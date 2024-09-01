// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GenerateByPatientCodeResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class GenerateByPatientCodeResponse.
    /// </summary>
    public class GenerateByPatientCodeResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GenerateByPatientCodeResponse" /> class.
        /// </summary>
        public GenerateByPatientCodeResponse()
        {
            FollowUpExaminations = new List<ExaminationQueueNumberViewModel>();
            Clinics = new ClinicQueueNumberResponse();
        }

        /// <summary>
        ///     Gets or sets the follow up examinations.
        /// </summary>
        /// <value>The follow up examinations.</value>
        [JsonProperty("follow_up_examinations")]
        public List<ExaminationQueueNumberViewModel> FollowUpExaminations { get; set; }

        /// <summary>
        ///     Gets or sets the clinics.
        /// </summary>
        /// <value>The clinics.</value>
        [JsonProperty("clinics")]
        public ClinicQueueNumberResponse Clinics { get; set; }

        /// <summary>
        ///     Gets or sets the queue number.
        /// </summary>
        /// <value>The queue number.</value>
        [JsonProperty("queue_number")]
        public QueueNumberViewModel QueueNumber { get; set; }

        /// <summary>
        ///     Gets or sets the type of the queue number.
        /// </summary>
        /// <value>The type of the queue number.</value>
        [JsonProperty("queue_number_type")]
        public QueueNumberType QueueNumberType { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }
    }
}