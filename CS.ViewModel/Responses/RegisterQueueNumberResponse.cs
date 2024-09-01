using System;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.Responses
{
    public class RegisterQueueNumberResponse
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        public DateTime? RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the scheduled time.
        /// </summary>
        /// <value>
        ///     The scheduled time.
        /// </value>
        public string ScheduledTime { get; set; }

        /// <summary>
        ///     Gets or sets the queue number view model.
        /// </summary>
        /// <value>The queue number view model.</value>
        [JsonProperty("data")]
        public QueueNumberViewModel QueueNumberViewModel { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public DateTime? Birthday { get; set; }

        public string RegisteredCode { get; set; }
    }
}