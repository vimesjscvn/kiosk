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
    public class DepartmentGroupService : IDepartmentGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepartmentGroup Add(DepartmentGroup entity)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentGroup> AddAsync(DepartmentGroup entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(DepartmentGroup entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(DepartmentGroup entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public DepartmentGroup Find(Expression<Func<DepartmentGroup, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<DepartmentGroup> FindAll(Expression<Func<DepartmentGroup, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DepartmentGroup>> FindAllAsync(Expression<Func<DepartmentGroup, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentGroup> FindAsync(Expression<Func<DepartmentGroup, bool>> match)
        {
            throw new NotImplementedException();
        }

        public DepartmentGroup Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<DepartmentGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DepartmentGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentGroup> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetDepartmentByGroupCode(string groupCode)
        {
            var group = await _unitOfWork.GetRepository<Group>().FindAsync(x => x.GroupDeptCode == groupCode && !x.IsDeleted);
            if (group == null)
                throw new Exception("Không tồn tại nhóm phòng ban");
            var departmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll().Where(x => x.GroupId == group.Id).ToListAsync();
            var departmentIds = departmentGroup.Select(x => x.ListValueExtendId).ToList().Distinct();
            var departments = await _unitOfWork.GetRepository<Department>().GetAll().Include(x => x.ListValueExtend).Where(x => departmentIds.Contains(x.ListValueExtendId)).ToListAsync();
            return departments;
        }

        public async Task<IEnumerable<DepartmentGroup>> GetDepartmentGroupByCode(string groupCode)
        {
            var group = await _unitOfWork.GetRepository<Group>().FindAsync(x => x.GroupDeptCode == groupCode && !x.IsDeleted);
            if (group == null)
                throw new Exception("Không tồn tại nhóm phòng ban");

            var departmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll().Where(x => x.GroupId == group.Id).ToListAsync();
            return departmentGroup;
        }

        public async Task<ListValueExtend> GetListValueExtendByVirtualId(Guid id)
        {
            var listValueExtend = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(x => x.Id == id);
            if (listValueExtend == null)
                throw new Exception("Không tồn tại list value extend");

            return listValueExtend;
        }

        public DepartmentGroup Update(DepartmentGroup updated, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentGroup> UpdateAsync(DepartmentGroup updated, Guid id)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<TEK.Core.Entities.DepartmentGroup>> GetDepartmentByGroupCode(string groupCode)
        //{
        //    var group = await _unitOfWork.GetRepository<Group>().FindAsync(x => x.Code == groupCode && !x.IsDeleted);

        //    if (group == null)
        //        throw new Exception(ErrorMessages.GroupDoNotExists);

        //    var departments = await _unitOfWork.GetRepository<TEK.Core.Entities.DepartmentGroup>()
        //        .GetAll()
        //        .Where(x => x.GroupId == group.Id)
        //        .ToListAsync();

        //    return departments;
        //}
    }
}
