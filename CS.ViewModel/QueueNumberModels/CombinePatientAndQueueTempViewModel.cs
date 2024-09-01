// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CombinePatientAndQueueTempViewModel.cs" company="CS.VM">
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
    ///     Class CombinePatientAndQueueTempViewModel.
    /// </summary>
    public class CombinePatientAndQueueTempViewModel
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
        public QueueNumberTempViewModel QueueNumer { get; set; }

        /// <summary>
        ///     Gets or sets the type of the priority.
        /// </summary>
        /// <value>The type of the priority.</value>
        [JsonProperty("priority_type")]
        public PriorityType PriorityType { get; set; }
    }

    /// <summary>
    /// </summary>
    public class VoicePatientAndQueueTempViewModel
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the queue numer.
        /// </summary>
        /// <value>
        ///     The queue numer.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the patient.
        /// </summary>
        /// <value>
        ///     The name of the patient.
        /// </value>
        [JsonProperty("name")]
        public string PatientName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the store.
        /// </summary>
        /// <value>
        ///     The store.
        /// </value>
        [JsonProperty("store")]
        public int? Store { get; set; }
    }
}