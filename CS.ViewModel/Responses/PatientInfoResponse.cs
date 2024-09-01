// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PatientInfoResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class PatientInfoResponse.
    /// </summary>
    public class PatientInfoResponse
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the patient administrative information.
        /// </summary>
        /// <value>The patient administrative information.</value>
        public PatientAdministrativeInformationResponse PatientAdministrativeInformation { get; set; }
    }
}