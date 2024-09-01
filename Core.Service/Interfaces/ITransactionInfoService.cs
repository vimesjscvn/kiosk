// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ITransactionInfoService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.EF.Models;
using System;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// Interface ITransactionInfoService
    /// Implements the <see cref="CS.Base.IService{TransactionInfo, CS.Base.IRepository{TransactionInfo}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{TransactionInfo, CS.Base.IRepository{TransactionInfo}}" />
    public interface ITransactionInfoService : IService<TransactionInfo, IRepository<TransactionInfo>>
    {
        /// <summary>
        /// Gets the sum paid by employee identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<decimal> GetSumPaidByEmployeeId(Guid id);
    }
}
