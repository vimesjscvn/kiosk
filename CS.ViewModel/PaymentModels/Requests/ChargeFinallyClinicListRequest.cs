// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ChargeFinallyClinicListRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class ChargeFinallyClinicListRequest.
    /// </summary>
    public class ChargeFinallyClinicListRequest
    {
        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        [JsonProperty("SoTiepNhan")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("MaGiaoDich")]
        public string TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>The transaction date.</value>
        [JsonRequired]
        [JsonProperty("NgayGiaoDich")]
        public string TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        [JsonRequired]
        [JsonProperty("ma.nhanvien")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        /// <value>The store code.</value>
        [JsonRequired]
        [JsonProperty("vitri.quay")]
        public string StoreCode { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonRequired]
        [JsonProperty("DATAXML")]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the medicine data.
        /// </summary>
        /// <value>The medicine data.</value>
        [JsonRequired]
        [JsonProperty("DATATHUOCXML")]
        public string MedicineData { get; set; }

        /// <summary>
        /// Gets or sets the amount total.
        /// </summary>
        /// <value>The amount total.</value>
        [JsonRequired]
        [JsonProperty("TongSoTien")]
        public string AmountTotal { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        [JsonRequired]
        [JsonProperty("TrangThaiThanhToan")]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the clinic medicine data.
        /// </summary>
        /// <value>The clinic medicine data.</value>
        [JsonRequired]
        [JsonProperty("DATATHUOC")]
        public string ClinicMedicineData { get; set; }
    }
}
