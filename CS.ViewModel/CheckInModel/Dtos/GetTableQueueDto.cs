using System.Collections.Generic;
using CS.EF.Models;

namespace CS.VM.CheckInModel.Dtos
{
    public class GetTableQueueDto
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public int Type { get; set; }

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

        public string UrlAudio { get; set; }

        public string DepartmentCode { get; set; }

        public string Table { get; set; }

        public int Limit { get; set; }

        public bool IsRecall { get; set; } = false;
    }

    public class GetTableQueueItemDto : GetTableQueueDto
    {
        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public Table Table { get; set; }
    }

    public class GetAllTableQueueDto
    {
        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>
        ///     The result.
        /// </value>
        public List<GetTableQueueItemDto> Result { get; set; } = new List<GetTableQueueItemDto>();

        //[JsonProperty("success")]
        //public bool Success { get; set; }

        //[JsonProperty("code")]
        //public string Code { get; set; }
    }
}