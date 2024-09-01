using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Adapters;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Implements
{
    public class SysUserService : IUserService
    {
        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public SysUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SysUser Add(SysUser entity)
        {
            _unitOfWork.GetRepository<SysUser>().Add(entity);
            _unitOfWork.GetRepository<SysUser>().SaveChanges();
            return entity;
        }

        public async Task<SysUser> AddAsync(SysUser entity)
        {
            _unitOfWork.GetRepository<SysUser>().Add(entity);
            await _unitOfWork.CommitAsync();
            ;
            return entity;
        }

        public int Count()
        {
            return _unitOfWork.GetRepository<SysUser>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<SysUser>().CountAsync();
        }

        public void Delete(SysUser entity)
        {
            _unitOfWork.GetRepository<SysUser>().Delete(entity);
            _unitOfWork.GetRepository<SysUser>().SaveChanges();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<SysUser>().Delete(id);
            _unitOfWork.GetRepository<SysUser>().SaveChanges();
        }

        public async Task<int> DeleteAsync(SysUser entity)
        {
            _unitOfWork.GetRepository<SysUser>().Delete(entity);
            return await _unitOfWork.CommitAsync();
            ;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<SysUser>().Delete(id);
            return await _unitOfWork.CommitAsync();
            ;
        }

        public SysUser Find(Expression<Func<SysUser, bool>> match)
        {
            return _unitOfWork.GetRepository<SysUser>().Find(match);
        }

        public ICollection<SysUser> FindAll(Expression<Func<SysUser, bool>> match)
        {
            return _unitOfWork.GetRepository<SysUser>().GetAll().Where(match).ToList();
        }

        public async Task<ICollection<SysUser>> FindAllAsync(Expression<Func<SysUser, bool>> match)
        {
            return await _unitOfWork.GetRepository<SysUser>().GetAll().Where(match).ToListAsync();
        }

        public async Task<SysUser> FindAsync(Expression<Func<SysUser, bool>> match)
        {
            return await _unitOfWork.GetRepository<SysUser>().FindAsync(match);
        }

        public SysUser Get(Guid id)
        {
            return _unitOfWork.GetRepository<SysUser>().GetById(id);
        }

        public ICollection<SysUser> GetAll()
        {
            return _unitOfWork.GetRepository<SysUser>().GetAll().ToList();
        }

        public async Task<ICollection<SysUser>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<SysUser>().GetAll().ToListAsync();
        }

        public async Task<SysUser> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<SysUser>().GetAsyncById(id);
        }

        public SysUser Update(SysUser entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<SysUser>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<SysUser>().Update(entity);
                _unitOfWork.GetRepository<SysUser>().SaveChanges();
            }

            return existing;
        }

        public async Task<SysUser> UpdateAsync(SysUser entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<SysUser>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<SysUser>().Update(entity);
                await _unitOfWork.CommitAsync();
                ;
            }

            return existing;
        }

        public async Task<TableResultJsonResponse<SysUserViewModel>> GetAll(DataTableParameters parameters)
        {
            if (parameters == null) return null;

            var result = new TableResultJsonResponse<SysUserViewModel>();

            var users = _unitOfWork.GetRepository<SysUser>().GetAll().OrderBy(l => l.Code);

            var totalRecord = users.Count();
            var userModels = parameters.Length > 0
                ? await users.Skip(parameters.Start).Take(parameters.Length).ToListAsync()
                : await users.ToListAsync();
            var userViewModels = new List<SysUserViewModel>();

            foreach (var user in userModels) userViewModels.Add(DataAdapter.ToViewModel(user));

            result.Draw = parameters.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = userViewModels;

            return result;
        }

        public async Task<bool> CheckUserNameUnique(CheckUserNameUniqueRequest requestData)
        {
            return await _unitOfWork.GetRepository<SysUser>().GetAll()
                .Where(x => x.UserName.ToLower() == requestData.UserName.ToLower() && x.Id != requestData.Id)
                .FirstOrDefaultAsync() != null
                ? true
                : false;
        }

        public async Task<bool> CheckCodeUnique(CheckCodeUniqueRequest requestData)
        {
            return await _unitOfWork.GetRepository<SysUser>().GetAll()
                .Where(x => x.Code.ToLower() == requestData.Code.ToLower() && x.Id != requestData.Id)
                .FirstOrDefaultAsync() != null
                ? true
                : false;
        }

        public async Task<SysUser> GetToken(GetTokenRequest request)
        {
            var hashPassword = PasswordSecurityHelper.GetHashedPassword(request.Password);

            var user = await _unitOfWork.GetRepository<SysUser>().GetAll().Where(u =>
                    u.UserName == request.UserName && u.Password == hashPassword && u.IsActive && !u.IsDeleted)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Tài khoản hay mật khẩu không hợp lệ");
            }

            user.Token = "U_" + TokenSecurityHelper
                .GenerateToken(request.UserName, request.Password, "120.0.0.1", "", DateTime.Now.Ticks)
                .Replace('=', 'U');
            user.TokenExp = DateTime.Now.AddDays(1);
            user.LastLogin = DateTime.Now;

            _unitOfWork.GetRepository<SysUser>().Update(user);
            await _unitOfWork.CommitAsync();
            ;

            return user;
        }

        public async Task<bool> CheckPassword(CheckPasswordRequest request)
        {
            var hashPassword = PasswordSecurityHelper.GetHashedPassword(request.Password);

            var user = await _unitOfWork.GetRepository<SysUser>().GetAll().Where(u =>
                    u.UserName == request.UserName && u.Password == hashPassword && u.IsActive && !u.IsDeleted)
                .FirstOrDefaultAsync();
            return user != null;
        }

        public async Task<bool> CheckEmail(CheckEmailRequest request)
        {
            var user = await _unitOfWork.GetRepository<SysUser>().GetAll()
                .Where(u => u.Email == request.Email && u.IsActive && !u.IsDeleted).FirstOrDefaultAsync();
            return user != null;
        }

        public async Task<SysUser> SendEmail(SendEmailRequest request)
        {
            var user = await _unitOfWork.GetRepository<SysUser>().GetAll()
                .Where(u => u.Email == request.ToEmail && u.IsActive && !u.IsDeleted).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Email không tồn tại trong hệ thống");
            }

            user.Token = "U_" + TokenSecurityHelper
                .GenerateToken(user.UserName, user.Password, "120.0.0.1", "", DateTime.Now.Ticks).Replace('=', 'U');
            user.TokenExp = DateTime.Now.AddMinutes(15);

            _unitOfWork.GetRepository<SysUser>().Update(user);
            await _unitOfWork.CommitAsync();

            var link = request.Link + "?token=" + user.Token;

            var client = new SmtpClient();
            client.Host = request.Host;
            client.Port = request.Post;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(request.FromEmail, request.PassFromEmail);

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(request.FromEmail);
            mailMessage.To.Add(request.ToEmail);
            mailMessage.Body = "Vào link bên dưới để tạo lại mật khẩu (link sẽ hết hạn trong 15 phút)";
            mailMessage.Body += Environment.NewLine + link;
            mailMessage.Subject = "Cấp lại mật khẩu Chợ Rẫy Hospital";
            client.Send(mailMessage);

            return user;
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _unitOfWork.GetRepository<SysUser>().GetAll()
                .Where(u => u.Token == request.Token && u.IsActive && !u.IsDeleted).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Không tìm thấy người dùng để cập nhật");
            }

            if (user.TokenExp < DateTime.Now) throw new Exception("Token đã hết hạn");

            user.Password = PasswordSecurityHelper.GetHashedPassword(request.Password);
            user.TokenExp = DateTime.Now;

            _unitOfWork.GetRepository<SysUser>().Update(user);
            await _unitOfWork.CommitAsync();
            ;

            return true;
        }
    }
}