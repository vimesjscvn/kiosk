using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.CheckInModel.Requests;
using CS.VM.CheckInModel.Responses;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{Table,IRepository}" />
    public interface ITableService : IService<Table, IRepository<Table>>
    {
        /// <summary>
        ///     Gets the callable tables.
        /// </summary>
        /// <returns></returns>
        Task<List<Table>> GetCallableTables();

        /// <summary>
        ///     Gets all table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<TableViewModel>> GetAllTable(GetTableRequest request);


        /// <summary>
        ///     Updates the table.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> UpdateTable(Guid id, TablePutModel request);

        /// <summary>
        ///     Checks the code unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> CheckCodeUnique(CheckCodeUniqueRequest request);

        /// <summary>
        ///     Changes the type of the table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ChangeTableTypeResponse> ChangeTableType(ChangeTableTypeRequest request);

        /// <summary>
        ///     Get all table by department code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<TableViewModel>> GetAllTableByDepartmentCode(
            GetAllTableByDepartmentCodeRequest request);

        /// <summary>
        ///     Checks the code is table code or not.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> CheckIsTableByCode(string code);
    }
}