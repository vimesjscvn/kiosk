using System;
using Newtonsoft.Json;

namespace CS.VM.UserModels
{
    public class SysUserJson
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public Guid Id { get; set; }

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
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

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
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [JsonProperty("sex")]
        public int? Sex { get; set; }

        /// <summary>
        ///     Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [JsonProperty("birthdate")]
        public DateTime? BirthDate { get; set; }

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
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [JsonProperty("identity_card_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}