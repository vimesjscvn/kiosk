using System;
using System.Threading.Tasks;
using CS.EF.Models;

namespace Admin.Domain.InternalRepo
{
    public interface ISysUserRepo
    {
        Task<SysUser> GetUserById(Guid id);
    }
}