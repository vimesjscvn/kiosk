// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueExtend.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="CS.Base.BaseObjectExtended" />
    [Table("department_service", Schema = "ListMgmt")]
    public class DepartmentService : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        [Column("dept_id")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        [Column("service_id")]
        public Guid ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        [Column("room_id")]
        public Guid RoomId { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [Column("examination_id")]
        public Guid ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the type of the usage.
        /// </summary>
        /// <value>
        ///     The type of the usage.
        /// </value>
        [Column("usage_type")]
        public UsageType UsageType { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [Column("type")]
        public CreatedType Type { get; set; }

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        [Column("room_code")]
        public string RoomCode { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [Column("service_code")]
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [Column("examination_code")]
        public string ExaminationCode { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [Column("object_type")]
        public string ObjectType { get; set; }


        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        public virtual ListValueExtend Service { get; set; }

        /// <summary>
        ///     Gets or sets the department.
        /// </summary>
        /// <value>
        ///     The department.
        /// </value>
        public virtual ListValue Department { get; set; }

        /// <summary>
        ///     Gets or sets the room.
        /// </summary>
        /// <value>
        ///     The room.
        /// </value>
        public virtual ListValueExtend Room { get; set; }

        /// <summary>
        ///     Gets or sets the examination.
        /// </summary>
        /// <value>
        ///     The examination.
        /// </value>
        public virtual ListValueExtend Examination { get; set; }
    }
}