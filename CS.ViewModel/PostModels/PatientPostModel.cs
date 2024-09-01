// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PatientPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Common;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class PatientPostModel.
    /// </summary>
    public class PatientPostModel
    {
        //[JsonProperty("first_name")]
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        //[JsonProperty("last_name")]
        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        //[JsonProperty("code")]
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        //[JsonProperty("gender")]
        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public Gender Gender { get; set; }

        //[JsonProperty("birthday")]
        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime? Birthday { get; set; }

        //[JsonProperty("birthday_year_only")]
        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value>
        ///     <c>null</c> if [birthday year only] contains no value, <c>true</c> if [birthday year only]; otherwise,
        ///     <c>false</c>.
        /// </value>
        public bool? BirthdayYearOnly { get; set; }

        //[JsonProperty("province_id")]
        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        public string ProvinceId { get; set; }

        //[JsonProperty("district_id")]
        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        public string DistrictId { get; set; }

        //[JsonProperty("ward_id")]
        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        public string WardId { get; set; }

        //[JsonProperty("street")]
        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        public string Street { get; set; }

        //[JsonProperty("village")]
        /// <summary>
        ///     Gets or sets the village.
        /// </summary>
        /// <value>The village.</value>
        public string Village { get; set; }

        //[JsonProperty("phone")]
        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        //[JsonProperty("tekmedi_card_number")]
        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        public string TekmediCardNumber { get; set; }

        //[JsonProperty("health_insurance_number")]
        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>The health insurance number.</value>
        public string HealthInsuranceNumber { get; set; }

        //[JsonProperty("health_insurance_expired_date")]
        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>The health insurance expired date.</value>
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        //[JsonProperty("health_insurance_first_place_code")]
        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        public string HealthInsuranceFirstPlaceCode { get; set; }

        //[JsonProperty("health_insurance_first_place")]
        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>The health insurance first place.</value>
        public string HealthInsuranceFirstPlace { get; set; }

        //[JsonProperty("health_insurance_issued_date")]
        /// <summary>
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>The health insurance issued date.</value>
        public DateTime? HealthInsuranceIssuedDate { get; set; }
    }
}