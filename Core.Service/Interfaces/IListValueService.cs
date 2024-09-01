using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;

namespace Core.Service.Interfaces
{
    public interface IListValueService : IService<ListValue, IRepository<ListValue>>
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
        /// <returns>Task&lt;IEnumerable&lt;ListValue&gt;&gt;.</returns>
        Task<IEnumerable<ListValue>> GetListValuesActivated(string code);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValue&gt;&gt;.</returns>
        Task<IEnumerable<ListValue>> GetAllListValuebyCode(string code);

        /// <summary>
        ///     Gets all list hospital.
        /// </summary>
        /// <returns></returns>
        Task<List<ValueHospitalViewModel>> GetAllListHospital();
    }
}