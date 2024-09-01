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
using DepartmentGroup.Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Implements
{
    public class GroupService : IGroupService
    {
        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IListValueService _listValueService;

        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TableService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public GroupService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IListValueService listValueService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Get All Department Group
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Group> GetAllGroup(GroupPagingRequest request, out int totalRecord)
        {
            var g = _unitOfWork.GetRepository<Group>().GetAll();

            if (!string.IsNullOrEmpty(request.Description))
                g = g.Where(x => x.Description.ToLower().Contains(request.Description.ToLower()));

            if (!string.IsNullOrEmpty(request.Code))
                g = g.Where(x => x.GroupDeptCode.ToLower().Equals(request.Code.ToLower()));
            totalRecord = g.Count();
            if (request.PageSize > 0)
                g = g.Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize);

            return g.OrderByDescending(x => x.UpdatedDate);
        }

        /// <summary>
        ///     Add Group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Group> AddGroup(GroupRequest request)
        {
            if (string.IsNullOrEmpty(request.GroupCode) || string.IsNullOrEmpty(request.GroupName))
                throw new Exception(ErrorMessages.GroupRequestEmpty);

            var exist = await FindAsync(x => x.GroupDeptCode == request.GroupCode);

            if (exist != null)
                throw new Exception(ErrorMessages.GroupCodeExist);

            var group = await AddAsync(new Group
            {
                GroupDeptCode = request.GroupCode,
                Description = request.GroupName,
                DisplayOrder = 0,
                IsActive = true,
                GroupDeptName = request.GroupName,
                IsDeleted = false
            });

            return group;
        }

        /// <summary>
        ///     Delete Group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Group> DeleteGroup(Guid id)
        {
            var exist = await FindAsync(x => x.Id == id);

            if (exist == null)
                throw new Exception(ErrorMessages.GroupDoNotExists);

            await DeleteAsync(exist);

            var listDepartmentOfGroups = _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>()
                .GetAll().Where(x => x.GroupId == exist.Id).ToList();

            listDepartmentOfGroups.ForEach(x => _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(x));

            await _unitOfWork.CommitAsync();

            return exist;
        }

        /// <summary>
        ///     Update Group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Group> UpdateGroup(Guid id, GroupRequest request)
        {
            var entity = await FindAsync(x => x.Id == id);

            if (entity == null)
                throw new Exception(ErrorMessages.GroupDoNotExists);

            var exist = await FindAsync(x => x.GroupDeptCode == request.GroupCode
                                             && x.Id != id);

            if (exist != null)
                throw new Exception(ErrorMessages.GroupCodeExist);

            entity.GroupDeptCode = request.GroupCode;
            entity.GroupDeptName = request.GroupName;
            entity.Description = request.GroupName;

            Update(entity, id);

            return entity;
        }

        /// <summary>
        ///     Update Department Of Group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Department>> UpdateDepartmentOfGroup(Guid id, DepartmentRequest request)
        {
            if (request == null || request.DepartmentCode.Count == 0)
                throw new Exception(ErrorMessages.DepartmentOfGroupRequestEmpty);

            var group = await FindAsync(x => x.Id == id);

            if (group == null)
                throw new Exception(ErrorMessages.GroupDoNotExists);

            var departmentVirtualId = Guid.Empty;
            if (!string.IsNullOrEmpty(request.DepartmentVirtualCode))
            {
                var departmentVirtual = await _unitOfWork.GetRepository<ListValueExtend>()
                    .FindAsync(x => x.Id == Guid.Parse(request.DepartmentVirtualCode));
                if (departmentVirtual != null) departmentVirtualId = departmentVirtual.Id;
            }

            var listDepartmentOfGroups = _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>()
                .GetAll().Where(x => x.GroupId == id).ToList();

            // Delete all department of group 
            listDepartmentOfGroups.ForEach(x => _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(x));

            // Insert
            var departments = _unitOfWork.GetRepository<Department>()
                .GetAll().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();

            request.DepartmentCode = request.DepartmentCode.Distinct().ToList();
            var results = new List<Department>();
            foreach (var item in request.DepartmentCode)
            {
                var dg = departments.Where(x => x.ListValueExtendId == Guid.Parse(item)).FirstOrDefault();

                if (dg != null)
                {
                    _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Add(new CS.EF.Models.DepartmentGroup
                    {
                        DepartmentId = dg.ListValueExtendId,
                        GroupId = group.Id,
                        GroupCode = group.GroupDeptCode,
                        DepartmentCode = dg.ListValueExtend.Code,
                        DepartmentVirtualId = departmentVirtualId
                    });

                    results.Add(dg);
                }
            }

            await _unitOfWork.CommitAsync();

            return results;
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
        public Group Add(Group entity)
        {
            _unitOfWork.GetRepository<Group>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Group> AddAsync(Group entity)
        {
            _unitOfWork.GetRepository<Group>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Group>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Group>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Group entity)
        {
            _unitOfWork.GetRepository<Group>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Group>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Group entity)
        {
            _unitOfWork.GetRepository<Group>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Group>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Group Find(Expression<Func<Group, bool>> match)
        {
            return _unitOfWork.GetRepository<Group>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Group> FindAll(Expression<Func<Group, bool>> match)
        {
            return _unitOfWork.GetRepository<Group>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Group>> FindAllAsync(Expression<Func<Group, bool>> match)
        {
            return await _unitOfWork.GetRepository<Group>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Group> FindAsync(Expression<Func<Group, bool>> match)
        {
            return await _unitOfWork.GetRepository<Group>().FindAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Group Get(Guid id)
        {
            return _unitOfWork.GetRepository<Group>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Group> GetAll()
        {
            return _unitOfWork.GetRepository<Group>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Group>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Group>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Group> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Group>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Group.</returns>
        public Group Update(Group entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Group>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Group>().Update(entity);
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
        ///     Group.
        /// </returns>
        public async Task<Group> UpdateAsync(Group entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Group>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Group>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion
    }
}