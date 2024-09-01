// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TempPatientViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class TempPatientViewModel.
    ///     Implements the <see cref="PatientViewModel" />
    /// </summary>
    /// <seealso cref="PatientViewModel" />
    public class TempPatientViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PatientViewModel" /> class.
        /// </summary>
        public TempPatientViewModel()
        {
            QueueNumberViewModel = new List<QueueNumberViewModel>();
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi identifier.
        /// </summary>
        /// <value>The tekmedi identifier.</value>
        [JsonProperty("tekmedi_uid")]
        public string TekmediId { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value><c>true</c> if [birthday year only]; otherwise, <c>false</c>.</value>
        [JsonProperty("birthday_year_only")]
        public bool BirthdayYearOnly { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [JsonProperty("district_id")]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [JsonProperty("ward_id")]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>The health insurance number.</value>
        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>The health insurance expired date.</value>
        [JsonProperty("health_insurance_expired_date")]
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [JsonProperty("health_insurance_first_place_code")]
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>The health insurance first place.</value>
        [JsonProperty("health_insurance_first_place")]
        public string HealthInsuranceFirstPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>The health insurance issued date.</value>
        [JsonProperty("health_insurance_issued_date")]
        public DateTime? HealthInsuranceIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi cardnumber.
        /// </summary>
        /// <value>The tekmedi cardnumber.</value>
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the unit number.
        /// </summary>
        /// <value>The unit number.</value>
        [JsonProperty("unit_number")]
        public string UnitNumber { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the village.
        /// </summary>
        /// <value>The village.</value>
        [JsonProperty("village")]
        public string Village { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty("price")]
        public decimal? Price { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [JsonProperty("identity_card_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [JsonProperty("patient_type")]
        public PatientType PatientType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the queue number view model.
        /// </summary>
        /// <value>The queue number view model.</value>
        [JsonProperty("data")]
        public List<QueueNumberViewModel> QueueNumberViewModel { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }
    }
}