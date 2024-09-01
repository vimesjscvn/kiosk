// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueueNumberPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class QueueNumberPostModel.
    /// </summary>
    public class QueueNumberPostModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [JsonProperty("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        //[JsonProperty("department_code")]
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PatientType? Type { get; set; }

        [JsonProperty("area_code")] public string AreaCode { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }

        [JsonProperty("group_code")] public string GroupCode { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        public Guid DepartmentExtendId { get; set; }
    }

    /// <summary>
    ///     Class QueueNumberPostModel.
    /// </summary>
    public class QueueNumberAddModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public Guid PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public List<string> DepartmentCodes { get; set; }

        //[JsonProperty("department_code")]
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PatientType? Type { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the date change.
        /// </summary>
        /// <value>The date change.</value>
        public DateTime RequestDate { get; set; }
    }
}