using Core.Config.Configs;
using Microsoft.Extensions.Configuration;
using static CS.Common.Common.Constants;

namespace Core.Config.Settings
{
    /// <summary>
    ///     Class HospitalSettings. This class cannot be inherited.
    /// </summary>
    public sealed class HospitalSettings
    {
        /// <summary>
        ///     Gets or sets the hospital.
        /// </summary>
        /// <value>The hospital.</value>
        public HospitalConfig Hospital { get; set; }

        public void LoadSettings(IConfiguration configuration)
        {
            var hospitalConfig = new HospitalConfig();
            hospitalConfig.LoadSettings(configuration.GetSection("Hospital"));
            Hospital = hospitalConfig;
        }
    }
}