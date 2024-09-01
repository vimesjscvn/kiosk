using Newtonsoft.Json;
using System;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class CreateAdvancePaymentRequest
    {

        [JsonProperty("manage_code")]
        public string ManageCode { get; set; }

        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("register_code")]
        public string RegisterCode { get; set; }

        [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("book_no")]
        public string BookNo { get; set; }
        [JsonProperty("serial_no")]
        public string SerialNo { get; set; }
        [JsonProperty("recv_no")]
        public int RecvNo { get; set; }
    }

    public class CreateAdvancePaymentResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }


        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("invoice_no")]
        public int InvoiceNo { get; set; }
        [JsonProperty("book_no")]
        public string BookNo { get; set; }
        [JsonProperty("serial_no")]
        public string SerialNo { get; set; }
        [JsonProperty("recv_no")]
        public int RecvNo { get; set; }
    }

    public class CreateAdvancePaymentResult
    {
        public bool IsSuccess { get; set; }
        public int InvoiceNo { get; set; }
        public string BookNo { get; set; }
        public string SerialNo { get; set; }
        public int RecvNo { get; set; }
        public string Message { get; set; }
    }
}