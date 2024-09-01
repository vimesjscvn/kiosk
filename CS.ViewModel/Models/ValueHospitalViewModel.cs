using System;

namespace CS.VM.Models
{
    public class ValueHospitalViewModel
    {
        public Guid ListValueTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
        public string Logo { get; set; }
    }
}