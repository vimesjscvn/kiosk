// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="LocationViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CS.VM
{
    /// <summary>
    ///     Queue Number View Model
    /// </summary>
    public class LocationViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LocationViewModel" /> class.
        /// </summary>
        public LocationViewModel()
        {
        }

        /// <summary>
        ///     Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        ///     Gets or sets the province code.
        /// </summary>
        /// <value>The province code.</value>
        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        /// <summary>
        ///     Gets or sets the district.
        /// </summary>
        /// <value>The district.</value>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        ///     Gets or sets the district code.
        /// </summary>
        /// <value>The district code.</value>
        [JsonProperty("district_code")]
        public string DistrictCode { get; set; }

        /// <summary>
        ///     Gets or sets the ward.
        /// </summary>
        /// <value>The ward.</value>
        [JsonProperty("block")]
        public string Ward { get; set; }

        /// <summary>
        ///     Gets or sets the ward code.
        /// </summary>
        /// <value>The ward code.</value>
        [JsonProperty("block_code")]
        public string WardCode { get; set; }
    }
}