// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetCalendarByPatientCodeRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Newtonsoft.Json;

namespace CS.VM.PatientModels
{
    /// <summary>
    ///     Class GetCalendarByPatientCodeRequest.
    /// </summary>
    public class GetCalendarByPatientCodeRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        public DateTime? RegisteredDate { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class GetCalendarByRegisteredCodeRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class GetCalendarByDateRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        public DateTime EndDate { get; set; }
    }
}