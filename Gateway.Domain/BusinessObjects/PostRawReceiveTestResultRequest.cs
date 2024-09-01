using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class PostRawReceiveTestResultRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; }
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("com_port")]
        public string COMPort { get; set; }

        [JsonProperty("intrument_id")]
        public int IntrumentId { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("ref_id")]
        public Guid RefId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PostRawReceiveTestResultResponse : BaseRawResponse
    {
    }
}
