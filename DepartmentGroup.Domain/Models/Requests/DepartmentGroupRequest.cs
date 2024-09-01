using System.Collections.Generic;

namespace DepartmentGroup.Domain.Models.Requests
{
    public class DepartmentGroupRequest
    {
        public string DepartmentGroupCode { get; set; }
        public string DepartmentGroupName { get; set; }
    }

    public class DepartmentRequest
    {
        public string DepartmentVirtualCode { get; set; }
        public List<string> DepartmentCode { get; set; }
    }
}