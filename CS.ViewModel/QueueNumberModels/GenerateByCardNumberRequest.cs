// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GenerateByCardNumberRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    /// Class GenerateByCardNumberRequest.
    /// </summary>
    public class GenerateByCardNumberRequest
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        [JsonRequired]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        public DateTime? RequestedDate { get; set; }
    }
}
