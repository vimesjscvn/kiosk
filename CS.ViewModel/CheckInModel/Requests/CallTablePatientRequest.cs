using System;
using Core.Domain.BusinessObjects;

namespace CS.VM.CheckInModel.Requests
{
    public class CallTablePatientRequest
    {
        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public int Limit { get; set; }

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>
        ///     The ip.
        /// </value>
        public string Ip { get; set; }

        /// <summary>
        ///     Gets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public CallOrderNumberPriorityType? Type { get; set; }

        public string AreaCode { get; set; }
    }
}