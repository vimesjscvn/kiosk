using System.Collections.Generic;
using CS.Common.Common;
using Newtonsoft.Json;

namespace Kiosk.Domain.Models.Requests
{
    /// <summary>
    /// </summary>
    public class QRCodeRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("function_ids")] public List<Functions> FunctionsIds { get; set; } = new List<Functions>();
    }
}