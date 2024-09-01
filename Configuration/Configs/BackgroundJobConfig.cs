using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Core.Config.Configs
{
    /// <summary>
    ///     Class BackgroundJob.
    /// </summary>
    public class BackgroundJobConfig
    {
        public void LoadSettings(IConfiguration configuration)
        {
            SyncDepartmentJobConfig = configuration["SyncDepartmentJobConfig"];
            ResetOrderNumberJobConfig = configuration["ResetOrderNumberJobConfig"];
            IsEnableSyncData = bool.TryParse(configuration["IsEnableSyncData"], out var isEnableSyncData) && isEnableSyncData;
            SyncGroupDeptList = configuration.GetSection("SyncGroupDeptList").Get<List<string>>();
        }

        public bool IsEnableSyncData { get; set; }
        public List<string> SyncGroupDeptList { get; set; }
        public string SyncDepartmentJobConfig { get; set; }
        public string ResetOrderNumberJobConfig { get; set; }
    }
}