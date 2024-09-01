// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TempPatient.cs" company="CS.EF">
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
    ///     User Profile
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("patient_temp", Schema = "IHM")]
    public class TempPatient : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the tekmedi identifier.
        /// </summary>
        /// <value>The tekmedi identifier.</value>
        [Column("tekmedi_uid")]
        public string TekmediId { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [Required]
        [Column("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [Required]
        [Column("birthday")]
        public DateTime? Birthday { get; set; } = DateTime.Now;

        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value><c>true</c> if [birthday year only]; otherwise, <c>false</c>.</value>
        [Required]
        [Column("birthday_year_only")]
        public bool BirthdayYearOnly { get; set; } = true;

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [Required]
        [StringLength(50)]
        [Column("province_id")]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [Required]
        [StringLength(50)]
        [Column("district_id")]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [Required]
        [StringLength(50)]
        [Column("ward_id")]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [Column("ic_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued date.
        /// </summary>
        /// <value>The identity card number issued date.</value>
        [Column("ic_issued_date")]
        public DateTime? IdentityCardNumberIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [Column("ic_issued_place")]
        public string IdentityCardNumberIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>The health insurance number.</value>
        [StringLength(20)]
        [Column("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>The health insurance expired date.</value>
        [Column("health_insurance_expired_date")]
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [StringLength(50)]
        [Column("health_insurance_first_place_code")]
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>The health insurance first place.</value>
        [StringLength(50)]
        [Column("health_insurance_first_place")]
        public string HealthInsuranceFirstPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>The health insurance issued date.</value>
        [Column("health_insurance_issued_date")]
        public DateTime? HealthInsuranceIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [StringLength(20)]
        [Column("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the unit number.
        /// </summary>
        /// <value>The unit number.</value>
        [StringLength(20)]
        [Column("unit_number")]
        public string UnitNumber { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [Column("street")]
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the village.
        /// </summary>
        /// <value>The village.</value>
        [Column("village")]
        public string Village { get; set; }

        /// <summary>
        ///     Gets or sets the type of the identity card.
        /// </summary>
        /// <value>The type of the identity card.</value>
        [Column("ic_type")]
        public string IdentityCardType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Column("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [Column("patient_type")]
        public PatientType PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("patient_id")]
        public Guid? PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>The patient identifier.</value>
        [Column("barcode")]
        public string Barcode { get; set; }

        [Column("area_code")] public string AreaCode { get; set; }

        [Column("ip")] public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }
    }
}