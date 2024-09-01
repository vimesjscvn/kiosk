// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="HistoryCardRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.Common.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CS.VM.Requests
{
    /// <summary>
    /// Class HistoryCardRequest.
    /// </summary>
    public class HistoryCardRequest : DataTableParameters
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string PatientCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        /// <value>The name of the patient.</value>
        public string PatientName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CS.VM.Requests.HistoryCardRequest" />
    public class HistoryCardWithTypeRequest : HistoryCardRequest
    {
        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        /// <value>
        /// The types.
        /// </value>
        [JsonRequired]
        public List<TypeEnum> Types { get; set; }
    }
}
