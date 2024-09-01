// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SysUser.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class SysUser.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("sys_user", Schema = "IHM")]
    public class SysUser : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [Column("full_name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Column("password")]
        public string Password { get; set; } = "1";

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [Column("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [Column("token")]
        public string Token { get; set; }

        /// <summary>
        ///     Gets or sets the token exp.
        /// </summary>
        /// <value>The token exp.</value>
        [Column("token_exp")]
        public DateTime? TokenExp { get; set; }

        /// <summary>
        ///     Gets or sets the last login.
        /// </summary>
        /// <value>The last login.</value>
        [Column("last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Column("user_name")]
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [Column("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        [Column("data_type")]
        public string DataType { get; set; }

        /// <summary>
        ///     Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [Column("sex")]
        public int? Sex { get; set; }

        /// <summary>
        ///     Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [Column("birthdate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }

        [Column("title")] public Guid? TitleId { get; set; }

        [Column("position")] public Guid? PositionId { get; set; }

        [InverseProperty("SysUser")] public virtual RoleUser RoleUser { get; set; }

        public virtual ListValue Title { get; set; }

        public virtual ListValue Position { get; set; }

        [NotMapped] public Role Role => RoleUser?.Role;

        [NotMapped]
        public IList<Permission> Permissions
        {
            get
            {
                if (RoleUser == null) return null;

                return RoleUser?.Role.RolePermissions
                    .Select(rp => rp.Permission)
                    .Distinct()
                    .ToList();
            }
        }
    }
}