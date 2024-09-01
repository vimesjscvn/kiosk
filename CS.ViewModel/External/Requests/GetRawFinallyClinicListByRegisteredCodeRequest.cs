using Newtonsoft.Json;

namespace CS.VM.External.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRawFinallyClinicListByRegisteredCodeRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        public string RegisteredCode { get; set; }
    }
}
