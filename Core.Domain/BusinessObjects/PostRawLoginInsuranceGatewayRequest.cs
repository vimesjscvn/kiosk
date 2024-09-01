using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class PostRawLoginInsuranceGatewayRequest
    {
        [JsonProperty("username")] public string username { get; set; }

        [JsonProperty("password")] public string password { get; set; }
    }

    public class PostRawLoginInsuranceGatewayAPIKey
    {
        [JsonProperty("access_token")] public string access_token { get; set; }

        [JsonProperty("id_token")] public string id_token { get; set; }

        [JsonProperty("token_type")] public string token_type { get; set; }

        [JsonProperty("username")] public string username { get; set; }

        [JsonProperty("expires_in")] public DateTime expires_in { get; set; }
    }

    public class PostRawLoginInsuranceGatewayResponse
    {
        [JsonProperty("maKetQua")] public string maKetQua { get; set; }

        [JsonProperty("APIKey")] public PostRawLoginInsuranceGatewayAPIKey APIKey { get; set; }
    }
}