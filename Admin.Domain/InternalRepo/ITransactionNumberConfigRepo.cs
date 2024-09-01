using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.API.Domain.InternalRepo
{
    public interface ITransactionNumberConfigRepo
    {
        Task<TransactionNumberConfig> GetById(Guid id);
        Task<TransactionNumberConfig> GetBySerialNo(string serialNo);
        Task<TransactionNumberConfig> GetOthersAdvancePaymentNumberConfigByUserId(Guid id, Guid userId);
        Task<List<TransactionNumberConfig>> GetListOthersAdvancePaymentNumberConfigByUserId(Guid id, Guid userId);
        Task<TransactionNumberConfig> GetOtherPaymentNumberConfigByUserId(Guid id, Guid userId);
        Task<List<TransactionNumberConfig>> GetListOtherPaymentNumberConfigByUserId(Guid id, Guid userId);
        void Add(TransactionNumberConfig transactionNumberConfig);
        void Delete(TransactionNumberConfig transactionNumberConfig);
        void Update(TransactionNumberConfig transactionNumberConfig);
        Task<List<TransactionNumberConfig>> GetByUserId(Guid userId);
        Task<TransactionNumberConfig> GetOtherRefundNumberConfigByUserId(Guid id, Guid userId);
        Task<List<TransactionNumberConfig>> GetListOtherRefundNumberConfigByUserId(Guid id, Guid userId);
    }
}
