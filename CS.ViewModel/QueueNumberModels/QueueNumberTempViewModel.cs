// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueueNumberTempViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Base.ViewModels;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Queue Number View Model
    /// </summary>
    public class QueueNumberTempViewModel : BaseViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueueNumberViewModel" /> class.
        /// </summary>
        public QueueNumberTempViewModel()
        {
        }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public PatientType Type { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>The table code.</value>
        [JsonProperty("table_code")]
        public string TableCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public QueueTempStatus Status { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [JsonProperty("patient_id")]
        public Guid? PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }
    }
}