using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class ClinicResultByExaminationRequest
    {
        /// <summary>
        ///     Gets or sets the card number.
        /// </summary>
        /// <value>
        ///     The card number.
        /// </value>
        [JsonRequired]
        [JsonProperty("examination_ids")]
        public List<string> ExaminationIds { get; set; }

        /// <summary>
        ///     Gets or sets the card number.
        /// </summary>
        /// <value>
        ///     The card number.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
    }
}