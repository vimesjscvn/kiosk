using System;
using Core.Config.Configs;

namespace Core.Config.Settings
{
    /// <summary>
    ///     Class ExternalSettings. This class cannot be inherited.
    /// </summary>
    public sealed class ExternalSettings
    {
        /// <summary>
        ///     Gets or sets the external.
        /// </summary>
        /// <value>The external.</value>
        public ExternalConfig External { get; set; }
    }

    /// <summary>
    ///     Class ExternalSettingHelper.
    /// </summary>
    public static class ExternalSettingHelper
    {
        /// <summary>
        ///     Gets the URL.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        public static string GetEndPoint(string host, string url)
        {
            return string.Format("{0}{1}", host, url);
        }

        public static string GetEndPoint(string baseUrl, object postUpdateListServiceUrl)
        {
            throw new NotImplementedException();
        }
    }
}