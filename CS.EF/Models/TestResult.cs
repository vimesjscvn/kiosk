// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionInfo.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class TransactionInfo.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("test_result", Schema = "IHM")]
    public class TestResult : BaseObjectExtended
    {
        [Column("ref_id")] public Guid RefId { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Column("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [Column("com_port")]
        public string COMPort { get; set; }

        [Column("instrument_id")] public int InstrumentId { get; set; }

        [Column("group_id")] public string GroupId { get; set; }

        [Column("data")] public string Data { get; set; }

        [Column("url")] public string Url { get; set; }
    }
}