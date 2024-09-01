using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    public class ListValueTypeService : IListValueTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListValueTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public ListValueType Add(ListValueType entity)
        {
            _unitOfWork.GetRepository<ListValueType>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValueType> AddAsync(ListValueType entity)
        {
            _unitOfWork.GetRepository<ListValueType>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<ListValueType>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<ListValueType>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(ListValueType entity)
        {
            _unitOfWork.GetRepository<ListValueType>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<ListValueType>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(ListValueType entity)
        {
            _unitOfWork.GetRepository<ListValueType>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<ListValueType>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public ListValueType Find(Expression<Func<ListValueType, bool>> match)
        {
            return _unitOfWork.GetRepository<ListValueType>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<ListValueType> FindAll(Expression<Func<ListValueType, bool>> match)
        {
            return _unitOfWork.GetRepository<ListValueType>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<ListValueType>> FindAllAsync(Expression<Func<ListValueType, bool>> match)
        {
            return await _unitOfWork.GetRepository<ListValueType>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValueType> FindAsync(Expression<Func<ListValueType, bool>> match)
        {
            return await _unitOfWork.GetRepository<ListValueType>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public ListValueType Get(Guid id)
        {
            return _unitOfWork.GetRepository<ListValueType>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<ListValueType> GetAll()
        {
            return _unitOfWork.GetRepository<ListValueType>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<ListValueType>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<ListValueType>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValueType> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<ListValueType>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>ListValueType.</returns>
        public ListValueType Update(ListValueType entity, Guid id)
        {
            if (entity == null)
                return null;

            ListValueType existing = _unitOfWork.GetRepository<ListValueType>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<ListValueType>().Update(entity);
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
        /// ListValueType.
        /// </returns>
        public async Task<ListValueType> UpdateAsync(ListValueType entity, Guid id)
        {
            if (entity == null)
                return null;

            ListValueType existing = await _unitOfWork.GetRepository<ListValueType>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<ListValueType>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Gets the list value type by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>ListValueType.</returns>
        public async Task<ListValueType> GetListValueTypeByCode(string code)
        {
            return await _unitOfWork.GetRepository<ListValueType>().FindAsync(x => x.Code == code && x.IsDeleted == false);
        }
    }
}
