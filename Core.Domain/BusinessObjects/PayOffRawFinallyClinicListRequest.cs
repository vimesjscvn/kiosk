using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class PayOffRawFinallyClinicListRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("transaction_code")]
        public string TransactionCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        ///     Gets or sets the clinic data.
        /// </summary>
        /// <value>
        ///     The clinic data.
        /// </value>
        [JsonRequired]
        [JsonProperty("clinic_data")]
        public string ClinicData { get; set; }

        /// <summary>
        ///     Gets or sets the clinic medicine data.
        /// </summary>
        /// <value>
        ///     The clinic medicine data.
        /// </value>
        [JsonRequired]
        [JsonProperty("clinic_medicine_data")]
        public string ClinicMedicineData { get; set; }

        /// <summary>
        ///     Gets or sets the medicine data.
        /// </summary>
        /// <value>
        ///     The medicine data.
        /// </value>
        [JsonRequired]
        [JsonProperty("medicine_data")]
        public string MedicineData { get; set; }

        /// <summary>
        ///     Gets or sets the amount total.
        /// </summary>
        /// <value>
        ///     The amount total.
        /// </value>
        [JsonRequired]
        [JsonProperty("amount_total")]
        public string AmountTotal { get; set; }

        /// <summary>
        ///     Gets or sets the payment status.
        /// </summary>
        /// <value>
        ///     The payment status.
        /// </value>
        [JsonRequired]
        [JsonProperty("payment_status")]
        public string PaymentStatus { get; set; }
    }

    /// <summary>
    /// </summary>
    public class PayOffRawFinallyClinicListResponse : BaseRawResponse
    {
    }
}