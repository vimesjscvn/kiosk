// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ChargesRegisterMedicalExamination.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CS.VM.External.Requests
{
    /// <summary>
    ///     Class ChargesRegisterMedicalExamination.
    /// </summary>
    public class ChargesRegisterMedicalExamination
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        [JsonRequired]
        [JsonProperty("YeuCau_IDX")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        [JsonProperty("SoTiepNhan")]
        public string RegisteredCode { get; set; }

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
        ///     Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        [JsonRequired]
        [JsonProperty("BenhNhanThanhToan")]
        public string Money { get; set; }

        /// <summary>
        ///     Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        [JsonRequired]
        [JsonProperty("TrangThaiThanhToan")]
        public string PaymentStatus { get; set; }

        /// <summary>
        ///     Gets or sets the transaction code.
        /// </summary>
        /// <value>The transaction code.</value>
        [JsonRequired]
        [JsonProperty("MaGiaoDich")]
        public string TransactionCode { get; set; }

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
    ///     Class ExternalHoldRegisterClinicWrapper.
    ///     Implements the <see cref="BaseExternalRequest" />
    /// </summary>
    /// <seealso cref="BaseExternalRequest" />
    public class ExternalHoldRegisterClinicWrapper : BaseExternalRequest
    {
    }
}