using AutoMapper;
using CS.Common.Common;
using CS.Common.Extensions;
using CS.EF.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Infrastructure;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using TEK.Gateway.Domain.BusinessObjects;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    public class UltrasoundQueueNumberService : IQueueNumberService
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
        /// Gets the hospital settings.
        /// </summary>
        /// <value>The hospital settings.</value>
        private readonly HospitalSettings _hospitalSettings;

        /// <summary>
        /// The patient service
        /// </summary>
        private readonly IPatientService _patientService;

        /// <summary>
        /// The location service
        /// </summary>
        private readonly ILocationService _locationService;

        /// <summary>
        /// The location service
        /// </summary>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueNumberService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="hospitalSettings">The hospital settings.</param>
        public UltrasoundQueueNumberService(IUnitOfWork unitOfWork,
            HospitalSettings hospitalSettings,
            IMapper mapper,
            IPatientService patientService,
            ILocationService locationService,
            IHospitalSystemService hospitalSystemService)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
            _mapper = mapper;
            _patientService = patientService;
            _locationService = locationService;
            _hospitalSystemService = hospitalSystemService;
        }

        public async Task<UltrasoundResponse> GenerateNumber(GetListServiceRequest groupDepartmentCode,
            Patient patientInfo,
            ICollection<Reception> receptions)
        {
            if (groupDepartmentCode == null || groupDepartmentCode.DepartmentCode.Count == 0)
            {
                throw new Exception("Dữ liệu không hợp lệ!");
            }

            // 1. Lấy danh sách các phòng thuộc các mã nhóm
            var departmentVirtuals = _unitOfWork.GetRepository<DepartmentGroup>().GetAll()
                .Where(x => groupDepartmentCode.DepartmentCode.Any(d => d == x.GroupCode))
                .Select(x => x.DepartmentVirtual);

            if (departmentVirtuals == null || departmentVirtuals.Count() == 0)
                throw new Exception("Không tìm thấy phòng chờ!");


            if (receptions.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            // List<Task<GetRawFinallyClinicListResponse>> taskList = new List<Task<GetRawFinallyClinicListResponse>>();

            // 3. Duyệt từng số tiếp nhận
            // foreach (var reception in receptions)
            // {
            //     // 4. Lấy dữ liệu từ HIS qua STN
            //     var task = _hospitalSystemService.GetRawFinallyClinicList(new GetRawFinallyClinicListRequest
            //     {
            //         PatientCode = patientInfo.Code,
            //         RegisteredCode = reception.RegisteredCode
            //     });

            //     taskList.Add(task);
            // }

            // // 5. Chờ tất cả hoàn tất
            // await Task.WhenAll(taskList.ToArray());

            var services = new List<Clinic>();

            foreach (var reception in receptions)
            {
                var clinics = _unitOfWork.GetRepository<Clinic>().GetAll()
                               .Where(x => x.ReceptionId == reception.Id
                                       && !x.Reception.IsFinished).ToList();
                if (clinics.Count > 0)
                {
                    services.AddRange(clinics);
                }
            }

            // 6. Nếu không có dịch vụ nào thì báo lỗi
            if (services.Count < 0 || services == null)
            {
                throw new Exception(ErrorMessages.NotFoundServiceInformation);
            }

            // 7. Lấy tất cả các dịch vụ 
            var serviceIds = services.Select(s => s.ServiceExtendId);

            // 8. Lấy các phòng thực hiện dịch vụ
            var departmentServiceList = await _unitOfWork.GetRepository<CS.EF.Models.DepartmentService>().GetAll().Where(l => serviceIds.Any(m => m == l.ServiceId)).ToListAsync();
            var departmentServiceListCodes = departmentServiceList.Select(s => s.RoomId).Distinct();
            var virtualCodes = await departmentVirtuals.Select(x => x.Id).ToListAsync();
            // 9. Lấy danh sách các phòng chỉ định có dịch vụ thực hiện
            var commonDepartmentCodes = virtualCodes.Intersect(departmentServiceListCodes);

            // 10. Lấy danh sách các dịch vụ trong danh sách phòng ban đang hoạt động
            var commonServices = departmentServiceList.Where(d => commonDepartmentCodes.Any(c => c == d.RoomId)).ToList();
            var commonServiceCodes = commonServices.Select(s => s.ServiceId).Distinct();

            // 11. Lấy tất cả service hợp lệ (có phòng khám đang hoạt động)
            var validServices = services.Where(x => commonServiceCodes.Any(d => d == x.ServiceExtendId)).ToList();
            if (validServices.Count <= 0 || validServices == null)
            {
                throw new Exception(ErrorMessages.NotFoundServiceInDepartment);
            }

            var notFinishedIds = validServices.Where(s => s.IsFinished == HISErrorCode.NotFinished).Select(s => s.IdSpecified);
            var finishedIds = validServices.Where(s => s.IsFinished == HISErrorCode.IsFinished).Select(s => s.IdSpecified);
            if (finishedIds.Count() > 0 && finishedIds.Count() == validServices.Count())
            {
                throw new Exception(ErrorMessages.AlrealdyFinished);
            }
            // 12. Lấy số tiếp nhận
            var receptionCodes = receptions.Select(s => s.RegisteredCode).Distinct();
            if (receptions.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundServiceInDepartment);
            }

            // // var transactionInfos = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
            // //         .Where(x => receptionCodes.Any(r => r == x.RegisteredCode)
            // //              && x.Status == TransactionStatus.Success
            // //              && x.Type == TransactionType.Hold);

            // // // 13. Lấy tất cả các dịch vụ đã tạm ứng
            // // var transactionClinicMasters = await _unitOfWork.GetRepository<TransactionClinic>()
            // //         .GetAll().Where(d => transactionInfos.Any(t => t.Id == d.TransactionInfoId)).ToListAsync();

            // // // 14. Lấy tất cả các dịch vụ đã tạm ứng
            // // var paymentCount = transactionClinicMasters.Count(x => notFinishedIds.Any(r => r == x.IdSpecified)
            // //         && x.TransactionInfo.Status == TransactionStatus.Success
            // //         && x.TransactionInfo.Type == TransactionType.Hold);

            // // // 15. Báo lỗi nếu có ít nhất một dịch vụ chưa thanh toán
            // // if (paymentCount < notFinishedIds.Count())
            // // {
            // //     throw new Exception(ErrorMessages.NotFinishPayment);
            // // }

            var responses = new UltrasoundResponse();
            responses.Patient = _mapper.Map<PatientJson>(patientInfo);

            // // // 16. Lấy các giao dịch thành công
            // // var transactionClinicList = transactionClinicMasters.Where(d =>
            // //       commonServiceCodes.Any(s => s == d.ServiceExtendId)
            // //       && d.Status == TransactionStatus.Success
            // //       && d.Type == TransactionType.Hold)
            // //       .ToList();

            //17 Lấy transaction clinic refund (trường hợp in 2 dịch vụ trùng nhau khi xóa chỉ định cho lại)
            //var transactionClinicRefunds = transactionClinicMasters.Where(d =>
            //          d.Status == TransactionStatus.Success
            //          && d.Type == TransactionType.Refund)
            //          .ToList();

            //if (transactionClinicRefunds.Count() > 0)
            //{
            //    transactionClinicList = transactionClinicList.Where(x => !transactionClinicRefunds.Any(t => t.ClinicId == x.Id)).ToList();
            //}

            // // var heldClinics = services.Where(clinic => transactionClinicList.Any(
            // //                                                 transactionClinic => clinic.IdSpecified == transactionClinic.IdSpecified))
            // //                                                 .DistinctBy(clinic => clinic.IdSpecified).ToList();
            // // transactionClinicList = transactionClinicList.DistinctBy(transactionClinic => transactionClinic.IdSpecified).ToList();
            // // // 18. Lấy danh sách phòng chỉ định
            // // var examinationCodes = heldClinics.Select(s => s.ExaminationExtendId).Distinct();
            // // var departmentCodeTrans = heldClinics.Select(x => x.DepartmentExtendId).Distinct();

            var heldClinics = validServices.ToList();
            // transactionClinicList = transactionClinicList.DistinctBy(transactionClinic => transactionClinic.IdSpecified).ToList();
            // 18. Lấy danh sách phòng chỉ định
            var examinationCodes = heldClinics.Select(s => s.ExaminationExtendId).Distinct();
            var departmentCodeTrans = heldClinics.Select(x => x.DepartmentExtendId).Distinct();


            // 19 Lấy phòng ảo
            var roomCodes = departmentServiceList.Where(x => examinationCodes.Any(e => e == x.ExaminationId)).Select(x => x.RoomId).ToList();

            // 20. Lấy master data
            var masterCodeTemps = new List<Guid>();
            masterCodeTemps.AddRange(serviceIds);
            masterCodeTemps.AddRange(departmentServiceListCodes);
            masterCodeTemps.AddRange(roomCodes);
            masterCodeTemps.AddRange(commonServiceCodes);
            masterCodeTemps.AddRange(examinationCodes);
            var masterCodes = masterCodeTemps.Distinct();
            var masterList = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(l => masterCodes.Any(m => m == l.Id)).AsNoTracking().ToListAsync();

            var newServices = new List<ServiceJson>();
            var receptionJsons = new List<ReceptionsJson>();

            // 21. Duyệt tất cả số tiếp nhận
            foreach (var reception in receptions)
            {
                var receptionJson = new ReceptionsJson();
                var departmentJson = new DepartmentJson()
                {
                    RegisteredCode = reception.RegisteredCode,
                    Data = new List<NumberData>()
                };

                // // var transactionInfo = transactionInfos.Where(x => x.RegisteredCode == reception.RegisteredCode).ToList();

                // // // 22. Lấy tất cả giao dịch theo số tiếp nhận và gom nhóm theo (phòng chỉ định, phòng thực hiện, dịch vụ)
                // // var transactionClinicItems = transactionClinicList.Where(t => transactionInfo.Any(tranInfo => t.TransactionInfoId == tranInfo.Id));
                // // var clinicItems = heldClinics.Where(clinic => transactionClinicItems.Any(
                // //                                             transactionClinic => clinic.IdSpecified == transactionClinic.IdSpecified))
                // //                                 .GroupBy(i => new { i.DepartmentExtendId, i.ExaminationExtendId, i.ServiceExtendId, i.IdSpecified });

                // var transactionInfo = transactionInfos.Where(x => x.RegisteredCode == reception.RegisteredCode).ToList();

                // 22. Lấy tất cả giao dịch theo số tiếp nhận và gom nhóm theo (phòng chỉ định, phòng thực hiện, dịch vụ)
                // var transactionClinicItems = transactionClinicList.Where(t => transactionInfo.Any(tranInfo => t.TransactionInfoId == tranInfo.Id));
                var clinicItems = heldClinics.Where(clinic => clinic.ReceptionId == reception.Id)
                                                .GroupBy(i => new { i.DepartmentExtendId, i.ExaminationExtendId, i.ServiceExtendId, i.IdSpecified });
                foreach (var transactionClinicItem in clinicItems)
                {
                    //22.1 Tìm thấy phòng chờ theo nhóm
                    var departmentService = departmentServiceList.Where(x =>
                        transactionClinicItem.Key.ServiceExtendId == x.ServiceId).FirstOrDefault();

                    if (departmentService != null)
                    {
                        var numberData = new NumberData();
                        numberData.DepartmentCode = departmentService.Room?.Code;
                        numberData.DepartmentName = masterList.FirstOrDefault(m => m.Id == departmentService.RoomId)?.Description;
                        numberData.DepartmentId = departmentService.RoomId;


                        var queueNumberList = await _unitOfWork.GetRepository<QueueNumber>()
                            .GetAll()
                            .Where(l => roomCodes.Any(m => m == l.DepartmentExtendId)).ToListAsync();
                        var existNumber = queueNumberList.FirstOrDefault(q => departmentService.RoomId == q.DepartmentExtendId
                        && q.PatientId == patientInfo.Id
                        && q.CreatedDate.Date == DateTime.Now.Date);

                        if (existNumber == null) // chưa có STT
                        {
                            var entity = new QueueNumber();
                            entity.Type = patientInfo.PatientType;

                            var departmentConfig = _unitOfWork.GetRepository<DepartmentConfig>().GetAll()
                                .Where(x => x.DepartmentId == departmentService.RoomId)
                                .FirstOrDefault();

                            if (departmentConfig == null)
                                throw new Exception("Không tìm thấy cấu hình phòng khám");

                            var countQueueNumbers = _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                .Where(x => x.DepartmentExtendId == departmentService.RoomId && x.CreatedDate.Date == DateTime.Now.Date)
                                .Count();

                            // Trả respone để in bill hẹn khám
                            if (countQueueNumbers >= departmentConfig.TotalNumber)
                            {
                                entity.DepartmentCode = departmentService.Room.Code;
                                entity.Patient = patientInfo;
                                entity.PatientId = patientInfo.Id;
                                //entity.PatientCode = patientInfo.Code;
                                entity.Type = patientInfo.PatientType;
                                // STT mặc định khi hết lượt
                                entity.Number = -2;
                                entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
                                entity.DepartmentExtendId = departmentService.RoomId;

                                _unitOfWork.GetRepository<QueueNumber>().Add(entity);
                                await _unitOfWork.CommitAsync();

                                foreach (var item in transactionClinicItem)
                                {
                                    receptionJson.ExaminationCode = item.ExaminationCode;
                                    receptionJson.ExaminationId = item.ExaminationExtendId;
                                    var serviceJson = new ServiceJson()
                                    {
                                        IdSpecified = item.IdSpecified,
                                        DepartmentCode = numberData.DepartmentCode,
                                        ServiceCode = item.ServiceExtend.Code,
                                        IsFinished = (finishedIds.FirstOrDefault(x => x == item.IdSpecified) != null) ? "1" : "0",
                                        ServiceName = masterList.FirstOrDefault(x => x.Id == item.ServiceExtendId)?.Description
                                    };
                                    numberData.Services.Add(serviceJson);
                                }

                                numberData.Number = entity.Number;
                                departmentJson.Data.Add(numberData);

                                continue;
                            }
                            // Trường hợp còn lượt khám trong ngày
                            var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentExtendId == departmentService.RoomId);

                            if (entity.Type == PatientType.Normal)
                            {
                                predicate = predicate.And(q => q.Type == PatientType.Normal);
                            }
                            else
                            {
                                predicate = predicate.And(q => q.Type != PatientType.Normal);
                            }

                            var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                .OrderByDescending(c => c.Number)
                                .FirstOrDefaultAsync(predicate);

                            entity.DepartmentCode = departmentService.Room.Code;
                            entity.Patient = patientInfo;
                            entity.PatientId = patientInfo.Id;
                            //entity.PatientCode = patientInfo.Code;
                            entity.Type = patientInfo.PatientType;
                            entity.Number = last != null ? last.Number + 1 : 1;
                            if (last != null && last.Number == -1)
                            {
                                entity.Number = last != null ? last.Number + 2 : 1;
                            }

                            entity.AreaCode = _hospitalSettings.Hospital.HospitalArea;
                            entity.DepartmentExtendId = departmentService.RoomId;

                            _unitOfWork.GetRepository<QueueNumber>().Add(entity);
                            await _unitOfWork.CommitAsync();

                            foreach (var item in transactionClinicItem)
                            {
                                receptionJson.ExaminationCode = item.ExaminationCode;
                                receptionJson.ExaminationId = item.ExaminationExtendId;
                                var serviceJson = new ServiceJson()
                                {
                                    IdSpecified = item.IdSpecified,
                                    DepartmentCode = numberData.DepartmentCode,
                                    ServiceCode = item.ServiceId,
                                    IsFinished = (finishedIds.FirstOrDefault(x => x == item.IdSpecified) != null) ? "1" : "0",
                                    ServiceName = masterList.FirstOrDefault(x => x.Id == item.ServiceExtendId)?.Description
                                };
                                numberData.Services.Add(serviceJson);
                            }

                            numberData.Number = entity.Number;
                            departmentJson.Data.Add(numberData);
                        }
                        else // Đã tồn tại STT
                        {
                            // Trường hợp đã hết lượt
                            if (existNumber.Number == -2)
                            {
                                foreach (var item in transactionClinicItem)
                                {
                                    receptionJson.ExaminationCode = item.ExaminationCode;
                                    receptionJson.ExaminationId = item.ExaminationExtendId;
                                    var serviceJson = new ServiceJson()
                                    {
                                        IdSpecified = item.IdSpecified,
                                        DepartmentCode = numberData.DepartmentCode,
                                        ServiceCode = item.ServiceId,
                                        IsFinished = (finishedIds.FirstOrDefault(x => x == item.IdSpecified) != null) ? "1" : "0",
                                        ServiceName = masterList.FirstOrDefault(x => x.Id == item.ServiceExtendId)?.Description
                                    };
                                    numberData.Services.Add(serviceJson);
                                }

                                numberData.Number = existNumber.Number;
                                departmentJson.Data.Add(numberData);
                                continue;
                            }

                            // Trường hợp đã có hẹn
                            if (existNumber.Number == -1)
                            {
                                var predicate = PredicateBuilder.Create<QueueNumber>(q => q.DepartmentExtendId == existNumber.DepartmentExtendId);
                                if (patientInfo.PatientType == PatientType.Normal)
                                {
                                    predicate = predicate.And(q => q.Type == PatientType.Normal);
                                }
                                else
                                {
                                    predicate = predicate.And(q => q.Type != PatientType.Normal);
                                }

                                var last = await _unitOfWork.GetRepository<QueueNumber>().GetAll()
                                    .OrderByDescending(c => c.Number)
                                    .FirstOrDefaultAsync(predicate);

                                // Nếu số hẹn là -1 => + 2
                                if (last != null && last.Number == -1)
                                {
                                    existNumber.Number = last != null ? last.Number + 2 : 1;
                                }
                                else
                                {
                                    existNumber.Number = last != null ? last.Number + 1 : 1;
                                }

                                _unitOfWork.GetRepository<QueueNumber>().Update(existNumber);
                                await _unitOfWork.CommitAsync();
                            }

                            foreach (var item in transactionClinicItem)
                            {
                                receptionJson.ExaminationCode = item.ExaminationCode;
                                receptionJson.ExaminationId = item.ExaminationExtendId;
                                var serviceJson = new ServiceJson()
                                {
                                    IdSpecified = item.IdSpecified,
                                    DepartmentCode = numberData.DepartmentCode,
                                    ServiceCode = item.ServiceId,
                                    IsFinished = (finishedIds.FirstOrDefault(x => x == item.IdSpecified) != null) ? "1" : "0",
                                    ServiceName = masterList.FirstOrDefault(x => x.Id == item.ServiceExtendId)?.Description
                                };
                                numberData.Services.Add(serviceJson);
                            }
                            numberData.Number = existNumber.Number;
                            departmentJson.Data.Add(numberData);
                        }
                    }
                }

                // Gộp những dịch vụ cùng phòng
                departmentJson.Data = departmentJson.Data.GroupBy(dep => new { dep.DepartmentId, dep.DepartmentCode, dep.DepartmentName, dep.Number })
                        .Select(grp => new NumberData
                        {
                            DepartmentCode = grp.Key.DepartmentCode,
                            DepartmentName = grp.Key.DepartmentName,
                            DepartmentId = grp.Key.DepartmentId,
                            Number = grp.Key.Number,
                            Services = grp.SelectMany(dep => dep.Services).Distinct().ToList()
                        }).ToList();

                receptionJson.RegisteredDate = reception.RegisteredDate;
                receptionJson.Departments = departmentJson;
                receptionJson.ExaminationType = reception.PatientType;
                receptionJson.ExaminationName = masterList.FirstOrDefault(m => m.Id == receptionJson.ExaminationId)?.Description;
                responses.Receptions.Add(receptionJson);
            }

            if (responses.Receptions.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundServiceInDepartment);
            }

            return responses;
        }
    }
}