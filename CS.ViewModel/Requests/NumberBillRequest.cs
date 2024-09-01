using System;
using CS.Common.Enums;

namespace CS.VM.Requests
{
    public class NumberBillRequest
    {
        public Guid EmployeeId { get; set; }
        public TypeEnum Type { get; set; }
        public DateTime Date { get; set; }
        public Guid HistoryId { get; set; }
    }
}