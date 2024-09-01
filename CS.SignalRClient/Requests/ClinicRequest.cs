// ***********************************************************************
// Assembly         : CS.SignalRClient
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicRequest.cs" company="CS.SignalRClient">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.SignalRClient.Requests
{
    /// <summary>
    ///     Class ClinicRequest.
    /// </summary>
    public class ClinicRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int Type { get; set; }
    }
}