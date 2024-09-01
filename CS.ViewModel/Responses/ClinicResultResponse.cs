using System.Collections.Generic;
using CS.VM.Models;

namespace CS.VM.Responses
{
    public class ClinicResultResponse
    {
        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>
        ///     The patient.
        /// </value>
        public PatientViewModel Patient { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the queue numbers.
        /// </summary>
        /// <value>
        ///     The queue numbers.
        /// </value>
        public List<QueueNumberViewModel> QueueNumbers { get; set; }
    }
}