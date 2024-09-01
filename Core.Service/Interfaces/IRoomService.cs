using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.EF.Models;
using CS.VM.Models;

namespace Core.Service.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        ///     Gets all departments.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ListValueExtend>> GetAllDepartments();

        /// <summary>
        ///     Gets all departments with department type.
        /// </summary>
        /// <returns></returns>
        Task<List<ListValueExtendViewModel>> GetAllDepartmentsWithType();

        Task<List<DepartmentGroupAndVirtualDepartmentViewModel>> GetGroupsAndVirtualDepartment(Guid departmentId);
    }
}