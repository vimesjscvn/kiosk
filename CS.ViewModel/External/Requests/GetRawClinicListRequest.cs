// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetRawClinicListRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;

namespace CS.VM.External.Requests
{
    /// <summary>
    /// Class GetRawClinicListRequest.
    /// </summary>
    public class GetRawClinicListRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        public DateTime? RegisteredDate { get; set; }
    }
}
