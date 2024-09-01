// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Ward.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Ward.
    ///     Implements the <see cref="BaseLocationPart" />
    /// </summary>
    /// <seealso cref="BaseLocationPart" />
    [Table("ward")]
    public class Ward : BaseLocationPart
    {
        /// <summary>
        ///     Gets or sets the district code.
        /// </summary>
        /// <value>The district code.</value>
        [Column("district")]
        public string DistrictCode { get; set; }
    }
}