using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Domain.BusinessObjects;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IPatientService" />
    public class PatientService : IPatientService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        private readonly IInsuranceGatewayService _insuranceGatewayService;

        /// <summary>
        /// Gets the insurance settings.
        /// </summary>
        /// <value>The insurance settings.</value>
        private readonly InsuranceSettings _insuranceSettings;

        /// <summary>
        /// The location service
        /// </summary>
        private readonly ILocationService _locationService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        private readonly HospitalSettings _hospitalSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public PatientService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            ILocationService locationService,
            IInsuranceGatewayService insuranceGatewayService,
            InsuranceSettings insuranceSettings,
            HospitalSettings hospitalSettings,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _locationService = locationService;
            _insuranceGatewayService = insuranceGatewayService;
            _insuranceSettings = insuranceSettings;
            _hospitalSettings = hospitalSettings;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public Patient Add(Patient entity)
        {
            _unitOfWork.GetRepository<Patient>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Patient> AddAsync(Patient entity)
        {
            _unitOfWork.GetRepository<Patient>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Patient>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Patient>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Patient entity)
        {
            _unitOfWork.GetRepository<Patient>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Patient>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Patient entity)
        {
            _unitOfWork.GetRepository<Patient>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Patient>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Patient Find(Expression<Func<Patient, bool>> match)
        {
            return _unitOfWork.GetRepository<Patient>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Patient> FindAll(Expression<Func<Patient, bool>> match)
        {
            return _unitOfWork.GetRepository<Patient>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Patient>> FindAllAsync(Expression<Func<Patient, bool>> match)
        {
            return await _unitOfWork.GetRepository<Patient>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Patient> FindAsync(Expression<Func<Patient, bool>> match)
        {
            return await _unitOfWork.GetRepository<Patient>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Patient Get(Guid id)
        {
            return _unitOfWork.GetRepository<Patient>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Patient> GetAll()
        {
            return _unitOfWork.GetRepository<Patient>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Patient>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Patient>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Patient> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Patient>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Patient.</returns>
        public Patient Update(Patient entity, Guid id)
        {
            if (entity == null)
                return null;

            Patient existing = _unitOfWork.GetRepository<Patient>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Patient>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Patient.
        /// </returns>
        public async Task<Patient> UpdateAsync(Patient entity, Guid id)
        {
            if (entity == null)
                return null;

            Patient existing = await _unitOfWork.GetRepository<Patient>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Patient>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Task&lt;Patient&gt;.
        /// </returns>
        public async Task<Patient> GetByPatientCode(string code)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);
            if (patient == null)
            {
                // Find patient in Tekmedi System
                var response = await _hospitalSystemService.GetRawPatient(new GetRawPatientRequest
                {
                    Code = code
                });

                if (response == null)
                {
                    return null;
                }

                patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == response.PatientCode);

                if (patient != null)
                {
                    return patient;
                }

                patient = _mapper.Map<GetRawPatientData, Patient>(response);
                _unitOfWork.GetRepository<Patient>().Add(patient);
                await _unitOfWork.CommitAsync();

                return patient;
            }

            return patient;
        }

        public async Task<Patient> GetByHealthInsuranceNumber(string healthInsuranceNumber)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.HealthInsuranceNumber == healthInsuranceNumber);
            return patient;
        }

        public async Task<Patient> GetByRegisteredCode(string registeredCode)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(item => item.RegisteredCode == registeredCode);
            if (reception == null)
            {
                // Find patient in Tekmedi System
                var response = await _hospitalSystemService.GetRawPatientByRegisteredCode(new GetRawPatientByRegisteredCodeRequest
                {
                    RegisteredCode = registeredCode
                });

                var patientRes = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == response.PatientCode);

                if (patientRes != null && !string.IsNullOrEmpty(patientRes.Code))
                {
                    return patientRes;
                }

                patientRes = _mapper.Map<Patient>(response);
                _unitOfWork.GetRepository<Patient>().Add(patientRes);
                await _unitOfWork.CommitAsync();

                return patientRes;
            }

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == reception.PatientCode);
            return patient;
        }

        /// <summary>
        /// Gets all calendar by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<ExaminationCalendar>> GetAllCalendar(GetCalendarByRegisteredCodeRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == request.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var response = await _hospitalSystemService.GetRawAllCalendar(new GetRawAllCalendarRequest
            {
                PatientCode = request.PatientCode,
                RegisteredCode = request.RegisteredCode
            });

            var calendars = new List<ExaminationCalendar>();

            Parallel.ForEach(response, item =>
            {
                var calendar = _mapper.Map<ExaminationCalendar>(item);
                calendar.PatientId = patient.Id;
                _unitOfWork.GetRepository<ExaminationCalendar>().Add(calendar);
                calendars.Add(calendar);
            });

            await _unitOfWork.CommitAsync();
            return calendars;
        }

        /// <summary>
        /// Gets the calendar by date.
        /// </summary>
        /// <param name="request">The get calendar by date request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ICollection<ExaminationCalendar>> GetCalendarByDate(GetCalendarByDateRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == request.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var responses = new List<GetRawCalendarResponseData>();

            foreach (DateTime day in DateUtils.EachCalendarDay(request.StartDate, request.EndDate))
            {
                var response = await _hospitalSystemService.GetRawAllCalendarByDate(new GetRawCalendarRequest
                {
                    PatientCode = request.PatientCode,
                    RegisteredDate = day
                });

                if (response != null && response.Count > 0)
                {
                    responses.AddRange(response);
                }
            }

            var calendars = new List<ExaminationCalendar>();

            foreach (var item in responses)
            {
                var calendar = _mapper.Map<ExaminationCalendar>(item);
                calendar.PatientId = patient.Id;
                _unitOfWork.GetRepository<ExaminationCalendar>().Add(calendar);
                calendars.Add(calendar);
            }

            await _unitOfWork.CommitAsync();
            return calendars;
        }

        /// <summary>
        /// Gets the patient by qr code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<TempPatient> GetPatientByQRCode(string code, List<Functions> functionsIds)
        {
            Patient patient = null;
            //var isSyncPatient = functionsIds != null && functionsIds.Where(f => f == Functions.EXAMINATION_REGISTRATION
            //|| f == Functions.DIAGNOSING_IMAGE
            //|| f == Functions.RE_EXAMINATION_REGISTRATION
            //|| f == Functions.HEALTH_EXAMINATION_RECORDS
            //|| f == Functions.PAYMENT_ORDER_NUMBER).Count() > 0;

            var isSyncPatient = true;

            bool verifyQrCode(string qrCode)
            {
                if (string.IsNullOrEmpty(qrCode))
                {
                    return false;
                }

                var qrCodeParts = qrCode.Split("|");
                if (qrCodeParts.Count() < 15)
                {
                    return false;
                }

                if (qrCodeParts[0].Length != 10 && qrCodeParts[0].Length != 15)
                {
                    return false;
                }

                if (qrCodeParts[1].Length == 0)
                {
                    return false;
                }

                if ((qrCodeParts[2].Length != 4 && qrCodeParts[2].Length != 10)
                    || (qrCodeParts[2].Length == 4 && !qrCodeParts[2].All(Char.IsDigit)))
                {
                    return false;
                }

                try
                {
                    if ((qrCodeParts[2].Length == 10))
                    {
                        var date = DateTime.ParseExact(qrCodeParts[2], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

                return true;
            }

            if (!verifyQrCode(code))
            {
                throw new Exception(ErrorMessages.InvalidQRCode);
            }

            var parts = code.Split("|").ToList();
            var insuranceCode = parts[0];
            var dob = parts[2];
            var name = StringUtils.Hex2utf8(parts[1]) ?? "";
            var gender = int.Parse(parts[3] ?? "1") == 2 ? 0 : 1;

            var birthday = dob.Length == 4
                ? new DateTime(int.Parse(dob), 01, 01)
                : DateTime.ParseExact(dob, DateTimeFormatConstants.DDMMYYYY, CultureInfo.InvariantCulture);

            // Find patient in Tekmedi System
            var tokenResponse = await _insuranceGatewayService.PostRawLoginInsuranceGateway(new PostRawLoginInsuranceGatewayRequest
            {
                username = _insuranceSettings.Insurance.Username,
                password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password),
            });

            var verifyResponse = await _insuranceGatewayService.PostRawVerifyInsuranceGateway(new PostRawVerifyInsuranceGatewayRequest
            {
                token = tokenResponse.APIKey.access_token,
                id_token = tokenResponse.APIKey.id_token,
                hoTen = name,
                ngaySinh = birthday.ToString(DateTimeFormatConstants.YYYY),
                maThe = insuranceCode
            });

            //Thẻ do BHXH Bộ Quốc Phòng quản lý
            if (verifyResponse.maKetQua == "001")
            {
                return await GetPatientByQRCodeWithNoCheckSocialGateway(code);
            }

            var address = verifyResponse.diaChi;
            var healthInsuranceFirstPlaceCode = verifyResponse.maDKBD;
            var healthInsuranceFirstPlace = verifyResponse.cqBHXH;
            var healthInsuranceIssuedDate = verifyResponse.gtTheTu;
            var healthInsuranceExpiredDate = verifyResponse.gtTheDen;
            var location = new Location();

            var addressParts = address.Split(",");
            var isDash = address.IndexOf("-") >= 0;
            if (isDash && addressParts.Length < 3)
            {
                addressParts = address.Split("-");
            }

            for (var i = addressParts.Length - 1; i >= 0; i--)
            {
                var indexFromEnd = addressParts.Length - i - 1;
                var part = addressParts[i];
                var normalizedAddress = StringUtils.NormalizeAddress(part);

                if (indexFromEnd == 0)
                {
                    var province = await _unitOfWork.GetRepository<Province>().GetAll().SingleOrDefaultAsync(p =>
                       p.SearchText == normalizedAddress);
                    if (province != null)
                    {
                        addressParts[i] = "";
                        location.Province = province.Name;
                        location.ProvinceCode = province.Code;
                        continue;
                    }
                    break;
                }

                if (indexFromEnd == 1)
                {
                    var district = await _unitOfWork.GetRepository<District>().GetAll().SingleOrDefaultAsync(district1 =>
                        district1.ProvinceCode == location.ProvinceCode &&
                        district1.SearchText == normalizedAddress);
                    if (district != null)
                    {
                        addressParts[i] = "";
                        location.District = district.Name;
                        location.DistrictCode = district.Code;
                        continue;
                    }

                    break;
                }

                if (indexFromEnd == 2)
                {
                    var ward = await _unitOfWork.GetRepository<Ward>().GetAll().SingleOrDefaultAsync(ward1 =>
                        ward1.DistrictCode == location.DistrictCode && ward1.SearchText == normalizedAddress);
                    if (ward != null)
                    {
                        addressParts[i] = "";
                        location.Ward = ward.Name;
                        location.WardCode = ward.Code;
                        continue;
                    }

                    break;
                }

                address = !string.IsNullOrEmpty(location.ProvinceCode) ? addressParts.Where(s => s != "").Join(", ") : "";
            }

            if (!string.IsNullOrEmpty(insuranceCode))
            {
                patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.HealthInsuranceNumber == insuranceCode);

                if (patient != null)
                {
                    patient.HealthInsuranceNumber = verifyResponse.maThe;
                    patient.HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode;
                    patient.HealthInsuranceFirstPlace = healthInsuranceFirstPlace;
                    patient.HealthInsuranceIssuedDate = healthInsuranceIssuedDate.Length == 10 ? DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY,
                                                CultureInfo.InvariantCulture) : DateTime.Now;
                    patient.HealthInsuranceExpiredDate = DateTime.ParseExact(healthInsuranceExpiredDate, DateTimeFormatConstants.DDMMYYYY,
                                                 CultureInfo.InvariantCulture);

                    _unitOfWork.GetRepository<Patient>().Update(patient);
                    await _unitOfWork.CommitAsync();
                    return _mapper.Map<Patient, TempPatient>(patient);
                }
            }

            if (isSyncPatient)
            {
                if (!string.IsNullOrEmpty(verifyResponse.maThe))
                {
                    patient = await GetByCode(DocumentTypes.BHYT, verifyResponse.maThe);
                }

                if (patient == null)
                {
                    if (!string.IsNullOrEmpty(verifyResponse.maTheCu))
                    {
                        patient = await GetByCode(DocumentTypes.BHYT, verifyResponse.maTheCu);
                    }

                    if (patient == null)
                    {
                        if (!string.IsNullOrEmpty(verifyResponse.maTheMoi) && verifyResponse.maTheMoi != verifyResponse.maThe)
                        {
                            patient = await GetByCode(DocumentTypes.BHYT, verifyResponse.maTheMoi);
                        }
                    }
                }
            }

            if (patient != null)
            {
                patient.HealthInsuranceNumber = verifyResponse.maThe;
                patient.HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode;
                patient.HealthInsuranceFirstPlace = healthInsuranceFirstPlace;
                patient.HealthInsuranceIssuedDate = healthInsuranceIssuedDate.Length == 10 ? DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY,
                                            CultureInfo.InvariantCulture) : DateTime.Now;
                patient.HealthInsuranceExpiredDate = DateTime.ParseExact(healthInsuranceExpiredDate, DateTimeFormatConstants.DDMMYYYY,
                                             CultureInfo.InvariantCulture);

                _unitOfWork.GetRepository<Patient>().Update(patient);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<Patient, TempPatient>(patient);
            }

            return new TempPatient
            {
                HealthInsuranceNumber = insuranceCode,
                HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode,
                HealthInsuranceFirstPlace = healthInsuranceFirstPlace,
                HealthInsuranceIssuedDate = !string.IsNullOrEmpty(healthInsuranceIssuedDate)
                && healthInsuranceIssuedDate.Length == 10
                ? DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY, CultureInfo.InvariantCulture)
                : DateTime.Now,
                HealthInsuranceExpiredDate = !string.IsNullOrEmpty(healthInsuranceExpiredDate)
                && healthInsuranceExpiredDate.Length == 10
                ? DateTime.ParseExact(healthInsuranceExpiredDate, DateTimeFormatConstants.DDMMYYYY, CultureInfo.InvariantCulture)
                : DateTime.Now,
                LastName = name.Split(" ")[0],
                FirstName = name.Split(" ").Where((s, i) => i > 0).Join(" "),
                Birthday = dob.Length == 4
                                        ? new DateTime(int.Parse(dob), 01, 01)
                                        : DateTime.ParseExact(dob, DateTimeFormatConstants.DDMMYYYY, CultureInfo.InvariantCulture),
                BirthdayYearOnly = dob.Length == 4,
                Gender = gender == 1 ? Gender.Male : Gender.Female,
                ProvinceId = location.ProvinceCode,
                DistrictId = location.DistrictCode,
                WardId = location.WardCode,
                Street = address
            };
        }

        /// <summary>
        /// Gets the patient by qr code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public async Task<TempPatient> GetPatientByNationalIdQRCode(string code, List<Functions> functionsIds)
        {
            Patient patient = null;
            //var isSyncPatient = functionsIds != null && functionsIds.Where(f => f == Functions.EXAMINATION_REGISTRATION
            //|| f == Functions.DIAGNOSING_IMAGE
            //|| f == Functions.RE_EXAMINATION_REGISTRATION
            //|| f == Functions.HEALTH_EXAMINATION_RECORDS
            //|| f == Functions.PAYMENT_ORDER_NUMBER).Count() > 0;

            var isSyncPatient = false;

            bool verifyQrCode(string qrCode)
            {
                if (string.IsNullOrEmpty(qrCode))
                {
                    return false;
                }

                var qrCodeParts = qrCode.Split("|");
                if (qrCodeParts.Count() < 7)
                {
                    return false;
                }

                if (qrCodeParts[0].Length != 12)
                {
                    return false;
                }

                try
                {
                    if ((qrCodeParts[3].Length == 8))
                    {
                        var date = DateTime.ParseExact(qrCodeParts[3], "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

                return true;
            }

            if (!verifyQrCode(code))
            {
                throw new Exception(ErrorMessages.InvalidQRCode);
            }

            var parts = code.Split("|").ToList();
            var nationalId = parts[0];
            var dob = parts[3];

            var name = parts[2];
            var gender = parts[4] == "Nam" ? 1 : 0;
            var address = parts[5];

            var birthday = dob.Length == 4
                ? new DateTime(int.Parse(dob), 01, 01)
                : DateTime.ParseExact(dob, DateTimeFormatConstants.DDMMYYYYNS, CultureInfo.InvariantCulture);

            // Find patient in Tekmedi System
            var tokenResponse = await _insuranceGatewayService.PostRawLoginInsuranceGateway(new PostRawLoginInsuranceGatewayRequest
            {
                username = _insuranceSettings.Insurance.Username,
                password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password),
            });

            var verifyResponse = await _insuranceGatewayService.PostRawVerifyInsuranceGateway(new PostRawVerifyInsuranceGatewayRequest
            {
                token = tokenResponse.APIKey.access_token,
                id_token = tokenResponse.APIKey.id_token,
                hoTen = name,
                ngaySinh = birthday.ToString(DateTimeFormatConstants.YYYY),
                maThe = nationalId
            });

            if (!string.IsNullOrEmpty(nationalId))
            {
                patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.IdentityCardNumber == nationalId);
                isSyncPatient = patient != null && name.Contains(patient.FirstName);
                if (isSyncPatient)
                {
                    return _mapper.Map<Patient, TempPatient>(patient);
                }
            }

            if (!isSyncPatient)
            {
                patient = await GetByCode(DocumentTypes.CCCD, nationalId);
                isSyncPatient = patient != null && name.Contains(patient.FirstName);
                if (isSyncPatient)
                {
                    return _mapper.Map<Patient, TempPatient>(patient);
                }
            }

            if (!isSyncPatient)
            {
                if (!string.IsNullOrEmpty(verifyResponse.maThe))
                {
                    patient = await GetByCode(DocumentTypes.BHYT, verifyResponse.maThe);
                }

                if (patient == null)
                {
                    if (!string.IsNullOrEmpty(verifyResponse.maTheCu))
                    {
                        patient = await GetByCode(DocumentTypes.BHYT, verifyResponse.maTheCu);
                    }

                    if (patient == null)
                    {
                        if (!string.IsNullOrEmpty(verifyResponse.maTheMoi) && verifyResponse.maTheMoi != verifyResponse.maThe)
                        {
                            patient = await GetByCode(DocumentTypes.BHYT, verifyResponse.maTheMoi);
                        }
                    }
                }

                isSyncPatient = patient != null && name.Contains(patient.FirstName);
                if (isSyncPatient)
                {
                    return _mapper.Map<Patient, TempPatient>(patient);
                }
            }

            var location = new Location();

            var addressParts = address.Split(",");

            for (var i = addressParts.Length - 1; i >= 0; i--)
            {
                var indexFromEnd = addressParts.Length - i - 1;
                var part = addressParts[i];
                var normalizedAddress = StringUtils.NormalizeAddress(part);
                var unidentified = "khôngxácđịnh";

                if (indexFromEnd == 0)
                {
                    var mostMatchProvince = _unitOfWork.GetRepository<Province>().GetAll().ToList().Select(province => new Tuple<string, string, int>(
                        province.Code, province.Name, CalculateDistance(StringUtils.NormalizeAddress(province.Name), normalizedAddress))).OrderBy(tup => tup.Item3).FirstOrDefault();

                    if (mostMatchProvince != null && mostMatchProvince.Item3 < 2)
                    {
                        addressParts[i] = "";
                        location.Province = mostMatchProvince.Item2;
                        location.ProvinceCode = mostMatchProvince.Item1;
                        continue;
                    }

                    var unidentifiedProvince = _unitOfWork.GetRepository<Province>().GetAll().Where(province => province.SearchText == unidentified).FirstOrDefault();
                    if (unidentifiedProvince != null)
                    {
                        location.Province = unidentifiedProvince.Name;
                        location.ProvinceCode = unidentifiedProvince.Code;
                    }
                    break;
                }

                if (indexFromEnd == 1)
                {

                    var mostMatchDistrict = _unitOfWork.GetRepository<District>().GetAll().Where(district1 => district1.ProvinceCode == location.ProvinceCode).ToList().Select(district => new Tuple<string, string, int>(
                        district.Code, district.Name, CalculateDistance(StringUtils.NormalizeAddress(district.Name), normalizedAddress))).OrderBy(tup => tup.Item3).FirstOrDefault();
                    if (mostMatchDistrict != null && mostMatchDistrict.Item3 < 2)
                    {
                        addressParts[i] = "";
                        location.District = mostMatchDistrict.Item2;
                        location.DistrictCode = mostMatchDistrict.Item1;
                        continue;
                    }

                    var unidentifiedDistrict = _unitOfWork.GetRepository<District>().GetAll().Where(district => district.ProvinceCode == location.ProvinceCode && district.SearchText == unidentified).FirstOrDefault();
                    if (unidentifiedDistrict != null)
                    {
                        location.District = unidentifiedDistrict.Name;
                        location.DistrictCode = unidentifiedDistrict.Code;
                    }
                    break;
                }

                if (indexFromEnd == 2)
                {
                    var mostMatchWard = _unitOfWork.GetRepository<Ward>().GetAll().Where(ward1 => ward1.DistrictCode == location.DistrictCode).ToList().Select(ward1 => new Tuple<string, string, int>(
                       ward1.Code, ward1.Name, CalculateDistance(StringUtils.NormalizeAddress(ward1.Name), normalizedAddress))).OrderBy(tup => tup.Item3).FirstOrDefault();

                    if (mostMatchWard != null && mostMatchWard.Item3 < 2)
                    {
                        addressParts[i] = "";
                        location.Ward = mostMatchWard.Item2;
                        location.WardCode = mostMatchWard.Item1;
                        continue;
                    }
                    var unidentifiedWard = _unitOfWork.GetRepository<Ward>().GetAll().Where(ward => ward.DistrictCode == location.DistrictCode && ward.SearchText == unidentified).FirstOrDefault();
                    if (unidentifiedWard != null)
                    {
                        location.Ward = unidentifiedWard.Name;
                        location.WardCode = unidentifiedWard.Code;
                    }
                    break;
                }
            }
            address = !string.IsNullOrEmpty(location.ProvinceCode) ? addressParts.Where(s => s != "").Join(", ") : parts[5];

            return new TempPatient
            {
                LastName = name.Split(" ")[0],
                FirstName = name.Split(" ").Where((s, i) => i > 0).Join(" "),
                Birthday = dob.Length == 4
                                        ? new DateTime(int.Parse(dob), 01, 01)
                                        : DateTime.ParseExact(dob, DateTimeFormatConstants.DDMMYYYYNS, CultureInfo.InvariantCulture),
                BirthdayYearOnly = dob.Length == 4,
                Gender = gender == 1 ? Gender.Male : Gender.Female,
                ProvinceId = location.ProvinceCode,
                DistrictId = location.DistrictCode,
                WardId = location.WardCode,
                Street = address,
                IdentityCardNumber = nationalId
            };
        }

        public async Task<TempPatient> GetPatientByQRCodeWithNoCheckSocialGateway(string code)
        {
            Patient patient = null;
            var parts = code.Split("|").ToList();
            var insuranceCode = parts[0];

            patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.HealthInsuranceNumber == insuranceCode);
            if (patient != null)
            {
                return _mapper.Map<Patient, TempPatient>(patient);
            }

            patient = await GetByCode(DocumentTypes.BHYT, insuranceCode);
            if (patient != null)
            {
                return _mapper.Map<Patient, TempPatient>(patient);
            }

            parts.RemoveAt(0);
            var hexValues = parts.Where(StringUtils.IsPossibleHexStr).Select(StringUtils.Hex2utf8).Where(s => s != null)
                .ToList();
            var birthYear = parts.Where(StringUtils.IsBirthYear).SingleOrDefault();
            var dateValues = parts.Where(StringUtils.IsDate).ToList();
            var dob = "";

            if (birthYear != null)
            {
                dob = birthYear;
            }
            else
            {
                dob = dateValues[0];
                dateValues.RemoveAt(0);
            }

            var name = hexValues[0];
            var gender = int.Parse(parts.FirstOrDefault(StringUtils.IsGender) ?? "1") == 2 ? 0 : 1;
            var address = hexValues[1].Split("_")[0];
            var healthInsuranceFirstPlaceCode = parts.Where(StringUtils.IsPlaceCode).SingleOrDefault();
            var healthInsuranceIssuedDate = dateValues[0];
            var healthInsuranceExpiredDate = dateValues[1];
            var location = new Location();

            var addressParts = address.Split(",");

            for (var i = addressParts.Length - 1; i >= 0; i--)
            {
                var indexFromEnd = addressParts.Length - i - 1;
                var part = addressParts[i];
                var normalizedAddress = StringUtils.NormalizeAddress(part);

                if (indexFromEnd == 0)
                {
                    var province = await _unitOfWork.GetRepository<Province>().GetAll().SingleOrDefaultAsync(p =>
                        p.SearchText == normalizedAddress);
                    if (province != null)
                    {
                        addressParts[i] = "";
                        location.Province = province.Name;
                        location.ProvinceCode = province.Code;
                        continue;
                    }

                    break;
                }

                if (indexFromEnd == 1)
                {
                    var district = await _unitOfWork.GetRepository<District>().GetAll().SingleOrDefaultAsync(
                        district1 =>
                            district1.ProvinceCode == location.ProvinceCode &&
                            district1.SearchText == normalizedAddress);
                    if (district != null)
                    {
                        addressParts[i] = "";
                        location.District = district.Name;
                        location.DistrictCode = district.Code;
                        continue;
                    }

                    break;
                }

                if (indexFromEnd == 2)
                {
                    var ward = await _unitOfWork.GetRepository<Ward>().GetAll().SingleOrDefaultAsync(ward1 =>
                        ward1.DistrictCode == location.DistrictCode && ward1.SearchText == normalizedAddress);
                    if (ward != null)
                    {
                        addressParts[i] = "";
                        location.Ward = ward.Name;
                        location.WardCode = ward.Code;
                        continue;
                    }

                    break;
                }

                address = !string.IsNullOrEmpty(location.ProvinceCode) ? addressParts.Where(s => s != "").Join() : "";
            }

            return new TempPatient
            {
                HealthInsuranceNumber = insuranceCode,
                HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode,
                HealthInsuranceIssuedDate = DateTime.ParseExact(healthInsuranceIssuedDate,
                    DateTimeFormatConstants.DDMMYYYY,
                    CultureInfo.InvariantCulture),
                HealthInsuranceExpiredDate = DateTime.ParseExact(healthInsuranceIssuedDate,
                    DateTimeFormatConstants.DDMMYYYY,
                    CultureInfo.InvariantCulture),
                LastName = name.Split(" ")[0],
                FirstName = name.Split(" ").Where((s, i) => i > 0).Join(" "),
                Birthday = dob.Length == 4
                    ? new DateTime(int.Parse(dob), 01, 01)
                    : DateTime.ParseExact(dob, DateTimeFormatConstants.DDMMYYYY, CultureInfo.InvariantCulture),
                BirthdayYearOnly = dob.Length == 4,
                Gender = gender == 1 ? Gender.Male : Gender.Female,
                ProvinceId = location.ProvinceCode,
                DistrictId = location.DistrictCode,
                WardId = location.WardCode,
                Street = address
            };
        }

        int CalculateDistance(string first, string second)
        {
            int[,] array = new int[first.Count() + 1, second.Count() + 1];

            for (int index = 0; index < first.Count() + 1; index++)
            {
                array[index, 0] = index;
            }

            for (int index = 0; index < second.Count() + 1; index++)
            {
                array[0, index] = index;
            }

            for (int index = 1; index < first.Count() + 1; index++)
            {
                for (int rowIndex = 1; rowIndex < second.Count() + 1; rowIndex++)
                {
                    if (first[index - 1] == second[rowIndex - 1])
                    {
                        array[index, rowIndex] = array[index - 1, rowIndex - 1];
                    }
                    else
                    {
                        array[index, rowIndex] = Math.Min(array[index, rowIndex - 1] + 1, array[index - 1, rowIndex] + 1);
                        array[index, rowIndex] = Math.Min(array[index, rowIndex], array[index - 1, rowIndex - 1] + 1);
                    }
                }
            }
            return array[first.Count(), second.Count()];
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<PatientInfoViewModel>> GetAllAsync(DataTableParameters parameters)
        {
            var data = new ConcurrentBag<PatientInfoViewModel>();
            var result = new TableResultJsonResponse<PatientInfoViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var predicate = PredicateBuilder.True<Patient>();

            if (!string.IsNullOrEmpty(parameters.Search.Value))
            {
                var searchValue = parameters.Search.Value.ToLower();
                predicate = PredicateBuilder.Create<Patient>(p => p.Code.ToLower().Contains(searchValue));
                predicate = predicate.Or(p => !string.IsNullOrEmpty(p.LastName) && p.LastName.ToLower().Contains(searchValue));
                predicate = predicate.Or(p => !string.IsNullOrEmpty(p.FirstName) && p.FirstName.ToLower().Contains(searchValue));
            }

            var patients = _unitOfWork.GetRepository<Patient>().GetAll().Where(predicate)
                .OrderBy(l => l.UpdatedDate);

            var totalRecord = patients.Count();
            var filteredPatients = await patients.Skip(parameters.Start).Take(parameters.Length).ToListAsync();

            foreach (var patient in filteredPatients)
            {
                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                data.Add(ToPatientInfoViewModel(patient, province, district, ward));
            }

            result.Draw = parameters.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data.ToList();

            return result;
        }

        /// <summary>
        /// Converts to patientinfoviewmodel.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="province">The province.</param>
        /// <param name="district">The district.</param>
        /// <param name="ward">The ward.</param>
        /// <returns></returns>
        private PatientInfoViewModel ToPatientInfoViewModel(Patient data, Province province, District district, Ward ward)
        {
            return new PatientInfoViewModel
            {
                Id = data.Id,
                TekmediId = data.TekmediId,
                FirstName = data.FirstName,
                Gender = data.Gender == Gender.Male ? GenderConstants.Male : GenderConstants.Female,
                Birthday = data.Birthday,
                BirthdayYearOnly = data.BirthdayYearOnly,
                ProvinceId = data.ProvinceCode,
                ProvinceName = province?.Name,
                DistrictId = data.DistrictCode,
                DistrictName = district?.Name,
                WardId = data.WardCode,
                WardName = ward?.Name,
                Phone = data.Phone,
                HealthInsuranceNumber = data.HealthInsuranceNumber,
                HealthInsuranceExpiredDate = data.HealthInsuranceExpiredDate,
                HealthInsuranceFirstPlaceCode = data.HealthInsuranceFirstPlaceCode,
                HealthInsuranceFirstPlace = data.HealthInsuranceFirstPlace,
                HealthInsuranceIssuedDate = data.HealthInsuranceIssuedDate,
                Code = data.Code,
                TekmediCardNumber = data.TekmediCardNumber,
                Email = data.Email,
                UnitNumber = data.UnitNumber,
                Street = data.Street,
                Village = data.Village,
                LastName = data.LastName,
                //Price = data.Balance,
                IdentityCardNumber = data.IdentityCardNumber,
                IdentityCardNumberIssuedDate = data.IdentityCardNumberIssuedDate,
                IdentityCardNumberIssuedPlace = data.IdentityCardNumberIssuedPlace,
                PatientType = data.PatientType,
                IsActive = data.IsActive
            };
        }

        /// <summary>
        /// Checks the code unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> CheckCodeUnique(CheckCodeUniqueRequest request)
        {
            return await _unitOfWork.GetRepository<Patient>()
                .GetAll()
                .Where(x => x.Code.ToLower() == request.Code.ToLower() && x.Id != request.Id)
                .FirstOrDefaultAsync() != null;
        }

        /// <summary>
        /// Updates the patient.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PatientInfoViewModel> UpdatePatient(Guid patientId, PatientInfoViewModel request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == patientId);
            if (patient == null) throw new Exception(ErrorMessages.NotFoundPatientCode);

            var modelUpdate = _mapper.Map<Patient>(request);
            var model = await UpdateAsync(modelUpdate, patientId);
            var province = await _locationService.GetProvince(model.ProvinceCode);
            var district = await _locationService.GetDistrict(model.ProvinceCode, model.DistrictCode);
            var ward = await _locationService.GetWard(model.DistrictCode, model.WardCode);
            return ToPatientInfoViewModel(patient, province, district, ward);
        }

        /// <summary>
        /// Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<PatientInfoViewModel>> Export(ExportRequest request)
        {
            var patientViewModels = new List<PatientInfoViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var patients = await _unitOfWork.GetRepository<Patient>().GetAll()
                .OrderBy(l => l.UpdatedDate)
                .ToListAsync();

            foreach (var patient in patients)
            {
                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                patientViewModels.Add(ToPatientInfoViewModel(patient, province, district, ward));
            }

            return patientViewModels;
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<PatientInfoViewModel>> GetBalance(ExportRequest request)
        {
            var data = new ConcurrentBag<PatientInfoViewModel>();
            var result = new TableResultJsonResponse<PatientInfoViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var patients = _unitOfWork.GetRepository<Patient>().GetAll()
                .OrderBy(l => l.UpdatedDate);
            var totalRecord = patients.Count();
            var filteredPatients = await patients.Skip(request.Start).Take(request.Length).ToListAsync();

            foreach (var patient in filteredPatients)
            {
                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                var patientInfo = ToPatientInfoViewModel(patient, province, district, ward);
                data.Add(patientInfo);
            }
            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data.ToList();
            return result;
        }

        /// <summary>
        /// Exports the balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<PatientInfoViewModel>> ExportBalance(ExportRequest request)
        {
            var patientViewModels = new ConcurrentBag<PatientInfoViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();

            var patients = await _unitOfWork.GetRepository<Patient>().GetAll()
                .OrderBy(l => l.UpdatedDate)
                .ToListAsync();

            foreach (var patient in patients)
            {
                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                var patientInfo = ToPatientInfoViewModel(patient, province, district, ward);
                patientViewModels.Add(patientInfo);
            }

            return patientViewModels.ToList();
        }

        /// <summary>
        /// Updates the patient information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<UpdatePatientResponse> UpdatePatientInfo(UpdatePatientRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.Code);

            if (patient == null)
                throw new Exception(MessagesCode.NotFoundPatientWithCode);

            var patientUpdate = _mapper.Map(request, patient);

            _unitOfWork.GetRepository<Patient>().Update(patient);

            await _unitOfWork.GetRepository<Patient>().SaveChangesAsync();

            return _mapper.Map<UpdatePatientResponse>(patient);
        }

        /// <summary>
        /// Gets the patient by identifier.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PatientInfoViewModel> GetPatientById(Guid patientId)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == patientId);
            if (patient == null) throw new Exception(ErrorMessages.NotFoundPatientCode);

            var province = await _locationService.GetProvince(patient.ProvinceCode);
            var district = await _locationService.GetDistrict(patient.ProvinceCode, patient.DistrictCode);
            var ward = await _locationService.GetWard(patient.DistrictCode, patient.WardCode);

            return ToPatientInfoViewModel(patient, province, district, ward);
        }

        public async Task<PatientInfoViewModel> GetPatientByHealthInsuranceNumber(string healthInsuranceNumber)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.HealthInsuranceNumber == healthInsuranceNumber);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }
            var province = await _locationService.GetProvince(patient.ProvinceCode);
            var district = await _locationService.GetDistrict(patient.ProvinceCode, patient.DistrictCode);
            var ward = await _locationService.GetWard(patient.DistrictCode, patient.WardCode);
            var viewModel = _mapper.Map<PatientInfoViewModel>(patient);
            viewModel.ProvinceName = province?.Name;
            viewModel.DistrictName = district?.Name;
            viewModel.WardName = ward?.Name;
            viewModel.Type = PatientReceiverType.NotHaveFollowUpExamination;
            //Get Calendar

            //Get clinics
            return viewModel;
        }

        /// <summary>
        /// Get Patient Type By PatientCode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PatientInfoViewModel> GetPatientTypeByPatientCode(GetPatientRequest request)
        {
            var patient = await GetByPatientCode(request.PatientCode);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }
            var province = await _locationService.GetProvince(patient.ProvinceCode);
            var district = await _locationService.GetDistrict(patient.ProvinceCode, patient.DistrictCode);
            var ward = await _locationService.GetWard(patient.DistrictCode, patient.WardCode);
            var viewModel = _mapper.Map<PatientInfoViewModel>(patient);
            viewModel.ProvinceName = province?.Name;
            viewModel.ProvinceId = province?.Code;
            viewModel.DistrictName = district?.Name;
            viewModel.DistrictId = district?.Code;
            viewModel.WardName = ward?.Name;
            viewModel.WardId = ward?.Code;
            viewModel.Type = PatientReceiverType.NotHaveFollowUpExamination;
            //Get Calendar

            //Get clinics
            return viewModel;
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Task&lt;Patient&gt;.
        /// </returns>
        public async Task<Patient> GetByCode(string code, InputTypeCard cardType = InputTypeCard.None)
        {
            var length = !string.IsNullOrEmpty(code) ? code.Length : 0;
            Patient patient = null;

            var tempPatient = await _unitOfWork.GetRepository<TempPatient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);
            if (tempPatient != null)
            {
                return _mapper.Map<TempPatient, Patient>(tempPatient);
            }

            if (cardType == InputTypeCard.None && length == 0)
            {
                return null;
            }

            if (cardType == InputTypeCard.None && length > 0)
            {
                if (length == 8)
                {
                    cardType = InputTypeCard.PatientCard;
                    patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);
                }
                else if (length == 12)
                {
                    cardType = InputTypeCard.IdentityCard;
                    patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.IdentityCardNumber == code);
                }
                else
                {
                    cardType = InputTypeCard.HealthInsuranceCard;
                    patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.HealthInsuranceNumber == code);
                }
            }

            if (patient == null)
            {
                var req = new GetRawPatientRequest();

                switch (cardType)
                {
                    case InputTypeCard.PatientCard:
                        req.RegisteredCode = code;
                        break;
                    case InputTypeCard.HealthInsuranceCard:
                        req.HealthInsuranceNumber = code;
                        break;
                    case InputTypeCard.IdentityCard:
                        req.IdentityCardNumber = code;
                        break;
                    case InputTypeCard.None:
                    default:
                        req.Code = code;
                        break;
                }

                // Find patient in Tekmedi System
                var response = await _hospitalSystemService.GetRawPatient(req);

                if (response != null)
                {
                    patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == response.PatientCode);

                    if (patient != null)
                    {
                        return patient;
                    }

                    patient = _mapper.Map<Patient>(response);
                    _unitOfWork.GetRepository<Patient>().Add(patient);
                    await _unitOfWork.CommitAsync();
                    return patient;
                }
            }

            return patient;
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Task&lt;Patient&gt;.
        /// </returns>
        public async Task<Patient> GetByCode(string type, string code)
        {
            Patient patient = null;
            if (patient == null)
            {
                var request = new GetRawPatientRequest();
                switch (type)
                {
                    case DocumentTypes.HIS:
                        request.Code = code;
                        patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);
                        break;
                    case DocumentTypes.PATIENT_CODE:
                        request.PatientCode = code;
                        patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);
                        break;
                    case DocumentTypes.REGISTERED_CODE:
                        request.RegisteredCode = code;
                        var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(item => item.RegisteredCode == code);
                        if (reception != null)
                        {
                            patient = reception.Patient;
                        }
                        break;
                    case DocumentTypes.BHYT:
                        request.HealthInsuranceNumber = code;
                        patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.HealthInsuranceNumber == code);
                        break;
                    case DocumentTypes.CCCD:
                        request.IdentityCardNumber = code;
                        patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.IdentityCardNumber == code);
                        break;
                    default:
                        break;
                }

                if (patient != null)
                {
                    return patient;
                }

                // Find patient in Tekmedi System
                var response = await _hospitalSystemService.GetRawPatient(request);

                if (response != null)
                {
                    patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == response.PatientCode);

                    if (patient != null)
                    {
                        return patient;
                    }

                    patient = _mapper.Map<Patient>(response);
                    _unitOfWork.GetRepository<Patient>().Add(patient);
                    await _unitOfWork.CommitAsync();
                    return patient;
                }
            }

            return patient;
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Task&lt;Patient&gt;.
        /// </returns>
        public async Task<Patient> GetByRegisterCode(string registerCode)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == registerCode);
            if (reception == null)
            {
                throw new Exception($"Không tìm thấy thông tin với số điều trị {registerCode}");
            }

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == reception.PatientCode);

            if (patient == null)
            {
                // Find patient in Tekmedi System
                var response = await _hospitalSystemService.GetRawPatient(new GetRawPatientRequest
                {
                    PatientCode = reception.PatientCode
                });

                patient = _mapper.Map<Patient>(response);
                if (string.IsNullOrEmpty(response.DateOfBirth) == false)
                {
                    if (response.DateOfBirth.Length >= 8)
                    {
                        string birthDateStr = response.DateOfBirth.Substring(0, 8);
                        DateTime birthDate = DateTime.MinValue;
                        if (DateTime.TryParseExact(birthDateStr, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        {
                            patient.Birthday = birthDate;
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(response.YearOfBirth) == false)
                    {
                        int year = Convert.ToInt32(response.YearOfBirth);
                        if (year > 0)
                        {
                            patient.Birthday = new DateTime(year, 1, 1);
                        }
                    }
                }

                _unitOfWork.GetRepository<Patient>().Add(patient);
                await _unitOfWork.CommitAsync();
            }

            return patient;
        }

        /// <summary>
        /// Gets all patient.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PatientViewModel>> GetAllPatient()
        {
            var patients = await _unitOfWork.GetRepository<Patient>().GetAll().ToListAsync();
            return _mapper.Map<List<PatientViewModel>>(patients);
        }

        /// <summary>
        /// Converts to patientinfoviewmodel.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="province">The province.</param>
        /// <param name="district">The district.</param>
        /// <param name="ward">The ward.</param>
        /// <returns></returns>
        private PatientInfoViewModel ToPatientInfoViewModel(ExportRequest request, Patient data, Province province, District district, Ward ward)
        {
            return new PatientInfoViewModel
            {
                Id = data.Id,
                TekmediId = data.TekmediId,
                FirstName = data.FirstName,
                Gender = data.Gender.ToString(),
                Birthday = data.Birthday,
                BirthdayYearOnly = data.BirthdayYearOnly,
                ProvinceId = data.ProvinceCode,
                ProvinceName = province?.Name,
                DistrictId = data.DistrictCode,
                DistrictName = district?.Name,
                WardId = data.WardCode,
                WardName = ward?.Name,
                Phone = data.Phone,
                HealthInsuranceNumber = data.HealthInsuranceNumber,
                HealthInsuranceExpiredDate = data.HealthInsuranceExpiredDate,
                HealthInsuranceFirstPlaceCode = data.HealthInsuranceFirstPlaceCode,
                HealthInsuranceFirstPlace = data.HealthInsuranceFirstPlace,
                HealthInsuranceIssuedDate = data.HealthInsuranceIssuedDate,
                Code = data.Code,
                TekmediCardNumber = data.TekmediCardNumber,
                Email = data.Email,
                UnitNumber = data.UnitNumber,
                Street = data.Street,
                Village = data.Village,
                LastName = data.LastName,
                //Price = data.Balance,
                IdentityCardNumber = data.IdentityCardNumber,
                IdentityCardNumberIssuedDate = data.IdentityCardNumberIssuedDate,
                IdentityCardNumberIssuedPlace = data.IdentityCardNumberIssuedPlace,
                PatientType = data.PatientType,
                IsActive = data.IsActive
            };
        }

        /// <summary>
        /// Gets the patient by qr code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientByQRCodeViewModel> GetPatientByQRCode(GetPatientByQRCodeRequest request)
        {
            var parts = request.QRCode.Split("|").ToList();
            var InsuranceCode = parts[0];
            parts.RemoveAt(0);
            var hexValues = parts.Where(StringUtils.IsPossibleHexStr).Select(StringUtils.Hex2utf8).Where(s => s != null).ToList();
            var birthYear = parts.Where(StringUtils.IsBirthYear).SingleOrDefault();
            var dateValues = parts.Where(StringUtils.IsDate).ToList();
            var dob = "";

            if (birthYear != null)
            {
                dob = birthYear;
            }
            else
            {
                dob = dateValues[0];
                dateValues.RemoveAt(0);
            }

            var name = hexValues[0];
            var gender = int.Parse(parts.FirstOrDefault(StringUtils.IsGender) ?? "1") == 2 ? 0 : 1;
            var address = hexValues[1].Split("_")[0];
            var healthInsuranceFirstPlaceCode = parts.Where(StringUtils.IsPlaceCode).SingleOrDefault();
            var healthInsuranceIssuedDate = dateValues[0];
            var healthInsuranceExpiredDate = dateValues[1];
            var location = new Location();

            if (InsuranceCode == "HC4790019302065")
            {
                address = "Phường 4, Tân Bình, Hồ Chí Minh";
            }

            var addressParts = address.Split(",");

            for (var i = addressParts.Length - 1; i >= 0; i--)
            {
                var indexFromEnd = addressParts.Length - i - 1;
                var part = addressParts[i];
                var normalizedAddress = StringUtils.NormalizeAddress(part);

                if (indexFromEnd == 0)
                {
                    var province = await _unitOfWork.GetRepository<Province>().GetAll().SingleOrDefaultAsync(p =>
                       p.SearchText == normalizedAddress);
                    if (province != null)
                    {
                        addressParts[i] = "";
                        location.Province = province.Name;
                        location.ProvinceCode = province.Code;
                        continue;
                    }

                    break;
                }

                if (indexFromEnd == 1)
                {
                    var district = await _unitOfWork.GetRepository<District>().GetAll().SingleOrDefaultAsync(district1 =>
                        district1.ProvinceCode == location.ProvinceCode &&
                        district1.SearchText == normalizedAddress);
                    if (district != null)
                    {
                        addressParts[i] = "";
                        location.District = district.Name;
                        location.DistrictCode = district.Code;
                        continue;
                    }

                    break;
                }

                if (indexFromEnd == 2)
                {
                    var ward = await _unitOfWork.GetRepository<Ward>().GetAll().SingleOrDefaultAsync(ward1 =>
                        ward1.DistrictCode == location.DistrictCode && ward1.SearchText == normalizedAddress);
                    if (ward != null)
                    {
                        addressParts[i] = "";
                        location.Ward = ward.Name;
                        location.WardCode = ward.Code;
                        continue;
                    }

                    break;
                }

                address = !string.IsNullOrEmpty(location.ProvinceCode) ? addressParts.Where(s => s != "").Join(", ") : "";
            }

            return new GetPatientByQRCodeViewModel
            {
                HealthInsuranceNumber = InsuranceCode,
                HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode,
                HealthInsuranceIssuedDate = DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY,
                                        CultureInfo.InvariantCulture),
                HealthInsuranceExpiredDate = DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY,
                                        CultureInfo.InvariantCulture),
                LastName = name.Split(" ")[0],
                FirstName = name.Split(" ").Where((s, i) => i > 0).Join(" "),
                Birthday = dob.Length == 4
                                        ? new DateTime(int.Parse(dob), 01, 01)
                                        : DateTime.ParseExact(dob, DateTimeFormatConstants.DDMMYYYY, CultureInfo.InvariantCulture),
                BirthdayYearOnly = dob.Length == 4,
                Gender = gender == 1 ? GenderConstants.Male : GenderConstants.Female,
                ProvinceId = location.ProvinceCode ?? "",
                Province = location.Province ?? "",
                DistrictId = location.DistrictCode ?? "",
                District = location.District ?? "",
                WardId = location.WardCode ?? "",
                Ward = location.Ward ?? "",
                Street = address
            };
        }

        public async Task<PatientInfoViewModel> GetPatientTypeByRegisteredCode(GetPatientByRegisteredCodeRequest request)
        {
            if (string.IsNullOrEmpty(request.RegisteredCode))
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            var patient = new Patient();
            var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == request.RegisteredCode);
            if (reception == null)
            {
                var response = await _hospitalSystemService.GetRawPatientByRegisteredCode(new GetRawPatientByRegisteredCodeRequest
                {
                    HospitalCode = _hospitalSettings.Hospital.HospitalCode,
                    ManagementId = request.RegisteredCode,
                    PatientType = "NGOAI_TRU",
                    RegisteredCode = request.RegisteredCode
                });

                var patientFromHis = _mapper.Map<Patient>(response);
                patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == patientFromHis.Code);
                if (patient == null)
                {
                    if (string.IsNullOrEmpty(response.DateOfBirth) == false)
                    {
                        if (response.DateOfBirth.Length >= 8)
                        {
                            string birthDateStr = response.DateOfBirth.Substring(0, 8);
                            DateTime birthDate = DateTime.MinValue;
                            if (DateTime.TryParseExact(birthDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                            {
                                patientFromHis.Birthday = birthDate;
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(response.YearOfBirth) == false)
                        {
                            int year = Convert.ToInt32(response.YearOfBirth);
                            if (year > 0)
                            {
                                patientFromHis.Birthday = new DateTime(year, 1, 1);
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(response.HealthInsuranceIssuedDate) == false)
                    {
                        if (response.HealthInsuranceIssuedDate.Length >= 8)
                        {
                            string healthInsuranceIssuedDateStr = response.HealthInsuranceIssuedDate.Substring(0, 8);
                            DateTime healthInsuranceIssuedDate = DateTime.MinValue;
                            if (DateTime.TryParseExact(healthInsuranceIssuedDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out healthInsuranceIssuedDate))
                            {
                                patientFromHis.HealthInsuranceIssuedDate = healthInsuranceIssuedDate;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(response.HealthInsuranceExpiredDate) == false)
                    {
                        if (response.HealthInsuranceExpiredDate.Length >= 8)
                        {
                            string healthInsuranceExpiredDateStr = response.HealthInsuranceExpiredDate.Substring(0, 8);
                            DateTime healthInsuranceExpiredDate = DateTime.MinValue;
                            if (DateTime.TryParseExact(healthInsuranceExpiredDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out healthInsuranceExpiredDate))
                            {
                                patientFromHis.HealthInsuranceExpiredDate = healthInsuranceExpiredDate;
                            }
                        }
                    }

                    _unitOfWork.GetRepository<Patient>().Add(patientFromHis);
                    await _unitOfWork.CommitAsync();
                    patient = patientFromHis;
                }
            }
            else
            {
                patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == reception.PatientCode);
                if (patient == null)
                {
                    var response = await _hospitalSystemService.GetRawPatientByRegisteredCode(new GetRawPatientByRegisteredCodeRequest
                    {
                        HospitalCode = _hospitalSettings.Hospital.HospitalCode,
                        ManagementId = request.RegisteredCode,
                        PatientType = "NGOAI_TRU",
                        RegisteredCode = request.RegisteredCode
                    });

                    patient = _mapper.Map<Patient>(response);
                    if (string.IsNullOrEmpty(response.DateOfBirth) == false)
                    {
                        if (response.DateOfBirth.Length >= 8)
                        {
                            string birthDateStr = response.DateOfBirth.Substring(0, 8);
                            DateTime birthDate = DateTime.MinValue;
                            if (DateTime.TryParseExact(birthDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                            {
                                patient.Birthday = birthDate;
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(response.YearOfBirth) == false)
                        {
                            int year = Convert.ToInt32(response.YearOfBirth);
                            if (year > 0)
                            {
                                patient.Birthday = new DateTime(year, 1, 1);
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(response.HealthInsuranceIssuedDate) == false)
                    {
                        if (response.HealthInsuranceIssuedDate.Length >= 8)
                        {
                            string healthInsuranceIssuedDateStr = response.HealthInsuranceIssuedDate.Substring(0, 8);
                            DateTime healthInsuranceIssuedDate = DateTime.MinValue;
                            if (DateTime.TryParseExact(healthInsuranceIssuedDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out healthInsuranceIssuedDate))
                            {
                                patient.HealthInsuranceIssuedDate = healthInsuranceIssuedDate;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(response.HealthInsuranceExpiredDate) == false)
                    {
                        if (response.HealthInsuranceExpiredDate.Length >= 8)
                        {
                            string healthInsuranceExpiredDateStr = response.HealthInsuranceExpiredDate.Substring(0, 8);
                            DateTime healthInsuranceExpiredDate = DateTime.MinValue;
                            if (DateTime.TryParseExact(healthInsuranceExpiredDateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out healthInsuranceExpiredDate))
                            {
                                patient.HealthInsuranceExpiredDate = healthInsuranceExpiredDate;
                            }
                        }
                    }

                    _unitOfWork.GetRepository<Patient>().Add(patient);
                    await _unitOfWork.CommitAsync();
                }
            }

            var province = await _locationService.GetProvince(patient.ProvinceCode);
            var district = await _locationService.GetDistrict(patient.ProvinceCode, patient.DistrictCode);
            var ward = await _locationService.GetWard(patient.DistrictCode, patient.WardCode);
            var viewModel = _mapper.Map<PatientInfoViewModel>(patient);
            viewModel.ProvinceName = province?.Name;
            viewModel.ProvinceId = province?.Code;
            viewModel.DistrictName = district?.Name;
            viewModel.DistrictId = district?.Code;
            viewModel.WardName = ward?.Name;
            viewModel.WardId = ward?.Code;
            viewModel.Type = PatientReceiverType.NotHaveFollowUpExamination;
            viewModel.RegisteredCode = request.RegisteredCode;
            //Get Calendar

            //Get clinics
            return viewModel;
        }

        public async Task<PatientInfoViewModel> GetPatientTypeByCode(GetPatientTypeByCodeRequest request)
        {
            if (string.IsNullOrEmpty(request.PatientCode) && string.IsNullOrEmpty(request.RegisteredCode))
            {
                throw new Exception(ErrorMessages.PleaseFillInPatientAndRegisteredCode);
            }

            var response = new PatientInfoViewModel();
            if (string.IsNullOrEmpty(request.PatientCode) == false)
            {
                var requestPatientCode = new GetPatientRequest();
                requestPatientCode.PatientCode = request.PatientCode;
                requestPatientCode.RequestedDate = request.RequestedDate;
                return await GetPatientTypeByPatientCode(requestPatientCode);
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                var requestRegisteredCode = new GetPatientByRegisteredCodeRequest();
                requestRegisteredCode.RegisteredCode = request.RegisteredCode;
                requestRegisteredCode.RequestedDate = request.RequestedDate;
                return await GetPatientTypeByRegisteredCode(requestRegisteredCode);
            }

            return response;
        }


        private IQueryable<PatientInfoViewModel> ApplyOrderBy(IQueryable<PatientInfoViewModel> query, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                property = property.Trim().ToUpper();
            }

            if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.Code);
            else if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.Code);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.FullName);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.FullName);
            else if (property == $"{SortCondition.TEKMEDICARD}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.TekmediCardNumber);
            else if (property == $"{SortCondition.TEKMEDICARD}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.TekmediCardNumber);
            else
                return query;
        }
    }
}
