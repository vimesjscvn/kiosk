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

namespace Admin.API.Domain.Services
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
            IMapper mapper,
            ILocationService locationService,
            HospitalSettings hospitalSettings)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _mapper = mapper;
            _locationService = locationService;
            _hospitalSettings = hospitalSettings;
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
        public async Task<Patient> GetByCode(string code)
        {
            Patient patient = null;
            if (patient == null)
            {
                var request = new GetRawPatientRequest();
                request.PatientCode = code;
                patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);

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
            var reception =  await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == registerCode);
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
            var now = DateTime.Now;
            var response = await _hospitalSystemService.GetRawAllCalendar(new GetRawAllCalendarRequest
            {
                PatientCode = request.PatientCode,
                RegisteredCode = request.RegisteredCode,
                RegisteredDate = DateTime.Now
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
        /// Gets all patient.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PatientViewModel>> GetAllPatient()
        {
            var patients = await _unitOfWork.GetRepository<Patient>().GetAll().ToListAsync();
            return _mapper.Map<List<PatientViewModel>>(patients);
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
            var provinces = await _locationService.GetAllProvincesAsync();
            var districts = await _locationService.GetAlDistrictsAsync();
            var wards = await _locationService.GetAlWardsAsync();
            var searchValue = parameters.Search.Value.Trim().ToLower();
            var orderValue = "";
            if (parameters.Order != null && parameters.Order.Length > 0)
            {
                orderValue = parameters.Order[0].Dir.Trim().ToLower();
            }

            var predicate = PredicateBuilder.True<Patient>();

            if (!string.IsNullOrEmpty(searchValue))
            {
                predicate = PredicateBuilder.Create<Patient>(p => p.Code.ToLower().Contains(searchValue));
                predicate = predicate.Or(p => (p.LastName.Trim().ToLower() + " " + p.FirstName.Trim().ToLower()).Trim().Contains(searchValue));
                predicate = predicate.Or(p => (p.Code.Contains(searchValue)));
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
                var patientInfo = _mapper.Map<PatientInfoViewModel>(patient);
                patientInfo.ProvinceName = province?.Name;
                patientInfo.ProvinceId = province?.Code;
                patientInfo.DistrictName = district?.Name;
                patientInfo.DistrictId = district?.Code;
                patientInfo.WardName = ward?.Name;
                patientInfo.WardId = ward?.Code;
                // Số tiền đã nạp
                //patientInfo.TopUpAmount = patient.TekmediCardHistories
                //    .Where(h => h.Status == StatusEnum.Success && h.Type == TypeEnum.Recharged &&
                //                !patient.TekmediCardCancelHistories.Any(c => c.TekmediCardHistoryId == h.Id))
                //    .Sum(h => h.Amount);
                //// Số tiền tạm ứng
                //patientInfo.HoldAmount = patient.TekmediCardHistories
                //   .Where(h => h.Status == StatusEnum.Success
                //        && (h.Type == TypeEnum.Charge
                //        || h.Type == TypeEnum.ChargeList)
                //        && !patient.TekmediCardCancelHistories.Any(c => c.TekmediCardHistoryId == h.Id))
                //   .Sum(h => h.Amount);
                //// Số tiền tất toán
                //patientInfo.FinallyAmount = patient.TekmediCardHistories
                //    .Where(h => h.Status == StatusEnum.Success
                //        && h.Type == TypeEnum.FinallyCharge
                //        && !patient.TekmediCardCancelHistories.Any(c => c.TekmediCardHistoryId == h.Id))
                //    .Sum(h => h.Amount);
                //// Số tiền còn lại
                //patientInfo.Balance = patient.TekmediCard != null ? patient.TekmediCard.Balance : 0;
                data.Add(patientInfo);
            }

            result.Draw = parameters.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = this.ApplyOrderBy(data.AsQueryable(), orderValue).ToList();

            return result;
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
            var patientInfo = _mapper.Map<PatientInfoViewModel>(patient);
            patientInfo.ProvinceName = province?.Name;
            patientInfo.ProvinceId = province?.Code;
            patientInfo.DistrictName = district?.Name;
            patientInfo.DistrictId = district?.Code;
            patientInfo.WardName = ward?.Name;
            patientInfo.WardId = ward?.Code;

            return patientInfo;
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

            patient.LastName = request.LastName;
            patient.FirstName = request.FirstName;
            patient.Gender = Gender.Male;
            patient.Birthday = request.Birthday.HasValue ? request.Birthday.Value : DateTime.Now;
            patient.BirthdayYearOnly = request.BirthdayYearOnly;
            patient.Street = request.Street;
            patient.ProvinceCode = request.ProvinceId;
            patient.DistrictCode = request.DistrictId;
            patient.WardCode = request.WardId;
            patient.IdentityCardNumber = request.IdentityCardNumber;
            patient.IdentityCardNumberIssuedDate = request.IdentityCardNumberIssuedDate;
            patient.IdentityCardNumberIssuedPlace = request.IdentityCardNumberIssuedPlace;
            patient.Phone = request.Phone;
            patient.HealthInsuranceNumber = request.HealthInsuranceNumber;
            patient.HealthInsuranceFirstPlaceCode = request.HealthInsuranceFirstPlaceCode;
            patient.HealthInsuranceFirstPlace = request.HealthInsuranceFirstPlace;
            patient.HealthInsuranceIssuedDate = request.HealthInsuranceIssuedDate;
            patient.HealthInsuranceExpiredDate = request.HealthInsuranceExpiredDate;
            patient.IsActive = request.IsActive;
            patient.UpdatedBy = Systems.UpdatedBy;
            patient.UpdatedDate = DateTime.Now;
            _unitOfWork.GetRepository<Patient>().Update(patient);
            await _unitOfWork.CommitAsync();
            var province = await _locationService.GetProvince(patient.ProvinceCode);
            var district = await _locationService.GetDistrict(patient.ProvinceCode, patient.DistrictCode);
            var ward = await _locationService.GetWard(patient.DistrictCode, patient.WardCode);

            var patientInfo = _mapper.Map<PatientInfoViewModel>(patient);
            patientInfo.ProvinceName = province?.Name;
            patientInfo.DistrictName = district?.Name;
            patientInfo.WardName = ward?.Name;
            return patientInfo;
        }

        /// <summary>
        /// Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<PatientInfoViewModel>> Export(ExportRequest request)
        {
            //var searchValue = request.Search.Value.Trim();
            var patientViewModels = new List<PatientInfoViewModel>();
            var provinces = await _locationService.GetAllProvincesAsync();
            var districts = await _locationService.GetAlDistrictsAsync();
            var wards = await _locationService.GetAlWardsAsync();
            var predicate = PredicateBuilder.True<Patient>();
            if (request.Search != null && !string.IsNullOrEmpty(request.Search.Value.Trim()))
            {
                predicate = PredicateBuilder.Create<Patient>(p => p.Code.ToLower().Contains(request.Search.Value.Trim()));
            }
            var patients = await _unitOfWork.GetRepository<Patient>().GetAll().Where(predicate)
                .OrderBy(l => l.UpdatedDate)
                .ToListAsync();

            foreach (var patient in patients)
            {
                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                var patientInfo = _mapper.Map<PatientInfoViewModel>(patient);
                patientInfo.ProvinceName = province?.Name;
                patientInfo.DistrictName = district?.Name;
                patientInfo.WardName = ward?.Name;
                patientViewModels.Add(patientInfo);
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
            var orderValue = "";

            if (request.Order != null && request.Order.Length > 0)
            {
                orderValue = request.Order[0].Dir.Trim().ToLower();
            }

            var predicate = PredicateBuilder.True<Patient>();

            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                predicate = predicate.And(p => (p.Code.Contains(request.Search.Value)) || (p.LastName.ToLower() + " " + p.FirstName.ToLower()).Trim().Contains(request.Search.Value.Trim().ToLower()));
            }

            var patients = await _unitOfWork.GetRepository<Patient>().GetAll()
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(l => l.UpdatedDate).ToListAsync();

            var totalRecord = patients.Count();

            var filteredPatients = patients.Skip(request.Start).Take(request.Length).ToList();

            foreach (var patient in filteredPatients)
            {
                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                var patientInfo = ToPatientInfoViewModel(request, patient, province, district, ward);
                data.Add(patientInfo);
            }
            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = filteredPatients.Count();
            result.Data = ApplyOrderBy(data.AsQueryable(), orderValue).ToList();
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
                IsActive = data.IsActive
            };
        }

        /// <summary>
        /// Exports the balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<PatientInfoViewModel>> ExportBalance(ExportRequest request)
        {
            var patientViewModels = new ConcurrentBag<PatientInfoViewModel>();
            var provinces = await _locationService.GetAllProvincesAsync();
            var districts = await _locationService.GetAlDistrictsAsync();
            var wards = await _locationService.GetAlWardsAsync();

            var patients = _unitOfWork.GetRepository<Patient>().GetAll()
               .OrderBy(l => l.UpdatedDate);

            foreach (var patient in patients)
            {

                var province = provinces.FirstOrDefault(p => p.Code == patient.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == patient.DistrictCode && d.ProvinceCode == patient.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == patient.WardCode && w.DistrictCode == patient.DistrictCode);
                var patientInfo = _mapper.Map<PatientInfoViewModel>(patient);
                patientInfo.ProvinceName = province?.Name;
                patientInfo.DistrictName = district?.Name;
                patientInfo.WardName = ward?.Name;
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
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);

            if (patient == null)
                throw new Exception(MessagesCode.NotFoundPatientWithCode);

            var patientUpdate = _mapper.Map(request, patient);

            _unitOfWork.GetRepository<Patient>().Update(patient);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<UpdatePatientResponse>(patient);
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

        public async Task<PatientInfoViewModel> GetPatientTypeByPatientCode(GetPatientRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null)
            {
                //throw new Exception(ErrorMessages.NotFoundPatientCode);
                var response = await _hospitalSystemService.GetRawPatient(new GetRawPatientRequest
                {
                    PatientCode = request.PatientCode
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

            var registeredCode = request.PatientCode;
            var receptions = await _unitOfWork.GetRepository<Reception>().ListAsync(x => x.PatientCode == request.PatientCode, null);
            if (receptions.Count() > 0)
            {
                var latestReception = receptions.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                registeredCode = latestReception.RegisteredCode;
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
            viewModel.RegisteredCode = registeredCode;
            //Get Calendar

            //Get clinics
            return viewModel;
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

        public Task<Patient> GetByCode(string code, InputTypeCard type = InputTypeCard.None)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetByCode(string type, string code)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetByPatientCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetByHealthInsuranceNumber(string healthInsuranceNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetByRegisteredCode(string registeredCode)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ExaminationCalendar>> GetCalendarByDate(GetCalendarByDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TempPatient> GetPatientByQRCode(string code, List<Functions> functionsIds)
        {
            throw new NotImplementedException();
        }

        public Task<TempPatient> GetPatientByNationalIdQRCode(string code, List<Functions> functionsIds)
        {
            throw new NotImplementedException();
        }

        public Task<TempPatient> GetPatientByQRCodeWithNoCheckSocialGateway(string code)
        {
            throw new NotImplementedException();
        }
    }
}
