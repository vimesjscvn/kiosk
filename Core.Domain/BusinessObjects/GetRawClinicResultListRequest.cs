using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class GetRawClinicResultListRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    ///     Class GetClinicListResponse.
    /// </summary>
    public class GetRawClinicResultListResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("result")]
        public List<GetRawClinicResultListResponseData> Result { get; set; }
    }

    /// <summary>
    ///     Class GetClinicListResponseData.
    /// </summary>
    public class GetRawClinicResultListResponseData
    {
        /// <summary>
        ///     Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("result_date")]
        public string ResultDate { get; set; }

        /// <summary>
        ///     Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("service_result")]
        public string ServiceResult { get; set; }

        /// <summary>
        ///     Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("service_code")]
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("service_status")]
        public bool ServiceStatus { get; set; }
    }
}