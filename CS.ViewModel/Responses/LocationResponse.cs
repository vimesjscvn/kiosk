// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="LocationResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class LocationResponse.
    /// </summary>
    public class LocationResponse
    {
        /// <summary>
        ///     Gets or sets the name of the province.
        /// </summary>
        /// <value>The name of the province.</value>
        public string ProvinceName { get; set; }

        /// <summary>
        ///     Gets or sets the province code.
        /// </summary>
        /// <value>The province code.</value>
        public string ProvinceCode { get; set; }

        /// <summary>
        ///     Gets or sets the districts.
        /// </summary>
        /// <value>The districts.</value>
        public List<DistrictResponse> Districts { get; set; }
    }
}