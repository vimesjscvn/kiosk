using Microsoft.AspNetCore.Mvc;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class Pagination Filter.
    /// </summary>
    public class PaginationFilter
    {
        public PaginationFilter()
        {
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 5000 ? 10 : pageSize;
        }

        [FromQuery(Name = "page_number")] public int PageNumber { get; set; }

        [FromQuery(Name = "page_size")] public int PageSize { get; set; }
    }
}