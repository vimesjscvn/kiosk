// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="AddQueueNumberTempRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class AddQueueNumberTempRequest.
    /// </summary>
    public class AddQueueNumberTempRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonRequired]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>The table code.</value>
        [JsonRequired]
        public string TableCode { get; set; }

        /// <summary>
        ///     Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        public DateTime? RequestedDate { get; set; }
    }
}