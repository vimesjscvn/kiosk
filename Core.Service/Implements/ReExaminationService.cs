using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Config.Helpers;
using Core.Config.Settings;
using Core.Domain.BusinessObjects;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IReExaminationService" />
    public class ReExaminationService : IReExaminationService
    {
        private readonly IExaminationService _examinationService;

        /// <summary>
        ///     Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        private readonly IInsuranceGatewayService _insuranceGatewayService;

        /// <summary>
        ///     Gets the insurance settings.
        /// </summary>
        /// <value>The insurance settings.</value>
        private readonly InsuranceSettings _insuranceSettings;

        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IPatientService _patientService;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReExaminationService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ReExaminationService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            IPatientService patientService,
            IExaminationService examinationService,
            IInsuranceGatewayService insuranceGatewayService,
            InsuranceSettings insuranceSettings,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _patientService = patientService;
            _examinationService = examinationService;
            _insuranceGatewayService = insuranceGatewayService;
            _insuranceSettings = AppConfig.LoadInsurance(insuranceSettings);
            _mapper = mapper;
        }

        public async Task<ICollection<ExaminationCalendar>> GetListByCodeAndDate(
            GetReExaminationListByCodeAndDateModel model, bool isAuto = false)
        {
            var reExams = await _hospitalSystemService.GetRawListReExaminationByCodeAndDate(
                new GetRawReExaminationListByCodeAndDateRequest
                {
                    PatientCode = model.PatientCode,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                });

            var calendars = new List<ExaminationCalendar>();

            if (reExams == null)
            {
                return calendars;
            }

            foreach (var item in reExams)
            {
                var activeDept = await _unitOfWork.GetRepository<Department>()
                    .GetAll()
                    .FirstOrDefaultAsync(c => c.DepartmentCode == item.DepartmentCode
                                              && c.GroupDeptCode == item.GroupDeptCode);

                if (activeDept != null && !activeDept.IsActive) continue;

                var calendar = await _unitOfWork.GetRepository<ExaminationCalendar>().GetAll().FirstOrDefaultAsync(c =>
                    c.PatientCode == item.PatientCode
                    && c.DepartmentCode == item.DepartmentCode
                    && c.RegisteredCode == item.RegisteredCode
                    && c.BookingId == item.BookingId);

                var depts = item.Departments.Where(w => w.DepartmentCode != calendar.DepartmentCode);

                if (calendar != null)
                {
                    calendar = _mapper.Map<ExaminationCalendar>(item);
                    calendar.WaitingNumber = "0";
                    calendar.MaxNumber = "0";
                    calendars.Add(calendar);

                    foreach (var department in depts)
                    {
                        var calendarDept = _mapper.Map<ExaminationCalendar>(item);
                        calendarDept.DepartmentName = department.DepartmentName;
                        calendarDept.DepartmentCode = department.DepartmentCode;
                        calendarDept.WaitingNumber = department.WaitingNumber;
                        calendarDept.MaxNumber = department.MaxNumber;
                        calendarDept.GroupDeptCode = department.GroupDeptCode;
                        calendars.Add(calendarDept);
                    }

                    continue;
                }

                calendar = _mapper.Map<ExaminationCalendar>(item);
                calendar.WaitingNumber = "0";
                calendar.MaxNumber = "0";
                _unitOfWork.GetRepository<ExaminationCalendar>().Add(calendar);
                await _unitOfWork.CommitAsync();
                calendars.Add(calendar);

                foreach (var department in depts)
                {
                    calendar.DepartmentName = department.DepartmentName;
                    calendar.DepartmentCode = department.DepartmentCode;
                    calendar.WaitingNumber = department.WaitingNumber;
                    calendar.MaxNumber = department.MaxNumber;
                    calendar.GroupDeptCode = department.GroupDeptCode;
                    calendars.Add(calendar);
                }
            }

            //calendars = calendars.Where(c => c.GroupDeptCode == "KB").ToList();
            if (isAuto && calendars.Count > 0)
                return new List<ExaminationCalendar>
                {
                    calendars.FirstOrDefault()
                };

            return calendars;
        }

        public async Task<ICollection<QueueNumber>> Create(Patient patient, List<ReExamRegistrationListModel> model,
            bool isThrowError = false)
        {
            var ip = model.FirstOrDefault()?.Ip;
            var result = new List<QueueNumber>();
            var bookingIds = model.Where(m => !string.IsNullOrEmpty(m.BookingId)).Select(s => s.BookingId).ToList();
            if (bookingIds.Count > 0)
                result = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .Where(q => bookingIds.Any(id => id == q.BookingId)).ToList();
            else
                foreach (var item in model)
                {
                    var groupDeptCode = item.GroupDeptCode == "KBNT" ? "KB" : item.GroupDeptCode;
                    var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(q =>
                        q.DepartmentCode == item.DepartmentCode
                        && q.GroupDeptCode == groupDeptCode
                        && q.PatientCode == item.PatientCode).FirstOrDefaultAsync();
                    if (number != null) result.Add(number);
                }

            if (result.Count > 0) return result;

            //if (!string.IsNullOrEmpty(patient.HealthInsuranceNumber))
            //{
            //    // Find patient in Tekmedi System
            //    var tokenResponse = await _insuranceGatewayService.PostRawLoginInsuranceGateway(new PostRawLoginInsuranceGatewayRequest
            //    {
            //        username = _insuranceSettings.Insurance.Username,
            //        password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password),
            //    });

            //    var verifyResponse = await _insuranceGatewayService.PostRawVerifyInsuranceGateway(new PostRawVerifyInsuranceGatewayRequest
            //    {
            //        token = tokenResponse.APIKey.access_token,
            //        id_token = tokenResponse.APIKey.id_token,
            //        hoTen = patient.LastName + " " + patient.FirstName,
            //        ngaySinh = patient.Birthday.ToString(DateTimeFormatConstants.YYYY),
            //        maThe = !string.IsNullOrEmpty(patient.IdentityCardNumber) ? patient.IdentityCardNumber : patient.HealthInsuranceNumber
            //    });

            //    if (verifyResponse.maKetQua != "000"
            //        && verifyResponse.maKetQua != "001"
            //        && verifyResponse.maKetQua != "002"
            //        && verifyResponse.maKetQua != "003"
            //        && verifyResponse.maKetQua != "004")
            //    {
            //        throw new Exception(verifyResponse.ghiChu);
            //    }

            //    var healthInsuranceFirstPlaceCode = verifyResponse.maDKBDMoi;
            //    var healthInsuranceFirstPlace = verifyResponse.tenDKBDMoi;
            //    var healthInsuranceIssuedDate = verifyResponse.gtTheTuMoi;
            //    var healthInsuranceExpiredDate = verifyResponse.gtTheDenMoi;

            //    patient.HealthInsuranceNumber = verifyResponse.maThe;
            //    patient.HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode;
            //    patient.HealthInsuranceFirstPlace = healthInsuranceFirstPlace;
            //    patient.HealthInsuranceIssuedDate = healthInsuranceIssuedDate.Length == 10 ? DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY,
            //                                CultureInfo.InvariantCulture) : DateTime.Now;
            //    patient.HealthInsuranceExpiredDate = DateTime.ParseExact(healthInsuranceExpiredDate, DateTimeFormatConstants.DDMMYYYY,
            //                                 CultureInfo.InvariantCulture);
            //}

            var reExamsResp = await _hospitalSystemService.PostRawRegisterReExamination(
                new PostRawRegisterReExaminationRequest
                {
                    PatientCode = patient.Code,
                    HealthInsuranceNumber = patient.HealthInsuranceNumber,
                    HealthInsuranceIssuedDate = patient.HealthInsuranceIssuedDate,
                    HealthInsuranceExpiredDate = patient.HealthInsuranceExpiredDate,
                    HealthInsuranceFirstPlaceCode = patient.HealthInsuranceFirstPlaceCode,
                    HealthInsuranceFirstPlace = patient.HealthInsuranceFirstPlace,
                    Departments = model
                        .Select(_mapper.Map<ReExamRegistrationListModel, PostRawRegisterReExaminationDataRequest>)
                        .ToList()
                });

            if (reExamsResp != null)
            {
                //_unitOfWork.GetRepository<Patient>().Update(patient);
                if (reExamsResp.Result != null && reExamsResp.Result.Count > 0)
                {
                    foreach (var item in reExamsResp.Result)
                    {
                        var number = new QueueNumber
                        {
                            BookingId = model.FirstOrDefault(m => m.DepartmentCode == item.DepartmentCode)?.BookingId,
                            GroupDeptCode = item.GroupDeptCode,
                            GroupDeptName = item.GroupDeptName,
                            DepartmentCode = item.DepartmentCode,
                            DepartmentName = item.DepartmentName,
                            DepartmentAddress = item.DepartmentAddress,
                            RegisteredCode = item.RegisteredCode,
                            RegisteredDate = item.RegisteredDate,
                            Number = item.Number,
                            PatientCode = patient.Code,
                            PatientId = patient.Id,
                            Title = DepartmentTitles.TAIKHAM,
                            Type = PatientType.Normal,
                            Ip = ip
                        };

                        result.Add(number);
                        _unitOfWork.GetRepository<QueueNumber>().Add(number);
                    }

                    await _unitOfWork.CommitAsync();
                    return result;
                }


                if (isThrowError)
                    if (reExamsResp.Result == null || reExamsResp.Result.Count == 0)
                    {
                        var errorMessage = string.Empty;

                        if (!string.IsNullOrEmpty(reExamsResp.ErrorMessage))
                            errorMessage += reExamsResp.ErrorMessage + " ";
                        else if (!string.IsNullOrEmpty(reExamsResp.Message))
                            errorMessage += reExamsResp.Message + " ";
                        else
                            errorMessage += ErrorMessages.Default + " ";

                        throw new Exception(errorMessage);
                    }
            }

            return result;
        }

        public async Task<ICollection<QueueNumber>> CreateAndGenerateNumber(Patient patient,
            List<ReExamRegistrationListModel> model)
        {
            var result = new List<QueueNumber>();

            foreach (var item in model)
            {
                var departmentCode = item.DepartmentCode;
                var registeredCode = item.RegisteredCode;
                var existedNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(p =>
                    p.PatientCode == patient.Code
                    && p.DepartmentCode == departmentCode
                    && (item.PatientType != PatientType.Normal
                        ? p.Type != PatientType.Normal
                        : p.Type == PatientType.Normal)).FirstOrDefault();
                if (existedNumber != null)
                {
                    result.Add(existedNumber);
                    continue;
                }

                var entity = new QueueNumber
                {
                    GroupDeptCode = item.GroupDeptCode,
                    GroupDeptName = item.GroupDeptName,
                    DepartmentCode = item.DepartmentCode,
                    DepartmentName = item.DepartmentName,
                    //DepartmentAddress = item.DepartmentAddress,
                    RegisteredCode = item.RegisteredCode,
                    RegisteredDate = item.RegisteredDate,
                    PatientCode = patient.Code,
                    PatientId = patient.Id,
                    Title = DepartmentTitles.PHONGKHAM,
                    Type = PatientType.Normal,
                    Ip = item.Ip
                };

                var last = new QueueNumber();
                if (entity.Type == PatientType.Normal)
                    last = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .OrderByDescending(c => c.Number)
                        .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                                                  && q.Type == PatientType.Normal);
                else
                    last = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .OrderByDescending(c => c.Number)
                        .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                                                  && q.Type != PatientType.Normal);

                entity.Number = last != null ? last.Number + 1 : 1;
                var department = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                    .SingleOrDefaultAsync(l => l.Code == entity.DepartmentCode);
                if (department != null)
                {
                    entity.DepartmentExtendId = department.Id;
                    entity.DepartmentName = department.Description;
                }

                result.Add(entity);
                _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            }

            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<ICollection<ExaminationCalendar>> GetManualListByCodeAndDate(
            GetReExaminationListByCodeAndDateModel model, bool isAuto = false)
        {
            var reExams = await _hospitalSystemService.GetRawListReExaminationByCodeAndDate(
                new GetRawReExaminationListByCodeAndDateRequest
                {
                    PatientCode = model.PatientCode,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                });

            var calendars = new List<ExaminationCalendar>();

            if (reExams.Count == 0)
            {
                var result = await _examinationService.GetListByPatientCode(model.PatientCode);

                if (result.Count == 0) throw new Exception(ErrorMessages.NotYetRegisteredExam);

                var examList = new List<GetRawExaminationDetailByCodeResponse>();
                //var receptions = result.OrderByDescending(o => o.RegisteredDate).Take(1).ToList();
                //if (receptions.Count > 0)
                //{
                //    foreach (var reception in receptions)
                //    {
                //        // Find patient in Tekmedi System
                //        var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(new GetRawExaminationDetailByCodeRequest
                //        {
                //            RegisteredCode = reception.RegisteredCode,
                //            PatientCode = reception.PatientCode
                //        });

                //        if (examinationRes != null
                //            && examinationRes.Result != null
                //            && examinationRes.Result.Examinations != null
                //            && examinationRes.Result.Examinations.Count > 0)
                //        {
                //            foreach (var item in examinationRes.Result.Examinations)
                //            {
                //                var calendar = _mapper.Map<GetRawExaminationDetailByCodeExaminationData, ExaminationCalendar>(item);
                //                calendar.WaitingNumber = "0";
                //                calendar.MaxNumber = "0";
                //                calendar.GroupDeptCode = "KB";
                //                calendar.GroupDeptName = "Khoa Khám Bệnh";
                //                calendar.RegisteredDate = DateTime.Now;
                //                calendars.Add(calendar);
                //            }
                //        }
                //    }
                //}

                var lastReception = result.OrderByDescending(o => o.RegisteredDate).FirstOrDefault();
                if (lastReception != null)
                {
                    // Find patient in Tekmedi System
                    var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(
                        new GetRawExaminationDetailByCodeRequest
                        {
                            RegisteredCode = lastReception.RegisteredCode,
                            PatientCode = lastReception.PatientCode
                        });

                    if (examinationRes != null
                        && examinationRes.Result != null
                        && examinationRes.Result.Examinations != null
                        && examinationRes.Result.Examinations.Count > 0)
                        foreach (var item in examinationRes.Result.Examinations)
                        {
                            var calendar =
                                _mapper.Map<GetRawExaminationDetailByCodeExaminationData, ExaminationCalendar>(item);
                            calendar.WaitingNumber = "0";
                            calendar.MaxNumber = "0";
                            calendar.GroupDeptCode = "KB";
                            calendar.GroupDeptName = "Khoa Khám Bệnh";
                            calendar.RegisteredDate = DateTime.Now;
                            calendars.Add(calendar);
                        }
                }
            }

            if (reExams.Count > 0)
                foreach (var item in reExams)
                {
                    var calendar = await _unitOfWork.GetRepository<ExaminationCalendar>().GetAll().FirstOrDefaultAsync(
                        c => c.PatientCode == item.PatientCode
                             && c.DepartmentCode == item.DepartmentCode
                             && c.RegisteredCode == item.RegisteredCode
                             && c.BookingId == item.BookingId);

                    var depts = item.Departments.Where(w => w.DepartmentCode != calendar.DepartmentCode);

                    if (calendar != null)
                    {
                        calendar = _mapper.Map<ExaminationCalendar>(item);
                        calendar.WaitingNumber = "0";
                        calendar.MaxNumber = "0";
                        calendars.Add(calendar);

                        foreach (var department in depts)
                        {
                            var calendarDept = _mapper.Map<ExaminationCalendar>(item);
                            calendarDept.DepartmentName = department.DepartmentName;
                            calendarDept.DepartmentCode = department.DepartmentCode;
                            calendarDept.WaitingNumber = department.WaitingNumber;
                            calendarDept.MaxNumber = department.MaxNumber;
                            calendarDept.GroupDeptCode = department.GroupDeptCode;
                            calendars.Add(calendarDept);
                        }

                        continue;
                    }

                    calendar = _mapper.Map<ExaminationCalendar>(item);
                    calendar.WaitingNumber = "0";
                    calendar.MaxNumber = "0";
                    _unitOfWork.GetRepository<ExaminationCalendar>().Add(calendar);
                    await _unitOfWork.CommitAsync();
                    calendars.Add(calendar);

                    foreach (var department in depts)
                    {
                        calendar.DepartmentName = department.DepartmentName;
                        calendar.DepartmentCode = department.DepartmentCode;
                        calendar.WaitingNumber = department.WaitingNumber;
                        calendar.MaxNumber = department.MaxNumber;
                        calendar.GroupDeptCode = department.GroupDeptCode;
                        calendars.Add(calendar);
                    }
                }

            calendars = calendars.Where(c => c.GroupDeptCode == "KB").ToList();
            if (isAuto && calendars.Count > 0)
                return new List<ExaminationCalendar>
                {
                    calendars.FirstOrDefault()
                };

            return calendars;
        }
    }
}