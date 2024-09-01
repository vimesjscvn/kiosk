using CS.EF.Models;
using CS.VM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.IRoomService" />
    public class RoomService : IRoomService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListValueExtend>> GetAllDepartments()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().ListAsync(x => x.ListValueType.Code == "PB" && !x.IsDeleted, null);
        }

        public Task<List<ListValueExtendViewModel>> GetAllDepartmentsWithType()
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentGroupAndVirtualDepartmentViewModel>> GetGroupsAndVirtualDepartment(Guid departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
