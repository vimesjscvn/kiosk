using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface
        IDepartmentGroupService : IService<CS.EF.Models.DepartmentGroup, IRepository<CS.EF.Models.DepartmentGroup>>
    {
        Task<IEnumerable<CS.EF.Models.DepartmentGroup>> GetDepartmentGroupByCode(string groupCode);
        Task<ListValueExtend> GetListValueExtendByVirtualId(Guid id);
        Task<IEnumerable<CS.EF.Models.DepartmentGroup>> GetDepartmentGroupByGroupCode(string groupCode);
        Task<IEnumerable<CS.EF.Models.DepartmentGroup>> GetDepartmentByGroupCode(string groupCode);
    }
}