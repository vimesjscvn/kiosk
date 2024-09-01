using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.CheckInModel.Requests
{
    public class GetPatientsInQueueRequest
    {
        /// <summary>
        ///     Gets or sets the room.
        /// </summary>
        /// <value>
        ///     The room.
        /// </value>
        public string Room { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public int Limit { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public PatientType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public int? Status { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class GetPatientsInQueueV2Request
    {
        /// <summary>
        ///     Gets or sets the room.
        /// </summary>
        /// <value>
        ///     The room.
        /// </value>
        [JsonRequired]
        public Guid Room { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        [JsonRequired]
        public int Limit { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public PatientType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public int? Status { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; } = DateTime.Now;
    }
}