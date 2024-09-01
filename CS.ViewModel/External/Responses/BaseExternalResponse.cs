// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseExternalResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace CS.VM.External.Responses
{
    /// <summary>
    ///     Class BaseExternalResponse.
    /// </summary>
    public class BaseExternalResponse
    {
        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("Status")]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [JsonProperty("ErrorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}