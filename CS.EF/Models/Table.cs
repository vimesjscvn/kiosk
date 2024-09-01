// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Table.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Table.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("table")]
    public class Table : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the device code.
        /// </summary>
        /// <value>The device code.</value>
        [Column("device")]
        public string DeviceCode { get; set; }

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
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public PriorityType Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        [Column("device_type")]
        public TableDeviceType DeviceType { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [Column("pc_ip")]
        public string ComputerIP { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [Column("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        [Column("store")]
        public int Store { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [Column("ip")]
        public string Ip { get; set; }

        [Column("limit")] public int Limit { get; set; }

        [Column("display_order")] public int DisplayOrder { get; set; }
    }
}