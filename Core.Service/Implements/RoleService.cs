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
    public class RoleService : IRoleService
    {
        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Role Add(Role entity)
        {
            _unitOfWork.GetRepository<Role>().Add(entity);
            _unitOfWork.GetRepository<Role>().SaveChanges();
            return entity;
        }

        public async Task<Role> AddAsync(Role entity)
        {
            _unitOfWork.GetRepository<Role>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public int Count()
        {
            return _unitOfWork.GetRepository<Role>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Role>().CountAsync();
        }

        public void Delete(Role entity)
        {
            _unitOfWork.GetRepository<Role>().Delete(entity);
            _unitOfWork.GetRepository<Role>().SaveChanges();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Role>().Delete(id);
            _unitOfWork.GetRepository<Role>().SaveChanges();
        }

        public async Task<int> DeleteAsync(Role entity)
        {
            _unitOfWork.GetRepository<Role>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Role>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        public Role Find(Expression<Func<Role, bool>> match)
        {
            return _unitOfWork.GetRepository<Role>().Find(match);
        }

        public ICollection<Role> FindAll(Expression<Func<Role, bool>> match)
        {
            return _unitOfWork.GetRepository<Role>().GetAll().Where(match).ToList();
        }

        public async Task<ICollection<Role>> FindAllAsync(Expression<Func<Role, bool>> match)
        {
            return await _unitOfWork.GetRepository<Role>().GetAll().Where(match).ToListAsync();
        }

        public async Task<Role> FindAsync(Expression<Func<Role, bool>> match)
        {
            return await _unitOfWork.GetRepository<Role>().FindAsync(match);
        }

        public Role Get(Guid id)
        {
            return _unitOfWork.GetRepository<Role>().GetById(id);
        }

        public ICollection<Role> GetAll()
        {
            return _unitOfWork.GetRepository<Role>().GetAll()
                .Include(r => r.RoleUsers)
                .ThenInclude(ru => ru.SysUser)
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .ToList();
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Role>().GetAll()
                .Include(r => r.RoleUsers)
                .ThenInclude(ru => ru.SysUser)
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission).ToListAsync();
        }

        public async Task<Role> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Role>().GetAsyncById(id);
        }

        public Role Update(Role entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Role>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Role>().Update(entity);
                _unitOfWork.GetRepository<Role>().SaveChanges();
            }

            return existing;
        }

        public async Task<Role> UpdateAsync(Role entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Role>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Role>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        public async Task<bool> isCodeUnique(string code)
        {
            var existedRole = await _unitOfWork.GetRepository<Role>().GetAll().FirstOrDefaultAsync(x => x.Code == code);
            return existedRole == null;
        }
    }
}