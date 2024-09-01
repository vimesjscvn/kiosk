// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="AuditLogViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class AuditLogViewModel.
    /// </summary>
    public class AuditLogViewModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the inserted date.
        /// </summary>
        /// <value>The inserted date.</value>
        [JsonProperty("inserted_date")]
        public DateTime InsertedDate { get; set; }

        /// <summary>
        ///     Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [JsonProperty("updated_date")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the trace identifier.
        /// </summary>
        /// <value>The trace identifier.</value>
        [JsonProperty("trace_id")]
        public string TraceId { get; set; }

        /// <summary>
        ///     Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        ///     Gets or sets the request URL.
        /// </summary>
        /// <value>The request URL.</value>
        [JsonProperty("request_url")]
        public string RequestUrl { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP method.
        /// </summary>
        /// <value>The HTTP method.</value>
        [JsonProperty("http_method")]
        public string HttpMethod { get; set; }

        /// <summary>
        ///     Gets or sets the name of the action.
        /// </summary>
        /// <value>The name of the action.</value>
        [JsonProperty("action_name")]
        public string ActionName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the controller.
        /// </summary>
        /// <value>The name of the controller.</value>
        [JsonProperty("controller_name")]
        public string ControllerName { get; set; }

        /// <summary>
        ///     Gets or sets the response status.
        /// </summary>
        /// <value>The response status.</value>
        [JsonProperty("response_status")]
        public string ResponseStatus { get; set; }

        /// <summary>
        ///     Gets or sets the response status code.
        /// </summary>
        /// <value>The response status code.</value>
        [JsonProperty("response_status_code")]
        public string ResponseStatusCode { get; set; }

        /// <summary>
        ///     Gets or sets the action parameters.
        /// </summary>
        /// <value>The action parameters.</value>
        [JsonProperty("action_parameters")]
        public string ActionParameters { get; set; }

        /// <summary>
        ///     Gets or sets the request body.
        /// </summary>
        /// <value>The request body.</value>
        [JsonProperty("request_body")]
        public string RequestBody { get; set; }

        /// <summary>
        ///     Gets or sets the response body.
        /// </summary>
        /// <value>The response body.</value>
        [JsonProperty("response_body")]
        public string ResponseBody { get; set; }

        /// <summary>
        ///     Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        [JsonProperty("exception")]
        public string Exception { get; set; }
    }
}