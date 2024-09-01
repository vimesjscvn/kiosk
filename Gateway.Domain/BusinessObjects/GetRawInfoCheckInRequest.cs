using Newtonsoft.Json;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class GetRawInfoCheckInRequest
    {
        [JsonProperty("MaCoSo")]
        public string HospitalCode { get; set; }
    }

    /// <summary>
    /// Class GetAllCalendarResponse.
    /// Implements the <see cref="CS.VM.External.Responses.BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class GetRawInfoCheckInResponse : BaseRawResponse
    {
        public List<GetRawInfoCheckInResult> Result { get; set; }
    }

    public class GetRawInfoCheckInResult
    {
        public string user { get; set; }
        public string password { get; set; }
    }
}
