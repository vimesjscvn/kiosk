// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ChargeClinicListRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class ChargeClinicListRequest.
    /// </summary>
    public class ChargeClinicListRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        [JsonProperty("SoTiepNhan")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("MaGiaoDich")]
        public string TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonRequired]
        [JsonProperty("NgayChiDinh")]
        public string RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [JsonRequired]
        [JsonProperty("BenhNhanThanhToan")]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        [JsonRequired]
        [JsonProperty("TrangThaiThanhToan")]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("Data")]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the data thuoc.
        /// </summary>
        /// <value>The data thuoc.</value>
        [JsonProperty("DataThuoc")]
        public string DataThuoc { get; set; }
    }
}
