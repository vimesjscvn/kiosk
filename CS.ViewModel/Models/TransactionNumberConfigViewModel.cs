using System;

namespace CS.VM.Models
{
    public class TransactionNumberConfigViewModel
    {
        public Guid Id { get; set; }
        public string BookNo { get; set; }
        public string SerialNo { get; set; }
        public int RecvNo { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public string PatientType { get; set; }
    }
}
