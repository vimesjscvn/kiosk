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
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class User.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("bank_card", Schema = "Bank")]
    public class BankCard : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [Column("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        ///     The bank identifier.
        /// </value>
        [Column("bank_account_id")]
        public Guid BankAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Column("type")]
        public CardType Type { get; set; } = CardType.Bank;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("is_actived")]
        public bool IsActived { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = true;
    }
}