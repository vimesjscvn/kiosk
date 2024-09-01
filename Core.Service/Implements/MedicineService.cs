using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Service.Interfaces;
using Core.UoW;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Implements
{
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckCodeUnique(Guid id, string code)
        {
            Expression<Func<Medicine, bool>> checkCodeUnique = m => m.Id != id && m.Code == code;
            var existing = await _unitOfWork.GetRepository<Medicine>().FindAsync(checkCodeUnique);
            return existing != null;
        }

        #region Default Service

        /// <summary>
        ///     Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public Medicine Add(Medicine entity)
        {
            _unitOfWork.GetRepository<Medicine>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Medicine> AddAsync(Medicine entity)
        {
            _unitOfWork.GetRepository<Medicine>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Medicine>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Medicine>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Medicine entity)
        {
            _unitOfWork.GetRepository<Medicine>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Medicine>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Medicine entity)
        {
            _unitOfWork.GetRepository<Medicine>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Medicine>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Medicine Find(Expression<Func<Medicine, bool>> match)
        {
            return _unitOfWork.GetRepository<Medicine>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Medicine> FindAll(Expression<Func<Medicine, bool>> match)
        {
            return _unitOfWork.GetRepository<Medicine>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Medicine>> FindAllAsync(Expression<Func<Medicine, bool>> match)
        {
            return await _unitOfWork.GetRepository<Medicine>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Medicine> FindAsync(Expression<Func<Medicine, bool>> match)
        {
            return await _unitOfWork.GetRepository<Medicine>().FindAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Medicine Get(Guid id)
        {
            return _unitOfWork.GetRepository<Medicine>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Medicine> GetAll()
        {
            return _unitOfWork.GetRepository<Medicine>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Medicine>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Medicine>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Medicine> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Medicine>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Medicine.</returns>
        public Medicine Update(Medicine entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Medicine>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Medicine>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        ///     update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     Medicine.
        /// </returns>
        public async Task<Medicine> UpdateAsync(Medicine entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Medicine>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Medicine>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion
    }
}