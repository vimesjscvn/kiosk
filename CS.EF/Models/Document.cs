// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Document.cs" company="CS.EF">
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
    ///     Class Document.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("document", Schema = "IHM")]
    public class Document : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        [Column("file_name")]
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [Column("path")]
        public string Path { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        [Column("content_type")]
        public string ContentType { get; set; }

        /// <summary>
        ///     Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [Column("size")]
        public long Size { get; set; }

        /// <summary>
        ///     Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets the survey result identifier.
        /// </summary>
        /// <value>The survey result identifier.</value>
        [Column("survey_result_id")]
        public Guid? SurveyResultId { get; set; }

        /// <summary>
        ///     Gets or sets the survey result.
        /// </summary>
        /// <value>The survey result.</value>
        public virtual SurveyResult SurveyResult { get; set; }
    }
}