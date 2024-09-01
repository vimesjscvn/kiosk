using System;
using System.Collections.Generic;
using CS.VM.Models;

namespace Admin.Domain.Models.Responses
{
    public class GetGroupByIdResponse
    {
        public GetGroupByIdResponse()
        {
            Departments = new List<DepartmentGroupViewModel>();
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DisplayOrder { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public List<DepartmentGroupViewModel> Departments { get; set; }
    }
}