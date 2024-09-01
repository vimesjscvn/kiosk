using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class BaseRawRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
    }
}
