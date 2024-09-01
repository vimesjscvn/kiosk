using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    public interface ITekmediCardHistoryService : IService<TekmediCardHistory, IRepository<TekmediCardHistory>>
    {
        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;StatisticalViewModel&gt;.</returns>
        Task<StatisticalViewModel> GetHistory(Guid id);
        /// <summary>
        /// Gets the statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;ICollection&lt;StatisticalViewModel&gt;&gt;.</returns>
        Task<TableResultJsonResponse<StatisticalViewModel>> GetStatistical(ExportRequest request);
        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;ICollection&lt;StatisticalViewModel&gt;&gt;.</returns>
        Task<TableResultJsonResponse<StatisticalViewModel>> GetHistory(HistoryCardRequest request);
        /// <summary>
        /// Gets the admin statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Task&lt;ICollection&lt;StatisticalViewModel&gt;&gt;.
        /// </returns>
        Task<TableResultJsonResponse<StatisticalViewModel>> GetAdminStatistical(ExportRequest request);
        /// <summary>
        /// Exports the statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ICollection<StatisticalViewModel>> ExportStatistical(ExportRequest request);
        /// <summary>
        /// Exports the admin statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ICollection<StatisticalViewModel>> ExportAdminStatistical(ExportRequest request);
        /// <summary>
        /// Gets the type of the history with.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<StatisticalViewModel>> GetHistoryWithType(HistoryCardWithTypeRequest request);
    }
}
