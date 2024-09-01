// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SysUserViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class SysUserViewModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class SysUserViewModel : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [JsonProperty("password")]
        public string Password { get; set; } = "1";

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        ///     Gets or sets the token exp.
        /// </summary>
        /// <value>The token exp.</value>
        [JsonProperty("token_exp")]
        public DateTime? TokenExp { get; set; }

        /// <summary>
        ///     Gets or sets the last login.
        /// </summary>
        /// <value>The last login.</value>
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonProperty("user_name")]
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        [JsonProperty("data_type")]
        public string DataType { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [JsonProperty("sex")]
        public int? Sex { get; set; }

        /// <summary>
        ///     Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [JsonProperty("birthdate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty("title")]
        public Guid? Title { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [JsonProperty("position")]
        public Guid? Position { get; set; }

        /// <summary>
        ///     Gets or sets the title description.
        /// </summary>
        /// <value>The title description.</value>
        [JsonProperty("title_description")]
        public string TitleDescription { get; set; }

        /// <summary>
        ///     Gets or sets the position description.
        /// </summary>
        /// <value>The position description.</value>
        [JsonProperty("position_description")]
        public string PositionDescription { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; } = true;

        [JsonProperty(PropertyName = "code")] public string Code { get; set; }

        [JsonProperty(PropertyName = "role")] public RoleViewModel Role { get; set; }

        [JsonProperty(PropertyName = "permissions")]
        public List<PermissionViewModel> Permissions { get; set; }
    }
}