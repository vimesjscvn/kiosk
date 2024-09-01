// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IDiagnosingImageService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Common;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IDiagnosingImageService
    ///     Implements the <see cref="CS.Base.IService{DiagnosingImage, Base.IRepository{DiagnosingImage}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{DiagnosingImage, Base.IRepository{DiagnosingImage}}" />
    public interface IDiagnosingImageService
    {
        Task<ICollection<QueueNumber>> CreateAndGenerateNumber(Patient patient, List<DiagnosingImageListModel> list);
    }

    public class DiagnosingImageListModel
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
        public int OrderId { get; set; }
        public int OrderLineId { get; set; }
        public string Ip { get; set; }
    }
}