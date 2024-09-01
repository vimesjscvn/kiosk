using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service.Interfaces;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Models;
using Microsoft.EntityFrameworkCore;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IRoomService" />
    public class RoomService : IRoomService
    {
        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoomService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets all departments.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListValueExtend>> GetAllDepartments()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>()
                .ListAsync(x => x.ListValueType.Code == "PB" && !x.IsDeleted, null);
        }

        public async Task<List<ListValueExtendViewModel>> GetAllDepartmentsWithType()
        {
            List<ListValueExtendViewModel> response;
            var departments = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Where(x => x.ListValueType.Code == ValueTypeCode.DepartmentCode && !x.IsDeleted).ToListAsync();
            var departmentIds = departments.Select(x => x.Id);
            var departmentTypeCLS = await _unitOfWork.GetRepository<DepartmentTypeCLS>().GetAll()
                .Where(x => x.ListValue.Code == DepartmentTypeValue.NPCD).ToListAsync();
            var departmentGroup =
                await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll().ToListAsync();
            response = _mapper.Map<List<ListValueExtendViewModel>>(departments);
            foreach (var department in response)
            {
                var checkExistInDepartmentGroup =
                    departmentTypeCLS.FirstOrDefault(x => x.ListValueExtendId == department.Id);
                if (checkExistInDepartmentGroup != null)
                    department.DepartmentType = DepartmentTypeValue.NPCD;
                else
                    department.DepartmentType = DepartmentTypeValue.NPTH;

                var existDepartmentGroup = departmentGroup.FirstOrDefault(x => x.ListValueExtendId == department.Id);
                if (existDepartmentGroup != null)
                    department.DepartmentVirtualId = existDepartmentGroup.DepartmentVirtualId.ToString();
            }

            return response;
        }

        public async Task<List<DepartmentGroupAndVirtualDepartmentViewModel>> GetGroupsAndVirtualDepartment(
            Guid departmentId)
        {
            var departmentGroups = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll()
                .Where(x => x.ListValueExtendId == departmentId)
                .Include(x => x.Group).Include(x => x.ListValueExtend).ToListAsync();
            var groupsInformation = departmentGroups.Select(x => new
            {
                GroupdId = x.Group.Id,
                GroupCode = x.Group.GroupDeptCode,
                GroupName = x.Group.GroupDeptName,
                x.Group.Description,
                x.DepartmentVirtualId,
                DepartmentVirtualCode = x.ListValueExtend?.Code
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