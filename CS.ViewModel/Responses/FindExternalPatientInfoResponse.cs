// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="FindExternalPatientInfoResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class FindExternalPatientInfoResponse.
    /// </summary>
    public class FindExternalPatientInfoResponse
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
        public FindExternalPatientInfoData Data { get; set; }
    }

    /// <summary>
    ///     Class FindExternalPatientInfoData.
    /// </summary>
    public class FindExternalPatientInfoData
    {
        /// <summary>
        ///     Gets or sets the mabenhnhan.
        /// </summary>
        /// <value>The mabenhnhan.</value>
        public int Mabenhnhan { get; set; }

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
    }
}