using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    ///     Department Setting
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("department_setting", Schema = "Online")]
    public class DepartmentSetting : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("time_on_minute")]
        public int TimeOnMinute { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("time_active")]
        public string TimeActive { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("age_to")]
        public int AgeTo { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("age_from")]
        public int AgeFrom { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("type_gender")]
        public TypeGender TypeGender { get; set; }

        [Required] [Column("total_number")] public int TotalNumber { get; set; }

        public virtual ListValueExtend Department { get; set; }
    }
}