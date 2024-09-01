using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class PostRawRegisterExamByGroupDataRequest
    {
        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("registered_date")] public DateTime RegisteredDate { get; set; }
    }

    public class PostRawRegisterExamByGroupRequest
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("address")] public string Address { get; set; }

        [JsonProperty("birthday")] public string Birthday { get; set; }

        [JsonProperty("first_name")] public string FirstName { get; set; }

        [JsonProperty("last_name")] public string LastName { get; set; }

        [JsonProperty("gender")] public string Gender { get; set; }

        [JsonProperty("type_exam")] public string TypeExam { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>The health insurance number.</value>
        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>The health insurance expired date.</value>
        [JsonProperty("health_insurance_expired_date")]
        public DateTime HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [JsonProperty("health_insurance_first_place_code")]
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>The health insurance issued date.</value>
        [JsonProperty("health_insurance_issued_date")]
        public DateTime HealthInsuranceIssuedDate { get; set; }

        [JsonProperty("receptions_codes")] public List<string> ReceptionCodes { get; set; }
    }

    public class PostRawRegisterExamByGroupResponseData
    {
        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("patient_name")] public string PatientName { get; set; }

        [JsonProperty("year_of_birth")] public string YearOfBirth { get; set; }

        [JsonProperty("birthday")] public DateTime Birthday { get; set; }

        [JsonProperty("address")] public string Address { get; set; }

        [JsonProperty("detail_address")] public string DetailAddress { get; set; }

        [JsonProperty("gender")] public string Gender { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")] public string GroupDeptName { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("number")] public int Number { get; set; }

        [JsonProperty("registered_date")] public DateTime RegisteredDate { get; set; }

        [JsonProperty("amount")] public double Amount { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("department_address")] public string DepartmentAddress { get; set; }
    }

    public class PostRawRegisterExamByGroupData : BaseRawResponse
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }
    }

    public class PostRawRegisterExamByGroupResultResponse : BaseRawResponse
    {
        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }
    }

    public class PostRawRegisterExamByGroupResponse : BaseRawResponse
    {
        [JsonProperty("result")] public List<PostRawRegisterExamByGroupResponseData> Result { get; set; }
    }
}