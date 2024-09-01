// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueExtendPutModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace DepartmentGroup.Domain.Models.Requests.PutModels
{
    /// <summary>
    ///     Class ListValueExtendPutModel.
    ///     Implements the <see cref="ListValuePutModel" />
    /// </summary>
    /// <seealso cref="ListValuePutModel" />
    public class DepartmentPutModel
    {
        /// <summary>
        ///     Gets or sets the display order.
        /// </summary>
        /// <value>The display order.</value>
        public int? DisplayOrder { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonRequired]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonRequired]
        [JsonProperty("name")]
        public string DepartmentName { get; set; }

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

        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        public Guid? ListValueId { get; set; }

        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [JsonProperty("address")]
        public string DepartmentAddress { get; set; }

        /// <summary>
        ///     Gets or sets the AreaCode.
        /// </summary>
        /// <value>The list value identifier.</value>
        public string AreaCode { get; set; }

        #region Request DepartmentConfig

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        public TimeSpan? StartTimeActiveAM { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public TimeSpan? EndTimeActiveAM { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [JsonRequired]
        public int TimeOnMinute { get; set; }

        /// <summary>
        ///     Gets or sets the time start.
        /// </summary>
        /// <value>The time start.</value>
        public TimeSpan? StartTimeActivePM { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public TimeSpan? EndTimeActivePM { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>

        public int AgeTo { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public int AgeFrom { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        [JsonRequired]
        public int TotalNumber { get; set; }

        /// <summary>
        ///     Gets or sets time end.
        /// </summary>
        /// <value>The time end.</value>
        public TypeGender TypeGender { get; set; }

        #endregion
    }
}