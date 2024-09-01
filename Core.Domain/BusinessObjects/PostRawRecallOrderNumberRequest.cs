using System;

namespace Core.Domain.BusinessObjects
{
    public class PostRawRecallOrderNumberResponse
    {
        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        ///     Gets or sets from.
        /// </summary>
        /// <value>
        ///     From.
        /// </value>
        public int From { get; set; }

        /// <summary>
        ///     Gets or sets to.
        /// </summary>
        /// <value>
        ///     To.
        /// </value>
        public int To { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public int Type { get; set; }

        public string UrlAudio { get; set; }
        public string TempCode { get; set; }
        public string RegisteredCode { get; set; }

        public string DepartmentCode { get; set; }

        public string GroupDeptCode { get; set; }

        public bool IsRecall { get; set; } = true;
    }

    public class PostRawRecallOrderNumberRequest
    {
        public string HospitalCode { get; set; }
        public string Table { get; set; }
        public int Limit { get; set; }
        public string Ip { get; set; }
        public Guid UserId { get; set; }
        public string AreaCode { get; set; }
        public CallOrderNumberPriorityType? Type { get; set; }
        public int Number { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}