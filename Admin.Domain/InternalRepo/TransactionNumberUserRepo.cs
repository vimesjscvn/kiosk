using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace Admin.API.Domain.InternalRepo
{
    public class TransactionNumberUserRepo : ITransactionNumberUserRepo
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionNumberUserRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTransactionUserNumber(TransactionNumberUser transactionNumberUser)
        {
            _unitOfWork.GetRepository<TransactionNumberUser>().Add(transactionNumberUser);
        }

        public async Task<List<TransactionNumberUser>> GetByTransactionNumberConfigId(Guid tranactionNumberConfigId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberUser>().GetAll().Include(x => x.User).Where(x => x.TransactionNumberConfigId == tranactionNumberConfigId).ToListAsync();
        }

        public async Task<TransactionNumberUser> GetByUserIdAndConfigId(Guid userId, Guid configId)
        {
            return await _unitOfWork.GetRepository<TransactionNumberUser>().GetAll().FirstOrDefaultAsync(x => x.UserId == userId && x.TransactionNumberConfigId == configId);
        }

        public void RemoveTransactionNumber(TransactionNumberUser transactionNumberUser)
        {
            _unitOfWork.GetRepository<TransactionNumberUser>().Delete(transactionNumberUser);
        }
    }
}
