// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="MedicalRegisterPutModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.VM.PutModels
{
    /// <summary>
    ///     Class MedicalRegisterPutModel.
    /// </summary>
    public class MedicalRegisterPutModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>The hospital code.</value>
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registration date.
        /// </summary>
        /// <value>The registration date.</value>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        ///     Gets or sets the object.
        /// </summary>
        /// <value>The object.</value>
        public string Object { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public int Amount { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the tekmedi status.
        /// </summary>
        /// <value>The tekmedi status.</value>
        public string TekmediStatus { get; set; }

        /// <summary>
        ///     Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        public string TransactionCode { get; set; }

        /// <summary>
        ///     Gets or sets the transaction date.
        /// </summary>
        /// <value>The transaction date.</value>
        public DateTime TransactionDate { get; set; }
    }
}