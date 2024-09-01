namespace Core.Config.Configs
{
    /// <summary>
    /// </summary>
    public class ApiConfig
    {
        /// <summary>
        ///     Gets or sets the secrect.
        /// </summary>
        /// <value>
        ///     The secrect.
        /// </value>
        public string SecretKey { get; set; }

        /// <summary>
        ///     Gets or sets the issuer.
        /// </summary>
        /// <value>
        ///     The issuer.
        /// </value>
        public string Issuer { get; set; }

        /// <summary>
        ///     Gets or sets the audience.
        /// </summary>
        /// <value>
        ///     The audience.
        /// </value>
        public string Audience { get; set; }
    }
}