// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CLSResponse.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.VM.Responses
{
    /// <summary>
    ///     Class CLSResponse.
    /// </summary>
    public class CLSResponse
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        public int IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the service code.
        /// </summary>
        /// <value>The service code.</value>
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the hold money.
        /// </summary>
        /// <value>The hold money.</value>
        public decimal HoldMoney { get; set; }
    }
}