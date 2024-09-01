// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IDeviceService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IDeviceService
    ///     Implements the <see cref="CS.Base.IService{Device, Base.IRepository{Device}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Device, Base.IRepository{Device}}" />
    public interface IDeviceService : IService<Device, IRepository<Device>>
    {
        /// <summary>
        ///     Gets all device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<Device>> GetAllDevice(GetAllDeviceRequest request);

        /// <summary>
        ///     Gets all device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<Device> AddDevice(Device request);
    }
}