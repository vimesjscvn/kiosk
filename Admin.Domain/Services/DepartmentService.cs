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
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    public class DepartmentService : IDepartmentService
    {
       /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The list value extend service
        /// </summary>
        private readonly IListValueExtendService _listValueExtendService;
        /// <summary>
        /// The list value service
        /// </summary>
        private readonly IListValueService _listValueService;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class.
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

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Department.</returns>
        public CS.EF.Models.DepartmentService Add(CS.EF.Models.DepartmentService entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Department.</returns>
        public async Task<CS.EF.Models.DepartmentService> AddAsync(CS.EF.Models.DepartmentService entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(CS.EF.Models.DepartmentService entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(CS.EF.Models.DepartmentService entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Department.</returns>
        public CS.EF.Models.DepartmentService Find(Expression<Func<CS.EF.Models.DepartmentService, bool>> match)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public ICollection<CS.EF.Models.DepartmentService> FindAll(Expression<Func<CS.EF.Models.DepartmentService, bool>> match)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public async Task<ICollection<CS.EF.Models.DepartmentService>> FindAllAsync(Expression<Func<CS.EF.Models.DepartmentService, bool>> match)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Department.</returns>
        public async Task<CS.EF.Models.DepartmentService> FindAsync(Expression<Func<CS.EF.Models.DepartmentService, bool>> match)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public CS.EF.Models.DepartmentService Get(Guid id)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public ICollection<CS.EF.Models.DepartmentService> GetAll()
        {
            return _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public async Task<ICollection<CS.EF.Models.DepartmentService>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public async Task<CS.EF.Models.DepartmentService> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public CS.EF.Models.DepartmentService Update(CS.EF.Models.DepartmentService entity, Guid id)
        {
            if (entity == null)
                return null;

            CS.EF.Models.DepartmentService existing = _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public async Task<CS.EF.Models.DepartmentService> UpdateAsync(CS.EF.Models.DepartmentService entity, Guid id)
        {
            if (entity == null)
                return null;

            CS.EF.Models.DepartmentService existing = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<DepartmentServiceViewModel>> GetAll(DepartmentServiceRequest request)
        {
            var result = new TableResultJsonResponse<DepartmentServiceViewModel>();
            List<DepartmentServiceViewModel> data = new List<DepartmentServiceViewModel>();

            var predicate = PredicateBuilder.True<CS.EF.Models.DepartmentService>();

            if (request.DeparmentId.HasValue)
                predicate = predicate.And(x => x.DepartmentId == request.DeparmentId.Value);

            if (request.RoomId.HasValue)
                predicate = predicate.And(x => x.RoomId == request.RoomId.Value);

            if (request.ExaminationId.HasValue)
                predicate = predicate.And(x => x.ExaminationId == request.ExaminationId.Value);

            if (request.ServiceId.HasValue)
                predicate = predicate.And(x => x.ServiceId == request.ServiceId.Value);

            if (request.UsageType.HasValue)
                predicate = predicate.And(x => x.UsageType == request.UsageType.Value);

            if (request.Type.HasValue)
                predicate = predicate.And(x => x.Type == request.Type.Value);

            var departmentServices = _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().Where(predicate).OrderByDescending(l => l.UpdatedDate);

            var totalRecord = await departmentServices.CountAsync();

            var dataResult = await departmentServices.Skip(request.Start).Take(request.Length).ToListAsync();

            foreach (var item in dataResult)
            {
                var viewModel = _mapper.Map<DepartmentServiceViewModel>(item);
                viewModel.DepartmentName = item.Department?.Description;
                viewModel.DepartmentCode = item.Department?.Code;
                viewModel.ServiceCode = item.Service?.Code;
                viewModel.ServiceName = item.Service?.Description;
                viewModel.RoomCode = item.Room?.Code;
                viewModel.RoomName = item.Room?.Description;
                viewModel.ExaminationCode = item.Examination?.Code;
                viewModel.ExaminationName = item.Examination?.Description;
                data.Add(viewModel);
            }

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data;

            return result;
        }

        /// <summary>
        /// Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<List<DepartmentServiceViewModel>> Export(ExportDepartmentServiceRequest request)
        {
            var predicate = PredicateBuilder.True<CS.EF.Models.DepartmentService>();

            if (request.DeparmentId.HasValue)
                predicate = predicate.And(x => x.DepartmentId == request.DeparmentId.Value);

            if (request.RoomId.HasValue)
                predicate = predicate.And(x => x.RoomId == request.RoomId.Value);

            if (request.ExaminationId.HasValue)
                predicate = predicate.And(x => x.ExaminationId == request.ExaminationId.Value);

            if (request.ServiceId.HasValue)
                predicate = predicate.And(x => x.ServiceId == request.ServiceId.Value);

            if (request.UsageType.HasValue)
                predicate = predicate.And(x => x.UsageType == request.UsageType.Value);

            if (request.Type.HasValue)
                predicate = predicate.And(x => x.Type == request.Type.Value);

            var departmentServices = await _unitOfWork
                .GetRepository<CS.EF.Models.DepartmentService>()
                .GetAll()
                    .Include(x => x.Department)
                    .Include(x => x.Service)
                    .Include(x => x.Room)
                    .Include(x => x.Examination)
                .Where(predicate).OrderBy(l => l.UpdatedDate).ToListAsync();

            List<DepartmentServiceViewModel> data = new List<DepartmentServiceViewModel>();

            foreach (var item in departmentServices)
            {
                var viewModel = _mapper.Map<DepartmentServiceViewModel>(item);
                viewModel.DepartmentName = item.Department?.Description;
                viewModel.DepartmentCode = item.Department?.Code;
                viewModel.ServiceCode = item.Service?.Code;
                viewModel.ServiceName = item.Service?.Description;
                viewModel.RoomCode = item.Room?.Code;
                viewModel.RoomName = item.Room?.Description;
                viewModel.ExaminationCode = item.Examination?.Code;
                viewModel.ExaminationName = item.Examination?.Description;
                data.Add(viewModel);
            }

            return data;
        }

        /// <summary>
        /// Checks the unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> CheckUnique(CheckUniqueRequest request)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>()
                                                                 .FindAsync(x => x.DepartmentId == request.DepartmentId &&
                                                                 x.RoomId == request.RoomId &&
                                                                 x.ExaminationId == request.ExaminationId &&
                                                                 x.ServiceId == request.ServiceId &&
                                                                 x.UsageType == request.UsageType) != null ? true : false;
        }

        /// <summary>
        /// Adds the department service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<bool> AddDepartmentService(AddDepartmentServiceRequest request)
        {
            var departmentService = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>()
                                            .FindAsync(x => x.DepartmentId == request.DepartmentId &&
                                                                 x.RoomId == request.RoomId &&
                                                                 x.ExaminationId == request.ExaminationId &&
                                                                 x.ServiceId == request.ServiceId &&
                                                                 x.UsageType == request.UsageType);

            if (departmentService != null)
                throw new Exception(ErrorMessages.ExsitedDepartmentService);

            var department = await _listValueService.GetAsync(request.DepartmentId);
            if (department == null)
                throw new Exception(ErrorMessages.NotFoundDepartmentService);

            var service = await _listValueExtendService.GetAsync(request.ServiceId);
            if (service == null)
                throw new Exception(ErrorMessages.NotFoundService);

            var examination = await _listValueExtendService.GetAsync(request.ExaminationId);
            if (examination == null)
                throw new Exception(ErrorMessages.NotFoundExamination);

            var room = await _listValueExtendService.GetAsync(request.RoomId);
            if (room == null)
                throw new Exception(ErrorMessages.NotFoundRoom);

            var addModel = _mapper.Map<CS.EF.Models.DepartmentService>(request);
            addModel.Type = CreatedType.Web;
            addModel.Department = department;
            addModel.Service = service;
            addModel.Examination = examination;
            addModel.Room = room;
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Add(addModel);
            return await _unitOfWork.CommitAsync() >= 1;
        }

        /// <summary>
        /// Updates the department service.
        /// </summary>
        /// <param name="departmentServiceId">The department service identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<bool> UpdateDepartmentService(Guid departmentServiceId, UpdateDepartmentServiceRequest request)
        {
            var departmentService = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAsyncById(departmentServiceId);
            if (departmentService == null)
                throw new Exception(ErrorMessages.NotFoundDepartmentService);

            var department = await _listValueService.GetAsync(request.DepartmentId);
            if (department == null)
                throw new Exception(ErrorMessages.NotFoundDepartmentService);

            var service = await _listValueExtendService.GetAsync(request.ServiceId);
            if (service == null)
                throw new Exception(ErrorMessages.NotFoundService);

            var examination = await _listValueExtendService.GetAsync(request.ExaminationId);
            if (examination == null)
                throw new Exception(ErrorMessages.NotFoundExamination);

            var room = await _listValueExtendService.GetAsync(request.RoomId);
            if (room == null)
                throw new Exception(ErrorMessages.NotFoundRoom);

            departmentService.ServiceId = request.ServiceId;
            departmentService.UsageType = request.UsageType;
            departmentService.DepartmentId = request.DepartmentId;
            departmentService.Service = service;
            departmentService.Department = department;
            departmentService.Examination = examination;
            departmentService.ExaminationId = request.ExaminationId;
            departmentService.Room = room;
            departmentService.RoomId = request.RoomId;
            departmentService.IsActive = request.IsActive;
            _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Update(departmentService);

            return await _unitOfWork.CommitAsync() >= 1;
        }

        ///// <summary>
        ///// Verifies the department service.
        ///// </summary>
        ///// <param name="imports">The imports.</param>
        ///// <returns></returns>
        //public async Task<ImportDepartmentServiceResponse> VerifyDepartmentService(List<ImportDepartmentServiceModel> imports)
        //{
        //    var listDepartmentKind = await _listValueService.GetAllListValuebyCode(ValueTypeCode.DepartmentKindCode);

        //    var listDepartment = await _listValueExtendService.GetAllListValuebyCode(ValueTypeCode.DepartmentCode);

        //    var listService = await _listValueExtendService.GetAllListValuebyCode(ValueTypeCode.ServiceCode);

        //    var listVerify = new List<ImportDepartmentServiceModel>();

        //    var listDepartmentService = new List<CS.EF.Models.DepartmentService>();

        //    var allDepartmentService = _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll();

        //    foreach (var item in imports)
        //    {
        //        var department = listDepartmentKind.FirstOrDefault(x => x.Code == item.DepartmentCode);

        //        if (department == null)
        //        {
        //            item.Status = false;
        //            item.Message.Add("Không tìm thấy khoa");
        //            item.Note.Add($"Mã khoa: {item.DepartmentCode}");
        //        }

        //        var service = listService.FirstOrDefault(x => x.Code == item.ServiceCode);

        //        if (service == null)
        //        {
        //            item.Status = false;
        //            item.Message.Add(ErrorMessages.NotFoundService);
        //            item.Note.Add($"Mã dịch vụ: {item.ServiceCode}");
        //        }

        //        var room = listDepartment.FirstOrDefault(x => x.Code == item.RoomCode);

        //        if (room == null)
        //        {
        //            item.Status = false;
        //            item.Message.Add(ErrorMessages.NotFoundRoom);
        //            item.Note.Add($"Mã phòng thực hiện: {item.RoomCode}");
        //        }

        //        var examination = listDepartment.FirstOrDefault(x => x.Code == item.ExaminationCode);

        //        if (examination == null)
        //        {
        //            item.Status = false;
        //            item.Message.Add(ErrorMessages.NotFoundExamination);
        //            item.Note.Add($"Mã phòng chỉ định: {item.ExaminationCode}");
        //        }

        //        var usageType = UsageType.Normal;
        //        var hasUsageType = false;
        //        if (item.UsageType != null)
        //        {
        //            hasUsageType = true;
        //            if (item.UsageType.ToLower() == "service") usageType = UsageType.Service;
        //            else if (item.UsageType.ToLower() == "male") usageType = UsageType.Male;
        //            else if (item.UsageType.ToLower() == "female") usageType = UsageType.Female;
        //            else if (item.UsageType.ToLower() == UsageTypeConstants.LDLK.ToLower()) usageType = UsageType.LDLK;
        //        }
        //        else
        //        {
        //            item.Status = false;
        //            item.Message.Add(ErrorMessages.NotFoundUsageType);
        //        }

        //        if (department != null && service != null && room != null && examination != null && hasUsageType)
        //        {
        //            try
        //            {
        //                var departmentService = await allDepartmentService.Where(x =>
        //                                                          x.DepartmentId == department.Id &&
        //                                                          x.RoomId == room.Id &&
        //                                                          x.ExaminationId == examination.Id &&
        //                                                          x.ServiceId == service.Id &&
        //                                                          x.UsageType == usageType)
        //                                                         .ToListAsync();
        //                if (departmentService.Count > 0)
        //                {
        //                    item.Status = false;
        //                    item.Message.Add(ErrorMessages.ExsitedDepartmentService);
        //                    item.Note.Add("");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                item.Status = false;
        //                item.Message.Add(ex.Message);
        //                item.Note.Add($"Mã dịch vụ: {item.ServiceCode}, Mã khoa: {item.DepartmentCode}, Mã phòng thực hiện: {item.RoomCode}, Mã phòng chỉ định: {item.ExaminationCode}");
        //            }

        //        }

        //        listVerify.Add(item);

        //        if (item.Status)
        //            listDepartmentService.Add(new CS.EF.Models.DepartmentService
        //            {
        //                Id = Guid.NewGuid(),
        //                DepartmentId = department.Id,
        //                RoomId = room.Id,
        //                ExaminationId = examination.Id,
        //                IsActive = true,
        //                ServiceId = service.Id,
        //                CreatedBy = Systems.CreatedBy,
        //                CreatedDate = DateTime.Now,
        //                UpdatedBy = Systems.CreatedBy,
        //                UpdatedDate = DateTime.Now,
        //                UsageType = usageType,
        //                Type = CreatedType.ImportExcel
        //            });
        //    }

        //    if (listVerify.Any(x => !x.Status))
        //    {
        //        return new ImportDepartmentServiceResponse
        //        {
        //            Import = listVerify,
        //            TotalError = listVerify.Count(x => !x.Status),
        //            Total = imports.Count,
        //            IsVerify = false,
        //            FileErrorUrl = "",
        //        };
        //    }
        //    else
        //    {
        //        await AddDepartmentService(listDepartmentService);
        //        return new ImportDepartmentServiceResponse
        //        {
        //            IsVerify = true,
        //            TotalError = 0,
        //            Import = listVerify,
        //            Total = imports.Count,
        //            FileErrorUrl = "",
        //        };
        //    }
        //}

        /// <summary>
        /// Adds the department service.
        /// </summary>
        /// <param name="data">The data.</param>
        private async Task AddDepartmentService(List<CS.EF.Models.DepartmentService> data)
        {
            foreach (var item in data)
            {
                _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().Add(item);
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Group>> GetGroup()
        {
            return await _unitOfWork.GetRepository<Group>().ListAsync(x => x.IsActive == true && x.IsDeleted == false, null);
        }

        public Task<ImportDepartmentServiceResponse> VerifyDepartmentService(List<ImportDepartmentServiceModel> imports)
        {
            throw new NotImplementedException();
        }
    }
}
