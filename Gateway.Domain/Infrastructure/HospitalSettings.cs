namespace TEK.Gateway.Domain.Infrastructure
{
    /// <summary>
    /// Class HospitalSettings. This class cannot be inherited.
    /// </summary>
    public sealed class HospitalSettings
    {
        /// <summary>
        /// Gets or sets the hospital.
        /// </summary>
        /// <value>The hospital.</value>
        public Hospital Hospital { get; set; }
    }

    /// <summary>
    /// Class Hospital.
    /// </summary>
    public class Hospital
    {
        /// <summary>
        /// Gets or sets the hospital code.
        /// </summary>
        /// <value>The hospital code.</value>
        public string HospitalCode { get; set; }

        /// <summary>
        /// Gets or sets the hospital area.
        /// </summary>
        /// <value>The hospital area.</value>
        public string HospitalArea { get; set; }

        /// <summary>
        /// Gets or sets the temporary patient code.
        /// </summary>
        /// <value>The temporary patient code.</value>
        public string TempPatientCode { get; set; }

        /// <summary>
        /// Gets or sets the card fee.
        /// </summary>
        /// <value>The card fee.</value>
        public int CardFee { get; set; }
    }
}
