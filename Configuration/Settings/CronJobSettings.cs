using System;
using Core.Config.Configs;

namespace Core.Config.Settings
{
    /// <summary>
    ///     Class ExternalSettings. This class cannot be inherited.
    /// </summary>
    public sealed class CronJobSettings
    {
        public CronJobConfig CronJob { get; set; }
    }
}