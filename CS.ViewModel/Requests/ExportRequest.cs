// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="StatisticalCardRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class ExportRequest.
    /// </summary>
    public class ExportRequest : DataTableParameters
    {
        /// <summary>
        ///     Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public Guid EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employee.
        /// </summary>
        /// <value>The name of the employee.</value>
        public string EmployeeName { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime EndDate { get; set; }
    }
}