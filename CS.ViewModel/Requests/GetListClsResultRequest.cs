using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class GetListClsResultRequest
    {
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonRequired]
        [JsonProperty("registered_codes")]
        public List<string> RegisteredCodes { get; set; }
    }
}