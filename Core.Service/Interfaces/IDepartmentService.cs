using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Requests;
using DepartmentGroup.Domain.Models.Requests;
using DepartmentGroup.Domain.Models.Requests.PostModels;
using DepartmentGroup.Domain.Models.Requests.PutModels;
using DepartmentGroup.Domain.Models.Responses;

namespace Core.Service.Interfaces
{
    public interface IDepartmentService : IService<Department, IRepository<Department>>
    {
        /// <summary>
        ///     Checks the unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> CheckUnique(CheckCodeUniqueRequest request);

        /// Get list departments.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        Task<IEnumerable<Group>> GetGroup();

        Task<IEnumerable<Department>> GetListValueByValueCode(string typeCode);

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
        Task<ListValueExtend> AddDepartment(DepartmentPostModel request);

        /// <summary>
        ///     Gets the list values activated.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<Department> UpdateDepartment(Guid id, DepartmentPutModel request);

        Task<ListValueExtend> UpdateDepartmentAdmin(Guid id, DepartmentPutModel request);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        IEnumerable<ListValueExtend> GetAllListValueByCode(DepartmentPagingRequest request, out int total);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<bool> RemoveInGroup(Guid id);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<bool> RemoveInDepartmentConfig(Guid departmentId);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<IEnumerable<ListValueExtendChangeDepartmentName>> ChangeNameDepartment(List<string> listDepartmentCode);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<bool> UpdateDepartmentOfListValueExtend(Department department, string code);

        Task<IEnumerable<Department>> GetDepartmentByGroupCode(string groupCode);
    }
}