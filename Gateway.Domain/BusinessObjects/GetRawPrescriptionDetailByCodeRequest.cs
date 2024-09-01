using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRawPrescriptionDetailByCodeRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    public class GetRawPrescriptionDetailByCodeData
    {
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("nation")]
        public string Nation { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("workplace")]
        public string Workplace { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("ward")]
        public string Ward { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("identity_card_number")]
        public string IdentityCardNumber { get; set; }

        [JsonProperty("examinations")]
        public List<GetRawExaminationDetailByCodeExaminationData> Examinations { get; set; }

        [JsonProperty("test_results")]
        public List<GetRawExaminationDetailByCodeTestResultData> TestResults { get; set; }

        [JsonProperty("prescriptions")]
        public List<GetRawExaminationDetailByCodePrescriptionData> Prescriptions { get; set; }
    }

    public class GetRawPrescriptionDetailByCodeResponse : BaseRawResponse
    {
        [JsonProperty("result")]
        public GetRawPrescriptionDetailByCodeData Result { get; set; }
    }
}
