// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="User.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class User.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("user", Schema = "IHM")]
    public class User : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [Column("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [Column("sex")]
        public string Sex { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the birthdate.
        /// </summary>
        /// <value>The birthdate.</value>
        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        ///     Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        [Column("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [Column("position")]
        public string Position { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value><c>true</c> if this instance is actived; otherwise, <c>false</c>.</value>
        [Column("is_actived")]
        public bool IsActived { get; set; }
    }
}