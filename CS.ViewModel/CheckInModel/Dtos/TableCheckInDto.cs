using System;

namespace CS.VM.CheckInModel.Dtos
{
    public class TableCheckInDto
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName { get; set; }

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
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the block identifier.
        /// </summary>
        /// <value>
        ///     The block identifier.
        /// </value>
        public string BlockId { get; set; }

        /// <summary>
        ///     Gets or sets the card number.
        /// </summary>
        /// <value>
        ///     The card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>
        ///     The district identifier.
        /// </value>
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the gender text.
        /// </summary>
        /// <value>
        ///     The gender text.
        /// </value>
        public string GenderText { get; set; }

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
        ///     Gets or sets the tekmedi uid.
        /// </summary>
        /// <value>
        ///     The tekmedi uid.
        /// </value>
        public string TekmediUid { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance number.
        /// </summary>
        /// <value>
        ///     The health insurance number.
        /// </value>
        public string HealthInsuranceNumber { get; set; }

        /// <summary>
        ///     Gets or sets the ic number.
        /// </summary>
        /// <value>
        ///     The ic number.
        /// </value>
        public string ICNumber { get; set; }

        /// <summary>
        ///     Gets or sets the ic issued place.
        /// </summary>
        /// <value>
        ///     The ic issued place.
        /// </value>
        public string ICIssuedPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance expired date.
        /// </summary>
        /// <value>
        ///     The health insurance expired date.
        /// </value>
        public DateTime? HealthInsuranceExpiredDate { get; set; }

        /// <summary>
        ///     Gets or sets the ic issued date.
        /// </summary>
        /// <value>
        ///     The ic issued date.
        /// </value>
        public DateTime? ICIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the birthday text.
        /// </summary>
        /// <value>
        ///     The birthday text.
        /// </value>
        public string BirthdayText { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [birth year only].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [birth year only]; otherwise, <c>false</c>.
        /// </value>
        public bool BirthYearOnly { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

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
        ///     Gets or sets the health insurance issued date.
        /// </summary>
        /// <value>
        ///     The health insurance issued date.
        /// </value>
        public DateTime? HealthInsuranceIssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place.
        /// </summary>
        /// <value>
        ///     The health insurance first place.
        /// </value>
        public string HealthInsuranceFirstPlace { get; set; }

        /// <summary>
        ///     Gets or sets the health insurance first place code.
        /// </summary>
        /// <value>
        ///     The health insurance first place code.
        /// </value>
        public string HealthInsuranceFirstPlaceCode { get; set; }

        /// <summary>
        ///     Gets or sets the unit number.
        /// </summary>
        /// <value>
        ///     The unit number.
        /// </value>
        public string UnitNumber { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the village.
        /// </summary>
        /// <value>
        ///     The village.
        /// </value>
        public string Village { get; set; }

        /// <summary>
        ///     Gets or sets the type of the ic.
        /// </summary>
        /// <value>
        ///     The type of the ic.
        /// </value>
        public string ICType { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>
        ///     The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>
        ///     The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        ///     Gets the passport.
        /// </summary>
        /// <value>
        ///     The passport.
        /// </value>
        public string Passport => ICType == "P" ? ICNumber : "";

        /// <summary>
        ///     Gets the CMND.
        /// </summary>
        /// <value>
        ///     The CMND.
        /// </value>
        public string CMND => ICType == "I" ? ICNumber : "";

        /// <summary>
        ///     Gets the day month of birth.
        /// </summary>
        /// <value>
        ///     The day month of birth.
        /// </value>
        public string DayMonthOfBirth => BirthYearOnly ? "N/A" : Birthday.ToString("dd/MM");

        /// <summary>
        ///     Gets the year of birth.
        /// </summary>
        /// <value>
        ///     The year of birth.
        /// </value>
        public string YearOfBirth => Birthday.ToString("yyyy");

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public string PatientId { get; set; }
    }
}