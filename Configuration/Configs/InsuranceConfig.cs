namespace Core.Config.Configs
{
    /// <summary>
    ///     Class Insurance.
    /// </summary>
    public class InsuranceConfig
    {
        /// <summary>
        ///     Gets or sets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl { get; set; }

        /// <summary>
        ///     Gets or sets the find patient URL.
        /// </summary>
        /// <value>The find patient URL.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the register patient URL.
        /// </summary>
        /// <value>The register patient URL.</value>
        public string Password { get; set; }
        public string LoginUrl { get; set; }
        public string VerifyUrl { get; set; }
        public string Version { get; set; }
        public string BaseUrlV1 { get; set; }
        public string LoginUrlV1 { get; set; }
        public string VerifyUrlV1 { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeIdentiyCard { get; set; }
    }
}