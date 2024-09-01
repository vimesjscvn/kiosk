// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Medicine.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Medicine.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("medicine_value", Schema = "ListMgmt")]
    public class Medicine : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the usage scope.
        /// </summary>
        /// <value>The usage scope.</value>
        [Column("usage_scope")]
        public string UsageScope { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        [Column("data_type")]
        public string DataType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}