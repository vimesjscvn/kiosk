// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ExaminationService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Class ExaminationService.
    /// Implements the <see cref="CS.Abstractions.IServices.IExaminationService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IExaminationService" />
    public class ExaminationService : IExaminationService
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
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        private readonly IInsuranceGatewayService _insuranceGatewayService;

        /// <summary>
        /// Gets the insurance settings.
        /// </summary>
        /// <value>The insurance settings.</value>
        private readonly InsuranceSettings _insuranceSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExaminationService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public ExaminationService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            IInsuranceGatewayService insuranceGatewayService,
            IMapper mapper,
            InsuranceSettings insuranceSettings)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _insuranceGatewayService = insuranceGatewayService;
            _mapper = mapper;
            _insuranceSettings = insuranceSettings;
        }

        public async Task<ICollection<Reception>> GetListByIdentityCardOrHealthcareNumber(string code)
        {
            // Find patient in Tekmedi System
            var response = await _hospitalSystemService.GetRawListExaminationByCode(new GetRawListExaminationByCodeRequest
            {
                IdentityCardNumber = code
            });

            if (response.Result.Count == 0)
            {
                // Find patient in Tekmedi System
                var healthInsuranceNumberResponse = await _hospitalSystemService.GetRawListExaminationByCode(new GetRawListExaminationByCodeRequest
                {
                    HealthInsuranceNumber = code
                });
            }

            var patientCode = string.Empty;

            foreach (var item in response.Result)
            {
                var patientInfo = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(p => p.Code == item.PatientCode);

                if (patientInfo == null)
                {
                    // Find patient in Tekmedi System
                    var patientRes = await _hospitalSystemService.GetRawPatientByRegisteredCode(new GetRawPatientByRegisteredCodeRequest
                    {
                        PatientCode = item.RegisteredCode
                    });

                    patientInfo = _mapper.Map<Patient>(patientRes);
                    _unitOfWork.GetRepository<Patient>().Add(patientInfo);
                    await _unitOfWork.CommitAsync();
                }

                patientCode = patientInfo.Code;

                var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == item.PatientCode
                        && r.RegisteredCode == item.RegisteredCode);

                if (reception == null)
                {
                    reception = new Reception
                    {
                        PatientCode = patientInfo.Code,
                        PatientId = patientInfo.Id,
                        PatientType = item.PatientType,
                        RegisteredCode = item.RegisteredCode,
                        RegisteredDate = item.RegisteredDate,
                        Status = ReceptionStatus.Success,
                        Type = ReceptionType.New,
                        CreatedBy = Systems.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Systems.UpdatedBy,
                        UpdatedDate = DateTime.Now
                    };

                    _unitOfWork.GetRepository<Reception>().Add(reception);
                    await _unitOfWork.CommitAsync();
                }
            }

            return await _unitOfWork.GetRepository<Reception>().GetAll().Where(r => r.PatientCode == patientCode).ToListAsync();
        }

        public async Task<ICollection<Reception>> GetListByTypeAndCode(string type, string code)
        {
            var request = new GetRawListExaminationByCodeRequest();
            switch (type)
            {
                case DocumentTypes.HIS:
                    request.PatientCode = code;
                    break;
                case DocumentTypes.BHYT:
                    var pHealthModel = await _unitOfWork.GetRepository<Patient>().GetAll().AsNoTracking().Where(p => p.HealthInsuranceNumber.Contains(code)).FirstOrDefaultAsync();
                    if (pHealthModel != null)
                    {
                        request.PatientCode = pHealthModel.Code;
                    }
                    else
                    {
                        request.HealthInsuranceNumber = code;
                    }
                    break;
                case DocumentTypes.CCCD:
                    var pIdentityModel = await _unitOfWork.GetRepository<Patient>().GetAll().AsNoTracking().Where(p => p.IdentityCardNumber.Contains(code)).FirstOrDefaultAsync();
                    if (pIdentityModel != null)
                    {
                        request.PatientCode = pIdentityModel.Code;
                    }
                    else
                    {
                        request.IdentityCardNumber = code;
                    }
                    break;
                default:
                    break;
            }
            // Find patient in Tekmedi System
            var response = await _hospitalSystemService.GetRawListExaminationByCode(request);
            var receptions = new List<Reception>();
            var patientCode = string.Empty;

            foreach (var item in response.Result)
            {
                var patientInfo = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(p => p.Code == item.PatientCode);

                if (patientInfo == null)
                {
                    // Find patient in Tekmedi System
                    var patientRes = await _hospitalSystemService.GetRawPatientByRegisteredCode(new GetRawPatientByRegisteredCodeRequest
                    {
                        PatientCode = item.RegisteredCode
                    });

                    patientInfo = _mapper.Map<Patient>(patientRes);
                    _unitOfWork.GetRepository<Patient>().Add(patientInfo);
                    await _unitOfWork.CommitAsync();
                }

                patientCode = patientInfo.Code;

                var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == item.PatientCode
                        && r.RegisteredCode == item.RegisteredCode);

                if (reception == null)
                {
                    reception = new Reception
                    {
                        PatientCode = patientInfo.Code,
                        PatientId = patientInfo.Id,
                        PatientType = item.PatientType,
                        RegisteredCode = item.RegisteredCode,
                        RegisteredDate = item.RegisteredDate,
                        Status = ReceptionStatus.Success,
                        Type = ReceptionType.New,
                        CreatedBy = Systems.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Systems.UpdatedBy,
                        UpdatedDate = DateTime.Now
                    };

                    _unitOfWork.GetRepository<Reception>().Add(reception);
                    await _unitOfWork.CommitAsync();
                }

                receptions.Add(reception);
            }

            return receptions;
        }

        public async Task<ICollection<Reception>> GetListByPatientCode(string code)
        {
            Patient patientInfo = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(p => p.Code == code);

            // Find patient in Tekmedi System
            var response = await _hospitalSystemService.GetRawListExaminationByCode(new GetRawListExaminationByCodeRequest
            {
                PatientCode = code
            });

            var registeredCode = response != null
                && response.Result != null
                && response.Result.Count > 0
                ? response.Result.FirstOrDefault()?.RegisteredCode : string.Empty;

            var patientCode = string.Empty;

            if (!string.IsNullOrEmpty(registeredCode) && patientInfo == null)
            {
                // Find patient in Tekmedi System
                var patientRes = await _hospitalSystemService.GetRawPatientByRegisteredCode(new GetRawPatientByRegisteredCodeRequest
                {
                    PatientCode = registeredCode
                });

                patientInfo = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(p => p.Code == patientRes.PatientCode);

                if (patientInfo == null)
                {
                    patientInfo = _mapper.Map<Patient>(patientRes);
                    _unitOfWork.GetRepository<Patient>().Add(patientInfo);
                    await _unitOfWork.CommitAsync();
                }
            }

            if (response.Result.Count == 0 || patientInfo == null)
            {
                return new List<Reception>();
            }

            foreach (var item in response.Result)
            {
                patientCode = patientInfo.Code;

                var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == item.PatientCode
                        && r.RegisteredCode == item.RegisteredCode);

                if (reception == null)
                {
                    reception = new Reception
                    {
                        PatientCode = patientInfo.Code,
                        PatientId = patientInfo.Id,
                        PatientType = item.PatientType,
                        RegisteredCode = item.RegisteredCode,
                        RegisteredDate = item.RegisteredDate,
                        StatusCode = item.StatusCode,
                        StatusName = item.StatusName,
                        IsFinished = item.StatusCode == "T",
                        Status = ReceptionStatus.Success,
                        Type = ReceptionType.New,
                        CreatedBy = Systems.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = Systems.UpdatedBy,
                        UpdatedDate = DateTime.Now
                    };

                    _unitOfWork.GetRepository<Reception>().Add(reception);
                    await _unitOfWork.CommitAsync();
                }
            }

            return await _unitOfWork.GetRepository<Reception>().GetAll().Where(r => r.PatientCode == patientCode).ToListAsync();
        }

        public async Task<PatientExaminationDetail> GetDetailByRegisteredCode(string code)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == code);

            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundExamination);
            }

            var patientCode = reception.PatientCode;

            // Find patient in Tekmedi System
            var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(new GetRawExaminationDetailByCodeRequest
            {
                RegisteredCode = reception.RegisteredCode,
                PatientCode = reception.PatientCode
            });

            var detail = new PatientExaminationDetail
            {
                RegisteredCode = reception.RegisteredCode,
                RegisteredDate = reception.RegisteredDate,
                Clinics = new List<PatientClinicGroupDetail>()
            };

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(r => r.Code == patientCode);
            detail.Patient = _mapper.Map<PatientViewModel>(patient);

            if (examinationRes.Result != null)
            {
                if (examinationRes.Result.Examinations != null && examinationRes.Result.Examinations.Count > 0)
                {
                    var exam = examinationRes.Result.Examinations.FirstOrDefault();
                    if (exam != null)
                    {
                        detail.Summary.BodyPart = exam.BodyPart;
                        detail.Summary.ClinicalExamination = exam.ClinicalExamination;
                        detail.Summary.Conclusion = exam.Conclusion;
                        detail.Summary.DoctorName = exam.DoctorName;
                        detail.Summary.FullBodyPart = exam.FullBodyPart;
                        detail.Summary.ICDTenId = exam.ICDTenId;
                        detail.Summary.InitialDiagnosis = exam.InitialDiagnosis;
                        detail.Summary.KeyId = exam.KeyId;
                        detail.Summary.DepartmentName = exam.DepartmentName;
                        detail.Summary.DepartmentCode = exam.DepartmentCode;
                    }
                }

                if (examinationRes.Result.TestResults != null && examinationRes.Result.TestResults.Count > 0)
                {
                    var groups = examinationRes.Result.TestResults.GroupBy(g => new { g.ServiceTypeId, g.OrderId });
                    foreach (var groupItem in groups)
                    {
                        var serviceGroup = new PatientClinicGroupDetail
                        {
                            ServiceTypeId = groupItem.Key.ServiceTypeId + "-" + groupItem.Key.OrderId,
                            OrderId = groupItem.Key.OrderId,
                            ServiceTypeName = examinationRes.Result.TestResults.FirstOrDefault(t => t.ServiceTypeId == groupItem.Key.ServiceTypeId)?.ServiceTypeName,
                            RegisteredDate = reception.RegisteredDate,
                            RegisteredCode = reception.RegisteredCode,
                            Services = new List<PatientClinicServiceDetail>()
                        };

                        foreach (var item in groupItem)
                        {
                            var service = new PatientClinicServiceDetail
                            {
                                DepartmentCode = item.DepartmentCode,
                                DepartmentName = item.DepartmentName,
                                Description = item.Description,
                                DoctorCode = item.DoctorCode,
                                DoctorName = item.DoctorName,
                                FileAttach = item.FileAttach,
                                FileAttachName = item.FileAttachName,
                                GroupDeptCode = item.GroupDeptCode,
                                GroupDeptName = item.GroupDeptName,
                                ListSubTestResult = item.ListSubTestResult,
                                NormalRange1 = item.NormalRange1,
                                NormalRange2 = item.NormalRange2,
                                Note = item.Note,
                                OrderId = item.OrderId,
                                OrderLineId = item.OrderLineId,
                                PatientCode = item.PatientCode,
                                RegisteredCode = item.RegisteredCode,
                                Result = item.Result,
                                ServiceId = item.ServiceId,
                                ServiceName = item.ServiceName,
                                ServiceTypeId = item.ServiceTypeId,
                                ServiceTypeName = item.ServiceTypeName,
                                Unit = item.Unit
                            };

                            serviceGroup.Services.Add(service);
                        }

                        detail.Clinics.Add(serviceGroup);
                    }
                }
            }

            return detail;
        }

        public async Task<PatientExaminationServiceGroupDetail> GetServiceDetailByRegisteredCodeAndServiceId(string code, string typeId)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == code);

            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundExamination);
            }

            var patientCode = reception.PatientCode;

            // Find patient in Tekmedi System
            var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(new GetRawExaminationDetailByCodeRequest
            {
                RegisteredCode = reception.RegisteredCode,
                PatientCode = reception.PatientCode
            });

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(r => r.Code == patientCode);

            var detail = new PatientExaminationServiceGroupDetail()
            {
                RegisteredCode = reception.RegisteredCode,
                RegisteredDate = reception.RegisteredDate,
            };

            detail.Patient = _mapper.Map<PatientViewModel>(patient);

            if (examinationRes.Result != null)
            {
                if (examinationRes.Result.Examinations != null && examinationRes.Result.Examinations.Count > 0)
                {
                    var exam = examinationRes.Result.Examinations.FirstOrDefault();
                    if (exam != null)
                    {
                        detail.BodyPart = exam.BodyPart;
                        detail.ClinicalExamination = exam.ClinicalExamination;
                        detail.Conclusion = exam.Conclusion;
                        detail.DoctorName = exam.DoctorName;
                        detail.FullBodyPart = exam.FullBodyPart;
                        detail.ICDTenId = exam.ICDTenId;
                        detail.InitialDiagnosis = exam.InitialDiagnosis;
                        detail.KeyId = exam.KeyId;
                        detail.DepartmentName = exam.DepartmentName;
                        detail.DepartmentCode = exam.DepartmentCode;
                    }
                }

                if (examinationRes.Result.TestResults != null && examinationRes.Result.TestResults.Count > 0)
                {
                    var groups = examinationRes.Result.TestResults.GroupBy(g => new { g.ServiceTypeId, g.OrderId }).Where(w => (w.Key.ServiceTypeId + "-" + w.Key.OrderId) == typeId).FirstOrDefault();
                    if (groups != null)
                    {
                        var serviceType = groups.FirstOrDefault();
                        detail.OrderId = groups.Key.OrderId;
                        detail.ServiceTypeId = groups.Key.ServiceTypeId;
                        detail.ServiceTypeName = serviceType.ServiceTypeName;
                        detail.Description = serviceType.Description;
                        var isTestGroup = !string.IsNullOrEmpty(detail.ServiceTypeName) && detail.ServiceTypeName.ToLower().IndexOf(ServiceGroups.XN) > 0;
                        if (!isTestGroup)
                        {
                            detail.Result = serviceType.Result;
                            detail.Note = serviceType.Note;
                        }

                        detail.SubTestResults = new List<PatientExaminationSubTestResultDetail>();
                        foreach (var item in groups)
                        {
                            var serviceItem = new PatientExaminationSubTestResultDetail();
                            serviceItem.ServiceId = item.ServiceId;
                            serviceItem.ServiceName = item.ServiceName;
                            serviceItem.Result = item.Result;
                            serviceItem.Unit = item.Unit;
                            serviceItem.NormalRange = item.NormalRange1;
                            serviceItem.Note = item.Note;
                            detail.SubTestResults.Add(serviceItem);
                            if (item.ListSubTestResult.Count > 0)
                            {
                                foreach (var subTestItem in item.ListSubTestResult)
                                {
                                    var subTest = new PatientExaminationSubTestResultDetail();
                                    subTest.ServiceId = subTestItem.ServiceId;
                                    subTest.ServiceName = subTestItem.ServiceName;
                                    subTest.Result = subTestItem.Result;
                                    subTest.Unit = subTestItem.Unit;
                                    subTest.NormalRange = subTestItem.NormalRange1;
                                    subTest.Note = subTestItem.Note;
                                    detail.SubTestResults.Add(subTest);
                                }
                            }
                        }
                    }
                }
            }

            return detail;
        }

        public async Task<PatientExaminationServiceResultList> GetListServiceResultByRegisteredCode(string code)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == code);

            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundExamination);
            }

            var patientCode = reception.PatientCode;

            // Find patient in Tekmedi System
            var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(new GetRawExaminationDetailByCodeRequest
            {
                RegisteredCode = reception.RegisteredCode,
                PatientCode = reception.PatientCode
            });

            var detail = new PatientExaminationServiceResultList
            {
                RegisteredCode = reception.RegisteredCode,
                RegisteredDate = reception.RegisteredDate,
                Clinics = new List<PatientExaminationServiceResult>()
            };

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(r => r.Code == patientCode);
            detail.Patient = _mapper.Map<PatientViewModel>(patient);

            if (examinationRes.Result != null)
            {
                if (examinationRes.Result.TestResults != null && examinationRes.Result.TestResults.Count > 0)
                {
                    foreach (var item in examinationRes.Result.TestResults)
                    {
                        var serviceResult = new PatientExaminationServiceResult
                        {
                            OrderId = item.OrderId,
                            OrderLineId = item.OrderLineId,
                            ServiceTypeId = item.ServiceTypeId,
                            ServiceTypeName = item.ServiceTypeName,
                            ServiceId = item.ServiceId,
                            ServiceName = item.ServiceName,
                            RegisteredDate = reception.RegisteredDate,
                            RegisteredCode = reception.RegisteredCode,
                            Services = new List<PatientClinicServiceDetail>()
                        };

                        foreach (var subItem in item.ListSubTestResult)
                        {
                            var service = new PatientClinicServiceDetail
                            {
                                ServiceId = subItem.ServiceId,
                                ServiceName = subItem.ServiceName,
                            };

                            serviceResult.Services.Add(service);
                        }

                        detail.Clinics.Add(serviceResult);
                    }
                }
            }

            return detail;
        }

        public async Task<PatientExaminationServiceGroupDetail> GetServiceDetailByOrder(string code, string orderId, string orderLineId)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == code);

            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundExamination);
            }

            var patientCode = reception.PatientCode;

            // Find patient in Tekmedi System
            var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(new GetRawExaminationDetailByCodeRequest
            {
                RegisteredCode = reception.RegisteredCode,
                PatientCode = reception.PatientCode
            });

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(r => r.Code == patientCode);

            var detail = new PatientExaminationServiceGroupDetail()
            {
                RegisteredCode = reception.RegisteredCode,
                RegisteredDate = reception.RegisteredDate,
            };

            detail.Patient = _mapper.Map<PatientViewModel>(patient);

            if (examinationRes.Result != null)
            {
                if (examinationRes.Result.Examinations != null && examinationRes.Result.Examinations.Count > 0)
                {
                    var exam = examinationRes.Result.Examinations.FirstOrDefault();
                    if (exam != null)
                    {
                        detail.BodyPart = exam.BodyPart;
                        detail.ClinicalExamination = exam.ClinicalExamination;
                        detail.Conclusion = exam.Conclusion;
                        detail.DoctorName = exam.DoctorName;
                        detail.FullBodyPart = exam.FullBodyPart;
                        detail.ICDTenId = exam.ICDTenId;
                        detail.InitialDiagnosis = exam.InitialDiagnosis;
                        detail.KeyId = exam.KeyId;
                        detail.DepartmentName = exam.DepartmentName;
                        detail.DepartmentCode = exam.DepartmentCode;
                    }
                }

                if (examinationRes.Result.TestResults != null && examinationRes.Result.TestResults.Count > 0)
                {

                }
            }

            return detail;
        }

        public async Task<ICollection<QueueNumber>> Create(Patient patient, List<ExamRegistrationListModel> model, bool isThrowError = false, string registrationType = "")
        {
            var ip = model.FirstOrDefault()?.Ip;
            var result = new List<QueueNumber>();
            registrationType = await ValidateHealthInsurance(patient);

            var resp = await _hospitalSystemService.PostRawRegisterExamination(new PostRawRegisterExaminationRequest
            {
                PatientCode = patient.Code,
                Birthday = patient.Birthday.ToString(DateTimeFormatConstants.YYYYMMDDTHHMMSSZ, CultureInfo.InvariantCulture),
                DistrictCode = patient.DistrictCode,
                Email = patient.Email,
                FirstName = patient.FirstName,
                Gender = patient.Gender == Gender.Male ? "0" : "1",
                HealthInsuranceExpiredDate = patient.HealthInsuranceExpiredDate?.ToString(DateTimeFormatConstants.YYYYMMDDTHHMMSSZ, CultureInfo.InvariantCulture),
                HealthInsuranceFirstPlace = patient.HealthInsuranceFirstPlace,
                HealthInsuranceFirstPlaceCode = patient.HealthInsuranceFirstPlaceCode,
                HealthInsuranceIssuedDate = patient.HealthInsuranceIssuedDate?.ToString(DateTimeFormatConstants.YYYYMMDDTHHMMSSZ, CultureInfo.InvariantCulture),
                HealthInsuranceNumber = patient.HealthInsuranceNumber,
                IdentityCardNumber = patient.IdentityCardNumber,
                IdentityCardNumberIssuedDate = patient.IdentityCardNumberIssuedDate?.ToString(DateTimeFormatConstants.YYYYMMDDTHHMMSSZ, CultureInfo.InvariantCulture),
                IdentityCardNumberIssuedPlace = patient.IdentityCardNumberIssuedPlace,
                LastName = patient.LastName,
                //Passport = patient.Passport,
                PhoneNumber = patient.Phone,
                ProvinceCode = patient.ProvinceCode,
                Street = patient.Street,
                WardCode = patient.WardCode,
                YearOfBirth = patient.Birthday.ToString(DateTimeFormatConstants.YYYY),
                RegistrationType = registrationType,
                Departments = model.Select(_mapper.Map<ExamRegistrationListModel, PostRawRegisterExaminationDataRequest>).ToList()
            });

            if (resp != null)
            {
                if (resp.Result != null && resp.Result.Count > 0)
                {
                    foreach (var item in resp.Result)
                    {
                        var number = await _unitOfWork.GetRepository<QueueNumber>().FindAsync(r => r.DepartmentCode == item.DepartmentCode
                        && r.RegisteredCode == item.RegisteredCode
                        && r.GroupDeptCode == item.GroupDeptCode
                        && DateTime.Compare(r.CreatedDate.Date, DateTime.Now.Date) == 0);

                        if (number == null)
                        {
                            number = new QueueNumber
                            {
                                GroupDeptCode = item.GroupDeptCode,
                                GroupDeptName = item.GroupDeptName,
                                DepartmentCode = item.DepartmentCode,
                                DepartmentName = item.DepartmentName,
                                DepartmentAddress = item.DepartmentAddress,
                                RegisteredCode = item.RegisteredCode,
                                RegisteredDate = item.RegisteredDate,
                                Number = item.Number,
                                PatientCode = patient.Code,
                                PatientId = patient.Id,
                                Title = DepartmentTitles.PHONGKHAM,
                                Type = PatientType.Normal,
                                Ip = ip
                            };

                            result.Add(number);
                            _unitOfWork.GetRepository<QueueNumber>().Add(number);
                        }

                        var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == item.RegisteredCode);
                        if (reception == null)
                        {
                            reception = new Reception
                            {
                                PatientCode = patient.Code,
                                PatientId = patient.Id,
                                PatientType = item.PatientType,
                                RegisteredCode = item.RegisteredCode,
                                RegisteredDate = item.RegisteredDate,
                                StatusName = "Đang mở",
                                StatusCode = "O",
                                Status = ReceptionStatus.Success,
                            };

                            _unitOfWork.GetRepository<Reception>().Add(reception);
                        }
                    }

                    await _unitOfWork.CommitAsync();
                    return result;
                }

                if (isThrowError)
                {
                    string errorMessage = string.Empty;
                    if (resp.Result == null || resp.Result.Count == 0)
                    {
                        if (!string.IsNullOrEmpty(resp.ErrorMessage))
                        {
                            errorMessage += resp.ErrorMessage + " ";
                        }
                        else if (!string.IsNullOrEmpty(resp.Message))
                        {
                            errorMessage += resp.Message + " ";
                        }
                        else
                        {
                            errorMessage += ErrorMessages.Default + " ";
                        }
                    }

                    throw new Exception(errorMessage);
                }
            }

            return result;
        }

        private async Task<string> ValidateHealthInsurance(Patient patient)
        {
            var registeredType = "BHYT";

            var insuranceCode = string.Empty;
            if (!string.IsNullOrEmpty(patient.HealthInsuranceNumber))
            {
                insuranceCode = patient.HealthInsuranceNumber;
            }
            else if (!string.IsNullOrEmpty(patient.IdentityCardNumber))
            {
                insuranceCode = patient.IdentityCardNumber;
            }

            if (string.IsNullOrEmpty(insuranceCode))
            {
                registeredType = "DV";
                return registeredType;
            }

            // Find patient in Tekmedi System
            var tokenResponse = await _insuranceGatewayService.PostRawLoginInsuranceGateway(new PostRawLoginInsuranceGatewayRequest
            {
                username = _insuranceSettings.Insurance.Username,
                password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password),
            });

            var verifyResponse = await _insuranceGatewayService.PostRawVerifyInsuranceGateway(new PostRawVerifyInsuranceGatewayRequest
            {
                token = tokenResponse.APIKey.access_token,
                id_token = tokenResponse.APIKey.id_token,
                hoTen = patient.LastName.Trim() + " " + patient.FirstName.Trim(),
                ngaySinh = patient.Birthday.ToString(DateTimeFormatConstants.YYYY),
                maThe = insuranceCode
            });

            if (verifyResponse.maKetQua != "000"
                && verifyResponse.maKetQua != "001"
                && verifyResponse.maKetQua != "002"
                && verifyResponse.maKetQua != "003"
                && verifyResponse.maKetQua != "004")
            {
                throw new Exception(verifyResponse.ghiChu);
            }

            if (string.IsNullOrEmpty(patient.HealthInsuranceNumber))
            {
                var healthInsuranceFirstPlaceCode = verifyResponse.maDKBDMoi;
                var healthInsuranceFirstPlace = verifyResponse.tenDKBDMoi;
                var healthInsuranceIssuedDate = verifyResponse.gtTheTuMoi;
                var healthInsuranceExpiredDate = verifyResponse.gtTheDenMoi;

                patient.HealthInsuranceNumber = verifyResponse.maThe;
                patient.HealthInsuranceFirstPlaceCode = healthInsuranceFirstPlaceCode;
                patient.HealthInsuranceFirstPlace = healthInsuranceFirstPlace;
                patient.HealthInsuranceIssuedDate = healthInsuranceIssuedDate.Length == 10 ? DateTime.ParseExact(healthInsuranceIssuedDate, DateTimeFormatConstants.DDMMYYYY,
                                            CultureInfo.InvariantCulture) : DateTime.Now;
                patient.HealthInsuranceExpiredDate = DateTime.ParseExact(healthInsuranceExpiredDate, DateTimeFormatConstants.DDMMYYYY,
                                             CultureInfo.InvariantCulture);
            }

            return registeredType;
        }

        public async Task<ICollection<QueueNumber>> CreateAndGenerateNumber(Patient patient, List<ExamRegistrationListModel> model)
        {
            var result = new List<QueueNumber>();

            foreach (var item in model)
            {
                var departmentCode = item.DepartmentCode;
                var registeredCode = item.RegisteredCode;
                var existedNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(p => p.PatientCode == patient.Code
                && p.DepartmentCode == departmentCode
                && (item.PatientType != PatientType.Normal
                ? p.Type != PatientType.Normal
                : p.Type == PatientType.Normal)).FirstOrDefault();
                if (existedNumber != null)
                {
                    result.Add(existedNumber);
                    continue;
                }

                var entity = new QueueNumber
                {
                    GroupDeptCode = item.GroupDeptCode,
                    GroupDeptName = item.GroupDeptName,
                    DepartmentCode = item.DepartmentCode,
                    DepartmentName = item.DepartmentName,
                    //DepartmentAddress = item.DepartmentAddress,
                    RegisteredCode = item.RegisteredCode,
                    RegisteredDate = item.RegisteredDate,
                    PatientCode = patient.Code,
                    PatientId = patient.Id,
                    Title = DepartmentTitles.PHONGKHAM,
                    Type = PatientType.Normal,
                    Ip = item.Ip
                };

                var last = new QueueNumber();
                if (entity.Type == PatientType.Normal)
                {
                    last = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .OrderByDescending(c => c.Number)
                        .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                        && q.Type == PatientType.Normal);
                }
                else
                {
                    last = await _unitOfWork.GetRepository<QueueNumber>().GetAll().AsNoTracking()
                        .OrderByDescending(c => c.Number)
                        .FirstOrDefaultAsync(q => q.DepartmentCode == entity.DepartmentCode
                        && q.Type != PatientType.Normal);
                }

                entity.Number = last != null ? last.Number + 1 : 1;
                var department = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().SingleOrDefaultAsync(l => l.Code == entity.DepartmentCode);
                if (department != null)
                {
                    entity.DepartmentExtendId = department.Id;
                    entity.DepartmentName = department.Description;
                }

                result.Add(entity);
                _unitOfWork.GetRepository<QueueNumber>().Add(entity);
            }

            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<ICollection<QueueNumber>> CreateWithGroup(Patient patient, List<ExamRegistrationListModel> model, bool isThrowError = false)
        {
            var ip = model.FirstOrDefault()?.Ip;
            var exams = new List<PostRawRegisterExamByGroupResponseData>();
            var receptionCodes = await _unitOfWork.GetRepository<Reception>().GetAll().Where(r => r.PatientCode == patient.Code
            && DateTime.Compare(r.RegisteredDate.Date, DateTime.Now.Date) == 0).Select(s => s.RegisteredCode).Distinct().ToListAsync();

            var responses = new List<PostRawRegisterExamByGroupResponse>();
            foreach (var item in model)
            {
                var groupExams = await _hospitalSystemService.PostRawRegisterExamByGroup(new PostRawRegisterExamByGroupRequest
                {
                    PatientCode = patient.Code,
                    Address = patient.Street,
                    Birthday = patient.Birthday.ToString(DateTimeFormatConstants.YYYY),
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Gender = patient.Gender == Gender.Male ? GenderConstants.Male : GenderConstants.Female,
                    HealthInsuranceFirstPlaceCode = patient.HealthInsuranceFirstPlaceCode,
                    HealthInsuranceIssuedDate = patient.HealthInsuranceIssuedDate.HasValue
                    ? patient.HealthInsuranceIssuedDate.Value
                    : DateTime.Now,
                    HealthInsuranceExpiredDate = patient.HealthInsuranceExpiredDate.HasValue
                    ? patient.HealthInsuranceExpiredDate.Value
                    : DateTime.Now,
                    HealthInsuranceNumber = patient.HealthInsuranceNumber,
                    TypeExam = item.DepartmentCode,
                    ReceptionCodes = receptionCodes
                });
                responses.Add(groupExams);

                if (groupExams != null
                    && groupExams.Result != null
                    && groupExams.Result.Count > 0)
                {
                    exams.AddRange(groupExams.Result);
                }
            }

            var result = new List<QueueNumber>();

            foreach (var item in exams)
            {
                var number = await _unitOfWork.GetRepository<QueueNumber>().FindAsync(r => r.DepartmentCode == item.DepartmentCode
                && r.RegisteredCode == item.RegisteredCode
                && r.GroupDeptCode == item.GroupDeptCode
                && DateTime.Compare(r.CreatedDate.Date, DateTime.Now.Date) == 0);

                if (number == null)
                {
                    number = new QueueNumber
                    {
                        GroupDeptCode = item.GroupDeptCode,
                        GroupDeptName = item.GroupDeptName,
                        DepartmentCode = item.DepartmentCode,
                        DepartmentName = item.DepartmentName,
                        DepartmentAddress = item.DepartmentAddress,
                        RegisteredCode = item.RegisteredCode,
                        RegisteredDate = item.RegisteredDate,
                        Number = item.Number,
                        PatientCode = patient.Code,
                        PatientId = patient.Id,
                        Title = DepartmentTitles.PHONGKHAM,
                        Type = PatientType.Normal,
                        Ip = ip
                    };

                    _unitOfWork.GetRepository<QueueNumber>().Add(number);
                }
                else
                {
                    number = new QueueNumber
                    {
                        GroupDeptCode = item.GroupDeptCode,
                        GroupDeptName = item.GroupDeptName,
                        DepartmentCode = item.DepartmentCode,
                        DepartmentName = item.DepartmentName,
                        DepartmentAddress = item.DepartmentAddress,
                        RegisteredCode = item.RegisteredCode,
                        RegisteredDate = item.RegisteredDate,
                        Number = item.Number,
                        PatientCode = patient.Code,
                        PatientId = patient.Id,
                        Title = DepartmentTitles.PHONGKHAM,
                        Type = PatientType.Normal,
                        Ip = ip
                    };
                }

                result.Add(number);

                var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(r => r.RegisteredCode == item.RegisteredCode);
                if (reception == null)
                {
                    reception = new Reception
                    {
                        PatientCode = patient.Code,
                        PatientId = patient.Id,
                        PatientType = item.PatientType,
                        RegisteredCode = item.RegisteredCode,
                        RegisteredDate = item.RegisteredDate,
                        StatusName = "Đang mở",
                        StatusCode = "O",
                        Status = ReceptionStatus.Success,
                    };

                    _unitOfWork.GetRepository<Reception>().Add(reception);
                }
            }

            if (isThrowError)
            {
                if (exams.Count == 0)
                {
                    string errorMessage = string.Empty;
                    foreach (var resp in responses)
                    {
                        if (resp.Result == null || resp.Result.Count == 0)
                        {
                            if (!string.IsNullOrEmpty(resp.ErrorMessage))
                            {
                                errorMessage += resp.ErrorMessage + " ";
                            }
                            else if (!string.IsNullOrEmpty(resp.Message))
                            {
                                errorMessage += resp.Message + " ";
                            }
                            else
                            {
                                errorMessage += ErrorMessages.Default + " ";
                            }
                        }
                    }

                    throw new Exception(errorMessage);
                }
            }

            await _unitOfWork.CommitAsync();
            return result;
        }
    }
}
