using System;

namespace CS.VM.Requests
{
    public class UpdateEInvoiceNoRequest
    {
        public Guid Id { get; set; }
        public string EInvoiceNo { get; set; }
        public Guid EmployeeId { get; set; }
    }
}