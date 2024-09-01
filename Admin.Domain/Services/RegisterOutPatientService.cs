using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.PostModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    public class RegisterOutPatientService : IRegisterService
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

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterInPatientService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        /// <param name="mapper">The mapper.</param>
        public RegisterOutPatientService(IUnitOfWork unitOfWork,
                HospitalSettings hospitalSettings,
                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
            _mapper = mapper;
        }

        /// <summary>
        /// Updates the result list service in patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="Exception">
        /// </exception>
        public async Task UpdateResultListService(UpdateResultListServiceRequest request)
        {
            if (!DateTimeUtils.CheckValidDatetime(request.RegisteredDate))
                throw new Exception(MessagesCode.InvalidFormatDatetime);
            var patient = await GetPatientByCode(request.PatientCode);

            //Check Exsit service
            foreach (var item in request.Services)
            {
                var service = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(x => x.Code == item.ServiceId);

                if (service == null)
                    throw new Exception(MessagesCode.NotFoundService);
            }
        }

        /// <summary>
        /// Registers the list service in patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="Exception">
        /// </exception>
        public async Task RegisterListService(RegisterListServiceRequest request)
        {
            if (!DateTimeUtils.CheckValidDatetime(request.RegisteredDate))
                throw new Exception(MessagesCode.InvalidFormatDatetime);
            var patient = await GetPatientByCode(request.PatientCode);

            if (string.IsNullOrEmpty(patient.TekmediCardNumber))
                throw new Exception(MessagesCode.HaveNotProvidedCardNumber);

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == patient.TekmediCardNumber);

            if (cardInfo == null)
                throw new Exception(MessagesCode.NotFoundCardNumber);

            var totalAmountService = request.Clinics.Select(x => x.Amount).Sum();
            var totalAmountMedicine = request.Medicines.Select(x => x.Amount).Sum();
            var totalAmount = totalAmountService + totalAmountMedicine;
            var balance = cardInfo.Balance;
            if (totalAmount > (double)balance)
                throw new Exception(MessagesCode.NotEnoughBalance);
            else
            {
                await ProceessValidate(request.Clinics);
                await _unitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// Cancels the list service in patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="Exception"></exception>
        public async Task CancelListService(CancelListServiceRequest request)
        {
            if (!DateTimeUtils.CheckValidDatetime(request.RegisteredDate))
                throw new Exception(MessagesCode.InvalidFormatDatetime);
            var patient = await GetPatientByCode(request.PatientCode);
            await ProceessValidate(request.Clinics);
        }

        /// <summary>
        /// Registers the in patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            if (!DateTimeUtils.CheckValidDatetime(request.RegisteredDate))
                throw new Exception(MessagesCode.InvalidFormatDatetime);
            if (request.Amount <= 0)
                throw new Exception(MessagesCode.InvalidAmount);

            if (request.DoctorCode == "123123")
                throw new Exception(MessagesCode.NotFoundDoctor);

            var patient = await GetPatientByCode(request.PatientCode);

            var existReception = await _unitOfWork.GetRepository<Reception>().FindAsync(x => x.PatientCode == request.PatientCode && x.RegisteredCode == request.RegisteredCode);
            var receptionId = Guid.NewGuid();
            if (existReception == null)
            {
                _unitOfWork.GetRepository<Reception>().Add(new Reception
                {
                    Id = receptionId,
                    PatientCode = patient.Code,
                    PatientId = patient.Id,
                    PatientType = "",
                    RegisteredCode = request.RegisteredCode,
                    RegisteredDate = DateTime.Now,
                    Status = ReceptionStatus.Success,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now
                });
                await _unitOfWork.CommitAsync();
            }
            else receptionId = existReception.Id;

            var entity = _mapper.Map(request, new Clinic());
            entity.PatientId = patient.Id;
            entity.ReceptionId = receptionId;
            _unitOfWork.GetRepository<Clinic>().Add(entity);
            QueueNumber queueNumberModel = await GenerateQueueNumber(patient, entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map(queueNumberModel, new RegisterResponse());
        }

        /// <summary>
        /// Generates the queue number.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private async Task<QueueNumber> GenerateQueueNumber(Patient patient, Clinic entity)
        {
            // Create queue number
            var queueNumber = new QueueNumberPostModel
            {
                DepartmentCode = entity.DepartmentCode,
                PatientId = patient.Id
            };

            var queueNumberModel = _mapper.Map<QueueNumber>(queueNumber);

            var existing = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .FirstOrDefaultAsync(q => q.DepartmentCode == queueNumberModel.DepartmentCode
                                          && q.PatientId == queueNumberModel.PatientId);

            if (existing != null)
            {
                return existing;
            }

            queueNumberModel.Type = patient.PatientType;

            var last = new QueueNumber();
            if (queueNumberModel.Type == PatientType.Normal)
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == queueNumberModel.DepartmentCode
                                              && q.Type == PatientType.Normal);
            }
            else
            {
                last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .FirstOrDefaultAsync(q => q.DepartmentCode == queueNumberModel.DepartmentCode
                                              && q.Type != PatientType.Normal);
            }

            queueNumberModel.Number = last != null ? last.Number + 1 : 1;
            queueNumberModel.PatientId = patient.Id;
            var department = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(l => l.Code == queueNumberModel.DepartmentCode);
            queueNumberModel.DepartmentExtendId = department.Id;
            queueNumberModel.ClinicId = entity.Id;
            _unitOfWork.GetRepository<QueueNumber>().Add(queueNumberModel);
            await _unitOfWork.CommitAsync();
            return queueNumberModel;
        }

        /// <summary>
        /// Gets the patient by code.
        /// </summary>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ExternalException"></exception>
        private async Task<Patient> GetPatientByCode(string patientCode)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == patientCode);

            if (patient == null)
                throw new Exception(MessagesCode.NotFoundPatientWithCode);
            return patient;
        }

        /// <summary>
        /// Proceesses the validate.
        /// </summary>
        /// <param name="listServices">The list services.</param>
        /// <exception cref="Exception"></exception>
        private async Task ProceessValidate(List<ServiceDataModel> listServices)
        {
            //Check Exsit service
            foreach (var item in listServices)
            {
                var service = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(x => x.Code == item.ServiceCode);
                if (service == null)
                    throw new Exception(MessagesCode.NotFoundService);
            }
        }

        public Task UpdateResultListServiceInPatient(UpdateResultListServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateResultListServiceOutPatient(UpdateResultListServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task RegisterListServiceInPatient(RegisterListServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Clinic>> RegisterListServiceOutPatient(RegisterListServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        public Task CancelListServiceInPatient(CancelListServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task CancelListServiceOutPatient(CancelListServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterResponse> RegisterInPatient(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterResponse> RegisterOutPatient(RegisterRequest request, Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAdvancePaymentAfterRegister(string patientCode)
        {
            throw new NotImplementedException();
        }
    }
}
