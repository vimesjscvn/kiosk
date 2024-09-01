using Core.Config.Configs;
using System;

namespace Core.Config.Settings
{
    /// <summary>
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        ///     Gets or sets the hospital.
        /// </summary>
        /// <value>The hospital.</value>
        public ApiConfig AppSetting { get; set; }
    }

    /// <summary>
    ///     Class BackgroundJobSettingHelper.
    /// </summary>
    public static class AppSettingHelper
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