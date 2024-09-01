using System;
using System.Collections.Generic;

namespace CS.VM.Responses
{
    public class GetEInvoiceDataResponse
    {
        public int TotalRecord { get; set; }
        public List<GetEInvoiceDataDto> Data { get; set; } = new List<GetEInvoiceDataDto>();
    }

    public class GetEInvoiceDataDto
    {
        public Guid Id { get; set; }
        public string EInvoiceNo { get; set; }
        public int PrintedBillCount { get; set; }
        public string BillNo { get; set; }
        public string RegisteredCode { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EInvoiceCreatedDate { get; set; }
    }
}