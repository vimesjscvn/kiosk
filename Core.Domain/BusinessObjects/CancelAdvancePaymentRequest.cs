using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class CancelAdvancePaymentRequest
    {
        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("employee_code")] public string EmployeeCode { get; set; }

        [JsonProperty("invoice_no")] public int InvoiceNo { get; set; }
    }

    public class CancelAdvancePaymentResponse
    {
        [JsonProperty("status")] public string Status { get; set; }


        [JsonProperty("status_code")] public string StatusCode { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("invoice_no")] public int InvoiceNo { get; set; }
    }
}