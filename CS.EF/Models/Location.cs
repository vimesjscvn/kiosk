// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Location.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Location.
    /// </summary>
    [Table("location", Schema = "IHM")]
    public class Location
    {
        /// <summary>
        ///     Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        [Column("province")]
        public string Province { get; set; }

        /// <summary>
        ///     Gets or sets the province code.
        /// </summary>
        /// <value>The province code.</value>
        [Column("province_code")]
        public string ProvinceCode { get; set; }

        /// <summary>
        ///     Gets or sets the district.
        /// </summary>
        /// <value>The district.</value>
        [Column("district")]
        public string District { get; set; }

        /// <summary>
        ///     Gets or sets the district code.
        /// </summary>
        /// <value>The district code.</value>
        [Column("district_code")]
        public string DistrictCode { get; set; }

        /// <summary>
        ///     Gets or sets the ward.
        /// </summary>
        /// <value>The ward.</value>
        [Column("block")]
        public string Ward { get; set; }

        /// <summary>
        ///     Gets or sets the ward code.
        /// </summary>
        /// <value>The ward code.</value>
        [Column("block_code")]
        public string WardCode { get; set; }
    }
}