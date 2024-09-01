namespace CS.VM.CheckInModel.Dtos
{
    public class CallTablePatientDto
    {
        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        ///     Gets or sets from.
        /// </summary>
        /// <value>
        ///     From.
        /// </value>
        public int From { get; set; }

        /// <summary>
        ///     Gets or sets to.
        /// </summary>
        /// <value>
        ///     To.
        /// </value>
        public int To { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public int Type { get; set; }

        public string UrlAudio { get; set; }

        public string DepartmentCode { get; set; }

        public string TempCode { get; set; }

        public string RegisteredCode { get; set; }

        public int Limit { get; set; }
    }
}