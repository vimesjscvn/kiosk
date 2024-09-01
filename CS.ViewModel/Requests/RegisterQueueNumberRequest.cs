using System;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class RegisterQueueNumberRequest : RegisterQueueNumberModel
    {
        [JsonRequired] public Guid RoomId { get; set; }

        [JsonRequired] public string RegisteredCode { get; set; }
    }

    public class RegisterEndoscopicQueueNumberRequest
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonRequired]
        public string GroupCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        [JsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        [JsonRequired]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        [JsonRequired]
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        [JsonRequired]
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the province code.
        /// </summary>
        /// <value>
        ///     The province code.
        /// </value>
        [JsonRequired]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district code.
        /// </summary>
        /// <value>
        ///     The district code.
        /// </value>
        [JsonRequired]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward code.
        /// </summary>
        /// <value>
        ///     The ward code.
        /// </value>
        [JsonRequired]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [JsonRequired]
        public DateTime RegisteredDate { get; set; }

        [JsonRequired] public string RegisteredCode { get; set; }
    }
}