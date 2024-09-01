using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
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
    public class ListValueService : IListValueService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListValueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public ListValue Add(ListValue entity)
        {
            _unitOfWork.GetRepository<ListValue>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValue> AddAsync(ListValue entity)
        {
            _unitOfWork.GetRepository<ListValue>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<ListValue>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<ListValue>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(ListValue entity)
        {
            _unitOfWork.GetRepository<ListValue>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<ListValue>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(ListValue entity)
        {
            _unitOfWork.GetRepository<ListValue>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<ListValue>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public ListValue Find(Expression<Func<ListValue, bool>> match)
        {
            return _unitOfWork.GetRepository<ListValue>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<ListValue> FindAll(Expression<Func<ListValue, bool>> match)
        {
            return _unitOfWork.GetRepository<ListValue>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<ListValue>> FindAllAsync(Expression<Func<ListValue, bool>> match)
        {
            return await _unitOfWork.GetRepository<ListValue>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValue> FindAsync(Expression<Func<ListValue, bool>> match)
        {
            return await _unitOfWork.GetRepository<ListValue>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public ListValue Get(Guid id)
        {
            return _unitOfWork.GetRepository<ListValue>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<ListValue> GetAll()
        {
            return _unitOfWork.GetRepository<ListValue>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<ListValue>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<ListValue>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValue> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<ListValue>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>ListValue.</returns>
        public ListValue Update(ListValue entity, Guid id)
        {
            if (entity == null)
                return null;

            ListValue existing = _unitOfWork.GetRepository<ListValue>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<ListValue>().Update(entity);
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
        /// ListValue.
        /// </returns>
        public async Task<ListValue> UpdateAsync(ListValue entity, Guid id)
        {
            if (entity == null)
                return null;

            ListValue existing = await _unitOfWork.GetRepository<ListValue>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<ListValue>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Checks the code unique.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> CheckCodeUnique(CheckCodeUniqueRequest requestData)
        {
            return await _unitOfWork.GetRepository<ListValue>().FindAsync(x => x.Code.ToLower() == requestData.Code.ToLower() && x.ListValueTypeId != requestData.Id && !x.IsDeleted) != null;

        }

        /// <summary>
        /// Gets the list values activated.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValue&gt;&gt;.</returns>
        public async Task<IEnumerable<ListValue>> GetListValuesActivated(string code)
        {
            return await _unitOfWork.GetRepository<ListValue>().ListAsync(x => x.ListValueType.Code == code && x.IsActive == true && x.IsDeleted == false, null);
        }

        /// <summary>
        /// Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>IEnumerable&lt;ListValue&gt;.</returns>
        public async Task<IEnumerable<ListValue>> GetAllListValuebyCode(string code)
        {
            return await _unitOfWork.GetRepository<ListValue>().ListAsync(x => x.ListValueType.Code == code && x.IsDeleted == false, null);
        }

        /// <summary>
        /// Gets all list hospital.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ValueHospitalViewModel>> GetAllListHospital()
        {
            return new List<ValueHospitalViewModel>();
        }
    }
}
