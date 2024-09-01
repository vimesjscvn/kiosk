// ***********************************************************************
// Assembly         : Core.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="Core.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.EntityFrameworkCore;
using System;

namespace Core.Config.Models
{
    public abstract class BaseApplicationDbContext : DbContext
    {
        public BaseApplicationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Common configurations for all derived contexts
            // e.g., Apply common entity configurations
        }

        // Common DbSets that will be shared across derived contexts
        public DbSet<CS.EF.Models.Config> Configs { get; set; }

        // Other common DbSets can be defined here
    }
}