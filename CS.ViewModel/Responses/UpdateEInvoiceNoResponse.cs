using System;

namespace CS.VM.Responses
{
    public class UpdateEInvoiceNoResponse
    {
        public Guid Id { get; set; }
        public string EInvoiceNo { get; set; }
        public DateTime? EInvoiceCreatedDate { get; set; }
        public Guid? EInvoiceEmployeeId { get; set; }
    }
}