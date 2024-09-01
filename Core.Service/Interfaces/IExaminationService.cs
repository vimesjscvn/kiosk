// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IExaminationService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.BusinessObjects;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IExaminationService
    ///     Implements the <see cref="CS.Base.IService{Examination, Base.IRepository{Examination}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Examination, Base.IRepository{Examination}}" />
    public interface IExaminationService
    {
        Task<PatientExaminationDetail> GetDetailByRegisteredCode(string code);
        Task<ICollection<Reception>> GetListByIdentityCardOrHealthcareNumber(string code);
        Task<ICollection<Reception>> GetListByTypeAndCode(string type, string code);
        Task<ICollection<Reception>> GetListByPatientCode(string code);
        Task<PatientExaminationServiceGroupDetail> GetServiceDetailByRegisteredCodeAndServiceId(string code, string id);
        Task<PatientExaminationServiceResultList> GetListServiceResultByRegisteredCode(string code);

        Task<PatientExaminationServiceGroupDetail> GetServiceDetailByOrder(string code, string orderId,
            string orderLineId);

        Task<ICollection<QueueNumber>> CreateAndGenerateNumber(Patient patient, List<ExamRegistrationListModel> depts);

        Task<ICollection<QueueNumber>> Create(Patient patient, List<ExamRegistrationListModel> model,
            bool isThrowError = false, string registrationType = "");

        Task<ICollection<QueueNumber>> CreateWithGroup(Patient patient, List<ExamRegistrationListModel> model,
            bool isThrowError = false);
    }

    public class PatientClinicGroupDetail
    {
        public string ServiceTypeName { get; set; }
        public string ServiceTypeId { get; set; }
        public List<PatientClinicServiceDetail> Services { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string OrderId { get; set; }
        public string OrderLineId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string RegisteredCode { get; set; }
    }

    public class PatientExaminationSummaryDetail
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

    public class PatientExaminationDetail
    {
        public List<PatientClinicGroupDetail> Clinics { get; set; }
        public string RegisteredCode { get; set; }
        public DateTime RegisteredDate { get; set; }
        public PatientViewModel Patient { get; set; }
        public PatientExaminationSummaryDetail Summary { get; set; } = new PatientExaminationSummaryDetail();
    }

    public class PatientClinicServiceDetail
    {
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string OrderId { get; set; }
        public string OrderLineId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string FileAttachName { get; set; }
        public string GroupDeptCode { get; set; }
        public string GroupDeptName { get; set; }
        public List<GetRawExaminationDetailByCodeSubTestResultData> ListSubTestResult { get; set; }
        public string NormalRange1 { get; set; }
        public string NormalRange2 { get; set; }
        public string Note { get; set; }
        public string PatientCode { get; set; }
        public string RegisteredCode { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string FileAttach { get; set; }
    }

    public class PatientExaminationServiceGroupDetail
    {
        public string DepartmentName { get; set; }
        public string BodyPart { get; set; }
        public string ClinicalExamination { get; set; }
        public string Conclusion { get; set; }
        public string DoctorName { get; set; }
        public string FullBodyPart { get; set; }
        public string ICDTenId { get; set; }
        public string InitialDiagnosis { get; set; }
        public string KeyId { get; set; }
        public string ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string Note { get; set; }
        public PatientViewModel Patient { get; set; }
        public string RegisteredCode { get; set; }
        public DateTime RegisteredDate { get; set; }
        public List<PatientExaminationSubTestResultDetail> SubTestResults { get; set; }
        public string OrderId { get; set; }
        public string OrderLineId { get; set; }
        public string DepartmentCode { get; set; }
    }

    public class PatientExaminationSubTestResultDetail
    {
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string NormalRange { get; set; }
        public string Note { get; set; }
    }

    public class PatientExaminationServiceResult
    {
        public string ServiceTypeName { get; set; }
        public string ServiceTypeId { get; set; }
        public List<PatientClinicServiceDetail> Services { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string OrderId { get; set; }
        public string OrderLineId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string RegisteredCode { get; set; }
    }

    public class PatientExaminationServiceResultList
    {
        public List<PatientExaminationServiceResult> Clinics { get; set; }
        public string RegisteredCode { get; set; }
        public DateTime RegisteredDate { get; set; }
        public PatientViewModel Patient { get; set; }
    }

    public class ExamRegistrationListModel
    {
        public string PatientCode { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string DoctorCode { get; set; }

        public string DepartmentCode { get; set; }

        public string BookingId { get; set; }

        public string RegisteredCode { get; set; }

        public PatientType PatientType { get; set; } = PatientType.Normal;

        public string GroupDeptCode { get; set; }
        public string DepartmentName { get; set; }
        public string GroupDeptName { get; set; }
        public string Ip { get; set; }

        public string FeeId { get; set; }
    }
}