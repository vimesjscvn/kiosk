using CS.Common.Common;

namespace CS.VM.Models
{
    /// <summary>
    ///     TableTypeModel
    /// </summary>
    public class TableTypeModel
    {
        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public PriorityType Type { get; set; }
    }
}