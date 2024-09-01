using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class GetRawListGroupDeptRequest
    {
        /// <summary>
        /// Gets or sets the hospital code.
        /// </summary>
        /// <value>
        /// The hospital code.
        /// </value>
        [JsonProperty("group_dept_type")]
        public string GroupDeptType { get; set; }
    }

    public class GetRawListGroupDeptResponse : BaseRawResponse
    {
        [JsonProperty("Result")]
        public List<GetRawListGroupDeptData> Result { get; set; }
    }

    public class GetRawListDepartmentData
    {
        [JsonProperty("department_code")]
        public int DepartmentCode { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("department_type")]
        public string DepartmentType { get; set; }

        [JsonProperty("department_address")]
        public string DepartmentAddress { get; set; }
    }

    public class GetRawListGroupDeptData
    {
        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")]
        public string GroupDeptName { get; set; }

        [JsonProperty("group_dept_type")]
        public string GroupDeptType { get; set; }

        [JsonProperty("group_dept_address")]
        public string GroupDeptAddress { get; set; }

        [JsonProperty("departments")]
        public List<GetRawListDepartmentData> Departments { get; set; }
    }
}
