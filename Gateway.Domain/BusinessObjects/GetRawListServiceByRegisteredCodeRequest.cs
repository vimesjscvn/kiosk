using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class GetRawListServiceByRegisteredCodeRequest
    {
        /// <summary>
        /// GetRaws or sets the hospital code.
        /// </summary>
        /// <value>
        /// The hospital code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    public class GetRawListServiceByRegisteredCodeResponse : BaseRawResponse
    {
        [JsonProperty("result")]
        public GetRawListServiceByRegisteredCodeData Result { get; set; }
    }

    public class GetRawListDepartmentServiceByRegisteredCodeData
    {
        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")]
        public string GroupDeptName { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }
    }

    public class GetRawListOrderByRegisteredCodeData
    {
        [JsonProperty("service_name")]
        public string ServiceName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")]
        public string GroupDeptName { get; set; }

        [JsonProperty("department_type")]
        public int DepartmentType { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("group_service_id")]
        public string GroupServiceId { get; set; }

        [JsonProperty("order_line_id")]
        public int OrderLineId { get; set; }

        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("group_service_name")]
        public string GroupServiceName { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("departments")]
        public List<GetRawListDepartmentServiceByRegisteredCodeData> Departments { get; set; }

        [JsonProperty("examination_code")]
        public string ExaminationCode { get; set; }

        [JsonProperty("examination_name")]
        public string ExaminationName { get; set; }
    }

    public class GetRawListServiceByRegisteredCodeData
    {
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("patient_name")]
        public string PatientName { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("patient_type_id")]
        public string PatientTypeId { get; set; }

        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        [JsonProperty("orders")]
        public List<GetRawListOrderByRegisteredCodeData> Orders { get; set; }
    }
}
