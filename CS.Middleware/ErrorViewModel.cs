﻿// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ErrorViewModel.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Exceptions;

namespace CS.Middleware
{
    /// <summary>
    ///     ErrorViewModel
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        ///     Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public ErrorCode Error { get; set; }

        /// <summary>
        ///     Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }
}