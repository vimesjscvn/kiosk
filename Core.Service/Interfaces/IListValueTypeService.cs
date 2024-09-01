using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{ListValueType,IRepository}" />
    public interface IListValueTypeService : IService<ListValueType, IRepository<ListValueType>>
    {
        /// <summary>
        ///     Gets the list value type by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;ListValueType&gt;.</returns>
        Task<ListValueType> GetListValueTypeByCode(string code);
    }
}