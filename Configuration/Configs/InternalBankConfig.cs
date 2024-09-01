namespace Core.Config.Configs
{
    /// <summary>
    /// </summary>
    public class InternalBankConfig
    {
        /// <summary>
        ///     Gets or sets the base URL.
        /// </summary>
        /// <value>
        ///     The base URL.
        /// </value>
        public string BaseUrl { get; set; }

        /// <summary>
        ///     Gets or sets the create URL.
        /// </summary>
        /// <value>
        ///     The create URL.
        /// </value>
        public string CreatePaymentUrl { get; set; }

        /// <summary>
        ///     Gets or sets the authorization payment URL.
        /// </summary>
        /// <value>
        ///     The authorization payment URL.
        /// </value>
        public string AuthorizationPaymentUrl { get; set; }
    }
}