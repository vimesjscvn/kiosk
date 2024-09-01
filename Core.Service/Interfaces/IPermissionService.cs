using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface IPermissionService : IService<Permission, IRepository<Permission>>
    {
    }
}