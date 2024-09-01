// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ListValueExtendViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class ListValueExtendViewModel.
    ///     Implements the <see cref="ListValueViewModel" />
    /// </summary>
    /// <seealso cref="ListValueViewModel" />
    public class ListValueExtendViewModel : ListValueViewModel
    {
        /// <summary>
        ///     Gets or sets the list value identifier.
        /// </summary>
        /// <value>The list value identifier.</value>
        [JsonProperty("list_value_id")]
        public Guid ListValueId { get; set; }

        [JsonProperty("department_virtual_id")]
        public string DepartmentVirtualId { get; set; } = "";

        [JsonProperty("list_value_code")] public string ListValueCode { get; set; } = "";
    }

    public class DepartmentGroupAndVirtualDepartmentViewModel
    {
        [JsonProperty("id")] public Guid Id { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("department_virtual_id")]
        public Guid DepartmentVirtualId { get; set; }

        [JsonProperty("department_virtual_code")]
        public string DepartmentVirtualCode { get; set; }
    }

    public class DepartmentViewModel
    {
        [JsonProperty("department_code")] public string DepartmentCode { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("id")] public Guid Id { get; set; }

        [JsonProperty("department_type")] public string DepartmentType { get; set; }
    }

    public class ListValueExtendViewModelMaster
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ServiceViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("service_code")]
        public string ServiceCode { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("service_name")]
        public string ServiceName { get; set; }
    }
}