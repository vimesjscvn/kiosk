using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("department_type", Schema = "ListMgmt")]
    public class DepartmentTypeCLS
    {
        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [Column("list_value_extend_id")]
        public Guid ListValueExtendId { get; set; }

        [Column("list_value_id")] public Guid ListValueId { get; set; }

        [Column("list_value_code")] public string ListValueCode { get; set; }

        [Column("list_value_extend_code")] public string ListValueExtendCode { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual ListValue ListValue { get; set; }

        public virtual ListValueExtend ListValueExtend { get; set; }
    }
}