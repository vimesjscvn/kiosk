using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Implements
{
    public class DepartmentGroupService : IDepartmentGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CS.EF.Models.DepartmentGroup>> GetDepartmentGroupByCode(string groupCode)
        {
            var group = await _unitOfWork.GetRepository<Group>()
                .FindAsync(x => x.GroupDeptCode == groupCode && !x.IsDeleted);
            if (group == null)
                throw new Exception("Không tồn tại nhóm phòng ban");

            var departmentGroup = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll()
                .Where(x => x.GroupId == group.Id).ToListAsync();
            return departmentGroup;
        }

        public async Task<ListValueExtend> GetListValueExtendByVirtualId(Guid id)
        {
            var listValueExtend = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(x => x.Id == id);
            if (listValueExtend == null)
                throw new Exception("Không tồn tại list value extend");

            return listValueExtend;
        }

        /// <summary>
        ///     Get Department By Group Code
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CS.EF.Models.DepartmentGroup>> GetDepartmentGroupByGroupCode(string groupCode)
        {
            var group = await _unitOfWork.GetRepository<Group>()
                .FindAsync(x => x.GroupDeptCode == groupCode && !x.IsDeleted);

            if (group == null)
                throw new Exception(ErrorMessages.GroupDoNotExists);

            var departments = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>()
                .GetAll()
                .Where(x => x.GroupId == group.Id)
                .ToListAsync();

            return departments;
        }

        /// <summary>
        ///     Get Department By Group Code
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CS.EF.Models.DepartmentGroup>> GetDepartmentByGroupCode(string groupCode)
        {
            var group = await _unitOfWork.GetRepository<Group>()
                .FindAsync(x => x.GroupDeptCode == groupCode && !x.IsDeleted);

            if (group == null)
                throw new Exception(ErrorMessages.GroupDoNotExists);

            var departments = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>()
                .GetAll()
                .Where(x => x.GroupId == group.Id)
                .ToListAsync();

            return departments;
        }

        #region Default Service

        /// <summary>
        ///     Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public CS.EF.Models.DepartmentGroup Add(CS.EF.Models.DepartmentGroup entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<CS.EF.Models.DepartmentGroup> AddAsync(CS.EF.Models.DepartmentGroup entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(CS.EF.Models.DepartmentGroup entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(CS.EF.Models.DepartmentGroup entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public CS.EF.Models.DepartmentGroup Find(Expression<Func<CS.EF.Models.DepartmentGroup, bool>> match)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<CS.EF.Models.DepartmentGroup> FindAll(
            Expression<Func<CS.EF.Models.DepartmentGroup, bool>> match)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<CS.EF.Models.DepartmentGroup>> FindAllAsync(
            Expression<Func<CS.EF.Models.DepartmentGroup, bool>> match)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<CS.EF.Models.DepartmentGroup> FindAsync(
            Expression<Func<CS.EF.Models.DepartmentGroup, bool>> match)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().FindAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public CS.EF.Models.DepartmentGroup Get(Guid id)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<CS.EF.Models.DepartmentGroup> GetAll()
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<CS.EF.Models.DepartmentGroup>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<CS.EF.Models.DepartmentGroup> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>CS.EF.Models.DepartmentGroupEntity.</returns>
        public CS.EF.Models.DepartmentGroup Update(CS.EF.Models.DepartmentGroup entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Update(entity);
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
        ///     CS.EF.Models.DepartmentGroupEntity.
        /// </returns>
        public async Task<CS.EF.Models.DepartmentGroup> UpdateAsync(CS.EF.Models.DepartmentGroup entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion
    }
}