using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface IUserService : IService<SysUser, IRepository<SysUser>>
    {
        Task<TableResultJsonResponse<SysUserViewModel>> GetAll(DataTableParameters parameters);
        Task<SysUser> GetToken(GetTokenRequest request);
        Task<bool> CheckPassword(CheckPasswordRequest requestData);
        Task<bool> CheckEmail(CheckEmailRequest requestData);
        Task<SysUser> SendEmail(SendEmailRequest requestData);
        Task<bool> ResetPassword(ResetPasswordRequest requestData);
        Task<bool> CheckUserNameUnique(CheckUserNameUniqueRequest requestData);
        Task<bool> CheckCodeUnique(CheckCodeUniqueRequest requestData);
    }
}