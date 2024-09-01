using Newtonsoft.Json;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawUpdateResultListServiceRequest
    {
        /// <summary>
        /// Gets or sets the result datas.
        /// </summary>
        /// <value>
        /// The result datas.
        /// </value>
        [JsonRequired]
        [JsonProperty("Data")]
        public List<UpdateRawResultData> ResultDatas { get; set; }
    }

    public class UpdateRawResultData
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        [JsonRequired]
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        [JsonRequired]
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        [JsonRequired]
        [JsonProperty("requested_date")]
        public string RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("registered_code")]
        public int RegisteredCode { get; set; }

        [JsonProperty("patient_code")]
        public int PatientCode { get; set; }

        [JsonProperty("group_service_id")]
        public string GroupServiceId { get; set; }

        [JsonProperty("order_Id")]
        public int OrderId { get; set; }

        [JsonProperty("order_line_Id")]
        public int OrderLineId { get; set; }
    }

    public class PostRawUpdateResultListServiceResponse
    {
    }
}
