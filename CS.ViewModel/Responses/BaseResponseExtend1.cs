// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseResponseExtend1.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class BaseResponseExtend1.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseExtend1<T>
    {
        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public ResponseBody<T> result { get; set; }

        /// <summary>
        ///     Gets or sets the return code.
        /// </summary>
        /// <value>The return code.</value>
        public int returnCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BaseResponseExtend1{T}" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool success { get; set; }
    }
}