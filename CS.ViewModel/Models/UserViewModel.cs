// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="UserViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class UserViewModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class UserViewModel : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the birthdate.
        /// </summary>
        /// <value>The birthdate.</value>
        [JsonProperty(PropertyName = "birthdate")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        ///     Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        [JsonProperty(PropertyName = "mobile")]
        public string Mobile { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}