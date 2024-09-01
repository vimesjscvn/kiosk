using CS.Base;
using CS.Common.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("bank_instrument", Schema = "Bank")]
    public class BankInstrument : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [Column("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Column("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        [Column("month")]
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        [Column("year")]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Column("instrument_id")]
        public string InstrumentId { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        [Column("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Column("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("is_actived")]
        public bool IsActived { get; set; } = Constants.DefaultIsActive;

        /// <summary>
        /// Gets or sets the authorization identifier.
        /// </summary>
        /// <value>
        /// The authorization identifier.
        /// </value>
        [Column("authorization_id")]
        public string AuthorizationId { get; set; }

        /// <summary>
        /// Gets or sets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        [Column("bank_account_id")]
        public Guid BankAccountId { get; set; }
    }
}
