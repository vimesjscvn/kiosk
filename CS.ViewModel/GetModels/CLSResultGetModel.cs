// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CLSResultGetModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.VM.GetModels
{
    /// <summary>
    ///     Class CLSResultGetModel.
    /// </summary>
    public class CLSResultGetModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets from date.
        /// </summary>
        /// <value>From date.</value>
        public DateTime FromDate { get; set; }

        /// <summary>
        ///     Converts to date.
        /// </summary>
        /// <value>To date.</value>
        public DateTime ToDate { get; set; }
    }
}