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
    public class RolePermissionService : IRolePermissionService
    {
        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public RolePermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RolePermission Add(RolePermission entity)
        {
            _unitOfWork.GetRepository<RolePermission>().Add(entity);
            _unitOfWork.GetRepository<RolePermission>().SaveChanges();
            return entity;
        }

        public async Task<RolePermission> AddAsync(RolePermission entity)
        {
            _unitOfWork.GetRepository<RolePermission>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public int Count()
        {
            return _unitOfWork.GetRepository<RolePermission>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<RolePermission>().CountAsync();
        }

        public void Delete(RolePermission entity)
        {
            _unitOfWork.GetRepository<RolePermission>().Delete(entity);
            _unitOfWork.GetRepository<RolePermission>().SaveChanges();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<RolePermission>().Delete(id);
            _unitOfWork.GetRepository<RolePermission>().SaveChanges();
        }

        public async Task<int> DeleteAsync(RolePermission entity)
        {
            _unitOfWork.GetRepository<RolePermission>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<RolePermission>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        public RolePermission Find(Expression<Func<RolePermission, bool>> match)
        {
            return _unitOfWork.GetRepository<RolePermission>().Find(match);
        }

        public ICollection<RolePermission> FindAll(Expression<Func<RolePermission, bool>> match)
        {
            return _unitOfWork.GetRepository<RolePermission>().GetAll().Where(match).ToList();
        }

        public async Task<ICollection<RolePermission>> FindAllAsync(Expression<Func<RolePermission, bool>> match)
        {
            return await _unitOfWork.GetRepository<RolePermission>().GetAll().Where(match).ToListAsync();
        }

        public async Task<RolePermission> FindAsync(Expression<Func<RolePermission, bool>> match)
        {
            return await _unitOfWork.GetRepository<RolePermission>().FindAsync(match);
        }

        public RolePermission Get(Guid id)
        {
            return _unitOfWork.GetRepository<RolePermission>().GetById(id);
        }

        public ICollection<RolePermission> GetAll()
        {
            return _unitOfWork.GetRepository<RolePermission>().GetAll().ToList();
        }

        public async Task<ICollection<RolePermission>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<RolePermission>().GetAll().ToListAsync();
        }

        public async Task<RolePermission> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<RolePermission>().GetAsyncById(id);
        }

        public RolePermission Update(RolePermission entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<RolePermission>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<RolePermission>().Update(entity);
                _unitOfWork.GetRepository<RolePermission>().SaveChanges();
            }

            return existing;
        }

        public async Task<RolePermission> UpdateAsync(RolePermission entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<RolePermission>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<RolePermission>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        public async Task<Role> UpdatePermissions(Guid roleId, List<Guid> permissionIds)
        {
            var rolePermissions =
                await _unitOfWork.GetRepository<RolePermission>().ListAsync(rp => rp.RoleId == roleId, null);
            rolePermissions.ToList().ForEach(ru => _unitOfWork.GetRepository<RolePermission>().Delete(ru));

            permissionIds.ForEach(id =>
            {
                _unitOfWork.GetRepository<RolePermission>().Add(new RolePermission
                {
                    PermissionId = id,
                    RoleId = roleId
                });
            });

            _unitOfWork.GetRepository<RolePermission>().SaveChanges();
            var rolePermission = await _unitOfWork.GetRepository<RolePermission>().GetAll()
                .Include(rp => rp.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(ru => ru.Permission)
                .Include(rp => rp.Role)
                .ThenInclude(r => r.RoleUsers)
                .ThenInclude(ru => ru.SysUser)
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId);
            return rolePermission.Role;
        }
    }
}