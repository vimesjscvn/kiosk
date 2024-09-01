using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class DepartmentGroupViewModel
    {
        [JsonProperty("id")] public Guid Id { get; set; }

        [JsonProperty("created_by")] public string CreatedBy { get; set; }

        [JsonProperty("created_date")] public DateTime? CreatedDate { get; set; }

        [JsonProperty("updated_by")] public string UpdatedBy { get; set; }

        [JsonProperty("updated_date")] public DateTime? UpdatedDate { get; set; }

        [JsonProperty("list_value_type_id")] public Guid ListValueTypeId { get; set; }

        [JsonProperty("display_order")] public int? DisplayOrder { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("is_active")] public bool IsActive { get; set; }

        [JsonProperty("is_checked")] public bool IsChecked { get; set; }

        [JsonProperty("is_system")] public bool IsSystem { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("is_deleted")] public bool IsDeleted { get; set; }

        public ServiceType ServiceType { get; set; }

        public Guid? ListValueId { get; set; }

        public string Name { get; set; }

        public Guid DepartmentVirtualId { get; set; }

        public string DepartmentVirtualCode { get; set; }

        public string DepartmentGroupCode { get; set; }
        public string DepartmentGroupName { get; set; }
    }
}