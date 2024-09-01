// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="FindByPatientCodeExternalResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class FindByPatientCodeExternalResponse.
    /// </summary>
    public class FindByPatientCodeExternalRequest
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
    ///     Class FindByPatientCodeExternalResponse.
    /// </summary>
    public class FindByPatientCodeExternalResponse
    {
        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets or sets the thong tin benh nhan.
        /// </summary>
        /// <value>The thong tin benh nhan.</value>
        public FindByPatientCodeExternalData ThongTinBenhNhan { get; set; }
    }

    /// <summary>
    ///     Class FindByPatientCodeExternalData.
    /// </summary>
    public class FindByPatientCodeExternalData
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