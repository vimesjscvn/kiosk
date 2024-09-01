// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CheckCodeUniqueRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using CS.Base.ViewModels.Requests;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class CheckCodeUniqueRequest.
    ///     Implements the <see cref="BaseRequest" />
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class CheckCodeUniqueRequest : BaseRequest
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required]
        public string Code { get; set; }
    }
}