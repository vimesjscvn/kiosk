namespace TEK.Gateway.Domain.BusinessObjects
{
    public class UpdateRawRefundResponse : BaseRawResponse
    {
        public int InvoiceNo { get; set; }
        public string BookNo { get; set; }
        public string SerialNo { get; set; }
        public int RecvNo { get; set; }
    }
}
