// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionReportViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base.ViewModels;
using CS.Common.Common;
using Newtonsoft.Json;
using System;

namespace CS.VM.Models
{
    /// <summary>
    /// Class TransactionReportViewModel.
    /// </summary>
    public class TransactionReportViewModel : BaseViewModelExtended
    {
        /// <summary>
        /// Gets or sets the transaction code tek.
        /// </summary>
        /// <value>The transaction code tek.</value>
        [JsonProperty("transaction_code_Tek")]
        public string TransactionCodeTEK { get; set; }
        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }
        /// <summary>
        /// Gets or sets the tekmedi uid.
        /// </summary>
        /// <value>The tekmedi uid.</value>
        [JsonProperty("tekmedi_Uid")]
        public string TekmediUID { get; set; }
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
        /// <summary>
        /// Gets or sets the registered number.
        /// </summary>
        /// <value>The registered number.</value>
        [JsonProperty("registered_number")]
        public string RegisteredNumber { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("full_name")]
        public string FullName => string.Format("{0} {1}", LastName, FirstName);
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the total money required.
        /// </summary>
        /// <value>The total money required.</value>
        [JsonProperty("total_money_required")]
        public decimal TotalMoneyRequired { get; set; }
        /// <summary>
        /// Gets or sets the total money hold.
        /// </summary>
        /// <value>The total money hold.</value>
        [JsonProperty("total_money_hold")]
        public decimal TotalMoneyHold { get; set; }
        /// <summary>
        /// Gets or sets the total payment.
        /// </summary>
        /// <value>The total payment.</value>
        [JsonProperty("total_payment")]
        public decimal TotalPayment { get; set; }
        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public TransactionReportStatus Status { get; set; }

    }
}
