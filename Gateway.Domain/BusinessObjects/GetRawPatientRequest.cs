using Newtonsoft.Json;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRawPatientRequest
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("patient_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("registered_code", NullValueHandling = NullValueHandling.Ignore)]
        public string RegisteredCode { get; set; }

        [JsonProperty("identity_card_number", NullValueHandling = NullValueHandling.Ignore)]
        public string IdentityCardNumber { get; set; }

        [JsonProperty("heatlh_insurance_number", NullValueHandling = NullValueHandling.Ignore)]
        public string HealthInsuranceNumber { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetRawPatientResponse : BaseRawResponse
    {
        /// <summary>
        /// Gets or sets the thong tin benh nhan.
        /// </summary>
        /// <value>The thong tin benh nhan.</value>
        [JsonProperty("patient_info")]
        public GetRawPatientData PatientInfo { get; set; }
    }

    /// <summary>
    /// Class FindByPatientCodeExternalData.
    /// </summary>
    public class GetRawPatientData
    {
        /// <summary>
        /// Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }
        /// <summary>
        /// Gets or sets the ho.
        /// </summary>
        /// <value>The ho.</value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the ten.
        /// </summary>
        /// <value>The ten.</value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the gioi tinh.
        /// </summary>
        /// <value>The gioi tinh.</value>
        [JsonProperty("gender")]
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the ngay sinh.
        /// </summary>
        /// <value>The ngay sinh.</value>
        [JsonProperty("birthday")]
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the nam sinh.
        /// </summary>
        /// <value>The nam sinh.</value>
        [JsonProperty("year_of_birth")]
        public string YearOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the CMND.
        /// </summary>
        /// <value>The CMND.</value>
        [JsonProperty("identity_number")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Gets or sets the passport.
        /// </summary>
        /// <value>The passport.</value>
        [JsonProperty("passport")]
        public string Passport { get; set; }
        /// <summary>
        /// Gets or sets the ngay cap CMND.
        /// </summary>
        /// <value>The ngay cap CMND.</value>
        [JsonProperty("identity_number_issue_date")]
        public string IdentityNumberIssueDate { get; set; }
        /// <summary>
        /// Gets or sets the noi cap CMND.
        /// </summary>
        /// <value>The noi cap CMND.</value>
        [JsonProperty("identity_number_issue_place")]
        public string IdentityNumberIssuePlace { get; set; }
        /// <summary>
        /// Gets or sets the duong.
        /// </summary>
        /// <value>The duong.</value>
        [JsonProperty("street")]
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the ma tinh thanh.
        /// </summary>
        /// <value>The ma tinh thanh.</value>
        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }
        /// <summary>
        /// Gets or sets the ma quan huyen.
        /// </summary>
        /// <value>The ma quan huyen.</value>
        [JsonProperty("district_code")]
        public string DistrictCode { get; set; }
        /// <summary>
        /// Gets or sets the ma phuong xa.
        /// </summary>
        /// <value>The ma phuong xa.</value>
        [JsonProperty("ward_code")]
        public string WardCode { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        [JsonProperty("health_insurance_issued_date")]
        public string HealthInsuranceIssuedDate { get; set; }

        [JsonProperty("health_insurance_expired_date")]
        public string HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        /// Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>The health insurance first place code.</value>
        [JsonProperty("health_insurance_first_place_code")]
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        /// Gets or sets the health insurance first place.
        /// </summary>
        /// <value>The health insurance first place.</value>
        [JsonProperty("health_insurance_first_place")]
        public string HealthInsuranceFirstPlace { get; set; }
    }
}
