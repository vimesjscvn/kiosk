using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRawListExaminationByCodeRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        [JsonProperty("identity_card_number")]
        public string IdentityCardNumber { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetRawListExaminationByCodeResponse : BaseRawResponse
    {
        /// <summary>
        /// Gets or sets the thong tin benh nhan.
        /// </summary>
        /// <value>The thong tin benh nhan.</value>
        [JsonProperty("result")]
        public List<GetRawListExaminationByCodeData> Result { get; set; }
    }

    /// <summary>
    /// Class FindByExaminationByRegisteredCodeCodeExternalData.
    /// </summary>
    public class GetRawListExaminationByCodeData
    {
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("patient_type")]
        public string PatientType { get; set; }
    }
}
