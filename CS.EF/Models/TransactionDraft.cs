﻿// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionInfo.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base;
using CS.Common.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    /// Class TransactionInfo.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("transaction_draft", Schema = "IHM")]
    public class TransactionDraft : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [StringLength(512)]
        [Column("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [Column("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [Required]
        [StringLength(36)]
        [Column("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Required]
        [Column("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Required]
        [Column("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [Required]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("total_fee")]
        public decimal TotalFee { get; set; }

        [Column("insurance_fee")]
        public decimal InsuranceFee { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Required]
        [Column("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the store identifier.
        /// </summary>
        /// <value>The store identifier.</value>
        [Column("store_id")]
        public Guid? StoreId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Column("employee_id")]
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the reception identifier.
        /// </summary>
        /// <value>
        /// The reception identifier.
        /// </value>
        [Column("reception_id")]
        public Guid? ReceptionId { get; set; }

        /// <summary>
        /// Gets or sets the type of the payment.
        /// </summary>
        /// <value>
        /// The type of the payment.
        /// </value>
        [Column("pay_provider")]
        public PaymentProvider? PayProvider { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Column("pay_ref_id")]
        public string PaymentRefId { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [Column("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the authorization identifier.
        /// </summary>
        /// <value>
        /// The authorization identifier.
        /// </value>
        [Column("authorization", TypeName = "jsonb")]
        public string Authorization { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [Column("reason", TypeName = "jsonb")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the reception identifier.
        /// </summary>
        /// <value>
        /// The reception identifier.
        /// </value>
        [Column("transaction_info_id")]
        public Guid? TransactionInfoId { get; set; }

        /// <summary>
        /// Gets or sets the type of the examination.
        /// </summary>
        /// <value>
        /// The type of the examination.
        /// </value>
        [Column("examination_type")]
        public string ExaminationType { get; set; }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>The store.</value>
        public virtual ListValueExtend Store { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public virtual SysUser Employee { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// Gets or sets the reception.
        /// </summary>
        /// <value>
        /// The reception.
        /// </value>
        public virtual Reception Reception { get; set; }

        /// <summary>
        /// Gets or sets the transaction information.
        /// </summary>
        /// <value>
        /// The transaction information.
        /// </value>
        public virtual TransactionInfo TransactionInfo { get; set; }

        /// <summary>
        /// Gets or sets the transaction draft clinics.
        /// </summary>
        /// <value>
        /// The transaction draft clinics.
        /// </value>
        public virtual ICollection<TransactionDraftClinic> TransactionDraftClinics { get; set; } = new List<TransactionDraftClinic>();

        /// <summary>
        /// Gets or sets the transaction prescriptions.
        /// </summary>
        /// <value>The transaction prescriptions.</value>
        public virtual ICollection<TransactionDraftPrescription> TransactionDraftPrescriptions { get; set; } = new List<TransactionDraftPrescription>();
    }
}
