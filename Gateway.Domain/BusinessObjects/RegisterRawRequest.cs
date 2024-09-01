using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class RegisterRawRequest:BaseRawRequest
    {

        /// <summary>
        /// Gets or sets career.
        /// </summary>
        /// <value>The career.</value>
        [JsonProperty("clinic_id")]
        public Guid ClinicId { get; set; } 
    }

    public class RegisterRawResponse : BaseRawResponse
    {

    }
}
