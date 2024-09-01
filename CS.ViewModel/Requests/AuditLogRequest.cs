// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="AuditLogRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class AuditLogRequest.
    /// </summary>
    public class AuditLogRequest : DataTableParameters
    {
        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [Required]
        public DateTime EndDate { get; set; }

        public string PatientCode { get; set; }
    }
}