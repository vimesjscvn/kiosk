using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class UpdateRawReturnCardRequest
    {
        [JsonProperty("hospital_code")] public string HospitalCode { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("management_code")] public string ManagementCode { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("employee_code")] public string EmployeeCode { get; set; }

        [JsonProperty("transaction_code")] public string TransactionCode { get; set; }

        [JsonProperty("transaction_date")] public DateTime TransactionDate { get; set; }

        [JsonProperty("return_card_amount")] public decimal ReturnCardAmount { get; set; }

        [JsonProperty("invoices")] public List<int> Invoices { get; set; }
    }
}