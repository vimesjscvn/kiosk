// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="LocationService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Common.Caching;
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
    /// Class LocationService.
    /// Implements the <see cref="CS.Abstractions.IServices.ILocationService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.ILocationService" />
    public class LocationService : ILocationService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICacheService _cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public LocationService(IUnitOfWork unitOfWork,
            ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public Location Add(Location entity)
        {
            _unitOfWork.GetRepository<Location>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Location> AddAsync(Location entity)
        {
            _unitOfWork.GetRepository<Location>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Location>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Location>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Location entity)
        {
            _unitOfWork.GetRepository<Location>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Location>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Location entity)
        {
            _unitOfWork.GetRepository<Location>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Location>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Location Find(Expression<Func<Location, bool>> match)
        {
            return _unitOfWork.GetRepository<Location>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Location> FindAll(Expression<Func<Location, bool>> match)
        {
            return _unitOfWork.GetRepository<Location>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Location>> FindAllAsync(Expression<Func<Location, bool>> match)
        {
            return await _unitOfWork.GetRepository<Location>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Location> FindAsync(Expression<Func<Location, bool>> match)
        {
            return await _unitOfWork.GetRepository<Location>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Location Get(Guid id)
        {
            return _unitOfWork.GetRepository<Location>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Location> GetAll()
        {
            return _unitOfWork.GetRepository<Location>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Location>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Location>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Location> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Location>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Location.</returns>
        public Location Update(Location entity, Guid id)
        {
            if (entity == null)
                return null;

            Location existing = _unitOfWork.GetRepository<Location>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Location>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Location.
        /// </returns>
        public async Task<Location> UpdateAsync(Location entity, Guid id)
        {
            if (entity == null)
                return null;

            Location existing = await _unitOfWork.GetRepository<Location>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Location>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// IEnumerable&lt;LocationResponse&gt;.
        /// </returns>
        public IEnumerable<LocationResponse> GetAllWithGroupFormat()
        {
            var test = _unitOfWork.GetRepository<Ward>().GetAll().Where(w => w.DistrictCode == "KXD" && w.Code == "KXD").FirstOrDefault();
            var provinces = _unitOfWork.GetRepository<Province>().GetAll().ToList();
            var districts = _unitOfWork.GetRepository<District>().GetAll().ToList().GroupBy(district => district.ProvinceCode)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());
            var wards = _unitOfWork.GetRepository<Ward>().GetAll().ToList().GroupBy(ward => ward.DistrictCode)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());

            return provinces.Select(province => new LocationResponse()
            {
                ProvinceName = province.Name,
                ProvinceCode = province.Code,
                Districts = districts[province.Code].Select(district => new DistrictResponse()
                {
                    DistrictCode = district.Code,
                    DistrictName = district.Name,
                    Wards = wards[district.Code].Select(ward => new WardResponse()
                    {
                        WardCode = ward.Code,
                        WardName = ward.Name
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        /// <summary>
        /// Gets the adresss by code.
        /// </summary>
        /// <param name="provincedId">The provinced identifier.</param>
        /// <param name="districtId">The district identifier.</param>
        /// <param name="wardId">The ward identifier.</param>
        /// <returns>Location.</returns>
        public async Task<Location> GetAdresssByCode(string provincedId, string districtId, string wardId)
        {
            return await _unitOfWork.GetRepository<Location>().FindAsync(x => x.ProvinceCode == provincedId && x.DistrictCode == districtId && x.WardCode == wardId);
        }

        /// <summary>
        /// Gets the province.
        /// </summary>
        /// <param name="provincedId">The provinced identifier.</param>
        /// <returns></returns>
        public async Task<Province> GetProvince(string provincedId)
        {
            return await _unitOfWork.GetRepository<Province>().GetAll().FirstOrDefaultAsync(p => p.Code == provincedId);
        }

        /// <summary>
        /// Gets the district.
        /// </summary>
        /// <param name="provincedId">The provinced identifier.</param>
        /// <param name="districtId">The district identifier.</param>
        /// <returns></returns>
        public async Task<District> GetDistrict(string provincedId, string districtId)
        {
            return await _unitOfWork.GetRepository<District>().GetAll().FirstOrDefaultAsync(p => p.Code == districtId && p.ProvinceCode == provincedId);
        }

        /// <summary>
        /// Gets the ward.
        /// </summary>
        /// <param name="districtId">The district identifier.</param>
        /// <param name="wardId">The ward identifier.</param>
        /// <returns></returns>
        public async Task<Ward> GetWard(string districtId, string wardId)
        {
            return await _unitOfWork.GetRepository<Ward>().GetAll().FirstOrDefaultAsync(p => p.Code == wardId && p.DistrictCode == districtId);
        }

        public async Task<List<Province>> GetAllProvincesAsync()
        {
            return await _cacheService.GetAsync(CacheKeyConstants.ProvinceKey, async () =>
            {
                return await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            }
           );
        }

        public async Task<List<District>> GetAlDistrictsAsync()
        {
            return await _cacheService.GetAsync(CacheKeyConstants.DistrictKey, async () =>
            {
                return await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            }
           );
        }

        public async Task<List<Ward>> GetAlWardsAsync()
        {
            return await _cacheService.GetAsync(CacheKeyConstants.WardKey, async () =>
            {
                return await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            }
           );
        }
    }
}
