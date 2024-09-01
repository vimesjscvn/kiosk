namespace CS.VM.Responses
{
    public class GetLatestNumberResponse
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        public int NormalNumber { get; set; }

        /// <summary>
        ///     Gets or sets the priority number.
        /// </summary>
        /// <value>
        ///     The priority number.
        /// </value>
        public int PriorityNumber { get; set; }

        /// <summary>
        ///     Gets or sets the priority number.
        /// </summary>
        /// <value>
        ///     The priority number.
        /// </value>
        public int ClinicResultNumber { get; set; }

        public string NormalName { get; set; }

        public string PriorityName { get; set; }

        public int NormalAge { get; set; }

        public int PriorityAge { get; set; }

        public string NormalSex { get; set; }

        public string PrioritySex { get; set; }
    }
}