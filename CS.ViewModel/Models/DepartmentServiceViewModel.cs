using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class DepartmentServiceBase
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
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        [JsonRequired]
        public Guid ServiceId { get; set; }

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
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the type of the usage.
        /// </summary>
        /// <value>
        ///     The type of the usage.
        /// </value>
        public UsageType UsageType { get; set; }
    }

    public class DepartmentServiceViewModel : DepartmentServiceBase
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        /// <value>
        ///     The created date.
        /// </value>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        ///     Gets or sets the updated date.
        /// </summary>
        /// <value>
        ///     The updated date.
        /// </value>
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

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
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public CreatedType Type { get; set; }

        /// <summary>
        ///     Gets or sets the room code.
        /// </summary>
        /// <value>
        ///     The room code.
        /// </value>
        public string RoomCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the room.
        /// </summary>
        /// <value>
        ///     The name of the room.
        /// </value>
        public string RoomName { get; set; }
    }

    /// <summary>
    ///     Class ListValueExtendViewModel.
    ///     Implements the <see cref="ListValueViewModel" />
    /// </summary>
    /// <seealso cref="ListValueViewModel" />
    public class DepartmentOfGroupViewModel : ListValueViewModel
    {
        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [JsonProperty("list_value_id")]
        public Guid? ListValueId { get; set; }

        [JsonProperty("name")] public string DepartmentName { get; set; }

        public Guid DepartmentVirtualId { get; set; }

        public string DepartmentVirtualCode { get; set; }
    }
}