// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionClinic.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base;
using CS.Common.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CS.Common.Common.Constants;

namespace CS.EF.Models
{
    /// <summary>
    /// Class TransactionClinic.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("transaction_draft_clinic", Schema = "IHM")]
    public class TransactionDraftClinic : BaseObjectExtended, ICloneable
    {
        /// <summary>
        /// Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        [StringLength(36)]
        [Column("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        //[Required]
        //[StringLength(36)]
        //[Column("patient_code")]
        //public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [Required]
        [Column("money")]
        public decimal Amount { get; set; }

        [Column("total_fee")]
        public decimal TotalFee { get; set; }

        [Column("insurance_fee")]
        public decimal InsuranceFee { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        //[Required]
        //[Column("registered_code")]
        //public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        //[Required]
        //[StringLength(36)]
        //[Column("registered_date")]
        //public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Required]
        [Column("type")]
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Required]
        [Column("status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the type of the payment.
        /// </summary>
        /// <value>
        /// The type of the payment.
        /// </value>
        [Column("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the transaction information identifier.
        /// </summary>
        /// <value>The transaction information identifier.</value>
        [Column("transaction_draft_id")]
        public Guid? TransactionDraftId { get; set; }

        /// <summary>
        /// Gets or sets the clinic identifier.
        /// </summary>
        /// <value>The clinic identifier.</value>
        //[Required]
        //[Column("clinic_id")]
        //public Guid ClinicId { get; set; }

        /// <summary>
        /// Gets or sets the is finished.
        /// </summary>
        /// <value>
        /// The is finished.
        /// </value>
        [Column("is_finished")]
        public string IsFinished { get; set; } = StatusServiceConstants.New;

        /// <summary>
        /// Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        [StringLength(36)]
        [Column("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [StringLength(36)]
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [StringLength(36)]
        [Column("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [Column("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        [Column("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Gets or sets the service extend identifier.
        /// </summary>
        /// <value>The service extend identifier.</value>
        [Column("service_extend_id")]
        public Guid? ServiceExtendId { get; set; }

        /// <summary>
        /// Gets or sets the department extend identifier.
        /// </summary>
        /// <value>The department extend identifier.</value>
        [Column("department_extend_id")]
        public Guid? DepartmentExtendId { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        [Column("note")]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        [Column("examination_code")]
        public string ExaminationCode { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("clinic_type")]
        public ClinicType ClinicType { get; set; } = ClinicType.Clinic;

        /// <summary>
        /// Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        //[Column("object_type")]
        //public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the management identifier.
        /// </summary>
        /// <value>
        /// The management identifier.
        /// </value>
        //[Column("management_id")]
        //public string ManagementId { get; set; }

        ///// <summary>
        ///// Gets or sets the clinic.
        ///// </summary>
        ///// <value>The clinic.</value>
        //public virtual Clinic Clinic { get; set; }

        /// <summary>
        /// Gets or sets the transaction information.
        /// </summary>
        /// <value>The transaction information.</value>
        //public virtual TransactionDraft DraftTransactionInfo { get; set; }

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
