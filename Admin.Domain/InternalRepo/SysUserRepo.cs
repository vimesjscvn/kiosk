using System;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Admin.Domain.InternalRepo
{
    public class SysUserRepo : ISysUserRepo
    {
        private readonly IUnitOfWork _unitOfWork;

        public SysUserRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SysUser> GetUserById(Guid id)
        {
            return await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == id);
        }
    }
}