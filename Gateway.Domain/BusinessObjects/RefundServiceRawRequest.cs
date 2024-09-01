using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class RefundServiceRawRequest
    {
        /// <summary>
        /// Gets or sets the transaction code.
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
