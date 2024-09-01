using Newtonsoft.Json;
using System.Xml.Serialization;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class CancelRawAdvancePaymentRequest
    {
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        [JsonProperty("invoice_no")]
        public int InvoiceNo { get; set; }
    }

    public class CancelRawAdvancePaymentResponse : BaseRawResponse
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("invoice_no")]
        [XmlIgnore]
        public int InvoiceNo { get; set; }
    }
}
