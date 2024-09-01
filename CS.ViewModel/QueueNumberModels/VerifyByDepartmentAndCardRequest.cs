// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="VerifyByDepartmentAndCardRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    /// Class VerifyByDepartmentAndCardRequest.
    /// </summary>
    public class VerifyByDepartmentAndCardRequest
    {
        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        [Required]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        public DateTime? RequestedDate { get; set; }
    }
}
