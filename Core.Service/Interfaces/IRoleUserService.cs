using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface IRoleUserService : IService<RoleUser, IRepository<RoleUser>>
    {
        Task<Role> UpdateUsers(Guid roleId, List<Guid> userIds);
    }
}