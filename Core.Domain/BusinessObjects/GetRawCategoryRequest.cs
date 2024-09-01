using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetRawCategoryRequest
    {
        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonRequired]
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// </summary>
    public class GetRawCategoryResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the thong tin benh nhan.
        /// </summary>
        /// <value>The thong tin benh nhan.</value>
        [JsonProperty("result")]
        public List<GetRawCategoryData> Result { get; set; }
    }

    /// <summary>
    ///     Class FindByCategoryCodeExternalData.
    /// </summary>
    public class GetRawCategoryData
    {
        [JsonProperty("service_id")] public string ServiceId { get; set; }

        [JsonProperty("service_name")] public string ServiceName { get; set; }

        [JsonProperty("service_type_id")] public string ServiceTypeId { get; set; }

        [JsonProperty("service_type_name")] public string ServiceTypeName { get; set; }

        [JsonProperty("unit")] public string Unit { get; set; }

        [JsonProperty("advanced_price")] public decimal? AdvancedPrice { get; set; }

        [JsonProperty("insurance_price")] public decimal? InsurancePrice { get; set; }

        [JsonProperty("vip_price")] public decimal? VipPrice { get; set; }
    }
}