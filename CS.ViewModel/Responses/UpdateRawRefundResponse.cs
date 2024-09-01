using Newtonsoft.Json;

namespace CS.VM.Responses
{
    public class UpdateRawRefundResponse
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_code")] public string StatusCode { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("invoice_no")] public int InvoiceNo { get; set; }

        [JsonProperty("book_no")] public string BookNo { get; set; }

        [JsonProperty("serial_no")] public string SerialNo { get; set; }

        [JsonProperty("recv_no")] public int RecvNo { get; set; }
    }
}