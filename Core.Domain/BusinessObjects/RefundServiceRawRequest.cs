using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class RefundServiceRawRequest
    {
        /// <summary>
        ///     Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("transaction_id")]
        public Guid TransactionId { get; set; }
    }

    public class RefundServiceRawResponse : BaseRawResponse
    {
    }
}