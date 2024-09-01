using CS.Common.Common;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Core.Config.Configs
{
    public class GroupDeptConfig
    {
        public void LoadSettings(IConfiguration configuration)
        {
            IsActive = bool.TryParse(configuration["IsActive"], out var isActive) && isActive;
            GroupDeptConfigList = configuration.GetSection("GroupDeptConfigList").Get<List<GroupDeptConfigList>>();
        }

        public bool IsActive { get; set; }

        public List<GroupDeptConfigList> GroupDeptConfigList { get; set; }
    }

    public class DepartmentAppConfig
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string GroupDeptCode { get; set; }
        public string GroupDeptName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }

    public class GroupDeptConfigList
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string GroupDeptCode { get; set; }
        public string GroupDeptName { get; set; }

        public List<DepartmentAppConfig> Departments { get; set; }
    }
}