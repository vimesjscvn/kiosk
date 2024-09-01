using System;
using CS.Base.ViewModels;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class PaidWaitingViewModel : BaseViewModel
    {
        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        /// <summary>
        ///     Gets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        [JsonProperty("patient_id")]
        public Guid? PatientId { get; set; }

        /// <summary>
        ///     Gets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonProperty("status")]
        public PaidWaitingStatus Status { get; set; }

        [JsonProperty("amount")] public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi identifier.
        /// </summary>
        /// <value>The tekmedi identifier.</value>
        [JsonProperty(PropertyName = "tekmedi_uid")]
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
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("full_name")]
        public string FullName => string.Format("{0} {1}", LastName, FirstName);

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonProperty(PropertyName = "gender")]
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        [JsonProperty(PropertyName = "birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value><c>true</c> if [birthday year only]; otherwise, <c>false</c>.</value>
        [JsonProperty(PropertyName = "birthday_year_only")]
        public bool? BirthdayYearOnly { get; set; }

        [JsonProperty(PropertyName = "is_selected")]
        public bool IsSelected { get; set; }
    }
}