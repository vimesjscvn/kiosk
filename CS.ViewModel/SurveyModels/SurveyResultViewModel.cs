// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SurveyResultViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using CS.Base.ViewModels;
using CS.VM.DocumentModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CS.VM.SurveyModels
{
    /// <summary>
    ///     Class SurveyResultViewModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class SurveyResultViewModel : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [JsonProperty("result")]
        public JObject Result { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [JsonProperty("user")]
        public string User { get; set; }

        /// <summary>
        ///     Gets or sets the documents.
        /// </summary>
        /// <value>The documents.</value>
        [JsonProperty("documents")]
        public List<DocumentViewModel> Documents { get; set; }
    }
}