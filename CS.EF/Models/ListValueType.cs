// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueType.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class ListValueType.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("list_value_type", Schema = "ListMgmt")]
    public class ListValueType : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        [Column("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is user list edit allowed.
        /// </summary>
        /// <value><c>true</c> if this instance is user list edit allowed; otherwise, <c>false</c>.</value>
        [Column("is_user_list_edit_allowed")]
        public bool? IsUserListEditAllowed { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is externally managed.
        /// </summary>
        /// <value><c>true</c> if this instance is externally managed; otherwise, <c>false</c>.</value>
        [Column("is_externally_managed")]
        public bool? IsExternallyManaged { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the list values.
        /// </summary>
        /// <value>The list values.</value>
        public virtual ICollection<ListValue> ListValues { get; set; }

        /// <summary>
        ///     Gets or sets the list value extends.
        /// </summary>
        /// <value>The list value extends.</value>
        public virtual ICollection<ListValueExtend> ListValueExtends { get; set; }
    }
}