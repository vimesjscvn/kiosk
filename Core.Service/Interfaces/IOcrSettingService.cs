using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface IOcrSettingService
    {
        /// <summary>
        ///     Adds the specified request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> AddOrUpdate(Guid id, AddOrUpdateOcrSettingRequest request);

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        ///     Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<OcrSettingViewModel> Get();

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<OcrSettingViewModel>> GetAll(GetOcrSettingRequest request);

        /// <summary>
        ///     Changes the active.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> ChangeActive(ChangeActiveRequest request);

        /// <summary>
        ///     Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<OcrSettingViewModel> GetById(Guid id);

        /// <summary>
        ///     Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<OcrSettingViewModel>> Export(ExportOcrSettingRequest request);
    }
}