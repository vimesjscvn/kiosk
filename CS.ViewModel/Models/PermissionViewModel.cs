using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class PermissionViewModel : BaseViewModel
    {
        [JsonProperty(PropertyName = "code")] public string Code { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "is_active")]
        public bool? IsActive { get; set; }
    }
}