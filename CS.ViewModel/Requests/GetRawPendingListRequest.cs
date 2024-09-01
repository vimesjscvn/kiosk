using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class GetRawPendingListRequest
    {
        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }
    }
}