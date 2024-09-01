// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueTypePostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class ListValueTypePostModel.
    /// </summary>
    public class ListValueTypePostModel
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int ParentId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is user list edit allowed.
        /// </summary>
        /// <value><c>true</c> if this instance is user list edit allowed; otherwise, <c>false</c>.</value>
        public bool IsUserListEditAllowed { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is externally managed.
        /// </summary>
        /// <value><c>true</c> if this instance is externally managed; otherwise, <c>false</c>.</value>
        public bool IsExternallyManaged { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required]
        public string Code { get; set; }
    }
}