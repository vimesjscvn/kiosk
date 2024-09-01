using System;
using CS.Base.ViewModels;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class ReceptionViewModel : BaseViewModel
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        /// <summary>
        ///     Gets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        [JsonProperty("patient_id")]
        public Guid? PatientId { get; set; }

        /// <summary>
        ///     Gets the type of the patient.
        /// </summary>
        /// <value>
        ///     The type of the patient.
        /// </value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonProperty("status")]
        public ReceptionStatus Status { get; set; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [JsonProperty("type")]
        public ReceptionType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the is finished.
        /// </summary>
        /// <value>The is finished.</value>
        [JsonProperty("is_finished")]
        public bool IsFinished { get; set; }

        [JsonProperty("patient_name")] public string PatientName { get; set; }
    }

    /// <summary>
    /// </summary>
    public class GetOrAddIfNotExistedData
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        /// <summary>
        ///     Gets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        [JsonProperty("patient_id")]
        public Guid? PatientId { get; set; }

        /// <summary>
        ///     Gets the type of the patient.
        /// </summary>
        /// <value>
        ///     The type of the patient.
        /// </value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }
    }

    /// <summary>
    /// </summary>
    /// <seealso cref="CS.VM.Models.ReceptionViewModel" />
    public class ReceptionReportViewModel : ReceptionViewModel
    {
        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        /// <value>
        ///     The created date.
        /// </value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the reason.
        /// </summary>
        /// <value>
        ///     The reason.
        /// </value>
        public string Reason { get; set; }

        /// <summary>
        ///     Gets or sets the birthday year only .
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public bool BirthdayYearOnly { get; set; }
    }
}