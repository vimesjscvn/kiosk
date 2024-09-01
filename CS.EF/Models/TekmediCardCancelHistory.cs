// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TekmediCardCancelHistory.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    /// Class TekmediCardCancelHistory.
    /// Implements the <see cref="BaseTekmediCardHistory" />
    /// </summary>
    /// <seealso cref="BaseTekmediCardHistory" />
    [Table("tekmedi_card_cancel_history", Schema = "IHM")]
    public class TekmediCardCancelHistory : BaseTekmediCardHistory
    {
        /// <summary>
        /// Gets or sets the tekmedi card history identifier.
        /// </summary>
        /// <value>The tekmedi card history identifier.</value>
        [Column("tekmedi_card_history_id")]
        public Guid TekmediCardHistoryId { get; set; }

        [Column("transaction_info_id")]
        public Guid? TransactionInfoId { get; set; }
    }
}
