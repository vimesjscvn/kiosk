// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Prescription.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    /// Class Prescription.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("prescription", Schema = "IHM")]
    public class Prescription : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [Column("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [StringLength(36)]
        [Column("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        /// <value>The prescription identifier.</value>
        [Column("prescription_id")]
        public string PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the prescription detail identifier.
        /// </summary>
        /// <value>The prescription detail identifier.</value>
        [Column("prescription_detail_id")]
        public string PrescriptionDetailId { get; set; }

        /// <summary>
        /// Gets or sets the medicine code.
        /// </summary>
        /// <value>The medicine code.</value>
        [Column("medicine_code")]
        public string MedicineCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the medicine.
        /// </summary>
        /// <value>The name of the medicine.</value>
        [Column("medicine_name")]
        public string MedicineName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [Column("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Column("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("total_fee")]
        public decimal TotalFee { get; set; }

        [Column("insurance_fee")]
        public decimal InsuranceFee { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Column("status")]
        public PrescriptionStatus Status { get; set; } = PrescriptionStatus.New;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public PrescriptionType Type { get; set; }

        /// <summary>
        /// Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Gets or sets the reception identifier.
        /// </summary>
        /// <value>
        /// The reception identifier.
        /// </value>
        [Column("reception_id")]
        public Guid? ReceptionId { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// Gets or sets the transaction prescriptions.
        /// </summary>
        /// <value>The transaction prescriptions.</value>
        //public virtual ICollection<TransactionPrescription> TransactionPrescriptions { get; set; }

        /// <summary>
        /// Gets or sets the reception.
        /// </summary>
        /// <value>
        /// The reception.
        /// </value>
        public virtual Reception Reception { get; set; }
    }
}
