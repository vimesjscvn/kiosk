using Newtonsoft.Json;
using System.Xml.Serialization;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseRawResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        [XmlIgnore]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [JsonProperty("status_code")]
        [XmlIgnore]
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("message")]
        [XmlIgnore]
        public string Message { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; } = "0";

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

    }
}
