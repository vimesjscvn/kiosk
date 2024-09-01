using System;

namespace CS.VM.Requests
{
    public class ExportBalanceExcelRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; } = "00:00";
        public string EndTime { get; set; } = "23:59";
        public string RegisteredCode { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public ExportBalanceExcelStatus Status { get; set; }
    }

    public enum ExportBalanceExcelStatus
    {
        All = 0,
        Payment = 1,
        NotPayment = 2
    }
}