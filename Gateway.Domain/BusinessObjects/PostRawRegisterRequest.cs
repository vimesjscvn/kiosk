using Newtonsoft.Json;
using System;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawRegisterRequest
    {
        /// <summary>
        /// Gets or sets the hospital code.
        /// </summary>
        /// <value>
        /// The hospital code.
        /// </value>
        [JsonRequired]
        [JsonProperty("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        /// The type of the patient.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>
        /// The registered code.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>
        /// The registered date.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public string RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the manage code.
        /// </summary>
        /// <value>
        /// The manage code.
        /// </value>
        [JsonRequired]
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        [JsonRequired]
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the doctor code.
        /// </summary>
        /// <value>
        /// The doctor code.
        /// </value>
        [JsonRequired]
        [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [JsonRequired]
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [JsonProperty("table")]
        public string Table { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [JsonProperty("order_line_id")]
        public int OrderLineId { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("group_service_id")]
        public string GroupServiceId { get; set; }

        [JsonProperty("group_service_name")]
        public string GroupServiceName { get; set; }
    }

    public class PostRawRegisterResponse
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
