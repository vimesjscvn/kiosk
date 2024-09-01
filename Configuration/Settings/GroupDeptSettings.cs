using System.Collections.Generic;
using Core.Config.Configs;
using Core.Config.Helpers;
using Microsoft.Extensions.Configuration;

namespace Core.Config.Settings
{
    /// <summary>
    ///     Class DepartmentSettings. This class cannot be inherited.
    /// </summary>
    public sealed class GroupDeptSettings
    {
        /// <summary>
        ///     Gets or sets the external.
        /// </summary>
        /// <value>The external.</value>
        public GroupDeptConfig GroupDept { get; set; }

        public void LoadSettings(IConfiguration configuration)
        {
            var groupDeptConfig = new GroupDeptConfig();
            groupDeptConfig.LoadSettings(configuration.GetSection("GroupDept"));
            GroupDept = groupDeptConfig;
        }
    }
}