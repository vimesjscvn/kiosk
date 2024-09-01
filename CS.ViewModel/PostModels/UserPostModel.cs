// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="UserPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Newtonsoft.Json;

namespace CS.VM.PostModels
{
    /// <summary>
    ///     Class UserPostModel.
    /// </summary>
    public class UserPostModel
    {
        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the birthdate.
        /// </summary>
        /// <value>The birthdate.</value>
        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        ///     Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [JsonProperty("position")]
        public string Position { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}