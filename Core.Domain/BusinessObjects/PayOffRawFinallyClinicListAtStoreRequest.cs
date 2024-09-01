using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class PayOffRawFinallyClinicListAtStoreRequest
    {
        /// <summary>
        ///     Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("transaction_id")]
        public Guid TransactionId { get; set; }

        [JsonProperty("book_no")] public string BookNo { get; set; }

        [JsonProperty("serial_no")] public string SerialNo { get; set; }

        [JsonProperty("recv_no")] public int RecvNo { get; set; }

        [JsonProperty("note")] public string Note { get; set; }

        [JsonProperty("extra_fee_amount")] public decimal ExtraFeeAmount { get; set; }

        [JsonProperty("book_no_cancel")] public string BookNoCancel { get; set; }

        [JsonProperty("serial_no_cancel")] public string SerialNoCancel { get; set; }

        [JsonProperty("recv_no_cancel")] public int RecvNoCancel { get; set; }

        [JsonProperty("transaction_id_cancel")]
        public string TransactionIdCancel { get; set; }
    }

    /// <summary>
    /// </summary>
    public class PayOffRawFinallyClinicListAtStoreResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("invoice_no")]
        public string InvoiceNo { get; set; }

        [JsonProperty("book_no")] public string BookNo { get; set; }

        [JsonProperty("serial_no")] public string SerialNo { get; set; }

        [JsonProperty("recv_no")] public int RecvNo { get; set; }
    }
}