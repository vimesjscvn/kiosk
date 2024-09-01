// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="User.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    /// Class User.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("bank_account", Schema = "Bank")]
    public class BankAccount : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("is_actived")]
        public bool IsActived { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Column("status")]
        public BankStatus Status { get; set; } = BankStatus.New;

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        [Column("create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Column("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Column("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        [Column("group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        [Column("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        [Column("ref_id")]
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Column("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        [Column("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        [Column("seq_num")]
        public string SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the identity card number.
        /// </summary>
        /// <value>
        /// The identity card number.
        /// </value>
        [Column("identity_card_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [Column("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Gets or sets the bank account address.
        /// </summary>
        /// <value>
        /// The bank account address.
        /// </value>
        public virtual BankAccountAddress BankAccountAddress { get; set; }

        /// <summary>
        /// Gets or sets the bank instrument.
        /// </summary>
        /// <value>
        /// The bank instrument.
        /// </value>
        public virtual BankInstrument BankInstrument { get; set; }

        /// <summary>
        /// Gets or sets the bank instrument.
        /// </summary>
        /// <value>
        /// The bank instrument.
        /// </value>
        public virtual ICollection<BankCard> BankCards { get; set; }
    }
}
