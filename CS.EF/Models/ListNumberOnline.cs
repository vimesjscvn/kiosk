using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Switch Board Department Time Slot
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("list_number_online", Schema = "Online")]
    public class ListNumberOnline : BaseObject
    {
        /// <summary>
        ///     Gets or sets the department id.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        [Required]
        [Column("start_time")]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("end_time")]
        public TimeSpan EndTime { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        [Required]
        [Column("start_number")]
        public int StartNumber { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        [Required]
        [Column("end_number")]
        public int EndNumber { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        [Required]
        [Column("name")]
        public string Name { get; set; }
    }

    public class ListNumberOnlineLimit
    {
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public TimeSpan? EndTime { get; set; }
    }
}