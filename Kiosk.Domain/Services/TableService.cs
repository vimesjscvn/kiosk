using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Settings;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using CS.VM.CheckInModel.Responses;
using CS.VM.CheckInModel.Requests;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.ITableService" />
    public class TableService : ITableService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The hospital settings
        /// </summary>
        private readonly HospitalSettings _hospitalSettings;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public TableService(IUnitOfWork unitOfWork,
             HospitalSettings hospitalSettings,
             IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
            _mapper = mapper;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public Table Add(Table entity)
        {
            _unitOfWork.GetRepository<Table>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Table> AddAsync(Table entity)
        {
            _unitOfWork.GetRepository<Table>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Table>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Table>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Table entity)
        {
            _unitOfWork.GetRepository<Table>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Table>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Table entity)
        {
            _unitOfWork.GetRepository<Table>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Table>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public Table Find(Expression<Func<Table, bool>> match)
        {
            return _unitOfWork.GetRepository<Table>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Table> FindAll(Expression<Func<Table, bool>> match)
        {
            return _unitOfWork.GetRepository<Table>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Table>> FindAllAsync(Expression<Func<Table, bool>> match)
        {
            return await _unitOfWork.GetRepository<Table>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Table> FindAsync(Expression<Func<Table, bool>> match)
        {
            return await _unitOfWork.GetRepository<Table>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public Table Get(Guid id)
        {
            return _unitOfWork.GetRepository<Table>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<Table> GetAll()
        {
            return _unitOfWork.GetRepository<Table>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<Table>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Table>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<Table> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Table>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Table.</returns>
        public Table Update(Table entity, Guid id)
        {
            if (entity == null)
                return null;

            Table existing = _unitOfWork.GetRepository<Table>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Table>().Update(entity);
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
        /// Table.
        /// </returns>
        public async Task<Table> UpdateAsync(Table entity, Guid id)
        {
            if (entity == null)
                return null;

            Table existing = await _unitOfWork.GetRepository<Table>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Table>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Gets the callable tables.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Table>> GetCallableTables()
        {
            var areaCode = _hospitalSettings.Hospital.HospitalArea;
            return await _unitOfWork.GetRepository<Table>().GetAll()
                .Where(x => x.DeviceType == (int)TableDeviceType.NORMAL && x.AreaCode == areaCode)
                .OrderBy(x => x.Code)
                .ToListAsync();
        }

        public async Task<TableResultJsonResponse<TableViewModel>> GetAllTable(GetTableRequest request)
        {
            var result = new TableResultJsonResponse<TableViewModel>();
            List<TableViewModel> data = new List<TableViewModel>();
            var predicate = PredicateBuilder.Create<Table>(x => x.AreaCode == _hospitalSettings.Hospital.HospitalArea);
            var tables = _unitOfWork.GetRepository<Table>().GetAll().Where(predicate).OrderByDescending(x => x.UpdatedDate);
            var total = await tables.CountAsync();
            var dataResult = await tables.Skip(request.Start).Take(request.Length).ToListAsync();
            
            foreach (var item in dataResult)
            {
                data.Add(_mapper.Map<TableViewModel>(item));
            }

            result.Draw = request.Draw;
            result.RecordsTotal = total;
            result.RecordsFiltered = total;
            result.Data = data;

            return result;
        }

        /// <summary>
        /// Updates the table.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateTable(Guid id, TablePutModel request)
        {
            var table = await _unitOfWork.GetRepository<Table>().FindAsync(x => x.Id == id);
            if (table == null)
                throw new Exception(ErrorMessages.NotFoundTable);

            var tableMapIp = await _unitOfWork.GetRepository<Table>().FindAsync(x => x.ComputerIP == request.ComputerIP);

            if (tableMapIp != null)
                if (table.Code != tableMapIp.Code && table.ComputerIP != tableMapIp.ComputerIP)
                    throw new Exception(ErrorMessages.IpIsMapTable);

            table = _mapper.Map(request, table);
            _unitOfWork.GetRepository<Table>().Update(table);
            return await _unitOfWork.CommitAsync() >= 1;
        }

        /// <summary>
        /// Checks the code unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> CheckCodeUnique(CheckCodeUniqueRequest request)
        {
            return await _unitOfWork.GetRepository<Table>().FindAsync(x => x.Code.ToLower() == request.Code.ToLower() && x.Id != request.Id) != null;
        }

        public Task<ChangeTableTypeResponse> ChangeTableType(ChangeTableTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TableResultJsonResponse<TableViewModel>> GetAllTableByDepartmentCode(GetAllTableByDepartmentCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIsTableByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
