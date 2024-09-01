using System;
using CS.VM.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentGroup.Domain.Models.Requests
{
    public class DepartmentPagingRequest : PaginationFilter
    {
        [FromQuery(Name = "code")] public string Code { get; set; }

        [FromQuery(Name = "description")] public string Description { get; set; }

        [FromQuery(Name = "list_value_id")] public Guid? ListValueId { get; set; }
    }
}