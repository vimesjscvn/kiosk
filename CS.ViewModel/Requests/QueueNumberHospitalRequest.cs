using System;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class QueueNumberHospitalRequest : DataTableParameters
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonRequired]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        public DateTime? RegisteredDate { get; set; }
    }

    public class QueueNumberHospitalExportRequest
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonRequired]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        public DateTime? RegisteredDate { get; set; }
    }
}