using CS.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("bank_transaction", Schema = "Bank")]
    public class BankTransaction : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Required]
        [Column("payment_id")]
        public string PaymentId { get; set; } = Guid.Empty.ToString();
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Required]
        [Column("type")]
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [Required]
        [Column("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the merchant identifier.
        /// </summary>
        /// <value>
        /// The merchant identifier.
        /// </value>
        [Column("merchant_id")]
        public string MerchantId { get; set; }
        /// <summary>
        /// Gets or sets the name of the merchant.
        /// </summary>
        /// <value>
        /// The name of the merchant.
        /// </value>
        [Column("merchant_name")]
        public string MerchantName { get; set; }
        /// <summary>
        /// Gets or sets the client reference.
        /// </summary>
        /// <value>
        /// The client reference.
        /// </value>
        [Column("client_ref")]
        public string ClientRef { get; set; }
        /// <summary>
        /// Gets or sets the terminal identifier.
        /// </summary>
        /// <value>
        /// The terminal identifier.
        /// </value>
        [Column("terminal_id")]
        public string TerminalId { get; set; }
        /// <summary>
        /// Gets or sets the instrument identifier.
        /// </summary>
        /// <value>
        /// The instrument identifier.
        /// </value>
        [Column("instrument_id")]
        public string InstrumentId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required]
        [Column("amount")]
        public string Amount { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        [Column("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Gets or sets the pay time.
        /// </summary>
        /// <value>
        /// The pay time.
        /// </value>
        [Column("pay_time")]
        public string PayTime { get; set; }
        /// <summary>
        /// Gets or sets the batch no.
        /// </summary>
        /// <value>
        /// The batch no.
        /// </value>
        [Column("batch_no")]
        public string BatchNo { get; set; }
        /// <summary>
        /// Gets or sets the trace no.
        /// </summary>
        /// <value>
        /// The trace no.
        /// </value>
        [Column("trace_no")]
        public string TraceNo { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Required]
        [Column("state")]
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>
        /// The response code.
        /// </value>
        [Column("response_code")]
        public string ResponseCode { get; set; }
        /// <summary>
        /// Gets or sets the merchant TXN reference.
        /// </summary>
        /// <value>
        /// The merchant TXN reference.
        /// </value>
        [Column("merchant_txn_ref")]
        public string MerchantTxnRef { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [Column("order", TypeName = "jsonb")]
        public string Order { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [Column("reason", TypeName = "jsonb")]
        public string Reason { get; set; }
        /// <summary>
        /// Gets or sets the settlement.
        /// </summary>
        /// <value>
        /// The settlement.
        /// </value>
        [Column("settlement", TypeName = "jsonb")]
        public string Settlement { get; set; }
        /// <summary>
        /// Gets or sets the terminal.
        /// </summary>
        /// <value>
        /// The terminal.
        /// </value>
        [Column("terminal", TypeName = "jsonb")]
        public string Terminal { get; set; }
        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        /// <value>
        /// The update time.
        /// </value>
        [Column("update_time")]
        public string UpdateTime { get; set; }
        /// <summary>
        /// Gets or sets the authorization.
        /// </summary>
        /// <value>
        /// The authorization.
        /// </value>
        [Column("authorization", TypeName = "jsonb")]
        public string Authorization { get; set; }

        /// <summary>
        /// Gets or sets the instrument.
        /// </summary>
        /// <value>
        /// The instrument.
        /// </value>
        [Column("instrument", TypeName = "jsonb")]
        public string Instrument { get; set; }

        /// <summary>
        /// Gets or sets the transaction information identifier.
        /// </summary>
        /// <value>
        /// The transaction information identifier.
        /// </value>
        [Column("transaction_info_id")]
        public Guid TransactionInfoId { get; set; }
    }

}
