using System;

namespace CS.VM.Requests
{
    public class AddTransactionNumberConfigRequest
    {
        public string SerialNo { get; set; }
        public string BookNo { get; set; }
        public string Type { get; set; }
        public string PatientType { get; set; }
        public int RecvNo { get; set; }
        public Guid UserId { get; set; }
    }
}
