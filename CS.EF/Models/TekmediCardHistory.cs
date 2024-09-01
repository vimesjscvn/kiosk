// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TekmediCardHistory.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    /// Class TekmediCardHistory.
    /// Implements the <see cref="BaseTekmediCardHistory" />
    /// </summary>
    /// <seealso cref="BaseTekmediCardHistory" />
    [Table("tekmedi_card_history", Schema = "IHM")]
    public class TekmediCardHistory : BaseTekmediCardHistory
    {
    }
}
