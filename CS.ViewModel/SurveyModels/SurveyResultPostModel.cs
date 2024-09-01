// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SurveyResultPostModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CS.VM.SurveyModels
{
    /// <summary>
    ///     Class SurveyResultPostModel.
    /// </summary>
    public class SurveyResultPostModel
    {
        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [Required]
        public string Result { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Required]
        public string User { get; set; }

        /// <summary>
        ///     Gets or sets the files.
        /// </summary>
        /// <value>The files.</value>
        public List<string> Files { get; set; }
    }
}