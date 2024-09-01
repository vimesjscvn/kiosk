// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="District.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class District.
    ///     Implements the <see cref="BaseLocationPart" />
    /// </summary>
    /// <seealso cref="BaseLocationPart" />
    [Table("district")]
    public class District : BaseLocationPart
    {
        /// <summary>
        ///     Gets or sets the province code.
        /// </summary>
        /// <value>The province code.</value>
        [Column("province")]
        public string ProvinceCode { get; set; }
    }
}