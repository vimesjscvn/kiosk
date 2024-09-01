using CS.VM.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentGroup.Domain.Models.Requests
{
    public class GroupPagingRequest : PaginationFilter
    {
        [FromQuery(Name = "code")] public string Code { get; set; }

        [FromQuery(Name = "description")] public string Description { get; set; }
    }
}