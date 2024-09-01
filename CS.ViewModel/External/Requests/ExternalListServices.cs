// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ExternalListServices.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CS.VM.External.Requests
{
    /// <summary>
    ///     Class ExternalListServices.
    /// </summary>
    public class ExternalListServices
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the clinic date.
        /// </summary>
        /// <value>The clinic date.</value>
        [JsonRequired]
        [JsonProperty("NgayChiDinh")]
        public string ClinicDate { get; set; }
    }

    /// <summary>
    ///     Class ExternalListServicesWrapper.
    ///     Implements the <see cref="BaseExternalRequest" />
    /// </summary>
    /// <seealso cref="BaseExternalRequest" />
    public class ExternalListServicesWrapper : BaseExternalRequest
    {
    }
}