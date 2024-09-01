using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     User Profile
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("switch_board_department", Schema = "Online")]
    public class SwitchBoardDepartment : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the department id.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        public virtual ListValueExtend Department { get; set; }

        [Required] [Column("total_number")] public int TotalNumber { get; set; }
    }
}