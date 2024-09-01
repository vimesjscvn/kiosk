// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetListFinallyClinicListRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class GetListFinallyClinicListRequest.
    /// </summary>
    public class GetListFinallyClinicListRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        [Required]
        [JsonProperty("requested_date")]
        public DateTime? RequestedDate { get; set; }
    }
}
