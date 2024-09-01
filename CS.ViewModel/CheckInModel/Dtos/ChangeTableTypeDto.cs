namespace CS.VM.CheckInModel.Dtos
{
    public class ChangeTableTypeDto
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
        public int Type { get; set; }

        public int Limit { get; set; }
    }
}