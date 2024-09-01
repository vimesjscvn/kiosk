// ***********************************************************************
// Assembly         : CS.SignalRClient
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="RegisterClinicRequest.cs" company="CS.SignalRClient">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.SignalRClient.Requests
{
    /// <summary>
    ///     Class RegisterClinicRequest.
    /// </summary>
    public class RegisterClinicRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }
    }
}