using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class PostRawCheckInRequest
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonRequired]
        [JsonProperty("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonRequired]
        [JsonProperty("table_code")]
        public string Table { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>
        ///     The table code.
        /// </value>
        [JsonRequired]
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the room code.
        /// </summary>
        /// <value>
        ///     The room code.
        /// </value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; }
    }

    /// <summary>
    /// </summary>
    public class PostRawCheckInResponse
    {
        [JsonProperty("gender")] public string Gender { get; set; }

        [JsonProperty("last_name")] public string LastName { get; set; }

        [JsonProperty("first_name")] public string FirstName { get; set; }

        [JsonProperty("birthday")] public string Birthday { get; set; }

        [JsonProperty("birthday_year_only")] public bool BirthdayYearOnly { get; set; }

        [JsonProperty("province_id")] public string ProvinceId { get; set; }

        [JsonProperty("district_id")] public string DistrictId { get; set; }

        [JsonProperty("ward_id")] public string WardId { get; set; }

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

        [JsonProperty("phone")] public string Phone { get; set; }

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

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("street")] public string Street { get; set; }

        [JsonProperty("is_deleted")] public bool IsDeleted { get; set; }

        [JsonProperty("is_active")] public bool IsActive { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("updated_date")] public DateTime UpdatedDate { get; set; }
    }
}