using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class DeleteRegistrationRawRequest
    {
        /// <summary>
        ///     Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("transaction_id")]
        public Guid TransactionId { get; set; }
    }

    /// <summary>
    /// </summary>
    public class DeleteRegistrationRawResponse : BaseRawResponse
    {
    }
}