// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueueNumberService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.SignalRClient.Requests;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.PostModels;
using CS.VM.QueueNumberModels;
using CS.VM.QueueNumberModels.Requests;
using CS.VM.Requests;
using CS.VM.Responses;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    /// <summary>
    /// User Profile Service
    /// </summary>
    /// <seealso cref="IQueueNumberService" />
    public class OrderNumberService : IOrderNumberService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Gets the hospital settings.
        /// </summary>
        /// <value>The hospital settings.</value>
        private readonly HospitalSettings _hospitalSettings;

        /// <summary>
        /// The patient service
        /// </summary>
        private readonly IPatientService _patientService;

        /// <summary>
        /// The location service
        /// </summary>
        private readonly ILocationService _locationService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNumberService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public OrderNumberService(IUnitOfWork unitOfWork, HospitalSettings hospitalSettings,
            IMapper mapper,
            IPatientService patientService,
            ILocationService locationService,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
            _mapper = mapper;
            _patientService = patientService;
            _locationService = locationService;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<QueueNumber> GetAll()
        {
            return _unitOfWork.GetRepository<QueueNumber>().GetAll().ToList();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<QueueNumber>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<QueueNumber>().GetAll().ToListAsync();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public QueueNumber Get(Guid id)
        {
            return _unitOfWork.GetRepository<QueueNumber>().GetById(id);
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<QueueNumber> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<QueueNumber>().GetAsyncById(id);
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public QueueNumber Find(Expression<Func<QueueNumber, bool>> match)
        {
            return _unitOfWork.GetRepository<QueueNumber>().Find(match);
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<QueueNumber> FindAsync(Expression<Func<QueueNumber, bool>> match)
        {
            return await _unitOfWork.GetRepository<QueueNumber>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<QueueNumber> FindAll(Expression<Func<QueueNumber, bool>> match)
        {
            return _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// Finds all asynchronous.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<QueueNumber>> FindAllAsync(Expression<Func<QueueNumber, bool>> match)
        {
            return await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public QueueNumber Add(QueueNumber entity)
        {
            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="Exception"></exception>
        //public async Task<QueueNumber> AddAsync(QueueNumber entity)
        //{
        //    _unitOfWork.GetRepository<QueueNumber>().Add(entity);
        //    await _unitOfWork.CommitAsync();
        //    return entity;
        //}

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <returns>QueueNumber.</returns>
        public QueueNumber Update(QueueNumber entity, Guid key)
        {
            if (entity == null)
                return null;

            QueueNumber existing = _unitOfWork.GetRepository<QueueNumber>().GetById(key);
            if (existing != null)
            {
                _unitOfWork.GetRepository<QueueNumber>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <returns>QueueNumber.</returns>
        public async Task<QueueNumber> UpdateAsync(QueueNumber entity, Guid key)
        {
            if (entity == null)
                return null;

            QueueNumber existing = await _unitOfWork.GetRepository<QueueNumber>().GetAsyncById(key);
            if (existing != null)
            {
                _unitOfWork.GetRepository<QueueNumber>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<QueueNumber>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(QueueNumber entity)
        {
            _unitOfWork.GetRepository<QueueNumber>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(QueueNumber entity)
        {
            _unitOfWork.GetRepository<QueueNumber>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<QueueNumber>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<QueueNumber>().Count();
        }

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<QueueNumber>().CountAsync();
        }

        /// <summary>
        /// Generates the specified patient information.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        public async Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<string> departments)
        {
            var services = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(v => departments.Any(id => id == v.Code)).ToListAsync();
            var currentNumbers = new List<QueueNumber>();
            var queueNumbers = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                .Where(q => departments.Any(id => id == q.DepartmentCode)
                && q.PatientId == patientInfo.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0).ToListAsync();

            var finalDepartments = departments.Except(queueNumbers.Select(s => s.DepartmentCode)).ToList();

            if (patientInfo.PatientType == PatientType.Normal)
            {
                currentNumbers = await _unitOfWork.GetRepository<QueueNumber>()
                    .GetAll()
                    .Where(v => finalDepartments.Any(id => id == v.DepartmentCode)
                    && v.Type == PatientType.Normal).ToListAsync();
            }
            else
            {
                currentNumbers = await _unitOfWork.GetRepository<QueueNumber>()
                    .GetAll()
                    .Where(v => finalDepartments.Any(id => id == v.DepartmentCode)
                    && v.Type != PatientType.Normal).ToListAsync();
            }

            foreach (var id in finalDepartments)
            {
                var queueNumber = new QueueNumber();
                queueNumber.DepartmentCode = id;
                queueNumber.DepartmentExtendId = services.FirstOrDefault(s => s.Code == id).Id;
                queueNumber.PatientId = patientInfo.Id;
                queueNumber.PatientId = patientInfo.Id;
                queueNumber.Type = patientInfo.PatientType;
                queueNumber.Number = currentNumbers
                    .Where(n => n.DepartmentCode == id)
                    .OrderByDescending(n => n.Number)
                    .FirstOrDefault()?.Number + 1 ?? 1;
                _unitOfWork.GetRepository<QueueNumber>().Add(queueNumber);
                queueNumbers.Add(queueNumber);
            }

            await _unitOfWork.CommitAsync();
            return queueNumbers;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumber> AddAsync(QueueNumber entity)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(item => item.Id == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var last = new QueueNumber();
            entity.Type = patient.PatientType;

            if (entity.Type == PatientType.Normal)
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == _hospitalSettings.Hospital.HospitalArea
                    && q.Type == PatientType.Normal);
            }
            else
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == _hospitalSettings.Hospital.HospitalArea
                    && q.Type != PatientType.Normal);
            }

            entity.Number = last != null ? last.Number + 1 : 1;
            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
            var listValue = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().SingleOrDefaultAsync(i => i.Code == entity.DepartmentCode);
            entity.DepartmentExtendId = listValue.Id;
            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Processes the queue number view model.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        private async Task<QueueNumberViewModel> ProcessQueueNumberViewModel(Patient patient)
        {
            var queueNumber = new QueueNumberPostModel();
            queueNumber.DepartmentCode = Departments.TNB;
            queueNumber.PatientId = patient.Id;

            var queueNumberModel = _mapper.Map<QueueNumber>(queueNumber);
            var queueNumberResultModel = await AddAsync(queueNumberModel);
            var queueNumberViewModel = _mapper.Map<QueueNumberViewModel>(queueNumberResultModel);
            return queueNumberViewModel;
        }

        /// <summary>
        /// Adds the temporary patient asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumber> AddTempPatientAsync(QueueNumber entity)
        {
            var patient = await _unitOfWork.GetRepository<TempPatient>().GetAll().SingleOrDefaultAsync(item => item.PatientId == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundTempPatientCode);
            }

            var last = new QueueNumber();
            entity.Type = patient.PatientType;

            if (entity.Type == PatientType.Normal)
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == _hospitalSettings.Hospital.HospitalArea
                    && q.Type == PatientType.Normal);
            }
            else
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == _hospitalSettings.Hospital.HospitalArea
                    && q.Type != PatientType.Normal);
            }

            entity.Number = last != null ? last.Number + 1 : 1;
            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
            var department = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().SingleOrDefaultAsync(l => l.Code == entity.DepartmentCode);
            entity.DepartmentExtendId = department.Id;
            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Gets the by departments.
        /// </summary>
        /// <param name="departments">The departments.</param>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        public async Task<ICollection<QueueNumber>> GetByDepartments(IEnumerable<string> departments, Guid patientId)
        {
            return await _unitOfWork.GetRepository<QueueNumber>()
                .GetAll()
                .Where(v => departments.Any(id => id == v.DepartmentCode) && v.PatientId == patientId).ToListAsync();
        }

        /// <summary>
        /// Gets the by patient code and department code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<IEnumerable<QueueNumber>> GetByPatientCodeAndDepartmentCode(GetByPatientCodeRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            var queueNumbers = await _unitOfWork.GetRepository<QueueNumber>()
                .GetAll().Where(queue => queue.PatientId == patient.Id
                && queue.DepartmentCode == request.DepartmentCode
                && !queue.IsDeleted).ToListAsync();

            return queueNumbers;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumber> AddAsync(QueueNumberPostModel postModel)
        {
            var entity = _mapper.Map<QueueNumber>(postModel);

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(item => item.Id == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => q.DepartmentCode == postModel.DepartmentCode
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

            if (number != null)
            {
                return number;
            }

            entity.Type = patient.PatientType;
            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == entity.DepartmentCode);

            if (entity.Type == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .OrderByDescending(c => c.Number)
                .FirstOrDefaultAsync(predicate);

            entity.Number = last != null ? last.Number + 1 : 1;
            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
            var listValue = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .SingleOrDefaultAsync(i => i.Code == entity.DepartmentCode);
            entity.DepartmentExtendId = listValue.Id;

            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Generates the specified patient information.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <returns></returns>
        public async Task<QueueNumber> Generate(Patient patient, string departmentCode, Guid roomId, string registeredCode)
        {
            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => q.DepartmentExtendId == roomId
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

            if (number != null)
            {
                return number;
            }

            var entity = new QueueNumber();
            entity.Type = patient.PatientType;

            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentExtendId == roomId);

            if (entity.Type == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }

            entity.Type = patient.PatientType;

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .OrderByDescending(c => c.Number)
                .FirstOrDefaultAsync(predicate);

            entity.DepartmentCode = departmentCode;
            entity.Patient = patient;
            entity.PatientId = patient.Id;
            entity.Type = patient.PatientType;
            entity.Number = last != null ? last.Number + 1 : 1;
            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
            entity.RegisteredCode = registeredCode;
            var listValue = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .SingleOrDefaultAsync(i => i.Id == roomId);
            entity.DepartmentExtendId = listValue.Id;

            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<TableResultJsonResponse<PatientsInRoomViewModel>> GetPatientsInRoom(GetPatientsInRoomRequest request)
        {
            var result = new TableResultJsonResponse<PatientsInRoomViewModel>();

            var queueNumbers = await FilterPatienstInRoom(request);

            var totalRecord = queueNumbers.Count();

            var orderValue = "";
            if (request.Order != null && request.Order.Length > 0)
            {
                orderValue = request.Order[0].Dir.Trim().ToLower();
            }

            var queryQueue = await queueNumbers.Skip(request.Start).Take(request.Length).OrderBy(x => x.CreatedDate).ToListAsync();

            var patientsInRoom = _mapper.Map<List<PatientsInRoomViewModel>>(queryQueue);

            if (patientsInRoom.Count > 0)
            {
                var tempPatientIds = queryQueue.Select(x => x.PatientId);
                var tempPatients = _unitOfWork.GetRepository<TempPatient>().GetAll().Where(x => tempPatientIds.Contains(x.Id));
                var dicTempPatient = tempPatients.ToDictionary(temp => temp.Id, temp => temp);

                var provinces = await _locationService.GetAllProvincesAsync();
                var districts = await _locationService.GetAlDistrictsAsync();
                var wards = await _locationService.GetAlWardsAsync();
                foreach (var item in patientsInRoom)
                {
                    if (dicTempPatient.ContainsKey(item.PatientId))
                    {
                        item.PatientCode = dicTempPatient[item.PatientId].Code;
                        item.ProvinceId = dicTempPatient[item.PatientId].ProvinceId;
                        item.WardId = dicTempPatient[item.PatientId].WardId;
                        item.DistrictId = dicTempPatient[item.PatientId].DistrictId;
                        item.FullName = $"{dicTempPatient[item.PatientId].LastName} {dicTempPatient[item.PatientId].FirstName}";
                        item.Gender = dicTempPatient[item.PatientId].Gender;
                        item.Birthday = dicTempPatient[item.PatientId].Birthday != null ? dicTempPatient[item.PatientId].Birthday : DateTime.Now;
                    }
                    var province = provinces.FirstOrDefault(p => p.Code == item.ProvinceId);
                    var district = districts.FirstOrDefault(d => d.Code == item.DistrictId && d.ProvinceCode == item.ProvinceId);
                    var ward = wards.FirstOrDefault(w => w.Code == item.WardId && w.DistrictCode == item.DistrictId);
                    item.WardName = ward?.Name;
                    item.ProvinceName = province?.Name;
                    item.DistrictName = district?.Name;

                }
            }
            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = ApplyOrderBy(patientsInRoom.AsQueryable(), orderValue).ToList();
            return result;
        }
        /// <summary>
        /// Registers the queue number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<RegisterQueueNumberResponse> RegisterQueueNumber(RegisterQueueNumberRequest request)
        {
            var patient = await _patientService.GetByCode(request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            patient = _mapper.Map(request, patient);

            var queueNumber = await Generate(patient, request.DepartmentCode, request.RoomId, request.RegisteredCode);
            var result = _mapper.Map<RegisterQueueNumberResponse>(queueNumber);
            return result;
        }

        /// <summary>
        /// Exports the patients in room.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<List<PatientsInRoomViewModel>> ExportPatientsInRoom(GetPatientsInRoomRequest request)
        {
            var queueNumbers = await FilterPatienstInRoom(request);

            var queryQueue = await queueNumbers.OrderBy(x => x.CreatedDate).ToListAsync();

            var patientsInRoom = _mapper.Map<List<PatientsInRoomViewModel>>(queryQueue);

            if (patientsInRoom.Count > 0)
            {
                var tempPatientIds = queryQueue.Select(x => x.PatientId);
                var tempPatients = _unitOfWork.GetRepository<TempPatient>().GetAll().Where(x => tempPatientIds.Contains(x.Id));
                var dicTempPatient = tempPatients.ToDictionary(temp => temp.Id, temp => temp);

                var provinces = await _locationService.GetAllProvincesAsync();
                var districts = await _locationService.GetAlDistrictsAsync();
                var wards = await _locationService.GetAlWardsAsync();
                foreach (var item in patientsInRoom)
                {
                    if (dicTempPatient.ContainsKey(item.PatientId))
                    {
                        item.PatientCode = dicTempPatient[item.PatientId].Code;
                        item.ProvinceId = dicTempPatient[item.PatientId].ProvinceId;
                        item.WardId = dicTempPatient[item.PatientId].WardId;
                        item.DistrictId = dicTempPatient[item.PatientId].DistrictId;
                        item.FullName = $"{dicTempPatient[item.PatientId].LastName} {dicTempPatient[item.PatientId].FirstName}";
                        item.Gender = dicTempPatient[item.PatientId].Gender;
                        item.Birthday = dicTempPatient[item.PatientId].Birthday??DateTime.Now;
                        item.BirthdayYearOnly = dicTempPatient[item.PatientId].BirthdayYearOnly;
                        item.Street = dicTempPatient[item.PatientId].Street;
                        item.PhoneNumber = dicTempPatient[item.PatientId].Phone;
                    }
                    var province = provinces.FirstOrDefault(p => p.Code == item.ProvinceId);
                    var district = districts.FirstOrDefault(d => d.Code == item.DistrictId && d.ProvinceCode == item.ProvinceId);
                    var ward = wards.FirstOrDefault(w => w.Code == item.WardId && w.DistrictCode == item.DistrictId);
                    item.WardName = ward?.Name;
                    item.ProvinceName = province?.Name;
                    item.DistrictName = district?.Name;
                }
            }
            return patientsInRoom;
        }

        /// <summary>
        /// Removes the patients in queue.
        /// </summary>
        /// <param name="removeRequest">The remove request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<bool> RemovePatientsInQueue(RemovePatientsInQueueRequest removeRequest)
        {
            DateTime dateTime = DateTime.Now;

            if (dateTime.Hour >= _hospitalSettings.Hospital.TimeRemoveQueueNumber)
            {
                var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == removeRequest.EmployeeId);

                if (employee == null)
                    throw new Exception(ErrorMessages.NotFoundEmployeeCode);

                var queueNumbers = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .Where(number => number.DepartmentCode == removeRequest.DepartmentCode &&
                                     DateTime.Compare(number.CreatedDate.Date, DateTime.Now.Date) == 0).ToListAsync();

                if (queueNumbers.Count > 0)
                {
                    History history = new History
                    {
                        Reason = removeRequest.Reason,
                        HistoryId = Guid.Empty,
                        Type = HistoryType.QueueNumber,
                        CreatedBy = employee.FullName,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = employee.FullName,
                        UpdatedDate = DateTime.Now,
                        EmployeeId = employee.Id,
                        Employee = employee
                    };
                    queueNumbers.ForEach(x => _unitOfWork.GetRepository<QueueNumber>().Delete(x));
                    _unitOfWork.GetRepository<History>().Add(history);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            else throw new Exception(ErrorMessages.InvalidTimeRemoveQueue);

        }

        /// <summary>
        /// Adds the queue number.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="patient">The patient.</param>
        /// <exception cref="Exception"></exception>
        public async Task AddQueueNumber(string departmentCode, SysUser employee, Patient patient)
        {
            var queueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == departmentCode);

            var patientNumber = await queueNumber.FirstOrDefaultAsync(number => number.PatientId == patient.Id);

            if (patientNumber != null)
                throw new Exception(ErrorMessages.PatientHadExistQueueNumber);

            var latestNumber = queueNumber.OrderByDescending(x => x.Number).Take(1).SingleOrDefault()?.Number ?? 0;

            QueueNumber addQueue = new QueueNumber
            {
                DepartmentCode = departmentCode,
                Patient = patient,
                PatientId = patient.Id,
                CreatedDate = DateTime.Now,
                CreatedBy = employee.FullName,
                IsSelected = false,
                IsDeleted = false,
                Type = patient.PatientType,
                Number = latestNumber + 1
            };

            _unitOfWork.GetRepository<QueueNumber>().Add(addQueue);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Gets the room by patient code.
        /// </summary>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        public async Task<GetRoomPatientResponse> GetRoomByPatientCode(string patientCode)
        {
            patientCode = StringUtils.MapValidPatientCode(patientCode);
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == patientCode);
            var queueNumbers = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.PatientId == patient.Id).AsNoTracking().ToListAsync();

            if (queueNumbers.Count > 0)
            {
                List<PatientHaveRoomViewModel> patientHaveRooms = new List<PatientHaveRoomViewModel>();

                var departmentCode = queueNumbers.Select(number => number.DepartmentCode).Distinct();

                var extendValues = _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(x => departmentCode.Contains(x.Code)).AsNoTracking().ToDictionary(extend => extend.Code, extend => extend);

                foreach (var queueNumber in queueNumbers)
                {
                    patientHaveRooms.Add(new PatientHaveRoomViewModel
                    {
                        DepartmentCode = queueNumber.DepartmentCode,
                        Description = extendValues.ContainsKey(queueNumber.DepartmentCode) == true ? extendValues[queueNumber.DepartmentCode].Description : queueNumber.DepartmentCode
                    });
                }
                return new GetRoomPatientResponse
                {
                    PatientHaveRooms = patientHaveRooms.ToList()
                };
            }
            return new GetRoomPatientResponse();
        }

        /// <summary>
        /// Gets the queue number temporary by table code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;ICollection&lt;CombinePatientAndQueueTempViewModel&gt;&gt;.</returns>
        public async Task<List<QueueNumberTempViewModel>> GetQueueNumberTempByTableCode(GetQueueNumberTempByTableCodeRequest request)
        {
            var limit = request.Limit ?? 5;
            var queueNumberTemps = await _unitOfWork.GetRepository<QueueNumberTemp>().GetAll()
                .Where(queue => queue.TableCode == request.TableCode
                && !queue.IsFinished
                && (request.Type == PriorityType.Priority ? queue.Type != PatientType.Normal : queue.Type == PatientType.Normal)
                && !queue.IsSelected).OrderBy(o => o.Number).Take(limit).ToListAsync();

            var response = _mapper.Map<List<QueueNumberTempViewModel>>(queueNumberTemps);

            //return await CombinePatientAndQueueTempBuilder(queueNumberTemps, request.Type);
            return response;
        }

        /// <summary>
        /// Gets the selected queue number temporary by table code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ICollection&lt;CombinePatientAndQueueTempViewModel&gt;.</returns>
        public async Task<ICollection<CombinePatientAndQueueTempViewModel>> GetSelectedQueueNumberTempByTableCode(GetQueueNumberTempByTableCodeRequest request)
        {
            var limit = request.Limit ?? 5;
            var queueNumberTemps = await _unitOfWork.GetRepository<QueueNumberTemp>().GetAll()
                .Where(queue => queue.TableCode == request.TableCode
                && !queue.IsFinished
                && (request.Type == PriorityType.Priority ? queue.Type != PatientType.Normal : queue.Type == PatientType.Normal)
                && queue.IsSelected).OrderByDescending(o => o.Number).Take(limit).ToListAsync();

            return await CombinePatientAndQueueTempBuilder(queueNumberTemps, request.Type);
        }

        /// <summary>
        /// Gets the latest number by department.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public GetLatestNumberResponse GetLatestNumberByDepartment(string deparmentCode)
        {
            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == deparmentCode && number.Number > 0).OrderByDescending(number => number.Number);
            var normalPatient = queueNumbers.Where(number => number.Type == PatientType.Normal && number.IsSelected).Take(1).SingleOrDefault();
            var priorityPatient = queueNumbers.Where(number => number.Type != PatientType.Normal && number.IsSelected).Take(1).SingleOrDefault();

            var normalNumber = 0;
            var normalName = string.Empty;
            var normalAge = 0;
            var normalSex = string.Empty;
            if (normalPatient != null)
            {
                normalNumber = normalPatient.Number;
                if (normalPatient.Patient != null)
                {
                    normalName = normalPatient.Patient.LastName + ' ' + normalPatient.Patient.FirstName;
                    normalAge = normalPatient.Patient.Birthday != null
                        ? (DateTime.Now.Year - normalPatient.Patient.Birthday.Year)
                        : normalAge;
                    normalSex = (normalPatient.Patient.Gender == Gender.Female)
                        ? GenderConstants.Female
                        : GenderConstants.Male;
                }
            }

            var priorityNumber = 0;
            var priorityName = string.Empty;
            var priorityAge = 0;
            var prioritySex = string.Empty;
            if (priorityPatient != null)
            {
                priorityNumber = priorityPatient.Number;
                if (priorityPatient.Patient != null)
                {
                    priorityName = priorityPatient.Patient.LastName + ' ' + priorityPatient.Patient.FirstName;
                    priorityAge = priorityPatient.Patient.Birthday != null
                        ? (DateTime.Now.Year - priorityPatient.Patient.Birthday.Year)
                        : priorityAge;
                    prioritySex = (priorityPatient.Patient.Gender == Gender.Female)
                        ? GenderConstants.Female
                        : GenderConstants.Male;
                }
            }

            return new GetLatestNumberResponse
            {
                NormalNumber = normalNumber,
                PriorityNumber = priorityNumber,
                NormalName = normalName,
                NormalAge = normalAge,
                PriorityName = priorityName,
                PriorityAge = priorityAge,
                NormalSex = normalSex,
                PrioritySex = prioritySex
            };
        }

        public async Task<GenerateByPatientCodeResponse> GenerateByPatientCodeWithType(GenerateByPatientCodeWithTypeRequest request)
        {
            var patient = await _patientService.GetByCode(request.PatientCode);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }
            var result = new GenerateByPatientCodeResponse();
            var viewModel = _mapper.Map<ExtendPatientViewModel>(patient);
            viewModel.Type = PatientReceiverType.NotHaveFollowUpExamination;

            if (viewModel.Type == PatientReceiverType.NotHaveFollowUpExamination)
            {
                var patientType = PatientType.Normal;
                switch (request.Type)
                {
                    case "CC":
                    case "CK":
                    case "KC":
                        patientType = PatientType.PriorityCode;
                        break;
                    case "06":
                        patientType = PatientType.Priority6;
                        break;
                    case "80":
                        patientType = PatientType.Priority80;
                        break;
                    case "KT":
                        patientType = PatientType.PriorityKT;
                        break;
                    case "BN":
                        patientType = PatientType.PriorityBN;
                        break;
                    case "GT":
                        patientType = PatientType.PriorityGT;
                        break;
                    default:
                        patientType = HealthcareHelper.GetPatientType(patient.HealthInsuranceNumber, patient.Birthday);
                        break;
                }
                patient = _mapper.Map(request, patient);
                patient.PatientType = patientType;
                _unitOfWork.GetRepository<Patient>().Update(patient);
                var queueNumberViewModel = await ProcessQueueNumberViewModelWithType(patient, patientType);
                result.QueueNumber = queueNumberViewModel;
                result.QueueNumberType = QueueNumberType.NotHaveFollowUpExamination;
            }
            result.Patient = _mapper.Map<PatientViewModel>(patient);
            return result;
        }

        /// <summary>
        /// Combines the patient and queue temporary builder.
        /// </summary>
        /// <param name="queueNumberTempViewModels">The queue number temporary view models.</param>
        /// <param name="priorityType">Type of the priority.</param>
        /// <returns>List&lt;CombinePatientAndQueueTempViewModel&gt;.</returns>
        private async Task<List<CombinePatientAndQueueTempViewModel>> CombinePatientAndQueueTempBuilder(
            List<QueueNumberTemp> queueNumberTempViewModels, PriorityType priorityType)
        {
            var patientCodes = queueNumberTempViewModels.Select(s => s.PatientCode);
            var patients = await _unitOfWork.GetRepository<Patient>().GetAll().AsNoTracking()
                .Where(x => patientCodes.Contains(x.Code)).ToListAsync();
            var list = new List<CombinePatientAndQueueTempViewModel>();
            foreach (var queue in queueNumberTempViewModels)
            {
                var patientWithQueue = new CombinePatientAndQueueTempViewModel
                {
                    QueueNumer = _mapper.Map<QueueNumberTempViewModel>(queue)
                };

                var patient = patients.FirstOrDefault(q => q.Code == queue.PatientCode);
                if (patient != null)
                {
                    patientWithQueue.Patient = _mapper.Map<PatientViewModel>(patient);
                }

                patientWithQueue.PriorityType = priorityType;
                list.Add(patientWithQueue);
            }

            return list;
        }
        /// <summary>
        /// Filters the patienst in room.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private async Task<IQueryable<QueueNumber>> FilterPatienstInRoom(GetPatientsInRoomRequest request)
        {
            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(x => x.CreatedDate.Date >= request.StartDate.Date && x.CreatedDate.Date <= request.EndDate.Date);
            var patientCode = request.PatientCode.Trim();
            var patientName = request.PatientName.Trim().ToLower();
            var departmentCode = request.DepartmentCode.Trim();

            if (!string.IsNullOrEmpty(departmentCode))
            {
                queueNumbers = queueNumbers.Where(number => number.DepartmentCode == departmentCode);
            }
            else if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(patientCode))
            {
                var patientGetByCodeAndName = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == patientCode && (x.LastName + " " + x.FirstName).ToLower().Contains(patientName));
                if (patientGetByCodeAndName != null)
                    queueNumbers = queueNumbers.Where(number => number.PatientId == patientGetByCodeAndName.Id);
                else
                {
                    var tempPatientGetByCodeAndName = await _unitOfWork.GetRepository<TempPatient>().FindAsync(x => x.Code == patientCode && (x.LastName + " " + x.FirstName).ToLower().Contains(patientName));
                    if (tempPatientGetByCodeAndName != null)
                        queueNumbers = queueNumbers.Where(number => number.PatientId == tempPatientGetByCodeAndName.Id);
                    else
                        queueNumbers = queueNumbers = queueNumbers.Where(number => number.PatientId == null);
                }
            }
            else if (!string.IsNullOrEmpty(patientName))
            {
                var patientIds = new List<Guid>();
                var patient = await _unitOfWork.GetRepository<Patient>().GetAll().Where(x => (x.LastName + " " + x.FirstName).ToLower().Contains(patientName)).Select(x => x.Id).ToListAsync();
                var tempPatient = await _unitOfWork.GetRepository<TempPatient>().GetAll().Where(x => (x.LastName + " " + x.FirstName).ToLower().Contains(patientName)).Select(x => x.Id).ToListAsync();
                patientIds.AddRange(patient);
                patientIds.AddRange(tempPatient);
                queueNumbers = queueNumbers.Where(number => patientIds.Any(p => p == number.PatientId));
            }
            else if (!string.IsNullOrEmpty(patientCode))
            {
                var patientGetByCode = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == patientCode);
                if (patientGetByCode != null)
                    queueNumbers = queueNumbers.Where(number => number.PatientId == patientGetByCode.Id);
                else
                {
                    var tempPatientGetByCode = await _unitOfWork.GetRepository<TempPatient>().FindAsync(x => x.Code == patientCode);
                    if (tempPatientGetByCode != null)
                        queueNumbers = queueNumbers.Where(number => number.PatientId == tempPatientGetByCode.Id);
                    else
                        queueNumbers = queueNumbers = queueNumbers.Where(number => number.PatientId == null);
                }
            }
            else if (!string.IsNullOrEmpty(request.AreaCode))
                queueNumbers = queueNumbers.Where(number => number.AreaCode == request.AreaCode);
            else if (!string.IsNullOrEmpty(request.RegisteredCode))
            {
                queueNumbers = queueNumbers.Where(number => number.RegisteredCode == request.RegisteredCode);
            }

            return queueNumbers;
        }
        /// <summary>
        /// Patients the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<CheckInResponse> PatientCheckIn(CheckInRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);

            if (patient == null)
                throw new Exception(MessagesCode.NotFoundPatientWithCode);

            var table = await _unitOfWork.GetRepository<Table>().GetAll().FirstOrDefaultAsync(x => x.ComputerIP == request.Ip);

            if (table == null)
                throw new Exception(MessagesCode.TableNotExist);

            var queueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == table.DepartmentCode);

            var patientNumner = await queueNumber.FirstOrDefaultAsync(number => number.PatientId == patient.Id);

            if (patientNumner == null)
                throw new Exception(MessagesCode.PatientHasNotTakenNumber);

            if (patientNumner.IsSelected)
                throw new Exception(MessagesCode.FinishedQueueNumberTemp);

            var lastestNumber = queueNumber.Where(x => x.IsSelected).OrderByDescending(number => number.Number).Take(1).SingleOrDefault()?.Number ?? 0;

            if (patientNumner.Number > lastestNumber)
                throw new Exception(MessagesCode.QueueNumberIsNotTurn);

            return _mapper.Map(patient, new CheckInResponse());
        }

        /// <summary>
        /// Adds the queue number temporary.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Task&lt;QueueNumberTempViewModel&gt;.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<QueueNumberTempViewModel> AddQueueNumberTemp(AddQueueNumberTempRequest request)
        {
            var patient = await _patientService.GetByCode(request.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var table = await _unitOfWork.GetRepository<Table>().FindAsync(t => t.Code == request.TableCode);

            if (table == null)
                throw new Exception(ErrorMessages.TableNotExist);

            if (table.Type == PriorityType.Normal ? patient.PatientType != PatientType.Normal : patient.PatientType == PatientType.Normal)
                throw new Exception(ErrorMessages.NotCorrectlyTableCode);

            var queueNumberTempModel = await _unitOfWork.GetRepository<QueueNumberTemp>()
                .GetAll().FirstOrDefaultAsync(queue => queue.DepartmentCode == request.DepartmentCode
                && queue.PatientCode == request.PatientCode);

            if (queueNumberTempModel != null)
            {
                if (queueNumberTempModel.IsFinished)
                    throw new Exception(ErrorMessages.FinishedQueueNumberTemp);
                else if (queueNumberTempModel.IsSelected)
                {
                    queueNumberTempModel.IsFinished = true;
                    _unitOfWork.GetRepository<QueueNumberTemp>().Update(queueNumberTempModel);
                    await _unitOfWork.CommitAsync();
                    var verifyViewModel = _mapper.Map<QueueNumberTempViewModel>(queueNumberTempModel);
                    verifyViewModel.Status = QueueTempStatus.Verified;
                    return verifyViewModel;
                }
                else
                    throw new Exception(ErrorMessages.PatientHasNotBeenCalledIntoTheRoom);
            }

            var queueNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(queue => queue.DepartmentCode == request.DepartmentCode
                && queue.PatientId == patient.Id);

            if (queueNumber == null)
            {
                throw new Exception(ErrorMessages.NotFoundQueueNumber);
            }

            var queueNumberTemp = _mapper.Map<QueueNumberTemp>(queueNumber);
            queueNumberTemp.TableCode = request.TableCode;
            queueNumberTemp.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            queueNumberTemp.PatientCode = patient.Code;

            _unitOfWork.GetRepository<QueueNumberTemp>().Add(queueNumberTemp);
            await _unitOfWork.CommitAsync();
            var viewModel = _mapper.Map<QueueNumberTempViewModel>(queueNumberTemp);
            viewModel.Status = QueueTempStatus.Added;
            return viewModel;
        }

        /// <summary>
        /// Verifies the queue temporary request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;QueueNumberTemp&gt;.</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumberTemp> VerifyQueueTempRequest(VerifyQueueTempRequest request)
        {
            var queueNumberTempModel = await _unitOfWork.GetRepository<QueueNumberTemp>()
                .GetAll().FirstOrDefaultAsync(queue => queue.DepartmentCode == request.DepartmentCode
                && queue.PatientCode == request.PatientCode);

            var table = await _unitOfWork.GetRepository<Table>().FindAsync(t => t.Code == request.TableCode);
            if (table == null)
            {
                throw new Exception(ErrorMessages.NotFoundTable);
            }

            if (queueNumberTempModel == null)
            {
                throw new Exception(ErrorMessages.NotFoundQueueNumber);
            }

            if (queueNumberTempModel.IsFinished)
            {
                throw new Exception(ErrorMessages.FinishedQueueNumberTemp);
            }

            queueNumberTempModel.IsFinished = true;
            _unitOfWork.GetRepository<QueueNumberTemp>().Update(queueNumberTempModel);
            await _unitOfWork.CommitAsync();

            return queueNumberTempModel;
        }

        /// <summary>
        /// Gets the type of the temporary from patient code and.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;List&lt;CombinePatientAndQueueTempViewModel&gt;&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<CombinePatientAndQueueTempViewModel>> GetTempFromPatientCodeAndType(GetTempFromPatientsByDepartmentCodeRequest request)
        {
            var limit = request.Limit.HasValue ? request.Limit.Value : 1;
            var table = await _unitOfWork.GetRepository<Table>().FindAsync(t => t.Code == request.TableCode);
            if (table == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            var queueNumberTemps = await _unitOfWork.GetRepository<QueueNumberTemp>().GetAll().Where(queue => queue.DepartmentCode == request.DepartmentCode
                && !queue.IsSelected
                && (table.Type == PriorityType.Priority ? queue.Type != PatientType.Normal : queue.Type == PatientType.Normal)
                && queue.TableCode == request.TableCode)
                .OrderBy(o => o.Number)
                .Take(limit).ToListAsync();

            foreach (var item in queueNumberTemps)
            {
                item.IsSelected = true;
                item.UpdatedDate = DateTime.Now;
                item.UpdatedBy = Systems.UpdatedBy;
                _unitOfWork.GetRepository<QueueNumberTemp>().Update(item);

                var medicineReceiverLineRequest = new MedicineReceiverLineRequest
                {
                    Number = item.Number,
                    PatientCode = item.PatientCode,
                    TableCode = table.Code,
                    Type = (int)table.Type
                };

                //SignalrService.Instance.SendMessage(
                //                new SignalrRequest(new Data()
                //                {
                //                    title = Departments.THUOCBHYT,
                //                    body = medicineReceiverLineRequest
                //                }, table.DeviceCode));
            }

            await _unitOfWork.GetRepository<QueueNumberTemp>().SaveChangesAsync();

            return await CombinePatientAndQueueTempBuilder(queueNumberTemps, table.Type);
        }

        /// <summary>
        /// Processes the type of the queue number view model with.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="patientType">Type of the patient.</param>
        /// <returns></returns>
        private async Task<QueueNumberViewModel> ProcessQueueNumberViewModelWithType(Patient patient, PatientType patientType = PatientType.Normal)
        {
            var queueNumber = new QueueNumberPostModel();
            queueNumber.PatientId = patient.Id;
            queueNumber.Type = patientType;
            queueNumber.DepartmentCode = Departments.TNB;

            var queueNumberModel = _mapper.Map<QueueNumberPostModel>(queueNumber);
            var queueNumberResultModel = await AddAsync(queueNumberModel);
            var queueNumberViewModel = _mapper.Map<QueueNumberViewModel>(queueNumberResultModel);
            return queueNumberViewModel;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumber> AddUltrasoundAsync(QueueNumberAddModel postModel)
        {
            var entity = _mapper.Map<QueueNumber>(postModel);

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(item => item.Id == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => postModel.DepartmentCodes.Any(d => d == q.DepartmentCode)
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

            if (number != null)
            {
                return number;
            }

            entity.Type = patient.PatientType;
            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == entity.DepartmentCode);

            if (entity.Type == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .OrderByDescending(c => c.Number)
                .FirstOrDefaultAsync(predicate);

            entity.Number = last != null ? last.Number + 1 : 1;
            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
            //entity.PatientCode = patient.Code;
            var listValue = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .SingleOrDefaultAsync(i => i.Code == entity.DepartmentCode);
            entity.DepartmentExtendId = listValue.Id;

            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        //public async Task<UltrasoundResponse> GenerateNumber(List<CreateOrderNumberRequest> requests, string patientCode)
        //{
        //    if (requests == null || requests.Count == 0)
        //        throw new Exception("Dữ liệu không hợp lệ!");
        //    var patientInfo = await _unitOfWork.GetRepository<Patient>().FindAsync(p => p.Code == patientCode);

        //    if (patientInfo == null)
        //        throw new Exception(ErrorMessages.NotFoundPatientCode);

        //    var responses = new UltrasoundResponse();
        //    responses.Patient = _mapper.Map<PatientJson>(patientInfo);

        //    var listValueExtends = _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking();
        //    var departmentServices = _unitOfWork.GetRepository<CS.EF.Models.DepartmentClinicService>().GetAll().AsNoTracking();
        //    var typeDep = _unitOfWork.GetRepository<DepartmentMapping>().GetAll().Where(x => x.IsActive).AsNoTracking();
        //    var queueNumbers = await this.GetAllAsync();

        //    foreach (var req in requests)
        //    {
        //        var departmentJson = new DepartmentJson()
        //        {
        //            Data = new List<NumberData>()
        //        };

        //        var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(d => d.RegisteredCode == req.RegisteredCode);
        //        var transactionInfos = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
        //            .Where(x => x.RegisteredCode == req.RegisteredCode
        //                    && x.Status == TransactionStatus.Success
        //                    && x.Type == TransactionType.Hold);
        //        if (transactionInfos == null || transactionInfos.Count() == 0)
        //            throw new Exception("Không tìm thấy thông tin giao dịch!");

        //        var transClinic = await _unitOfWork.GetRepository<TransactionClinic>()
        //            .GetAll()
        //            .Where(d => transactionInfos.Any(x => x.Id == d.TransactionInfoId))
        //            .ToListAsync();

        //        for (int i = 0; i < req.Data.Count; i++)
        //        {
        //            if (req.Data[i].Services.Count <= 0)
        //                continue;

        //            foreach (var ser in req.Data[i].Services)
        //            {
        //                var departments = await departmentServices.Where(x => x.ServiceCode == ser.ServiceCode).ToArrayAsync();
        //                if (departments == null || departments.Count() == 0)
        //                    continue;

        //                var currentNumbers = new Dictionary<string, int>();

        //                foreach (var itemSe in departments)
        //                {
        //                    var count = queueNumbers.Where(x => x.DepartmentCode == itemSe.RoomCode
        //                        && !x.IsSelected
        //                        && DateTime.Compare(x.CreatedDate.Date, DateTime.Now.Date) == 0).Count();

        //                    var dep = typeDep.FirstOrDefault(x => x.RoomCode == itemSe.RoomCode && x.ExaminationCode == req.Data[i].DepartmentCode);
        //                    if (dep != null)
        //                    {
        //                        currentNumbers.Add(itemSe.RoomCode, count);
        //                    }
        //                }

        //                if (currentNumbers.Count() == 0)
        //                    continue;

        //                // Min value number queue of room
        //                var minValue = currentNumbers.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

        //                var queueNumber = await AddUltrasoundAsync(new QueueNumberAddModel()
        //                {
        //                    DepartmentCodes = currentNumbers.Select(x => x.Key).ToList(),
        //                    PatientId = patientInfo.Id,
        //                    Type = patientInfo.PatientType,
        //                    DepartmentCode = minValue
        //                });

        //                var continute = false;
        //                for (int d = 0; d < departmentJson.Data.Count; d++)
        //                {
        //                    if (departmentJson.Data[d].DepartmentCode == queueNumber.DepartmentCode
        //                        && departmentJson.Data[d].Number == queueNumber.Number)
        //                    {
        //                        departmentJson.Data[d].Services.Add(new ServiceJson()
        //                        {
        //                            ServiceCode = ser.ServiceCode,
        //                            ServiceName = listValueExtends.FirstOrDefault(x => x.Code == ser.ServiceCode)?.Description
        //                        });
        //                        // Call his update department
        //                        //await _hospitalSystemService.CallUltrasound(
        //                        //    new PostHisUltrasoundRequest()
        //                        //    {
        //                        //        DepartmentCode = queueNumber.DepartmentCode,
        //                        //        IdSpecified = transClinic.FirstOrDefault(x => x.DepartmentCode == req.Data[i].DepartmentCode
        //                        //            && x.ServiceId == ser.ServiceCode)?.IdSpecified
        //                        //    });
        //                        continute = true;
        //                        break;
        //                    }
        //                }

        //                if (continute) continue;

        //                var numberData = new NumberData()
        //                {
        //                    DepartmentCode = queueNumber.DepartmentCode,
        //                    DepartmentName = queueNumber.DepartmentExtend?.Description,
        //                    Number = queueNumber.Number,
        //                    Services = new List<ServiceJson>() {
        //                            new ServiceJson()
        //                                {
        //                                    ServiceCode = ser.ServiceCode,
        //                                    ServiceName = listValueExtends.FirstOrDefault(x => x.Code == ser.ServiceCode)?.Description
        //                                }
        //                        }
        //                };

        //                // Call his update department
        //                //await _hospitalSystemService.CallUltrasound(
        //                //            new PostHisUltrasoundRequest()
        //                //            {
        //                //                DepartmentCode = queueNumber.DepartmentCode,
        //                //                IdSpecified = transClinic.FirstOrDefault(x => x.DepartmentCode == req.Data[i].DepartmentCode
        //                //                    && x.ServiceId == ser.ServiceCode)?.IdSpecified
        //                //            });

        //                departmentJson.Data.Add(numberData);
        //            }
        //            departmentJson.RegisteredCode = req.RegisteredCode;
        //        }

        //        var examinationCode = transClinic?.FirstOrDefault(x => x.DepartmentCode == req.Data[0].DepartmentCode)?.ExaminationCode;
        //        responses.Receptions.Add(new ReceptionsJson()
        //        {
        //            Departments = departmentJson,
        //            ExaminationType = reception?.PatientType,
        //            ExaminationCode = examinationCode,
        //            ExaminationName = (transClinic != null && transClinic.Count > 0)
        //                                    ? listValueExtends.FirstOrDefault(x => x.Code == examinationCode)?.Description
        //                                    : string.Empty
        //        });
        //    }

        //    if (responses.Receptions.Count == 0)
        //        throw new Exception("Không tìm thấy phòng thực hiện dịch vụ!");

        //    return responses;
        //}

        private IQueryable<PatientsInRoomViewModel> ApplyOrderBy(IQueryable<PatientsInRoomViewModel> query, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                property = property.Trim().ToUpper();
            }

            if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.PatientCode);
            else if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.PatientCode);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.FullName);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.FullName);
            else if (property == $"{SortCondition.CREATED_DATE}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.CreatedDate);
            else if (property == $"{SortCondition.CREATED_DATE}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.CreatedDate);
            else
                return query;
        }

        /// <summary>
        /// Adds the queue number history.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumberHistory> AddQueueNumberHistory(QueueNumberHistory entity)
        {
            _unitOfWork.GetRepository<QueueNumberHistory>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<QueueNumber> AddNumberChangeRoom(QueueNumberAddModel postModel)
        {
            var entity = _mapper.Map<QueueNumber>(postModel);

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(item => item.Id == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => postModel.DepartmentCode == q.DepartmentCode
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, postModel.RequestDate.Date) == 0);

            if (number != null)
            {
                return number;
            }

            entity.Type = patient.PatientType;
            entity.CreatedDate = postModel.RequestDate;
            entity.RegisteredDate = postModel.RequestDate;
            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == entity.DepartmentCode
                && q.CreatedDate.Date == postModel.RequestDate.Date);

            if (entity.Type == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .OrderByDescending(c => c.Number)
                .FirstOrDefaultAsync(predicate);

            entity.Number = -1;
            if (DateTime.Compare(postModel.RequestDate.Date, DateTime.Now.Date) == 0)
            {
                entity.Number = last != null ? last.Number + 1 : 1;
            }

            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
           // entity.PatientCode = patient.Code;
            entity.IsSelected = false;
            var listValue = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .SingleOrDefaultAsync(i => i.Code == entity.DepartmentCode);
            entity.DepartmentExtendId = listValue.Id;

            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<bool> RevertOrderNumber(RevertOrderNumberRequest request)
        {
            var patient = await _patientService.FindAsync(x=> x.Id == request.PatientId);

            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            var orderNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(x => x.IsSelected
                && x.PatientId == patient.Id
                && (int)x.Type == request.PatientType
                && x.Number == request.Number
                && x.DepartmentCode == request.RoomActiveCode).FirstOrDefaultAsync();

            var orderNumberVirtual = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(x => x.IsSelected
                && x.PatientId == patient.Id
                && (int)x.Type == request.PatientType
                && x.Number == request.Number
                && x.DepartmentCode == request.RoomVirtualCode).FirstOrDefaultAsync();

            if (orderNumber == null || orderNumberVirtual == null)
                throw new Exception("Không tìm thấy STT của bệnh nhân!");

            orderNumberVirtual.IsSelected = false;
            _unitOfWork.GetRepository<QueueNumber>().Update(orderNumberVirtual);
            if (orderNumber.Id != orderNumberVirtual.Id)
            {
                _unitOfWork.GetRepository<QueueNumber>().Delete(orderNumber);
            }

            await _unitOfWork.CommitAsync();

            return true;
        }


        public async Task<bool> RevertOrderNumberNormalDepartment(RevertOrderNumberNormalDepartmentRequest request)
        {
            var patient = await _patientService.FindAsync(x => x.Id == request.PatientId);

            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            var orderNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(x => x.IsSelected
                && x.PatientId == patient.Id
                && (int)x.Type == request.PatientType
                && x.Number == request.Number
                && x.DepartmentCode == request.Room).FirstOrDefaultAsync();

            if (orderNumber == null )
                throw new Exception(ErrorMessages.NotFoundQueueNumber);

            orderNumber.IsSelected = false;
            _unitOfWork.GetRepository<QueueNumber>().Update(orderNumber);

            await _unitOfWork.CommitAsync();

            return true;
        }


        public ICollection<QueueNumber> GetPatientsInRoomEndoscopic(GetPatientsInEndoscopicRequest request, out int totalRecord, bool isExport)
        {
            // STT đã gọi vào phòng nội soi
            var queueNumbers = new List<QueueNumber>();

            queueNumbers = _unitOfWork
                .GetRepository<QueueNumber>()
                .GetAll()
                .Where(x => x.CreatedDate.Date >= request.StartDate.Date && x.CreatedDate.Date <= request.EndDate.Date)
                .ToList();

            // DepartmentCode hiện tại là group code
            if (!string.IsNullOrEmpty(request.GroupCode))
            {
                var groupCode = request.GroupCode.Trim();
                var departmentGroup = _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                    .Where(x => x.GroupCode == groupCode).FirstOrDefault();
                // STT còn ở phòng ảo
                if (departmentGroup != null && departmentGroup.DepartmentVirtual != null)
                {
                    var queueNumber2s = _unitOfWork.GetRepository<QueueNumber>()
                     .GetAll()
                     .Where(x => x.CreatedDate.Date >= request.StartDate.Date && x.CreatedDate.Date <= request.EndDate.Date
                     && x.DepartmentCode == departmentGroup.DepartmentVirtual.Code);

                    queueNumbers = queueNumber2s.ToList();
                }
            }

            if (!string.IsNullOrEmpty(request.PatientName))
            {
                var patientName = request.PatientName.Trim().ToLower();
                queueNumbers = queueNumbers.Where(number => (number.Patient.LastName + " " + number.Patient.FirstName).ToLower().Contains(patientName)).ToList();
            }

            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                var patientCode = request.PatientCode.Trim();
                var patientGetByCodes = _unitOfWork.GetRepository<Patient>().GetAll().Where(x => x.Code.Contains(patientCode));
                if (patientGetByCodes != null && patientGetByCodes.Count() > 0)
                    queueNumbers = queueNumbers.Where(number => patientGetByCodes.Any(p => p.Id == number.PatientId)).ToList();
                else
                {
                    var tempPatientGetByCodes = _unitOfWork.GetRepository<TempPatient>().GetAll().Where(x => x.Code.Contains(patientCode));
                    if (tempPatientGetByCodes != null)
                        queueNumbers = queueNumbers.Where(number => tempPatientGetByCodes.Any(p => p.Id == number.PatientId)).ToList();
                    else
                        queueNumbers = queueNumbers = queueNumbers.Where(number => number.PatientId == null).ToList();
                }
            }

            if (!string.IsNullOrEmpty(request.AreaCode))
                queueNumbers = queueNumbers.Where(number => number.AreaCode == request.AreaCode).ToList();

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                queueNumbers = queueNumbers.Where(number => number.RegisteredCode == request.RegisteredCode).ToList();
            }

            if (!isExport)
            {
                totalRecord = queueNumbers.Count();
                if (request.PageSize > 0)
                {
                    queueNumbers = queueNumbers.Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize).ToList();
                }
                else
                {
                    queueNumbers = queueNumbers.ToList();
                }
            }
            else
            {
                totalRecord = queueNumbers.Count();
                queueNumbers = queueNumbers.ToList();
            }

            return queueNumbers;
        }

        public async Task<QueueNumber> EndoscopicBoardingRegisterQueueNumber(EndoscopicBoardingRegisterOrderNumberRequest request, Patient model)
        {
            var departmentVirtual = _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                .Where(x => x.GroupCode == request.GroupCode).FirstOrDefault().DepartmentVirtual;

            var patient = await _patientService.GetByCode(request.HospitalAdmissionCode);

            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (departmentVirtual == null)
                throw new Exception("Không tìm thấy phòng khám để đăng ký!");

            var exist = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                           .Where(x => x.DepartmentCode == departmentVirtual.Code
                           && x.CreatedDate.Date == DateTime.Now.Date).ToListAsync();

            if (patient!= null)
            {
                exist = exist.Where(x=> x.PatientId == patient.Id).ToList();
            }

            if (exist.FirstOrDefault() != null)
                return exist.FirstOrDefault();

            var departmentConfig = _unitOfWork.GetRepository<DepartmentConfig>().GetAll()
                           .Where(x => x.DepartmentCode == departmentVirtual.Code)
                           .FirstOrDefault();

            if (departmentConfig == null)
                throw new Exception("Không tìm thấy cấu hình phòng khám");

            var countQueueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(x => x.DepartmentCode == departmentVirtual.Code && x.CreatedDate.Date == DateTime.Now.Date)
                .Count();

            // Hết lượt khám ngày hôm nay
            if (countQueueNumbers >= departmentConfig.TotalNumber)
            {
                var modelQueue = new QueueNumber();
                modelQueue.DepartmentCode = departmentVirtual.Code;
                //modelQueue.Patient = patientInfo;
                modelQueue.PatientId = model.Id;
                //modelQueue.PatientCode = model.Code;
                modelQueue.Type = model.PatientType;
                // STT mặc định khi hết lượt
                modelQueue.Number = -2;
                modelQueue.AreaCode = _hospitalSettings.Hospital.HospitalArea;
                var lv = _unitOfWork.GetRepository<ListValueExtend>().GetAll().FirstOrDefault(l => l.Code == modelQueue.DepartmentCode);
                modelQueue.DepartmentExtendId = lv.Id;

                _unitOfWork.GetRepository<QueueNumber>().Add(modelQueue);
                await _unitOfWork.CommitAsync();
                throw new Exception("Đã hết lượt khám trong ngày hôm nay, vui lòng hẹn lại ngày khám!");
            }

            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == departmentVirtual.Code
               && q.CreatedDate.Date == DateTime.Now.Date);
            var entity = new QueueNumber();
            if (model.PatientType == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }
            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                             .OrderByDescending(c => c.Number)
                             .FirstOrDefaultAsync(predicate);

            entity.DepartmentCode = departmentVirtual.Code;
            entity.PatientId = model.Id;
            //entity.PatientCode = model.Code;
            entity.Type = model.PatientType;
            entity.Number = last != null ? last.Number + 1 : 1;
            if (last != null && last.Number < 0)
            {
                entity.Number = last != null ? last.Number + Math.Abs(last.Number) + 1 : 1;
            }

            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            var department = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().FirstOrDefaultAsync(l => l.Code == entity.DepartmentCode);
            entity.DepartmentExtendId = department.Id;
            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }


        /// <summary>
        /// Registers the queue number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<RegisterQueueNumberResponse> RegisterEndoscopicQueueNumber(RegisterEndoscopicQueueNumberRequest request)
        {
            var patient = await _patientService.GetByCode(request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            var departmentVirtual = _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                .Where(x => x.GroupCode == request.GroupCode).FirstOrDefault()?.DepartmentVirtual;

            if (departmentVirtual == null)
                throw new Exception("Không tìm thấy phòng khám để đăng ký!");

            patient = _mapper.Map(request, patient);

            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => q.DepartmentCode == departmentVirtual.Code
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

            if (number != null)
            {
                var resultExist = _mapper.Map<RegisterQueueNumberResponse>(number);
                resultExist.QueueNumberViewModel = _mapper.Map<QueueNumberViewModel>(number);
                resultExist.QueueNumberViewModel.DepartmentName = number.DepartmentExtend?.Description;

                return resultExist;
            }

            var departmentConfig = _unitOfWork.GetRepository<DepartmentConfig>().GetAll()
                           .Where(x => x.DepartmentCode == departmentVirtual.Code)
                           .FirstOrDefault();

            if (departmentConfig == null)
                throw new Exception("Không tìm thấy cấu hình phòng khám");

            var countQueueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(x => x.DepartmentCode == departmentVirtual.Code && x.CreatedDate.Date == DateTime.Now.Date)
                .Count();

            // Trả respone để in bill hẹn khám
            if (countQueueNumbers >= departmentConfig.TotalNumber)
            {
                var entityQueue = new QueueNumber();
                entityQueue.DepartmentCode = departmentVirtual.Code;
                //entityQueue.Patient = patientInfo;
                entityQueue.PatientId = patient.Id;
                //entityQueue.PatientCode = patient.Code;
                entityQueue.Type = patient.PatientType;
                // STT mặc định khi hết lượt
                entityQueue.Number = -2;
                entityQueue.AreaCode = _hospitalSettings.Hospital.HospitalArea;
                var lv = await _unitOfWork.GetRepository<ListValueExtend>()
                     .GetAll()
                     .SingleOrDefaultAsync(i => i.Code == entityQueue.DepartmentCode);
                entityQueue.DepartmentExtendId = lv.Id;

                _unitOfWork.GetRepository<QueueNumber>().Add(entityQueue);
                await _unitOfWork.CommitAsync();
                throw new Exception("Đã hết lượt khám trong ngày hôm nay, vui lòng hẹn lại ngày khám!");
            }

            var entity = new QueueNumber();
            entity.RegisteredDate = request.RegisteredDate;
            entity.Type = patient.PatientType;
            entity.RegisteredCode = request.RegisteredCode;

            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == departmentVirtual.Code);

            if (entity.Type == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }

            entity.Type = patient.PatientType;

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .OrderByDescending(c => c.Number)
                .FirstOrDefaultAsync(predicate);

            entity.DepartmentCode = departmentVirtual.Code;
            entity.Patient = patient;
            entity.PatientId = patient.Id;
            //entity.PatientCode = patient.Code;
            entity.Type = patient.PatientType;

            entity.Number = last != null ? last.Number + 1 : 1;
            if (last != number && last.Number < 0)
            {
                entity.Number = last != null ? last.Number + Math.Abs(last.Number) + 1 : 1;
            }

            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
            entity.PatientId = patient.Id;
            var listValue = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .SingleOrDefaultAsync(i => i.Id == departmentVirtual.Id);
            entity.DepartmentExtendId = listValue.Id;

            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            await _unitOfWork.CommitAsync();

            var result = _mapper.Map<RegisterQueueNumberResponse>(entity);
            result.QueueNumberViewModel = _mapper.Map<QueueNumberViewModel>(entity);
            result.QueueNumberViewModel.DepartmentName = entity.DepartmentExtend?.Description;
            return result;
        }

        public async Task<RegisterQueueNumberResponse> RePrintQueueNumber(RePrintQueueNumberRequest request)
        {
            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (number == null)
            {
                throw new Exception("Không tìm thấy STT.");
            }

            var resultExist = _mapper.Map<RegisterQueueNumberResponse>(number);
            resultExist.QueueNumberViewModel = _mapper.Map<QueueNumberViewModel>(number);
            resultExist.QueueNumberViewModel.DepartmentName = number.DepartmentExtend?.Description;

            return resultExist;
        }

        public async Task<ResetQueueNumberResponse> ResetQueueNumber(ResetQueueNumberRequest request)
        {
            var startTime = DateTime.Now;
            if (request.Username != "tekmedi" || request.Password != "tekmedibvk2022")
            {
                throw new Exception("Sai tài khoản hoặc mật khẩu");
            }

            var sql =
            "TRUNCATE TABLE \"IHM\".queue_number; " +
            "TRUNCATE TABLE \"IHM\".queue_number_temp; " +
            "TRUNCATE TABLE \"IHM\".patient_temp; " +
            "TRUNCATE TABLE \"IHM\".transaction_draft; " +
            "TRUNCATE TABLE \"IHM\".transaction_draft_clinic; " +
            "TRUNCATE TABLE \"IHM\".transaction_draft_prescription; " +
            "TRUNCATE TABLE public.table_call_number_normal; " +
            "TRUNCATE TABLE public.table_call_number_priority; " +
            "TRUNCATE TABLE public.table_d_call_number_normal; " +
            "TRUNCATE TABLE public.table_d_call_number_priority; " +
            "TRUNCATE TABLE public.table_call_paid_number_normal; " +
            "TRUNCATE TABLE public.table_call_paid_number_priority; " +
            "DROP TABLE public.table_call_number_normal; " +
            "DROP TABLE public.table_call_number_priority; " +
            "DROP TABLE public.table_call_paid_number_normal; " +
            "DROP TABLE public.table_call_paid_number_priority; " +
            "DROP TABLE public.table_d_call_number_normal; " +
            "DROP TABLE public.table_d_call_number_priority; " +

            "CREATE TABLE public.table_d_call_number_priority " +
            "( " +
                "seq bigserial NOT NULL, " +
                "\"table\" character varying(50) COLLATE pg_catalog.\"default\", " +
                "created_date timestamp without time zone DEFAULT now(), " +
                "\"created_by\" uuid, " +
                "ip character varying COLLATE pg_catalog.\"default\", " +
                "user_id uuid, " +
                "area_code character varying COLLATE pg_catalog.\"default\", " +
                "CONSTRAINT table_d_call_number_priority_pk PRIMARY KEY (seq) " +
            ") " +
            "WITH ( " +
                "OIDS = FALSE " +
            ") " +
            "TABLESPACE pg_default; " +

            "CREATE TABLE public.table_d_call_number_normal " +
            "( " +
                "seq bigserial NOT NULL, " +
                "\"table\" character varying(50) COLLATE pg_catalog.\"default\", " +
                "created_date timestamp without time zone DEFAULT now(), " +
                "\"created_by\" uuid, " +
                "ip character varying COLLATE pg_catalog.\"default\", " +
                "area_code character varying(36) COLLATE pg_catalog.\"default\", " +
                "CONSTRAINT table_d_call_number_normal_pk PRIMARY KEY (seq) " +
            ") " +
            "WITH ( " +
                "OIDS = FALSE " +
            ") " +
            "TABLESPACE pg_default; " +

            "CREATE TABLE public.table_call_paid_number_priority " +
            "( " +
                "seq bigserial NOT NULL, " +
                "created_date timestamp without time zone DEFAULT now(), " +
                "\"created_by\" uuid, " +
                "ip character varying COLLATE pg_catalog.\"default\", " +
                "\"table\" character varying(5) COLLATE pg_catalog.\"default\", " +
                "CONSTRAINT table_call_paid_number_priority_pk PRIMARY KEY (seq) " +
            ") " +
            "WITH ( " +
                "OIDS = FALSE " +
            ") " +
            "TABLESPACE pg_default; " +

            "CREATE TABLE public.table_call_paid_number_normal " +
            "( " +
                "seq bigserial NOT NULL, " +
                "created_date timestamp without time zone DEFAULT now(), " +
                "\"created_by\" uuid, " +
                "ip character varying COLLATE pg_catalog.\"default\", " +
                "\"table\" character varying(5) COLLATE pg_catalog.\"default\", " +
                "CONSTRAINT table_call_paid_number_normal_pk PRIMARY KEY (seq) " +
            ") " +
            "WITH ( " +
                "OIDS = FALSE " +
            ") " +
            "TABLESPACE pg_default; " +

            "CREATE TABLE public.table_call_number_priority " +
            "( " +
                "seq bigserial NOT NULL, " +
                "\"table\" character varying(50) COLLATE pg_catalog.\"default\", " +
                "created_date timestamp without time zone DEFAULT now(), " +
                "\"created_by\" uuid, " +
                "ip character varying COLLATE pg_catalog.\"default\", " +
                "area_code character varying COLLATE pg_catalog.\"default\", " +
                "CONSTRAINT table_call_number_priority_pk PRIMARY KEY (seq) " +
            ") " +
            "WITH ( " +
                "OIDS = FALSE " +
            ") " +
            "TABLESPACE pg_default; " +

            "CREATE TABLE public.table_call_number_normal " +
            "( " +
                "seq bigserial NOT NULL, " +
                "\"table\" character varying(50) COLLATE pg_catalog.\"default\", " +
                "created_date timestamp without time zone DEFAULT now(), " +
                "\"created_by\" uuid, " +
                "ip character varying COLLATE pg_catalog.\"default\", " +
                "area_code character varying(36) COLLATE pg_catalog.\"default\", " +
                "CONSTRAINT table_call_number_normal_pk PRIMARY KEY (seq) " +
            ") " +
            "WITH ( " +
                "OIDS = FALSE " +
            ") " +
            "TABLESPACE pg_default; " +

            "select true; ";

            var success = false;
            var response = new ResetQueueNumberResponse();
            try
            {
                var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    using (var multi = await connection.QueryMultipleAsync(sql).ConfigureAwait(false))
                    {
                        success = await multi.ReadSingleAsync<bool>();
                    }
                }

                response.Success = success;
                response.StartTime = startTime;
                response.EndTime = DateTime.Now;
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<Guid> departments)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumber> Generate(Patient patient, string departmentCode)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<CreateOrderNumberRequest> departments)
        {
            throw new NotImplementedException();
        }

        Task<GetPatientsInRoomResponse> IOrderNumberService.GetPatientsInRoom(GetPatientsInRoomRequest roomRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QueueNumber>> GetByPatientCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Patient>> GetResult()
        {
            throw new NotImplementedException();
        }

        public Task<List<QueueNumber>> GenerateClinicResult(QueueNumberPostModel postModel)
        {
            throw new NotImplementedException();
        }
    }
}