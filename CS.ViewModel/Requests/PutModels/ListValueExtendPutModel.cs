// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueExtendPutModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.VM.Requests.PutModels
{
    /// <summary>
    ///     Class ListValueExtendPutModel.
    ///     Implements the <see cref="ListValuePutModel" />
    /// </summary>
    /// <seealso cref="ListValuePutModel" />
    public class ListValueExtendPutModel : ListValuePutModel
    {
        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        public Guid ListValueId { get; set; }
    }
}