using System;
using Core.Config.Configs;
using Microsoft.Extensions.Configuration;

namespace Core.Config.Settings
{
    /// <summary>
    ///     Class BackgroundJobSettings. This class cannot be inherited.
    /// </summary>
    public sealed class BackgroundJobSettings
    {
        /// <summary>
        ///     Gets or sets the external.
        /// </summary>
        /// <value>The external.</value>
        public BackgroundJobConfig BackgroundJob { get; set; }

        public void LoadSettings(IConfiguration configuration)
        {
            var backgroundJobConfig = new BackgroundJobConfig();
            backgroundJobConfig.LoadSettings(configuration.GetSection("BackgroundJob"));
            BackgroundJob = backgroundJobConfig;
        }
    }

    /// <summary>
    ///     Class BackgroundJobSettingHelper.
    /// </summary>
    public static class BackgroundJobSettingHelper
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

        public static string GetEndPoint(string baseUrl, object loginUrl)
        {
            throw new NotImplementedException();
        }
    }
}