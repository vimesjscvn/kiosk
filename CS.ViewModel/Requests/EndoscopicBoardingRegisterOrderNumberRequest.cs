using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class EndoscopicBoardingRegisterOrderNumberRequest
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonRequired]
        [JsonProperty("hospital_admission_code")]
        public string HospitalAdmissionCode { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonRequired]
        [JsonProperty("group_code")]
        public string GroupCode { get; set; }

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
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

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
    }
}