using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class GetListServiceByRegisteredCodeRequest
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>The health insurance number.</value>
        [JsonProperty("health_insurance_number")]
        public string HealthInsuranceNumber { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        [JsonProperty("identity_card_number")]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}