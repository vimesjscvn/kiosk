using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using DepartmentGroup.Domain.Models.Requests;

namespace Core.Service.Interfaces
{
    public interface IGroupService : IService<Group, IRepository<Group>>
    {
        IEnumerable<Group> GetAllGroup(GroupPagingRequest request, out int totalRecord);

        Task<Group> AddGroup(GroupRequest request);

        Task<Group> UpdateGroup(Guid id, GroupRequest request);

        Task<IEnumerable<Department>> UpdateDepartmentOfGroup(Guid id, DepartmentRequest request);

        Task<Group> DeleteGroup(Guid id);
    }
}