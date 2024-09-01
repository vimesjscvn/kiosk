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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    /// <summary>
    ///     Class ReceptionService.
    ///     Implements the <see cref="CS.Abstractions.IServices.IReceptionService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IReceptionService" />
    public class ReceptionService : IReceptionService
    {
        /// <summary>
        ///     The advance payment service
        /// </summary>
        private readonly IExaminationService _examinationService;

        /// <summary>
        ///     Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReceptionService" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public ReceptionService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            IExaminationService examinationService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _examinationService = examinationService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets all reception.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<ReceptionReportViewModel>> GetAllReception(ReceptionRequest request)
        {
            var receptions = GetReceptionFillter(request);

            var result = new TableResultJsonResponse<ReceptionReportViewModel>();

            var totalRecord = await receptions.CountAsync();

            var response = await receptions.Skip(request.Start).Take(request.Length)
                .OrderByDescending(x => x.RegisteredDate).ToListAsync();

            var data = _mapper.Map<List<ReceptionReportViewModel>>(response);

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data;
            return result;
        }

        /// <summary>
        ///     Exports the reception.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<List<ReceptionReportViewModel>> ExportReception(ReceptionRequest request)
        {
            var receptions = GetReceptionFillter(request);

            var result = await receptions.OrderByDescending(x => x.CreatedBy).ToListAsync();

            return _mapper.Map<List<ReceptionReportViewModel>>(result);
        }

        /// <summary>
        ///     Changes the finished.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<bool> ChangeFinished(ChangeFinishedRequest request)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(x => x.Id == request.Id);

            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == request.EmployeeId);
            if (employee == null)
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);

            if (request.IsFinished.HasValue)
                reception.IsFinished = request.IsFinished.Value;

            var receptionHistory = new History
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

        /// <summary>
        ///     Gets all reason change.
        /// </summary>
        /// <param name="receptionId">The reception identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Gets the reception fillter.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private IQueryable<Reception> GetReceptionFillter(ReceptionRequest request)
        {
            var receptions = _unitOfWork.GetRepository<Reception>().GetAll().Where(x =>
                x.RegisteredDate >= request.StartDate && x.RegisteredDate <= request.EndDate);

            if (!string.IsNullOrWhiteSpace(request.PatientCode))
                receptions = receptions.Where(x => x.PatientCode == request.PatientCode);

            if (!string.IsNullOrWhiteSpace(request.PatientName))
                receptions = receptions.Where(x =>
                    x.Patient.FirstName != null &&
                    x.Patient.FirstName.ToLower().Contains(request.PatientName.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                int.TryParse(request.Status, out var status);
                receptions = receptions.Where(x => x.Status == (ReceptionStatus)status);
            }

            return receptions;
        }

        #region Default Service

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Reception.</returns>
        public Reception Add(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Add(entity);
            _unitOfWork.GetRepository<Reception>().SaveChanges();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
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
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Reception>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Reception>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Delete(entity);
            _unitOfWork.GetRepository<Reception>().SaveChanges();
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Reception>().Delete(id);
            _unitOfWork.GetRepository<Reception>().SaveChanges();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Reception entity)
        {
            _unitOfWork.GetRepository<Reception>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Reception>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Reception.</returns>
        public Reception Find(Expression<Func<Reception, bool>> match)
        {
            return _unitOfWork.GetRepository<Reception>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public ICollection<Reception> FindAll(Expression<Func<Reception, bool>> match)
        {
            return _unitOfWork.GetRepository<Reception>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public async Task<ICollection<Reception>> FindAllAsync(Expression<Func<Reception, bool>> match)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> FindAsync(Expression<Func<Reception, bool>> match)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public Reception Get(Guid id)
        {
            return _unitOfWork.GetRepository<Reception>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public ICollection<Reception> GetAll()
        {
            return _unitOfWork.GetRepository<Reception>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Reception&gt;.</returns>
        public async Task<ICollection<Reception>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public Reception Update(Reception entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Reception>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Reception>().Update(entity);
                _unitOfWork.GetRepository<Reception>().SaveChanges();
            }

            return existing;
        }

        /// <summary>
        ///     update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Reception.</returns>
        public async Task<Reception> UpdateAsync(Reception entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Reception>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Reception>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        /// <summary>
        ///     Gets the or add if not existed.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="clinic">The clinic.</param>
        public async Task<Reception> GetOrAddIfNotExisted(GetOrAddIfNotExistedData data)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().GetAll().SingleOrDefaultAsync(r =>
                r.PatientCode == data.PatientCode
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
        ///     Gets the registered code list by patient.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public async Task<ICollection<Reception>> GetRegisteredCodeListByPatient(string code)
        {
            return await _unitOfWork.GetRepository<Reception>().GetAll().Where(r => r.PatientCode == code)
                .OrderByDescending(o => o.RegisteredDate).ToListAsync();
        }

        #endregion
    }
}