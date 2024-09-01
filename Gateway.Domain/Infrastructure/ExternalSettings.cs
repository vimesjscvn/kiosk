namespace TEK.Gateway.Domain.Infrastructure
{
    /// <summary>
    /// Class ExternalSettings. This class cannot be inherited.
    /// </summary>
    public sealed class ExternalSettings
    {
        /// <summary>
        /// Gets or sets the external.
        /// </summary>
        /// <value>The external.</value>
        public External External { get; set; }
    }


    /// <summary>
    /// Class External.
    /// </summary>
    public class External
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the find patient URL.
        /// </summary>
        /// <value>The find patient URL.</value>
        public string FindPatientUrl { get; set; }

        /// <summary>
        /// Gets or sets the register patient URL.
        /// </summary>
        /// <value>The register patient URL.</value>
        public string RegisterPatientUrl { get; set; }

        /// <summary>
        /// Gets or sets the find patient by code URL.
        /// </summary>
        /// <value>The find patient by code URL.</value>
        public string FindPatientByCodeUrl { get; set; }

        /// <summary>
        /// Gets or sets the charge clinic URL.
        /// </summary>
        /// <value>The charge clinic URL.</value>
        public string ChargeClinicUrl { get; set; }

        /// <summary>
        /// Gets or sets the get calendar URL.
        /// </summary>
        /// <value>The get calendar URL.</value>
        public string GetCalendarUrl { get; set; }

        /// <summary>
        /// Gets or sets the get all calendar URL.
        /// </summary>
        /// <value>The get all calendar URL.</value>
        public string GetAllCalendarUrl { get; set; }

        /// <summary>
        /// Gets or sets the get clinic URL.
        /// </summary>
        /// <value>The get clinic URL.</value>
        public string GetClinicUrl { get; set; }

        /// <summary>
        /// Gets or sets the get clinic list URL.
        /// </summary>
        /// <value>The get clinic list URL.</value>
        public string GetClinicListUrl { get; set; }

        /// <summary>
        /// Gets or sets the charge list clinic URL.
        /// </summary>
        /// <value>The charge list clinic URL.</value>
        public string ChargeListClinicUrl { get; set; }

        /// <summary>
        /// Gets or sets the get finally clinic list URL.
        /// </summary>
        /// <value>The get finally clinic list URL.</value>
        public string GetFinallyClinicListUrl { get; set; }

        /// <summary>
        /// Gets or sets the charge finally clinic list URL.
        /// </summary>
        /// <value>The charge finally clinic list URL.</value>
        public string ChargeFinallyClinicListUrl { get; set; }

        /// <summary>
        /// Gets or sets the charge clinic list URL.
        /// </summary>
        /// <value>The charge clinic list URL.</value>
        public string ChargeClinicListUrl { get; set; }

        /// <summary>
        /// Gets or sets the get prescription URL.
        /// </summary>
        /// <value>The get prescription URL.</value>
        public string GetPrescriptionUrl { get; set; }

        /// <summary>
        /// Gets or sets the charge finally clinic list at store URL.
        /// </summary>
        /// <value>The charge finally clinic list at store URL.</value>
        public string ChargeFinallyClinicListAtStoreUrl { get; set; }
    }

    /// <summary>
    /// Class ExternalSettingHelper.
    /// </summary>
    public static class ExternalSettingHelper
    {
        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        public static string GetUrl(string host, string url)
        {
            return string.Format("{0}{1}", host, url);
        }
    }
}
