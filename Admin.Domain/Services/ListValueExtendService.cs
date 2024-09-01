using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Domain.BusinessObjects;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    public class ListValueExtendService : IListValueExtendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHospitalSystemService _hospitalSystemService;
        public ListValueExtendService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService)
        {
            _hospitalSystemService = hospitalSystemService;
            _unitOfWork = unitOfWork;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public ListValueExtend Add(ListValueExtend entity)
        {
            _unitOfWork.GetRepository<ListValueExtend>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValueExtend> AddAsync(ListValueExtend entity)
        {
            _unitOfWork.GetRepository<ListValueExtend>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<ListValueExtend>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(ListValueExtend entity)
        {
            _unitOfWork.GetRepository<ListValueExtend>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<ListValueExtend>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(ListValueExtend entity)
        {
            _unitOfWork.GetRepository<ListValueExtend>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<ListValueExtend>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public ListValueExtend Find(Expression<Func<ListValueExtend, bool>> match)
        {
            return _unitOfWork.GetRepository<ListValueExtend>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<ListValueExtend> FindAll(Expression<Func<ListValueExtend, bool>> match)
        {
            return _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<ListValueExtend>> FindAllAsync(Expression<Func<ListValueExtend, bool>> match)
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValueExtend> FindAsync(Expression<Func<ListValueExtend, bool>> match)
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public ListValueExtend Get(Guid id)
        {
            return _unitOfWork.GetRepository<ListValueExtend>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<ListValueExtend> GetAll()
        {
            return _unitOfWork.GetRepository<ListValueExtend>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<ListValueExtend>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<ListValueExtend> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>ListValueExtend.</returns>
        public ListValueExtend Update(ListValueExtend entity, Guid id)
        {
            if (entity == null)
                return null;

            ListValueExtend existing = _unitOfWork.GetRepository<ListValueExtend>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<ListValueExtend>().Update(entity);
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
        /// ListValueExtend.
        /// </returns>
        public async Task<ListValueExtend> UpdateAsync(ListValueExtend entity, Guid id)
        {
            if (entity == null)
                return null;

            ListValueExtend existing = await _unitOfWork.GetRepository<ListValueExtend>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<ListValueExtend>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Checks the code unique.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> CheckCodeUnique(CheckCodeUniqueRequest requestData)
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(x => x.Code.ToLower() == requestData.Code.ToLower() && x.Id != requestData.Id) != null ? true : false;

        }

        /// <summary>
        /// Gets the list values activated.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;IEnumerable&lt;ListValueExtend&gt;&gt;.</returns>
        public async Task<IEnumerable<ListValueExtend>> GetListValuesActivated(string code)
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().ListAsync(x => x.ListValueType.Code == code && x.IsActive == true && x.IsDeleted == false, null);
        }

        /// <summary>
        /// Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>IEnumerable&lt;ListValueExtend&gt;.</returns>
        public async Task<List<ListValueExtend>> GetAllListValuebyCode(string code)
        {
            return _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Where(x => x.ListValueType.Code == code && x.IsDeleted == false)
                .ToList();
        }

        /// <summary>
        /// Gets all list valueby code and name.
        /// </summary>
        /// <returns>IEnumerable&lt;ListValueExtend&gt;.</returns>
        public async Task<List<ListValueExtend>> GetAllListValuebyCodeAndDescription(GetAllListValuesRequest requestData)
        {
            return _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Where(x => x.ListValueType.Code == requestData.Code && x.Description.ToLower().Contains(requestData.Description.ToLower()) && x.IsDeleted == false)
                .ToList();
        }

        //public async Task<IEnumerable<ListValueExtend>> GetByGroupCode(string code)
        //{
        //    var listValue = await _unitOfWork.GetRepository<ListValue>().FindAsync(x => x.Code == code && !x.IsDeleted);

        //    if (listValue == null)
        //        throw new Exception("Không tìm thấy nhóm phòng ban!");

        //    var listValueExtends = await _unitOfWork.GetRepository<DepartmentGroup>()
        //        .GetAll()
        //        .Where(x => x.ListValueId == listValue.Id)
        //        .Select(x => x.ListValueExtend)
        //        .ToListAsync();

        //    return listValueExtends;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListValueExtend>> GetListDepartment()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().ListAsync(x => x.ListValueType.Code == ValueTypeCode.DepartmentCode && x.IsActive == true && x.IsDeleted == false, null);
        }

        public async Task<bool> SynchronizationListService(ServiceListFromHisRawData<GetListServiceFromHisRawData> request)
        {
            var listValueExtend = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().ToListAsync();
            var listValue = await _unitOfWork.GetRepository<ListValue>().GetAll().ToListAsync();
            var listValueType = await _unitOfWork.GetRepository<ListValueType>().FindAsync(x => x.Code == ValueTypeCode.ServiceCode);
            if (request != null)
            {
                foreach (var item in request.result)
                {
                    var checkListValueExtend = listValueExtend.FirstOrDefault(x => x.Code == item.ServiceCode);
                    var checkListValue = listValue.FirstOrDefault(x => x.Code == item.ListValueCode);
                    if (checkListValueExtend == null && checkListValue != null)
                    {
                        var newListValueExtend = new ListValueExtend
                        {
                            Id = Guid.NewGuid(),
                            ListValueTypeId = listValueType.Id,
                            DisplayOrder = 1,
                            Code = item.ServiceCode,
                            Description = item.Description,
                            IsDeleted = false,
                            IsActive = true,
                            Type = "HIS_K",
                            ListValueId = checkListValue.Id
                        };
                        _unitOfWork.GetRepository<ListValueExtend>().Add(newListValueExtend);
                    }
                    else
                    {
                        checkListValueExtend.Description = item.Description;
                        checkListValueExtend.IsDeleted = false;
                        _unitOfWork.GetRepository<ListValueExtend>().Update(checkListValueExtend);
                    }
                }
            }
            return await _unitOfWork.CommitAsync() > 0;
        }

        Task<IEnumerable<ListValueExtend>> IListValueExtendService.GetAllListValuebyCode(string code)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ListValueExtend>> IListValueExtendService.GetAllListValuebyCodeAndDescription(GetAllListValuesRequest requestData)
        {
            throw new NotImplementedException();
        }
    }
}
