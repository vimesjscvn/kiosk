using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Gateway.Domain.BusinessObjects.BaseRawRequest" />
    public class DeleteRegistrationRawRequest
    {
        /// <summary>
        /// Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("transaction_id")]
        public Guid TransactionId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteRegistrationRawResponse : BaseRawResponse
    {
    }
}
