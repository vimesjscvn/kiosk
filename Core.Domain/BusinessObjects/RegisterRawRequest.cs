using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class RegisterRawRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets career.
        /// </summary>
        /// <value>The career.</value>
        [JsonProperty("clinic_id")]
        public Guid ClinicId { get; set; }
    }

    public class RegisterRawResponse : BaseRawResponse
    {
    }
}