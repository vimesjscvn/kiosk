// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Clinic.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Clinic.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("clinic", Schema = "IHM")]
    public class Clinic : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
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
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        //[Column("registered_date")]
        //public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        //[StringLength(36)]
        //[Column("registered_code")]
        //public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        //[StringLength(36)]
        //[Column("patient_type")]
        //public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [Column("money")]
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [StringLength(36)]
        [Column("status")]
        public ClinicStatus? Status { get; set; } = ClinicStatus.New;

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        [StringLength(36)]
        [Column("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [StringLength(36)]
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [StringLength(36)]
        [Column("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [Column("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [Column("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the is finished.
        /// </summary>
        /// <value>The is finished.</value>
        [Column("is_finished")]
        public string IsFinished { get; set; } = Constants.StatusServiceConstants.New;

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("clinic_type")]
        public ClinicType ClinicType { get; set; } = ClinicType.Clinic;

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        [Column("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the service extend identifier.
        /// </summary>
        /// <value>The service extend identifier.</value>
        [Column("service_extend_id")]
        public Guid? ServiceExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the department extend identifier.
        /// </summary>
        /// <value>The department extend identifier.</value>
        [Column("department_extend_id")]
        public Guid DepartmentExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        [Column("note")]
        public string Note { get; set; }

        /// <summary>
        ///     Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        [Column("examination_code")]
        public string ExaminationCode { get; set; }

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

        /// <summary>
        ///     Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///     The type of the service.
        /// </value>
        [Column("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>The examination identifier.</value>
        [Column("examination_id")]
        public Guid? ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>The examination identifier.</value>
        [Column("examination_extend_id")]
        public Guid? ExaminationExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the reception identifier.
        /// </summary>
        /// <value>
        ///     The reception identifier.
        /// </value>
        [Column("reception_id")]
        public Guid? ReceptionId { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Column("room_code")]
        public string GroupDeptCode { get; set; }

        [Column("total_fee")] public decimal TotalFee { get; set; }

        [Column("insurance_fee")] public decimal InsuranceFee { get; set; }

        [Column("registered_code")] public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        ///     Gets or sets the service extend.
        /// </summary>
        /// <value>The service extend.</value>
        public virtual ListValueExtend ServiceExtend { get; set; }

        /// <summary>
        ///     Gets or sets the department extend.
        /// </summary>
        /// <value>The department extend.</value>
        public virtual ListValueExtend DepartmentExtend { get; set; }

        /// <summary>
        ///     Gets or sets the examination.
        /// </summary>
        /// <value>The examination.</value>
        public virtual ListValueExtend ExaminationExtend { get; set; }

        /// <summary>
        ///     Gets or sets the queue number.
        /// </summary>
        /// <value>The queue number.</value>
        public virtual QueueNumber QueueNumber { get; set; }

        ///// <summary>
        ///// Gets or sets the transaction clinics.
        ///// </summary>
        ///// <value>The transaction clinics.</value>
        //public virtual ICollection<TransactionClinic> TransactionClinics { get; set; }

        /// <summary>
        ///     Gets or sets the reception.
        /// </summary>
        /// <value>
        ///     The reception.
        /// </value>
        public virtual Reception Reception { get; set; }
    }
}