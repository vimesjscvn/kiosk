// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicRegistrationPutModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using CS.Common.Common;

namespace CS.VM.PutModels
{
    /// <summary>
    ///     Class ClinicRegistrationPutModel.
    /// </summary>
    public class ClinicRegistrationPutModel
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        //[JsonProperty("id_specified")]
        [Required]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Required]
        [StringLength(36)]
        //[JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        [StringLength(36)]
        //[JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [Required]
        [StringLength(36)]
        //[JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [Required]
        [StringLength(36)]
        //[JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [StringLength(36)]
        //[JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        //[JsonProperty("registered_date")]
        [Required]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [StringLength(36)]
        //[JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid money")]
        //[JsonProperty("money")]
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [StringLength(36)]
        //[JsonProperty("status")]
        public ClinicStatus Status { get; set; }

        /// <summary>
        ///     Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [StringLength(36)]
        //[JsonProperty("transaction_code")]
        public string TransactionCode { get; set; }

        /// <summary>
        ///     Gets or sets the transaction date.
        /// </summary>
        /// <value>The transaction date.</value>
        //[JsonProperty("transaction_date")]
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        ///     Gets the ip.
        /// </summary>
        /// <value>The ip.</value>
        public string Ip { get; set; }
    }
}