using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Requests;
using DepartmentGroup.Domain.Models;
using DepartmentGroup.Domain.Models.Requests;
using DepartmentGroup.Domain.Models.Requests.PostModels;
using DepartmentGroup.Domain.Models.Requests.PutModels;
using DepartmentGroup.Domain.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Core.Service.Implements
{
    public class DepartmentService : IDepartmentService
    {
        /// <summary>
        ///     The list value extend service
        /// </summary>
        private readonly IListValueExtendService _listValueExtendService;

        /// <summary>
        ///     The list value service
        /// </summary>
        private readonly IListValueService _listValueService;

        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DepartmentService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="listValueExtendService">The list value extend service.</param>
        /// <param name="listValueService">The list value service.</param>
        public DepartmentService(IUnitOfWork unitOfWork,
            IListValueExtendService listValueExtendService,
            IListValueService listValueService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _listValueExtendService = listValueExtendService;
            _listValueService = listValueService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Checks the unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> CheckUnique(CheckCodeUniqueRequest requestData)
        {
            return await _unitOfWork.GetRepository<Department>()
                .FindAsync(x => x.ListValueExtend.Code.ToLower() == requestData.Code.ToLower()
                                && x.Id != requestData.Id) != null
                ? true
                : false;
        }

        public async Task<IEnumerable<Group>> GetGroup()
        {
            return await _unitOfWork.GetRepository<Group>()
                .ListAsync(x => x.IsActive == true && x.IsDeleted == false, null);
        }

        public async Task<IEnumerable<Department>> GetListValueByValueCode(string valueCode)
        {
            return await _unitOfWork.GetRepository<Department>().GetAll()
                .Where(x => x.ListValueExtend.ListValue != null && x.ListValueExtend.ListValue.Code == valueCode)
                .ToListAsync();
        }

        /// <summary>
        ///     Checks the code unique.
        /// </summary>
        /// <param name="requestData">The request data.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> CheckCodeUnique(CheckCodeUniqueRequest requestData)
        {
            return await _unitOfWork.GetRepository<Department>()
                .FindAsync(x => x.ListValueExtend.Code.ToLower() == requestData.Code.ToLower()
                                && x.Id != requestData.Id) != null
                ? true
                : false;
        }

        /// <summary>
        ///     Gets all list valueby code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>IEnumerable&lt;Department&gt;.</returns>
        public IEnumerable<ListValueExtend> GetAllListValueByCode(DepartmentPagingRequest request, out int total)
        {
            var result = new List<ListValueExtend>();
            var listValueTypePhongBan =
                _unitOfWork.GetRepository<ListValueType>().GetAll().FirstOrDefault(x => x.Code == "PB");
            if (listValueTypePhongBan == null) throw new Exception("Khong tim thay list value type cua phong ban");

            var listValueExtendPhongBan = _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll().Where(x => x.ListValueTypeId == listValueTypePhongBan.Id && x.IsDeleted == false);

            var listDepartments = _unitOfWork.GetRepository<Department>().GetAll()
                .Where(x => x.ListValueExtendId != null).ToList();
            var listValueExtendDepartmentIds = listDepartments.Select(x => x.ListValueExtendId).ToList();


            if (request.ListValueId.HasValue)
                listValueExtendPhongBan = listValueExtendPhongBan.Where(x => x.ListValueId == request.ListValueId);

            if (!string.IsNullOrEmpty(request.Description))
                listValueExtendPhongBan =
                    listValueExtendPhongBan.Where(x => x.Description.ToLower().Contains(request.Description.ToLower()));

            if (!string.IsNullOrEmpty(request.Code))
                listValueExtendPhongBan =
                    listValueExtendPhongBan.Where(x => x.Code.ToLower().Equals(request.Code.ToLower()));

            listValueExtendPhongBan = listValueExtendPhongBan.Where(x => listValueExtendDepartmentIds.Contains(x.Id));

            total = listValueExtendPhongBan.Count();
            if (request.PageSize > 0)
                result = listValueExtendPhongBan.Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();


            return result;
        }

        public async Task<ListValueExtend> AddDepartment(DepartmentPostModel request)
        {
            if (request.ListValueId.HasValue)
            {
                var value = await _unitOfWork.GetRepository<ListValue>().FindAsync(x => x.Id == request.ListValueId);
                if (value == null)
                    throw new Exception("Không tìm thấy chuyên khoa!");
            }

            var isExistCode = await _unitOfWork.GetRepository<Department>()
                .FindAsync(x => x.ListValueExtend.Code.ToLower() == request.Code.ToLower());

            if (isExistCode != null && !isExistCode.IsActive && !isExistCode.IsDeleted)
                throw new Exception(string.Format(ErrorMessages.CodeAlreadyExistButNotActive, request.Code));

            if (isExistCode != null && isExistCode.IsActive && !isExistCode.IsDeleted)
                throw new Exception(string.Format(ErrorMessages.CodeAlreadyExist, request.Code));

            if (isExistCode != null && ((isExistCode.IsActive && isExistCode.IsDeleted) ||
                                        (!isExistCode.IsActive && !isExistCode.IsDeleted)))
            {
                var uModel = _mapper.Map(request, isExistCode);
                uModel.IsActive = true;
                uModel.IsDeleted = false;
                await UpdateAsync(uModel, isExistCode.Id);

                return uModel.ListValueExtend;
            }

            var listValueTypePB = await _unitOfWork.GetRepository<ListValueType>().GetAll().Where(x => x.Code == "PB")
                .FirstOrDefaultAsync();
            if (listValueTypePB == null) throw new Exception("Khong tim list value type loai PB");


            var model = _mapper.Map<Department>(request);
            _unitOfWork.GetRepository<Department>().Add(model);

            ListValueExtend isExist = null;
            if (isExistCode != null)
                // Thêm vào list value extend
                isExist = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                    .Where(x => x.ListValueType != null
                                && x.Id == isExistCode.ListValueExtendId).FirstOrDefaultAsync();

            var result = new ListValueExtend();
            try
            {
                if (isExist != null)
                {
                    isExist.Code = model.ListValueExtend.Code;
                    isExist.Description = model.DepartmentName;
                    isExist.DisplayOrder = request.DisplayOrder;
                    isExist.IsActive = model.IsActive;
                    isExist.IsSystem = model.IsSystem;
                    isExist.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<ListValueExtend>().Update(isExist);
                    await _unitOfWork.CommitAsync();
                    ;

                    model.ListValueExtendId = isExist.Id;
                    _unitOfWork.GetRepository<Department>().Update(model);
                    await _unitOfWork.CommitAsync();
                    ;

                    result = isExist;
                }
                else
                {
                    var modelExtend = new ListValueExtend();
                    modelExtend.Code = request.Code;
                    modelExtend.Description = model.DepartmentName;
                    modelExtend.DisplayOrder = request.DisplayOrder;
                    modelExtend.IsActive = model.IsActive;
                    modelExtend.IsSystem = model.IsSystem;
                    modelExtend.UpdatedDate = DateTime.Now;
                    modelExtend.ListValueId = request.ListValueId.Value;
                    modelExtend.Type = "TEK";
                    modelExtend.ListValueTypeId = listValueTypePB.Id;
                    _unitOfWork.GetRepository<ListValueExtend>().Add(modelExtend);
                    await _unitOfWork.CommitAsync();
                    ;

                    model.ListValueExtendId = modelExtend.Id;
                    _unitOfWork.GetRepository<Department>().Update(model);
                    await _unitOfWork.CommitAsync();
                    ;

                    result = modelExtend;
                }

                // Thêm config
                await InsertDepartmentConfig(request, model);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return result;
        }

        public async Task<ListValueExtend> UpdateDepartmentAdmin(Guid id, DepartmentPutModel request)
        {
            var listValueExtendPhongBan = _unitOfWork.GetRepository<ListValueExtend>().Find(x => x.Id == id);
            if (listValueExtendPhongBan == null) throw new Exception("Không tìm thấy phòng ban");

            var updateModel = _unitOfWork.GetRepository<Department>().Find(x => x.ListValueExtendId == id);
            if (updateModel == null)
                throw new Exception(ErrorMessages.NotFoundExtendValue);

            if (request.ListValueId.HasValue)
            {
                var value = await _unitOfWork.GetRepository<ListValue>().FindAsync(x => x.Id == request.ListValueId);
                if (value == null)
                    throw new Exception("Không tìm thấy chuyên khoa!");
            }

            var codeOld = updateModel.ListValueExtend.Code;

            var model = _mapper.Map(request, updateModel);
            _unitOfWork.GetRepository<Department>().Update(model);

            // Thêm config
            await UpdateDepartmentConfig(request, model);

            // Thêm vào list value extend

            listValueExtendPhongBan.Code = model.ListValueExtend.Code;
            listValueExtendPhongBan.Description = model.DepartmentName;
            listValueExtendPhongBan.DisplayOrder = request.DisplayOrder;
            listValueExtendPhongBan.IsActive = model.IsActive;
            listValueExtendPhongBan.IsSystem = model.IsSystem;
            listValueExtendPhongBan.UpdatedDate = DateTime.Now;
            if (request.ListValueId.HasValue) listValueExtendPhongBan.ListValueId = request.ListValueId.Value;

            _unitOfWork.GetRepository<ListValueExtend>().Update(listValueExtendPhongBan);
            await _unitOfWork.CommitAsync();

            return listValueExtendPhongBan;
        }

        public async Task<Department> UpdateDepartment(Guid id, DepartmentPutModel request)
        {
            var updateModel = await GetAsync(id);
            var codeOld = updateModel.ListValueExtend.Code;

            if (updateModel == null)
                throw new Exception(ErrorMessages.NotFoundExtendValue);

            if (request.ListValueId.HasValue)
            {
                var value = await _unitOfWork.GetRepository<ListValue>().FindAsync(x => x.Id == request.ListValueId);
                if (value == null)
                    throw new Exception("Không tìm thấy chuyên khoa!");
            }

            var isExistCode = await _unitOfWork.GetRepository<Department>()
                .FindAsync(x => x.ListValueExtend.Code.ToLower() == request.Code.ToLower() && x.Id != id);

            if (isExistCode != null && isExistCode.IsDeleted)
                _unitOfWork.GetRepository<Department>().Delete(isExistCode);

            if (isExistCode != null && !isExistCode.IsDeleted)
                throw new Exception(string.Format(ErrorMessages.CodeAlreadyExist, request.Code));

            var model = _mapper.Map(request, updateModel);
            _unitOfWork.GetRepository<Department>().Update(model);

            // Thêm config
            await UpdateDepartmentConfig(request, model);

            // Thêm vào list value extend
            var isExist = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Where(x => x.ListValueType != null
                            && x.ListValueType.Code == "PB"
                            && x.Code == codeOld).FirstOrDefaultAsync();

            if (isExist != null)
            {
                isExist.Code = model.ListValueExtend.Code;
                isExist.Description = model.DepartmentName;
                //isExist.AreaCode = model.AreaCode;
                isExist.IsActive = model.IsActive;
                isExist.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<ListValueExtend>().Update(isExist);
                await _unitOfWork.CommitAsync();
                ;
            }
            else
            {
                var modelExtend = _mapper.Map<ListValueExtend>(model);
                if (modelExtend.ListValue == null)
                {
                    var listValue = await _unitOfWork.GetRepository<ListValue>().GetAll()
                        .Where(x => x.Code == "CLS").FirstOrDefaultAsync();
                    modelExtend.ListValueId = listValue.Id;
                }

                modelExtend.Type = "TEK";
                _unitOfWork.GetRepository<ListValueExtend>().Add(modelExtend);
                await _unitOfWork.CommitAsync();
                ;
            }

            return model;
        }

        public async Task<bool> RemoveInGroup(Guid id)
        {
            var groupDepartment = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll()
                .Where(x => x.DepartmentId == id).ToListAsync();
            if (groupDepartment != null && groupDepartment.Count > 0)
            {
                foreach (var item in groupDepartment)
                    _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().Delete(item);
                await _unitOfWork.CommitAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ListValueExtendChangeDepartmentName>> ChangeNameDepartment(
            List<string> listDepartmentCode)
        {
            if (listDepartmentCode.Count <= 0)
                throw new Exception("Mã phòng rỗng!");

            var listValueExtend = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Where(x => x.ListValueType != null
                            && x.ListValueType.Code == "PB"
                            && listDepartmentCode.Any(l => l == x.Code)).ToListAsync();

            var response = new List<ListValueExtendChangeDepartmentName>();
            foreach (var item in listValueExtend)
            {
                var derpartmentGroup = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll()
                    .Where(x => x.IsRoomActive && x.DepartmentCode == item.Code).FirstOrDefaultAsync();

                if (derpartmentGroup != null)
                {
                    if (derpartmentGroup.DepartmentVirtual != null)
                    {
                        var result = _mapper.Map<ListValueExtendChangeDepartmentName>(item);
                        result.Name = result.Description;
                        result.NameChange = derpartmentGroup.DepartmentVirtual.DepartmentName + " Phòng " +
                                            item.DisplayOrder;
                        response.Add(result);
                    }
                    else
                    {
                        var result = _mapper.Map<ListValueExtendChangeDepartmentName>(item);
                        result.Name = result.Description;
                        result.NameChange = result.Description;
                        response.Add(result);
                    }
                }
                else
                {
                    var result = _mapper.Map<ListValueExtendChangeDepartmentName>(item);
                    result.Name = result.Description;
                    result.NameChange = result.Description;
                    response.Add(result);
                }
            }

            return response;
        }

        public async Task<bool> RemoveInDepartmentConfig(Guid departmentId)
        {
            var isExitList = await _unitOfWork.GetRepository<DepartmentConfig>().GetAll()
                .Where(x => x.DepartmentId == departmentId).ToListAsync();

            try
            {
                foreach (var isExit in isExitList)
                {
                    _unitOfWork.GetRepository<DepartmentConfig>().Delete(isExit);
                    await _unitOfWork.CommitAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDepartmentOfListValueExtend(Department department, string code)
        {
            if (department == null) return true;

            // Thêm vào list value extend
            var isExist = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Where(x => x.Id == department.ListValueExtendId).FirstOrDefaultAsync();

            try
            {
                if (isExist != null)
                {
                    isExist.Code = code;
                    isExist.Description = department.DepartmentName;
                    isExist.IsActive = department.IsActive;
                    isExist.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<ListValueExtend>().Update(isExist);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var modelExtend = _mapper.Map<ListValueExtend>(department);
                if (modelExtend.ListValue == null)
                {
                    var listValue = await _unitOfWork.GetRepository<ListValue>().GetAll()
                        .Where(x => x.Code == "CLS").FirstOrDefaultAsync();
                    modelExtend.ListValueId = listValue.Id;
                }

                modelExtend.Type = "TEK";
                _unitOfWork.GetRepository<ListValueExtend>().Add(modelExtend);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                var e = ex;
                return false;
            }
        }

        public async Task<IEnumerable<Department>> GetDepartmentByGroupCode(string groupCode)
        {
            var group = await _unitOfWork.GetRepository<Group>()
                .FindAsync(x => x.GroupDeptCode == groupCode && !x.IsDeleted);
            if (group == null)
                throw new Exception("Không tồn tại nhóm phòng ban");
            var departmentGroup = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentGroup>().GetAll()
                .Where(x => x.GroupId == group.Id).ToListAsync();
            var departmentIds = departmentGroup.Select(x => x.ListValueExtendId).ToList().Distinct();
            var departments = await _unitOfWork.GetRepository<Department>().GetAll().Include(x => x.ListValueExtend)
                .Where(x => departmentIds.Contains(x.ListValueExtendId)).ToListAsync();
            return departments;
        }

        private async Task<DepartmentConfig> InsertDepartmentConfig(DepartmentPostModel request, Department department)
        {
            if (request.TimeOnMinute <= 0) throw new Exception(ErrorMessages.TimeOnTimes);

            if ((request.StartTimeActiveAM == null && request.EndTimeActiveAM != null)
                || (request.StartTimeActiveAM != null && request.EndTimeActiveAM == null)
                ||
                (request.StartTimeActivePM == null && request.EndTimeActivePM != null)
                || (request.StartTimeActivePM != null && request.EndTimeActivePM == null)
                ||
                (request.StartTimeActiveAM == null && request.EndTimeActiveAM == null
                                                   && request.StartTimeActivePM == null &&
                                                   request.EndTimeActivePM == null))
                throw new Exception(ErrorMessages.TimeSlotErorr);

            if (request.StartTimeActiveAM.HasValue && request.EndTimeActiveAM.HasValue
                                                   && request.StartTimeActiveAM.Value >= request.EndTimeActiveAM.Value)
                throw new Exception(ErrorMessages.TimeSlotErorr);

            if (request.StartTimeActivePM.HasValue && request.EndTimeActivePM.HasValue
                                                   && request.StartTimeActivePM.Value >= request.EndTimeActivePM.Value)
                throw new Exception(ErrorMessages.TimeSlotErorr);

            if (request.EndTimeActiveAM.HasValue && request.StartTimeActivePM.HasValue
                                                 && request.EndTimeActiveAM.Value > request.StartTimeActivePM.Value)
                throw new Exception(ErrorMessages.TimeSlotErorr);

            var model = _mapper.Map<DepartmentConfig>(request);
            model.DepartmentId = department.ListValueExtendId;
            model.TimeActive = JsonConvert.SerializeObject(new TimeActiveViewModel
            {
                StartTimeActiveAM = request.StartTimeActiveAM,
                EndTimeActiveAM = request.EndTimeActiveAM,
                StartTimeActivePM = request.StartTimeActivePM,
                EndTimeActivePM = request.EndTimeActivePM
            });

            model.DepartmentCode = department.ListValueExtend.Code;

            _unitOfWork.GetRepository<DepartmentConfig>().Add(model);
            await _unitOfWork.CommitAsync();
            return model;
        }

        private async Task<DepartmentConfig> UpdateDepartmentConfig(DepartmentPutModel request, Department department)
        {
            if (request.TimeOnMinute <= 0) throw new Exception(ErrorMessages.TimeOnTimes);

            if ((request.StartTimeActiveAM == null && request.EndTimeActiveAM != null)
                || (request.StartTimeActiveAM != null && request.EndTimeActiveAM == null)
                ||
                (request.StartTimeActivePM == null && request.EndTimeActivePM != null)
                || (request.StartTimeActivePM != null && request.EndTimeActivePM == null)
                ||
                (request.StartTimeActiveAM == null && request.EndTimeActiveAM == null
                                                   && request.StartTimeActivePM == null &&
                                                   request.EndTimeActivePM == null))
                throw new Exception(ErrorMessages.TimeSlotErorr);

            if (request.StartTimeActiveAM.HasValue && request.EndTimeActiveAM.HasValue
                                                   && request.StartTimeActiveAM.Value >= request.EndTimeActiveAM.Value)
                throw new Exception(ErrorMessages.TimeSlotErorr);

            if (request.StartTimeActivePM.HasValue && request.EndTimeActivePM.HasValue
                                                   && request.StartTimeActivePM.Value >= request.EndTimeActivePM.Value)
                throw new Exception(ErrorMessages.TimeSlotErorr);

            if (request.EndTimeActiveAM.HasValue && request.StartTimeActivePM.HasValue
                                                 && request.EndTimeActiveAM.Value > request.StartTimeActivePM.Value)
                throw new Exception(ErrorMessages.TimeSlotErorr);

            var departmentConfig = await _unitOfWork.GetRepository<DepartmentConfig>().GetAll()
                .Where(x => x.DepartmentId == department.ListValueExtendId).FirstOrDefaultAsync();

            if (departmentConfig != null)
            {
                var model = _mapper.Map(request, departmentConfig);
                model.DepartmentId = department.ListValueExtendId;
                model.TimeActive = JsonConvert.SerializeObject(new TimeActiveViewModel
                {
                    StartTimeActiveAM = request.StartTimeActiveAM,
                    EndTimeActiveAM = request.EndTimeActiveAM,
                    StartTimeActivePM = request.StartTimeActivePM,
                    EndTimeActivePM = request.EndTimeActivePM
                });

                model.DepartmentCode = department.ListValueExtend.Code;

                _unitOfWork.GetRepository<DepartmentConfig>().Update(model);
                await _unitOfWork.CommitAsync();
                return model;
            }
            else
            {
                var model = _mapper.Map<DepartmentConfig>(request);
                model.DepartmentId = department.ListValueExtendId;
                model.TimeActive = JsonConvert.SerializeObject(new TimeActiveViewModel
                {
                    StartTimeActiveAM = request.StartTimeActiveAM,
                    EndTimeActiveAM = request.EndTimeActiveAM,
                    StartTimeActivePM = request.StartTimeActivePM,
                    EndTimeActivePM = request.EndTimeActivePM
                });

                model.DepartmentCode = department.ListValueExtend.Code;

                _unitOfWork.GetRepository<DepartmentConfig>().Add(model);
                await _unitOfWork.CommitAsync();

                return model;
            }
        }

        #region Default Service

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Department.</returns>
        public Department Add(Department entity)
        {
            _unitOfWork.GetRepository<Department>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Department.</returns>
        public async Task<Department> AddAsync(Department entity)
        {
            _unitOfWork.GetRepository<Department>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Department>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Department>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Department entity)
        {
            _unitOfWork.GetRepository<Department>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Department>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Department entity)
        {
            _unitOfWork.GetRepository<Department>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Department>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Department.</returns>
        public Department Find(Expression<Func<Department, bool>> match)
        {
            return _unitOfWork.GetRepository<Department>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public ICollection<Department> FindAll(Expression<Func<Department, bool>> match)
        {
            return _unitOfWork.GetRepository<Department>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public async Task<ICollection<Department>> FindAllAsync(Expression<Func<Department, bool>> match)
        {
            return await _unitOfWork.GetRepository<Department>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Department.</returns>
        public async Task<Department> FindAsync(Expression<Func<Department, bool>> match)
        {
            return await _unitOfWork.GetRepository<Department>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public Department Get(Guid id)
        {
            return _unitOfWork.GetRepository<Department>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public ICollection<Department> GetAll()
        {
            return _unitOfWork.GetRepository<Department>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public async Task<ICollection<Department>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Department>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public async Task<Department> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Department>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public Department Update(Department entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<Department>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Department>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        ///     update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public async Task<Department> UpdateAsync(Department entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<Department>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Department>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion
    }
}