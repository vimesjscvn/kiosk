using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class CreateRawAdvancePaymentRequest
    {
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("register_code")]
        public string RegisteredCode { get; set; }

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

    public class CreateRawAdvancePaymentResponse : BaseRawResponse
    {

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("invoice_no")]
        [XmlIgnore]
        public int InvoiceNo { get; set; }
        [JsonProperty("book_no")]
        public string BookNo { get; set; }
        [JsonProperty("serial_no")]
        public string SerialNo { get; set; }
        [JsonProperty("recv_no")]
        public int RecvNo { get; set; }
    }
}