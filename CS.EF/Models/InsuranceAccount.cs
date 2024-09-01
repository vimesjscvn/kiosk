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
    [Table("insurance_account", Schema = "IHM")]
    public class InsuranceAccount : BaseObjectExtended
    {
        [Column("access_token")] public string access_token { get; set; }

        [Column("id_token")] public string id_token { get; set; }

        [Column("token_type")] public string token_type { get; set; }

        [Column("username")] public string username { get; set; }

        [Column("expires_in")] public DateTime expires_in { get; set; }
    }
}