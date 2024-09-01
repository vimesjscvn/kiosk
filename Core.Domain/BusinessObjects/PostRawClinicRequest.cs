using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class PostRawClinicRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
    }

    /// <summary>
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class PostRawClinicRegistrationResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        [JsonProperty("data")]
        public PostRawClinicRegistrationResponseData Data { get; set; }
    }

    /// <summary>
    ///     Class ClinicPostModel.
    /// </summary>
    public class PostRawClinicRegistrationResponseData
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        [JsonProperty("temp_patient_code")]
        public string TempPatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        //[Required]
        [StringLength(36)]
        [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [StringLength(36)]
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [StringLength(36)]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [StringLength(36)]
        [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        [JsonProperty("money")]
        public decimal Money { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the clinic.
        /// </summary>
        /// <value>The type of the clinic.</value>
        [JsonProperty("clinic_type")]
        public string ClinicType { get; set; }

        /// <summary>
        ///     Gets or sets the is finished.
        /// </summary>
        /// <value>The is finished.</value>
        [JsonProperty("is_finished")]
        public string IsFinished { get; set; }

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        ///     Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        [JsonProperty("examination_code")]
        public string ExaminationCode { get; set; }
    }
}