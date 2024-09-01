// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueueNumberViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using CS.Base.ViewModels;
using CS.Common.Common;
using CS.VM.ClinicModels;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Queue Number View Model
    /// </summary>
    public class QueueNumberViewModel : BaseViewModel, ICloneable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueueNumberViewModel" /> class.
        /// </summary>
        public QueueNumberViewModel()
        {
        }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public PatientType Type { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the clinic.
        /// </summary>
        /// <value>The clinic.</value>
        [JsonProperty("clinic")]
        public ClinicViewModel Clinic { get; set; }

        /// <summary>
        ///     Gets the department.
        /// </summary>
        /// <value>The department.</value>
        [JsonProperty("department")]
        public ListValueExtendViewModel Department { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        [JsonProperty("group_dept_name")] public string GroupDeptName { get; set; }

        [JsonProperty("department_address")] public string DepartmentAddress { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("services")] public List<ServiceQueueNumberJson> Services { get; set; }

        /// <summary>
        ///     Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        ///     A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    /// <summary>
    ///     Queue Number View Model
    /// </summary>
    public class QueueNumberViewModelDefault : BaseViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueueNumberBaseViewModel" /> class.
        /// </summary>
        public QueueNumberViewModelDefault()
        {
        }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public PatientType Type { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        public string DepartmentName { get; set; }
    }

    /// <summary>
    /// </summary>
    /// <seealso cref="CS.VM.Models.QueueNumberViewModelDefault" />
    public class PatientsInRoomViewModel : QueueNumberViewModelDefault
    {
        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>
        ///     The birthday.
        /// </value>
        [JsonProperty("birth_day")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        /// <value>
        ///     The created date.
        /// </value>
        [JsonProperty("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is called.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is called; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_called")]
        public bool IsCalled { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>
        ///     The area code.
        /// </value>
        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        /// <value>
        ///     The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is called.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is called; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected { get; set; }

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
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        public string WardId { get; set; }

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
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public Guid PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the birthday year only.
        /// </summary>
        /// <value>
        ///     The the birthday year only.
        /// </value>
        public bool BirthdayYearOnly { get; set; }

        public string RegisteredCode { get; set; }
    }

    /// <summary>
    /// </summary>
    public class PatientHaveRoomViewModel
    {
        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonProperty("code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    /// <summary>
    ///     Queue Number View Model
    /// </summary>
    public class OrderNumberViewModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueueNumberViewModel" /> class.
        /// </summary>
        public OrderNumberViewModel()
        {
        }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///     The type of the service.
        /// </value>
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>
        ///     The name of the department.
        /// </value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        ///     The type of the patient.
        /// </value>
        [JsonProperty("patient_type")]
        public PatientType PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the room code.
        /// </summary>
        /// <value>
        ///     The room code.
        /// </value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; }

        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>
        ///     The identifier specified.
        /// </value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }
    }

    public class ServiceQueueNumberJson
    {
        public string ServiceName { get; set; }

        public string ServiceId { get; set; }

        public string GroupServiceId { get; set; }

        public string GroupServiceName { get; set; }
    }


    public class ResultQueueNumberViewModel : QueueNumberViewModel
    {
        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty("examination_id")]
        public string ExaminationId { get; set; }
    }

    public class PatientsInRoomEndoscopicViewModel : PatientsInRoomViewModel
    {
        public string GroupCode { get; set; }
        public string DepartmentVirtualCode { get; set; }
        public string DepartmentVirtualName { get; set; }
        public bool IsCallback { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int PatientType { get; set; }
        public Guid DepartmentExtendId { get; set; }
    }
}