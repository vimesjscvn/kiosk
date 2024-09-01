// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetTransactionByPatientCodeRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.TransactionModels.Requests
{
    /// <summary>
    /// Class GetTransactionByPatientCodeRequest.
    /// </summary>
    public class GetTransactionByPatientCodeRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        [Required]
        public DateTime? RequestedDate { get; set; }
    }
}
