using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    public class TransactionNumberUserService : ITransactionNumberUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionNumberUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TransactionNumberUser> GetTransactionNumberUserByUserId(Guid userId)
        {
            return _unitOfWork.GetRepository<TransactionNumberUser>().GetAll().Where(x => x.UserId == userId).ToList();
        }

        public TransactionNumberConfig GetActiveTransactionConfigByType(List<TransactionNumberUser> transactionNumberUsers, string type, string patientType)
        {
            if (transactionNumberUsers == null || transactionNumberUsers.Count == 0)
            {
                return null;
            }

            var transactionNumberConfigIds = transactionNumberUsers.Select(x => x.TransactionNumberConfigId).ToList();

            var activeTransactionNumber = _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().FirstOrDefault(
                x => transactionNumberConfigIds.Contains(x.Id) && x.IsActive && x.Type == type && x.PatientType == patientType);

            return activeTransactionNumber;
        }

        public TransactionNumberConfig GetNextNumberConfig(TransactionNumberConfig transactionNumberConfig)
        {
            if (transactionNumberConfig == null)
            {
                throw new Exception($"Không tìm thấy cấu hình transaction number");
            }

            transactionNumberConfig.RecvNo = transactionNumberConfig.RecvNo + 1;
            return transactionNumberConfig;
        }
        
        public TransactionNumberConfig GetAdvancePaymentNumberConfig(Guid userId)
        {
            var config = _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().FirstOrDefault(x => x.UserId == userId
                && x.IsActive && x.Type == "TU");
            return config;
        }

        public TransactionNumberConfig GetPaymentNumberConfig(Guid userId, string patientType)
        {
            throw new NotImplementedException();
        }

        public TransactionNumberConfig GetRefundConfig(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
