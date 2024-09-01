// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GenericRequestModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class GenericRequestModel.
    /// </summary>
    public class GenericRequestModel
    {
        /// <summary>
        ///     Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [Required]
        //[JsonProperty("url")]
        public string Url { get; set; }

        //[JsonProperty("Json_body")]
        /// <summary>
        ///     Gets or sets the json body.
        /// </summary>
        /// <value>The json body.</value>
        public string JsonBody { get; set; }
    }
}