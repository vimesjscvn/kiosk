// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseExternalRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CS.VM.External.Requests
{
    /// <summary>
    ///     Class BaseExternalRequest.
    /// </summary>
    public class BaseExternalRequest
    {
        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [JsonProperty("UserName")]
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [JsonProperty("PassWord")]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the data sign.
        /// </summary>
        /// <value>The data sign.</value>
        [JsonProperty("DataSign")]
        public string DataSign { get; set; }
    }
}