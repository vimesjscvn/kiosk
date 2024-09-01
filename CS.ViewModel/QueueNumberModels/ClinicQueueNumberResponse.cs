// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicQueueNumberResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class ClinicQueueNumberResponse.
    /// </summary>
    public class ClinicQueueNumberResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClinicQueueNumberResponse" /> class.
        /// </summary>
        public ClinicQueueNumberResponse()
        {
            FollowUpClinics = new List<ClinicQueueNumberViewModel>();
        }

        /// <summary>
        ///     Gets or sets the follow up clinics.
        /// </summary>
        /// <value>The follow up clinics.</value>
        [JsonProperty("follow_up_clinics")]
        public List<ClinicQueueNumberViewModel> FollowUpClinics { get; set; }

        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
    }
}