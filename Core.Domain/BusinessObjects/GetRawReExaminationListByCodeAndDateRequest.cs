using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class GetRawReExaminationListByCodeAndDateRequest
    {
        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; } = string.Empty;

        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; } = string.Empty;

        [JsonProperty("identity_card_number")] public string IdentityCardNumber { get; set; } = string.Empty;

        [JsonProperty("registered_date")] public DateTime? RegisteredDate { get; set; }

        [JsonProperty("start_date")] public DateTime? StartDate { get; set; }

        [JsonProperty("end_date")] public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// </summary>
    public class GetRawReExaminationListByCodeAndDateResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the thong tin benh nhan.
        /// </summary>
        /// <value>The thong tin benh nhan.</value>
        [JsonProperty("result")]
        public List<GetRawReExaminationListByCodeAndDateResponseData> Result { get; set; }
    }

    /// <summary>
    ///     Class FindByReExaminationByRegisteredCodeCodeExternalData.
    /// </summary>
    public class GetRawReExaminationListByCodeAndDateResponseData
    {
        [JsonProperty("booking_id")] public string BookingId { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("doctor_code")] public string DoctorCode { get; set; }

        [JsonProperty("doctor_name")] public string DoctorName { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")] public string GroupDeptName { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("registered_date")] public DateTime RegisteredDate { get; set; }

        [JsonProperty("is_have_clinic")] public string IsHaveClinic { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("status_code")] public string StatusCode { get; set; }

        [JsonProperty("status_name")] public string StatusName { get; set; }

        [JsonProperty("departments")]
        public List<GetRawReExaminationListByCodeAndDateDepartmentResponseData> Departments { get; set; }
    }

    public class GetRawReExaminationListByCodeAndDateDepartmentResponseData
    {
        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("max_number")] public string MaxNumber { get; set; }

        [JsonProperty("waiting_number")] public string WaitingNumber { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }
    }
}