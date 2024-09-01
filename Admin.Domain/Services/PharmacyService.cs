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
    public class PharmacyService : IPharmacyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PharmacyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public Pharmacy Add(Pharmacy entity)
        {
            _unitOfWork.GetRepository<Pharmacy>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Pharmacy> AddAsync(Pharmacy entity)
        {
            _unitOfWork.GetRepository<Pharmacy>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Pharmacy>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Pharmacy>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Pharmacy entity)
        {
            _unitOfWork.GetRepository<Pharmacy>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Pharmacy>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Pharmacy entity)
        {
            _unitOfWork.GetRepository<Pharmacy>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Pharmacy>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Pharmacy Find(Expression<Func<Pharmacy, bool>> match)
        {
            return _unitOfWork.GetRepository<Pharmacy>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Pharmacy> FindAll(Expression<Func<Pharmacy, bool>> match)
        {
            return _unitOfWork.GetRepository<Pharmacy>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Pharmacy>> FindAllAsync(Expression<Func<Pharmacy, bool>> match)
        {
            return await _unitOfWork.GetRepository<Pharmacy>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Pharmacy> FindAsync(Expression<Func<Pharmacy, bool>> match)
        {
            return await _unitOfWork.GetRepository<Pharmacy>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Pharmacy Get(Guid id)
        {
            return _unitOfWork.GetRepository<Pharmacy>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Pharmacy> GetAll()
        {
            return _unitOfWork.GetRepository<Pharmacy>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Pharmacy>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Pharmacy>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Pharmacy> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Pharmacy>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Pharmacy.</returns>
        public Pharmacy Update(Pharmacy entity, Guid id)
        {
            if (entity == null)
                return null;

            Pharmacy existing = _unitOfWork.GetRepository<Pharmacy>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Pharmacy>().Update(entity);
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
        /// Pharmacy.
        /// </returns>
        public async Task<Pharmacy> UpdateAsync(Pharmacy entity, Guid id)
        {
            if (entity == null)
                return null;

            Pharmacy existing = await _unitOfWork.GetRepository<Pharmacy>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Pharmacy>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion

        public async Task<bool> CheckCodeUnique(Guid id, string code)
        {
            Expression<Func<Pharmacy, bool>> checkCodeUnique = m => m.Id != id && m.Code == code;
            Pharmacy existing = await _unitOfWork.GetRepository<Pharmacy>().FindAsync(checkCodeUnique);
            return existing != null;
        }
    }
}
