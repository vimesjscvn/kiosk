// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ExtendPatientViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.PatientModels
{
    /// <summary>
    ///     Class ExtendPatientViewModel.
    ///     Implements the <see cref="PatientViewModel" />
    /// </summary>
    /// <seealso cref="PatientViewModel" />
    public class PatientInfoViewModel : PatientViewModel
    {
        [JsonProperty(PropertyName = "province_name")]
        public string ProvinceName { get; set; }

        [JsonProperty(PropertyName = "district_name")]
        public string DistrictName { get; set; }

        [JsonProperty("ward_name")] public string WardName { get; set; }

        [JsonProperty("ic_issued_date")] public DateTime? IdentityCardNumberIssuedDate { get; set; }

        [JsonProperty("ic_issued_place")] public string IdentityCardNumberIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PatientReceiverType Type { get; set; }

        /// <summary>
        ///     Gets or sets the hold.
        /// </summary>
        /// <value>
        ///     The balance.
        /// </value>
        public decimal? HoldAmount { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the finnaly amount.
        /// </summary>
        /// <value>
        ///     The balance.
        /// </value>
        public decimal? FinallyAmount { get; set; } = 0;

        public string RegisteredCode { get; set; }
    }
}