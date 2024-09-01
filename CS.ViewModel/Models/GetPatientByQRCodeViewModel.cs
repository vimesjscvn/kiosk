using System;

namespace CS.VM.Models
{
    public class GetPatientByQRCodeViewModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>
        ///     The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>
        ///     The tekmedi card number.
        /// </value>
        public string TekmediCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>
        ///     The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the unit number.
        /// </summary>
        /// <value>
        ///     The unit number.
        /// </value>
        public string UnitNumber { get; set; }

        /// <summary>
        ///     Gets or sets the village.
        /// </summary>
        /// <value>
        ///     The village.
        /// </value>
        public string Village { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>
        ///     The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        ///     Gets or sets the ic number.
        /// </summary>
        /// <value>
        ///     The ic number.
        /// </value>
        public string IcNumber { get; set; }

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
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [birthday year only].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [birthday year only]; otherwise, <c>false</c>.
        /// </value>
        public bool BirthdayYearOnly { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the ward.
        /// </summary>
        /// <value>
        ///     The ward.
        /// </value>
        public string Ward { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>
        ///     The ward identifier.
        /// </value>
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the district.
        /// </summary>
        /// <value>
        ///     The district.
        /// </value>
        public string District { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>
        ///     The district identifier.
        /// </value>
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the province.
        /// </summary>
        /// <value>
        ///     The province.
        /// </value>
        public string Province { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>
        ///     The province identifier.
        /// </value>
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the gender text.
        /// </summary>
        /// <value>
        ///     The gender text.
        /// </value>
        public string GenderText { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>
        ///     The health insurance expired date.
        /// </value>
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>
        ///     The health insurance issued date.
        /// </value>
        public DateTime? HealthInsuranceIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>
        ///     The health insurance first place code.
        /// </value>
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>
        ///     The health insurance first place.
        /// </value>
        public string HealthInsuranceFirstPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>
        ///     The health insurance number.
        /// </value>
        public string HealthInsuranceNumber { get; set; }
    }
}