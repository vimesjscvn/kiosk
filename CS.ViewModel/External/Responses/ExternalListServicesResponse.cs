// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ExternalListServicesResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using CS.VM.External.Requests;
using Newtonsoft.Json;

namespace CS.VM.External.Responses
{
    /// <summary>
    ///     Class ExternalListServicesResponse.
    ///     Implements the <see cref="BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="BaseExternalResponse" />
    public class ExternalListServicesResponse : BaseExternalResponse
    {
        /// <summary>
        ///     Gets or sets the clinic date.
        /// </summary>
        /// <value>The clinic date.</value>
        [JsonProperty("Data")]
        public List<ExternalListServicesResponseData> ClinicDate { get; set; }
    }

    /// <summary>
    ///     Class ExternalListServicesResponseData.
    /// </summary>
    public class ExternalListServicesResponseData
    {
        /// <summary>
        ///     Gets or sets the requirement identifier.
        /// </summary>
        /// <value>The requirement identifier.</value>
        [JsonRequired]
        [JsonProperty("YeuCau_IDX")]
        public string RequirementId { get; set; }

        /// <summary>
        ///     Gets or sets the clinic date.
        /// </summary>
        /// <value>The clinic date.</value>
        [JsonRequired]
        [JsonProperty("NgayChiDinh")]
        public string ClinicDate { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonRequired]
        [JsonProperty("NgayDangKy")]
        public string RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>The type of the patient.</value>
        [JsonProperty("DoiTuong")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonRequired]
        [JsonProperty("BenhNhanThanhToan")]
        public string Amount { get; set; }

        /// <summary>
        ///     Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        [JsonRequired]
        [JsonProperty("TrangThaiThanhToan")]
        public string PaymentStatus { get; set; }

        /// <summary>
        ///     Gets or sets the transactioncode.
        /// </summary>
        /// <value>The transactioncode.</value>
        [JsonRequired]
        [JsonProperty("MaGiaoDich")]
        public string Transactioncode { get; set; }

        /// <summary>
        ///     Gets or sets the transaction date.
        /// </summary>
        /// <value>The transaction date.</value>
        [JsonRequired]
        [JsonProperty("NgayGiaoDich")]
        public string TransactionDate { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonRequired]
        [JsonProperty("MaKhoaPhong")]
        public string DepartmentCode { get; set; }
    }

    /// <summary>
    ///     Class ExternalListServicesResponseWrapper.
    ///     Implements the <see cref="BaseExternalRequest" />
    /// </summary>
    /// <seealso cref="BaseExternalRequest" />
    public class ExternalListServicesResponseWrapper : BaseExternalRequest
    {
    }
}