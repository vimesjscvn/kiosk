// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="DistrictResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class DistrictResponse.
    /// </summary>
    public class DistrictResponse
    {
        /// <summary>
        ///     Gets or sets the name of the district.
        /// </summary>
        /// <value>The name of the district.</value>
        public string DistrictName { get; set; }

        /// <summary>
        ///     Gets or sets the district code.
        /// </summary>
        /// <value>The district code.</value>
        public string DistrictCode { get; set; }

        /// <summary>
        ///     Gets or sets the wards.
        /// </summary>
        /// <value>The wards.</value>
        public List<WardResponse> Wards { get; set; }
    }
}