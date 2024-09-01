using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Helpers;
using Core.Config.Helpers;
using Core.Config.Settings;
using Core.Service.Interfaces;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Requests;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Service.Cron
{
    public class SyncDepartmentJob
    {
        private readonly BackgroundJobSettings _backgroundJobSettings;

        private readonly IHospitalSystemService _hospitalSystemService;
        private readonly ILogger<SyncDepartmentJob> _logger;

        /// <summary>
        ///     The hospital settings
        /// </summary>
        private readonly IPatientService _patientService;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public SyncDepartmentJob(IUnitOfWork unitOfWork,
            IPatientService patientService,
            IHospitalSystemService hospitalSystemService,
            BackgroundJobSettings backgroundJobSettings,
            ILogger<SyncDepartmentJob> logger)
        {
            _unitOfWork = unitOfWork;
            _patientService = patientService;
            _hospitalSystemService = hospitalSystemService;
            _backgroundJobSettings = AppConfig.LoadBackgroundJob(backgroundJobSettings);
            _logger = logger;
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task Sync()
        {
            var groupDepts = _backgroundJobSettings.BackgroundJob.SyncGroupDeptList;
            var predicate = PredicateBuilder.True<Department>();

            if (groupDepts != null && groupDepts.Count > 0)
                predicate = predicate.And(x => groupDepts.Contains(x.GroupDeptCode));

            var depts = await _unitOfWork.GetRepository<Department>().GetAll().Where(predicate).ToListAsync();
            foreach (var dept in depts) await SyncData(dept);
        }

        private async Task SyncData(Department dept)
        {
            var numbersFromHIS = await _hospitalSystemService.GetPendingList(new GetRawPendingListRequest
            {
                DepartmentCode = dept.DepartmentCode,
                GroupDeptCode = dept.GroupDeptCode
            });

            if (numbersFromHIS.Result != null)
            {
                var oldNumbers = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(q =>
                    q.DepartmentCode == dept.DepartmentCode
                    && q.GroupDeptCode == dept.GroupDeptCode).ToListAsync();

                if (oldNumbers.Count > 0)
                    foreach (var item in oldNumbers)
                    {
                        item.IsSelected = true;
                        _unitOfWork.GetRepository<QueueNumber>().Update(item);
                    }

                var result = numbersFromHIS.Result;
                if (result.RegisteredCode != "0")
                    await SyncNumberDepartment(dept, result.PatientCode, result.RegisteredCode,
                        int.Parse(result.OrderNumber), true);


                foreach (var item in numbersFromHIS.Result.MissingPatient)
                    if (item.RegisteredCode != "0")
                        await SyncNumberDepartment(dept, item.PatientCode, item.RegisteredCode,
                            int.Parse(item.OrderNumber));


                foreach (var item in numbersFromHIS.Result.WaitingPatient)
                    if (item.RegisteredCode != "0")
                        await SyncNumberDepartment(dept, item.PatientCode, item.RegisteredCode,
                            int.Parse(item.OrderNumber));

                await _unitOfWork.CommitAsync();
            }
        }

        private async Task SyncNumberDepartment(Department dept, string patientCode, string registeredCode, int number,
            bool isSelected = false)
        {
            var patient = await _patientService.GetByCode(patientCode);
            if (patient != null)
            {
                var currentNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(q =>
                    q.PatientCode == patient.Code
                    && q.DepartmentCode == dept.DepartmentCode
                    && q.GroupDeptCode == dept.GroupDeptCode
                    && q.RegisteredCode == registeredCode
                    && q.Number == number).FirstOrDefaultAsync();

                if (currentNumber == null)
                {
                    currentNumber = new QueueNumber
                    {
                        DepartmentCode = dept.DepartmentCode,
                        GroupDeptCode = dept.GroupDeptCode,
                        DepartmentAddress = dept.DepartmentAddress,
                        DepartmentName = dept.DepartmentName,
                        GroupDeptName = dept.GroupDeptName,
                        Number = number,
                        PatientCode = patient.Code,
                        RegisteredCode = registeredCode,
                        RegisteredDate = DateTime.Now,
                        PatientId = patient.Id,
                        DepartmentExtendId = dept.ListValueExtendId,
                        IsSelected = isSelected
                    };

                    _unitOfWork.GetRepository<QueueNumber>().Add(currentNumber);
                }
                else
                {
                    currentNumber.IsSelected = isSelected;
                    _unitOfWork.GetRepository<QueueNumber>().Update(currentNumber);
                }
            }
        }
    }
}