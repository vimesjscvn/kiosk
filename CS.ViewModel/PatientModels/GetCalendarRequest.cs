// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetCalendarRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using CS.VM.External.Responses;
using Newtonsoft.Json;

namespace CS.VM.PatientModels
{
    /// <summary>
    ///     Class GetCalendarRequest.
    /// </summary>
    public class GetCalendarRequest
    {
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
    }

    /// <summary>
    ///     Class GetCalendarResponse.
    ///     Implements the <see cref="BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="BaseExternalResponse" />
    public class GetCalendarResponse : BaseExternalResponse
    {
        /// <summary>
        ///     Gets or sets the danh sach lich tai kham.
        /// </summary>
        /// <value>The danh sach lich tai kham.</value>
        public List<GetCalendarResponseData> DanhSachLichTaiKham { get; set; }
    }

    /// <summary>
    ///     Class GetCalendarResponseData.
    /// </summary>
    public class GetCalendarResponseData
    {
        /// <summary>
        ///     Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        public int MaBenhNhan { get; set; }

        /// <summary>
        ///     Gets or sets the ngay tai kham.
        /// </summary>
        /// <value>The ngay tai kham.</value>
        public string NgayTaiKham { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string MaBacSi { get; set; }

        /// <summary>
        ///     Gets or sets the ma phong ban.
        /// </summary>
        /// <value>The ma phong ban.</value>
        public int MaPhongBan { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string DoiTuong { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string CoCanLamSan { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarRequest.
    /// </summary>
    public class GetAllCalendarRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        [JsonProperty("SoTiepNhan")]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarResponse.
    ///     Implements the <see cref="BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="BaseExternalResponse" />
    public class GetAllCalendarResponse : BaseExternalResponse
    {
        /// <summary>
        ///     Gets or sets the danh sach lich tai kham.
        /// </summary>
        /// <value>The danh sach lich tai kham.</value>
        public List<GetAllCalendarResponseData> DanhSachLichTaiKham { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarResponseData.
    /// </summary>
    public class GetAllCalendarResponseData
    {
        /// <summary>
        ///     Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        public int MaBenhNhan { get; set; }

        /// <summary>
        ///     Gets or sets the ngay tai kham.
        /// </summary>
        /// <value>The ngay tai kham.</value>
        public string NgayTaiKham { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string MaBacSi { get; set; }

        /// <summary>
        ///     Gets or sets the ma phong ban.
        /// </summary>
        /// <value>The ma phong ban.</value>
        public int MaPhongBan { get; set; }

        /// <summary>
        ///     Gets or sets the co can lam san.
        /// </summary>
        /// <value>The co can lam san.</value>
        public string CoCanLamSan { get; set; }

        /// <summary>
        ///     Gets or sets the doi tuong.
        /// </summary>
        /// <value>The doi tuong.</value>
        public string DoiTuong { get; set; }
    }
}