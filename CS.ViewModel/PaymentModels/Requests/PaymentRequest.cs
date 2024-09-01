// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PaymentRequest.cs" company="CS.VM">
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
    /// Class PaymentRequest.
    /// </summary>
    public class PaymentRequest
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
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        [Required]
        [JsonProperty("requested_date")]
        public DateTime? RequestedDate { get; set; }
    }

    /// <summary>
    /// Class FinallyRequest.
    /// Implements the <see cref="PaymentRequest" />
    /// </summary>
    /// <seealso cref="PaymentRequest" />
    public class FinallyRequest : PaymentRequest
    {
        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [StringLength(36)]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    /// Class FinallyRequestAtStore.
    /// Implements the <see cref="FinallyRequest" />
    /// </summary>
    /// <seealso cref="FinallyRequest" />
    public class FinallyRequestAtStore : FinallyRequest
    {
        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        /// <value>The store code.</value>
        [Required]
        [JsonProperty("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Required]
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }
    }

    /// <summary>
    /// Class PaymentRequest.
    /// </summary>
    public class CancelTransactionRequest
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Required]
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Required]
        [JsonProperty("transaction_id")]
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        [JsonProperty("requested_date")]
        public DateTime? RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SyncPaidWaitingRequest
    {
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        [Required]
        [JsonProperty("from_date")]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Converts to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        [Required]
        [JsonProperty("to_date")]
        public DateTime ToDate { get; set; }
    }
}
