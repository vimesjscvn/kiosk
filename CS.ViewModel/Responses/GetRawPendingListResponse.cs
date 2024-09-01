using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Responses
{
    public class GetRawPendingListData
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("order_number")] public string OrderNumber { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("age")] public string Age { get; set; }

        [JsonProperty("gender")] public int Gender { get; set; }

        [JsonProperty("waiting_patient")] public List<GetRawPendingListPatientData> WaitingPatient { get; set; }

        [JsonProperty("missing_patient")] public List<GetRawPendingListPatientData> MissingPatient { get; set; }
    }

    public class GetRawPendingListPatientData
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("order_number")] public string OrderNumber { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("age")] public string Age { get; set; }

        [JsonProperty("gender")] public int Gender { get; set; }
    }

    public class GetRawPendingListResponse
    {
        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error_code")] public string ErrorCode { get; set; } = "0";

        [JsonProperty("error_message")] public string ErrorMessage { get; set; }

        public GetRawPendingListData Result { get; set; }
    }
}