using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetTitleListRawRequest
    {
    }

    /// <summary>
    ///     Class GetAllCalendarResponse.
    ///     Implements the <see cref="CS.VM.External.Responses.BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class GetTitleListRawResponse : BaseRawResponse
    {
        /// <summary>
        ///     Get all title from hsoft
        /// </summary>
        /// <value>Title List.</value>
        [JsonProperty("data")]
        public List<GetTitleListRawData> Titles { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarResponseData.
    /// </summary>
    public class GetTitleListRawData
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
    }
}