using Newtonsoft.Json;
using System;

namespace CS.VM.Requests
{
    public class AdminApiAddPaymentRequest
    {
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
        [JsonProperty("payment_type_id")]
        public Guid? PaymentTypeId { get; set; }
        [JsonProperty("register_code")]
        public string RegisterCode { get; set; }
        [JsonProperty("recv_no")]
        public int RecvNo { get; set; }
    }
}
