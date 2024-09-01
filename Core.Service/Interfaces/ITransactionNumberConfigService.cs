using CS.EF.Models;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    public interface ITransactionNumberConfigService : IService<TransactionNumberConfig, IRepository<TransactionNumberConfig>>
    {
    }
}
