// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IReExaminationService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Common;
using CS.EF.Models;
using Newtonsoft.Json;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IReExaminationService
    ///     Implements the <see cref="CS.Base.IService{ReExamination, Base.IRepository{ReExamination}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{ReExamination, Base.IRepository{ReExamination}}" />
    public interface IReExaminationService
    {
        /// <summary>
        ///     Gets the calendar by date.
        /// </summary>
        /// <param name="request">The get calendar by date request.</param>
        /// <returns></returns>
        Task<ICollection<ExaminationCalendar>> GetListByCodeAndDate(GetReExaminationListByCodeAndDateModel request,
            bool isAuto = false);

        Task<ICollection<QueueNumber>> Create(Patient patient, List<ReExamRegistrationListModel> list,
            bool isThrowError = false);

        Task<ICollection<QueueNumber>> CreateAndGenerateNumber(Patient patient, List<ReExamRegistrationListModel> list);

        Task<ICollection<ExaminationCalendar>> GetManualListByCodeAndDate(
            GetReExaminationListByCodeAndDateModel request, bool isAuto = false);
    }

    public class ReExamRegistrationListModel
    {
        public string PatientCode { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string DoctorCode { get; set; }

        public string DepartmentCode { get; set; }

        public string BookingId { get; set; }

        public string RegisteredCode { get; set; }

        public PatientType PatientType { get; set; } = PatientType.Normal;

        public string GroupDeptCode { get; set; }
        public string DepartmentName { get; set; }
        public string GroupDeptName { get; set; }
        public string Ip { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarByPatientCodeRequest.
    /// </summary>
    public class GetReExaminationListByCodeAndDateModel
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        public DateTime EndDate { get; set; }
    }
}