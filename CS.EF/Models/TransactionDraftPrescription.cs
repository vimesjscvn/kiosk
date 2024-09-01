// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionPrescription.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base;
using CS.Common.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    /// Class TransactionPrescription.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("transaction_draft_prescription", Schema = "IHM")]
    public class TransactionDraftPrescription : BaseObjectExtended, ICloneable
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
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Required]
        [Column("price")]
        public decimal Price { get; set; }

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
        /// Gets or sets the transaction information identifier.
        /// </summary>
        /// <value>The transaction information identifier.</value>
        [Column("transaction_draft_id")]
        public Guid? TransactionDraftId { get; set; }

        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        /// <value>The prescription identifier.</value>
        [Column("prescription_id")]
        public Guid? PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        /// <value>The prescription identifier.</value>
        [Required]
        [Column("prescription_data_id")]
        public string PrescriptionDataId { get; set; }

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
        /// Gets or sets the type of the prescription.
        /// </summary>
        /// <value>
        /// The type of the prescription.
        /// </value>
        [Column("prescription_type")]
        public PrescriptionType PrescriptionType { get; set; } = PrescriptionType.UseWithService;

        ///// <summary>
        ///// Gets or sets the transaction draft.
        ///// </summary>
        ///// <value>
        ///// The transaction draft.
        ///// </value>
        //public virtual TransactionDraft TransactionDraft { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
