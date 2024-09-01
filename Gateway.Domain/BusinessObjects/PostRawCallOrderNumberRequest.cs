using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawCallOrderNumberResponse
    {
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        public string Table { get; set; }
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public int From { get; set; }
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public int To { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }

        public string UrlAudio { get; set; }
        public string TempCode { get; set; }
        public string RegisteredCode { get; set; }

        public string DepartmentCode { get; set; }

        public string GroupDeptCode { get; set; }
    }

    public class PostRawCallOrderNumberRequest
    {
        public string HospitalCode { get; set; }
        public string Table { get; set; }
        public int Limit { get; set; }
        public string Ip { get; set; }
        public Guid UserId { get; set; }
        public string AreaCode { get; set; }
        public CallOrderNumberPriorityType? Type { get; set; }
    }

    /// <summary>
    /// Priority Type
    /// </summaryPriorityType
    public enum CallOrderNumberPriorityType
    {
        /// <summary>
        /// The Normal
        /// </summary>
        Normal,
        /// <summary>
        /// The priority
        /// </summary>
        Priority
    }
}
