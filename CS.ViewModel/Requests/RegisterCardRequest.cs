// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="RegisterCardRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.Requests
{
    /// <summary>
    /// Class RegisterCardRequest.
    /// </summary>
    public class RegisterCardRequest
    {
        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [Required]
        public string TekmediCardNumber { get; set; }

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
