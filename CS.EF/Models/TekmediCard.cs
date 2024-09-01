// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TekmediCard.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base;
using CS.Common.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CS.EF.Models
{
    /// <summary>
    /// Class TekmediCard.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("tekmedi_card", Schema = "IHM")]
    public class TekmediCard : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the tekmedi card number.
        /// </summary>
        /// <value>The tekmedi card number.</value>
        [Column("tekmedi_card_number")]
        public string TekmediCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Column("price")]
        public decimal Balance { get; set; } = decimal.Zero;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; } = Constants.DefaultIsActive;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = Constants.DefaultIsDeleted;

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        /// <value>The patient.</value>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// Gets or sets the tekmedi card history.
        /// </summary>
        /// <value>The tekmedi card history.</value>
        //public virtual TekmediCardHistory TekmediCardHistory { get; set; }
    }
}
