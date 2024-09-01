// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ILocationService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface ILocationService
    ///     Implements the <see cref="CS.Base.IService{Location, Base.IRepository{Location}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Location, Base.IRepository{Location}}" />
    public interface ILocationService : IService<Location, IRepository<Location>>
    {
        /// <summary>
        ///     Gets the adresss by code.
        /// </summary>
        /// <param name="provincedId">The provinced identifier.</param>
        /// <param name="districtId">The district identifier.</param>
        /// <param name="wardId">The ward identifier.</param>
        /// <returns>Task&lt;Location&gt;.</returns>
        Task<Location> GetAdresssByCode(string provincedId, string districtId, string wardId);

        /// <summary>
        ///     Gets the province.
        /// </summary>
        /// <param name="provincedId">The provinced identifier.</param>
        /// <returns></returns>
        Task<Province> GetProvince(string provincedId);

        /// <summary>
        ///     Gets the district.
        /// </summary>
        /// <param name="provincedId">The provinced identifier.</param>
        /// <param name="districtId">The district identifier.</param>
        /// <returns></returns>
        Task<District> GetDistrict(string provincedId, string districtId);

        /// <summary>
        ///     Gets the ward.
        /// </summary>
        /// <param name="districtId">The district identifier.</param>
        /// <param name="wardId">The ward identifier.</param>
        /// <returns></returns>
        Task<Ward> GetWard(string districtId, string wardId);

        /// <summary>
        ///     Gets all with group format.
        /// </summary>
        /// <returns></returns>
        IEnumerable<LocationResponse> GetAllWithGroupFormat();

        Task<List<Province>> GetAllProvincesAsync();
        Task<List<District>> GetAlDistrictsAsync();
        Task<List<Ward>> GetAlWardsAsync();
    }

    /// <summary>
    ///     Class LocationResponse.
    /// </summary>
    public class LocationResponse
    {
        /// <summary>
        ///     Gets or sets the name of the province.
        /// </summary>
        /// <value>The name of the province.</value>
        public string ProvinceName { get; set; }

        /// <summary>
        ///     Gets or sets the province code.
        /// </summary>
        /// <value>The province code.</value>
        public string ProvinceCode { get; set; }

        /// <summary>
        ///     Gets or sets the districts.
        /// </summary>
        /// <value>The districts.</value>
        public List<DistrictResponse> Districts { get; set; }
    }

    /// <summary>
    ///     Class DistrictResponse.
    /// </summary>
    public class DistrictResponse
    {
        /// <summary>
        ///     Gets or sets the name of the district.
        /// </summary>
        /// <value>The name of the district.</value>
        public string DistrictName { get; set; }

        /// <summary>
        ///     Gets or sets the district code.
        /// </summary>
        /// <value>The district code.</value>
        public string DistrictCode { get; set; }

        /// <summary>
        ///     Gets or sets the wards.
        /// </summary>
        /// <value>The wards.</value>
        public List<WardResponse> Wards { get; set; }
    }

    /// <summary>
    ///     Class WardResponse.
    /// </summary>
    public class WardResponse
    {
        /// <summary>
        ///     Gets or sets the name of the ward.
        /// </summary>
        /// <value>The name of the ward.</value>
        public string WardName { get; set; }

        /// <summary>
        ///     Gets or sets the ward code.
        /// </summary>
        /// <value>The ward code.</value>
        public string WardCode { get; set; }
    }
}