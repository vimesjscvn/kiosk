using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    [Table("history", Schema = "IHM")]
    public class History : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the history identifier.
        /// </summary>
        /// <value>
        ///     The history identifier.
        /// </value>
        [Column("history_id")]
        public Guid HistoryId { get; set; }

        /// <summary>
        ///     Gets or sets the reason.
        /// </summary>
        /// <value>
        ///     The reason.
        /// </value>
        [Column("reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [Column("type")]
        public HistoryType Type { get; set; }

        /// <summary>
        ///     Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        ///     The employee identifier.
        /// </value>
        [Column("employee_id")]
        public Guid? EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the employee.
        /// </summary>
        /// <value>
        ///     The employee.
        /// </value>
        public virtual SysUser Employee { get; set; }
    }
}