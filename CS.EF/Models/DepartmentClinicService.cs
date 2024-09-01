﻿using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    [Table("department_service", Schema = "Dept")]
    public class DepartmentClinicService : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        [Column("room_code")]
        public string RoomCode { get; set; }

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [Column("service_code")]
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>
        ///     The examination identifier.
        /// </value>
        [Column("examination_code")]
        public string ExaminationCode { get; set; }
    }
}