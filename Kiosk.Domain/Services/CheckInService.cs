using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.SignalRClient;
using CS.VM.CheckInModel.Dtos;
using CS.VM.CheckInModel.Requests;
using CS.VM.CheckInModel.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Settings;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;
using CS.VM.Responses;
using CS.VM.Requests;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.ICheckInService" />
    public class CheckInService : ICheckInService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The hospital settings
        /// </summary>
        private readonly HospitalSettings _hospitalSettings;
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckInService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public CheckInService(IUnitOfWork unitOfWork,
            IMapper mapper,
            HospitalSettings hospitalSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hospitalSettings = hospitalSettings;
        }

        /// <summary>
        /// Calls the paid table patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<CallTablePatientResponse> CallPaidTablePatient(CallTablePatientRequest request)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            var table = await _unitOfWork.GetRepository<Table>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Table);

            if (table == null)
                throw new Exception(ErrorMessages.NotFoundTable);

            var lastQueueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .Where(queue => queue.DepartmentCode == table.DepartmentCode && queue.AreaCode == table.AreaCode)
                    .Take(request.Limit);

            var type = table.Type;
            CallTablePatientDto callTablePatientDto = null;
            switch (type)
            {
                case PriorityType.Normal:
                    {
                        var tableCallPaidNumberNormals = new List<KBBPaidNormalTable>();
                        for (var i = 0; i < request.Limit; i++)
                        {
                            var tableCallNumberNormal = new KBBPaidNormalTable()
                            {
                                Table = request.Table,
                                Ip = request.Ip
                            };
                            _unitOfWork.GetRepository<KBBPaidNormalTable>().Add(tableCallNumberNormal);
                            tableCallPaidNumberNormals.Add(tableCallNumberNormal);
                        }
                        await _unitOfWork.CommitAsync();
                        callTablePatientDto = new CallTablePatientDto()
                        {
                            Type = (int)type,
                            Table = request.Table,
                            From = tableCallPaidNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                            To = tableCallPaidNumberNormals.LastOrDefault()?.SEQ ?? -1,
                        };

                        break;
                    }
                case PriorityType.Priority:
                    {
                        var tableCallPaidNumberPriorities = new List<KBBPaidPriorityTable>();

                        for (var i = 0; i < request.Limit; i++)
                        {
                            var tableCallNumberNormal = new KBBPaidPriorityTable()
                            {
                                Table = request.Table,
                                Ip = request.Ip
                            };
                            _unitOfWork.GetRepository<KBBPaidPriorityTable>().Add(tableCallNumberNormal);
                            tableCallPaidNumberPriorities.Add(tableCallNumberNormal);
                        }
                        await _unitOfWork.CommitAsync();
                        callTablePatientDto = new CallTablePatientDto()
                        {
                            Type = (int)type,
                            Table = request.Table,
                            From = tableCallPaidNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                            To = tableCallPaidNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                        };
                        break;
                    }
            }

            if (callTablePatientDto == null)
            {
                return null;
            }


            var queueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number =>
                    number.DepartmentCode == "TATTOAN" && !number.IsSelected &&
                    (table.Type == PriorityType.Normal
                    ? number.Type == (int)PriorityType.Normal
                    : number.Type != (int)PriorityType.Normal))
                .OrderBy(number => number.Number).Take(request.Limit)
                .ToList();

            foreach (var number in queueNumber)
            {
                number.IsSelected = true;
                _unitOfWork.GetRepository<QueueNumber>().Update(number);
            }

            await _unitOfWork.CommitAsync();


            if (callTablePatientDto == null)
                throw new Exception(ErrorMessages.NotFoundQueueNumber);

            SignalrService.Instance.SendMessage(
                new SignalrRequest(new Data()
                {
                    title = "CallPaidTablePatient",
                    body = callTablePatientDto
                }, table.DeviceCode)
            );

            return new CallTablePatientResponse
            {
                CallTablePatientDto = callTablePatientDto
            };
        }

        /// <summary>
        /// Calls the patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<GetPatientsInQueueResponse> CallPatient(CallPatientRequest request)
        {
            var room = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Join(_unitOfWork.GetRepository<ListValueType>().GetAll().Where(type => type.Code == "PB"),
                          extend => extend.ListValueTypeId, type => type.Id, (extend, type) => new { extend })
                .Select(arg => arg.extend)
                .Where(extend => extend.Code == request.Room.ToString())
                .SingleOrDefaultAsync();

            if (room == null)
                throw new Exception(ErrorMessages.NotFoundExtendValue);

            var queueNumbersQuery = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == request.Room.ToString());

            var lastTimeCall = queueNumbersQuery.Where(t => t.IsSelected).OrderByDescending(o => o.UpdatedDate).FirstOrDefault();

            if (lastTimeCall != null)
            {
                var seconds = (DateTime.Now - lastTimeCall.UpdatedDate).TotalSeconds;
                if (seconds < _hospitalSettings.Hospital.NextCallTime)
                    throw new Exception(ErrorMessages.InvalidNextCallTime);
            }

            var queueNumbers = queueNumbersQuery.Where(number => !number.IsSelected &&
                    (request.Type == PatientType.Normal
                    ? number.Type == PatientType.Normal
                    : number.Type != PatientType.Normal))
                .OrderBy(number => number.Number).Take(request.Number);


            foreach (var number in queueNumbers)
            {
                number.IsSelected = true;
                number.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<QueueNumber>().Update(number);
            }

            await _unitOfWork.GetRepository<QueueNumber>().SaveChangesAsync();

            var devices = await _unitOfWork.GetRepository<Device>().GetAll().Where(device => device.RoomId == room.Id).ToListAsync();

            devices.ForEach(device =>
            {
                SignalrService.Instance.SendMessage(
                    new SignalrRequest(new Data()
                    {
                        title = "RoomCallPatient",
                        body = request
                    }, device.Ip)
                );
            });

            var queueNumbersDto = queueNumbers.Join(_unitOfWork.GetRepository<Patient>().GetAll(),
                       number => number.PatientId,
                       patient => patient.Id,
                       (number, patient) => new
                       {
                           Name = $"{patient.LastName} {patient.FirstName}",
                           Age = DateTimeUtils.CalculatorAge(patient.Birthday),
                           Number = number.Number,
                           Type = number.Type,
                           Status = number.IsSelected ? EStatus.Called : EStatus.Waiting,
                           Created_Date = number.CreatedDate,
                       }).Select(number => new GetPatientsInQueueDto()
                       {
                           Age = number.Age.ToString(),
                           Name = number.Name,
                           Status = (int)number.Status,
                           Type = number.Type,
                           QueueNumber = number.Number
                       });

            return new GetPatientsInQueueResponse
            {
                GetPatientsInQueueDtos = await queueNumbersDto.ToListAsync()
            };
        }

        /// <summary>
        /// Calls the table patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<CallTablePatientResponse> CallTablePatient(CallTablePatientRequest request)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            var nextTimeValue = 10;

            var nextCallTime = _hospitalSettings.Hospital.NextCallTime;

            string areaCode = _hospitalSettings.Hospital.HospitalArea;

            var getTableByCode = _unitOfWork.GetRepository<Table>().GetAll().Where(x => x.AreaCode == areaCode);

            var table = await getTableByCode.SingleOrDefaultAsync(x => x.Code == request.Table);

            var cps = await getTableByCode.FirstOrDefaultAsync(y => y.DeviceType == TableDeviceType.CPS);

            if (table == null)
                throw new Exception(ErrorMessages.NotFoundTable);

            var lastQueueNumber = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderByDescending(c => c.Number)
                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                            && queue.AreaCode == areaCode).Take(request.Limit);

            var type = table.Type;
            CallTablePatientDto callTablePatientDto = null;
            if (areaCode == "D")
            {
                switch (type)
                {
                    case PriorityType.Normal:
                        {
                            var tableCallNumberNormals = new List<KBANormalTable>();

                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBANormalTable()
                                {
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBANormalTable>().Add(tableCallNumberNormal);
                                tableCallNumberNormals.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();


                            callTablePatientDto = new CallTablePatientDto()
                            {
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                                To = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                            };

                            break;
                        }
                    case PriorityType.Priority:
                        {
                            var tableCallNumberPriorities = new List<KBAPriorityTable>();
                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBAPriorityTable()
                                {
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBAPriorityTable>().Add(tableCallNumberNormal);
                                tableCallNumberPriorities.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();

                            callTablePatientDto = new CallTablePatientDto()
                            {
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                                To = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                            };
                            break;
                        }
                }
            }
            else
            {
                switch (type)
                {
                    case PriorityType.Normal:
                        {
                            var lastTimeCall = _unitOfWork.GetRepository<KBBNormalTable>().GetAll().Where(t => t.Table == request.Table)
                                .OrderByDescending(o => o.CreatedDate).FirstOrDefault();

                            if (lastTimeCall != null && lastTimeCall.CreatedDate.HasValue)
                            {
                                var seconds = (DateTime.Now - lastTimeCall.CreatedDate.Value).TotalSeconds;
                                if (seconds < nextTimeValue)
                                {
                                    throw new Exception(ErrorMessages.InvalidNextCallTime);
                                }
                            }

                            var tableCallNumberNormals = new List<KBBNormalTable>();

                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBBNormalTable()
                                {
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBBNormalTable>().Add(tableCallNumberNormal);
                                tableCallNumberNormals.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();

                            callTablePatientDto = new CallTablePatientDto()
                            {
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                                To = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                            };

                            break;
                        }
                    case PriorityType.Priority:
                        {
                            var lastTimeCall = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll().Where(t => t.Table == request.Table)
                                .OrderByDescending(o => o.CreatedDate).FirstOrDefault();

                            if (lastTimeCall != null && lastTimeCall.CreatedDate.HasValue)
                            {
                                var seconds = (DateTime.Now - lastTimeCall.CreatedDate.Value).TotalSeconds;
                                if (seconds < nextTimeValue)
                                {
                                    throw new Exception(ErrorMessages.InvalidNextCallTime);
                                }
                            }

                            var tableCallNumberPriorities = new List<KBBPriorityTable>();

                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBBPriorityTable()
                                {
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBBPriorityTable>().Add(tableCallNumberNormal);
                                tableCallNumberPriorities.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();

                            callTablePatientDto = new CallTablePatientDto()
                            {
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                                To = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                            };
                            break;
                        }
                }
            }

            if (callTablePatientDto == null)
                throw new Exception(ErrorMessages.NotFoundQueueNumber);

            SignalrService.Instance.SendMessage(
                new SignalrRequest(new Data()
                {
                    title = "CallTablePatient",
                    body = callTablePatientDto
                }, table.DeviceCode)
            );
            SignalrService.Instance.SendMessage(
                new SignalrRequest(new Data()
                {
                    title = "CallTablePatient",
                    body = callTablePatientDto
                }, cps.DeviceCode)
            );

            return new CallTablePatientResponse
            {
                CallTablePatientDto = callTablePatientDto
            };
        }

        /// <summary>
        /// Changes the type of the table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ChangeTableTypeResponse> ChangeTableType(ChangeTableTypeRequest request)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            string areaCode = _hospitalSettings.Hospital.HospitalArea;

            var getTableByAreaCode = _unitOfWork.GetRepository<Table>().GetAll().Where(x => x.AreaCode == areaCode);

            var table = await getTableByAreaCode.SingleOrDefaultAsync(x => x.Code == request.Table);
            var cps = await getTableByAreaCode.FirstOrDefaultAsync(y => y.DeviceType == TableDeviceType.CPS);

            if (table == null)
                throw new Exception(ErrorMessages.NotFoundTable);

            table.Type = (PriorityType)request.Type;

            _unitOfWork.GetRepository<Table>().Update(table);
            await _unitOfWork.GetRepository<Table>().SaveChangesAsync();

            var changeTableTypeDto = new ChangeTableTypeDto
            {
                Table = table.Code,
                Type = (int)table.Type
            };

            SignalrService.Instance.SendMessage(
                new SignalrRequest(new Data()
                {
                    title = "ChangeTableType",
                    body = changeTableTypeDto
                }, table.DeviceCode)
            );

            SignalrService.Instance.SendMessage(
                new SignalrRequest(new Data()
                {
                    title = "ChangeTableType",
                    body = changeTableTypeDto
                }, cps.DeviceCode)
            );

            return new ChangeTableTypeResponse
            {
                ChangeTableTypeDto = changeTableTypeDto
            };
        }

        /// <summary>
        /// Gets all table queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetAllTableQueueResponse> GetAllTableQueue(GetAllTableQueueRequest request)
        {
            string areaCode = _hospitalSettings.Hospital.HospitalArea;
            var tables = await _unitOfWork.GetRepository<Table>().GetAll()
                .Where(t => t.AreaCode == areaCode && t.DepartmentCode == request.DepartmentCode && t.IsActive && !t.IsDeleted).OrderBy(x => x.Code).ToListAsync();

            var response = new GetAllTableQueueResponse
            {
                GetAllTableQueueDto = new GetAllTableQueueDto()
            };

            var tableCallNumbers = _unitOfWork.GetRepository<Table>().GetAll().OrderByDescending(tb => tb.AreaCode == "");

            foreach (var table in tables)
            {
                if (table.Type == PriorityType.Normal)
                {
                    if (areaCode == "D")
                    {
                        var tableCallNumberNormals = _unitOfWork.GetRepository<KBANormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(request.Limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            Type = (int)table.Type,
                            To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                            From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                    else
                    {
                        var tableCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(request.Limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            Type = (int)table.Type,
                            To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                            From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                }
                if (table.Type == PriorityType.Priority)
                {
                    if (areaCode == "D")
                    {
                        var tableCallNumberPriorities = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(request.Limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            Type = (int)table.Type,
                            To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                            From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                    else
                    {
                        var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(request.Limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            Type = (int)table.Type,
                            To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                            From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Gets all table queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetAllTableQueueResponse> GetAllTableQueue_V02(GetAllTableQueueRequest_V02 request)
        {
            var tables = await _unitOfWork.GetRepository<Table>().GetAll()
                .Where(t => t.AreaCode == request.AreaCode && t.DepartmentCode == request.DepartmentCode && t.IsActive && !t.IsDeleted)
                .OrderBy(x => x.Code)
                .ToListAsync();

            var response = new GetAllTableQueueResponse
            {
                GetAllTableQueueDto = new GetAllTableQueueDto()
            };

            foreach (var table in tables)
            {
                if (table.Type == PriorityType.Normal)
                {
                    var tableCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == request.AreaCode)
                        .OrderByDescending(normal => normal.SEQ)
                        .Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueItemDto()
                    {
                        Type = (int)table.Type,
                        To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                        From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                        Table = table,
                    };
                    response.GetAllTableQueueDto.Result.Add(callTablePatientDto);

                }
                if (table.Type == PriorityType.Priority)
                {
                    var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == request.AreaCode )
                        .OrderByDescending(priority => priority.SEQ)
                        .Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueItemDto()
                    {
                        Type = (int)table.Type,
                        To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                        From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                        Table = table,
                    };
                    response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                }
            }
            return response;
        }

        /// <summary>
        /// Gets the patients in queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientsInQueueResponse> GetPatientsInQueue(GetPatientsInQueueRequest request)
        {
            var isCalled = request.Status == (int)EStatus.Called;

            var latestCalledQuery = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(number => number.DepartmentCode == request.Room && number.IsSelected);

            if (request.Type.HasValue)
                latestCalledQuery = request.Type == PatientType.Normal
                    ? latestCalledQuery.Where(number => number.Type == PatientType.Normal)
                    : latestCalledQuery.Where(number => number.Type != PatientType.Normal);


            var latestCalled = latestCalledQuery.OrderByDescending(number => number.Number).Take(1)
                .SingleOrDefault()?.Number ?? 0;

            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(number => number.DepartmentCode == request.Room && number.IsSelected == isCalled);

            if (request.Type.HasValue)
                queueNumbers = request.Type == PatientType.Normal
                    ? queueNumbers.Where(number => number.Type == PatientType.Normal)
                    : queueNumbers.Where(number => number.Type != PatientType.Normal);

            if (isCalled)
                queueNumbers = queueNumbers.OrderByDescending(dto => dto.Number);
            else
                queueNumbers = queueNumbers.Where(number => number.Number > latestCalled)
                    .OrderBy(dto => dto.Number);

            var patients = _unitOfWork.GetRepository<Patient>().GetAll();

            var queueNumbersDto = queueNumbers.Join(patients,
                        number => number.PatientId,
                        patient => patient.Id,
                        (number, patient) => new
                        {
                            Name = $"{patient.LastName} {patient.FirstName}",
                            Age = DateTimeUtils.CalculatorAge(patient.Birthday),
                            Number = number.Number,
                            Type = number.Type,
                            Status = number.IsSelected ? EStatus.Called : EStatus.Waiting,
                            Created_Date = number.CreatedDate,
                        })
                        .Select(number => new GetPatientsInQueueDto()
                        {
                            Age = number.Age.ToString(),
                            Name = number.Name,
                            Status = (int)number.Status,
                            Type = number.Type,
                            QueueNumber = number.Number
                        });

            var getPatientsInQueueDtos = await queueNumbersDto.Take(request.Limit).ToListAsync();

            return new GetPatientsInQueueResponse()
            {
                GetPatientsInQueueDtos = getPatientsInQueueDtos
            };
        }

        /// <summary>
        /// Gets the table paid queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetTableQueueResponse> GetTablePaidQueue(GetTableQueueRequest request)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            string areaCode = _hospitalSettings.Hospital.HospitalArea;
            var table = await _unitOfWork.GetRepository<Table>().GetAll().FirstOrDefaultAsync(x => x.Code == request.Table);

            if (table == null)
            {
                return new GetTableQueueResponse
                {
                    GetTableQueueDto = new GetTableQueueDto
                    {
                        Type = -1,
                        From = -1,
                        To = -1
                    }
                };
            }
            return await GetTableQueueByPriority(table, areaCode, request.Limit);
        }

        /// <summary>
        /// Gets the table queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetTableQueueResponse> GetTableQueue(GetTableQueueRequest request)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            string areaCode = _hospitalSettings.Hospital.HospitalArea;
            var table = await _unitOfWork.GetRepository<Table>().GetAll().SingleOrDefaultAsync(t => t.Code == request.Table && t.AreaCode == areaCode && t.IsActive && !t.IsDeleted);

            if (table == null)
                return new GetTableQueueResponse
                {
                    GetTableQueueDto = new GetTableQueueDto
                    {
                        Type = -1,
                        From = -1,
                        To = -1
                    }

                };

            if (table.Type == PriorityType.Normal)
            {
                if (areaCode == "D")
                {
                    var tableCallNumberNormals = _unitOfWork.GetRepository<KBANormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        Type = (int)table.Type,
                        To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                        From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
                else
                {
                    var tableCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        Type = (int)table.Type,
                        To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? -1,
                        From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? -1,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
            }
            if (table.Type == PriorityType.Priority)
            {
                if (areaCode == "D")
                {
                    var tableCallNumberPriorities = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        Type = (int)table.Type,
                        To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                        From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
                else
                {
                    var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        Type = (int)table.Type,
                        To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? -1,
                        From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? -1,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
            }

            return new GetTableQueueResponse()
            {
                GetTableQueueDto = new GetTableQueueDto()
                {
                    Type = -1,
                    From = -1,
                    To = -1
                }
            };
        }

        /// <summary>
        /// Tables the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Bệnh nhân chưa được gọi vào bàn. đang gọi số {latestCall ?? -1}. Số thứ tự của bệnh nhân: {queueNumber.Number}
        /// </exception>
        public async Task<TableCheckInResponse> TableCheckIn(TableCheckInRequest request)
        {
            if (!string.IsNullOrEmpty(request.Table)
                && request.Table.Length == 1)
            {
                request.Table = $"0{request.Table}";
            }

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Patient);
            var tempPatient = await _unitOfWork.GetRepository<TempPatient>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Patient);

            if (patient == null && tempPatient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }
            else
            {
                if (patient == null)
                {
                    patient = _mapper.Map(tempPatient, patient);
                }
            }

            string areaCode = _hospitalSettings.Hospital.HospitalArea;

            var queueNumberList = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number =>
                          number.PatientId == patient.Id
                          && number.DepartmentCode == Departments.TNB
                          && number.AreaCode == areaCode)
                     .OrderByDescending(number => number.Number).ToList();

            var table = await _unitOfWork.GetRepository<Table>().GetAll().FirstOrDefaultAsync(t => t.Code == request.Table
                 && t.AreaCode == areaCode);

            if (table == null)
                throw new Exception(ErrorMessages.TableNotExist);

            if (queueNumberList.Count == 0)
                throw new Exception(ErrorMessages.PatientHasNotTakenNumber);

            var queueNumber = queueNumberList.FirstOrDefault(item => item.Type > 0);

            if (queueNumber == null)
                queueNumber = queueNumberList.OrderByDescending(o => o.CreatedDate).FirstOrDefault();

            if (queueNumber == null)
                throw new Exception(ErrorMessages.PatientHasNotTakenNumber);

            if (queueNumber.IsSelected)
                throw new Exception(ErrorMessages.PatientHasBeenCalledIntoTheRoom);

            var type = table.Type;
            TableCallNumber queue = null;
            int? latestCall = null;
            if (queueNumber.Type == PatientType.Normal)
            {
                if ((int)queueNumber.Type != (int)table.Type)
                    throw new Exception(ErrorMessages.TableTypeIncorrect);

                if (areaCode == "D")
                {
                    queue = _unitOfWork.GetRepository<KBANormalTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                    latestCall = _unitOfWork.GetRepository<KBANormalTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                }
                else
                {
                    queue = _unitOfWork.GetRepository<KBBNormalTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                    latestCall = _unitOfWork.GetRepository<KBBNormalTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                }
            }
            else
            {
                if (areaCode == "D")
                {
                    queue = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                    latestCall = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                }
                else
                {
                    queue = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll().SingleOrDefault(normal => normal.SEQ == queueNumber.Number && normal.AreaCode == areaCode);
                    latestCall = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll().Where(normal => normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Select(priority => priority.SEQ).Take(1).SingleOrDefault();
                }

            }

            if (queue == null)
            {
                throw new Exception($"Bệnh nhân chưa được gọi vào bàn. đang gọi số {latestCall ?? -1}. Số thứ tự của bệnh nhân: {queueNumber.Number} ");
            }

            return new TableCheckInResponse
            {
                TableCheckInDto = _mapper.Map<TableCheckInDto>(patient)
            };
        }


        /// <summary>
        /// Gets the patient clinic result.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientsLastQueueClinicResultResponse> GetPatientClinicResult(GetPatientsInQueueRequest request)
        {
            request.Room = $"{Departments.ClinicResult}{request.Room}";
            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                              .Where(number => number.DepartmentCode == request.Room && DateTime.Compare(number.CreatedDate.Date, request.Date.Date) == 0)
                                     .OrderBy(number => number.Number);

            var inQueuePatients = await queueNumbers.Where(number => !number.IsSelected).Take(request.Limit).ToListAsync();
            var lastQueuePatients = await queueNumbers.Where(number => number.IsSelected).ToListAsync();
            var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number).Take(1).SingleOrDefault()?.Number ?? 0;

            return new GetPatientsLastQueueClinicResultResponse
            {
                CurrentNumber = currentQueueNumber,
                InQueuePatients = _mapper.Map<List<GetPatientsInQueueDto>>(inQueuePatients),
                LastQueuePatients = _mapper.Map<List<GetPatientsInQueueDto>>(lastQueuePatients)
            };
        }

        /// <summary>
        /// Calls the patient result clinic.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<bool> CallPatientClinicResult(CallPatientClinicResultRequest request)
        {
            request.Room = $"{Departments.ClinicResult}{request.Room}";
            var room = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
               .Join(_unitOfWork.GetRepository<ListValueType>().GetAll().Where(type => type.Code == ValueTypeCode.DepartmentCode),
                         extend => extend.ListValueTypeId, type => type.Id, (extend, type) => new { extend })
               .Select(arg => arg.extend)
               .Where(extend => extend.Code == request.Room)
               .SingleOrDefaultAsync();

            if (room == null)
                throw new Exception(ErrorMessages.NotFoundExtendValue);

            var queueNumbersQuery = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == request.Room);

            var lastTimeCall = queueNumbersQuery.Where(t => t.IsSelected).OrderByDescending(o => o.UpdatedDate).FirstOrDefault();

            if (lastTimeCall != null)
            {
                var seconds = (DateTime.Now - lastTimeCall.UpdatedDate).TotalSeconds;
                if (seconds < _hospitalSettings.Hospital.NextCallTime)
                    throw new Exception(ErrorMessages.InvalidNextCallTime);
            }

            var queueNumbers = queueNumbersQuery.Where(number => !number.IsSelected)
                .OrderBy(number => number.Number).Take(request.Number);

            foreach (var number in queueNumbers)
            {
                number.IsSelected = true;
                number.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<QueueNumber>().Update(number);
            }

            await _unitOfWork.CommitAsync();

            var devices = await _unitOfWork.GetRepository<Device>().GetAll().Where(device => device.RoomId == room.Id).ToListAsync();

            devices.ForEach(device =>
            {
                SignalrService.Instance.SendMessage(
                    new SignalrRequest(new Data()
                    {
                        title = "RoomCallPatient",
                        body = request
                    }, device.Ip)
                );
            });
            return true;
        }

        /// <summary>
        /// Gets the patient in and last queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientsInAndLastQueueResponse> GetPatientInAndLastQueue(GetPatientsInQueueRequest request)
        {
            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == request.Room).OrderBy(number => number.Number);

            var inQueuePatientsNormal = queueNumbers.Where(number => number.Type == PatientType.Normal && !number.IsSelected);
            var inQueuePatientsPriority = queueNumbers.Where(number => number.Type != PatientType.Normal && !number.IsSelected);
            var lastQueueNumbersCall = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.UpdatedDate);
            var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number);

            var patients = _unitOfWork.GetRepository<Patient>().GetAll();

            return new GetPatientsInAndLastQueueResponse
            {
                Patients = new GetPatientsInAndLastQueueDto
                {
                    NormalPatients = await inQueuePatientsNormal.Join(_unitOfWork.GetRepository<Patient>().GetAll(),
                       number => number.PatientId,
                       patient => patient.Id,
                       (number, patient) => new
                       {
                           Name = $"{patient.LastName} {patient.FirstName}",
                           Age = DateTimeUtils.CalculatorAge(patient.Birthday),
                           Number = number.Number,
                           Type = number.Type,
                           Status = number.IsSelected ? EStatus.Called : EStatus.Waiting,
                           Created_Date = number.CreatedDate,
                       }).Select(number => new GetPatientsInQueueDto()
                       {
                           Age = number.Age.ToString(),
                           Name = number.Name,
                           Status = (int)number.Status,
                           Type = number.Type,
                           QueueNumber = number.Number
                       }).Take(request.Limit).ToListAsync(),
                    PriorityPatients = await inQueuePatientsPriority.Join(_unitOfWork.GetRepository<Patient>().GetAll(),
                       number => number.PatientId,
                       patient => patient.Id,
                       (number, patient) => new
                       {
                           Name = $"{patient.LastName} {patient.FirstName}",
                           Age = DateTimeUtils.CalculatorAge(patient.Birthday),
                           Number = number.Number,
                           Type = number.Type,
                           Status = number.IsSelected ? EStatus.Called : EStatus.Waiting,
                           Created_Date = number.CreatedDate,
                       }).Select(number => new GetPatientsInQueueDto()
                       {
                           Age = number.Age.ToString(),
                           Name = number.Name,
                           Status = (int)number.Status,
                           Type = number.Type,
                           QueueNumber = number.Number
                       }).Take(request.Limit).ToListAsync(),
                    LastPatients = await lastQueueNumbersCall.Join(_unitOfWork.GetRepository<Patient>().GetAll(),
                       number => number.PatientId,
                       patient => patient.Id,
                       (number, patient) => new
                       {
                           Name = $"{patient.LastName} {patient.FirstName}",
                           Age = DateTimeUtils.CalculatorAge(patient.Birthday),
                           Number = number.Number,
                           Type = number.Type,
                           Status = number.IsSelected ? EStatus.Called : EStatus.Waiting,
                           Created_Date = number.CreatedDate,
                       }).Select(number => new GetPatientsInQueueDto()
                       {
                           Age = number.Age.ToString(),
                           Name = number.Name,
                           Status = (int)number.Status,
                           Type = number.Type,
                           QueueNumber = number.Number
                       }).ToListAsync(),
                    NormalNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                    PriorityNumber = currentQueueNumber.Where(x => x.Type != PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0
                }
            };
        }

        /// <summary>
        /// Gets the by token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<Guid> GetByToken(string token)
        {
            return await _unitOfWork.GetRepository<SysUser>().GetAll().Where(x => x.Token == token).Select(x => x.Id).FirstOrDefaultAsync();
        }

        #region Private Functions
        private async Task<GetTableQueueResponse> GetTableQueueByPriority(Table table, string areaCode, int limit)
        {
            var tableCallNumbers = await _unitOfWork.GetRepository<TableCallNumber>().GetAll()
                .Where(tb => tb.Table == table.Code && table.AreaCode == areaCode)// && tb. == table.Type)
                .OrderByDescending(normal => normal.SEQ).Take(limit)
                .ToListAsync();

            var callTablePatientDto = new GetTableQueueDto
            {
                Type = (int)table.Type,
                To = tableCallNumbers.FirstOrDefault()?.SEQ ?? -1,
                From = tableCallNumbers.LastOrDefault()?.SEQ ?? -1,
            };

            if (callTablePatientDto != null)
                return new GetTableQueueResponse
                {
                    GetTableQueueDto = callTablePatientDto
                };
            else
                return new GetTableQueueResponse
                {
                    GetTableQueueDto = new GetTableQueueDto
                    {
                        Type = -1,
                        From = -1,
                        To = -1
                    }
                };
        }

        public Task<GetPatientsLastQueueResponse> GetPatientInAndLastQueueV2(GetPatientsInQueueV2Request request, string webRoot = "")
        {
            throw new NotImplementedException();
        }

        public Task<GetPatientsLastQueueResponse> GetPatientInAndLastQueue(GetPatientsInQueueV2Request request, string webRoot = "")
        {
            throw new NotImplementedException();
        }

        public Task<GetAllTableQueueResponse> GetAllEyeTableQueue(GetAllTableQueueRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CallTablePatientResponse> CallEyeTablePatient(CallTablePatientRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<QueueItem>> GetMultiQueueByDepartment(List<QueueItemRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task<GetPatientsLastQueueClinicResultResponse> GetPatientMedicineResult(GetPatientsInQueueRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterQueueNumberResponse> ChangeRoomEndoscopic(ChangeRoomRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<QueueItem>> GetMultiQueueByDepartmentEndoscopic(List<QueueItemRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task<GetPatientsInQueueResponse> CallPatientVirtual(CallPatientGroupRequest request, string urlAudio)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllTableQueueResponse> GetCPS(GetAllTableQueueRequest request)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
