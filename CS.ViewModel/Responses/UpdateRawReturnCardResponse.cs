using Newtonsoft.Json;

namespace CS.VM.Responses
{
    public class UpdateRawReturnCardResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
