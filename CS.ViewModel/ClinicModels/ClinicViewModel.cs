// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ClinicViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Base.ViewModels;
using CS.Common.Common;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.ClinicModels
{
    /// <summary>
    ///     Class ClinicViewModel.
    ///     Implements the <see cref="BaseViewModelExtended" />
    /// </summary>
    /// <seealso cref="BaseViewModelExtended" />
    public class ClinicViewModel : BaseViewModelExtended
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public ClinicStatus? Status { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>The doctor code.</value>
        [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets the type of the clinic.
        /// </summary>
        /// <value>The type of the clinic.</value>
        [JsonProperty("clinic_type")]
        public string ClinicType { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        [JsonProperty("service_name")]
        public string ServiceName { get; set; }

        /// <summary>
        ///     Gets or sets the is finished.
        /// </summary>
        /// <value>The is finished.</value>
        [JsonProperty("is_finished")]
        public string IsFinished { get; set; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public ClinicType? Type { get; set; }

        /// <summary>
        ///     Gets the ip.
        /// </summary>
        /// <value>The ip.</value>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the service extend identifier.
        /// </summary>
        /// <value>The service extend identifier.</value>
        [JsonProperty("service_extend_id")]
        public Guid? ServiceExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the department extend identifier.
        /// </summary>
        /// <value>The department extend identifier.</value>
        [JsonProperty("department_extend_id")]
        public Guid? DepartmentExtendId { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        ///     Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        [JsonProperty("examination_code")]
        public string ExaminationCode { get; set; }

        /// <summary>
        ///     Gets or sets the examination identifier.
        /// </summary>
        /// <value>The examination identifier.</value>
        [JsonProperty("examination_id")]
        public Guid? ExaminationId { get; set; }

        /// <summary>
        ///     Gets or sets the examination extend identifier.
        /// </summary>
        /// <value>The examination extend identifier.</value>
        [JsonProperty("examination_extend_id")]
        public Guid? ExaminationExtendId { get; set; }

        /// <summary>
        ///     Gets the name of the examination extend.
        /// </summary>
        /// <value>The name of the examination extend.</value>
        [JsonProperty("examination_extend_name")]
        public string ExaminationExtendName { get; set; }

        /// <summary>
        ///     Gets or sets the queue number.
        /// </summary>
        /// <value>The queue number.</value>
        [JsonProperty("queue_number")]
        public QueueNumberViewModelDefault QueueNumber { get; set; }
    }
}