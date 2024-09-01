using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Responses;
using DepartmentGroup.Domain.Models;
using DepartmentGroup.Domain.Models.Requests;
using DepartmentGroup.Domain.Models.Requests.PostModels;
using DepartmentGroup.Domain.Models.Requests.PutModels;

namespace Core.Service.Interfaces
{
    public interface
        IPatientDepartmentService : IService<PatientDeptServiceEntity, IRepository<PatientDeptServiceEntity>>
    {
        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PagedResponse<List<PatientDepartmentServiceJsonViewModel>>>
            GetAll(PatientDepartmentServiceRequest request);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task InsertListServiceOfDepartment(InsertPatientDepartmentServiceModel request);

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        Task UpdateListServiceOfDepartment(UpdatePatientDepartmentServiceModel request, Guid id);

        /// <summary>
        ///     Get list departments.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        Task<PatientDepartmentServiceJsonViewModel> GetDepartmentServiceById(Guid id);

        /// <summary>
        ///     Get list departments.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        Task<IEnumerable<ListValueExtend>> GetListDepartment();
    }
}