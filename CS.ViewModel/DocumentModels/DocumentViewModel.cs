// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="DocumentViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.Base.ViewModels;
using Newtonsoft.Json;

namespace CS.VM.DocumentModels
{
    /// <summary>
    ///     Class DocumentViewModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class DocumentViewModel : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        [JsonProperty("file_name")]
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [JsonProperty("path")]
        public string Path { get; set; }

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
        ///     Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        ///     Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [JsonProperty("size")]
        public long Size { get; set; }

        /// <summary>
        ///     Gets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}