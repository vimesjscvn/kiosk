using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.ISurveyResultService" />
    public class SurveyResultService : ISurveyResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SurveyResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public SurveyResult Add(SurveyResult entity)
        {
            _unitOfWork.GetRepository<SurveyResult>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<SurveyResult> AddAsync(SurveyResult entity)
        {
            _unitOfWork.GetRepository<SurveyResult>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<SurveyResult>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<SurveyResult>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(SurveyResult entity)
        {
            _unitOfWork.GetRepository<SurveyResult>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<SurveyResult>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(SurveyResult entity)
        {
            _unitOfWork.GetRepository<SurveyResult>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<SurveyResult>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public SurveyResult Find(Expression<Func<SurveyResult, bool>> match)
        {
            return _unitOfWork.GetRepository<SurveyResult>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<SurveyResult> FindAll(Expression<Func<SurveyResult, bool>> match)
        {
            return _unitOfWork.GetRepository<SurveyResult>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<SurveyResult>> FindAllAsync(Expression<Func<SurveyResult, bool>> match)
        {
            return await _unitOfWork.GetRepository<SurveyResult>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<SurveyResult> FindAsync(Expression<Func<SurveyResult, bool>> match)
        {
            return await _unitOfWork.GetRepository<SurveyResult>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public SurveyResult Get(Guid id)
        {
            return _unitOfWork.GetRepository<SurveyResult>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<SurveyResult> GetAll()
        {
            return _unitOfWork.GetRepository<SurveyResult>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<SurveyResult>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<SurveyResult>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<SurveyResult> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<SurveyResult>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>SurveyResult.</returns>
        public SurveyResult Update(SurveyResult entity, Guid id)
        {
            if (entity == null)
                return null;

            SurveyResult existing = _unitOfWork.GetRepository<SurveyResult>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<SurveyResult>().Update(entity);
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
        /// SurveyResult.
        /// </returns>
        public async Task<SurveyResult> UpdateAsync(SurveyResult entity, Guid id)
        {
            if (entity == null)
                return null;

            SurveyResult existing = await _unitOfWork.GetRepository<SurveyResult>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<SurveyResult>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion
    }
}
