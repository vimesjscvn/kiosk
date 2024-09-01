using System.Collections.Generic;

namespace CS.VM.Models
{
    public class ImportDepartmentServiceModel
    {
        /// <summary>
        ///     Gets or sets the service code.
        /// </summary>
        /// <value>
        ///     The service code.
        /// </value>
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the service.
        /// </summary>
        /// <value>
        ///     The name of the service.
        /// </value>
        public string ServiceName { get; set; }

        /// <summary>
        ///     Gets or sets the room code.
        /// </summary>
        /// <value>
        ///     The room code.
        /// </value>
        public string GroupDeptCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the room.
        /// </summary>
        /// <value>
        ///     The name of the room.
        /// </value>
        public string GroupDeptName { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the examination code.
        /// </summary>
        /// <value>
        ///     The examination code.
        /// </value>
        public string ExaminationCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the examination.
        /// </summary>
        /// <value>
        ///     The name of the examination.
        /// </value>
        public string ExaminationName { get; set; }

        /// <summary>
        ///     Gets or sets the type of the usage.
        /// </summary>
        /// <value>
        ///     The type of the usage.
        /// </value>
        public string UsageType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ImportDepartmentServiceModel" /> is status.
        /// </summary>
        /// <value>
        ///     <c>true</c> if status; otherwise, <c>false</c>.
        /// </value>
        public bool Status { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public List<string> Message { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        /// <value>
        ///     The note.
        /// </value>
        public List<string> Note { get; set; }
    }
}