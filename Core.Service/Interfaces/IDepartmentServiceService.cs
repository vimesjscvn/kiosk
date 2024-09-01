using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using DepartmentGroup.Domain.Models;
using DepartmentGroup.Domain.Models.Requests.PutModels;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{DepartmentService,IRepository}" />
    public interface IDepartmentServiceService : IService<DepartmentService, IRepository<DepartmentService>>
    {
        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PagedResponse<List<DepartmentServiceJsonViewModel>>> GetAll(DepartmentServiceRequest request);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task<IEnumerable<ListValueExtend>> GetServicesByExaminationCode(string request);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task InsertListServiceOfDepartment(InsertServiceOfDepartmentModel request);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task UpdateListServiceOfDepartment(UpdateServiceOfDepartmentModel request, Guid id);

        /// <summary>
        ///     Get list departments.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        Task<DepartmentServiceJsonViewModel> GetDepartmentServiceById(Guid id);

        /// <summary>
        ///     Get list departments.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        Task<IEnumerable<ListValueExtend>> GetListDepartment();

        Department GetKhuThucHien(string maPhongKhamChiDinh, string loaiDoiTuongPhongKham, string chiDinhCanThucHien);

        /// <summary>
        ///     Verifies the department service.
        /// </summary>
        /// <param name="imports">The imports.</param>
        /// <returns></returns>
        Task<ImportDepartmentServiceResponse> VerifyDepartmentService(List<ImportDepartmentServiceModel> imports);

        /// <summary>
        ///     Checks the unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> CheckUnique(CheckUniqueRequest request);

        /// <summary>
        ///     Updates the department service.
        /// </summary>
        /// <param name="departmentServiceId">The department service identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> UpdateDepartmentService(Guid departmentServiceId, UpdateDepartmentServiceRequest request);

        /// <summary>
        ///     Adds the department service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> AddDepartmentService(AddDepartmentServiceRequest request);

        /// <summary>
        ///     Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<DepartmentServiceViewModel>> Export(ExportDepartmentServiceRequest request);

        /// Get list departments.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        Task<IEnumerable<Group>> GetGroup();
    }
}