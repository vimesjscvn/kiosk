// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueueNumber.cs" company="CS.EF">
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
    ///     Class QueueNumber.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("queue_number", Schema = "IHM")]
    public class QueueNumber : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
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
        public PatientType Type { get; set; } = PatientType.Normal;

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
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>The area code.</value>
        [Column("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("patient_id")]
        public Guid PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the department extend identifier.
        /// </summary>
        /// <value>The department extend identifier.</value>
        [Column("department_extend_id")]
        public Guid DepartmentExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the clinic identifier.
        /// </summary>
        /// <value>The clinic identifier.</value>
        [Column("clinic_id")]
        public Guid? ClinicId { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [Column("registered_date")]
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        [Column("registered_code")] public string RegisteredCode { get; set; } = "";

        [Column("group_dept_code")] public string GroupDeptCode { get; set; }

        [Column("booking_id")] public string BookingId { get; set; }

        [Column("department_name")] public string DepartmentName { get; set; }

        [Column("department_number")] public string DepartmentNumber { get; set; }

        [Column("department_address")] public string DepartmentAddress { get; set; }

        [Column("order_id")] public int OrderId { get; set; }

        [Column("is_finished")] public bool IsFinished { get; set; }

        /// <summary>
        ///     Gets or sets the clinic identifier.
        /// </summary>
        /// <value>The clinic identifier.</value>
        [Column("url_audio")]
        public string UrlAudio { get; set; }

        /// <summary>
        ///     Gets or sets the clinic identifier.
        /// </summary>
        /// <value>The clinic identifier.</value>
        [Column("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the clinic identifier.
        /// </summary>
        /// <value>The clinic identifier.</value>
        [Column("group_code")]
        public string GroupCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        ///     Gets or sets the clinic.
        /// </summary>
        /// <value>The clinic.</value>
        public virtual Clinic Clinic { get; set; }

        /// <summary>
        ///     Gets or sets the department extend.
        /// </summary>
        /// <value>The department extend.</value>
        public virtual ListValueExtend DepartmentExtend { get; set; }

        [NotMapped] public string Title { get; set; }

        [NotMapped] public string GroupDeptName { get; set; }

        [NotMapped] public List<ServiceQueueNumber> Services { get; set; } = new List<ServiceQueueNumber>();
    }

    public class ServiceQueueNumber
    {
        public string ServiceName { get; set; }

        public string ServiceId { get; set; }

        public string GroupServiceId { get; set; }

        public string GroupServiceName { get; set; }
    }
}