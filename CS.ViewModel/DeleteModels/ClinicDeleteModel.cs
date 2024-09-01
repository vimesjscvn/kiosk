// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicDeleteModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace CS.VM.DeleteModels
{
    /// <summary>
    ///     Class ClinicDeleteModel.
    /// </summary>
    public class ClinicDeleteModel
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        //[JsonProperty("id_specified")]
        [Required]
        [StringLength(36)]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }
}