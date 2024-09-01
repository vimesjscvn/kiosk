using System;

namespace CS.VM.Requests
{
    public class UpdateTransactionNumberConfigRequest
    {
        public Guid Id { get; set; }
        public string SerialNo { get; set; }
        public string BookNo { get; set; }
        public string Type { get; set; }
        public string PatientType { get; set; }
        public bool IsActive { get; set; }
        public int RecvNo { get; set; }
    }
}
