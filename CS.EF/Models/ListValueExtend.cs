// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueExtend.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class ListValueExtend.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("list_value_extend", Schema = "ListMgmt")]
    public class ListValueExtend : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual ListValueType ListValueType { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        [ForeignKey("ListValueType")]
        [Column("list_value_type_id")]
        public Guid ListValueTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the display order.
        /// </summary>
        /// <value>The display order.</value>
        [Column("display_order")]
        public int? DisplayOrder { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        [Column("is_system")]
        public bool IsSystem { get; set; } = true;

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is checked; otherwise, <c>false</c>.
        /// </value>
        [Column("is_checked")]
        public bool IsChecked { get; set; }

        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [Column("list_value_id")]
        public Guid ListValueId { get; set; }

        [Column("name")] public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual ListValue ListValue { get; set; }
    }
}