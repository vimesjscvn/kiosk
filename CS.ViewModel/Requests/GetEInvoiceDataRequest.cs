using System;

namespace CS.VM.Requests
{
    public class GetEInvoiceDataRequest
    {
        public Guid EmployeeId { get; set; }
        public bool AdminView { get; set; } = true;
        public int Start { get; set; } = 0;
        public int Length { get; set; } = 10;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public string StartTime { get; set; } = "00:00";
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string EndTime { get; set; } = "23:59";
        public string RegisteredCode { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string EInvoiceNo { get; set; }
    }
}