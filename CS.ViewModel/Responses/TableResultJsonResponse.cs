// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TableResultJsonResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class TableResultJsonResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TableResultJsonResponse<T>
    {
        /// <summary>
        ///     Gets or sets the draw.
        /// </summary>
        /// <value>The draw.</value>
        public int Draw { get; set; }

        /// <summary>
        ///     Gets or sets the records total.
        /// </summary>
        /// <value>The records total.</value>
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        /// <summary>
        ///     Gets or sets the records filtered.
        /// </summary>
        /// <value>The records filtered.</value>
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<T> Data { get; set; }

        /// <summary>
        ///     Gets or sets the other.
        /// </summary>
        /// <value>The other.</value>
        public object Other { get; set; }
    }
}