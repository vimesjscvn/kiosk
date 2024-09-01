// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using CS.Common.Common;

namespace CS.VM.ClinicModels
{
    /// <summary>
    ///     Class ClinicPostModel.
    /// </summary>
    public class ClinicPostModel
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        //[JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        // [JsonProperty("patient_code")]
        public string TempPatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        //[Required]
        [StringLength(36)]
        // [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [Required]
        [StringLength(36)]
        // [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        // [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [StringLength(36)]
        // [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid money")]
        // [JsonProperty("money")]
        public decimal Money { get; set; }

        public decimal TotalFee { get; set; }
        public decimal InsuranceFee { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the clinic.
        /// </summary>
        /// <value>The type of the clinic.</value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the is finished.
        /// </summary>
        /// <value>The is finished.</value>
        public string IsFinished { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public ClinicStatus? Status { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public ClinicType? ClinicType { get; set; }

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        public string Note { get; set; }

        /// <summary>
        ///     Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        public string ExaminationCode { get; set; }

        /// <summary>
        ///     Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///     The type of the service.
        /// </value>
        public string ServiceType { get; set; }

        /// <summary>
        ///     Gets or sets the management identifier.
        /// </summary>
        /// <value>
        ///     The management identifier.
        /// </value>
        public string ManagementId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the object.
        /// </summary>
        /// <value>
        ///     The type of the object.
        /// </value>
        public string ObjectType { get; set; }
    }
}