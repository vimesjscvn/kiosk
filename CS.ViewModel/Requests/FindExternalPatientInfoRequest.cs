// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="FindExternalPatientInfoRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class FindExternalPatientInfoRequest.
    /// </summary>
    public class FindExternalPatientInfoRequest
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
    }
}