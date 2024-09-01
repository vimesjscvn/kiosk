using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class GetRawFinallyPrescriptionListRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime? RegisteredDate { get; set; }
    }

    /// <summary>
    ///     Class GetPrescriptionResponse.
    /// </summary>
    public class GetRawFinallyPrescriptionListResponse : BaseRawResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetPrescriptionResponse" /> class.
        /// </summary>
        public GetRawFinallyPrescriptionListResponse()
        {
            DanhSachBHYT = new List<GetRawFinallyPrescriptionListResponseData>();
        }

        /// <summary>
        ///     Gets or sets the danh sach bhyt.
        /// </summary>
        /// <value>The danh sach bhyt.</value>
        public List<GetRawFinallyPrescriptionListResponseData> DanhSachBHYT { get; set; }
    }

    /// <summary>
    ///     Class GetPrescriptionResponseData.
    /// </summary>
    public class GetRawFinallyPrescriptionListResponseData : GetRawListPrescriptionResponseData
    {
    }
}