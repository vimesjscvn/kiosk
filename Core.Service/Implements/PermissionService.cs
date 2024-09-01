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
    public class PermissionService : IPermissionService
    {
        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Permission Add(Permission entity)
        {
            _unitOfWork.GetRepository<Permission>().Add(entity);
            _unitOfWork.GetRepository<Permission>().SaveChanges();
            return entity;
        }

        public async Task<Permission> AddAsync(Permission entity)
        {
            _unitOfWork.GetRepository<Permission>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public int Count()
        {
            return _unitOfWork.GetRepository<Permission>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Permission>().CountAsync();
        }

        public void Delete(Permission entity)
        {
            _unitOfWork.GetRepository<Permission>().Delete(entity);
            _unitOfWork.GetRepository<Permission>().SaveChanges();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Permission>().Delete(id);
            _unitOfWork.GetRepository<Permission>().SaveChanges();
        }

        public async Task<int> DeleteAsync(Permission entity)
        {
            _unitOfWork.GetRepository<Permission>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Permission>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        public Permission Find(Expression<Func<Permission, bool>> match)
        {
            return _unitOfWork.GetRepository<Permission>().Find(match);
        }

        public ICollection<Permission> FindAll(Expression<Func<Permission, bool>> match)
        {
            return _unitOfWork.GetRepository<Permission>().GetAll().Where(match).ToList();
        }

        public async Task<ICollection<Permission>> FindAllAsync(Expression<Func<Permission, bool>> match)
        {
            return await _unitOfWork.GetRepository<Permission>().GetAll().Where(match).ToListAsync();
        }

        public async Task<Permission> FindAsync(Expression<Func<Permission, bool>> match)
        {
            return await _unitOfWork.GetRepository<Permission>().FindAsync(match);
        }

        public Permission Get(Guid id)
        {
            return _unitOfWork.GetRepository<Permission>().GetById(id);
        }

        public ICollection<Permission> GetAll()
        {
            return _unitOfWork.GetRepository<Permission>().GetAll().ToList();
        }

        public async Task<ICollection<Permission>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Permission>().GetAll().ToListAsync();
        }

        public async Task<Permission> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Permission>().GetAsyncById(id);
        }

        public Permission Update(Permission entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Permission>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Permission>().Update(entity);
                _unitOfWork.GetRepository<Permission>().SaveChanges();
            }

            return existing;
        }

        public async Task<Permission> UpdateAsync(Permission entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Permission>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Permission>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
    }
}