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
    [Table("list_number_online_detail", Schema = "Online")]
    public class ListNumberOnlineDetail : BaseObject
    {
        /// <summary>
        ///     Gets or sets the list number online id
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [Column("list_number_online_id")]
        public Guid ListNumberOnlineId { get; set; }

        public virtual ListNumberOnline ListNumberOnline { get; set; }

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
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The time start.</value>
        [Required]
        [Column("number")]
        public int Number { get; set; }
    }
}