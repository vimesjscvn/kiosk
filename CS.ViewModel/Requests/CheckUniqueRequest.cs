using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class CheckUniqueRequest
    {
        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        [JsonRequired]
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        [JsonRequired]
        public Guid RoomId { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [JsonRequired]
        public Guid ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        [JsonRequired]
        public Guid ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the usage.
        /// </summary>
        /// <value>
        ///     The type of the usage.
        /// </value>
        [JsonRequired]
        public UsageType UsageType { get; set; }
    }
}