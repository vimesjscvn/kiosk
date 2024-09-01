using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawRegisterExaminationDataRequest
    {
        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        [JsonProperty("fee_id")]
        public string FeeId { get; set; }
    }

    public class PostRawRegisterExaminationRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
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
        public string Birthday { get; set; }
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
        public string IdentityCardNumber { get; set; }
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
        public string IdentityCardNumberIssuedDate { get; set; }
        /// <summary>
        /// Gets or sets the noi cap CMND.
        /// </summary>
        /// <value>The noi cap CMND.</value>
        [JsonProperty("identity_number_issue_place")]
        public string IdentityCardNumberIssuedPlace { get; set; }
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

        [JsonProperty("registration_type")]
        public string RegistrationType { get; set; }

        [JsonProperty("departments")]
        public List<PostRawRegisterExaminationDataRequest> Departments { get; set; }
    }

    public class PostRawRegisterExaminationResponseData
    {
        [JsonProperty("registered_code")] 
        public string RegisteredCode { get; set; }

        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("patient_name")]
        public string PatientName { get; set; }

        [JsonProperty("year_of_birth")]
        public string YearOfBirth { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("detail_address")]
        public string DetailAddress { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("group_dept_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")]
        public string GroupDeptName { get; set; }

        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        [JsonProperty("department_address")]
        public string DepartmentAddress { get; set; }

        [JsonProperty("qr_code")]
        public string QRCode { get; set; }
    }

    public class PostRawRegisterExaminationResponse : BaseRawResponse
    {
        [JsonProperty("result")]
        public List<PostRawRegisterExaminationResponseData> Result { get; set; }
    }
}
