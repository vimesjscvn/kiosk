// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="RegisterExternalPatientInfoResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class RegisterExternalPatientInfoResponse.
    /// </summary>
    public class RegisterExternalPatientInfoResponse
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
        ///     Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public RegisterExternalPatientInfoData Data { get; set; }
    }

    /// <summary>
    ///     Class RegisterExternalPatientInfoData.
    /// </summary>
    public class RegisterExternalPatientInfoData
    {
        /// <summary>
        ///     Gets or sets the ho ten.
        /// </summary>
        /// <value>The ho ten.</value>
        public string HoTen { get; set; }

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
        ///     Gets or sets the gioi tinh.
        /// </summary>
        /// <value>The gioi tinh.</value>
        public string GioiTinh { get; set; }

        /// <summary>
        ///     Gets or sets the dia chi.
        /// </summary>
        /// <value>The dia chi.</value>
        public string DiaChi { get; set; }

        /// <summary>
        ///     Gets or sets the dien thoai.
        /// </summary>
        /// <value>The dien thoai.</value>
        public string DienThoai { get; set; }

        /// <summary>
        ///     Gets or sets the CMND.
        /// </summary>
        /// <value>The CMND.</value>
        public string CMND { get; set; }

        /// <summary>
        ///     Gets or sets the pastport.
        /// </summary>
        /// <value>The pastport.</value>
        public string Pastport { get; set; }

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
    }
}