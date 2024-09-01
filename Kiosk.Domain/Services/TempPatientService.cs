// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TempPatientService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// TempPatient Profile Service
    /// </summary>
    /// <seealso cref="ITempPatientService" />
    public class TempPatientService : ITempPatientService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TempPatientService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public TempPatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TempPatient> GetAll()
        {
            return _unitOfWork.GetRepository<TempPatient>().GetAll().ToList();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TempPatient>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TempPatient>().GetAll().ToListAsync();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public TempPatient Get(Guid id)
        {
            return _unitOfWork.GetRepository<TempPatient>().GetById(id);
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TempPatient> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<TempPatient>().GetAsyncById(id);
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public TempPatient Find(Expression<Func<TempPatient, bool>> match)
        {
            return _unitOfWork.GetRepository<TempPatient>().Find(match);
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TempPatient> FindAsync(Expression<Func<TempPatient, bool>> match)
        {
            return await _unitOfWork.GetRepository<TempPatient>().FindAsync(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TempPatient> FindAll(Expression<Func<TempPatient, bool>> match)
        {
            return _unitOfWork.GetRepository<TempPatient>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// Finds all asynchronous.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TempPatient>> FindAllAsync(Expression<Func<TempPatient, bool>> match)
        {
            return await _unitOfWork.GetRepository<TempPatient>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public TempPatient Add(TempPatient entity)
        {
            _unitOfWork.GetRepository<TempPatient>().Add(entity);
            _unitOfWork.GetRepository<TempPatient>().SaveChanges();
            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <returns>TempPatient.</returns>
        public TempPatient Update(TempPatient entity, Guid key)
        {
            if (entity == null)
                return null;

            TempPatient existing = _unitOfWork.GetRepository<TempPatient>().GetById(key);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TempPatient>().Update(entity);
                _unitOfWork.GetRepository<TempPatient>().SaveChanges();
            }

            return existing;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="key">The key.</param>
        /// <returns>TempPatient.</returns>
        public async Task<TempPatient> UpdateAsync(TempPatient entity, Guid key)
        {
            if (entity == null)
                return null;

            TempPatient existing = await _unitOfWork.GetRepository<TempPatient>().GetAsyncById(key);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TempPatient>().Update(entity);
                await _unitOfWork.GetRepository<TempPatient>().SaveChangesAsync();
            }

            return existing;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<TempPatient>().Delete(id);
            _unitOfWork.GetRepository<TempPatient>().SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TempPatient entity)
        {
            _unitOfWork.GetRepository<TempPatient>().Delete(entity);
            _unitOfWork.GetRepository<TempPatient>().SaveChanges();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(TempPatient entity)
        {
            _unitOfWork.GetRepository<TempPatient>().Delete(entity);
            return await _unitOfWork.GetRepository<TempPatient>().SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<TempPatient>().Delete(id);
            return await _unitOfWork.GetRepository<TempPatient>().SaveChangesAsync();
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<TempPatient>().Count();
        }

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<TempPatient>().CountAsync();
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;TempPatient&gt;.</returns>
        public async Task<TempPatient> GetByCode(string code)
        {
            return await _unitOfWork.GetRepository<TempPatient>().GetAll().FirstOrDefaultAsync(item => item.Code == code);
        }

        /// <summary>
        /// Gets the by card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>Task&lt;TempPatient&gt;.</returns>
        public async Task<TempPatient> GetByCardNumber(string cardNumber)
        {
            // Find tempPatient in Tekmedi System
            return await _unitOfWork.GetRepository<TempPatient>().GetAll().FirstOrDefaultAsync(item => item.Code == cardNumber);
        }

        /// <summary>
        /// get by card number as an asynchronous operation.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Task&lt;TempPatient&gt;.</returns>
        public async Task<TempPatient> GetByCardNumberAsync(string number)
        {
            return await _unitOfWork.GetRepository<TempPatient>().GetAll().FirstOrDefaultAsync(x =>x.TekmediCardNumber == number && x.IsActive == true);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TempPatient.</returns>
        public async Task<TempPatient> AddAsync(TempPatient entity)
        {
            _unitOfWork.GetRepository<TempPatient>().Add(entity);
            await _unitOfWork.GetRepository<TempPatient>().SaveChangesAsync();
            return entity;
        }
    }
}