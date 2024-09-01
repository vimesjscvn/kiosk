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
using CS.Common.Extensions;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.PostModels;
using CS.VM.QueueNumberModels;
using CS.VM.QueueNumberModels.Requests;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Settings;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;
using TEK.Core.Domain.BusinessObjects;

namespace TEK.Payment.Domain.Services
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
        /// The patient service
        /// </summary>
        private readonly IPatientService _patientService;

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
        /// Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNumberService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public OrderNumberService(IUnitOfWork unitOfWork,
            IMapper mapper,
            HospitalSettings hospitalSettings,
            IHospitalSystemService hospitalSystemService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hospitalSettings = hospitalSettings;
            _hospitalSystemService = hospitalSystemService;
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
            _unitOfWork.GetRepository<QueueNumber>().SaveChanges();
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
                _unitOfWork.GetRepository<QueueNumber>().SaveChanges();
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
            _unitOfWork.GetRepository<QueueNumber>().SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(QueueNumber entity)
        {
            _unitOfWork.GetRepository<QueueNumber>().Delete(entity);
            _unitOfWork.GetRepository<QueueNumber>().SaveChanges();
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
        public async Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<Guid> departments)
        {
            // Không cấp STT vào những phòng nội soi, siêu âm
            //var departmentOfGroups = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
            //    .Where(x => x.GroupCode == Groups.Endoscopic || x.GroupCode == Groups.Ultrasound)
            //    .Select(x => x.DepartmentCode).ToListAsync();

            // departments = departments.Where(x => !departmentOfGroups.Any(d => d == x)).ToList();

            var services = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(v => departments.Any(id => id == v.Id)).ToListAsync();
            var currentNumbers = new List<QueueNumber>();
            var queueNumbers = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Distinct().AsNoTracking()
                .Where(q => departments.Any(id => id == q.DepartmentExtendId)
                && q.PatientId == patientInfo.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0).ToListAsync();

            var finalDepartments = departments.Except(queueNumbers.Select(s => s.DepartmentExtendId)).Distinct().ToList();

            if (patientInfo.PatientType == PatientType.Normal)
            {
                currentNumbers = await _unitOfWork.GetRepository<QueueNumber>()
                    .GetAll()
                    .Where(v => finalDepartments.Any(id => id == v.DepartmentExtendId)
                    && v.Type == PatientType.Normal).ToListAsync();
            }
            else
            {
                currentNumbers = await _unitOfWork.GetRepository<QueueNumber>()
                    .GetAll()
                    .Where(v => finalDepartments.Any(id => id == v.DepartmentExtendId)
                    && v.Type != PatientType.Normal).ToListAsync();
            }

            foreach (var id in finalDepartments)
            {
                var queueNumber = new QueueNumber();
                queueNumber.DepartmentCode = services.FirstOrDefault(s => s.Id == id).Code;
                queueNumber.DepartmentExtendId = id;
                //queueNumber.PatientCode = patientInfo.Code;
                queueNumber.PatientId = patientInfo.Id;
                queueNumber.Type = patientInfo.PatientType;
                queueNumber.Number = currentNumbers
                    .Where(n => n.DepartmentExtendId == id)
                    .OrderByDescending(n => n.Number)
                    .FirstOrDefault()?.Number + 1 ?? 1;
                _unitOfWork.GetRepository<QueueNumber>().Add(queueNumber);
                queueNumbers.Add(queueNumber);
            }

            await _unitOfWork.CommitAsync();
            return queueNumbers;
        }

        /// <summary>
        /// Registers the queue number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<RegisterQueueNumberResponse> RegisterQueueNumber(RegisterQueueNumberRequest request)
        {
            var patient = await _patientService.GetByPatientCode(request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            patient = _mapper.Map(request, patient);

            var queueNumber = await Generate(patient, request.DepartmentCode);
            var result = _mapper.Map<RegisterQueueNumberResponse>(queueNumber);
            return result;
        }

        public async Task<GenerateByPatientCodeResponse> GenerateByPatientCodeWithType(GenerateByPatientCodeWithTypeRequest request)
        {
            var patient = await _patientService.GetByPatientCode(request.PatientCode);
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
                    && q.AreaCode == entity.AreaCode
                    && q.Type == PatientType.Normal);
            }
            else
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == entity.AreaCode
                    && q.Type != PatientType.Normal);
            }

            entity.Number = last != null ? last.Number + 1 : 1;
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
            var patient = await _unitOfWork.GetRepository<TempPatient>().GetAll().SingleOrDefaultAsync(item => item.Id == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundTempPatientCode);
            }

            if (entity.DepartmentCode == Departments.TNB)
            {
                var t = Task.Factory.StartNew(() => _hospitalSystemService.PostCheckInInfo(new PostRawCheckInInfoRequest
                {
                    TempCode = patient.Code
                }));
            }

            var last = new QueueNumber();
            entity.Type = patient.PatientType;

            if (entity.Type == PatientType.Normal)
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == entity.AreaCode
                    && q.Type == PatientType.Normal);
            }
            else
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                    && q.AreaCode == entity.AreaCode
                    && q.Type != PatientType.Normal);
            }

            entity.Number = last != null ? last.Number + 1 : 1;
            entity.PatientId = patient.Id;
            var department = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().SingleOrDefaultAsync(l => l.Code == entity.DepartmentCode);
            if (department != null)
            {
                entity.DepartmentExtendId = department.Id;
            }

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
            var patient = await _unitOfWork.GetRepository<Patient>()
                .GetAll().SingleOrDefaultAsync(p => p.Code == request.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

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
                && q.AreaCode == postModel.AreaCode
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

            if (number != null)
            {
                return number;
            }

            entity.Type = patient.PatientType;
            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == entity.DepartmentCode);

            if (!string.IsNullOrEmpty(postModel.AreaCode))
            {
                predicate = predicate.And(q => q.AreaCode == postModel.AreaCode);
            }

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
            entity.AreaCode = !string.IsNullOrEmpty(postModel.AreaCode) ? postModel.AreaCode : _hospitalSettings.Hospital.HospitalArea;
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
        public async Task<QueueNumber> Generate(Patient patient, string departmentCode)
        {
            var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => q.DepartmentCode == departmentCode
                && q.PatientId == patient.Id
                && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

            if (number != null)
            {
                return number;
            }

            var entity = new QueueNumber();
            entity.Type = PatientType.Normal;

            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == departmentCode);

            if (entity.Type == PatientType.Normal)
            {
                predicate = predicate.And(q => q.Type == PatientType.Normal);
            }
            else
            {
                predicate = predicate.And(q => q.Type != PatientType.Normal);
            }

            entity.Type = PatientType.Normal;

            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .OrderByDescending(c => c.Number)
                .FirstOrDefaultAsync(predicate);

            entity.DepartmentCode = departmentCode;
            //entity.PatientCode = patient.Code;
            entity.PatientId = patient.Id;
            entity.Type = PatientType.Normal;
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
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        public async Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<CreateOrderNumberRequest> departments)
        {
            // Không cấp STT vào những phòng nội soi, siêu âm
            var departmentGroups = _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                .Where(x => x.GroupCode == Groups.Ultrasound)
                .Select(x => x.DepartmentCode).ToList();

            //foreach (var item in departments)
            //{
            //    var dep = departmentGroups.FirstOrDefault(x => x.DepartmentCode == item.DepartmentCode);

            //    if (dep != null)
            //    {
            //        if (dep.GroupCode == Groups.Endoscopic)
            //        {
            //            item.DepartmentCode = Groups.Endoscopic;
            //        }

            //        if (dep.GroupCode == Groups.Ultrasound)
            //        {
            //            item.DepartmentCode = Groups.Ultrasound;
            //        }
            //    }
            //}

            departments = departments.Where(x => !departmentGroups.Any(a => a == x.DepartmentCode)).ToList();

            var departmentCodes = departments.Select(s => s.DepartmentCode);
            var services = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(v => departmentCodes.Any(d => d == v.Code)).ToListAsync();
            var currentNumbers = new List<QueueNumber>();
            var queueNumbers = new List<QueueNumber>();
            var finalDepartments = new List<CreateOrderNumberRequest>();

            foreach (var item in departments)
            {
                if (DateTime.Compare(DateTime.Now.Date, item.RegisteredDate.Date) >= 0)
                {
                    var queueNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .Where(q => item.DepartmentCode == q.DepartmentCode
                        && q.PatientId == patientInfo.Id
                        && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0).ToListAsync();

                    if (queueNumber.Count > 0)
                    {
                        queueNumbers.AddRange(queueNumber);
                    }
                    else
                    {
                        finalDepartments.Add(item);
                    }
                }
                else
                {
                    var queueNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .Where(q => item.DepartmentCode == q.DepartmentCode
                        && q.PatientId == patientInfo.Id
                        && DateTime.Compare(q.CreatedDate.Date, item.RegisteredDate.Date) == 0).ToListAsync();

                    if (queueNumber.Count > 0)
                    {
                        queueNumbers.AddRange(queueNumber);
                    }
                    else
                    {
                        finalDepartments.Add(item);
                    }
                }
            }

            finalDepartments = finalDepartments.DistinctBy(d => d.DepartmentCode).ToList();

            foreach (var item in finalDepartments)
            {
                if (DateTime.Compare(DateTime.Now.Date, item.RegisteredDate.Date) >= 0)
                {
                    if (patientInfo.PatientType == PatientType.Normal)
                    {
                        var currentNumber = await _unitOfWork.GetRepository<QueueNumber>()
                             .GetAll()
                             .Where(v => item.DepartmentCode == v.DepartmentCode
                             && v.Type == PatientType.Normal
                             && DateTime.Compare(v.CreatedDate.Date, DateTime.Now.Date) == 0).ToListAsync();

                        currentNumbers.AddRange(currentNumber);
                    }
                    else
                    {
                        var currentNumber = await _unitOfWork.GetRepository<QueueNumber>()
                             .GetAll()
                             .Where(v => item.DepartmentCode == v.DepartmentCode
                             && v.Type != PatientType.Normal
                             && DateTime.Compare(v.CreatedDate.Date, DateTime.Now.Date) == 0).ToListAsync();

                        currentNumbers.AddRange(currentNumber);
                    }
                }
                else
                {
                    if (patientInfo.PatientType == PatientType.Normal)
                    {
                        var currentNumber = await _unitOfWork.GetRepository<QueueNumber>()
                             .GetAll()
                             .Where(v => item.DepartmentCode == v.DepartmentCode
                             && v.Type == PatientType.Normal
                             && DateTime.Compare(v.CreatedDate.Date, item.RegisteredDate.Date) == 0).ToListAsync();

                        currentNumbers.AddRange(currentNumber);
                    }
                    else
                    {
                        var currentNumber = await _unitOfWork.GetRepository<QueueNumber>()
                             .GetAll()
                             .Where(v => item.DepartmentCode == v.DepartmentCode
                             && v.Type != PatientType.Normal
                             && DateTime.Compare(v.CreatedDate.Date, item.RegisteredDate.Date) == 0).ToListAsync();

                        currentNumbers.AddRange(currentNumber);
                    }
                }
            }

            foreach (var item in finalDepartments)
            {
                var queueNumber = new QueueNumber();
                queueNumber.DepartmentCode = item.DepartmentCode;
                queueNumber.DepartmentExtendId = Enumerable.FirstOrDefault<ListValueExtend>(services, (Func<ListValueExtend, bool>)(s => (bool)(s.Code == item.DepartmentCode))).Id;
                //queueNumber.PatientCode = patientInfo.Code;
                queueNumber.PatientId = patientInfo.Id;
                queueNumber.Type = patientInfo.PatientType;
                queueNumber.Number = currentNumbers
                    .Where(n => n.DepartmentCode == item.DepartmentCode)
                    .OrderByDescending(n => n.Number)
                    .FirstOrDefault()?.Number + 1 ?? 1;

                if (DateTime.Compare(DateTime.Now.Date, item.RegisteredDate.Date) >= 0)
                {
                    queueNumber.CreatedDate = DateTime.Now;
                    queueNumber.UpdatedDate = DateTime.Now;
                }
                else
                {
                    queueNumber.CreatedDate = item.RegisteredDate.Date;
                    queueNumber.UpdatedDate = item.RegisteredDate.Date;
                }

                _unitOfWork.GetRepository<QueueNumber>().Add(queueNumber);
                queueNumbers.Add(queueNumber);
            }

            await _unitOfWork.CommitAsync();
            return queueNumbers;
        }

        /// <summary>
        /// Gets the patients in room.
        /// </summary>
        /// <param name="roomRequest">The room request.</param>
        /// <returns></returns>
        public async Task<GetPatientsInRoomResponse> GetPatientsInRoom(GetPatientsInRoomRequest roomRequest)
        {
            var queueNumbers = FilterPatienstInRoom(roomRequest);

            var result = await queueNumbers.OrderByDescending(x => x.CreatedDate).AsNoTracking().ToListAsync();

            return new GetPatientsInRoomResponse
            {
                PatientsInRooms = await MappingListPatientInRoom(result),
                CurrentNormalNumber = queueNumbers
                                    .Where(number => number.IsSelected && number.Type == PatientType.Normal)
                                    .OrderByDescending(number => number.Number)
                                    .Take(1)
                                    .SingleOrDefault()?.Number ?? 0,
                CurrentPriorityNumber = queueNumbers
                                    .Where(number => number.IsSelected && number.Type != PatientType.Normal)
                                    .OrderByDescending(number => number.Number)
                                    .Take(1)
                                    .SingleOrDefault()?.Number ?? 0
            };
        }

        /// <summary>
        /// Exports the patients in room.
        /// </summary>
        /// <param name="roomRequest">The room request.</param>
        /// <returns></returns>
        public async Task<List<PatientsInRoomViewModel>> ExportPatientsInRoom(GetPatientsInRoomRequest roomRequest)
        {
            var result = await FilterPatienstInRoom(roomRequest).OrderBy(number => number.Number).ToListAsync();

            return await MappingListPatientInRoom(result);
        }

        /// <summary>
        /// Removes the patients in queue.
        /// </summary>
        /// <param name="removeRequest">The remove request.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
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
                    .Where(number => number.DepartmentCode == removeRequest.DepartmentCode).ToListAsync();

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
        /// <exception cref="System.Exception"></exception>
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
                //PatientCode = patient.Code,
                PatientId = patient.Id,
                CreatedDate = DateTime.Now,
                CreatedBy = employee.FullName,
                IsSelected = false,
                IsDeleted = false,
                Type = patient.PatientType,
                Number = latestNumber + 1
            };

            _unitOfWork.GetRepository<QueueNumber>().Add(addQueue);
            await _unitOfWork.GetRepository<QueueNumber>().SaveChangesAsync();
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
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(number => number.Code == patientCode);
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
                    PatientHaveRooms = patientHaveRooms.DistinctBy(x => x.DepartmentCode).ToList()
                };
            }
            return new GetRoomPatientResponse();
        }

        /// <summary>
        /// Mappings the list patient in room.
        /// </summary>
        /// <param name="queueNumbers">The queue numbers.</param>
        /// <returns></returns>
        private async Task<List<PatientsInRoomViewModel>> MappingListPatientInRoom(List<QueueNumber> queueNumbers)
        {
            var patientIds = queueNumbers.Select(x => x.PatientId);

            var patients = await _unitOfWork.GetRepository<Patient>().GetAll().Where(x => patientIds.Contains(x.Id)).AsNoTracking().ToListAsync();

            var dicPatients = patients.ToDictionary(patient => patient.Id, patient => patient);

            var tempPatientCodes = patientIds.Except(patients.Select(x => x.Id).ToList());

            var tempPatients = await _unitOfWork.GetRepository<TempPatient>().GetAll().Where(x => tempPatientCodes.Contains(x.Id)).AsNoTracking().ToListAsync();

            var dicTempPatients = tempPatients.ToDictionary(patient => patient.Id, patient => patient);

            List<PatientsInRoomViewModel> patientsInRoom = new List<PatientsInRoomViewModel>();

            foreach (var item in queueNumbers)
            {
                var existedPatient = dicPatients.ContainsKey(item.PatientId);
                var existedTempPatient = dicTempPatients.ContainsKey(item.PatientId);

                if (existedPatient)
                    patientsInRoom.Add(ToPatientsInRoom(dicPatients[item.PatientId], item));
                else if (existedTempPatient)
                    patientsInRoom.Add(ToPatientsInRoom(dicPatients[item.PatientId], item));
            }
            return patientsInRoom;
        }

        /// <summary>
        /// Filters the patienst in room.
        /// </summary>
        /// <param name="request">The room request.</param>
        /// <returns></returns>
        private IQueryable<QueueNumber> FilterPatienstInRoom(GetPatientsInRoomRequest request)
        {
            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == request.DepartmentCode);

            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                var patient = _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefault(p => p.Code == request.PatientCode);

                if (patient != null)
                {
                    queueNumbers = queueNumbers.Where(number => number.PatientId == patient.Id);
                }
            }

            if (!string.IsNullOrEmpty(request.AreaCode))
            {
                queueNumbers = queueNumbers.Where(number => number.AreaCode == request.AreaCode);
            }

            return queueNumbers.AsNoTracking();
        }

        /// <summary>
        /// Converts to patientsinroom.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="queueNumber">The queue number.</param>
        /// <returns></returns>
        private PatientsInRoomViewModel ToPatientsInRoom(Patient patient, QueueNumber queueNumber)
        {
            return new PatientsInRoomViewModel
            {
                AreaCode = queueNumber.AreaCode,
                Birthday = patient.Birthday,
                Gender = patient.Gender,
                PatientCode = patient.Code,
                FullName = $"{patient.LastName} {patient.FirstName}",
                DepartmentCode = queueNumber.DepartmentCode,
                IsCalled = queueNumber.IsSelected,
                Number = queueNumber.Number,
                Type = queueNumber.Type,
                Id = queueNumber.Id,
                CreatedDate = queueNumber.CreatedDate
            };
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

            var code = string.Empty;
            var patientType = PatientType.Normal;
            if (patient == null)
            {
                if (!string.IsNullOrEmpty(request.PatientCode) && request.PatientCode.Length > 9)
                {
                    var tempPatient = await _unitOfWork.GetRepository<TempPatient>().FindAsync(x => x.Code == request.PatientCode);
                    if (tempPatient == null)
                    {
                        throw new Exception(ErrorMessages.NotFoundPatientCode);
                    }
                    patient = _mapper.Map<TempPatient, Patient>(tempPatient);
                }
                else
                {
                    // Find patient in Tekmedi System
                    var response = await _hospitalSystemService.GetRawPatientByCode(new GetRawPatientByCodeRequest
                    {
                        PatientCode = request.PatientCode
                    });

                    if (!string.IsNullOrEmpty(response.PatientCode))
                    {
                        patient = _mapper.Map<Patient>(response);
                        if (patient == null)
                        {
                            throw new Exception(ErrorMessages.NotFoundPatientCode);
                        }

                        _unitOfWork.GetRepository<Patient>().Add(patient);
                    }

                }
            }

            if (patient == null)
            {
                throw new Exception($"Khong tim thay benh nhan {request.PatientCode}");
            }

            code = patient.Code;
            patientType = patient.PatientType;

            if (!string.IsNullOrEmpty(request.DepartmentCode) && request.DepartmentCode != "0")
            {
                var departmentArea = _unitOfWork.GetRepository<ListValue>().GetAll().FirstOrDefault(x => x.Code == request.RoomCode);
                if (departmentArea == null)
                {
                    throw new Exception($"Khong tim thay khoa {request.RoomCode}");
                }

                var realDepartment = _unitOfWork.GetRepository<ListValueExtend>().GetAll().FirstOrDefault(x => x.Code == request.DepartmentCode && x.ListValueId == departmentArea.Id);
                if (realDepartment == null)
                {
                    throw new Exception($"Khong tim thay phong ban {request.DepartmentCode}");
                }

                var departmentGroup = _unitOfWork.GetRepository<DepartmentGroup>().GetAll().FirstOrDefault(x => x.ListValueExtendId == realDepartment.Id);
                if (departmentGroup == null)
                {
                    throw new Exception($"Chua dinh nghia nhomg phong ban cho {realDepartment.Id}");
                }

                var queueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number =>
                              number.PatientId == patient.Id
                              && number.DepartmentExtendId == departmentGroup.DepartmentVirtualId)
                         .OrderByDescending(number => number.Number)
                         .Select(s => s.Number)
                         .FirstOrDefault();

                if (queueNumber <= 0)
                {
                    throw new Exception(ErrorMessages.PatientHasNotTakenNumber);
                }

                var lastNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number =>
                              number.IsSelected
                              && number.DepartmentExtendId == departmentGroup.DepartmentVirtualId)
                         .OrderByDescending(number => number.Number).OrderByDescending(o => o.Number).Select(s => s.Number).FirstOrDefault();

                if (queueNumber > lastNumber)
                {
                    throw new Exception($"Bệnh nhân chưa đến lượt khám. Số thứ tự của phòng khám là {lastNumber}. Số thứ tự của bệnh nhân: {queueNumber} ");
                }
            }
            else
            {
                var table = await _unitOfWork.GetRepository<Table>().GetAll().FirstOrDefaultAsync(x => x.ComputerIP == request.Ip);
                if (table == null)
                {
                    throw new Exception(MessagesCode.TableNotExist);
                }

                var type = table.Type;
                if (patientType == PatientType.Normal && type == CS.Common.Common.PriorityType.Priority)
                {
                    throw new Exception(ErrorMessages.TableTypeIncorrect);
                }

                string areaCode = _hospitalSettings.Hospital.HospitalArea;

                var queueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number =>
                              number.PatientId == patient.Id
                              && number.DepartmentCode == Departments.TNB
                              && number.AreaCode == areaCode
                              && (patientType != PatientType.Normal
                              ? number.Type != PatientType.Normal : number.Type == PatientType.Normal))
                         .OrderByDescending(number => number.Number).FirstOrDefault();

                if (queueNumber == null)
                {
                    throw new Exception(ErrorMessages.PatientHasNotTakenNumber);
                }

                TableCallNumber queue = null;
                int? latestCall = null;
                if (queueNumber.Type == PatientType.Normal)
                {
                    if (areaCode == AreaCode.KBA)
                    {
                        queue = _unitOfWork.GetRepository<KBANormalTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                        latestCall = _unitOfWork.GetRepository<KBANormalTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                    }
                    else
                    {
                        queue = _unitOfWork.GetRepository<KBBNormalTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                        latestCall = _unitOfWork.GetRepository<KBBNormalTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                    }
                }
                else
                {
                    if (areaCode == AreaCode.KBA)
                    {
                        queue = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                        latestCall = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                    }
                    else
                    {
                        queue = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                        latestCall = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                    }

                }

                if (queue == null)
                {
                    throw new Exception($"Bệnh nhân chưa được gọi vào bàn. đang gọi số {latestCall ?? -1}. Số thứ tự của bệnh nhân: {queueNumber.Number} ");
                }
            }

            return _mapper.Map<Patient, CheckInResponse>(patient);
        }

        /// <summary>
        /// Gets the by patient code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public async Task<IEnumerable<QueueNumber>> GetByPatientCode(string code)
        {
            var patient = await _unitOfWork.GetRepository<Patient>()
                .GetAll().SingleOrDefaultAsync(p => p.Code == code);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var queueNumbers = await _unitOfWork.GetRepository<QueueNumber>()
                .GetAll().Where(queue => queue.PatientId == patient.Id
                && queue.DepartmentCode != Constants.Departments.TNB
                && queue.DepartmentCode != Constants.Departments.TATTOAN
                && queue.DepartmentCode != Constants.Departments.THUOCBHYT
                && !queue.IsDeleted).ToListAsync();

            return queueNumbers;
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> GetResult()
        {
            var receptions = await _unitOfWork.GetRepository<Reception>()
                .GetAll().Where(r => DateTime.Compare(DateTime.Now.Date, r.RegisteredDate.Date) == 0
                && r.ClinicStatus == ReceptionClinicStatus.Full).OrderByDescending(x => x.UpdatedDate).ToListAsync();

            return receptions.Select(s => s.Patient);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<QueueNumber>> GenerateClinicResult(QueueNumberPostModel postModel)
        {
            var entity = _mapper.Map<QueueNumber>(postModel);
            var queueNumbers = new List<QueueNumber>();

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(item => item.Id == entity.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var receptions = await _unitOfWork.GetRepository<Reception>().GetAll().Where(item => item.PatientId == patient.Id
            && DateTime.Compare(item.RegisteredDate.Date, DateTime.Now.Date) == 0
            && (item.ClinicStatus == ReceptionClinicStatus.Part || item.ClinicStatus == ReceptionClinicStatus.Full)).ToListAsync();

            if (receptions.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundClinicResult);
            }

            foreach (var reception in receptions)
            {
                var clinics = _unitOfWork.GetRepository<Clinic>().GetAll().Where(item => item.ReceptionId == reception.Id);

                if (reception.ClinicStatus == ReceptionClinicStatus.Part)
                {
                    var serviceCodes = await clinics.Where(c => c.PatientId == patient.Id &&
                                                    c.ClinicType == ClinicType.Clinic)
                                                    .Select(x => x.ServiceId).ToListAsync();

                    var services = _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(x => serviceCodes.Contains(x.Code));

                    var isHasCheckedService = await services.AnyAsync(x => x.IsChecked);
                    if (isHasCheckedService)
                        continue;
                }

                var resultQueueNumber = _mapper.Map<QueueNumber>(postModel);

                var clinic = await clinics.FirstOrDefaultAsync(item => item.ClinicType == ClinicType.Examination);

                if (clinic != null)
                {
                    var departmentCode = postModel.DepartmentCode + "_" + clinic.DepartmentCode;
                    var number = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .FirstOrDefaultAsync(q => q.DepartmentCode == departmentCode
                    && q.PatientId == patient.Id
                    && DateTime.Compare(q.CreatedDate.Date, DateTime.Now.Date) == 0);

                    if (number != null)
                    {
                        queueNumbers.Add(number);
                        continue;
                    }

                    resultQueueNumber.Type = patient.PatientType;
                    resultQueueNumber.DepartmentCode = departmentCode;
                    var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentCode == resultQueueNumber.DepartmentCode);

                    if (resultQueueNumber.Type == PatientType.Normal)
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

                    resultQueueNumber.Number = last != null ? last.Number + 1 : 1;
                    resultQueueNumber.AreaCode = _hospitalSettings.Hospital.HospitalArea;
                    resultQueueNumber.PatientId = patient.Id;
                    var listValue = await _unitOfWork.GetRepository<ListValueExtend>()
                        .GetAll()
                        .SingleOrDefaultAsync(i => i.Code == resultQueueNumber.DepartmentCode);
                    resultQueueNumber.DepartmentExtendId = listValue.Id;

                    _unitOfWork.GetRepository<QueueNumber>().Add(resultQueueNumber);
                    queueNumbers.Add(resultQueueNumber);
                    reception.ClinicStatus = ReceptionClinicStatus.Read;
                }
            }

            await _unitOfWork.CommitAsync();
            return queueNumbers;
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

        private async Task<QueueNumberViewModel> ProcessQueueNumberViewModel(Patient patient, string ip)
        {
            var device = await _unitOfWork.GetRepository<Device>().GetAll().FirstOrDefaultAsync(t => t.Ip == ip);
            var groupCode = patient.Gender == Gender.Female ? GroupCode.Female : GroupCode.Male;
            DayOfWeek day = DateTime.Now.DayOfWeek;

            if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
            {
                groupCode = GroupCode.Male;
            }

            if (_hospitalSettings.Hospital.IsForce)
            {
                groupCode = _hospitalSettings.Hospital.GroupCode;
            }

            var queueNumber = new QueueNumberPostModel();
            queueNumber.DepartmentCode = Departments.TNB;
            queueNumber.PatientId = patient.Id;
            queueNumber.AreaCode = device != null ? device.AreaCode + groupCode : _hospitalSettings.Hospital.HospitalArea + groupCode;

            var queueNumberModel = _mapper.Map<QueueNumber>(queueNumber);
            var queueNumberResultModel = await AddAsync(queueNumberModel);
            var queueNumberViewModel = _mapper.Map<QueueNumberViewModel>(queueNumberResultModel);
            queueNumberViewModel.AreaCode = groupCode;
            return queueNumberViewModel;
        }

        public Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<string> departments)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumber> Generate(Patient patient, string departmentCode, Guid roomId, string registeredCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<QueueNumberTempViewModel>> GetQueueNumberTempByTableCode(GetQueueNumberTempByTableCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CombinePatientAndQueueTempViewModel>> GetSelectedQueueNumberTempByTableCode(GetQueueNumberTempByTableCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public GetLatestNumberResponse GetLatestNumberByDepartment(string deparmentCode)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumberTempViewModel> AddQueueNumberTemp(AddQueueNumberTempRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumberTemp> VerifyQueueTempRequest(VerifyQueueTempRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<CombinePatientAndQueueTempViewModel>> GetTempFromPatientCodeAndType(GetTempFromPatientsByDepartmentCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevertOrderNumber(RevertOrderNumberRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumber> AddNumberChangeRoom(QueueNumberAddModel postModel)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterQueueNumberResponse> RegisterEndoscopicQueueNumber(RegisterEndoscopicQueueNumberRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumber> EndoscopicBoardingRegisterQueueNumber(EndoscopicBoardingRegisterOrderNumberRequest request, Patient model)
        {
            throw new NotImplementedException();
        }

        public ICollection<QueueNumber> GetPatientsInRoomEndoscopic(GetPatientsInEndoscopicRequest request, out int totalRecord, bool isExport)
        {
            throw new NotImplementedException();
        }

        public Task<QueueNumberHistory> AddQueueNumberHistory(QueueNumberHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevertOrderNumberNormalDepartment(RevertOrderNumberNormalDepartmentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterQueueNumberResponse> RePrintQueueNumber(RePrintQueueNumberRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResetQueueNumberResponse> ResetQueueNumber(ResetQueueNumberRequest request)
        {
            throw new NotImplementedException();
        }
    }
}