// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PrescriptionPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.PostModels
{
    /// <summary>
    /// Class PrescriptionPostModel.
    /// </summary>
    public class PrescriptionPostModel
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        /// <value>The prescription identifier.</value>
        [JsonProperty("prescription_id")]
        public string PrescriptionDataId { get; set; }

        /// <summary>
        /// Gets or sets the prescription detail identifier.
        /// </summary>
        /// <value>The prescription detail identifier.</value>
        [JsonProperty("prescription_extend_id")]
        public string PrescriptionDetailId { get; set; }

        /// <summary>
        /// Gets or sets the medicine code.
        /// </summary>
        /// <value>The medicine code.</value>
        [JsonProperty("medicine_code")]
        public string MedicineCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the medicine.
        /// </summary>
        /// <value>The name of the medicine.</value>
        [JsonProperty("medicine_name")]
        public string MedicineName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        public decimal TotalFee { get; set; }
        public decimal InsuranceFee { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public PrescriptionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public PrescriptionType Type { get; set; }
    }
}
