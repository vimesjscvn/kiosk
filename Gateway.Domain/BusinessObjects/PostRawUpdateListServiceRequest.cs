using Newtonsoft.Json;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawUpdateListServiceRequest
    {
        /// <summary>
        /// Gets or sets the clinics.
        /// </summary>
        /// <value>
        /// The clinics.
        /// </value>
        [JsonRequired]
        [JsonProperty("orders")]
        public List<PostRawUpdateListServiceModel> Orders { get; set; } = new List<PostRawUpdateListServiceModel>();
    }

    public class PostRawUpdateListServiceModel
    {
        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("group_service_id")]
        public string GroupServiceId { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("order_line_id")]
        public int OrderLineId { get; set; }

        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PostRawUpdateListServiceResponse : BaseRawResponse
    {
    }
}
