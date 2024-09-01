using Newtonsoft.Json;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawCheckInInfoRequest
    {
        [JsonProperty("temp_code")]
        public string TempCode { get; set; }
    }

    /// <summary>
    /// Class GetAllCalendarResponse.
    /// Implements the <see cref="CS.VM.External.Responses.BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class PostRawCheckInInfoResponse : BaseRawResponse
    {
    }
}
