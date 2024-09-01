using System;

namespace CS.VM.Responses
{
    public class TempPatientResponse
    {
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        /// <value>
        ///     The created date.
        /// </value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>
        ///     The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>
        ///     The province identifier.
        /// </value>
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the province.
        /// </summary>
        /// <value>
        ///     The name of the province.
        /// </value>
        public string ProvinceName { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>
        ///     The district identifier.
        /// </value>
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the district.
        /// </summary>
        /// <value>
        ///     The name of the district.
        /// </value>
        public string DistrictName { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>
        ///     The ward identifier.
        /// </value>
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the ward.
        /// </summary>
        /// <value>
        ///     The name of the ward.
        /// </value>
        public string WardName { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        public DateTime? RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        public string HospitalCode { get; set; }
    }
}