using System;
using CS.Common.Common;

namespace CS.VM.Requests
{
    public class DepartmentServiceRequest : DataTableParameters
    {
        /// <summary>
        ///     Gets or sets the deparment identifier.
        /// </summary>
        /// <value>
        ///     The deparment identifier.
        /// </value>
        public Guid? DeparmentId { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        public Guid? ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        public Guid? RoomId { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        public Guid? ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the usage.
        /// </summary>
        /// <value>
        ///     The type of the usage.
        /// </value>
        public UsageType? UsageType { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public CreatedType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        public string RoomCode { get; set; }


        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        public string ExaminationCode { get; set; }
    }

    public class ExportDepartmentServiceRequest
    {
        /// <summary>
        ///     Gets or sets the deparment identifier.
        /// </summary>
        /// <value>
        ///     The deparment identifier.
        /// </value>
        public Guid? DeparmentId { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        public Guid? ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        public Guid? RoomId { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        public Guid? ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the usage.
        /// </summary>
        /// <value>
        ///     The type of the usage.
        /// </value>
        public UsageType? UsageType { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public CreatedType? Type { get; set; }
    }
}