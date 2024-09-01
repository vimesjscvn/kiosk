namespace DepartmentGroup.Domain.Models.Requests
{
    public class GroupRequest
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
    }

    public class DepartmentAddGroupRequest
    {
        public string DepartmentCode { get; set; }
    }
}