// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using static CS.Common.Common.Constants;

namespace CS.VM.Models
{
    /// <summary>
    /// Class TransactionViewModel.
    /// </summary>
    public class TransactionViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [JsonProperty("service_id")]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        [JsonProperty("service_name")]
        public string ServiceName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hold amount.
        /// </summary>
        /// <value>The hold amount.</value>
        [JsonProperty("hold_amount")]
        public decimal HoldAmount { get; set; }

        /// <summary>
        /// Gets or sets the actual amount.
        /// </summary>
        /// <value>The actual amount.</value>
        [JsonProperty("actual_amount")]
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// Gets or sets the paid amount.
        /// </summary>
        /// <value>The paid amount.</value>
        [JsonProperty("paid_amount")]
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; } = TransactionStatusContent.Doing;

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the store.
        /// </summary>
        /// <value>
        /// The name of the store.
        /// </value>
        [JsonProperty("store_name")]
        public string StoreName { get; set; }
    }

    public class TransactionDetailViewModel : TransactionViewModel
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
    }
}
