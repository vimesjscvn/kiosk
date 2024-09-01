// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseTekmediCardHistory.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base;
using CS.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    /// Class BaseTekmediCardHistory.
    /// Implements the <see cref="BaseObject" />
    /// </summary>
    /// <seealso cref="BaseObject" />
    public class BaseTekmediCardHistory : BaseObject
    {
        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [Column("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Column("price")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("patient_id")]
        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        [Column("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Column("status")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Creates new tekmedicardnumber.
        /// </summary>
        /// <value>The new tekmedi card number.</value>
        [Column("new_tekmedi_card_number")]
        public string NewTekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the tekmedi card identifier.
        /// </summary>
        /// <value>The tekmedi card identifier.</value>
        [Column("tekmedi_card_id")]
        public Guid TekmediCardId { get; set; }

        /// <summary>
        /// Gets or sets the before value.
        /// </summary>
        /// <value>
        /// The before value.
        /// </value>
        [Column("before_value")]
        public decimal? BeforeValue { get; set; }

        /// <summary>
        /// Gets or sets the after value.
        /// </summary>
        /// <value>
        /// The after value.
        /// </value>
        [Column("after_value")]
        public decimal? AfterValue { get; set; }

        /// <summary>
        /// Gets or sets the payment type id.
        /// </summary>
        /// <value>
        /// The payment type id value.
        /// </value>
        [Column("payment_type_id")]
        public Guid? PaymentTypeId { get; set; }

        [Column("register_code")]
        public string RegisterCode { get; set; }

        [Column("invoice_no")]
        public int? InvoiceNo { get; set; }

        [Column("serial_no")]
        public string SerialNo { get; set; }

        [Column("recv_no")]
        public int? RecvNo { get; set; }

        [Column("book_no")]
        public string BookNo { get; set; }

        /// <summary>
        /// Gets or sets list value extend.
        /// </summary>
        /// <value>The list value extend.</value>
        public virtual ListValueExtend PaymentType { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public virtual SysUser Employee { get; set; }
    }
}
