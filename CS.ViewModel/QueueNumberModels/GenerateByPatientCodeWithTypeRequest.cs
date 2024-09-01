// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GenerateByPatientCodeWithTypeRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.QueueNumberModels
{
    /// <summary>
    ///     Class GenerateByPatientCodeWithTypeRequest.
    /// </summary>
    public class GenerateByPatientCodeWithTypeRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the requested date.
        /// </summary>
        /// <value>The requested date.</value>
        public DateTime? RequestedDate { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonRequired]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [JsonRequired]
        public Gender Gender { get; set; }

        /// <summary>
        ///     Gets or sets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the province identifier.
        /// </summary>
        /// <value>The province identifier.</value>
        [JsonRequired]
        public string ProvinceId { get; set; }

        /// <summary>
        ///     Gets or sets the district identifier.
        /// </summary>
        /// <value>The district identifier.</value>
        [JsonRequired]
        public string DistrictId { get; set; }

        /// <summary>
        ///     Gets or sets the ward identifier.
        /// </summary>
        /// <value>The ward identifier.</value>
        [JsonRequired]
        public string WardId { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        public string Street { get; set; }
    }
}