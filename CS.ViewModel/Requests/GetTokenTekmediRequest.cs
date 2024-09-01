// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetTokenTekmediRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CS.VM.Requests
{
    /// <summary>
    /// Class GetTokenTekmediRequest.
    /// </summary>
    public class GetTokenTekmediRequest
    {
        /// <summary>
        /// Gets or sets the request data.
        /// </summary>
        /// <value>The request data.</value>
        public GetTokenBody RequestData { get; set; }
    }

    /// <summary>
    /// Class GetTokenBody.
    /// </summary>
    public class GetTokenBody
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        public double TimeStamp { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }
    }
}
