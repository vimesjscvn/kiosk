using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.BusinessObjects;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Requests;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{ListValueExtend,IRepository}" />
    public interface IListValueExtendService : IService<ListValueExtend, IRepository<ListValueExtend>>
    {
        /// <summary>
        ///     Checks the code unique.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CheckCodeUnique(CheckCodeUniqueRequest requestData);

        /// <summary>
        ///     Gets the list values activated.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<IEnumerable<ListValueExtend>> GetListValuesActivated(string code);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<IEnumerable<ListValueExtend>> GetAllListValuebyCode(string code);

        Task<IEnumerable<ListValueExtend>> GetAllListValuebyCodeAndDescription(GetAllListValuesRequest requestData);

        /// <summary>
        ///     Gets all list department.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<IEnumerable<ListValueExtend>> GetListDepartment();

        /// <summary>
        ///     Gets synchronization list service.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<bool> SynchronizationListService(ServiceListFromHisRawData<GetListServiceFromHisRawData> request);
    }
}