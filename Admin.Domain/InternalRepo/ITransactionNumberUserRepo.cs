using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.API.Domain.InternalRepo
{
    public interface ITransactionNumberUserRepo
    {
        Task<List<TransactionNumberUser>> GetByTransactionNumberConfigId(Guid tranactionNumberConfigId);
        void AddTransactionUserNumber(TransactionNumberUser transactionNumberUser);
        Task<TransactionNumberUser> GetByUserIdAndConfigId(Guid userId, Guid configId);
        void RemoveTransactionNumber(TransactionNumberUser transactionNumberUser);
    }
}
