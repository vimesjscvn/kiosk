// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IPrescriptionService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.VM.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IPrescriptionService
    ///     Implements the <see cref="CS.Base.IService{Prescription, Base.IRepository{Prescription}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Prescription, Base.IRepository{Prescription}}" />
    public interface IPrescriptionService
    {
        Task<PatientPrescriptionDetail> GetDetailByRegisteredCode(string code);
    }

    public class PatientPrescriptionSummaryDetail
    {
        public string BodyPart { get; set; }
        public string ClinicalExamination { get; set; }
        public string Conclusion { get; set; }
        public string DoctorName { get; set; }
        public string FullBodyPart { get; set; }
        public string ICDTenId { get; set; }
        public string InitialDiagnosis { get; set; }
        public string KeyId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }

    public class PatientPrescriptionDetail
    {
        public List<PatientPrescriptionGroupDetail> Prescriptions { get; set; }
        public string RegisteredCode { get; set; }
        public DateTime RegisteredDate { get; set; }
        public PatientViewModel Patient { get; set; }
        public PatientPrescriptionSummaryDetail Summary { get; set; } = new PatientPrescriptionSummaryDetail();
    }

    public class PatientPrescriptionGroupDetail
    {
        public string PrescriptionId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Doctor { get; set; }
        public string Advice { get; set; }
        public List<PatientMedicineDetail> Medicines { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string GroupDeptCode { get; set; }
        public string GroupDeptName { get; set; }
    }

    public class PatientMedicineDetail
    {
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
    }
}