namespace CS.VM.AuthorizationModels
{
    /// <summary>
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>
        ///     The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>
        ///     The password.
        /// </value>
        public string Password { get; set; }
    }
}