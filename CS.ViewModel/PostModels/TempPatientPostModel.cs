// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TempPatientPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class TempPatientPostModel.
    /// </summary>
    public class TempPatientPostModel
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonRequired]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonRequired]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonRequired]
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value>
        ///     <c>null</c> if [birthday year only] contains no value, <c>true</c> if [birthday year only]; otherwise,
        ///     <c>false</c>.
        /// </value>
        [JsonProperty("birthday_year_only")]
        public bool? BirthdayYearOnly { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [JsonRequired]
        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [JsonRequired]
        [JsonProperty("district_id")]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [JsonRequired]
        [JsonProperty("ward_id")]
        public string WardId { get; set; }

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
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [JsonProperty("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

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
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [JsonProperty("identity_card_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued date.
        /// </summary>
        /// <value>The identity card number issued date.</value>
        [JsonProperty("ic_issued_date")]
        public DateTime? IdentityCardNumberIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [JsonProperty("ic_issued_place")]
        public string IdentityCardNumberIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("is_re_exam")]
        public bool IsReExam { get; set; }

        [JsonProperty("departments")] public List<DepartmentTempPatientPostModel> Departments { get; set; }

        [JsonProperty("function_id")] public Functions? FunctionId { get; set; }

        [JsonProperty("registration_type")] public string RegistrationType { get; set; }
    }

    public class DepartmentTempPatientPostModel
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("registered_date")] public DateTime RegisteredDate { get; set; }

        [JsonProperty("doctor_code")] public string DoctorCode { get; set; }

        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("booking_id")] public string BookingId { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; } = "KB";

        [JsonProperty("group_dept_name")] public string GroupDeptName { get; set; } = "Khoa Khám Bệnh";

        [JsonProperty("order_line_id")] public string OrderLineId { get; set; }

        [JsonProperty("order_id")] public string OrderId { get; set; }

        [JsonProperty("ip")] public string Ip { get; set; }

        [JsonProperty("fee_id")] public string FeeId { get; set; }
    }
}