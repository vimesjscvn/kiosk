using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetDistrictListRawRequest
    {

    }

    /// <summary>
    /// Class GetAllCalendarResponse.
    /// Implements the <see cref="CS.VM.External.Responses.BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class GetDistrictListRawResponse : BaseRawResponse
    {
        /// <summary>
        /// Get all District from hsoft
        /// </summary>
        /// <value>District List.</value>
        [JsonProperty("data")]
        public List<GetDistrictListRawData> Districts { get; set; }
    }

    /// <summary>
    /// Class GetAllCalendarResponseData.
    /// </summary>
    public class GetDistrictListRawData
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the province id.
        /// </summary>
        /// <value>The province id.</value>
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }
    }
}
