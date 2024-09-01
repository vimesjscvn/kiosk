// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionDetailResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using CS.VM.Models;

namespace CS.VM.Responses
{
    /// <summary>
    /// Class TransactionDetailResponse.
    /// </summary>
    public class TransactionDetailResponse
    {
        /// <summary>
        /// Gets or sets the hold transactions.
        /// </summary>
        /// <value>The hold transactions.</value>
        public IEnumerable<TransactionViewModel> HoldTransactions { get; set; }
        /// <summary>
        /// Gets or sets the paid transactions.
        /// </summary>
        /// <value>The paid transactions.</value>
        public IEnumerable<TransactionViewModel> PaidTransactions { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionDetailInfoResponse
    {
        /// <summary>
        /// Gets or sets the transaction information detail.
        /// </summary>
        /// <value>
        /// The transaction information detail.
        /// </value>
        public List<TransactionDetailViewModel> TransactionInfoDetail { get; set; }
    }
}
