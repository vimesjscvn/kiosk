using Newtonsoft.Json;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawUpdatePatientInfoRequest : GetRawPatientByCodeData
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
    }

    public class PostRawUpdatePatientInfoResponse : GetRawPatientByCodeData
    {
    }
}
