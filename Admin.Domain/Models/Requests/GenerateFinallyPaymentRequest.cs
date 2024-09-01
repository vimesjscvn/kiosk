using Newtonsoft.Json;

namespace Admin.API.Domain.Models.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class GenerateFinallyPaymentRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class GeneratePaymentByRegisteredCodeRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }
}
