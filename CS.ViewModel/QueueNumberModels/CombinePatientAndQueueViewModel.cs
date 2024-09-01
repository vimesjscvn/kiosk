// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CombinePatientAndQueueViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class CombinePatientAndQueueViewModel.
    /// </summary>
    public class CombinePatientAndQueueViewModel
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }

        /// <summary>
        ///     Gets or sets the queue numer.
        /// </summary>
        /// <value>The queue numer.</value>
        [JsonProperty("queue")]
        public QueueNumberViewModel QueueNumer { get; set; }

        /// <summary>
        ///     Gets or sets the type of the priority.
        /// </summary>
        /// <value>The type of the priority.</value>
        [JsonProperty("priority_type")]
        public PriorityType PriorityType { get; set; }
    }
}