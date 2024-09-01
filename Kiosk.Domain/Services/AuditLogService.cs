using AutoMapper;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuditLogService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public AuditLog Add(AuditLog entity)
        {
            _unitOfWork.GetRepository<AuditLog>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<AuditLog> AddAsync(AuditLog entity)
        {
            _unitOfWork.GetRepository<AuditLog>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<AuditLog>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<AuditLog>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(AuditLog entity)
        {
            _unitOfWork.GetRepository<AuditLog>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<AuditLog>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(AuditLog entity)
        {
            _unitOfWork.GetRepository<AuditLog>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<AuditLog>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public AuditLog Find(Expression<Func<AuditLog, bool>> match)
        {
            return _unitOfWork.GetRepository<AuditLog>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<AuditLog> FindAll(Expression<Func<AuditLog, bool>> match)
        {
            return _unitOfWork.GetRepository<AuditLog>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<AuditLog>> FindAllAsync(Expression<Func<AuditLog, bool>> match)
        {
            return await _unitOfWork.GetRepository<AuditLog>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<AuditLog> FindAsync(Expression<Func<AuditLog, bool>> match)
        {
            return await _unitOfWork.GetRepository<AuditLog>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public AuditLog Get(Guid id)
        {
            return _unitOfWork.GetRepository<AuditLog>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<AuditLog> GetAll()
        {
            return _unitOfWork.GetRepository<AuditLog>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<AuditLog>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<AuditLog>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<AuditLog> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<AuditLog>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>AuditLog.</returns>
        public AuditLog Update(AuditLog entity, Guid id)
        {
            if (entity == null)
                return null;

            AuditLog existing = _unitOfWork.GetRepository<AuditLog>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<AuditLog>().Update(entity);
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
        /// AuditLog.
        /// </returns>
        public async Task<AuditLog> UpdateAsync(AuditLog entity, Guid id)
        {
            if (entity == null)
                return null;

            AuditLog existing = await _unitOfWork.GetRepository<AuditLog>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<AuditLog>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion
        public async Task<TableResultJsonResponse<AuditLogViewModel>> GetRange(AuditLogRequest request)
        {
            var result = new TableResultJsonResponse<AuditLogViewModel>();
            var predicate = PredicateBuilder.Create<AuditLog>(l => l.UpdatedDate >= request.StartDate && l.UpdatedDate <= request.EndDate);

            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                predicate = predicate.And(l => EF.Functions.JsonExists(l.Data, "Action") &&
                    l.Data.GetProperty("Action").GetString().Contains(request.PatientCode));
            }

            var logs = _unitOfWork.GetRepository<AuditLog>().GetAll().Where(predicate).OrderBy(l => l.UpdatedDate);

            var totalRecord = await logs.CountAsync();
            var data = logs.Skip(request.Start).Take(request.Length).Select(MapAuditLog).ToList();

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data;

            return result;
        }

        public AuditLogViewModel MapAuditLog(AuditLog model)
        {
            dynamic json = JsonConvert.DeserializeObject(model.Data.ToString());
            return new AuditLogViewModel
            {
                Id = model.Id,
                InsertedDate = model.InsertedDate,
                UpdatedDate = model.UpdatedDate,
                TraceId = json.Action.TraceId?.ToString(),
                IpAddress = json.Action.IpAddress?.ToString(),
                RequestUrl = json.Action.RequestUrl?.ToString(),
                HttpMethod = json.Action.HttpMethod?.ToString(),
                ActionName = json.Action.ActionName?.ToString(),
                ControllerName = json.Action.ControllerName?.ToString(),
                ResponseStatus = json.Action.ResponseStatus?.ToString(),
                ResponseStatusCode = json.Action.ResponseStatusCode?.ToString(),
                ActionParameters = json.Action.ActionParameters?.ToString(),
                RequestBody = json.Action.RequestBody?.ToString(),
                ResponseBody = json.Action.ResponseBody?.ToString(),
                Exception = json.Action.Exception?.ToString()
            };
        }
    }
}
