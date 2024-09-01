using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.CheckInModel.Requests
{
    public class CallPatientRequest
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
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [JsonRequired]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public PatientType Type { get; set; }

        /// <summary>
        ///     Gets or sets the room.
        /// </summary>
        /// <value>
        ///     The room.
        /// </value>
        public string DepartmentCode { get; set; }
    }


    public class CallPatientClinicResultRequest
    {
        /// <summary>
        ///     Gets or sets the room.
        /// </summary>
        /// <value>
        ///     The room.
        /// </value>
        [JsonRequired]
        public string Room { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [JsonRequired]
        public int Number { get; set; }
    }
}