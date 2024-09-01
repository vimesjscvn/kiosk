// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetClinicListRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TEK.Gateway.Domain.BusinessObjects;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class GetClinicListWithClinicData.
    /// </summary>
    public class GetFinallyClinicListWithClinicData
    {
        public List<GetRawFinallyClinicListResponseData> Clinics { get; set; }
    }

    /// <summary>
    /// Class GetClinicListWithPrescriptionData.
    /// </summary>
    public class GetFinallyClinicListWithPrescriptionData
    {
        /// <summary>
        /// Gets or sets the medicines.
        /// </summary>
        /// <value>
        /// The medicines.
        /// </value>
        public List<GetRawFinallyListPrescriptionResponseData> Medicines { get; set; }
    }
}
