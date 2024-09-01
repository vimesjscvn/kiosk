using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Settings;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Domain.Services
{
    public class RegisterService : IRegisterService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Gets the hospital settings.
        /// </summary>
        /// <value>The hospital settings.</value>
        private readonly HospitalSettings _hospitalSettings;

        private readonly IPatientService _patientService;
        private readonly IReceptionService _receptionService;
        private readonly ILogger<RegisterService> _logger;
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        /// The queue number service
        /// </summary>
        private readonly IDeviceService _deviceService;

        /// <summary>
        /// The advance payment service
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public RegisterService(IUnitOfWork unitOfWork,
                HospitalSettings hospitalSettings,
                IPatientService patientService,
                ILogger<RegisterService> logger,
                IMapper mapper,
                IHospitalSystemService hospitalSystemService,
                IDataService dataService,
                IDeviceService deviceService)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
            _patientService = patientService;
            _logger = logger;
            _mapper = mapper;
            _hospitalSystemService = hospitalSystemService;
            _dataService = dataService;
            _deviceService = deviceService;
        }

        /// <summary>
        /// Updates the result list service out patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="ExternalException"></exception>
        public async Task UpdateResultListServiceOutPatient(UpdateResultListServiceRequest serviceRequest)
        {
            foreach (var item in serviceRequest.Services)
            {
                var orders = await _unitOfWork.GetRepository<ServiceOrder>().GetAll().Where(so => so.OrderId == item.OrderId && !so.IsFinished).ToListAsync();
                foreach (var order in orders)
                {
                    order.IsFinished = true;
                    order.IsHadResult = true;
                    _unitOfWork.GetRepository<ServiceOrder>().Update(order);
                }

                var numbers = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(so => so.OrderId == item.OrderId && !so.IsFinished).ToListAsync();
                foreach (var number in numbers)
                {
                    number.IsFinished = true;
                    _unitOfWork.GetRepository<QueueNumber>().Update(number);
                }
            }

            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Registers the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="ExternalException"></exception>
        public async Task<RegisterResponse> RegisterOutPatient(RegisterRequest request, Patient patient)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            var table = await _unitOfWork.GetRepository<Table>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Table);

            if (table != null)
            {
                if ((string.IsNullOrEmpty(table.ComputerIP) || table.ComputerIP != request.Ip)
                    && !string.IsNullOrEmpty(request.Ip))
                {
                    table.ComputerIP = request.Ip;
                    _unitOfWork.GetRepository<Table>().Update(table);
                    await _unitOfWork.CommitAsync();
                }
            }

            var device = await _deviceService.FindAsync(t => t.Ip == request.Ip);
            if (device == null)
            {
                device = new Device
                {
                    AreaCode = request.GroupDeptCode,
                    Code = request.Table,
                    Ip = request.Ip,
                    Name = "PC",
                    Type = "PC"
                };

                await _deviceService.AddAsync(device);
            }

            patient.PatientType = HealthcareHelper.GetPatientTypeWithCode(patient.HealthInsuranceNumber, patient.Birthday);
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(x => x.PatientCode == request.PatientCode && x.RegisteredCode == request.RegisteredCode);
            var receptionId = Guid.NewGuid();
            if (reception == null)
            {
                reception = new Reception
                {
                    Id = receptionId,
                    PatientCode = patient.Code,
                    PatientId = patient.Id,
                    PatientType = request.PatientType,
                    RegisteredCode = request.RegisteredCode,
                    RegisteredDate = request.RegisteredDate,
                    Status = ReceptionStatus.Success,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now
                };
                _unitOfWork.GetRepository<Reception>().Add(reception);
            }
            else
            {
                receptionId = reception.Id;
            }

            var departmentCode = request.DepartmentCode;
            var groupDeptCode = request.GroupDeptCode;
            var group = await _unitOfWork.GetRepository<Group>().FindAsync(g => g.GroupDeptCode == groupDeptCode);
            var department = await _unitOfWork.GetRepository<Department>().FindAsync(g => g.DepartmentCode == departmentCode
            && g.GroupDeptCode == groupDeptCode);

            var departmentName = department?.DepartmentName;
            var groupDeptName = group?.GroupDeptName;
            var registeredCode = request.RegisteredCode;

            var deptGroup = await _unitOfWork.GetRepository<DepartmentGroup>().FindAsync(g => g.DepartmentCode == departmentCode
            && g.GroupCode == groupDeptCode);

            var serviceOrder = await _unitOfWork.GetRepository<ServiceOrder>().GetAll().FirstOrDefaultAsync(sd =>
            sd.OrderId == request.OrderId
            && sd.OrderLineId == request.OrderLineId);

            if (serviceOrder != null)
            {
                serviceOrder.DepartmentCode = request.DepartmentCode;
                serviceOrder.DepartmentName = departmentName;
                _unitOfWork.GetRepository<ServiceOrder>().Update(serviceOrder);
            }
            else
            {
                serviceOrder = new ServiceOrder();
                serviceOrder.PatientCode = request.PatientCode;
                serviceOrder.DepartmentCode = departmentCode;
                serviceOrder.DepartmentName = departmentName;
                serviceOrder.DepartmentType = 0;
                serviceOrder.GroupDeptCode = groupDeptCode;
                serviceOrder.GroupDeptName = groupDeptName;
                serviceOrder.GroupServiceId = string.IsNullOrEmpty(request.GroupServiceId)
                    && !string.IsNullOrEmpty(serviceOrder.ServiceId)
                    && serviceOrder.ServiceId.Length > 5 ? serviceOrder.ServiceId.Substring(0, 5)
                    : request.GroupServiceId;
                serviceOrder.GroupServiceName = request.GroupServiceName;
                serviceOrder.OrderId = request.OrderId;
                serviceOrder.OrderLineId = request.OrderLineId;
                serviceOrder.ServiceId = request.ServiceId;
                serviceOrder.ServiceName = request.ServiceName;
                serviceOrder.Status = request.Status;
                serviceOrder.RegisteredDate = request.RegisteredDate;
                serviceOrder.RegisteredCode = request.RegisteredCode;
                serviceOrder.PatientType = request.PatientType;
                serviceOrder.IsFinished = false;
                serviceOrder.IsHadResult = false;
                serviceOrder.ExaminationCode = departmentCode;
                serviceOrder.ExaminationName = departmentName;
                _unitOfWork.GetRepository<ServiceOrder>().Add(serviceOrder);
                await _unitOfWork.CommitAsync();
            }

            var number = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(p => p.PatientCode == patient.Code
            && p.DepartmentCode == departmentCode
            && p.GroupDeptCode == groupDeptCode
            && !p.IsFinished
            && (patient.PatientType != PatientType.Normal
            ? p.Type != PatientType.Normal
            : p.Type == PatientType.Normal)).OrderByDescending(o => o.Number).FirstOrDefault();
            if (number == null)
            {
                number = new QueueNumber
                {
                    GroupDeptCode = groupDeptCode,
                    GroupDeptName = groupDeptName,
                    DepartmentCode = departmentCode,
                    DepartmentName = departmentName,
                    //DepartmentAddress = item.DepartmentAddress,
                    RegisteredCode = request.RegisteredCode,
                    RegisteredDate = request.RegisteredDate,
                    PatientCode = patient.Code,
                    PatientId = patient.Id,
                    Title = DepartmentTitles.PHONGKHAM,
                    Type = PatientType.Normal,
                    OrderId = request.OrderId,
                    DepartmentExtendId = deptGroup != null ? deptGroup.ListValueExtendId : Guid.Empty,
                    Number = request.Number,
                    Ip = request.Ip,
                    AreaCode = table?.AreaCode,
                    GroupCode = table != null && !string.IsNullOrEmpty(table.AreaCode) && table.AreaCode.Length > 0 ? table.AreaCode.Substring(table.AreaCode.Length - 1) : string.Empty
                };

                _unitOfWork.GetRepository<QueueNumber>().Add(number);
                await _unitOfWork.CommitAsync();
            }

            // Provide Number
            return _mapper.Map<QueueNumber, RegisterResponse>(number);
        }
    }
}
