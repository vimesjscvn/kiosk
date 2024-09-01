// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueueNumberTemp.cs" company="CS.EF">
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
    ///     Class QueueNumberTemp.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("queue_number_temp", Schema = "IHM")]
    public class QueueNumberTemp : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [Required]
        [Column("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Required]
        [Column("type")]
        public PatientType Type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        [Column("is_selected")]
        public bool IsSelected { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is called.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is called; otherwise, <c>false</c>.
        /// </value>
        [Column("is_called")]
        public bool? IsCalled { get; set; }

        /// <summary>
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>The area code.</value>
        [Column("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>The table code.</value>
        [Column("table_code")]
        public string TableCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is finished.
        /// </summary>
        /// <value><c>true</c> if this instance is finished; otherwise, <c>false</c>.</value>
        [Column("is_finished")]
        public bool IsFinished { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("patient_id")]
        public Guid? PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the department extend identifier.
        /// </summary>
        /// <value>The department extend identifier.</value>
        [Column("department_extend_id")]
        public Guid? DepartmentExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the queue number identifier.
        /// </summary>
        /// <value>The queue number identifier.</value>
        [Column("queue_number_id")]
        public Guid? QueueNumberId { get; set; }

        /// <summary>
        ///     Gets or sets the clinic identifier.
        /// </summary>
        /// <value>
        ///     The clinic identifier.
        /// </value>
        [Column("clinic_id")]
        public Guid? ClinicId { get; set; }

        /// <summary>
        ///     Gets or sets the table identifier.
        /// </summary>
        /// <value>
        ///     The table identifier.
        /// </value>
        [Column("table_id")]
        public Guid? TableId { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        ///     Gets or sets the department extend.
        /// </summary>
        /// <value>The department extend.</value>
        public virtual ListValueExtend DepartmentExtend { get; set; }

        /// <summary>
        ///     Gets or sets the queue number.
        /// </summary>
        /// <value>The queue number.</value>
        public virtual QueueNumber QueueNumber { get; set; }

        /// <summary>
        ///     Gets or sets the clinic.
        /// </summary>
        /// <value>
        ///     The clinic.
        /// </value>
        public virtual Clinic Clinic { get; set; }

        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public virtual Table Table { get; set; }
    }
}