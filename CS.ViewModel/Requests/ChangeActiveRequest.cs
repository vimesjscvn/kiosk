// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ChangeActiveRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using CS.Base.ViewModels.Requests;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class ChangeActiveRequest.
    ///     Implements the <see cref="BaseRequest" />
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class ChangeActiveRequest : BaseRequest
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Required]
        public bool IsActive { get; set; }
    }
}