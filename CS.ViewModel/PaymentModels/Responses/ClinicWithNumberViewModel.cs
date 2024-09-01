// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicWithNumberViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using CS.Common.Common;
using CS.VM.ClinicModels;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Responses
{
    /// <summary>
    /// Class ClinicWithNumberViewModel.
    /// Implements the <see cref="ClinicViewModel" />
    /// </summary>
    /// <seealso cref="ClinicViewModel" />
    public class ClinicWithNumberViewModel : ClinicViewModel
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the type of the queue number.
        /// </summary>
        /// <value>The type of the queue number.</value>
        [JsonProperty("queue_number_type")]
        public PatientType QueueNumberType { get; set; }
    }

    /// <summary>
    /// Class CombineQueueWithServicesViewModel.
    /// Implements the <see cref="QueueNumberViewModel" />
    /// </summary>
    /// <seealso cref="QueueNumberViewModel" />
    public class CombineQueueWithServicesViewModel : QueueNumberViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombineQueueWithServicesViewModel"/> class.
        /// </summary>
        public CombineQueueWithServicesViewModel()
        {
            Services = new List<ClinicViewModel>();
        }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>The services.</value>
        [JsonProperty("services")]
        public List<ClinicViewModel> Services { get; set; }

        /// <summary>
        /// Gets or sets the type of the clinic.
        /// </summary>
        /// <value>The type of the clinic.</value>
        [JsonProperty("clinic_type")]
        public ClinicType? ClinicType { get; set; }
    }
}
