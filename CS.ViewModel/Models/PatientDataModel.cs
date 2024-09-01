using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    public class PatientDataModel
    {
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
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value><c>true</c> if [birthday year only]; otherwise, <c>false</c>.</value>
        [JsonProperty("birthday_year_only")]
        public bool BirthdayYearOnly { get; set; } = true;

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [JsonProperty("province_id")]
        public string ProvinceCode { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [JsonProperty("district_id")]
        public string DistrictCode { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [JsonProperty("ward_id")]
        public string WardCode { get; set; }

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
        public string IdentityCardNumberIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number issued place.
        /// </summary>
        /// <value>The identity card number issued place.</value>
        [JsonProperty("ic_issued_place")]
        public string IdentityCardNumberIssuedPlace { get; set; }

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
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
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
        ///     Gets or sets the type of the identity card.
        /// </summary>
        /// <value>The type of the identity card.</value>
        [JsonProperty("ic_type")]
        public string IdentityCardType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [JsonProperty("patient_type")]
        public PatientType PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card identifier.
        /// </summary>
        /// <value>The tekmedi card identifier.</value>
        [JsonProperty("tekmedi_card_id")]
        public Guid? TekmediCardId { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonProperty("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the balance.
        /// </summary>
        /// <value>
        ///     The balance.
        /// </value>
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        ///     Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [JsonProperty("updated_date")]
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        /// <summary>
        ///     Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the ngay sinh.
        /// </summary>
        /// <value>The ngay sinh.</value>
        public string DateOfBirth { get; set; }

        /// <summary>
        ///     Gets or sets the nam sinh.
        /// </summary>
        /// <value>The nam sinh.</value>
        public string YearOfBirth { get; set; }

        /// <summary>
        ///     Gets or sets the CMND.
        /// </summary>
        /// <value>The CMND.</value>
        public string IdentityNumber { get; set; }

        /// <summary>
        ///     Gets or sets the passport.
        /// </summary>
        /// <value>The passport.</value>
        public string Passport { get; set; }

        /// <summary>
        ///     Gets or sets the ngay cap CMND.
        /// </summary>
        /// <value>The ngay cap CMND.</value>
        public string IdentityNumberIssueDate { get; set; }

        /// <summary>
        ///     Gets or sets the noi cap CMND.
        /// </summary>
        /// <value>The noi cap CMND.</value>
        public string IdentityNumberIssuePlace { get; set; }

        /// <summary>
        ///     Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        public string PhoneNumber { get; set; }
    }
}