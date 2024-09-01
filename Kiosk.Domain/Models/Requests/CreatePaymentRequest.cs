using Newtonsoft.Json;
using System;

namespace TEK.Payment.Domain.Models.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatePaymentRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("transaction_info_id")]
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("payment_provider")]
        public string PaymentProvider { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("device_id")]
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        /// <value>
        /// The store code.
        /// </value>
        [JsonProperty("store_code")]
        public string StoreCode { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        [JsonProperty("employee_id")]
        public Guid EmployeeId { get; set; }
    }
}
