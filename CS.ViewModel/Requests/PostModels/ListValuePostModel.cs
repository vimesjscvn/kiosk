// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValuePostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests.PostModels
{
    /// <summary>
    ///     Class ListValuePostModel.
    /// </summary>
    public class ListValuePostModel
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonRequired]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the list value type identifier.
        /// </summary>
        /// <value>The list value type identifier.</value>
        [JsonRequired]
        public Guid ListValueTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the display order.
        /// </summary>
        /// <value>The display order.</value>
        [JsonRequired]
        public int? DisplayOrder { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonRequired]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonRequired]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonRequired]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        [JsonRequired]
        public bool IsSystem { get; set; }

        /// <summary>
        ///     Gets or sets the type of the service.
        /// </summary>
        /// <value>
        ///     The type of the service.
        /// </value>
        public ServiceType ServiceType { get; set; } = ServiceType.Unknown;
    }
}