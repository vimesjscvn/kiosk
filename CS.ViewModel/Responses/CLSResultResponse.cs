// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CLSResultResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class CLSResultResponse.
    /// </summary>
    public class CLSResultResponse
    {
        /// <summary>
        ///     Gets or sets the list CLS result.
        /// </summary>
        /// <value>The list CLS result.</value>
        public List<string> ListCLSResult { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        public string RegisteredCode { get; set; }
    }
}