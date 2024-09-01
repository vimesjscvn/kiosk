namespace Core.Domain.BusinessObjects
{
    public class CardRawBalanceResponse : BaseRawResponse
    {
        public decimal Balance { get; set; }
    }

    public class CardRawBalanceRequest : BaseRawRequest
    {
        public string HospitalCode { get; set; }
    }
}