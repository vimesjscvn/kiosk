using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class UpdateRawRefundRequest
    {
        [JsonProperty("hospital_code")] public string HospitalCode { get; set; }

        [JsonProperty("management_code")] public string ManagementCode { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("employee_code")] public string EmployeeCode { get; set; }

        [JsonProperty("amount")] public decimal Amount { get; set; }

        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("book_no")] public string BookNo { get; set; }

        [JsonProperty("serial_no")] public string SerialNo { get; set; }

        [JsonProperty("recv_no")] public int RecvNo { get; set; }
    }
}