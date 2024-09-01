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
using CS.VM.Responses;
using Dapper;
using DepartmentGroup.Domain.Models;
using DepartmentGroup.Domain.Models.Requests;
using DepartmentGroup.Domain.Models.Requests.PostModels;
using DepartmentGroup.Domain.Models.Requests.PutModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    public class PatientDepartmentService : IPatientDepartmentService
    {
        /// <summary>
        ///     ApplicationDbContext
        /// </summary>
        private const string ApplicationDbContext = "ApplicationDbContext";

        /// <summary>
        ///     _configuration
        /// </summary>
        private readonly IConfiguration _configuration;

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
        ///     Initializes a new instance of the <see cref="DepartmentServiceService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="listValueExtendService">The list value extend service.</param>
        /// <param name="listValueService">The list value service.</param>
        public PatientDepartmentService(IUnitOfWork unitOfWork,
            IListValueExtendService listValueExtendService,
            IListValueService listValueService,
            IMapper mapper,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _listValueExtendService = listValueExtendService;
            _listValueService = listValueService;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        ///     Gets all department.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ListValueExtend>> GetListDepartment()
        {
            return await _unitOfWork.GetRepository<ListValueExtend>().ListAsync(
                x => x.ListValueType.Code == ValueTypeCode.DepartmentCode && x.IsActive == true && x.IsDeleted == false,
                null);
        }

        public async Task InsertListServiceOfDepartment(InsertPatientDepartmentServiceModel request)
        {
            if (request == null || request.ServiceCodeList == null || request.ServiceCodeList.Count == 0)
                throw new Exception(ErrorMessages.ServiceOfDepartmentEmpty);

            if (request.ObjectTypeList == null
                || request.ObjectTypeList.Count == 0
                || request.ObjectTypeList.All(x => Enum.IsDefined(typeof(ObjectType), x)) == false)
                throw new Exception(ErrorMessages.ErrorObjectType);

            var serviceCodes = request.ServiceCodeList.Distinct();

            var services = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .Where(x => serviceCodes.Any(s => s == x.Code))
                .ToListAsync();

            foreach (var item in services)
            foreach (var type in request.ObjectTypeList)
            {
                var exist = await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll().Where(x =>
                    x.ObjectType == type.ToString()
                    && x.ExaminationCode == request.ExaminationCode
                    && x.ServiceCode == item.Code).FirstOrDefaultAsync();

                if (exist != null) continue;

                var addDepartmentSerivce = new PatientDeptServiceEntity
                {
                    ServiceCode = item.Code,
                    RoomCode = request.RoomCode,
                    ExaminationCode = request.ExaminationCode,
                    IsActive = true,
                    ObjectType = type.ToString()
                };

                _unitOfWork.GetRepository<PatientDeptServiceEntity>().Add(addDepartmentSerivce);
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateListServiceOfDepartment(UpdatePatientDepartmentServiceModel request,
            Guid departmentServiceId)
        {
            if (request == null || string.IsNullOrEmpty(request.ServiceCode))
                throw new Exception(ErrorMessages.ServiceOfDepartmentEmpty);

            if (request.ObjectType <= 0
                || Enum.IsDefined(typeof(ObjectType), request.ObjectType) == false)
                throw new Exception("Đối tượng bệnh nhân không đúng.");

            var patientDepartmentService = await _unitOfWork.GetRepository<PatientDeptServiceEntity>()
                .FindAsync(x => x.Id == departmentServiceId);

            if (patientDepartmentService == null) throw new Exception("Không tìm thấy thông tin phòng khám dịch vụ");

            var existDepartmentService = await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll()
                .Where(x => x.ExaminationCode == request.ExaminationCode
                            && x.ServiceCode == request.ServiceCode
                            && x.ObjectType == request.ObjectType.ToString()
                            && x.RoomCode == request.RoomCode).FirstOrDefaultAsync();

            if (existDepartmentService != null && existDepartmentService.Id != departmentServiceId)
                throw new Exception("Đã tồn tại phòng khám dịch vụ này");

            patientDepartmentService.ExaminationCode = request.ExaminationCode;
            patientDepartmentService.ObjectType = request.ObjectType.ToString();
            patientDepartmentService.RoomCode = request.RoomCode;
            patientDepartmentService.ServiceCode = request.ServiceCode;

            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Update(patientDepartmentService);
            await _unitOfWork.CommitAsync();
        }

        public async Task<PatientDepartmentServiceJsonViewModel> GetDepartmentServiceById(Guid id)
        {
            var connectionString = _configuration.GetConnectionString(ApplicationDbContext);
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlForGetData = " SELECT ds.id as id, " +
                                    " ds.service_code as ServiceCode, " +
                                    " l.description as ServiceName, " +
                                    " ds.examination_code as ExaminationCode, " +
                                    " d.\"name\" as ExaminationName,  " +
                                    " ds.room_code as RoomCode, " +
                                    " d2.\"name\" as RoomName, " +
                                    " ds.object_type as ObjectType,  " +
                                    " ds.is_active as IsActive " +
                                    " FROM \"Dept\".patient_department_service AS ds " +
                                    " LEFT JOIN \"Dept\".department as d on d.code = ds.examination_code " +
                                    " LEFT JOIN \"Dept\".department as d2 on d2.code = ds.room_code " +
                                    " LEFT JOIN \"ListMgmt\".list_value_extend as l on l.code = ds.service_code " +
                                    $" WHERE ds.id = '{id}'; ";

                var departmentService =
                    await connection.QueryFirstOrDefaultAsync<PatientDepartmentServiceJsonViewModel>(sqlForGetData);

                if (departmentService == null) throw new Exception("Không tìm thấy thông tin phòng khám dịch vụ");

                return departmentService;
            }
        }

        public async Task<PagedResponse<List<PatientDepartmentServiceJsonViewModel>>> GetAll(
            PatientDepartmentServiceRequest request)
        {
            var connectionString = _configuration.GetConnectionString(ApplicationDbContext);
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlCount =
                    "SELECT count(*) " +
                    " FROM \"Dept\".patient_department_service AS ds " +
                    " LEFT JOIN \"Dept\".department as d on d.code = ds.examination_code " +
                    " LEFT JOIN \"Dept\".department as d2 on d2.code = ds.room_code " +
                    " LEFT JOIN \"ListMgmt\".list_value_extend as l on l.code = ds.service_code " +
                    "WHERE 1 = 1 ";

                var sqlForGetData = " SELECT ds.id as id, " +
                                    " ds.service_code as ServiceCode, " +
                                    " l.description as ServiceName, " +
                                    " ds.examination_code as ExaminationCode, " +
                                    " d.\"name\" as ExaminationName,  " +
                                    " ds.room_code as RoomCode, " +
                                    " d2.\"name\" as RoomName, " +
                                    " ds.object_type as ObjectType,  " +
                                    " ds.is_active as IsActive " +
                                    " FROM \"Dept\".patient_department_service AS ds " +
                                    " LEFT JOIN \"Dept\".department as d on d.code = ds.examination_code " +
                                    " LEFT JOIN \"Dept\".department as d2 on d2.code = ds.room_code " +
                                    " LEFT JOIN \"ListMgmt\".list_value_extend as l on l.code = ds.service_code " +
                                    " WHERE 1 = 1 ";

                if (!string.IsNullOrEmpty(request.RoomCode))
                {
                    sqlCount += $"AND ds.room_code like '%{request.RoomCode}%' ";
                    sqlForGetData += $"AND ds.room_code like '%{request.RoomCode}%' ";
                }

                if (!string.IsNullOrEmpty(request.ServiceCode))
                {
                    sqlCount += $"AND ds.service_code like '%{request.ServiceCode}%' ";
                    sqlForGetData += $"AND ds.service_code like '%{request.ServiceCode}%' ";
                }

                if (!string.IsNullOrEmpty(request.ExaminationCode))
                {
                    sqlCount += $"AND ds.examination_code like '%{request.ExaminationCode}%' ";
                    sqlForGetData += $"AND ds.examination_code like '%{request.ExaminationCode}%' ";
                }

                if (!string.IsNullOrEmpty(request.ExaminationCode))
                {
                    sqlCount += $"AND ds.examination_code like '%{request.ExaminationCode}%' ";
                    sqlForGetData += $"AND ds.examination_code like '%{request.ExaminationCode}%' ";
                }

                sqlCount += ";";
                sqlForGetData +=
                    $" ORDER BY ds.created_date DESC OFFSET (({request.PageNumber} - 1) * {request.PageSize}) ROWS " +
                    $"FETCH NEXT {request.PageSize} ROWS ONLY; ";

                var sqlExcute = sqlCount + sqlForGetData;
                var data = new List<PatientDepartmentServiceJsonViewModel>();
                var totalRecord = 0;
                using (var multi = await connection.QueryMultipleAsync(sqlExcute).ConfigureAwait(false))
                {
                    totalRecord = await multi.ReadSingleAsync<int>();
                    data = multi.Read<PatientDepartmentServiceJsonViewModel>().ToList();
                }

                var response =
                    new PagedResponse<List<PatientDepartmentServiceJsonViewModel>>(data, request.PageNumber,
                        request.PageSize);
                response.TotalRecords = totalRecord;
                response.TotalPages = Convert.ToInt32(Math.Ceiling(totalRecord / (double)request.PageSize));

                return response;
            }
        }

        #region Default Service

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Department.</returns>
        public PatientDeptServiceEntity Add(PatientDeptServiceEntity entity)
        {
            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        ///     add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Department.</returns>
        public async Task<PatientDeptServiceEntity> AddAsync(PatientDeptServiceEntity entity)
        {
            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        ///     Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<PatientDeptServiceEntity>().Count();
        }

        /// <summary>
        ///     count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<PatientDeptServiceEntity>().CountAsync();
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(PatientDeptServiceEntity entity)
        {
            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(PatientDeptServiceEntity entity)
        {
            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<PatientDeptServiceEntity>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        ///     Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Department.</returns>
        public PatientDeptServiceEntity Find(Expression<Func<PatientDeptServiceEntity, bool>> match)
        {
            return _unitOfWork.GetRepository<PatientDeptServiceEntity>().Find(match);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public ICollection<PatientDeptServiceEntity> FindAll(Expression<Func<PatientDeptServiceEntity, bool>> match)
        {
            return _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll().Where(match).ToList();
        }

        /// <summary>
        ///     find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public async Task<ICollection<PatientDeptServiceEntity>> FindAllAsync(
            Expression<Func<PatientDeptServiceEntity, bool>> match)
        {
            return await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        ///     find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Department.</returns>
        public async Task<PatientDeptServiceEntity> FindAsync(Expression<Func<PatientDeptServiceEntity, bool>> match)
        {
            return await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public PatientDeptServiceEntity Get(Guid id)
        {
            return _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetById(id);
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public ICollection<PatientDeptServiceEntity> GetAll()
        {
            return _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll().ToList();
        }

        /// <summary>
        ///     get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Department&gt;.</returns>
        public async Task<ICollection<PatientDeptServiceEntity>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAll().ToListAsync();
        }

        /// <summary>
        ///     get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public async Task<PatientDeptServiceEntity> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAsyncById(id);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Department.</returns>
        public PatientDeptServiceEntity Update(PatientDeptServiceEntity entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<PatientDeptServiceEntity>().Update(entity);
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
        public async Task<PatientDeptServiceEntity> UpdateAsync(PatientDeptServiceEntity entity, Guid id)
        {
            if (entity == null)
                return null;

            var existing = await _unitOfWork.GetRepository<PatientDeptServiceEntity>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<PatientDeptServiceEntity>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion
    }
}