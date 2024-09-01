// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicWithPatientPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CS.VM.ClinicModels
{
    /// <summary>
    ///     Class ClinicWithPatientPostModel.
    ///     Implements the <see cref="ClinicPostModel" />
    /// </summary>
    /// <seealso cref="ClinicPostModel" />
    public class ClinicWithPatientPostModel : ClinicPostModel
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("Ten")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty("Ho")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("HoTen")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty("NgaySinh")]
        public string Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the birthday year.
        /// </summary>
        /// <value>The birthday year.</value>
        [JsonProperty("NamSinh")]
        public string BirthdayYear { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonProperty("GioiTinh")]
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        [JsonProperty("DiaChi")]
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("DienThoai")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [JsonProperty("CMND")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the passport.
        /// </summary>
        /// <value>The passport.</value>
        [JsonProperty("Passport")]
        public string Passport { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued date.
        /// </summary>
        /// <value>The identity card number issued date.</value>
        [JsonProperty("NgayCapCMND")]
        public string IdentityCardNumberIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [JsonProperty("NoiCapCMND")]
        public string IdentityCardNumberIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [JsonProperty("MaTinhThanh")]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [JsonProperty("MaQuanHuyen")]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [JsonProperty("MaPhuongXa")]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ClinicWithPatientPostModel" /> is priority.
        /// </summary>
        /// <value><c>true</c> if priority; otherwise, <c>false</c>.</value>
        [JsonProperty("UuTien")]
        public bool Priority { get; set; }

        /// <summary>
        ///     Gets or sets the type of the priority.
        /// </summary>
        /// <value>The type of the priority.</value>
        [JsonProperty("LoaiUuTien")]
        public string PriorityType { get; set; }
    }

    /// <summary>
    ///     Class ChangeRegisteredClinicRequest.
    /// </summary>
    public class ChangeRegisteredClinicRequest
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        //[JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        // [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Creates new money.
        /// </summary>
        /// <value>The new money.</value>
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid money")]
        // [JsonProperty("money")]
        public decimal NewMoney { get; set; }

        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        //[JsonProperty("id_specified")]
        public string NewIdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("department_code")]
        public string NewDepartmentCode { get; set; }
    }
}