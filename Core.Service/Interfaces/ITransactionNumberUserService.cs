using CS.EF.Models;
using System;
using System.Collections.Generic;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    public interface ITransactionNumberUserService
    {
        List<TransactionNumberUser> GetTransactionNumberUserByUserId(Guid userId);

        TransactionNumberConfig GetPaymentNumberConfig(Guid userId, string patientType);
        // TransactionNumberConfig GetActiveTransactionConfigByType(string type, string patientType);
        TransactionNumberConfig GetNextNumberConfig(TransactionNumberConfig transactionNumberConfig);
        TransactionNumberConfig GetRefundConfig(Guid userId);
    }
}
