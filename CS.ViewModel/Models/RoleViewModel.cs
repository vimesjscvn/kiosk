using System.Collections.Generic;
using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class RoleViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "code")] public string Code { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "permissions")]
        public List<PermissionViewModel> Permissions { get; set; } = new List<PermissionViewModel>();

        [JsonProperty(PropertyName = "users")]
        public List<SysUserViewModel> Users { get; set; } = new List<SysUserViewModel>();
    }
}