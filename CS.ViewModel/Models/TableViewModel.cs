// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TableViewModel.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.Base.ViewModels;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Models
{
    /// <summary>
    ///     Class TableViewModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class TableViewModel : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the device code.
        /// </summary>
        /// <value>The device code.</value>
        [JsonProperty("device")]
        public string DeviceCode { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public PriorityType Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        [JsonProperty("device_type")]
        public int DeviceType { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [JsonProperty("pc_ip")]
        public string ComputerIP { get; set; }

        /// <summary>
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>
        ///     The area code.
        /// </value>
        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets the store.
        /// </summary>
        /// <value>
        ///     The store.
        /// </value>
        [JsonProperty("store")]
        public int Store { get; set; }
    }

    /// <summary>
    ///     Class TablePostModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class TablePostModel
    {
        /// <summary>
        ///     Gets or sets the device code.
        /// </summary>
        /// <value>The device code.</value>
        public string DeviceCode { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PriorityType Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        public int DeviceType { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        public string ComputerIP { get; set; }

        /// <summary>
        ///     Gets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets the area code.
        /// </summary>
        /// <value>The department code.</value>
        public string AreaCode { get; set; }
    }

    /// <summary>
    ///     Class TablePostModel.
    ///     Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class TablePutModel : BaseViewModel
    {
        /// <summary>
        ///     Gets or sets the device code.
        /// </summary>
        /// <value>The device code.</value>
        [JsonProperty("device")]
        public string DeviceCode { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public PriorityType Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        public int DeviceType { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [JsonProperty("pc_ip")]
        public string ComputerIP { get; set; }

        /// <summary>
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>The area code.</value>
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        public string DepartmentCode { get; set; }
    }
}