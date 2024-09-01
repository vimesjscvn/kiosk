using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class ChargerFinallyClinicListRawRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the patient date.
        /// </summary>
        /// <value>The patient date.</value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [Required]
        [StringLength(36)]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }
}