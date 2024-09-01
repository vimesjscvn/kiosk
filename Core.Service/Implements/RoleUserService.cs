using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Service.Interfaces;
using Core.UoW;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Implements
{
    public class RoleUserService : IRoleUserService
    {
        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public RoleUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RoleUser Add(RoleUser entity)
        {
            _unitOfWork.GetRepository<RoleUser>().Add(entity);
            _unitOfWork.GetRepository<RoleUser>().SaveChanges();
            return entity;
        }

        public async Task<RoleUser> AddAsync(RoleUser entity)
        {
            _unitOfWork.GetRepository<RoleUser>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public int Count()
        {
            return _unitOfWork.GetRepository<RoleUser>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<RoleUser>().CountAsync();
        }

        public void Delete(RoleUser entity)
        {
            _unitOfWork.GetRepository<RoleUser>().Delete(entity);
            _unitOfWork.GetRepository<RoleUser>().SaveChanges();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<RoleUser>().Delete(id);
            _unitOfWork.GetRepository<RoleUser>().SaveChanges();
        }

        public async Task<int> DeleteAsync(RoleUser entity)
        {
            _unitOfWork.GetRepository<RoleUser>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<RoleUser>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        public RoleUser Find(Expression<Func<RoleUser, bool>> match)
        {
            return _unitOfWork.GetRepository<RoleUser>().Find(match);
        }

        public ICollection<RoleUser> FindAll(Expression<Func<RoleUser, bool>> match)
        {
            return _unitOfWork.GetRepository<RoleUser>().GetAll().Where(match).ToList();
        }

        public async Task<ICollection<RoleUser>> FindAllAsync(Expression<Func<RoleUser, bool>> match)
        {
            return await _unitOfWork.GetRepository<RoleUser>().GetAll().Where(match).ToListAsync();
        }

        public async Task<RoleUser> FindAsync(Expression<Func<RoleUser, bool>> match)
        {
            return await _unitOfWork.GetRepository<RoleUser>().FindAsync(match);
        }

        public RoleUser Get(Guid id)
        {
            return _unitOfWork.GetRepository<RoleUser>().GetById(id);
        }

        public ICollection<RoleUser> GetAll()
        {
            return _unitOfWork.GetRepository<RoleUser>().GetAll().ToList();
        }

        public async Task<ICollection<RoleUser>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<RoleUser>().GetAll().ToListAsync();
        }

        public async Task<RoleUser> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<RoleUser>().GetAsyncById(id);
        }

        public RoleUser Update(RoleUser entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<RoleUser>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<RoleUser>().Update(entity);
                _unitOfWork.GetRepository<RoleUser>().SaveChanges();
            }

            return existing;
        }

        public async Task<RoleUser> UpdateAsync(RoleUser entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<RoleUser>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<RoleUser>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        public async Task<Role> UpdateUsers(Guid roleId, List<Guid> userIds)
        {
            var roleUsers = await _unitOfWork.GetRepository<RoleUser>().ListAsync(ru => ru.RoleId == roleId, null);
            roleUsers.ToList().ForEach(ru => _unitOfWork.GetRepository<RoleUser>().Delete(ru));

            userIds.ForEach(id =>
            {
                roleUsers = _unitOfWork.GetRepository<RoleUser>().GetAll().Where(ru => ru.SysUserId == id);
                roleUsers.ToList().ForEach(ru => _unitOfWork.GetRepository<RoleUser>().Delete(ru));

                _unitOfWork.GetRepository<RoleUser>().Add(new RoleUser
                {
                    SysUserId = id,
                    RoleId = roleId
                });
            });

            _unitOfWork.GetRepository<RoleUser>().SaveChanges();
            var roleUser = await _unitOfWork.GetRepository<RoleUser>().GetAll()
                .Include(ru => ru.Role)
                .ThenInclude(r => r.RoleUsers)
                .ThenInclude(ru => ru.SysUser)
                .Include(ru => ru.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(ru => ru.RoleId == roleId);
            return roleUser?.Role;
        }
    }
}