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
using TEK.Core.Settings;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IDiagnosingImageService" />
    public class DiagnosingImageService : IDiagnosingImageService
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

        private readonly IExaminationService _examinationService;

        private readonly IInsuranceGatewayService _insuranceGatewayService;

        /// <summary>
        /// The advance payment service
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// Gets the insurance settings.
        /// </summary>
        /// <value>The insurance settings.</value>
        private readonly InsuranceSettings _insuranceSettings;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosingImageService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public DiagnosingImageService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            IPatientService patientService,
            IExaminationService examinationService,
            IDataService dataService,
            IInsuranceGatewayService insuranceGatewayService,
            InsuranceSettings insuranceSettings,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _patientService = patientService;
            _examinationService = examinationService;
            _dataService = dataService;
            _insuranceGatewayService = insuranceGatewayService;
            _insuranceSettings = insuranceSettings;
            _mapper = mapper;
        }

        public async Task<ICollection<QueueNumber>> CreateAndGenerateNumber(Patient patient, List<DiagnosingImageListModel> model)
        {
            var result = new List<QueueNumber>();

            var departments = await _dataService.GetListDepartment(new GetListGroupDeptModel
            {
                GroupDeptType = "CDHA"
            });

            var updateListServiceRequest = new PostRawUpdateListServiceRequest();

            foreach (var item in model)
            {
                var departmentName = departments.FirstOrDefault(d => d.DepartmentCode == item.DepartmentCode)?.DepartmentName;
                var departmentCode = item.DepartmentCode;
                var groupDeptCode = item.GroupDeptCode;
                var groupDeptName = item.GroupDeptCode;
                var registeredCode = item.RegisteredCode;

                var deptGroup = await _unitOfWork.GetRepository<DepartmentGroup>().FindAsync(g => g.DepartmentCode == departmentCode
                && g.GroupCode == groupDeptCode);

                var serviceDept = await _unitOfWork.GetRepository<ServiceOrder>().GetAll().FirstOrDefaultAsync(sd =>
                sd.OrderId == item.OrderId
                && sd.OrderLineId == item.OrderLineId);

                if (serviceDept != null)
                {
                    serviceDept.DepartmentCode = item.DepartmentCode;
                    serviceDept.DepartmentName = departmentName;
                    _unitOfWork.GetRepository<ServiceOrder>().Update(serviceDept);
                }

                var serviceOrders = _unitOfWork.GetRepository<ServiceOrder>()
                    .GetAll()
                    .Where(so => so.OrderId == item.OrderId);

                var number = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(p => p.PatientCode == patient.Code
                && p.DepartmentCode == departmentCode
                && p.GroupDeptCode == groupDeptCode
                && !p.IsFinished
                && (item.PatientType != PatientType.Normal
                ? p.Type != PatientType.Normal
                : p.Type == PatientType.Normal)).OrderByDescending(o => o.Number).FirstOrDefault();
                if (number != null)
                {
                    foreach (var so in serviceOrders)
                    {
                        number.Services.Add(_mapper.Map<ServiceOrder, ServiceQueueNumber>(so));
                        var updateServiceItemReq = new PostRawUpdateListServiceModel
                        {
                            DepartmentCode = departmentCode,
                            GroupServiceId = so.GroupServiceId,
                            GroupDeptCode = groupDeptCode,
                            Number = number.Number,
                            OrderId = so.OrderId,
                            OrderLineId = so.OrderLineId
                        };

                        updateListServiceRequest.Orders.Add(updateServiceItemReq);
                    }
                    result.Add(number);
                    continue;
                }

                number = new QueueNumber
                {
                    GroupDeptCode = item.GroupDeptCode,
                    GroupDeptName = item.GroupDeptName,
                    DepartmentCode = item.DepartmentCode,
                    DepartmentName = departmentName,
                    //DepartmentAddress = item.DepartmentAddress,
                    RegisteredCode = serviceDept.RegisteredCode,
                    RegisteredDate = item.RegisteredDate,
                    PatientCode = patient.Code,
                    PatientId = patient.Id,
                    Title = DepartmentTitles.PHONGKHAM,
                    Type = PatientType.Normal,
                    OrderId = item.OrderId,
                    DepartmentExtendId = deptGroup != null ? deptGroup.ListValueExtendId : Guid.Empty,
                    Ip = item.Ip
                };

                var last = new QueueNumber();
                if (number.Type == PatientType.Normal)
                {
                    last = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .OrderByDescending(c => c.Number)
                        .FirstOrDefaultAsync(q => q.DepartmentCode == number.DepartmentCode
                        && q.GroupDeptCode == groupDeptCode
                        && q.Type == PatientType.Normal);
                }
                else
                {
                    last = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .OrderByDescending(c => c.Number)
                        .FirstOrDefaultAsync(q => q.DepartmentCode == number.DepartmentCode
                        && q.GroupDeptCode == groupDeptCode
                        && q.Type != PatientType.Normal);
                }

                number.Number = last != null ? last.Number + 1 : 1;
                result.Add(number);
                _unitOfWork.GetRepository<QueueNumber>().Add(number);

                foreach (var so in serviceOrders)
                {
                    number.Services.Add(_mapper.Map<ServiceOrder, ServiceQueueNumber>(so));
                    var updateServiceItemReq = new PostRawUpdateListServiceModel
                    {
                        DepartmentCode = departmentCode,
                        GroupServiceId = so.GroupServiceId,
                        GroupDeptCode = groupDeptCode,
                        Number = number.Number,
                        OrderId = so.OrderId,
                        OrderLineId = so.OrderLineId
                    };

                    updateListServiceRequest.Orders.Add(updateServiceItemReq);
                }
            }

            //var t = Task.Factory.StartNew(() => _hospitalSystemService.PostRawUpdateListService(updateListServiceRequest));
            var updateResponse = _hospitalSystemService.PostRawUpdateListService(updateListServiceRequest);
            await _unitOfWork.CommitAsync();
            return result;
        }
    }
}
