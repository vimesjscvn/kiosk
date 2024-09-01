// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="LostCardRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.Requests
{
    /// <summary>
    /// Class LostCardRequest.
    /// </summary>
    public class LostCardRequest
    {
        /// <summary>
        /// Gets or sets the current tekmedi card number.
        /// </summary>
        /// <value>The current tekmedi card number.</value>
        [Required]
        public string CurrentTekmediCardNumber { get; set; }

        /// <summary>
        /// Creates new tekmedicardnumber.
        /// </summary>
        /// <value>The new tekmedi card number.</value>
        public string NewTekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        public string PatientCode { get; set; }
    }
}
