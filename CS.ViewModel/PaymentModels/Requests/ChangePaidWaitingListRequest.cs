// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ChangePaidWaitingListRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class ChangePaidWaitingListRequest.
    /// </summary>
    public class ChangePaidWaitingListRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is select all.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is select all; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelectAll { get; set; }

        /// <summary>
        /// Gets or sets the selected ids.
        /// </summary>
        /// <value>
        /// The selected ids.
        /// </value>
        public ICollection<Guid> SelectedIds { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; set; }
    }
}
