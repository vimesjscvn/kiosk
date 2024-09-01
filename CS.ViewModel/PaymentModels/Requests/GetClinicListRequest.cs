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
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TEK.Gateway.Domain.BusinessObjects;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class GetClinicListWithClinicData.
    /// </summary>
    [Serializable]
    [XmlRoot("DOCUMENT")]
    public class GetClinicListWithClinicData
    {
        public List<GetRawClinicListResponseData> Clinics { get; set; }
    }

    /// <summary>
    /// Class GetClinicListWithPrescriptionData.
    /// </summary>
    [Serializable]
    [XmlRoot("DOCUMENT")]
    public class GetClinicListWithPrescriptionData
    {
        /// <summary>
        /// Gets or sets the medicines.
        /// </summary>
        /// <value>
        /// The medicines.
        /// </value>
        public List<GetRawListPrescriptionResponseData> Medicines { get; set; }
    }
}
