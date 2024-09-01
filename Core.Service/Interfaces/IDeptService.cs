using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface IDeptService : IService<Department, IRepository<Department>>
    {
    }

    public interface IDeptConfigService : IService<DepartmentConfig, IRepository<DepartmentConfig>>
    {
    }
}