using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace Admin.API.Domain.InternalRepo
{
    public class TransactionNumberConfigRepo : ITransactionNumberConfigRepo
    {
        private IUnitOfWork _unitOfWork;

        public TransactionNumberConfigRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TransactionNumberConfig transactionNumberConfig)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Add(transactionNumberConfig);
        }

        public void Delete(TransactionNumberConfig transactionNumberConfig)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Delete(transactionNumberConfig);
        }

        public async Task<TransactionNumberConfig> GetById(Guid id)
        {
            var transactionNumberConfig = await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().FirstOrDefaultAsync(x => x.Id == id);
            return transactionNumberConfig;
        }

        public async Task<TransactionNumberConfig> GetBySerialNo(string serialNo)
        {
            var transactionNumberConfig = await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().FirstOrDefaultAsync(x => x.SerialNo == serialNo);
            return transactionNumberConfig;
        }


        public async Task<TransactionNumberConfig> GetOtherPaymentNumberConfigByUserId(Guid id, Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll()
                            .FirstOrDefaultAsync(x => x.UserId == userId && x.Type == TransactionNumberConfig.BookTypeTatToan && x.Id != id);
        }

        public async Task<List<TransactionNumberConfig>> GetListOtherPaymentNumberConfigByUserId(Guid id, Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll()
                            .Where(x => x.UserId == userId && x.Type == TransactionNumberConfig.BookTypeTatToan && x.Id != id)
                            .ToListAsync();
        }

        public async Task<TransactionNumberConfig> GetOthersAdvancePaymentNumberConfigByUserId(Guid id, Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().FirstOrDefaultAsync(x => x.UserId == userId
                && x.Type == TransactionNumberConfig.BookTypeTamUng && x.Id != id);
        }

        public async Task<List<TransactionNumberConfig>> GetListOthersAdvancePaymentNumberConfigByUserId(Guid id, Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll()
                .Where(x => x.UserId == userId && x.Type == TransactionNumberConfig.BookTypeTamUng && x.Id != id)
                .ToListAsync();
        }

        public void Update(TransactionNumberConfig transactionNumberConfig)
        {
            _unitOfWork.GetRepository<TransactionNumberConfig>().Update(transactionNumberConfig);
        }

        public async Task<List<TransactionNumberConfig>> GetByUserId(Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<TransactionNumberConfig> GetOtherRefundNumberConfigByUserId(Guid id, Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll()
                .FirstOrDefaultAsync(x => x.UserId == userId
                    && x.Type == TransactionNumberConfig.BookTypeHoanUng && x.Id != id);
        }

        public async Task<List<TransactionNumberConfig>> GetListOtherRefundNumberConfigByUserId(Guid id, Guid userId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll()
                            .Where(x => x.UserId == userId && x.Type == TransactionNumberConfig.BookTypeHoanUng && x.Id != id)
                            .ToListAsync();
        }
    }
}
