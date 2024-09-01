// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ErrorWrappingMiddleware.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CS.Middleware
{
    /// <summary>
    ///     Class ErrorWrappingMiddleware.
    /// </summary>
    public class ErrorWrappingMiddleware
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly ILogger<ErrorWrappingMiddleware> _logger;

        /// <summary>
        ///     The next
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ErrorWrappingMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">logger</exception>
        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        ///     Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task Invoke(HttpContext context)
        {
            var success = true;
            var message = string.Empty;
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(10000, ex, ex.Message);
                message = ex.Message;
                context.Response.StatusCode = 400;
                success = false;
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var response = new ApiResponse(success, context.Response.StatusCode, message);

                var json = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}