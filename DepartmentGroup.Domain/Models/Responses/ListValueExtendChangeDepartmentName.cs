using System;

namespace DepartmentGroup.Domain.Models.Responses
{
    public class ListValueExtendChangeDepartmentName
    {
        public Guid ListValueTypeId { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameChange { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ListValueId { get; set; }
    }
}