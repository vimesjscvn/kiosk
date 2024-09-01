using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class GetRawExaminationDetailByCodeRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }
    }

    public class GetRawExaminationDetailByCodePrescriptionData
    {
        [JsonProperty("prescription_id")] public string PrescriptionId { get; set; }

        [JsonProperty("order_date")] public DateTime OrderDate { get; set; }

        [JsonProperty("doctor")] public string Doctor { get; set; }

        [JsonProperty("advice")] public string Advice { get; set; }

        [JsonProperty("medicines")] public List<GetRawExaminationDetailByCodeMedicineDetailData> Medicines { get; set; }

        [JsonProperty("doctor_name")] public string DoctorName { get; set; }

        [JsonProperty("doctor_id")] public string DoctorCode { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("group_dept_name")] public string GroupDeptName { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }
    }

    public class GetRawExaminationDetailByCodeExaminationData
    {
        [JsonProperty("key_id")] public string KeyId { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("doctor_name")] public string DoctorName { get; set; }

        [JsonProperty("clinical_examination")] public string ClinicalExamination { get; set; }

        [JsonProperty("full_body_part")] public string FullBodyPart { get; set; }

        [JsonProperty("body_part")] public string BodyPart { get; set; }

        [JsonProperty("initial_diagnosis")] public string InitialDiagnosis { get; set; }

        [JsonProperty("icd_ten_id")] public string ICDTenId { get; set; }

        [JsonProperty("conclusion")] public string Conclusion { get; set; }
    }

    public class GetRawExaminationDetailByCodeSubTestResultData
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("service_type_id")] public string ServiceTypeId { get; set; }

        [JsonProperty("service_type_name")] public string ServiceTypeName { get; set; }

        [JsonProperty("service_id")] public string ServiceId { get; set; }

        [JsonProperty("parent_service_id")] public string ParentServiceId { get; set; }

        [JsonProperty("order_id")] public string OrderId { get; set; }

        [JsonProperty("order_line_id")] public string OrderLineId { get; set; }

        [JsonProperty("service_name")] public string ServiceName { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("result")] public string Result { get; set; }

        [JsonProperty("note")] public string Note { get; set; }

        [JsonProperty("normal_range1")] public string NormalRange1 { get; set; }

        [JsonProperty("normal_range2")] public string NormalRange2 { get; set; }

        [JsonProperty("unit")] public string Unit { get; set; }

        [JsonProperty("file_attach")] public string FileAttach { get; set; }

        [JsonProperty("file_attach_name")] public string FileAttachName { get; set; }
    }

    public class GetRawExaminationDetailByCodeTestResultData
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("service_type_id")] public string ServiceTypeId { get; set; }

        [JsonProperty("service_type_name")] public string ServiceTypeName { get; set; }

        [JsonProperty("service_id")] public string ServiceId { get; set; }

        [JsonProperty("order_id")] public string OrderId { get; set; }

        [JsonProperty("order_line_id")] public string OrderLineId { get; set; }

        [JsonProperty("service_name")] public string ServiceName { get; set; }

        [JsonProperty("result")] public string Result { get; set; }

        [JsonProperty("note")] public string Note { get; set; }

        [JsonProperty("normal_range1")] public string NormalRange1 { get; set; }

        [JsonProperty("normal_range2")] public string NormalRange2 { get; set; }

        [JsonProperty("unit")] public string Unit { get; set; }

        [JsonProperty("file_attach")] public string FileAttach { get; set; }

        [JsonProperty("file_attach_name")] public string FileAttachName { get; set; }

        [JsonProperty("list_sub_test_results")]
        public List<GetRawExaminationDetailByCodeSubTestResultData> ListSubTestResult { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")] public string GroupDeptName { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("doctor_id")] public string DoctorCode { get; set; }

        [JsonProperty("doctor_name")] public string DoctorName { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }
    }

    public class GetRawExaminationDetailByCodeMedicineDetailData
    {
        [JsonProperty("medicine_id")] public string MedicineId { get; set; }

        [JsonProperty("medicine")] public string MedicineName { get; set; }

        [JsonProperty("unit")] public string Unit { get; set; }

        [JsonProperty("quantity")] public string Quantity { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }

    public class GetRawExaminationDetailByCodeData
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("age")] public string Age { get; set; }

        [JsonProperty("birthday")] public string Birthday { get; set; }

        [JsonProperty("gender")] public string Gender { get; set; }

        [JsonProperty("nation")] public string Nation { get; set; }

        [JsonProperty("job")] public string Job { get; set; }

        [JsonProperty("workplace")] public string Workplace { get; set; }

        [JsonProperty("street")] public string Street { get; set; }

        [JsonProperty("province")] public string Province { get; set; }

        [JsonProperty("district")] public string District { get; set; }

        [JsonProperty("ward")] public string Ward { get; set; }

        [JsonProperty("address")] public string Address { get; set; }

        [JsonProperty("identity_card_number")] public string IdentityCardNumber { get; set; }

        [JsonProperty("examinations")]
        public List<GetRawExaminationDetailByCodeExaminationData> Examinations { get; set; }

        [JsonProperty("test_results")]
        public List<GetRawExaminationDetailByCodeTestResultData> TestResults { get; set; }

        [JsonProperty("prescriptions")]
        public List<GetRawExaminationDetailByCodePrescriptionData> Prescriptions { get; set; }
    }

    public class GetRawExaminationDetailByCodeResponse : BaseRawResponse
    {
        [JsonProperty("result")] public GetRawExaminationDetailByCodeData Result { get; set; }
    }
}