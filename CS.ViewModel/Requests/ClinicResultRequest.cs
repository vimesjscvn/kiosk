using System;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class ClinicResultRequest
    {
        /// <summary>
        ///     Gets or sets the card number.
        /// </summary>
        /// <value>
        ///     The card number.
        /// </value>
        [JsonRequired]
        public string CardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the requested date.
        /// </summary>
        /// <value>
        ///     The requested date.
        /// </value>
        public DateTime RequestedDate { get; set; }
    }
}