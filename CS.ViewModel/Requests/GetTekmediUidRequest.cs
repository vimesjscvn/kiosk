// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetTekmediUidRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CS.VM.Requests
{
    /// <summary>
    /// Class GetTekmediUidRequest.
    /// </summary>
    public class GetTekmediUidRequest
    {
        /// <summary>
        /// Gets or sets the request data.
        /// </summary>
        /// <value>The request data.</value>
        public GetTekmediUidBody RequestData { get; set; }
    }

    /// <summary>
    /// Class GetTekmediUidBody.
    /// </summary>
    public class GetTekmediUidBody
    {
        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        public string UserType { get; set; }
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        public string Organization { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }
    }
}
