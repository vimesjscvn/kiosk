using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Domain.BusinessObjects;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IDataService" />
    public class DataService : IDataService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        /// Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IPatientService _patientService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public DataService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            IPatientService patientService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _patientService = patientService;
            _mapper = mapper;
        }

        public async Task<ICollection<Department>> ActiveGroupDept(List<ActiveGroupDeptModel> model)
        {
            var groupIds = model.Select(s => s.GroupDeptCode).ToList();
            var departmentIds = model.Select(s => s.GroupDeptCode).ToList();
            var departments = await _unitOfWork.GetRepository<Department>()
                .GetAll()
                .Where(g => groupIds.Any(id => id == g.GroupDeptCode))
                .ToListAsync();

            foreach (var group in model)
            {
                var deptIds = group.ActiveDepartments.Select(s => s.ToString()).ToList();
                var activeDepts = departments.Where(d => d.GroupDeptCode == group.GroupDeptCode
                && deptIds.Any(id => id == d.DepartmentCode)).ToList();

                var inactiveDepts = departments.Where(d => d.GroupDeptCode == group.GroupDeptCode
                && !deptIds.Any(id => id == d.DepartmentCode)).ToList();

                foreach (var dept in activeDepts)
                {
                    dept.IsActive = true;
                    _unitOfWork.GetRepository<Department>().Update(dept);
                }

                foreach (var dept in inactiveDepts)
                {
                    dept.IsActive = false;
                    _unitOfWork.GetRepository<Department>().Update(dept);
                }
            }

            await _unitOfWork.CommitAsync();
            return departments;
        }

        public async Task<ICollection<Department>> GetListDepartment(GetListGroupDeptModel model)
        {
            var response = await _hospitalSystemService.GetRawListGroupDept(new GetRawListGroupDeptRequest
            {
                GroupDeptType = model.GroupDeptType
            });

            var groupDepts = response.Select(_mapper.Map<Group>).ToList();
            var depts = new List<Department>();
            groupDepts = groupDepts.Where(g => g.GroupDeptType == model.GroupDeptType).ToList();
            foreach (var group in groupDepts)
            {
                foreach (var item in group.Departments)
                {
                    var dept = _mapper.Map<Department>(item);
                    dept.GroupDeptCode = group.GroupDeptCode;
                    dept.GroupDeptName = group.GroupDeptName;
                    depts.Add(dept);
                }
            }

            return depts;
        }

        public async Task<ICollection<Group>> GetListGroupDept(GetListGroupDeptModel model)
        {
            var group = await _unitOfWork.GetRepository<Group>()
                .GetAll()
                .Where(g => g.GroupDeptType == model.GroupDeptType)
                .ToListAsync();
            return group;
        }

        public async Task<ICollection<Group>> GetGroupDeptByCode(GetGroupDeptByCodeModel model)
        {
            var group = await _unitOfWork.GetRepository<Group>()
                .GetAll()
                .Where(g => g.GroupDeptCode == model.GroupDeptCode)
                .ToListAsync();
            return group;
        }

        public async Task<ICollection<ServiceOrder>> GetListServiceByRegisteredCode(GetListServiceByRegisteredCodeModel model)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(r => r.Code == model.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var response = await _hospitalSystemService.GetRawListServiceByRegisteredCode(new GetRawListServiceByRegisteredCodeRequest
            {
                RegisteredCode = model.RegisteredCode
            });

            var orders = new List<ServiceOrder>();

            if (response != null && response.Orders != null && response.Orders.Count > 0)
            {
                var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == model.RegisteredCode);
                if (reception == null)
                {
                    reception = new Reception
                    {
                        PatientId = patient.Id,
                        PatientCode = patient.Code,
                        PatientType = response.PatientType,
                        RegisteredCode = response.RegisteredCode,
                        RegisteredDate = DateTime.Now,
                        Status = ReceptionStatus.Success,
                        Type = ReceptionType.New,
                        CreatedBy = Systems.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Systems.UpdatedBy,
                        UpdatedDate = DateTime.Now
                    };

                    _unitOfWork.GetRepository<Reception>().Add(reception);
                }

                var orderIds = response.Orders.Select(s => s.OrderId);

                var serviceOrders = _unitOfWork.GetRepository<ServiceOrder>().GetAll()
                    .Where(sd => orderIds.Any(o => o == sd.OrderId)).ToArray();

                var isAdded = false;

                foreach (var item in response.Orders)
                {
                    var serviceOrder = serviceOrders.FirstOrDefault(sd => sd.OrderId == item.OrderId
                        && sd.OrderLineId == item.OrderLineId);

                    if (serviceOrder == null)
                    {
                        serviceOrder = new ServiceOrder();
                        serviceOrder.PatientCode = model.PatientCode;
                        //order.DepartmentCode = item.DepartmentCode;
                        //order.DepartmentName = item.DepartmentName;
                        serviceOrder.DepartmentType = item.DepartmentType;
                        serviceOrder.GroupDeptCode = item.GroupDeptCode;
                        serviceOrder.GroupDeptName = item.GroupDeptName;
                        serviceOrder.GroupServiceId = item.GroupServiceId;
                        serviceOrder.GroupServiceName = item.GroupServiceName;
                        serviceOrder.OrderId = item.OrderId;
                        serviceOrder.OrderLineId = item.OrderLineId;
                        serviceOrder.ServiceId = item.ServiceId;
                        serviceOrder.ServiceName = item.ServiceName;
                        serviceOrder.Status = item.Status;
                        serviceOrder.RegisteredDate = DateTime.Now;
                        serviceOrder.RegisteredCode = response.RegisteredCode;
                        serviceOrder.PatientType = response.PatientType;
                        serviceOrder.IsFinished = false;
                        serviceOrder.IsHadResult = false;
                        serviceOrder.ExaminationCode = item.DepartmentCode;
                        serviceOrder.ExaminationName = item.DepartmentName;
                        _unitOfWork.GetRepository<ServiceOrder>().Add(serviceOrder);
                        isAdded = true;
                    }

                    foreach (var deptItem in item.Departments)
                    {
                        var dept = _mapper.Map<GetRawListDepartmentServiceByRegisteredCodeData, ServiceDepartment>(deptItem);
                        dept.OrderId = serviceOrder.OrderId;
                        dept.OrderLineId = serviceOrder.OrderLineId;
                        dept.ServiceId = serviceOrder.ServiceId;
                        dept.ServiceName = serviceOrder.ServiceName;
                        dept.DepartmentType = serviceOrder.DepartmentType;
                        //dept.TotalNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Count(r => r.DepartmentCode == deptItem.DepartmentCode
                        //&& r.GroupDeptCode == deptItem.GroupDeptCode);
                        serviceOrder.Departments.Add(dept);
                    }

                    orders.Add(serviceOrder);
                }

                if (isAdded)
                {
                    await _unitOfWork.CommitAsync();
                }
            }

            return orders;
        }

        public async Task<ICollection<Group>> PostSyncListGroupDept(PostSyncListGroupDeptModel model)
        {
            var response = await _hospitalSystemService.GetRawListGroupDept(new GetRawListGroupDeptRequest
            {
                GroupDeptType = model.GroupDeptCode
            });

            var groupDepts = response.Select(_mapper.Map<Group>).ToList();

            var depts = new List<Department>();

            foreach (var gItem in groupDepts)
            {
                gItem.Description = gItem.GroupDeptName;
                var group = await _unitOfWork.GetRepository<Group>().FindAsync(g => g.GroupDeptCode == gItem.GroupDeptCode);
                if (group == null)
                {
                    group = gItem;
                    group.Id = Guid.NewGuid();
                    _unitOfWork.GetRepository<Group>().Add(group);
                }

                group = await InsertMasterData(gItem);

                foreach (var dItem in group.Departments)
                {
                    var dept = await _unitOfWork.GetRepository<Department>().FindAsync(d => d.GroupDeptCode == dItem.GroupDeptCode
                    && d.DepartmentCode == dItem.DepartmentCode);

                    var deptGroup = await _unitOfWork.GetRepository<DepartmentGroup>().FindAsync(d => d.GroupCode == dItem.GroupDeptCode
                    && d.DepartmentCode == dItem.DepartmentCode);

                    if (dept != null)
                    {
                        depts.Add(dept);
                        if (deptGroup != null)
                        {
                            continue;
                        }

                        deptGroup = new DepartmentGroup
                        {
                            Id = Guid.NewGuid(),
                            DepartmentCode = dItem.DepartmentCode,
                            GroupCode = group.GroupDeptCode,
                            ListValueExtendId = dept.ListValueExtendId,
                            DepartmentId = dept.Id,
                            GroupId = group.Id,
                            DepartmentVirtualId = dept.ListValueExtendId
                        };

                        _unitOfWork.GetRepository<DepartmentGroup>().Add(deptGroup);
                    }

                    dept = dItem;
                    dept.Id = Guid.NewGuid();
                    dept.GroupId = group.Id;
                    dept.GroupDeptCode = group.GroupDeptCode;
                    dept.GroupDeptName = group.GroupDeptName;

                    _unitOfWork.GetRepository<Department>().Add(dept);
                    depts.Add(dept);

                    if (deptGroup != null)
                    {
                        continue;
                    }

                    deptGroup = new DepartmentGroup
                    {
                        Id = Guid.NewGuid(),
                        DepartmentCode = dItem.DepartmentCode,
                        GroupCode = group.GroupDeptCode,
                        ListValueExtendId = dept.ListValueExtendId,
                        DepartmentId = dept.Id,
                        GroupId = group.Id,
                        DepartmentVirtualId = dept.ListValueExtendId
                    };

                    _unitOfWork.GetRepository<DepartmentGroup>().Add(deptGroup);
                }
            }

            foreach (var dept in depts)
            {
                var deptConfig = await _unitOfWork.GetRepository<DepartmentConfig>().FindAsync(d => d.GroupDeptCode == dept.GroupDeptCode
                    && d.DepartmentCode == dept.DepartmentCode);

                if (deptConfig != null)
                {
                    continue;
                }

                deptConfig = new DepartmentConfig
                {
                    Id = Guid.NewGuid(),
                    DepartmentCode = dept.DepartmentCode,
                    GroupDeptCode = dept.GroupDeptCode,
                    DepartmentId = dept.Id,
                    GroupId = dept.GroupId,
                    AgeFrom = 0,
                    AgeTo = 100,
                    TimeActive = "{\"EndTimeActiveAM\":\"12:00:00\",\"StartTimeActiveAM\":\"05:00:00\",\"EndTimeActivePM\":\"16:00:00\",\"StartTimeActivePM\":\"13:00:00\"}",
                    TimeOnMinute = 9,
                    TotalNumber = 65,
                    TypeGender = TypeGender.All,
                    ActiveReExamDays = new int[] { 0, 1, 2, 3, 4, 5, 6 }
                };

                _unitOfWork.GetRepository<DepartmentConfig>().Add(deptConfig);
            }

            await _unitOfWork.CommitAsync();
            return groupDepts;
        }

        private async Task<Group> InsertMasterData(Group gItem)
        {
            var listValueType = await _unitOfWork.GetRepository<ListValueType>().FindAsync(g => g.Code == "PB");
            var listValue = await _unitOfWork.GetRepository<ListValue>().FindAsync(g => g.ListValueTypeId == listValueType.Id
            && g.Code == gItem.GroupDeptCode);

            if (listValueType != null)
            {
                if (listValue == null)
                {
                    listValue = new ListValue
                    {
                        Description = gItem.GroupDeptName,
                        Code = gItem.GroupDeptCode,
                        ListValueTypeId = listValueType.Id,
                        Type = "HIS"
                    };

                    listValue.Id = Guid.NewGuid();
                    _unitOfWork.GetRepository<ListValue>().Add(listValue);
                    gItem.ListValueId = listValue.Id;
                }

                foreach (var dItem in gItem.Departments)
                {
                    var listValueExtend = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(d => d.ListValueId == listValue.Id
                    && d.Code == dItem.DepartmentCode);

                    if (listValueExtend != null)
                    {
                        continue;
                    }

                    listValueExtend = new ListValueExtend
                    {
                        Id = Guid.NewGuid(),
                        ListValueId = listValue.Id,
                        ListValueTypeId = listValueType.Id,
                        Code = dItem.DepartmentCode,
                        Description = dItem.DepartmentName,
                        Type = "HIS"
                    };

                    _unitOfWork.GetRepository<ListValueExtend>().Add(listValueExtend);

                    dItem.ListValueExtendId = listValueExtend.Id;
                }
            }

            return gItem;
        }
    }
}
