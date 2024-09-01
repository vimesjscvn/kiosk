using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    [Table("setting", Schema = "IHM")]
    public class Setting : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        [Column("key")]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [Column("value", TypeName = "jsonb")]
        public string Value { get; set; }
    }
}