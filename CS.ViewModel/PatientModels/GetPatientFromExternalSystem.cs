// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetPatientFromExternalSystem.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.VM.External.Responses;
using Newtonsoft.Json;

namespace CS.VM.PatientModels
{
    /// <summary>
    ///     Class GetPatientFromExternalSystemRequest.
    /// </summary>
    public class GetPatientFromExternalSystemRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }
    }

    /// <summary>
    ///     Class GetPatientFromExternalSystemResponse.
    ///     Implements the <see cref="BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="BaseExternalResponse" />
    public class GetPatientFromExternalSystemResponse : BaseExternalResponse
    {
        /// <summary>
        ///     Gets or sets the thong tin benh nhan.
        /// </summary>
        /// <value>The thong tin benh nhan.</value>
        public GetPatientFromExternalSystemResponseData ThongTinBenhNhan { get; set; }
    }

    /// <summary>
    ///     Class GetPatientFromExternalSystemResponseData.
    /// </summary>
    public class GetPatientFromExternalSystemResponseData
    {
        /// <summary>
        ///     Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        public int MaBenhNhan { get; set; }

        /// <summary>
        ///     Gets or sets the ho.
        /// </summary>
        /// <value>The ho.</value>
        public string Ho { get; set; }

        /// <summary>
        ///     Gets or sets the ten.
        /// </summary>
        /// <value>The ten.</value>
        public string Ten { get; set; }

        /// <summary>
        ///     Gets or sets the gioi tinh.
        /// </summary>
        /// <value>The gioi tinh.</value>
        public string GioiTinh { get; set; }

        /// <summary>
        ///     Gets or sets the ngay sinh.
        /// </summary>
        /// <value>The ngay sinh.</value>
        public string NgaySinh { get; set; }

        /// <summary>
        ///     Gets or sets the nam sinh.
        /// </summary>
        /// <value>The nam sinh.</value>
        public string NamSinh { get; set; }

        /// <summary>
        ///     Gets or sets the CMND.
        /// </summary>
        /// <value>The CMND.</value>
        public string CMND { get; set; }

        /// <summary>
        ///     Gets or sets the passport.
        /// </summary>
        /// <value>The passport.</value>
        public string Passport { get; set; }

        /// <summary>
        ///     Gets or sets the ngay cap CMND.
        /// </summary>
        /// <value>The ngay cap CMND.</value>
        public string NgayCapCMND { get; set; }

        /// <summary>
        ///     Gets or sets the noi cap CMND.
        /// </summary>
        /// <value>The noi cap CMND.</value>
        public string NoiCapCMND { get; set; }

        /// <summary>
        ///     Gets or sets the duong.
        /// </summary>
        /// <value>The duong.</value>
        public string Duong { get; set; }

        /// <summary>
        ///     Gets or sets the ma tinh thanh.
        /// </summary>
        /// <value>The ma tinh thanh.</value>
        public string MaTinhThanh { get; set; }

        /// <summary>
        ///     Gets or sets the ma quan huyen.
        /// </summary>
        /// <value>The ma quan huyen.</value>
        public string MaQuanHuyen { get; set; }

        /// <summary>
        ///     Gets or sets the ma phuong xa.
        /// </summary>
        /// <value>The ma phuong xa.</value>
        public string MaPhuongXa { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        public string DienThoai { get; set; }
    }
}