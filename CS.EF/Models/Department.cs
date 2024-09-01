using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class ListValueExtend.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("department", Schema = "Dept")]
    public class Department
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Column("created_by")]
        public string CreatedBy { get; set; } = "System";

        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        ///     Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Column("updated_by")]
        public string UpdatedBy { get; set; } = "System";

        /// <summary>
        ///     Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

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

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("url_audio")]
        public string UrlAudio { get; set; }

        [Column("address")] public string DepartmentAddress { get; set; }

        [Column("type")] public string DepartmentType { get; set; }

        [Column("name")] public string DepartmentName { get; set; }

        [Column("code")] public string DepartmentCode { get; set; }

        [Column("group_dept_code")] public string GroupDeptCode { get; set; }

        [Column("group_dept_name")] public string GroupDeptName { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>The examination identifier.</value>
        [Column("list_value_extend_id")]
        public Guid ListValueExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>The examination identifier.</value>
        [Column("group_id")]
        public Guid? GroupId { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual ListValueExtend ListValueExtend { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual Group Group { get; set; }
    }
}