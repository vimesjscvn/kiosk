// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ExaminationQueueNumberViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class ExaminationQueueNumberViewModel.
    ///     Implements the <see cref="QueueNumberViewModel" />
    /// </summary>
    /// <seealso cref="QueueNumberViewModel" />
    public class ExaminationQueueNumberViewModel : QueueNumberViewModel
    {
        /// <summary>
        ///     Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonProperty("doctor_id")]
        public string EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employee.
        /// </summary>
        /// <value>The name of the employee.</value>
        [JsonProperty("doctor_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }
    }
}