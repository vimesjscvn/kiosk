using System;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{Medicine,IRepository}" />
    public interface IMedicineService : IService<Medicine, IRepository<Medicine>>
    {
        /// <summary>
        ///     Checks the code unique.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CheckCodeUnique(Guid id, string code);
    }
}