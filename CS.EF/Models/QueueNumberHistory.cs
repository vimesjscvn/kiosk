using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    [Table("queue_number_history", Schema = "IHM")]
    public class QueueNumberHistory : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the old department code.
        /// </summary>
        /// <value>The old department code.</value>
        [Required]
        [StringLength(36)]
        [Column("old_department_code")]
        public string OldDepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the new department code.
        /// </summary>
        /// <value>The new department code.</value>
        [Required]
        [StringLength(36)]
        [Column("new_department_code")]
        public string NewDepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the old date.
        /// </summary>
        /// <value>The old date.</value>
        [Column("old_date")]
        public DateTime OldDate { get; set; } = DateTime.Now;

        /// <summary>
        ///     Gets or sets the new date.
        /// </summary>
        /// <value>The new date.</value>
        [Column("new_date")]
        public DateTime? NewDate { get; set; }

        /// <summary>
        ///     Gets or sets the reason change room.
        /// </summary>
        /// <value>The reason.</value>
        [Column("reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Gets or sets the old number.
        /// </summary>
        /// <value>The old number.</value>
        [Column("old_number")]
        public int OldNumber { get; set; }

        /// <summary>
        ///     Gets or sets the new number.
        /// </summary>
        /// <value>The new number.</value>
        [Column("new_number")]
        public int NewNumber { get; set; }

        /// <summary>
        ///     Gets or sets the registerd code.
        /// </summary>
        /// <value>The registered code.</value>
        [Column("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the is deleted.
        /// </summary>
        /// <value>The is deleted.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets the is deleted.
        /// </summary>
        /// <value>The is deleted.</value>
        [Required]
        [Column("patient_id")]
        public Guid PatientId { get; set; }
    }
}