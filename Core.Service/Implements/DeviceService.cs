// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="DeviceService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Common.Helpers;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Implements
{
    /// <summary>
    ///     Class DeviceService.
    ///     Implements the <see cref="CS.Abstractions.IServices.IDeviceService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IDeviceService" />
    public class DeviceService : IDeviceService
    {
        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeviceService" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Gets all device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<Device>> GetAllDevice(GetAllDeviceRequest request)
        {
            var result = new TableResultJsonResponse<Device>();
            var data = new List<Device>();
            var predicate = PredicateBuilder.True<Device>();
            var devices = _unitOfWork.GetRepository<Device>().GetAll().Where(predicate)
                .OrderByDescending(x => x.UpdatedDate);
            var total = await devices.CountAsync();
            var dataResult = await devices.Skip(request.Start).Take(request.Length).ToListAsync();
            result.Draw = request.Draw;
            result.RecordsTotal = total;
            result.RecordsFiltered = total;
            result.Data = dataResult;
            return result;
        }

        /// <summary>
        ///     Add device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<Device> AddDevice(Device device)
        {
            var exist = await _unitOfWork.GetRepository<Device>().GetAll()
                .FirstOrDefaultAsync(x => x.Code == device.Code);
            if (exist != null) throw new Exception(ErrorMessages.DeviceCodeAlreadyExist);

            return await AddAsync(device);
        }

        #region Default Service

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public Device Add(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Add(entity);
            _unitOfWork.GetRepository<Device>().SaveChanges();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public async Task<Device> AddAsync(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Device>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Device>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Delete(entity);
            _unitOfWork.GetRepository<Device>().SaveChanges();
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Device>().Delete(id);
            _unitOfWork.GetRepository<Device>().SaveChanges();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Device entity)
        {
            _unitOfWork.GetRepository<Device>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Device>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public Device Find(Expression<Func<Device, bool>> match)
        {
            return _unitOfWork.GetRepository<Device>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<Device> FindAll(Expression<Func<Device, bool>> match)
        {
            return _unitOfWork.GetRepository<Device>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<Device>> FindAllAsync(Expression<Func<Device, bool>> match)
        {
            return await _unitOfWork.GetRepository<Device>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public async Task<Device> FindAsync(Expression<Func<Device, bool>> match)
        {
            return await _unitOfWork.GetRepository<Device>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public Device Get(Guid id)
        {
            return _unitOfWork.GetRepository<Device>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<Device> GetAll()
        {
            return _unitOfWork.GetRepository<Device>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<Device>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Device>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<Device> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Device>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public Device Update(Device entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Device>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Device>().Update(entity);
                _unitOfWork.GetRepository<Device>().SaveChanges();
            }

            return existing;
        }

        /// <summary>
        ///     update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<Device> UpdateAsync(Device entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Device>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Device>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion
    }
}