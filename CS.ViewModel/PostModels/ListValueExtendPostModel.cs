// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueExtendPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class ListValueExtendPostModel.
    ///     Implements the <see cref="ListValuePostModel" />
    /// </summary>
    /// <seealso cref="ListValuePostModel" />
    public class ListValueExtendPostModel : ListValuePostModel
    {
        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        public Guid ListValueId { get; set; }
    }
}