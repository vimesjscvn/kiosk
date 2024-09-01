using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.PostModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using TEK.Gateway.Domain.BusinessObjects;

namespace Admin.API.Domain.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IListValueService _listValueService;
        private readonly IMapper _mapper;
        private readonly IHospitalSystemService _hospitalSystemService;
        private readonly HospitalSettings _hospitalSettings;
        public ClinicService(IUnitOfWork unitOfWork,
            IListValueService listValueService,
            IMapper mapper,
            IHospitalSystemService hospitalSystemService,
            HospitalSettings hospitalSettings
            )
        {
            _hospitalSettings = hospitalSettings;
            _unitOfWork = unitOfWork;
            _listValueService = listValueService;
            _mapper = mapper;
            _hospitalSystemService = hospitalSystemService;
        }

        public async Task<List<ClinicResultViewModel>> GetAllClinicResult(int? limit)
        {
            var take = limit ?? 5;
            var result = new List<ClinicResultViewModel>();
            var services = new List<GetRawFinallyClinicListResponseData>();

            //  Giới hạn ngày lấy số tiếp nhận
            var passClinicResultDayLimit = DateTime.Now.Date.AddDays(_hospitalSettings.Hospital.PassClinicResultDayLimit);

            //  Lấy danh sách số tiếp nhận với các điều kiện dưới 7 ngày và chưa thanh toán.
            var receptions = await _unitOfWork.GetRepository<Reception>().GetAll()
                .Where(x => (DateTime.Compare(x.RegisteredDate.Date, passClinicResultDayLimit) == 0
                || DateTime.Compare(x.RegisteredDate.Date, passClinicResultDayLimit) > 0)
                && !x.IsFinished).ToListAsync();

            if (receptions.Count == 0)
            {
                return result;
            }

            var registerCodes = receptions.Select(x => x.RegisteredCode).ToList();

            // Danh sách stn đã có kết quả
            var receptionResult = await _unitOfWork.GetRepository<ReceptionResult>().GetAll().Where(x => registerCodes.Any(r => r == x.RegisteredCode) && (x.Status == ReceptionResultStatus.TakeMoreClinicIsFull || x.Status == ReceptionResultStatus.NotYetTakeQueueNumberResult)).ToListAsync();

            if (receptionResult.Count == 0)
            {
                return result;
            }

            foreach (var reception in receptionResult)
            {
                // Bệnh nhân tương ứng
                var patient = reception.Patient;

                if (patient == null) continue;

                result.Add(new ClinicResultViewModel
                {
                    FullName = $"{patient.LastName} {patient.FirstName}",
                    PatientCode = patient.Code,
                    RegisteredCode = reception.RegisteredCode,
                    ResultDate = reception.UpdatedDate.ToString(),
                    Gender = (int)patient.Gender == 0 ? "Nữ" : "Nam",
                    Age = DateTime.Now.Year - patient.Birthday.Year
                });
            }
            return result.Take(take).OrderByDescending(x => Convert.ToDateTime(x.ResultDate)).ToList();
        }

        public async Task<ClinicResultResponse> GenerateClinicResultNumber(ClinicResultRequest request)
        {

            request.CardNumber = request.CardNumber.Trim();

            if (!StringUtils.ValidateCardNumber(request.CardNumber)) throw new Exception(ErrorMessages.InvalidCardNumber);

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.CardNumber);

            if (cardInfo == null) throw new Exception(ErrorMessages.NotFoundCardNumber);

            var patient = cardInfo.Patient ?? null;

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumberMappingWithPatient);
            }
            // Lấy repception result tương ứng (reception_result : lưu những số tiếp nhận đã có kết quả cận lâm sàng)
            var receptions = _unitOfWork.GetRepository<Reception>().GetAll().Where(x => x.PatientId == patient.Id && x.CreatedDate.Date == DateTime.Now.Date);
            // Lấy danh sách dịch vụ tương ứng với số tiếp nhận
            var clinics = await _unitOfWork.GetRepository<Clinic>().GetAll().Where(clinic => clinic.PatientId == patient.Id && receptions.Any(reception => reception.Id == clinic.ReceptionId)).ToListAsync();
            // Danh sách phòng chỉ định
            var departmentSpecified = clinics.Select(s => s.ExaminationExtendId).Distinct().ToList();

            var finishedDepartment = _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(lve =>
                                                                                            departmentSpecified.Any(id => lve.Id == id)
                                                                                            && (lve.ListValue.Code == "KB" || lve.ListValue.Code == "KBYC"))
                                                                                        .Distinct().ToList();

            var queueNumbersResult = new List<QueueNumberViewModel>();
            foreach (var item in finishedDepartment)
            {
                var virtualDept = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll().FirstOrDefaultAsync(deptGroup => deptGroup.ListValueExtendId == item.Id);
                queueNumbersResult.Add(await ProcessQueueNumberWithDepartment(patient, virtualDept.DepartmentVirtual));
            }

            string type = "";
            if (clinics.Count() > 0)
            {
                var listValue = await _listValueService.GetListValuesActivated(ValueTypeCode.ObjectCode);
                type = listValue.SingleOrDefault(x => x.Code == clinics.FirstOrDefault()?.Type)?.Description;
            }

            return new ClinicResultResponse
            {
                Type = type,
                Patient = _mapper.Map<PatientViewModel>(patient),
                QueueNumbers = queueNumbersResult
            };
        }

        private async Task<ResultQueueNumberViewModel> ProcessQueueNumberWithDepartment(Patient patient, ListValueExtend departmentExtend)
        {
            var queueNumber = new QueueNumberPostModel
            {
                DepartmentExtendId = departmentExtend.Id,
                DepartmentCode = departmentExtend.Code,
                PatientId = patient.Id
            };
            var queueNumberModel = _mapper.Map<QueueNumber>(queueNumber);

            // Cấp stt mới nếu BN có các chỉ định thêm (các dịch vụ chỉ định thêm cũng đã thực hiện)

            // Nếu ngày hôm nay đã lấy stt thì in lại số đã lấy, qua ngày thì sẽ in số mới
            var existing = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
               .OrderByDescending(c => c.Number)
               .FirstOrDefaultAsync(q => q.DepartmentExtendId == queueNumberModel.DepartmentExtendId
                                         && (DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0)
                                         && q.PatientId == queueNumberModel.PatientId);
            if (existing != null && !existing.IsSelected)
            {
                var response = _mapper.Map<ResultQueueNumberViewModel>(existing);
                response.DepartmentName = existing.DepartmentExtend?.Description;
                return response;

            }


            queueNumberModel.Type = patient.PatientType;

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentExtendId == queueNumberModel.DepartmentExtendId
                                              && (DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0));

            queueNumberModel.Number = last != null ? last.Number + 1 : 1;
            queueNumberModel.PatientId = patient.Id;

            var department = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(l => l.Code == queueNumberModel.DepartmentCode);
            queueNumberModel.DepartmentExtendId = department.Id;
            _unitOfWork.GetRepository<QueueNumber>().Add(queueNumberModel);
            await _unitOfWork.CommitAsync();

            var queueNumberViewModel = _mapper.Map<ResultQueueNumberViewModel>(queueNumberModel);
            queueNumberViewModel.DepartmentName = department?.Description;

            return queueNumberViewModel;
        }

        //public async Task<GetListClsResultResponse> GetListClsResult(GetListClsResultRequest request)
        //{
        //    var patient = await _unitOfWork.GetRepository<Patient>()
        //        .GetAll()
        //        .FirstOrDefaultAsync(x => x.Code == request.PatientCode);

        //    if (patient == null)
        //    {
        //        throw new Exception(ErrorMessages.NotFoundPatientCode);
        //    }

        //    var response = new GetListClsResultResponse();
        //    var hisClinics = new List<GetServiceResultRawResponse>();
        //    var clinics = new List<Clinic>();
        //    foreach (var registerCode in request.RegisteredCodes)
        //    {
        //        var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == registerCode);

        //        if (reception == null)
        //        {
        //            throw new Exception(ErrorMessages.NotFoundReceptionNumber);
        //        }

        //        var requestToHis = new GetServiceListResultRawRequest()
        //        {
        //            PatientCode = request.PatientCode,
        //            RegisteredCode = registerCode
        //        };

        //        hisClinics.AddRange(await _hospitalSystemService.GetClinicResult(requestToHis));
        //        clinics.AddRange(await _unitOfWork.GetRepository<Clinic>().GetAll()
        //                                    .Where(clinic => clinic.ReceptionId == reception.Id && clinic.PatientId == patient.Id)
        //                                    .ToListAsync());
        //    }

        //    var hisClinicResult = hisClinics.Join(clinics,
        //                                         hisClinic => hisClinic.IdSpecified,
        //                                         clinic => clinic.IdSpecified,
        //                                         (hisClinic, clinic) => new { Clinic = clinic, IsResult = hisClinic.ServiceStatus });

        //    var examinationRooms = hisClinicResult.DistinctBy(hisClinicResult => hisClinicResult.Clinic.ExaminationExtendId)
        //                                            .Select(hisClinicResult => hisClinicResult.Clinic.ExaminationExtend)
        //                                            .Where(examinationRoom => examinationRoom.ListValue.Code == "KB")
        //                                            .ToList();

        //    foreach (var examinationRoom in examinationRooms)
        //    {
        //        var examinationRoomResult = new ExaminationRoomResultViewModel();
        //        var clinicResultsByExamination = hisClinicResult.Where(hisClinicResult => hisClinicResult.Clinic.ExaminationExtendId == examinationRoom.Id);
        //        var reception = clinicResultsByExamination.DistinctBy(hisClinicResult => hisClinicResult.Clinic.ReceptionId)
        //                                        .Select(hisClinicResult => hisClinicResult.Clinic.Reception)
        //                                        .OrderByDescending(reception => reception.CreatedDate)
        //                                        .FirstOrDefault();

        //        var clinicResults = clinicResultsByExamination.Select(hisClinicResult => new ExaminationRoomClinicResultViewModel
        //        {
        //            Id = hisClinicResult.Clinic.IdSpecified,
        //            ServiceName = hisClinicResult.Clinic.ServiceExtend?.Description,
        //            IsResult = hisClinicResult.IsResult
        //        })
        //                                            .ToList();

        //        examinationRoomResult.Id = examinationRoom.Id.ToString();
        //        examinationRoomResult.RegisteredCode = reception?.RegisteredCode;
        //        examinationRoomResult.DepartmentName = examinationRoom.Description;
        //        examinationRoomResult.ClinicResults = clinicResults;
        //        examinationRoomResult.IsResult = !clinicResults.Any(clinicResult => !clinicResult.IsResult);
        //        response.examinationRoomResults.Add(examinationRoomResult);
        //    }
        //    return response;
        //}

        public DateTime ConvertDateTimeFromHis(string dateString)
        {
            var result = DateTime.MinValue;

            try
            {
                var date = dateString.Substring(0, 8);
                var time = dateString.Substring(9, 6);
                DateTime.TryParseExact($"{date} {time}", "yyyyMMdd HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public async Task<ClinicResultResponse> GenerateClinicResultNumberByExamination(ClinicResultByExaminationRequest request)
        {

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var queueNumbersResult = new List<QueueNumberViewModel>();
            foreach (var item in request.ExaminationIds)
            {
                var virtualDept = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll().FirstOrDefaultAsync(deptGroup => deptGroup.ListValueExtendId.ToString() == item);
                var resultQueueNumber = await ProcessQueueNumberWithDepartment(patient, virtualDept.DepartmentVirtual);
                resultQueueNumber.ExaminationId = item;
                queueNumbersResult.Add(resultQueueNumber);
            }

            return new ClinicResultResponse
            {
                Type = "",
                Patient = _mapper.Map<PatientViewModel>(patient),
                QueueNumbers = queueNumbersResult
            };
        }

        public Task<GetListClsResultResponse> GetListClsResult(GetListClsResultRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
