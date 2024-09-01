// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Province.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class Province.
    ///     Implements the <see cref="BaseLocationPart" />
    /// </summary>
    /// <seealso cref="BaseLocationPart" />
    [Table("province")]
    public class Province : BaseLocationPart
    {
    }
}