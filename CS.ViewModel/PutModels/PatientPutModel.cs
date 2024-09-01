// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PatientPutModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Base.ViewModels.PostModel;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.PutModels
{
    /// <summary>
    ///     Class PatientPutModel.
    ///     Implements the <see cref="BasePutModel" />
    /// </summary>
    /// <seealso cref="BasePutModel" />
    public class PatientPutModel : BasePutModel
    {
        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [JsonProperty("CMND")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [JsonProperty("DiaChi")]
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("DienThoai")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [JsonProperty("Duong")]
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>The health insurance expired date.</value>
        [JsonProperty("GiaTriDen")]
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>The health insurance issued date.</value>
        [JsonProperty("GiaTriTu")]
        public DateTime? HealthInsuranceIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonProperty("GioiTinh")]
        public Gender? Gender { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("Ho")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty("HoTen")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [JsonProperty("MaDKKCBBD")]
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [JsonProperty("MaPhuongXa")]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [JsonProperty("MaQuanHuyen")]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [JsonProperty("MaTinhThanh")]
        public string ProvinceId { get; set; }

        [JsonProperty("NameSinh")] public DateTime? BirthdayYearOnly { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued date.
        /// </summary>
        /// <value>The identity card number issued date.</value>
        [JsonProperty("NgayCapCMND")]
        public DateTime? IdentityCardNumberIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty("NgaySinh")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [JsonProperty("NoiCapCMND")]
        public string IdentityCardNumberIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>The health insurance first place.</value>
        [JsonProperty("NoiDKKCBBD")]
        public string HealthInsuranceFirstPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>The health insurance first place.</value>
        [JsonProperty("Passport")]
        public string Passport { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty("Ten")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets the health insurance number.
        /// </summary>
        /// <value>The health insurance number.</value>
        [JsonProperty("MaBHYT")]
        public string HealthInsuranceNumber { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ClinicWithPatientPostModel" /> is priority.
        /// </summary>
        /// <value><c>true</c> if priority; otherwise, <c>false</c>.</value>
        [JsonProperty("UuTien")]
        public bool? Priority { get; set; }

        /// <summary>
        ///     Gets or sets the type of the priority.
        /// </summary>
        /// <value>The type of the priority.</value>
        [JsonProperty("LoaiUuTien")]
        public string PriorityType { get; set; }
    }
}