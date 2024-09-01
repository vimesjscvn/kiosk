// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TransactionInfoService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Common.Common;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// Class TransactionInfoService.
    /// Implements the <see cref="CS.Abstractions.IServices.ITransactionInfoService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.ITransactionInfoService" />
    public class TransactionInfoService : ITransactionInfoService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfoService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public TransactionInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TransactionInfo.</returns>
        public TransactionInfo Add(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TransactionInfo.</returns>
        public async Task<TransactionInfo> AddAsync(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<TransactionInfo>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>TransactionInfo.</returns>
        public TransactionInfo Find(Expression<Func<TransactionInfo, bool>> match)
        {
            return _unitOfWork.GetRepository<TransactionInfo>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;TransactionInfo&gt;.</returns>
        public ICollection<TransactionInfo> FindAll(Expression<Func<TransactionInfo, bool>> match)
        {
            return _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;TransactionInfo&gt;.</returns>
        public async Task<ICollection<TransactionInfo>> FindAllAsync(Expression<Func<TransactionInfo, bool>> match)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>TransactionInfo.</returns>
        public async Task<TransactionInfo> FindAsync(Expression<Func<TransactionInfo, bool>> match)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TransactionInfo.</returns>
        public TransactionInfo Get(Guid id)
        {
            return _unitOfWork.GetRepository<TransactionInfo>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;TransactionInfo&gt;.</returns>
        public ICollection<TransactionInfo> GetAll()
        {
            return _unitOfWork.GetRepository<TransactionInfo>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;TransactionInfo&gt;.</returns>
        public async Task<ICollection<TransactionInfo>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TransactionInfo.</returns>
        public async Task<TransactionInfo> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TransactionInfo.</returns>
        public TransactionInfo Update(TransactionInfo entity, Guid id)
        {
            if (entity == null)
                return null;

            TransactionInfo existing = _unitOfWork.GetRepository<TransactionInfo>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TransactionInfo>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TransactionInfo.</returns>
        public async Task<TransactionInfo> UpdateAsync(TransactionInfo entity, Guid id)
        {
            if (entity == null)
                return null;

            TransactionInfo existing = await _unitOfWork.GetRepository<TransactionInfo>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TransactionInfo>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion

        /// <summary>
        /// Gets the sum paid by employee identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<decimal> GetSumPaidByEmployeeId(Guid id)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t =>
                t.EmployeeId == id && t.Type == TransactionType.Paid &&
                t.Status == TransactionStatus.Success).SumAsync(t => t.Amount);
        }
    }
}
