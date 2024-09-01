// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicPutModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using CS.Base.ViewModels.PostModel;
using Newtonsoft.Json;

namespace CS.VM.PutModels
{
    /// <summary>
    ///     Class ClinicPutModel.
    ///     Implements the <see cref="BasePutModel" />
    /// </summary>
    /// <seealso cref="BasePutModel" />
    public class ClinicPutModel : BasePutModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code registered.
        /// </summary>
        /// <value>The doctor code registered.</value>
        [StringLength(36)]
        public string DoctorCodeRegistered { get; set; }

        /// <summary>
        ///     Gets or sets the department code registered.
        /// </summary>
        /// <value>The department code registered.</value>
        [StringLength(36)]
        public string DepartmentCodeRegistered { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        [Required]
        [StringLength(36)]
        [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }
    }
}