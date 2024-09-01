using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("department_group", Schema = "Dept")]
    public class DepartmentGroup
    {
        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        [Column("department_code")] public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [Column("group_id")]
        public Guid GroupId { get; set; }

        [Column("group_code")] public string GroupCode { get; set; }

        [Column("is_room_active")] public bool IsRoomActive { get; set; }

        [Column("department_virtual_id")] public Guid DepartmentVirtualId { get; set; }

        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [Column("list_value_extend_id")]
        public Guid ListValueExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual ListValueExtend ListValueExtend { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual Department DepartmentVirtual { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual Group Group { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual Department Department { get; set; }
    }
}