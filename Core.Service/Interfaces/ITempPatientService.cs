// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ITempPatientService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface ITempPatientService
    ///     Implements the <see cref="CS.Base.IService{TempPatient, Base.IRepository{TempPatient}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{TempPatient, Base.IRepository{TempPatient}}" />
    public interface ITempPatientService : IService<TempPatient, IRepository<TempPatient>>
    {
        /// <summary>
        ///     Gets the by card number asynchronous.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Task&lt;TempPatient&gt;.</returns>
        Task<TempPatient> GetByCardNumberAsync(string number);

        /// <summary>
        ///     Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;TempPatient&gt;.</returns>
        Task<TempPatient> GetByCode(string code);

        /// <summary>
        ///     Gets the by card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>Task&lt;TempPatient&gt;.</returns>
        Task<TempPatient> GetByCardNumber(string cardNumber);
    }
}