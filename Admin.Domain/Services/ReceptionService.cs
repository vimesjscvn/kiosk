// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ReceptionService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    /// <summary>
    /// Class ReceptionService.
    /// Implements the <see cref="CS.Abstractions.IServices.IReceptionService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IReceptionService" />
    public class ReceptionService : IReceptionService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceptionService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public ReceptionService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Reception.</returns>
        public Reception Add(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> AddAsync(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Reception>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Reception>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Reception>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Reception>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Reception.</returns>
        public Reception Find(Expression<Func<Reception, bool>> match)
        {
            return _unitOfWork.GetRepository<Reception>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public ICollection<Reception> FindAll(Expression<Func<Reception, bool>> match)
        {
            return _unitOfWork.GetRepository<Reception>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public async Task<ICollection<Reception>> FindAllAsync(Expression<Func<Reception, bool>> match)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> FindAsync(Expression<Func<Reception, bool>> match)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public Reception Get(Guid id)
        {
            return _unitOfWork.GetRepository<Reception>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public ICollection<Reception> GetAll()
        {
            return _unitOfWork.GetRepository<Reception>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public async Task<ICollection<Reception>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public Reception Update(Reception entity, Guid id)
        {
            if (entity == null)
                return null;

            Reception existing = _unitOfWork.GetRepository<Reception>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Reception>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> UpdateAsync(Reception entity, Guid id)
        {
            if (entity == null)
                return null;

            Reception existing = await _unitOfWork.GetRepository<Reception>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Reception>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        /// <summary>
        /// Gets the or add if not existed.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="clinic">The clinic.</param>
        public async Task<Reception> GetOrAddIfNotExisted(GetOrAddIfNotExistedData data)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().GetAll().SingleOrDefaultAsync(r => r.PatientCode == data.PatientCode
            && r.RegisteredCode == data.RegisteredCode);
            if (reception == null)
            {
                reception = new Reception
                {
                    PatientCode = data.PatientCode,
                    PatientId = data.PatientId,
                    PatientType = data.PatientType,
                    RegisteredCode = data.RegisteredCode,
                    RegisteredDate = data.RegisteredDate,
                    Status = ReceptionStatus.Success,
                    Type = ReceptionType.New,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now
                };
                _unitOfWork.GetRepository<Reception>().Add(reception);
                await _unitOfWork.CommitAsync();
            }

            return reception;
        }

        /// <summary>
        /// Gets the registered code list by patient.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public async Task<ICollection<Reception>> GetRegisteredCodeListByPatient(string code)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().Where(r => r.PatientCode == code).ToListAsync();
        }

        #endregion
        public async Task<TableResultJsonResponse<ReceptionReportViewModel>> GetAllReception(ReceptionRequest request)
        {
            var receptions = GetReceptionFillter(request);

            var result = new TableResultJsonResponse<ReceptionReportViewModel>();

            var totalRecord = receptions.Count();

            var response = receptions.Skip(request.Start).Take(request.Length).OrderByDescending(x => x.RegisteredDate).ToList();

            var data = _mapper.Map<List<ReceptionReportViewModel>>(response);

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data;
            return result;
        }

        public async Task<List<ReceptionReportViewModel>> ExportReception(ReceptionRequest request)
        {
            var receptions = GetReceptionFillter(request);

            var result = receptions.OrderByDescending(x => x.CreatedBy).ToList();

            return _mapper.Map<List<ReceptionReportViewModel>>(result);
        }

        public async Task<bool> ChangeFinished(ChangeFinishedRequest request)
        {
            Reception reception = await _unitOfWork.GetRepository<Reception>().FindAsync(x => x.Id == request.Id);

            if (reception == null)
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);

            if (reception.IsFinished)
            {
                throw new Exception(ErrorMessages.CanNotChangeIsFinished);
            }
            else
            {
                var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == request.EmployeeId);
                if (employee == null)
                    throw new Exception(ErrorMessages.NotFoundEmployeeCode);

                if (request.IsFinished.HasValue)
                    reception.IsFinished = request.IsFinished.Value;

                History receptionHistory = new History
                {
                    Reason = request.Reason,
                    HistoryId = reception.Id,
                    Type = HistoryType.Reception,
                    CreatedBy = employee.FullName,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = employee.FullName,
                    UpdatedDate = DateTime.Now,
                    EmployeeId = employee.Id,
                    Employee = employee
                };

                _unitOfWork.GetRepository<History>().Add(receptionHistory);
                _unitOfWork.GetRepository<Reception>().Update(reception);
                await _unitOfWork.CommitAsync();
                return true;
            }
        }

        public async Task<ReceptionHistoryResponse> GetAllReasonChange(Guid receptionId)
        {
            var receptionHistories = await _unitOfWork.GetRepository<History>().GetAll()
                .Where(x => x.HistoryId == receptionId)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return new ReceptionHistoryResponse
            {
                ReceptionHistories = receptionHistories
            };
        }

        private IEnumerable<Reception> GetReceptionFillter(ReceptionRequest request)
        {
            var receptions = _unitOfWork.GetRepository<Reception>()
                .GetAll()
                .Include(x => x.Patient)
                .Where(x => x.RegisteredDate.Date >= request.StartDate.Date && x.RegisteredDate.Date <= request.EndDate.Date);

            if (!string.IsNullOrWhiteSpace(request.PatientCode))
            {
                receptions = receptions.Where(x => x.PatientCode == request.PatientCode);
            }

            if (!string.IsNullOrWhiteSpace(request.PatientName))
            {
                receptions = receptions.Where(x => (x.Patient.LastName.ToLower() + " " + x.Patient.FirstName.ToLower()).Contains(request.PatientName.Trim().ToLower()));
            }

            if (request.Type.HasValue)
            {
                var requestType = (int)request.Type;
                receptions = receptions.Where(x => (int)x.Type == requestType);
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                receptions = receptions.Where(x => x.RegisteredCode == request.RegisteredCode);
            }

            return receptions.ToList();
        }

        public async Task<Reception> GetByPatientAndReceptionCode(string patientCode, string registeredCode)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == patientCode);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            return await _unitOfWork.GetRepository<Reception>().FindAsync(x => x.PatientId == patient.Id && x.RegisteredCode == registeredCode);
        }

        public List<Reception> GetReceptionByPatientAndRegisteredCode(string patientCode, List<string> registeredCode)
        {
            var patient = _unitOfWork.GetRepository<Patient>().Find(x => x.Code == patientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            var reception = _unitOfWork.GetRepository<Reception>().GetAll().Where(x => x.PatientId == patient.Id && registeredCode.Contains(x.RegisteredCode)).ToList();
            if (reception == null || reception.Count <= 0)
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            return reception;
        }

        public Task<ICollection<Reception>> SyncRegisteredCodeListByPatient(Patient patientInfo)
        {
            throw new NotImplementedException();
        }

        public Task<Reception> GetReceptionHaveOrder(Reception item)
        {
            throw new NotImplementedException();
        }

        public Task<Reception> GetFee(string patientCode, string code)
        {
            throw new NotImplementedException();
        }
    }
}
