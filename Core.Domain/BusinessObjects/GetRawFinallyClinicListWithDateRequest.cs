using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class GetRawFinallyClinicListWithDateRequest : GetRawFinallyClinicListRequest
    {
        /// <summary>
        ///     Gets or sets the patient date.
        /// </summary>
        /// <value>The patient date.</value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }
    }
}