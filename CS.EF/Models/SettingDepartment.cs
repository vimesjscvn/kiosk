using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    [Table("setting_department", Schema = "IHM")]
    public class SettingDepartment : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [Column("type")]
        public DepartmentType Type { get; set; }

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>
        ///     The ip.
        /// </value>
        [Column("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        [Column("code")]
        public string Code { get; set; }
    }
}