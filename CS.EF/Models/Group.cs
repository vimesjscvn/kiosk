using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class ListValueExtend.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("group", Schema = "Dept")]
    public class Group : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        [Column("is_system")]
        public bool IsSystem { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("type")] public string GroupDeptType { get; set; }

        [Column("name")] public string GroupDeptName { get; set; }

        [Column("code")] public string GroupDeptCode { get; set; }

        [Column("address")] public string GroupDeptAddress { get; set; }

        [Column("display_order")] public int DisplayOrder { get; set; }

        [Column("description")] public string Description { get; set; }

        [Column("list_value_id")] public Guid ListValueId { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ListValue ListValue { get; set; }
    }
}