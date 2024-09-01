using System;

namespace CS.VM.Models
{
    public class StatisticalMonthByPatientViewModel
    {
        public Guid PatientId { get; set; }
        public string PatientCode { get; set; }
        public string FullName { get; set; }
        public decimal Initial { get; set; }
        public decimal Increase { get; set; }
        public decimal Payment { get; set; }
        public decimal ReturnCardAmount { get; set; }
        public decimal LastAmount { get; set; }
    }
}