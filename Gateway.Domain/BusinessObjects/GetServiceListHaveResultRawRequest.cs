using Newtonsoft.Json;
using System;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class GetServiceListResultRawRequest : BaseRawRequest
    {
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>The date.</value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

    }

    public class GetServiceResultRawResponse
    {
            /// <summary>
        /// Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        /// Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("result_date")]
        public string ResultDate { get; set; }

        /// <summary>
        /// Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("service_result")]
        public string ServiceResult { get; set; }

        /// <summary>
        /// Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("service_code")]
        public string ServiceCode { get; set; }

        /// <summary>
        /// Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("service_status")]
        public bool ServiceStatus { get; set; }
    }
}
