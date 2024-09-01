using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawRegisterReExaminationDataRequest
    {
        [JsonProperty("booking_id")]
        public string BookingId { get; set; }

        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }
    }

    public class PostRawRegisterReExaminationRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        [JsonProperty("health_insurance_issued_date")]
        public DateTime? HealthInsuranceIssuedDate { get; set; }

        [JsonProperty("health_insurance_expired_date")]
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        /// Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [JsonProperty("health_insurance_first_place_code")]
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        /// Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [JsonProperty("health_insurance_first_place")]
        public string HealthInsuranceFirstPlace { get; set; }

        [JsonProperty("departments")]
        public List<PostRawRegisterReExaminationDataRequest> Departments { get; set; }
    }

    public class PostRawRegisterReExaminationResponseData
    {
        [JsonProperty("registered_code")] 
        public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("patient_name")]
        public string PatientName { get; set; }

        [JsonProperty("year_of_birth")]
        public string YearOfBirth { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("detail_address")]
        public string DetailAddress { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")]
        public string GroupDeptName { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        [JsonProperty("department_address")]
        public string DepartmentAddress { get; set; }
    }

    public class PostRawRegisterReExaminationResponse : BaseRawResponse
    {
        [JsonProperty("result")]
        public List<PostRawRegisterReExaminationResponseData> Result { get; set; }
    }
}
