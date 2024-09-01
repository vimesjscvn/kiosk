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

using CS.Common.Common;
using CS.VM.Models;

namespace CS.VM.PatientModels
{
    /// <summary>
    ///     Class ExtendPatientViewModel.
    ///     Implements the <see cref="PatientViewModel" />
    /// </summary>
    /// <seealso cref="PatientViewModel" />
    public class ExtendPatientViewModel : PatientViewModel
    {
        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public string Data { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PatientReceiverType Type { get; set; }
    }
}