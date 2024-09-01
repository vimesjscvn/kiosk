using System;

namespace CS.VM.Requests
{
    public class ExportBalanceWebRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; } = "00:00";
        public string EndTime { get; set; } = "23:59";
        public string RegisteredCode { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public ExportBalanceExcelStatus Status { get; set; }
        public int Start { get; set; } = 0;
        public int Length { get; set; } = 50;
    }
}