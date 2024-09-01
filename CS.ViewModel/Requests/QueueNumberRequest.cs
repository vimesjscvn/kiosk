using System;
using System.ComponentModel.DataAnnotations;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class QueueNumberPostModel.
    /// </summary>
    public class QueueNumberRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [StringLength(36)]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonRequired]
        [StringLength(36)]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PatientType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonRequired]
        public string HospitalCode { get; set; }

        [JsonRequired] public DateTime RegisteredDate { get; set; }
    }
}