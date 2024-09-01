// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetTempFromPatientsByDepartmentCodeRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class GetTempFromPatientsByDepartmentCodeRequest.
    /// </summary>
    public class GetTempFromPatientsByDepartmentCodeRequest
    {
        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>The table code.</value>
        [Required]
        public string TableCode { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public int? Limit { get; set; }

        /// <summary>
        ///     Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        public DateTime? RequestedDate { get; set; }
    }
}