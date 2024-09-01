using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class CheckInRequest
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonRequired]
        [JsonProperty("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>
        ///     The table code.
        /// </value>
        [JsonRequired]
        [JsonProperty("table_code")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>
        ///     The table code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the room code.
        /// </summary>
        /// <value>
        ///     The room code.
        /// </value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; }
    }
}