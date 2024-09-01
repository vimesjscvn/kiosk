// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class BaseResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
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
        ///     Gets or sets a value indicating whether this <see cref="BaseResponse{T}" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool success { get; set; }
    }

    /// <summary>
    ///     Class ResponseBody.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseBody<T>
    {
        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T data { get; set; }

        /// <summary>
        ///     Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public string errors { get; set; }

        /// <summary>
        ///     Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int errorCode { get; set; }
    }
}