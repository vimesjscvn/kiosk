// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PrescriptionService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.BusinessObjects;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;

namespace Core.Service.Implements
{
    /// <summary>
    ///     Class PrescriptionService.
    ///     Implements the <see cref="CS.Abstractions.IServices.IPrescriptionService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IPrescriptionService" />
    public class PrescriptionService : IPrescriptionService
    {
        /// <summary>
        ///     Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrescriptionService" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public PrescriptionService(IUnitOfWork unitOfWork, IHospitalSystemService hospitalSystemService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _mapper = mapper;
        }

        public async Task<PatientPrescriptionDetail> GetDetailByRegisteredCode(string code)
        {
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.RegisteredCode == code);

            if (reception == null) throw new Exception(ErrorMessages.NotFoundPrescription);

            var patientCode = reception.PatientCode;

            // Find patient in Tekmedi System
            var examinationRes = await _hospitalSystemService.GetRawExaminationDetailByCode(
                new GetRawExaminationDetailByCodeRequest
                {
                    RegisteredCode = reception.RegisteredCode,
                    PatientCode = reception.PatientCode
                });

            var detail = new PatientPrescriptionDetail
            {
                RegisteredCode = reception.RegisteredCode,
                RegisteredDate = reception.RegisteredDate,
                Prescriptions = new List<PatientPrescriptionGroupDetail>()
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

                if (examinationRes.Result.Prescriptions != null && examinationRes.Result.Prescriptions.Count > 0)
                    foreach (var prescription in examinationRes.Result.Prescriptions)
                    {
                        var prescriptionGroup = new PatientPrescriptionGroupDetail
                        {
                            Advice = prescription.Advice,
                            DepartmentCode = prescription.DepartmentCode,
                            DepartmentName = prescription.DepartmentName,
                            Doctor = prescription.Doctor,
                            DoctorCode = prescription.DoctorCode,
                            DoctorName = prescription.DoctorName,
                            GroupDeptCode = prescription.GroupDeptCode,
                            GroupDeptName = prescription.GroupDeptName,
                            OrderDate = prescription.OrderDate,
                            PrescriptionId = prescription.PrescriptionId,
                            Medicines = new List<PatientMedicineDetail>()
                        };

                        if (prescription.Medicines != null && prescription.Medicines.Count > 0)
                            foreach (var item in prescription.Medicines)
                            {
                                var medicine = new PatientMedicineDetail
                                {
                                    Description = item.Description,
                                    MedicineId = item.MedicineId,
                                    MedicineName = item.MedicineName,
                                    Quantity = item.Quantity,
                                    Unit = item.Unit
                                };

                                prescriptionGroup.Medicines.Add(medicine);
                            }

                        detail.Prescriptions.Add(prescriptionGroup);
                    }
            }

            return detail;
        }
    }
}