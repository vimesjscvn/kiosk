// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetQueueNumberTempByTableCodeRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using CS.Common.Common;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class GetQueueNumberTempByTableCodeRequest.
    /// </summary>
    public class GetQueueNumberTempByTableCodeRequest
    {
        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>The table code.</value>
        [Required]
        public string TableCode { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Required]
        public PriorityType Type { get; set; }

        /// <summary>
        ///     Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        public DateTime? RequestedDate { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public int? Limit { get; set; }
    }
}