using System;
using System.Collections.Generic;
using CS.Base.ViewModels;
using CS.Common.Common;

namespace CS.VM.Responses
{
    /// <summary>
    ///     OrderNumber View Model
    /// </summary>
    public class UltrasoundResponse : BaseViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderNumberViewModel" /> class.
        /// </summary>
        public UltrasoundResponse()
        {
            Patient = new UltrasoundPatientJson();
            Receptions = new List<UltrasoundReceptionsJson>();
        }

        /// <summary>
        ///     Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public UltrasoundPatientJson Patient { get; set; }

        public List<UltrasoundReceptionsJson> Receptions { get; set; }
    }

    public class UltrasoundReceptionsJson
    {
        /// <summary>
        ///     Gets or sets the examination name.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string ExaminationName { get; set; }

        public Guid ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets the examination code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string ExaminationCode { get; set; }

        /// <summary>
        ///     Gets or sets the department type.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string ExaminationType { get; set; }

        /// <summary>
        ///     Gets or sets registered date.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public UltrasoundDepartmentJson Departments { get; set; }
    }


    public class UltrasoundServiceJson
    {
        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string ServiceName { get; set; }

        public string IsFinished { get; set; }
        public string IdSpecified { get; set; }
        public string DepartmentCode { get; set; }
    }

    /// <summary>
    /// </summary>
    public class UltrasoundDepartmentJson
    {
        /// <summary>
        ///     Gets or sets the register code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public List<UltrasoundNumberData> Data { get; set; }
    }

    public class UltrasoundNumberData
    {
        public UltrasoundNumberData()
        {
            Services = new List<UltrasoundServiceJson>();
        }

        /// <summary>
        ///     Gets or sets the register code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public string DepartmentCode { get; set; }

        public Guid DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the register name.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public int Number { get; set; }

        public string Time { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public List<UltrasoundServiceJson> Services { get; set; }
    }

    /// <summary>
    ///     Patient View Model
    /// </summary>
    public class UltrasoundPatientJson : BaseViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PatientViewModel" /> class.
        /// </summary>
        public UltrasoundPatientJson()
        {
        }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public string FullName => string.Format("{0} {1}", LastName, FirstName);

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the village.
        /// </summary>
        /// <value>The village.</value>
        public string Village { get; set; }

        /// <summary>
        ///     Gets or sets the identity card number.
        /// </summary>
        /// <value>The identity card number.</value>
        public string IdentityCardNumber { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        public PatientType PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the name of the province.
        /// </summary>
        /// <value>
        ///     The name of the province.
        /// </value>
        public string ProvinceName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the district.
        /// </summary>
        /// <value>
        ///     The name of the district.
        /// </value>
        public string DistrictName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the ward.
        /// </summary>
        /// <value>
        ///     The name of the ward.
        /// </value>
        public string WardName { get; set; }

        /// <summary>
        ///     Gets or sets the balance.
        /// </summary>
        /// <value>
        ///     The balance.
        /// </value>
        public decimal? Balance { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>
        ///     The tekmedi card number.
        /// </value>
        public string TekmediCardNumber { get; set; }
    }
}