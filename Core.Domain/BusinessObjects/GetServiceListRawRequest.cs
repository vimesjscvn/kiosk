using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetServiceListRawRequest
    {
    }

    /// <summary>
    ///     Class GetAllCalendarResponse.
    ///     Implements the <see cref="CS.VM.External.Responses.BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class GetServiceListRawResponse : BaseRawResponse
    {
        /// <summary>
        ///     Get all Service from hsoft
        /// </summary>
        /// <value>Service List.</value>
        [JsonProperty("data")]
        public List<GetServiceListRawData> Services { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarResponseData.
    /// </summary>
    public class GetServiceListRawData
    {
        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the service group id.
        /// </summary>
        /// <value>The service group id.</value>
        [JsonProperty("service_group_id")]
        public string ServiceGroupId { get; set; }
    }

    /// <summary>
    ///     Class Get all list value extend.
    /// </summary>
    public class GetListServiceFromHisRawData
    {
        /// <summary>
        ///     Gets or sets the service code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("service_code")]
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the service group id.
        /// </summary>
        /// <value>The service group id.</value>
        [JsonProperty("list_value_code")]
        public string ListValueCode { get; set; }
    }

    public class ServiceListFromHisRawData<T>
    {
        [JsonProperty("result")] public List<T> result { get; set; }
    }
}