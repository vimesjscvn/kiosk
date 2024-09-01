using CS.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("bank_token", Schema = "Bank")]
    public class BankToken : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        [Column("token_id")]
        public string TokenId { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [Column("token_number")]
        public string TokenNumber { get; set; }
        /// <summary>
        /// Gets or sets the expire month.
        /// </summary>
        /// <value>
        /// The expire month.
        /// </value>
        [Column("expire_month")]
        public int ExpireMonth { get; set; }
        /// <summary>
        /// Gets or sets the expire year.
        /// </summary>
        /// <value>
        /// The expire year.
        /// </value>
        [Column("expire_year")]
        public int ExpireYear { get; set; }
        /// <summary>
        /// Gets or sets the icvv.
        /// </summary>
        /// <value>
        /// The icvv.
        /// </value>
        [Column("icvv")]
        public string ICVV { get; set; }
        /// <summary>
        /// Gets or sets the CVV.
        /// </summary>
        /// <value>
        /// The CVV.
        /// </value>
        [Column("cvv")]
        public string CVV { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Column("state")]
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        [Column("bank_instrument_id")]
        public Guid BankInstrumentId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("is_actived")]
        public bool IsActived { get; set; }
    }
}
