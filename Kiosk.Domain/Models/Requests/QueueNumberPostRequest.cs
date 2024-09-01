using CS.Common.Common;
using Newtonsoft.Json;

namespace Kiosk.Domain.Models.Requests
{
    /// <summary>
    /// </summary>
    public class QueueNumberPostRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonRequired]
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        //[JsonProperty("department_code")]
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PatientType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}