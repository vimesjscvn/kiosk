using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.SignalRClient;
using CS.VM.CheckInModel.Dtos;
using CS.VM.CheckInModel.Requests;
using CS.VM.CheckInModel.Responses;
using CS.VM.Models;
using CS.VM.PostModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Domain.BusinessObjects;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
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
        /// The order number service
        /// </summary>
        private readonly IOrderNumberService _orderNumberService;
        private readonly IHospitalSystemService _hospitalSystemService;
        private readonly IPatientService _patientService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IAudioService _audio;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckInService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public CheckInService(IUnitOfWork unitOfWork,
            IOrderNumberService orderNumberService,
            IHospitalSystemService hospitalSystemService,
            IPatientService patientService,
            IMapper mapper,
            HospitalSettings hospitalSettings,
            IAudioService audio)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hospitalSettings = hospitalSettings;
            _orderNumberService = orderNumberService;
            _audio = audio;
            _hospitalSystemService = hospitalSystemService;
            _patientService = patientService;
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
                            From = tableCallPaidNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            To = tableCallPaidNumberNormals.LastOrDefault()?.SEQ ?? 0,
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
                            From = tableCallPaidNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                            To = tableCallPaidNumberPriorities.LastOrDefault()?.SEQ ?? 0,
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
            if (!string.IsNullOrEmpty(request.DepartmentCode))
            {
                return await CallPatientByDepartmentCode(request);
            }

            var room = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                .Join(_unitOfWork.GetRepository<ListValueType>().GetAll().Where(type => type.Code == "PB"),
                          extend => extend.ListValueTypeId, type => type.Id, (extend, type) => new { extend })
                .Select(arg => arg.extend)
                .Where(extend => extend.Id == request.Room)
                .FirstOrDefaultAsync();

            if (room == null)
                throw new Exception(ErrorMessages.NotFoundExtendValue);

            var queueNumbersQuery = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentExtendId == room.Id);

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

            return new GetPatientsInQueueResponse()
            {
                GetPatientsInQueueDtos = new List<GetPatientsInQueueDto>()
            };
        }

        private async Task<GetPatientsInQueueResponse> CallPatientByDepartmentCode(CallPatientRequest request)
        {
            var queueNumbersQuery = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentCode == request.DepartmentCode);
            var queueNumbers = queueNumbersQuery.Where(number => !number.IsSelected &&
                    (request.Type == PatientType.Normal
                    ? number.Type == PatientType.Normal
                    : number.Type != PatientType.Normal))
                .OrderBy(number => number.Number).Take(request.Number);

            var dtos = new List<GetPatientsInQueueDto>();
            foreach (var number in queueNumbers)
            {
                number.IsSelected = true;
                number.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<QueueNumber>().Update(number);

                var dto = new GetPatientsInQueueDto()
                {
                    PatientId = number.PatientId,
                    Type = number.Type,
                    QueueNumber = number.Number,
                };

                dtos.Add(dto);
            }

            await _unitOfWork.CommitAsync();

            return new GetPatientsInQueueResponse()
            {
                GetPatientsInQueueDtos = dtos
            };
        }


        public async Task<CallTablePatientResponse> CallTablePatient(CallTablePatientRequest request)
        {
            if (request.Limit > _hospitalSettings.Hospital.MaxLimitNumberOfCallingPatient)
            {
                throw new Exception(ErrorMessages.LimitNumberOfCallingPatient);
            }

            var nextTimeValue = _hospitalSettings.Hospital.NextCallTime;

            var table = await _unitOfWork.GetRepository<Table>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Table);

            if (table == null)
            {
                throw new Exception(ErrorMessages.NotFoundTable);
            }

            if (request.Type.HasValue)
            {
                table.Type = request.Type.Value == CallOrderNumberPriorityType.Priority ? PriorityType.Priority : PriorityType.Normal;
                _unitOfWork.GetRepository<Table>().Update(table);
                await _unitOfWork.CommitAsync();
            }

            if (table.DepartmentCode == Departments.TATTOAN)
            {
                CallTablePatientDto callTablePatientDto = await CallTATTOAN(request, nextTimeValue, table);

                if (callTablePatientDto == null)
                {
                    throw new Exception(ErrorMessages.NotFoundQueueNumber);
                }

                callTablePatientDto.DepartmentCode = table.DepartmentCode;
                return new CallTablePatientResponse
                {
                    CallTablePatientDto = callTablePatientDto
                };
            }
            else
            {
                CallTablePatientDto callTablePatientDto = await CallTNB(request, nextTimeValue, table);

                if (callTablePatientDto == null)
                {
                    throw new Exception(ErrorMessages.NotFoundQueueNumber);
                }

                callTablePatientDto.DepartmentCode = table.DepartmentCode;
                return new CallTablePatientResponse
                {
                    CallTablePatientDto = callTablePatientDto
                };
            }
        }

        private async Task<CallTablePatientDto> CallTNB(CallTablePatientRequest request, int nextTimeValue, Table table)
        {
            table.Limit = request.Limit;
            _unitOfWork.GetRepository<Table>().Update(table);
            await _unitOfWork.CommitAsync();

            string areaCode = request.AreaCode ?? table.AreaCode;

            var getTableByCode = _unitOfWork.GetRepository<Table>().GetAll().Where(x => x.AreaCode == areaCode);

            var type = table.Type;
            if (request.Type.HasValue)
            {
                switch (request.Type.Value)
                {
                    case CallOrderNumberPriorityType.Normal:
                        type = PriorityType.Normal;
                        break;
                    case CallOrderNumberPriorityType.Priority:
                        type = PriorityType.Priority;
                        break;
                    default:
                        break;
                }
            }

            var waitingCount = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderBy(c => c.Number)
                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                    && queue.AreaCode == areaCode
                    && !queue.IsSelected
                    && (type == PriorityType.Priority
                    ? queue.Type != PatientType.Normal
                    : queue.Type == PatientType.Normal)).Take(request.Limit).Count();

            if (waitingCount == 0)
            {
                throw new Exception(ErrorMessages.EmptyWaitingList);
            }

            if (waitingCount < request.Limit)
            {
                request.Limit = waitingCount;
            }

            CallTablePatientDto result = null;
            if (areaCode == AreaCode.KBA)
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
                                    DepartmentCode = table.DepartmentCode,
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
                            var orderNumbers = tableCallNumberNormals.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var tempCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TNB)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                tempCode = _unitOfWork.GetRepository<TempPatient>().GetById(number.PatientId)?.Code;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                TempCode = tempCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
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
                                    DepartmentCode = table.DepartmentCode,
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
                            var orderNumbers = tableCallNumberPriorities.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var tempCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TNB)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                tempCode = _unitOfWork.GetRepository<TempPatient>().GetById(number.PatientId)?.Code;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                TempCode = tempCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
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
                                    DepartmentCode = table.DepartmentCode,
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
                            var orderNumbers = tableCallNumberNormals.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var tempCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TNB)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                tempCode = _unitOfWork.GetRepository<TempPatient>().GetById(number.PatientId)?.Code;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                TempCode = tempCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
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
                                    DepartmentCode = table.DepartmentCode,
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
                            var orderNumbers = tableCallNumberPriorities.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var tempCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TNB)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                tempCode = _unitOfWork.GetRepository<TempPatient>().GetById(number.PatientId)?.Code;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                TempCode = tempCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                            };
                            break;
                        }
                }
            }

            return result;
        }

        private async Task<CallTablePatientDto> CallTATTOAN(CallTablePatientRequest request, int nextTimeValue, Table table)
        {
            table.Limit = request.Limit;
            _unitOfWork.GetRepository<Table>().Update(table);
            await _unitOfWork.CommitAsync();

            string areaCode = request.AreaCode ?? table.AreaCode;

            var getTableByCode = _unitOfWork.GetRepository<Table>().GetAll().Where(x => x.AreaCode == areaCode);

            var type = table.Type;
            if (request.Type.HasValue)
            {
                switch (request.Type.Value)
                {
                    case CallOrderNumberPriorityType.Normal:
                        type = PriorityType.Normal;
                        break;
                    case CallOrderNumberPriorityType.Priority:
                        type = PriorityType.Priority;
                        break;
                    default:
                        break;
                }
            }

            var waitingCount = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .OrderBy(c => c.Number)
                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                    && queue.AreaCode == areaCode
                    && !queue.IsSelected
                    && (type == PriorityType.Priority
                    ? queue.Type != PatientType.Normal
                    : queue.Type == PatientType.Normal)).Take(request.Limit).Count();

            if (waitingCount == 0)
            {
                throw new Exception(ErrorMessages.EmptyWaitingList);
            }


            if (waitingCount < request.Limit)
            {
                request.Limit = waitingCount;
            }

            CallTablePatientDto result = null;
            if (areaCode == AreaCode.KBA)
            {
                switch (type)
                {
                    case PriorityType.Normal:
                        {
                            var tableCallNumberNormals = new List<KBAPaidNormalTable>();

                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBAPaidNormalTable()
                                {
                                    DepartmentCode = table.DepartmentCode,
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBAPaidNormalTable>().Add(tableCallNumberNormal);
                                tableCallNumberNormals.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();
                            var orderNumbers = tableCallNumberNormals.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var registeredCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TATTOAN)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                registeredCode = number?.RegisteredCode;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                RegisteredCode = registeredCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            };

                            break;
                        }
                    case PriorityType.Priority:
                        {
                            var tableCallNumberPriorities = new List<KBAPaidPriorityTable>();
                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBAPaidPriorityTable()
                                {
                                    DepartmentCode = table.DepartmentCode,
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBAPaidPriorityTable>().Add(tableCallNumberNormal);
                                tableCallNumberPriorities.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();
                            var orderNumbers = tableCallNumberPriorities.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var registeredCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TATTOAN)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                registeredCode = number?.RegisteredCode;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                RegisteredCode = registeredCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
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
                            var lastTimeCall = _unitOfWork.GetRepository<KBBPaidNormalTable>().GetAll().Where(t => t.Table == request.Table)
                                .OrderByDescending(o => o.CreatedDate).FirstOrDefault();

                            if (lastTimeCall != null && lastTimeCall.CreatedDate.HasValue)
                            {
                                var seconds = (DateTime.Now - lastTimeCall.CreatedDate.Value).TotalSeconds;
                                if (seconds < nextTimeValue)
                                {
                                    throw new Exception(ErrorMessages.InvalidNextCallTime);
                                }
                            }

                            var tableCallNumberNormals = new List<KBBPaidNormalTable>();

                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBBPaidNormalTable()
                                {
                                    DepartmentCode = table.DepartmentCode,
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBBPaidNormalTable>().Add(tableCallNumberNormal);
                                tableCallNumberNormals.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();
                            var orderNumbers = tableCallNumberNormals.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var registeredCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TATTOAN)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                registeredCode = number?.RegisteredCode;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                RegisteredCode = registeredCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            };

                            break;
                        }
                    case PriorityType.Priority:
                        {
                            var lastTimeCall = _unitOfWork.GetRepository<KBBPaidPriorityTable>().GetAll().Where(t => t.Table == request.Table)
                                .OrderByDescending(o => o.CreatedDate).FirstOrDefault();

                            if (lastTimeCall != null && lastTimeCall.CreatedDate.HasValue)
                            {
                                var seconds = (DateTime.Now - lastTimeCall.CreatedDate.Value).TotalSeconds;
                                if (seconds < nextTimeValue)
                                {
                                    throw new Exception(ErrorMessages.InvalidNextCallTime);
                                }
                            }

                            var tableCallNumberPriorities = new List<KBBPaidPriorityTable>();

                            for (var i = 0; i < request.Limit; i++)
                            {
                                var tableCallNumberNormal = new KBBPaidPriorityTable()
                                {
                                    DepartmentCode = table.DepartmentCode,
                                    Table = request.Table,
                                    AreaCode = areaCode,
                                    Ip = request.Ip,
                                    CreatedBy = request.UserId,
                                    CreatedDate = DateTime.Now
                                };
                                _unitOfWork.GetRepository<KBBPaidPriorityTable>().Add(tableCallNumberNormal);
                                tableCallNumberPriorities.Add(tableCallNumberNormal);
                            }

                            await _unitOfWork.CommitAsync();
                            var orderNumbers = tableCallNumberPriorities.Select(s => s.SEQ);
                            var numberList = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderBy(c => c.Number)
                                    .Where(queue => queue.DepartmentCode == table.DepartmentCode
                                    && queue.AreaCode == areaCode
                                    && orderNumbers.Any(o => o == queue.Number)
                                    && (type == PriorityType.Priority
                                    ? queue.Type != PatientType.Normal
                                    : queue.Type == PatientType.Normal)).Take(request.Limit);

                            var registeredCode = string.Empty;
                            if (numberList != null && numberList.Count() > 0 && table.DepartmentCode == Departments.TATTOAN)
                            {
                                foreach (var numberItem in numberList)
                                {
                                    numberItem.IsSelected = true;
                                    _unitOfWork.GetRepository<QueueNumber>().Update(numberItem);
                                }

                                await _unitOfWork.CommitAsync();
                                var number = await numberList.FirstOrDefaultAsync();
                                registeredCode = number?.RegisteredCode;
                            }

                            result = new CallTablePatientDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                RegisteredCode = registeredCode,
                                Type = (int)type,
                                Table = request.Table,
                                From = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                                To = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                            };
                            break;
                        }
                }
            }

            return result;
        }

        /// <summary>
        /// Changes the type of the table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CS.VM.CheckInModel.Responses.ChangeTableTypeResponse> ChangeTableType(CS.VM.CheckInModel.Requests.ChangeTableTypeRequest request)
        {
            var table = await _unitOfWork.GetRepository<Table>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Table);

            if (table == null)
            {
                throw new Exception(ErrorMessages.NotFoundTable);
            }

            table.Type = request.Type == PriorityType.Priority ? PriorityType.Priority : PriorityType.Normal;
            _unitOfWork.GetRepository<Table>().Update(table);
            var cps = await _unitOfWork.GetRepository<Table>().GetAll().FirstOrDefaultAsync(y => y.DeviceType == TableDeviceType.CPS && y.AreaCode == table.AreaCode);

            await _unitOfWork.CommitAsync();

            var changeTableTypeDto = new ChangeTableTypeDto
            {
                Table = table.Code,
                Type = (int)table.Type
            };

            try
            {

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
            }
            catch (Exception e)
            {
                Console.WriteLine("SIGNALR: MsgSendFail");
                Console.WriteLine(e.Message);
            }


            return new CS.VM.CheckInModel.Responses.ChangeTableTypeResponse
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

            foreach (var table in tables)
            {
                if (table.Type == PriorityType.Normal)
                {
                    var tableCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueItemDto()
                    {
                        DepartmentCode = table.DepartmentCode,
                        Type = (int)table.Type,
                        To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                        From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                        Table = table,
                    };
                    response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                }
                if (table.Type == PriorityType.Priority)
                {
                    var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(request.Limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueItemDto()
                    {
                        DepartmentCode = table.DepartmentCode,
                        Type = (int)table.Type,
                        To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                        From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
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
                .Where(number => number.DepartmentCode == request.Room && number.IsSelected && DateTime.Compare(number.CreatedDate.Date, DateTime.Now.Date) == 0);

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
                            Gender = patient.Gender,
                            PatientId = patient.Id
                        })
                        .Select(number => new GetPatientsInQueueDto()
                        {
                            PatientId = number.PatientId,
                            Age = number.Age.ToString(),
                            Name = number.Name,
                            Status = (int)number.Status,
                            Type = number.Type,
                            QueueNumber = number.Number,
                            Gender = (int)number.Gender
                        }).Distinct().ToList();


            var getPatientsInQueueDtos = queueNumbersDto.OrderBy(x => x.QueueNumber).Take(request.Limit).ToList();

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
            string areaCode = _hospitalSettings.Hospital.HospitalArea;
            var table = await _unitOfWork.GetRepository<Table>().GetAll().FirstOrDefaultAsync(x => x.Code == request.Table);

            if (table == null)
            {
                return new GetTableQueueResponse
                {
                    GetTableQueueDto = new GetTableQueueDto
                    {
                        Type = -1,
                        From = 0,
                        To = 0
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
            var table = await _unitOfWork.GetRepository<Table>().GetAll().SingleOrDefaultAsync(t => t.Code == request.Table && t.IsActive && !t.IsDeleted);

            if (table == null)
                return new GetTableQueueResponse
                {
                    GetTableQueueDto = new GetTableQueueDto
                    {
                        Type = -1,
                        From = 0,
                        To = 0
                    }
                };

            string areaCode = table.AreaCode;
            var limit = table.Limit;

            if (table.Type == PriorityType.Normal)
            {
                if (areaCode == AreaCode.KBA)
                {
                    var tableReCallNumberNormals = _unitOfWork.GetRepository<KBANormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code
                        && normal.AreaCode == areaCode
                        && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                    if (tableReCallNumberNormals.Count > 0)
                    {
                        var reCallTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                            IsRecall = true
                        };

                        return new GetTableQueueResponse()
                        {
                            GetTableQueueDto = reCallTablePatientDto
                        };
                    }

                    var tableCallNumberNormals = _unitOfWork.GetRepository<KBANormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        DepartmentCode = table.DepartmentCode,
                        Table = table.Code,
                        Type = (int)table.Type,
                        To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                        From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
                else
                {
                    var tableReCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code
                        && normal.AreaCode == areaCode
                        && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                    if (tableReCallNumberNormals.Count > 0)
                    {
                        var reCallTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                            IsRecall = true
                        };

                        return new GetTableQueueResponse()
                        {
                            GetTableQueueDto = reCallTablePatientDto
                        };
                    }

                    var tableCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        DepartmentCode = table.DepartmentCode,
                        Table = table.Code,
                        Type = (int)table.Type,
                        To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                        From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
            }
            if (table.Type == PriorityType.Priority)
            {
                if (areaCode == AreaCode.KBA)
                {
                    var tableReCallNumberNormals = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code
                        && normal.AreaCode == areaCode
                        && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                    if (tableReCallNumberNormals.Count > 0)
                    {
                        var reCallTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                            IsRecall = true
                        };

                        return new GetTableQueueResponse()
                        {
                            GetTableQueueDto = reCallTablePatientDto
                        };
                    }

                    var tableCallNumberPriorities = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        DepartmentCode = table.DepartmentCode,
                        Table = table.Code,
                        Type = (int)table.Type,
                        To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                        From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                    };
                    return new GetTableQueueResponse()
                    {
                        GetTableQueueDto = callTablePatientDto
                    };
                }
                else
                {
                    var tableReCallNumberNormals = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code
                        && normal.AreaCode == areaCode
                        && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                    if (tableReCallNumberNormals.Count > 0)
                    {
                        var reCallTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                            IsRecall = true
                        };

                        return new GetTableQueueResponse()
                        {
                            GetTableQueueDto = reCallTablePatientDto
                        };
                    }

                    var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                        .Where(normal => normal.Table == table.Code && table.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(limit)
                        .ToList();
                    var callTablePatientDto = new GetTableQueueDto()
                    {
                        DepartmentCode = table.DepartmentCode,
                        Table = table.Code,
                        Type = (int)table.Type,
                        To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                        From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
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
                    From = 0,
                    To = 0
                }
            };
        }

        /// <summary>
        /// Tables the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Bệnh nhân chưa được gọi vào bàn. đang gọi số {latestCall ?? 0}. Số thứ tự của bệnh nhân: {queueNumber.Number}
        /// </exception>
        public async Task<TableCheckInResponse> TableCheckIn(TableCheckInRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Patient);
            var tempPatient = await _unitOfWork.GetRepository<TempPatient>().GetAll().SingleOrDefaultAsync(x => x.Code == request.Patient);

            if (patient == null && tempPatient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            else
                if (patient == null)
                patient = _mapper.Map(tempPatient, patient);//DataAdapter.ToCopyModel(patient, tempPatient);

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

                if (areaCode == AreaCode.KBA)
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
                if (areaCode == AreaCode.KBA)
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
                throw new Exception($"Bệnh nhân chưa được gọi vào bàn. đang gọi số {latestCall ?? 0}. Số thứ tự của bệnh nhân: {queueNumber.Number} ");
            }

            return new TableCheckInResponse
            {
                TableCheckInDto = _mapper.Map<TableCheckInDto>(patient)
            };
        }

        /// <summary>
        /// Gets the patient in and last queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientsLastQueueResponse> GetPatientInAndLastQueue(GetPatientsInQueueV2Request request, string webRoot = "")
        {
            var dept = await _unitOfWork.GetRepository<Department>().FindAsync(x => x.ListValueExtendId == request.Room);

            if (dept != null)
            {
                var numbersFromHIS = await _hospitalSystemService.GetPendingList(new GetRawPendingListRequest
                {
                    DepartmentCode = dept.DepartmentCode,
                    GroupDeptCode = dept.GroupDeptCode
                });

                if (numbersFromHIS.Result != null)
                {
                    var result = numbersFromHIS.Result;
                    if (result.RegisteredCode != "0")
                    {
                        await SyncNumberDepartment(dept, result.PatientCode, result.RegisteredCode, int.Parse(result.OrderNumber), true);
                    }

                    foreach (var item in numbersFromHIS.Result.MissingPatient)
                    {
                        if (item.RegisteredCode != "0")
                        {
                            await SyncNumberDepartment(dept, item.PatientCode, item.RegisteredCode, int.Parse(item.OrderNumber));
                        }
                    }

                    foreach (var item in numbersFromHIS.Result.WaitingPatient)
                    {
                        if (item.RegisteredCode != "0")
                        {
                            await SyncNumberDepartment(dept, item.PatientCode, item.RegisteredCode, int.Parse(item.OrderNumber));
                        }
                    }

                    await _unitOfWork.CommitAsync();
                }
            }

            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                .Where(number => number.DepartmentExtendId == request.Room &&
                                        DateTime.Compare(number.CreatedDate.Date, request.Date.Date) == 0
                                        && number.Number > 0);

            //var departmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>()
            //        .FindAsync(x => x.IsRoomActive && x.DepartmentId == request.Room);

            //if (departmentGroup != null)
            //{
            //    queueNumbers = queueNumbers.Where(x => x.GroupCode == departmentGroup.GroupCode);
            //}
            queueNumbers = queueNumbers.OrderBy(number => number.Number);

            var inQueuePatientsNormal = await queueNumbers.Where(number => number.Type == PatientType.Normal && !number.IsSelected).ToListAsync();
            var inQueuePatientsPriority = await queueNumbers.Where(number => number.Type != PatientType.Normal && !number.IsSelected).ToListAsync();
            var lastQueueNumbersCall = await queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.UpdatedDate).ToListAsync();
            var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number);

            var normal = _mapper.Map<List<GetPatientsInQueueDto>>(inQueuePatientsNormal);
            var priority = _mapper.Map<List<GetPatientsInQueueDto>>(inQueuePatientsPriority);
            var last = _mapper.Map<List<GetPatientsInQueueDto>>(lastQueueNumbersCall);

            var normalPatientNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault();
            var normalName = "";
            var normalAge = "";
            var normalGender = 0;
            var normalUrlAudio = "";
            if (normalPatientNumber != null)
            {
                normalName = $"{normalPatientNumber.Patient.LastName} {normalPatientNumber.Patient.FirstName}";
                normalAge = DateTimeUtils.CalculatorAge(normalPatientNumber.Patient.Birthday);
                normalGender = normalPatientNumber.Patient.Gender == Gender.Male ? (int)Gender.Male : (int)Gender.Female;
                var audio = _audio.CreateAudioDepartment(
                    webRoot,
                    normalPatientNumber.GroupDeptCode,
                    normalPatientNumber.Number,
                    normalPatientNumber.Number,
                    (int)normalPatientNumber.Type,
                    normalPatientNumber.DepartmentExtend.Code,
                    normalPatientNumber.DepartmentName,
                    normalName);

                normalUrlAudio = audio;
            }

            return new GetPatientsLastQueueResponse
            {
                LastPatients = last,
                NormalPatients = normal,
                PriorityPatients = priority,
                PriorityNumber = currentQueueNumber.Where(x => x.Type != PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                NormalNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                NormalName = normalName,
                NormalAge = normalAge,
                NormalGender = normalGender,
                NormalAudioUrl = normalUrlAudio
            };
        }

        private async Task SyncNumberDepartment(Department dept, string patientCode, string registeredCode, int number, bool isSelected = false)
        {
            var patient = await _patientService.GetByCode(patientCode);
            if (patient != null)
            {
                var currentNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(q => q.PatientCode == patient.Code
                && q.DepartmentCode == dept.DepartmentCode
                && q.RegisteredCode == registeredCode).FirstOrDefaultAsync();

                if (currentNumber == null)
                {
                    currentNumber = new QueueNumber
                    {
                        DepartmentCode = dept.DepartmentCode,
                        GroupDeptCode = dept.GroupDeptCode,
                        DepartmentAddress = dept.DepartmentAddress,
                        DepartmentName = dept.DepartmentName,
                        GroupDeptName = dept.GroupDeptName,
                        Number = number,
                        PatientCode = patient.Code,
                        RegisteredCode = registeredCode,
                        RegisteredDate = DateTime.Now,
                        PatientId = patient.Id,
                        DepartmentExtendId = dept.ListValueExtendId,
                        IsSelected = isSelected
                    };

                    _unitOfWork.GetRepository<QueueNumber>().Add(currentNumber);
                }
            }
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

            try
            {

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
            }
            catch (Exception e)
            {
                Console.WriteLine("SIGNALR: MsgSendFail");
                Console.WriteLine(e.Message);
            }
            return true;
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
                              .Where(number => number.DepartmentCode == request.Room && DateTime.Compare(number.CreatedDate.Date, request.Date.Date) == 0
                              && number.Number > 0)
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
        /// Gets the patient medicine result.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientsLastQueueClinicResultResponse> GetPatientMedicineResult(GetPatientsInQueueRequest request)
        {
            var queueNumbers = _unitOfWork.GetRepository<QueueNumberTemp>().GetAll()
                              .Where(number => number.TableCode == request.Room && DateTime.Compare(number.CreatedDate.Date, request.Date.Date) == 0
                              && number.Number > 0).OrderBy(number => number.Number);

            var inQueuePatients = await queueNumbers.Where(number => !number.IsSelected).Take(request.Limit).ToListAsync();
            var lastQueuePatients = await queueNumbers.Where(number => number.IsSelected).ToListAsync();
            var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number).Take(1).SingleOrDefault()?.Number ?? 0;
            var currentNumberRec = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number).Take(1).SingleOrDefault();
            var currentName = "";
            var currentAge = "";
            var currentGender = 0;
            if (currentNumberRec != null)
            {
                currentName = $"{currentNumberRec.Patient.LastName} {currentNumberRec.Patient.FirstName}";
                currentAge = DateTimeUtils.CalculatorAge(currentNumberRec.Patient.Birthday);
                currentGender = currentNumberRec.Patient.Gender == Gender.Male ? (int)Gender.Male : (int)Gender.Female;
            }

            return new GetPatientsLastQueueClinicResultResponse
            {
                CurrentNumber = currentQueueNumber,
                CurrentName = currentName,
                CurrentAge = currentAge,
                CurrentGender = currentGender,
                InQueuePatients = _mapper.Map<List<GetPatientsInQueueDto>>(inQueuePatients),
                LastQueuePatients = _mapper.Map<List<GetPatientsInQueueDto>>(lastQueuePatients)
            };
        }

        public async Task<RegisterQueueNumberResponse> ChangeRoomEndoscopic(ChangeRoomRequest request)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == request.PatientId);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            var queueNumber = _unitOfWork.GetRepository<QueueNumber>()
                               .GetAll()
                               .Where(number => number.DepartmentCode == request.OldDepartment
                                    && number.Patient != null
                                    && number.PatientId == request.PatientId
                                    && DateTime.Compare(number.CreatedDate.Date, request.Date.Date) == 0)
                               .FirstOrDefault();

            if (queueNumber == null)
                throw new Exception(ErrorMessages.NotFoundQueueNumber);

            var departmentConfig = _unitOfWork.GetRepository<DepartmentConfig>().GetAll()
                           .Where(x => x.DepartmentCode == request.NewDepartment)
                           .FirstOrDefault();

            if (departmentConfig == null)
                throw new Exception("Không tìm thấy cấu hình phòng khám");

            var countQueueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                .Where(x => x.DepartmentCode == request.NewDepartment && x.CreatedDate.Date == request.NewDate.Date)
                .Count();

            // Trả respone để in bill hẹn khám
            if (countQueueNumbers >= departmentConfig.TotalNumber)
            {
                throw new Exception("Đã hết lượt khám trong ngày hôm nay, vui lòng qua quầy tiếp nhận để hẹn lại ngày khám!");
            }

            var clinics = await _unitOfWork.GetRepository<Clinic>()
                                 .GetAll()
                                 .Where(x => x.PatientId == queueNumber.PatientId
                                     && x.DepartmentCode == request.OldDepartment
                                     && DateTime.Compare(x.CreatedDate.Date, queueNumber.CreatedDate.Date) == 0)
                                 .ToListAsync();

            var reception = await _unitOfWork.GetRepository<Reception>().GetAll()
                                       .OrderByDescending(x => x.CreatedDate)
                                       .FirstOrDefaultAsync(x => x.PatientId == request.PatientId
                                                                && x.IsFinished == false);

            var history = _unitOfWork.GetRepository<QueueNumberHistory>().GetAll()
                    .Where(x => x.NewDepartmentCode == request.NewDepartment
                        && x.OldDepartmentCode == request.OldDepartment
                        && x.PatientId == patient.Id
                        && x.NewDate.Value.Date > DateTime.Now.Date);
            if (reception != null)
            {
                history = history.Where(x => x.RegisteredCode == reception.RegisteredCode);
            }

            // Đã có hẹn thì update
            if (history.Count() > 0)
            {
                var his = history.FirstOrDefault();
                his.NewDate = request.NewDate;
                _unitOfWork.GetRepository<QueueNumberHistory>().Update(his);

                var numberAppointment = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                    .Where(x => x.Number < 0
                    && x.DepartmentCode == request.NewDepartment
                    && x.CreatedDate.Date > DateTime.Now.Date
                    && x.PatientId == patient.Id).FirstOrDefault();

                if (numberAppointment != null)
                {
                    numberAppointment.CreatedDate = request.NewDate;
                    numberAppointment.RegisteredDate = request.NewDate;
                    _unitOfWork.GetRepository<QueueNumber>().Update(numberAppointment);
                    await _unitOfWork.CommitAsync();
                    var responseApp = _mapper.Map<RegisterQueueNumberResponse>(numberAppointment);
                    responseApp.QueueNumberViewModel = _mapper.Map<QueueNumberViewModel>(numberAppointment);
                    responseApp.QueueNumberViewModel.DepartmentName = numberAppointment.DepartmentExtend?.Description;

                    return _mapper.Map<RegisterQueueNumberResponse>(responseApp);
                }
                else
                {
                    // Add queue number 
                    var queueNew = await _orderNumberService.AddNumberChangeRoom(new QueueNumberAddModel()
                    {
                        DepartmentCode = request.NewDepartment,
                        PatientId = queueNumber.PatientId,
                        Type = queueNumber.Patient?.PatientType,
                        RequestDate = request.NewDate.Date,
                    });
                    await _unitOfWork.CommitAsync();
                    var responseNew = _mapper.Map<RegisterQueueNumberResponse>(queueNew);
                    responseNew.QueueNumberViewModel = _mapper.Map<QueueNumberViewModel>(queueNew);
                    responseNew.QueueNumberViewModel.DepartmentName = queueNew.DepartmentExtend?.Description;
                    return _mapper.Map<RegisterQueueNumberResponse>(responseNew);
                }
            }

            if (clinics != null && clinics.Count > 0)
            {
                foreach (var item in clinics)
                {
                    item.DepartmentCode = request.NewDepartment;
                    item.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<Clinic>().Update(item);
                }
            }

            // Add queue number 
            var queueNumberNew = await _orderNumberService.AddNumberChangeRoom(new QueueNumberAddModel()
            {
                DepartmentCode = request.NewDepartment,
                PatientId = queueNumber.PatientId,
                Type = queueNumber.Patient?.PatientType,
                RequestDate = request.NewDate.Date,
            });

            if (queueNumber.Number < 0)
            {
                _unitOfWork.GetRepository<QueueNumber>().Delete(queueNumber);
            }
            // Add queue number history
            var queueNumberHistory = await _orderNumberService.AddQueueNumberHistory(new QueueNumberHistory()
            {
                PatientCode = patient.Code,
                PatientId = patient.Id,
                OldDepartmentCode = request.OldDepartment,
                NewDepartmentCode = request.NewDepartment,
                OldDate = request.Date.Date,
                NewDate = request.NewDate != DateTime.MinValue ? request.NewDate.Date : DateTime.Now.Date,
                OldNumber = queueNumber.Number,
                NewNumber = queueNumberNew.Number,
                Reason = request.Reason,
                RegisteredCode = reception?.RegisteredCode,
                CreatedBy = request.EmployeeId.ToString()
            });

            await _unitOfWork.CommitAsync();
            var response = _mapper.Map<RegisterQueueNumberResponse>(queueNumberNew);
            response.QueueNumberViewModel = _mapper.Map<QueueNumberViewModel>(queueNumberNew);
            response.QueueNumberViewModel.DepartmentName = queueNumberNew.DepartmentExtend?.Description;
            return _mapper.Map<RegisterQueueNumberResponse>(response);
        }

        public async Task<List<QueueItem>> GetMultiQueueByDepartmentEndoscopic(List<QueueItemRequest> request)
        {
            var result = new List<QueueItem>();
            foreach (var itemRequest in request)
            {
                var departmentValue = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(l => l.Id == itemRequest.DepartmentCode);
                if (departmentValue == null)
                {
                    continue;
                }

                var departmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>()
                    .FindAsync(x => x.IsRoomActive && x.ListValueExtendId == itemRequest.DepartmentCode);

                var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentExtendId == itemRequest.DepartmentCode &&
                                        DateTime.Compare(number.CreatedDate.Date, itemRequest.Date.Date) == 0
                                        && number.Number > 0);

                if (departmentGroup != null)
                {
                    queueNumbers = queueNumbers.Where(x => x.GroupDeptCode == departmentGroup.GroupCode);
                }
                queueNumbers = queueNumbers.OrderBy(number => number.Number);

                var inQueuePatientsNormal = await queueNumbers.Where(number => number.Type == PatientType.Normal && !number.IsSelected).ToListAsync();
                var inQueuePatientsPriority = await queueNumbers.Where(number => number.Type != PatientType.Normal && !number.IsSelected).ToListAsync();
                var lastQueueNumbersCall = await queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.CreatedDate).ToListAsync();
                var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number);

                var normal = _mapper.Map<List<PatientQueueItem>>(inQueuePatientsNormal);
                var priority = _mapper.Map<List<PatientQueueItem>>(inQueuePatientsPriority);
                var last = _mapper.Map<List<PatientQueueItem>>(lastQueueNumbersCall);

                var department = new QueueItem
                {
                    DisplayOrder = departmentValue?.DisplayOrder,
                    DeparmentCode = departmentValue?.Code,
                    DepartmentId = itemRequest.DepartmentCode,
                    DepartmentName = departmentValue?.Description,
                    LastPatients = last,
                    NormalPatients = normal,
                    PriorityPatients = priority,
                    NumberOfNormalPatient = normal.Count(),
                    NumberOfPriorityPatient = priority.Count(),
                    PriorityNumber = currentQueueNumber.Where(x => x.Type != PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                    NormalNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0
                };

                var derpartmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                   .Where(x => x.IsRoomActive && x.ListValueExtendId == itemRequest.DepartmentCode).FirstOrDefaultAsync();

                if (derpartmentGroup != null)
                {
                    if (derpartmentGroup.DepartmentVirtual != null)
                    {
                        department.DepartmentNameChange = derpartmentGroup.DepartmentVirtual.Description;
                    }
                    else
                    {
                        department.DepartmentName = department.DepartmentName;
                    }
                }
                else
                {
                    department.DepartmentName = department.DepartmentName;
                }

                result.Add(department);
            }

            return result;
        }

        public async Task<GetPatientsInQueueResponse> CallPatientVirtual(CallPatientGroupRequest request, string urlAudio)
        {
            if (!string.IsNullOrEmpty(request.GroupCode))
            {
                var newServices = new List<UltrasoundServiceJson>();
                var department = await _unitOfWork.GetRepository<Department>().FindAsync(x => x.ListValueExtend.Id == request.Room);
                if (department == null)
                {
                    throw new Exception(ErrorMessages.NotFoundDepartment);
                }

                var group = await _unitOfWork.GetRepository<Group>().FindAsync(x => x.GroupDeptCode == request.GroupCode);

                if (group == null)
                {
                    throw new Exception("Không tìm thấy nhóm phòng");
                }

                var departmentGroup = _unitOfWork.GetRepository<DepartmentGroup>().GetAll().Where(x => x.ListValueExtendId == department.ListValueExtendId
                                       && x.GroupId == group.Id).FirstOrDefault();

                if (departmentGroup != null && departmentGroup.DepartmentVirtual != null)
                {
                    // CẬp nhật lại phòng đang sử dụng của nhóm
                    var departmentGroups = await _unitOfWork.GetRepository<DepartmentGroup>().GetAll().Where(x => x.ListValueExtendId == departmentGroup.ListValueExtendId
                    ).ToListAsync();
                    foreach (var item in departmentGroups)
                    {
                        item.IsRoomActive = false;
                        if (item.GroupId == departmentGroup.GroupId)
                        {
                            item.IsRoomActive = true;
                        }
                        _unitOfWork.GetRepository<DepartmentGroup>().Update(item);
                    }

                    var room = await _unitOfWork.GetRepository<ListValueExtend>().GetAll()
                    .Join(_unitOfWork.GetRepository<ListValueType>().GetAll().Where(type => type.Code == "PB"),
                              extend => extend.ListValueTypeId, type => type.Id, (extend, type) => new { extend })
                    .Select(arg => arg.extend)
                    .Where(extend => extend.Id == request.Room)
                    .SingleOrDefaultAsync();

                    if (room == null)
                        throw new Exception(ErrorMessages.NotFoundExtendValue);

                    var queueNumbersQuery = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                        .Where(number => number.DepartmentExtendId == departmentGroup.DepartmentVirtual.Id
                        && DateTime.Compare(number.CreatedDate.Date, DateTime.Now.Date) == 0);

                    var lastTimeCall = queueNumbersQuery.Where(t => t.IsSelected).OrderByDescending(o => o.UpdatedDate).FirstOrDefault();

                    if (lastTimeCall != null)
                    {
                        var seconds = (DateTime.Now - lastTimeCall.UpdatedDate).TotalSeconds;
                        if (seconds < _hospitalSettings.Hospital.NextCallTime)
                            throw new Exception(ErrorMessages.InvalidNextCallTime);
                    }

                    var queueNumbers = await queueNumbersQuery.Where(number => !number.IsSelected &&
                            (request.Type == PatientType.Normal
                            ? number.Type == PatientType.Normal
                            : number.Type != PatientType.Normal)
                            && number.Number > 0)
                        .OrderBy(number => number.Number).Take(request.Number).ToListAsync();

                    var patientIds = queueNumbers.Select(s => s.PatientId).ToList();
                    //var receptions = await _unitOfWork.GetRepository<Reception>().GetAll().Where(d => patientIds.Any(p => p == d.PatientId) && !d.IsFinished).AsNoTracking().ToListAsync();

                    foreach (var number in queueNumbers)
                    {
                        number.IsSelected = true;
                        number.UpdatedDate = DateTime.Now;
                        _unitOfWork.GetRepository<QueueNumber>().Update(number);

                        var queueNumber = await _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(
                            x => x.Number == number.Number
                            && x.Type == request.Type
                            && x.PatientId == number.PatientId
                            && x.DepartmentExtendId == request.Room).FirstOrDefaultAsync();

                        var patientName = number.Patient != null ? number.Patient.LastName + " " + number.Patient.FirstName : string.Empty;

                        var audio = _audio.CreateAudioDepartment(
                            urlAudio,
                            number.GroupDeptCode,
                            number.Number,
                            number.Number,
                            (int)number.Type,
                            department.ListValueExtend.Code,
                            number.DepartmentName,
                            patientName);

                        if (queueNumber != null)
                        {
                            queueNumber.IsSelected = true;
                            queueNumber.GroupDeptCode = request.GroupCode;
                            queueNumber.UrlAudio = audio;
                            _unitOfWork.GetRepository<QueueNumber>().Update(queueNumber);
                            await _unitOfWork.CommitAsync();
                            continue;
                        }

                        queueNumber = new QueueNumber()
                        {
                            Number = number.Number,
                            AreaCode = _hospitalSettings.Hospital.HospitalArea,
                            IsSelected = true,
                            DepartmentCode = department.ListValueExtend.Code,
                            PatientId = number.PatientId,
                            Type = number.Type,
                            GroupDeptCode = request.GroupCode,
                            UrlAudio = audio,
                            DepartmentExtendId = department.ListValueExtend.Id
                        };

                        _unitOfWork.GetRepository<QueueNumber>().Add(queueNumber);
                    }

                    await _unitOfWork.CommitAsync();

                    return new GetPatientsInQueueResponse()
                    {
                        GetPatientsInQueueDtos = new List<GetPatientsInQueueDto>()
                    };
                }
            }
            return await CallPatient(new CallPatientRequest()
            {
                Number = request.Number,
                Room = request.Room,
                Type = request.Type
            });
        }

        public async Task<GetAllTableQueueResponse> GetCPS(GetAllTableQueueRequest request)
        {
            var cps = await _unitOfWork.GetRepository<Table>().GetAll()
                .FirstOrDefaultAsync(t => t.Code == request.Code && t.IsActive && !t.IsDeleted);

            if (cps == null)
            {
                throw new Exception(ErrorMessages.NotFoundTable);
            }

            var cpsTypes = cps.DepartmentCode.Split("_");
            var departmentCode = Departments.TNB;
            if (cpsTypes.Length > 1)
            {
                departmentCode = cpsTypes[1];
            }

            string areaCode = cps.AreaCode;
            if (departmentCode == Departments.TNB)
            {
                GetAllTableQueueResponse response = await GetTNBCPS(departmentCode, areaCode);
                return response;
            }

            if (departmentCode == Departments.TATTOAN)
            {
                GetAllTableQueueResponse response = await GetTATTOANCPS(departmentCode, areaCode);
                return response;
            }

            return new GetAllTableQueueResponse
            {
                GetAllTableQueueDto = new GetAllTableQueueDto()
            };
        }

        private async Task<GetAllTableQueueResponse> GetTNBCPS(string departmentCode, string areaCode)
        {
            var tables = await _unitOfWork.GetRepository<Table>().GetAll()
                .Where(t => t.AreaCode == areaCode && (t.DepartmentCode == departmentCode) && !t.IsDeleted).OrderBy(x => x.Store).ToListAsync();

            var response = new GetAllTableQueueResponse
            {
                GetAllTableQueueDto = new GetAllTableQueueDto()
            };

            foreach (var table in tables)
            {
                var limit = table.Limit;
                if (areaCode == AreaCode.KBA)
                {
                    if (table.Type == PriorityType.Normal)
                    {
                        var tableReCallNumberNormals = _unitOfWork.GetRepository<KBANormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberNormals.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberNormals = _unitOfWork.GetRepository<KBANormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(limit)
                            .ToList();

                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                    if (table.Type == PriorityType.Priority)
                    {
                        var tableReCallNumberPriorities = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberPriorities.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberPriorities = _unitOfWork.GetRepository<KBAPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                }

                if (areaCode == AreaCode.KBB)
                {
                    if (table.Type == PriorityType.Normal)
                    {
                        var tableReCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberNormals.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberNormals = _unitOfWork.GetRepository<KBBNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                    if (table.Type == PriorityType.Priority)
                    {
                        var tableReCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberPriorities.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                }
            }

            return response;
        }

        private async Task<GetAllTableQueueResponse> GetTATTOANCPS(string departmentCode, string areaCode)
        {
            var tables = await _unitOfWork.GetRepository<Table>().GetAll()
                .Where(t => t.AreaCode == areaCode && (t.DepartmentCode == departmentCode) && !t.IsDeleted)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            var response = new GetAllTableQueueResponse
            {
                GetAllTableQueueDto = new GetAllTableQueueDto()
            };

            foreach (var table in tables)
            {
                var limit = table.Limit;
                if (areaCode == AreaCode.KBA)
                {
                    if (table.Type == PriorityType.Normal)
                    {
                        var tableReCallNumberNormals = _unitOfWork.GetRepository<KBAPaidNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberNormals.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberNormals = _unitOfWork.GetRepository<KBAPaidNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                    if (table.Type == PriorityType.Priority)
                    {
                        var tableReCallNumberNormals = _unitOfWork.GetRepository<KBAPaidPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberNormals.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberPriorities = _unitOfWork.GetRepository<KBAPaidPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                }

                if (areaCode == AreaCode.KBB)
                {
                    if (table.Type == PriorityType.Normal)
                    {
                        var tableReCallNumberNormals = _unitOfWork.GetRepository<KBBPaidNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberNormals.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberNormals = _unitOfWork.GetRepository<KBBPaidNormalTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(normal => normal.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                    if (table.Type == PriorityType.Priority)
                    {
                        var tableReCallNumberNormals = _unitOfWork.GetRepository<KBBPaidPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code
                            && normal.AreaCode == areaCode
                            && normal.IsSelected == false).OrderByDescending(normal => normal.SEQ).ToList();

                        if (tableReCallNumberNormals.Count > 0)
                        {
                            var reCallTablePatientDto = new GetTableQueueItemDto()
                            {
                                DepartmentCode = table.DepartmentCode,
                                Type = (int)table.Type,
                                To = tableReCallNumberNormals.FirstOrDefault()?.SEQ ?? 0,
                                From = tableReCallNumberNormals.LastOrDefault()?.SEQ ?? 0,
                                Table = table,
                                IsRecall = true
                            };
                            response.GetAllTableQueueDto.Result.Add(reCallTablePatientDto);
                            continue;
                        }

                        var tableCallNumberPriorities = _unitOfWork.GetRepository<KBBPaidPriorityTable>().GetAll()
                            .Where(normal => normal.Table == table.Code && normal.AreaCode == areaCode).OrderByDescending(priority => priority.SEQ).Take(limit)
                            .ToList();
                        var callTablePatientDto = new GetTableQueueItemDto()
                        {
                            DepartmentCode = table.DepartmentCode,
                            Type = (int)table.Type,
                            To = tableCallNumberPriorities.FirstOrDefault()?.SEQ ?? 0,
                            From = tableCallNumberPriorities.LastOrDefault()?.SEQ ?? 0,
                            Table = table,
                        };
                        response.GetAllTableQueueDto.Result.Add(callTablePatientDto);
                    }
                }
            }

            return response;
        }

        #region Private Functions
        /// <summary>
        /// Gets the table queue by priority.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="areaCode">The area code.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        private async Task<GetTableQueueResponse> GetTableQueueByPriority(Table table, string areaCode, int limit)
        {
            var tableCallNumbers = await _unitOfWork.GetRepository<TableCallNumber>().GetAll()
                .Where(tb => tb.Table == table.Code && table.AreaCode == areaCode)// && tb. == table.Type)
                .OrderByDescending(normal => normal.SEQ).Take(limit)
                .ToListAsync();

            var callTablePatientDto = new GetTableQueueDto
            {
                Type = (int)table.Type,
                To = tableCallNumbers.FirstOrDefault()?.SEQ ?? 0,
                From = tableCallNumbers.LastOrDefault()?.SEQ ?? 0,
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
                        From = 0,
                        To = 0
                    }
                };
        }

        public async Task<List<QueueItem>> GetMultiQueueByDepartment(List<QueueItemRequest> request)
        {
            var result = new List<QueueItem>();
            foreach (var item in request)
            {
                var departmentValue = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(l => l.Id == item.DepartmentCode);
                if (departmentValue == null)
                {
                    continue;
                }

                var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll().Where(number => number.DepartmentExtendId == item.DepartmentCode &&
                                        DateTime.Compare(number.CreatedDate.Date, item.Date.Date) == 0).OrderBy(number => number.Number);

                var inQueuePatientsNormal = await queueNumbers.Where(number => number.Type == PatientType.Normal && !number.IsSelected).ToListAsync();
                var inQueuePatientsPriority = await queueNumbers.Where(number => number.Type != PatientType.Normal && !number.IsSelected).ToListAsync();
                var lastQueueNumbersCall = await queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.UpdatedDate).ToListAsync();
                var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number);

                var normal = _mapper.Map<List<PatientQueueItem>>(inQueuePatientsNormal);
                var priority = _mapper.Map<List<PatientQueueItem>>(inQueuePatientsPriority);
                var last = _mapper.Map<List<PatientQueueItem>>(lastQueueNumbersCall);

                var department = new QueueItem
                {
                    DeparmentCode = departmentValue?.Code,
                    DepartmentName = departmentValue?.Description,
                    LastPatients = last,
                    NormalPatients = normal,
                    PriorityPatients = priority,
                    NumberOfNormalPatient = normal.Count(),
                    NumberOfPriorityPatient = priority.Count(),
                    PriorityNumber = currentQueueNumber.Where(x => x.Type != PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                    NormalNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0
                };

                result.Add(department);
            }

            return result;
        }

        public Task<GetAllTableQueueResponse> GetAllTableQueue_V02(GetAllTableQueueRequest_V02 request)
        {
            throw new NotImplementedException();
        }

        public Task<GetPatientsInAndLastQueueResponse> GetPatientInAndLastQueue(GetPatientsInQueueRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the patient in and last queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetPatientsLastQueueResponse> GetPatientInAndLastQueueV2(GetPatientsInQueueV2Request request, string webRoot = "")
        {
            var dept = await _unitOfWork.GetRepository<Department>().FindAsync(x => x.ListValueExtendId == request.Room);

            if (dept != null)
            {
                var numbersFromHIS = await _hospitalSystemService.GetPendingList(new GetRawPendingListRequest
                {
                    DepartmentCode = dept.DepartmentCode,
                    GroupDeptCode = dept.GroupDeptCode
                });

                if (numbersFromHIS.Result != null)
                {
                    var result = numbersFromHIS.Result;
                    if (result.RegisteredCode != "0")
                    {
                        await SyncNumberDepartment(dept, result.PatientCode, result.RegisteredCode, int.Parse(result.OrderNumber), true);
                    }

                    foreach (var item in numbersFromHIS.Result.MissingPatient)
                    {
                        if (item.RegisteredCode != "0")
                        {
                            await SyncNumberDepartment(dept, item.PatientCode, item.RegisteredCode, int.Parse(item.OrderNumber));
                        }
                    }

                    foreach (var item in numbersFromHIS.Result.WaitingPatient)
                    {
                        if (item.RegisteredCode != "0")
                        {
                            await SyncNumberDepartment(dept, item.PatientCode, item.RegisteredCode, int.Parse(item.OrderNumber));
                        }
                    }

                    await _unitOfWork.CommitAsync();
                }
            }

            var queueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                .Where(number => number.DepartmentExtendId == request.Room &&
                                        DateTime.Compare(number.CreatedDate.Date, request.Date.Date) == 0
                                        && number.Number > 0);

            //var departmentGroup = await _unitOfWork.GetRepository<DepartmentGroup>()
            //        .FindAsync(x => x.IsRoomActive && x.DepartmentId == request.Room);

            //if (departmentGroup != null)
            //{
            //    queueNumbers = queueNumbers.Where(x => x.GroupCode == departmentGroup.GroupCode);
            //}
            queueNumbers = queueNumbers.OrderBy(number => number.Number);

            var inQueuePatientsNormal = await queueNumbers.Where(number => number.Type == PatientType.Normal && !number.IsSelected).ToListAsync();
            var inQueuePatientsPriority = await queueNumbers.Where(number => number.Type != PatientType.Normal && !number.IsSelected).ToListAsync();
            var lastQueueNumbersCall = await queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.UpdatedDate).ToListAsync();
            var currentQueueNumber = queueNumbers.Where(number => number.IsSelected).OrderByDescending(x => x.Number);

            var normal = _mapper.Map<List<GetPatientsInQueueDto>>(inQueuePatientsNormal);
            var priority = _mapper.Map<List<GetPatientsInQueueDto>>(inQueuePatientsPriority);
            var last = _mapper.Map<List<GetPatientsInQueueDto>>(lastQueueNumbersCall);

            var normalPatientNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault();
            var normalName = "";
            var normalAge = "";
            var normalGender = 0;
            var normalUrlAudio = "";
            if (normalPatientNumber != null)
            {
                normalName = $"{normalPatientNumber.Patient.LastName} {normalPatientNumber.Patient.FirstName}";
                normalAge = DateTimeUtils.CalculatorAge(normalPatientNumber.Patient.Birthday);
                normalGender = normalPatientNumber.Patient.Gender == Gender.Male ? (int)Gender.Male : (int)Gender.Female;

                try
                {
                    var audio = _audio.CreateAudioDepartment(
                        webRoot,
                        normalPatientNumber.GroupDeptCode,
                        normalPatientNumber.Number,
                        normalPatientNumber.Number,
                        (int)normalPatientNumber.Type,
                        normalPatientNumber.DepartmentExtend.Code,
                        normalPatientNumber.DepartmentName,
                        normalName);

                    normalUrlAudio = audio;
                }
                catch (Exception)
                {
                }
            }

            return new GetPatientsLastQueueResponse
            {
                LastPatients = last,
                NormalPatients = normal,
                PriorityPatients = priority,
                PriorityNumber = currentQueueNumber.Where(x => x.Type != PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                NormalNumber = currentQueueNumber.Where(x => x.Type == PatientType.Normal).Take(1).SingleOrDefault()?.Number ?? 0,
                NormalName = normalName,
                NormalAge = normalAge,
                NormalGender = normalGender,
                NormalAudioUrl = normalUrlAudio
            };
        }

        #endregion

    }
}
