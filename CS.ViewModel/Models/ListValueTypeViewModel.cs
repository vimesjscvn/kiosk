// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueTypeViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class ListValueTypeViewModel.
    ///     Implements the <see cref="BaseViewModelExtended" />
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class ListValueTypeViewModel : BaseViewModelExtended
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is user list edit allowed.
        /// </summary>
        /// <value><c>true</c> if this instance is user list edit allowed; otherwise, <c>false</c>.</value>
        [JsonProperty("is_user_list_edit_allowed")]
        public bool? IsUserListEditAllowed { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is externally managed.
        /// </summary>
        /// <value><c>true</c> if this instance is externally managed; otherwise, <c>false</c>.</value>
        [JsonProperty("is_externally_managed")]
        public bool? IsExternallyManaged { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}