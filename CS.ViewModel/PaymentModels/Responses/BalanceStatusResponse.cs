// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BalanceStatusResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Responses
{
    /// <summary>
    /// Class BalanceStatusResponse.
    /// </summary>
    public class BalanceStatusResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("balance_status")]
        public BalanceStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
