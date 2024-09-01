using System;

namespace Admin.Domain.Models.Requests
{
    public class GetMultiQueueByDepartmentRequest
    {
        public DateTime Date { get; set; }
        public Guid DepartmentCode { get; set; }
        public int Limit { get; set; }
    }
}