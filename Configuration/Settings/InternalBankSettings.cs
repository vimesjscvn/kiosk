using Core.Config.Configs;

namespace Core.Config.Settings
{
    /// <summary>
    /// </summary>
    public sealed class InternalBankSettings
    {
        /// <summary>
        ///     Gets or sets the hospital.
        /// </summary>
        /// <value>The hospital.</value>
        public InternalBankConfig InternalBank { get; set; }
    }

    /// <summary>
    /// </summary>
    public static class InternalBankSettingHelper
    {
        /// <summary>
        ///     Gets the URL.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="apiPath">The API path.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public static string GetEndPoint(string host, string apiPath, string url)
        {
            return string.Format("{0}{1}/{2}", host, apiPath, url);
        }

        /// <summary>
        ///     Gets the URL.
        /// </summary>
        /// <param name="apiPath">The API path.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public static string GetEndPoint(string apiPath, string url)
        {
            return string.Format("{0}{1}", apiPath, url);
        }
    }
}