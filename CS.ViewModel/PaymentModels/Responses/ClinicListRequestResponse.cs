// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicListRequestResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Responses
{
    /// <summary>
    /// Class ClinicListRequestResponse.
    /// </summary>
    public class ClinicListRequestResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicListRequestResponse"/> class.
        /// </summary>
        public ClinicListRequestResponse()
        {
            Examinations = new List<CombineQueueWithServicesViewModel>();
            Clinics = new List<CombineQueueWithServicesViewModel>();
            Prescriptions = new List<PrescriptionViewModel>();
            ClinicPrescriptions = new List<PrescriptionViewModel>();
            BalanceStatusResponse = new BalanceStatusResponse();
        }

        /// <summary>
        /// Gets or sets the examinations.
        /// </summary>
        /// <value>The examinations.</value>
        [JsonProperty("examinations")]
        public List<CombineQueueWithServicesViewModel> Examinations { get; set; }

        /// <summary>
        /// Gets or sets the clinics.
        /// </summary>
        /// <value>The clinics.</value>
        [JsonProperty("clinics")]
        public List<CombineQueueWithServicesViewModel> Clinics { get; set; }

        /// <summary>
        /// Gets or sets the prescriptions.
        /// </summary>
        /// <value>The prescriptions.</value>
        [JsonProperty("prescriptions")]
        public List<PrescriptionViewModel> Prescriptions { get; set; }

        /// <summary>
        /// Gets or sets the clinic prescriptions.
        /// </summary>
        /// <value>The clinic prescriptions.</value>
        [JsonProperty("clinics_prescriptions")]
        public List<PrescriptionViewModel> ClinicPrescriptions { get; set; }

        /// <summary>
        /// Gets or sets the balance status response.
        /// </summary>
        /// <value>The balance status response.</value>
        [JsonProperty("status")]
        public BalanceStatusResponse BalanceStatusResponse { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
    }

    /// <summary>
    /// Class ClinicListRequestResponse.
    /// </summary>
    public class ClinicListRequestResponseExtend : ClinicListRequestResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicListRequestResponse"/> class.
        /// </summary>
        public ClinicListRequestResponseExtend()
        {
        }

        /// <summary>
        /// Gets or sets the queue number.
        /// </summary>
        /// <value>The queue number.</value>
        [JsonProperty("queue_number")]
        public QueueNumberViewModel QueueNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the queue number.
        /// </summary>
        /// <value>The type of the queue number.</value>
        [JsonProperty("queue_number_type")]
        public QueueNumberType QueueNumberType { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        [JsonProperty("patient")]
        public PatientViewModel Patient { get; set; }
    }
}
