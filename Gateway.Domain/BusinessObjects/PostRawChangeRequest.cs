using Newtonsoft.Json;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawChangeRequest
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
        /// Gets or sets the manage code.
        /// </summary>
        /// <value>
        /// The manage code.
        /// </value>
        [JsonRequired]
        [JsonProperty("management_id")]
        public string ManagementId { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>
        /// The registered date.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public string RequestedDate { get; set; }

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
        [JsonRequired]
        [JsonProperty("examination_code")]
        public string ExaminationCode { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        [JsonRequired]
        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        [JsonRequired]
        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonRequired]
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ClinicWithPatientPostModel"/> is priority.
        /// </summary>
        /// <value><c>true</c> if priority; otherwise, <c>false</c>.</value>
        [JsonProperty("priority")]
        public bool Priority { get; set; }

        /// <summary>
        /// Gets or sets the type of the priority.
        /// </summary>
        /// <value>The type of the priority.</value>
        [JsonProperty("priority_type")]
        public string PriorityType { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonRequired]
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [JsonRequired]
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }

    public class PostRawChangeResponse
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
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
