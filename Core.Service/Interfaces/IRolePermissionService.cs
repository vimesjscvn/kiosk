using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface IRolePermissionService : IService<RolePermission, IRepository<RolePermission>>
    {
        Task<Role> UpdatePermissions(Guid roleId, List<Guid> permissionIds);
    }
}