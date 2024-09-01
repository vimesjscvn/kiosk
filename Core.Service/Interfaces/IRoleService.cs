using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface IRoleService : IService<Role, IRepository<Role>>
    {
        Task<bool> isCodeUnique(string code);
    }
}