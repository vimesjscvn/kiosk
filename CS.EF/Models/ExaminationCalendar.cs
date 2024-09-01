using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="CS.Base.BaseObjectExtended" />
    [Table("examination_calendar", Schema = "IHM")]
    public class ExaminationCalendar : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [Column("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>
        ///     The doctor code.
        /// </value>
        [Column("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [Column("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the is have clinic.
        /// </summary>
        /// <value>
        ///     The is have clinic.
        /// </value>
        [Column("is_have_clinic")]
        public string IsHaveClinic { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        ///     The type of the patient.
        /// </value>
        [Column("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        [Column("patient_id")]
        public Guid PatientId { get; set; }

        [Column("group_dept_code")] public string GroupDeptCode { get; set; }

        [Column("booking_id")] public string BookingId { get; set; }

        [Column("status_code")] public string StatusCode { get; set; }

        [Column("registered_code")] public string RegisteredCode { get; set; }

        [NotMapped] public string DoctorName { get; set; }

        [NotMapped] public string StatusName { get; set; }

        [NotMapped] public string GroupDeptName { get; set; }

        [NotMapped] public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>
        ///     The patient.
        /// </value>
        public virtual Patient Patient { get; set; }

        [NotMapped] public string WaitingNumber { get; set; }

        [NotMapped] public string MaxNumber { get; set; }
    }
}