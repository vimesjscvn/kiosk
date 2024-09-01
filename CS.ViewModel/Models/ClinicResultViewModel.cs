namespace CS.VM.Models
{
    public class ClinicResultViewModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the result date.
        /// </summary>
        /// <value>
        ///     The result date.
        /// </value>
        public string ResultDate { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the age.
        /// </summary>
        /// <value>
        ///     The age.
        /// </value>
        public int Age { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public string Gender { get; set; }
    }
}