using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    public class TransactionNumberConfigService : ITransactionNumberConfigService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionNumberConfigService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TransactionNumberConfig Add(TransactionNumberConfig entity)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public async Task<TransactionNumberConfig> AddAsync(TransactionNumberConfig entity)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public int Count()
        {
            return _unitOfWork.GetRepository<TransactionNumberConfig>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().CountAsync();
        }

        public void Delete(TransactionNumberConfig entity)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Delete(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Delete(id);
            _unitOfWork.Commit();
        }

        public async Task<int> DeleteAsync(TransactionNumberConfig entity)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        public TransactionNumberConfig Find(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            return _unitOfWork.GetRepository<TransactionNumberConfig>().Find(match);
        }

        public ICollection<TransactionNumberConfig> FindAll(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            return _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().Where(match).ToList();
        }

        public async Task<ICollection<TransactionNumberConfig>> FindAllAsync(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().Where(match).ToListAsync();
        }

        public  async Task<TransactionNumberConfig> FindAsync(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().FindAsync(match);
        }

        public TransactionNumberConfig Get(Guid id)
        {
            return _unitOfWork.GetRepository<TransactionNumberConfig>().GetById(id);
        }

        public ICollection<TransactionNumberConfig> GetAll()
        {
            return _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().ToList();
        }

        public async Task<ICollection<TransactionNumberConfig>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().ToListAsync();
        }

        public async Task<TransactionNumberConfig> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAsyncById(id);
        }

        public TransactionNumberConfig Update(TransactionNumberConfig entity, Guid id)
        {
            if (entity == null)
                return null;

            TransactionNumberConfig existing = _unitOfWork.GetRepository<TransactionNumberConfig>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TransactionNumberConfig>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        public async Task<TransactionNumberConfig> UpdateAsync(TransactionNumberConfig entity, Guid id)
        {
            if (entity == null)
                return null;

            TransactionNumberConfig existing = await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TransactionNumberConfig>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
    }
}
