using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
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
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListValueExtend>> GetAllDepartments()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().ListAsync(x => x.ListValueType.Code == "PB" && !x.IsDeleted, null);
        }

        public async Task<List<ListValueExtendViewModel>> GetAllDepartmentsWithType()
        {
            List<ListValueExtendViewModel> response;
            var departments = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(x => x.ListValueType.Code == ValueTypeCode.DepartmentCode && !x.IsDeleted).ToListAsync();
            var departmentIds = departments.Select(x => x.Id);
            var departmentTypeCLS = await _unitOfWork.GetRepository<DepartmentTypeCLS>().GetAll().Where(x => x.ListValue.Code == Constants.DepartmentTypeValue.NPCD).ToListAsync();
            var departmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll().ToListAsync();
            response = _mapper.Map<List<ListValueExtendViewModel>>(departments);
            foreach (var department in response)
            {
                var checkExistInDepartmentGroup = departmentTypeCLS.FirstOrDefault(x => x.ListValueExtendId == department.Id);
                if (checkExistInDepartmentGroup != null)
                    department.DepartmentType = Constants.DepartmentTypeValue.NPCD;
                else
                    department.DepartmentType = Constants.DepartmentTypeValue.NPTH;

                var existDepartmentGroup = departmentGroup.FirstOrDefault(x => x.ListValueExtendId == department.Id);
                if (existDepartmentGroup != null)
                {
                    department.DepartmentVirtualId = existDepartmentGroup.DepartmentVirtualId.ToString();
                }
            }
            return response;
        }

        public async Task<List<DepartmentGroupAndVirtualDepartmentViewModel>> GetGroupsAndVirtualDepartment(Guid departmentId)
        {
            var departmentGroups = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                                        .Where(x => x.ListValueExtendId == departmentId)
                                        .Include(x => x.Group).Include(x => x.DepartmentVirtual).ToListAsync();
            var groupsInformation = departmentGroups.Select(x => new
            {
                GroupdId = x.Group.Id,
                GroupCode = x.Group.GroupDeptCode,
                GroupName = x.Group.GroupDeptName,
                Description = x.Group.Description,
                DepartmentVirtualId = x.DepartmentVirtualId,
                DepartmentVirtualCode = x.DepartmentVirtual?.Code
            });

            groupsInformation = groupsInformation.Distinct().ToList();
            var departmentAndGroupsInfo = groupsInformation.Select(x => new DepartmentGroupAndVirtualDepartmentViewModel
            {
                Id = x.GroupdId,
                Code = x.GroupCode,
                Name = x.GroupName,
                Description = x.Description,
                DepartmentVirtualId = x.DepartmentVirtualId,
                DepartmentVirtualCode = x.DepartmentVirtualCode

            }).ToList();

            return departmentAndGroupsInfo;
        }
    }
}
