using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     User Profile
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("online_patient", Schema = "Online")]
    public class PatientOnline : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        [Column("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [Column("department_code")]
        [StringLength(36)]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [Column("patient_code")]
        [StringLength(50)]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        [Column("birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the birthday year only.
        /// </summary>
        /// <value>
        ///     The birthday year only.
        /// </value>
        [Column("birthday_year_only")]
        public bool? BirthdayYearOnly { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        [Column("gender")]
        public int Gender { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        [Column("street")]
        [StringLength(500)]
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>
        ///     The province identifier.
        /// </value>
        [Column("province_id")]
        [StringLength(36)]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>
        ///     The district identifier.
        /// </value>
        [Column("district_id")]
        [StringLength(36)]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>
        ///     The ward identifier.
        /// </value>
        [Column("ward_id")]
        [StringLength(36)]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>
        ///     The phone.
        /// </value>
        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>
        ///     The identity card number.
        /// </value>
        [Column("ic_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued date.
        /// </summary>
        /// <value>
        ///     The identity card number issued date.
        /// </value>
        [Column("ic_issued_date")]
        public DateTime? IdentityCardNumberIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>
        ///     The identity card number issued place.
        /// </value>
        [Column("ic_issued_place")]
        public string IdentityCardNumberIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the passport.
        /// </summary>
        /// <value>
        ///     The passport.
        /// </value>
        [Column("passport")]
        public string Passport { get; set; }

        /// <summary>
        ///     Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///     The type of the service.
        /// </value>
        [Column("service_type")]
        [StringLength(36)]
        public string ServiceType { get; set; }

        /// <summary>
        ///     Gets or sets the specialist code.
        /// </summary>
        /// <value>
        ///     The specialist code.
        /// </value>
        [Column("specialist_code")]
        public string SpecialistCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [Column("registered_date")]
        public string RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [Column("status")]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the apply date.
        /// </summary>
        /// <value> The apply date. </value>
        [Column("apply_date")]
        public DateTime ApplyDate { get; set; }

        /// <summary>
        ///     Gets or sets the apply date.
        /// </summary>
        /// <value> The is checked. </value>
        [Column("is_checked_in")]
        public bool? IsCheckedIn { get; set; }

        /// <summary>
        ///     Gets or sets the apply date.
        /// </summary>
        /// <value> The is deleted. </value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets the is active.
        /// </summary>
        /// <value> The is deleted. </value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets time checked.
        /// </summary>
        /// <value>The time checked in.</value>
        [Column("time_checked")]
        public DateTime? TimeChecked { get; set; }

        /// <summary>
        ///     Gets or sets department id.
        /// </summary>
        /// <value>The time checked in.</value>
        [Required]
        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets switch board id.
        /// </summary>
        /// <value>The time checked in.</value>
        [Column("switch_board_id")]
        public Guid SwitchBoardId { get; set; }

        /// <summary>
        ///     Gets or sets the booking code.
        /// </summary>
        /// <value>The time checked in.</value>
        [Column("booking_code")]
        public string BookingCode { get; set; }

        /// <summary>
        ///     Gets or sets the hash.
        /// </summary>
        /// <value>The time checked in.</value>
        [Column("hash")]
        public string Hash { get; set; }

        /// <summary>
        ///     Gets or sets the list number online id.
        /// </summary>
        /// <value>The time start.</value>
        [Required]
        [Column("list_number_online_id")]
        public Guid ListNumberOnlineId { get; set; }

        [Required] [Column("synced")] public bool Synced { get; set; }

        public virtual ListValueExtend Department { get; set; }

        public virtual SysUser SwitchBoard { get; set; }

        public virtual ListNumberOnline ListNumberOnline { get; set; }
    }
}