// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PaymentService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AutoMapper;
using CS.Common.Common;
using CS.Common.Enums;
using CS.Common.Extensions;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.PaymentModels.Models;
using CS.VM.PaymentModels.Requests;
using CS.VM.Requests;
using CS.VM.Responses;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Admin.API.Domain.Models.Requests;
using TEK.Core.Models;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using TEK.Gateway.Domain.BusinessObjects;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    /// <summary>
    /// Class PaymentService.
    /// Implements the <see cref="CS.Abstractions.IServices.IPaymentService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IPaymentService" />
    public class TransactionService : ITransactionService
    {
        /// <summary>
        /// Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        /// The unit of work
        /// </summary>
        public readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The mapper
        /// </summary>
        public readonly IMapper _mapper;

        private readonly IHttpClientFactory _clientFactory;

        private readonly ExternalSettings _externalSettings;

        private readonly ILogger<TransactionService> _logger;
        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService" /> class.
        /// </summary>
        /// <param name="externalSystemService">The external system service.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public TransactionService(
            IHospitalSystemService externalSystemService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpClientFactory clientFactory,
            ExternalSettings externalSettings,
            IAuditLogService auditLogService,
            ILogger<TransactionService> logger,
            IConfiguration configuration)
        {
            _hospitalSystemService = externalSystemService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clientFactory = clientFactory;
            _externalSettings = externalSettings;
            _logger = logger;
            _configuration = configuration;
        }

        #region -- Base Method --
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public TransactionInfo Add(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TransactionInfo> AddAsync(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<TransactionInfo>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(TransactionInfo entity)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<TransactionInfo>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public TransactionInfo Find(Expression<Func<TransactionInfo, bool>> match)
        {
            return _unitOfWork.GetRepository<TransactionInfo>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TransactionInfo> FindAll(Expression<Func<TransactionInfo, bool>> match)
        {
            return _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TransactionInfo>> FindAllAsync(Expression<Func<TransactionInfo, bool>> match)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TransactionInfo> FindAsync(Expression<Func<TransactionInfo, bool>> match)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public TransactionInfo Get(Guid id)
        {
            return _unitOfWork.GetRepository<TransactionInfo>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TransactionInfo> GetAll()
        {
            return _unitOfWork.GetRepository<TransactionInfo>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TransactionInfo>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TransactionInfo> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<TransactionInfo>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TransactionInfo.</returns>
        public TransactionInfo Update(TransactionInfo entity, Guid id)
        {
            if (entity == null)
                return null;

            TransactionInfo existing = _unitOfWork.GetRepository<TransactionInfo>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TransactionInfo>().Update(entity);
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
        /// TransactionInfo.
        /// </returns>
        public async Task<TransactionInfo> UpdateAsync(TransactionInfo entity, Guid id)
        {
            if (entity == null)
                return null;

            TransactionInfo existing = await _unitOfWork.GetRepository<TransactionInfo>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TransactionInfo>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }

        #endregion

        #region Service Admin
        public string GetNote(TekmediCardCashFlowPrepareData transaction, TekmediCardCashFlowPrepareData cancelledTransaction)
        {
            var note = "";
            var diffStr = "";
            var diffAmount = transaction.PatientPaymentAmount - cancelledTransaction.PatientPaymentAmount;
            if (diffAmount > 0)
            {
                diffStr = "Tăng";
            }
            else if (diffAmount < 0)
            {
                diffStr = "Giảm";
            }
            else
            {
                diffStr = "Bằng";
            }

            note = $"HĐ này điều chỉnh {diffStr} thay cho HĐ {cancelledTransaction.SerialNo}-{cancelledTransaction.RecvNo}, " +
                $"ngày {cancelledTransaction.CreatedDate.ToString("dd/MM/yyyy")}.";
            return note;
        }

        /// <summary>
        /// Gets the transaction report.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Task&lt;TableResultJsonResponse&lt;TransactionReportViewModel&gt;&gt;.
        /// </returns>
        /// <exception cref="Exception">Transactions not found
        /// or
        /// Clinics not found
        /// or
        /// Patients not found</exception>
        public async Task<TableResultJsonResponse<TekmediCardCashflowExportViewModel>> GetTransactionReport(TransactionReportRequest request)
        {
            var result = new TableResultJsonResponse<TekmediCardCashflowExportViewModel>();
            var patientCode = request.PatientCode.Trim();
            var patientName = request.PatientName.Trim().ToLower();
            var orderValue = "";
            if (request.Order != null && request.Order.Length > 0)
            {
                orderValue = request.Order[0].Dir.Trim().ToLower();
            }

            var employee = await _unitOfWork.GetRepository<SysUser>().GetAll().FirstOrDefaultAsync(x => x.Id == request.EmployeeId);
            if (employee == null)
            {
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            var paymentResultList = new List<TransactionInfo>();
            var cancelledPaymentResultList = new List<TransactionInfo>();
            var cashFlowResult = new List<TekmediCardCashFlowPrepareData>();
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var startDateStr = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
            var endDateStr = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
            DateTime.TryParseExact(startDateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            DateTime.TryParseExact(endDateStr, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (request.AdminView)
            {
                paymentResultList = await _unitOfWork.GetRepository<TransactionInfo>().GetAll().AsNoTracking()
                    .Include(x => x.Patient)
                    .Include(x => x.Employee)
                    .Include(x => x.Reception)
                    .Where(t => t.Type == TransactionType.Paid
                        && t.Status == TransactionStatus.Success
                        && t.CreatedDate >= startDate && t.CreatedDate <= endDate)
                    .ToListAsync();

                cancelledPaymentResultList = await _unitOfWork.GetRepository<TransactionInfo>().GetAll().AsNoTracking()
                    .Include(x => x.Patient)
                    .Include(x => x.Employee)
                    .Include(x => x.Reception)
                    .Where(t => t.Type == TransactionType.Cancelled
                        && t.Status == TransactionStatus.Success
                        && t.CreatedDate >= startDate && t.CreatedDate <= endDate)
                    .ToListAsync();
            }
            else
            {
                paymentResultList = await _unitOfWork.GetRepository<TransactionInfo>().GetAll().AsNoTracking()
                    .Include(x => x.Patient)
                    .Include(x => x.Employee)
                    .Include(x => x.Reception)
                    .Where(t => t.Type == TransactionType.Paid
                        && t.Status == TransactionStatus.Success
                        && t.CreatedDate >= startDate && t.CreatedDate <= endDate
                        && t.EmployeeId == employee.Id)
                    .ToListAsync();

                cancelledPaymentResultList = await _unitOfWork.GetRepository<TransactionInfo>().GetAll().AsNoTracking()
                    .Include(x => x.Patient)
                    .Include(x => x.Employee)
                    .Include(x => x.Reception)
                    .Where(t => t.Type == TransactionType.Cancelled
                        && t.Status == TransactionStatus.Success
                        && t.CreatedDate >= startDate && t.CreatedDate <= endDate
                        && t.EmployeeId == employee.Id)
                    .ToListAsync();
            }

            if (request.PatientType == TransactionReportPatientType.BHYT)
            {
                paymentResultList = paymentResultList
                    .Where(x => x.Reception?.IsFinished == true
                        && x.Reception?.PatientType == "Bảo hiểm")
                    .ToList();

                cancelledPaymentResultList = cancelledPaymentResultList
                    .Where(x => x.Reception?.PatientType == "Bảo hiểm")
                    .ToList();
            }
            else if (request.PatientType == TransactionReportPatientType.DV)
            {
                paymentResultList = paymentResultList
                    .Where(x => x.Reception?.IsFinished == true
                        && x.Reception?.PatientType == "Dịch vụ")
                    .ToList();

                cancelledPaymentResultList = cancelledPaymentResultList
                    .Where(x => x.Reception?.PatientType == "Dịch vụ")
                    .ToList();
            }
            else
            {
                paymentResultList = paymentResultList.Where(x => x.Reception?.IsFinished == true).ToList();
            }

            foreach (var paymentResult in paymentResultList)
            {
                cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                {
                    RowNumber = $"{paymentResult.SerialNo}-{paymentResult.RecvNo}",
                    TekmediCardNumber = paymentResult.Patient?.TekmediCardNumber,
                    PatientCode = paymentResult.Patient?.Code,
                    PatientName = paymentResult.Patient?.LastName + " " + paymentResult.Patient?.FirstName,
                    Gender = paymentResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                    BirthDate = paymentResult.Patient?.Birthday?.Year.ToString(),
                    AdvancePaymentAmount = 0,
                    TotalFee = paymentResult.TotalFee.HasValue ? paymentResult.TotalFee.Value : 0,
                    PatientPaymentAmount = paymentResult.Amount,
                    InsurancePaymentAmount = paymentResult.InsuranceFee.HasValue ? paymentResult.InsuranceFee.Value : 0,
                    RefundPaymentAmount = 0,
                    LostPaymentAmount = 0,
                    CancelAdvancePaymentAmount = 0,
                    EmployeeUserName = paymentResult.Employee?.UserName,
                    EmployeeName = paymentResult.Employee?.FullName,
                    TransactionDate = paymentResult.CreatedDate.Date,
                    Type = TekmediCardCashFlowPrepareDataEnum.Payment,
                    RegisteredCode = paymentResult.RegisteredCode,
                    RecvNo = paymentResult.RecvNo.HasValue ? paymentResult.RecvNo.Value : 0,
                    SerialNo = paymentResult.SerialNo,
                    CreatedDate = paymentResult.CreatedDate,
                    TransactionInfoId = paymentResult.Id,
                    CancelledTransactionInfoId = paymentResult.CancelledTransactionInfoId
                });
            }

            foreach (var cancelledPaymentResult in cancelledPaymentResultList)
            {
                cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                {
                    RowNumber = $"{cancelledPaymentResult.SerialNo}-{cancelledPaymentResult.RecvNo}",
                    TekmediCardNumber = cancelledPaymentResult.Patient?.TekmediCardNumber,
                    PatientCode = cancelledPaymentResult.Patient?.Code,
                    PatientName = cancelledPaymentResult.Patient?.LastName + " " + cancelledPaymentResult.Patient?.FirstName,
                    Gender = cancelledPaymentResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                    BirthDate = cancelledPaymentResult.Patient?.Birthday?.Year.ToString(),
                    AdvancePaymentAmount = 0,
                    TotalFee = cancelledPaymentResult.TotalFee.HasValue ? cancelledPaymentResult.TotalFee.Value : 0,
                    PatientPaymentAmount = cancelledPaymentResult.Amount,
                    InsurancePaymentAmount = cancelledPaymentResult.InsuranceFee.HasValue ? cancelledPaymentResult.InsuranceFee.Value : 0,
                    RefundPaymentAmount = 0,
                    LostPaymentAmount = 0,
                    CancelAdvancePaymentAmount = 0,
                    EmployeeUserName = cancelledPaymentResult.Employee?.UserName,
                    EmployeeName = cancelledPaymentResult.Employee?.FullName,
                    TransactionDate = cancelledPaymentResult.CreatedDate.Date,
                    Type = TekmediCardCashFlowPrepareDataEnum.PaymentCancel,
                    RegisteredCode = cancelledPaymentResult.RegisteredCode,
                    RecvNo = cancelledPaymentResult.RecvNo.HasValue ? cancelledPaymentResult.RecvNo.Value : 0,
                    SerialNo = cancelledPaymentResult.SerialNo,
                    CreatedDate = cancelledPaymentResult.CreatedDate,
                    TransactionInfoId = cancelledPaymentResult.Id,
                    CancelledTransactionInfoId = cancelledPaymentResult.CancelledTransactionInfoId
                });
            }

            var validRegisterCodeByPayment = cashFlowResult.Select(x => x.RegisteredCode).ToList();

            var advancePaymentResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.Recharged
                    && t.Status == StatusEnum.Success)
                .ToListAsync();

            foreach (var advancePaymentResult in advancePaymentResultList)
            {
                if (validRegisterCodeByPayment.Contains(advancePaymentResult.RegisterCode))
                {
                    cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                    {
                        RowNumber = $"{advancePaymentResult.SerialNo}-{advancePaymentResult.RecvNo}",
                        TekmediCardNumber = advancePaymentResult.TekmediCardNumber,
                        PatientCode = advancePaymentResult.Patient?.Code,
                        PatientName = advancePaymentResult.Patient?.LastName + " " + advancePaymentResult.Patient?.FirstName,
                        Gender = advancePaymentResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                        BirthDate = advancePaymentResult.Patient?.Birthday?.Year.ToString(),
                        AdvancePaymentAmount = advancePaymentResult.Amount.HasValue ? advancePaymentResult.Amount.Value : 0,
                        TotalFee = 0,
                        PatientPaymentAmount = 0,
                        InsurancePaymentAmount = 0,
                        RefundPaymentAmount = 0,
                        LostPaymentAmount = 0,
                        CancelAdvancePaymentAmount = 0,
                        EmployeeUserName = advancePaymentResult.Employee?.UserName,
                        TransactionDate = advancePaymentResult.Time.Date,
                        Type = TekmediCardCashFlowPrepareDataEnum.AdvancePayment,
                        RegisteredCode = advancePaymentResult.RegisterCode,
                        RecvNo = int.MaxValue,
                        SerialNo = advancePaymentResult.SerialNo,
                        CreatedDate = advancePaymentResult.Time,
                        Id = advancePaymentResult.Id
                    });
                }
            }

            var extraFeeResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.ExtraFee
                    && t.Status == StatusEnum.Success)
                .ToListAsync();

            var cancelExtraFeeResultList = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.CancelExtraFee
                    && t.Status == StatusEnum.Success)
                .ToListAsync();
            if (cancelExtraFeeResultList.Count > 0)
            {
                var ids = cancelExtraFeeResultList.Select(x => x.TekmediCardHistoryId).ToList();
                extraFeeResultList = extraFeeResultList.Where(x => ids.Contains(x.Id) == false).ToList();
            }

            var cancelPaymentHistoryList = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.CancelPayment
                    && t.Status == StatusEnum.Success)
                .ToListAsync();

            foreach (var extraFeeResult in extraFeeResultList)
            {
                if (validRegisterCodeByPayment.Contains(extraFeeResult.RegisterCode))
                {
                    cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                    {
                        RowNumber = $"{extraFeeResult.SerialNo}-{extraFeeResult.RecvNo}",
                        TekmediCardNumber = extraFeeResult.TekmediCardNumber,
                        PatientCode = extraFeeResult.Patient?.Code,
                        PatientName = extraFeeResult.Patient?.LastName + " " + extraFeeResult.Patient?.FirstName,
                        Gender = extraFeeResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                        BirthDate = extraFeeResult.Patient?.Birthday?.Year.ToString(),
                        AdvancePaymentAmount = 0,
                        TotalFee = 0,
                        PatientPaymentAmount = 0,
                        InsurancePaymentAmount = 0,
                        RefundPaymentAmount = 0,
                        LostPaymentAmount = 0,
                        CancelAdvancePaymentAmount = 0,
                        EmployeeUserName = extraFeeResult.Employee?.UserName,
                        TransactionDate = extraFeeResult.Time.Date,
                        Type = TekmediCardCashFlowPrepareDataEnum.ExtraFee,
                        RegisteredCode = extraFeeResult.RegisterCode,
                        RecvNo = int.MaxValue,
                        SerialNo = extraFeeResult.SerialNo,
                        ExtraFeeAmount = extraFeeResult.Amount.HasValue ? extraFeeResult.Amount.Value : 0,
                        CreatedDate = extraFeeResult.Time
                    });
                }
            }

            var cancelAdvancePaymentResultList = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.Cancel
                      && t.Status == StatusEnum.Success)
                .ToListAsync();

            foreach (var cancelAdvancePaymentResult in cancelAdvancePaymentResultList)
            {
                if (validRegisterCodeByPayment.Contains(cancelAdvancePaymentResult.RegisterCode))
                {
                    cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                    {
                        RowNumber = $"{cancelAdvancePaymentResult.SerialNo}-{cancelAdvancePaymentResult.RecvNo}",
                        TekmediCardNumber = cancelAdvancePaymentResult.TekmediCardNumber,
                        PatientCode = cancelAdvancePaymentResult.Patient?.Code,
                        PatientName = cancelAdvancePaymentResult.Patient?.LastName + " " + cancelAdvancePaymentResult.Patient?.FirstName,
                        Gender = cancelAdvancePaymentResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                        BirthDate = cancelAdvancePaymentResult.Patient?.Birthday?.Year.ToString(),
                        CancelAdvancePaymentAmount = cancelAdvancePaymentResult.Amount.HasValue ? cancelAdvancePaymentResult.Amount.Value : 0,
                        AdvancePaymentAmount = 0,
                        TotalFee = 0,
                        PatientPaymentAmount = 0,
                        InsurancePaymentAmount = 0,
                        RefundPaymentAmount = 0,
                        LostPaymentAmount = 0,
                        EmployeeUserName = cancelAdvancePaymentResult.Employee?.UserName,
                        TransactionDate = cancelAdvancePaymentResult.Time.Date,
                        Type = TekmediCardCashFlowPrepareDataEnum.AdvancePaymentCancel,
                        RegisteredCode = cancelAdvancePaymentResult.RegisterCode,
                        RecvNo = int.MaxValue,
                        SerialNo = cancelAdvancePaymentResult.SerialNo,
                        TekmediCardHistoryId = cancelAdvancePaymentResult.TekmediCardHistoryId,
                        CreatedDate = cancelAdvancePaymentResult.Time
                    });
                }
            }

            var refundResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.Return
                    && t.Status == StatusEnum.Success)
                .ToListAsync();

            foreach (var refundResult in refundResultList)
            {
                if (validRegisterCodeByPayment.Contains(refundResult.RegisterCode))
                {
                    cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                    {
                        RowNumber = $"{refundResult.SerialNo}-{refundResult.RecvNo}",
                        TekmediCardNumber = refundResult.TekmediCardNumber,
                        PatientCode = refundResult.Patient?.Code,
                        PatientName = refundResult.Patient?.LastName + " " + refundResult.Patient?.FirstName,
                        Gender = refundResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                        BirthDate = refundResult.Patient?.Birthday?.Year.ToString(),
                        AdvancePaymentAmount = 0,
                        TotalFee = 0,
                        PatientPaymentAmount = 0,
                        InsurancePaymentAmount = 0,
                        RefundPaymentAmount = refundResult.Amount.HasValue ? refundResult.Amount.Value : 0,
                        LostPaymentAmount = 0,
                        CancelAdvancePaymentAmount = 0,
                        EmployeeUserName = refundResult.Employee?.UserName,
                        TransactionDate = refundResult.Time.Date,
                        Type = TekmediCardCashFlowPrepareDataEnum.Refund,
                        RegisteredCode = refundResult.RegisterCode,
                        RecvNo = int.MaxValue,
                        SerialNo = refundResult.SerialNo,
                        CreatedDate = refundResult.Time
                    });
                }
            }

            var lostResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.CardFee
                    && t.Status == StatusEnum.Success)
                .ToListAsync();

            foreach (var lostResult in lostResultList)
            {
                if (validRegisterCodeByPayment.Contains(lostResult.RegisterCode))
                {
                    cashFlowResult.Add(new TekmediCardCashFlowPrepareData
                    {
                        RowNumber = $"{lostResult.SerialNo}-{lostResult.RecvNo}",
                        TekmediCardNumber = lostResult.TekmediCardNumber,
                        PatientCode = lostResult.Patient?.Code,
                        PatientName = lostResult.Patient?.LastName + " " + lostResult.Patient?.FirstName,
                        Gender = lostResult.Patient?.Gender == Gender.Male ? "Nam" : "Nữ",
                        BirthDate = lostResult.Patient?.Birthday?.Year.ToString(),
                        AdvancePaymentAmount = 0,
                        TotalFee = 0,
                        PatientPaymentAmount = 0,
                        InsurancePaymentAmount = 0,
                        RefundPaymentAmount = 0,
                        CancelAdvancePaymentAmount = 0,
                        LostPaymentAmount = lostResult.Amount.HasValue ? lostResult.Amount.Value : 0,
                        EmployeeUserName = lostResult.Employee?.UserName,
                        TransactionDate = lostResult.Time.Date,
                        Type = TekmediCardCashFlowPrepareDataEnum.Lost,
                        RegisteredCode = lostResult.RegisterCode,
                        RecvNo = int.MaxValue,
                        SerialNo = lostResult.SerialNo,
                        CreatedDate = lostResult.Time
                    });
                }
            }

            foreach (var cashFlowItem in cashFlowResult)
            {
                // Lấy TekmediCardNumber cho giao dịch tất toán, trường hợp BN trả thẻ sau khi tất toán
                if (string.IsNullOrEmpty(cashFlowItem.TekmediCardNumber))
                {
                    // Lấy ra giao dịch có TekmediCardNumber, có ngày gần nhất và nhỏ hơn ngày của giao dịch tất toán
                    var cashFlowItemHasTekmediCardNumber = cashFlowResult
                        .Where(x => x.PatientCode == cashFlowItem.PatientCode
                            && x.TekmediCardNumber != null
                            && x.TekmediCardNumber != ""
                            && x.TransactionDate.Date <= cashFlowItem.TransactionDate.Date)
                        .OrderByDescending(x => x.TransactionDate).FirstOrDefault();

                    if (cashFlowItemHasTekmediCardNumber != null)
                    {
                        cashFlowItem.TekmediCardNumber = cashFlowItemHasTekmediCardNumber.TekmediCardNumber;
                    }
                }
            }

            var groups = cashFlowResult
                .Where(x => x.Type != TekmediCardCashFlowPrepareDataEnum.PaymentCancel)
                .GroupBy(i => new
                {
                    i.RegisteredCode,
                    i.PatientCode,
                    i.PatientName,
                    i.Gender,
                    i.BirthDate
                },
                  (key, g) => new
                  {
                      RegisteredCode = key.RegisteredCode,
                      PatientCode = key.PatientCode,
                      PatientName = key.PatientName,
                      Gender = key.Gender,
                      BirthDate = key.BirthDate,
                      TransactionDate = g.Where(x => x.RegisteredCode == key.RegisteredCode)
                        .OrderByDescending(x => x.TransactionDate).FirstOrDefault()?.TransactionDate,
                      Historys = g.ToList()
                  });

            var listResult = new List<TekmediCardCashflowExportViewModel>();
            int indexRow = 1;
            foreach (var groupItem in groups)
            {
                decimal diffAmount = 0;
                string time = "";
                string note = "";
                var historyCancelIds = groupItem.Historys
                    .Where(x => x.Type == TekmediCardCashFlowPrepareDataEnum.AdvancePaymentCancel)
                    .Select(x => x.TekmediCardHistoryId)
                    .ToList();

                decimal advancePaymentAmount = groupItem.Historys
                    .Where(x => x.Type == TekmediCardCashFlowPrepareDataEnum.AdvancePayment
                        && historyCancelIds.Contains(x.Id) == false)
                    .Select(h => h.AdvancePaymentAmount).Sum();

                decimal extraFeeAmount = 0;
                decimal totalRefundAmount = 0;
                decimal totalFeeAmount = groupItem.Historys.Select(x => x.TotalFee).Sum();
                decimal patientPaymentAmount = groupItem.Historys.Select(x => x.PatientPaymentAmount).Sum();
                decimal insurancePaymentAmount = groupItem.Historys.Select(x => x.InsurancePaymentAmount).Sum();
                decimal refundAmount = advancePaymentAmount - patientPaymentAmount;
                // Có thu tiếp
                if (refundAmount < 0)
                {
                    refundAmount = Math.Abs(refundAmount);
                    refundAmount = MathExtensions.Round((int)refundAmount, 1000);
                    extraFeeAmount = refundAmount;
                    refundAmount = 0;
                }
                // Hoàn lại
                else
                {
                    refundAmount = MathExtensions.Round((int)refundAmount, 1000);
                    totalRefundAmount = refundAmount;
                }

                decimal lostPayment = groupItem.Historys.Select(x => x.LostPaymentAmount).Sum();
                var isReturnedCard = cashFlowResult.Any(x => x.RegisteredCode == groupItem.RegisteredCode && x.Type == TekmediCardCashFlowPrepareDataEnum.Refund);
                var cardAmount = refundAmount;
                if (cardAmount < 0)
                {
                    cardAmount = 0;
                }

                cardAmount = MathExtensions.Round((int)cardAmount, 1000);
                decimal alreadyReturnPatientPaidAmount = 0;
                decimal notYetReturnPatientPaidAmount = 0;

                if (isReturnedCard)
                {
                    alreadyReturnPatientPaidAmount = cardAmount;
                }
                else
                {
                    notYetReturnPatientPaidAmount = cardAmount;
                }

                string rowNumber = "";
                var rowNumberItem = groupItem.Historys.FirstOrDefault(x => x.Type == TekmediCardCashFlowPrepareDataEnum.Payment && x.RegisteredCode == groupItem.RegisteredCode);
                // Khi hủy tất toán mà chưa tất toán lại thì dư record -0-0
                if (rowNumberItem == null)
                {
                    continue;
                }

                var transactionInfoId = Guid.Empty;
                if (rowNumberItem != null)
                {
                    if (rowNumberItem.RowNumber != "--")
                    {
                        rowNumber = rowNumberItem.RowNumber;
                    }
                    else
                    {
                        rowNumber = "";
                    }

                    transactionInfoId = rowNumberItem.TransactionInfoId;
                    time = rowNumberItem.CreatedDate.ToString("dd/MM/yyyy HH:mm");
                    // Lấy ra giao dịch đã hủy
                    if (rowNumberItem.CancelledTransactionInfoId.HasValue)
                    {
                        var cancelledTransaction = cashFlowResult.Where(x => x.TransactionInfoId == rowNumberItem.CancelledTransactionInfoId.Value).FirstOrDefault();
                        if (cancelledTransaction != null)
                        {
                            diffAmount = Math.Abs(rowNumberItem.PatientPaymentAmount - cancelledTransaction.PatientPaymentAmount);
                            note = GetNote(rowNumberItem, cancelledTransaction);
                        }
                    }
                }

                if (rowNumber == "")
                {
                    rowNumber = "-0-0";
                }

                listResult.Add(new TekmediCardCashflowExportViewModel
                {
                    RowNum = rowNumber,
                    RegisteredCode = groupItem.RegisteredCode,
                    PatientCode = groupItem.PatientCode,
                    PatientName = groupItem.PatientName,
                    BirthDate = groupItem.BirthDate,
                    Gender = groupItem.Gender,
                    TransactionDate = groupItem.TransactionDate,
                    AdvancePaymentAmount = MathExtensions.Round((int)advancePaymentAmount, 1000),
                    TotalFeeAmount = MathExtensions.Round((int)totalFeeAmount, 1000),
                    PatientPaymentAmount = MathExtensions.Round((int)patientPaymentAmount, 1000),
                    InsurancePaymentAmount = MathExtensions.Round((int)insurancePaymentAmount, 1000),
                    TotalRefundAmount = MathExtensions.Round((int)totalRefundAmount, 1000),
                    TotalLostAmount = MathExtensions.Round((int)lostPayment, 1000),
                    AlreadyReturnPatientPaidAmount = alreadyReturnPatientPaidAmount,
                    NotYetReturnPatientPaidAmount = notYetReturnPatientPaidAmount,
                    SerialNo = rowNumberItem == null ? string.Empty : rowNumberItem.SerialNo,
                    RecvNo = rowNumberItem == null ? 0 : rowNumberItem.RecvNo,
                    IsPaid = true,
                    DepartmentName = "Khoa khám bệnh",
                    ExtraFeeAmount = MathExtensions.Round((int)extraFeeAmount, 1000),
                    TransactionInfoId = transactionInfoId,
                    Type = TekmediCardCashFlowPrepareDataEnum.Payment,
                    DiffAmount = MathExtensions.Round((int)diffAmount, 1000),
                    Time = time,
                    Note = note,
                    CancelledTransactionInfoId = rowNumberItem.CancelledTransactionInfoId
                });

                indexRow++;
            }

            // Lấy data cho hủy tất toán
            var cancelledGroups = cashFlowResult
                .Where(x => x.Type == TekmediCardCashFlowPrepareDataEnum.PaymentCancel)
                .ToList();

            foreach (var groupItem in cancelledGroups)
            {
                var histories = cashFlowResult
                    .Where(x => x.Type != TekmediCardCashFlowPrepareDataEnum.PaymentCancel
                        && x.Type != TekmediCardCashFlowPrepareDataEnum.Payment
                        && x.RegisteredCode == groupItem.RegisteredCode)
                    .ToList();

                var time = groupItem.CreatedDate.ToString("dd/MM/yyyy HH:mm");
                var cancelPaymentHistory = cancelPaymentHistoryList.Where(x => x.TransactionInfoId == groupItem.TransactionInfoId).FirstOrDefault();
                if (cancelPaymentHistory != null)
                {
                    time = cancelPaymentHistory.Time.ToString("dd/MM/yyyy HH:mm");
                }

                // Lấy ra tạm ứng tạo trước khi hủy tất toán này
                var advancePaymentAmountHistories = histories
                    .Where(x => x.Type == TekmediCardCashFlowPrepareDataEnum.AdvancePayment
                        && x.CreatedDate <= groupItem.CreatedDate)
                    .ToList();
                var cancelAdvancePaymentAmountHistories = histories
                    .Where(x => x.Type == TekmediCardCashFlowPrepareDataEnum.AdvancePaymentCancel
                        && x.CreatedDate <= groupItem.CreatedDate)
                    .ToList();

                var advancePaymentAmount = advancePaymentAmountHistories.Select(h => h.AdvancePaymentAmount).Sum() - cancelAdvancePaymentAmountHistories.Select(h => h.CancelAdvancePaymentAmount).Sum();
                decimal extraFeeAmount = 0;
                decimal totalRefundAmount = 0;
                decimal refundAmount = advancePaymentAmount - groupItem.PatientPaymentAmount;
                // Có thu tiếp
                if (refundAmount < 0)
                {
                    refundAmount = Math.Abs(refundAmount);
                    refundAmount = MathExtensions.Round((int)refundAmount, 1000);
                    extraFeeAmount = refundAmount;
                    refundAmount = 0;
                }
                // Hoàn lại
                else
                {
                    refundAmount = MathExtensions.Round((int)refundAmount, 1000);
                    totalRefundAmount = refundAmount;
                }

                var lostPaymentAmount = histories.Select(x => x.LostPaymentAmount).Sum();
                var isReturnedCard = cashFlowResult.Any(x => x.RegisteredCode == groupItem.RegisteredCode && x.Type == TekmediCardCashFlowPrepareDataEnum.Refund);
                var cardAmount = refundAmount;
                if (cardAmount < 0)
                {
                    cardAmount = 0;
                }

                cardAmount = MathExtensions.Round((int)cardAmount, 1000);
                decimal alreadyReturnPatientPaidAmount = 0;
                decimal notYetReturnPatientPaidAmount = 0;
                if (isReturnedCard)
                {
                    alreadyReturnPatientPaidAmount = cardAmount;
                }
                else
                {
                    notYetReturnPatientPaidAmount = cardAmount;
                }

                listResult.Add(new TekmediCardCashflowExportViewModel
                {
                    RowNum = groupItem.RowNumber,
                    RegisteredCode = groupItem.RegisteredCode,
                    PatientName = groupItem.PatientName,
                    PatientCode = groupItem.PatientCode,
                    BirthDate = groupItem.BirthDate,
                    Gender = groupItem.Gender,
                    TransactionDate = groupItem.TransactionDate,
                    AdvancePaymentAmount = MathExtensions.Round((int)advancePaymentAmount, 1000),
                    TotalFeeAmount = MathExtensions.Round((int)groupItem.TotalFee, 1000),
                    PatientPaymentAmount = MathExtensions.Round((int)groupItem.PatientPaymentAmount, 1000),
                    InsurancePaymentAmount = MathExtensions.Round((int)groupItem.InsurancePaymentAmount, 1000),
                    TotalRefundAmount = MathExtensions.Round((int)totalRefundAmount, 1000),
                    TotalLostAmount = MathExtensions.Round((int)lostPaymentAmount, 1000),
                    AlreadyReturnPatientPaidAmount = alreadyReturnPatientPaidAmount,
                    NotYetReturnPatientPaidAmount = notYetReturnPatientPaidAmount,
                    SerialNo = groupItem.SerialNo,
                    RecvNo = groupItem.RecvNo,
                    IsPaid = true,
                    DepartmentName = "Khoa khám bệnh",
                    ExtraFeeAmount = extraFeeAmount,
                    Time = time,
                    Type = TekmediCardCashFlowPrepareDataEnum.PaymentCancel,
                    TypeName = "Hủy",
                    TransactionInfoId = groupItem.TransactionInfoId,
                    CancelledTransactionInfoId = groupItem.CancelledTransactionInfoId
                });
            }

            if (!string.IsNullOrEmpty(patientCode))
            {
                listResult = listResult.Where(x => x.PatientCode != null && x.PatientCode.ToLower().Contains(patientCode)).ToList();
            }

            if (!string.IsNullOrEmpty(patientName))
            {
                listResult = listResult.Where(x => x.PatientName.ToLower().Contains(patientName)).ToList();
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                listResult = listResult.Where(x => x.RegisteredCode == request.RegisteredCode).ToList();
            }

            listResult = listResult
                .OrderBy(x => x.TransactionDate)
                .ThenBy(x => x.SerialNo)
                .ThenBy(x => x.RecvNo).ToList();
            var totalRecord = listResult.Count;
            var data = listResult.Skip(request.Start).Take(request.Length).ToList();

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data;

            return result;
        }

        public async Task<TekmediCardCashflowExportViewModel> GetCancelledTransationDetail(Guid id)
        {
            var transaction = await _unitOfWork.GetRepository<TransactionInfo>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Include(x => x.Reception)
                .Where(t => t.Type == TransactionType.Cancelled
                    && t.Status == TransactionStatus.Success
                    && t.Id == id)
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new Exception("Không tìm thấy giao dịch hủy.");
            }

            var advancePaymentResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.Recharged
                    && t.Status == StatusEnum.Success
                    && t.RegisterCode == transaction.RegisteredCode)
                .ToListAsync();

            var cancelAdvancePaymentResultList = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.Cancel
                    && t.Status == StatusEnum.Success
                    && t.RegisterCode == transaction.RegisteredCode)
                .ToListAsync();

            var lostResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.CardFee
                    && t.Status == StatusEnum.Success
                    && t.RegisterCode == transaction.RegisteredCode)
                .ToListAsync();

            var cancelPaymentHistoryList = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.CancelPayment
                    && t.Status == StatusEnum.Success
                    && t.RegisterCode == transaction.RegisteredCode)
                .ToListAsync();

            var refundResultList = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Include(x => x.Patient)
                .Include(x => x.Employee)
                .Where(t => t.Type == TypeEnum.Return
                    && t.Status == StatusEnum.Success
                    && t.RegisterCode == transaction.RegisteredCode)
                .ToListAsync();

            var time = transaction.CreatedDate.ToString("dd/MM/yyyy HH:mm");
            var cancelPaymentHistory = cancelPaymentHistoryList.Where(x => x.TransactionInfoId == transaction.Id).FirstOrDefault();
            if (cancelPaymentHistory != null)
            {
                time = cancelPaymentHistory.Time.ToString("dd/MM/yyyy HH:mm");
            }

            // Lấy ra tạm ứng tạo trước khi hủy tất toán này
            var advancePaymentAmountHistories = advancePaymentResultList
                .Where(x => x.Time <= transaction.CreatedDate)
                .ToList();

            var cancelAdvancePaymentAmountHistories = cancelAdvancePaymentResultList
                .Where(x => x.Time <= transaction.CreatedDate)
                .ToList();

            var advancePaymentAmount = advancePaymentAmountHistories.Select(h => h.Amount).Sum() - cancelAdvancePaymentAmountHistories.Select(h => h.Amount).Sum();
            decimal extraFeeAmount = 0;
            decimal totalRefundAmount = 0;
            decimal refundAmount = advancePaymentAmount.Value - transaction.Amount;
            // Có thu tiếp
            if (refundAmount < 0)
            {
                refundAmount = Math.Abs(refundAmount);
                refundAmount = MathExtensions.Round((int)refundAmount, 1000);
                extraFeeAmount = refundAmount;
                refundAmount = 0;
            }
            // Hoàn lại
            else
            {
                refundAmount = MathExtensions.Round((int)refundAmount, 1000);
                totalRefundAmount = refundAmount;
            }

            decimal lostPaymentAmount = lostResultList.Select(x => x.Amount.Value).Sum();
            var isReturnedCard = refundResultList.Count > 0 ? true : false;
            var cardAmount = refundAmount - lostPaymentAmount;
            if (cardAmount < 0)
            {
                cardAmount = 0;
            }

            cardAmount = MathExtensions.Round((int)cardAmount, 1000);
            decimal alreadyReturnPatientPaidAmount = 0;
            decimal notYetReturnPatientPaidAmount = 0;
            if (isReturnedCard)
            {
                alreadyReturnPatientPaidAmount = cardAmount;
            }
            else
            {
                notYetReturnPatientPaidAmount = cardAmount;
            }

            var response = new TekmediCardCashflowExportViewModel();
            response.RowNum = $"{transaction.SerialNo}-{transaction.RecvNo}";
            response.RegisteredCode = transaction.RegisteredCode;
            response.PatientName = transaction.Patient?.LastName + " " + transaction.Patient?.FirstName;
            response.PatientCode = transaction.PatientCode;
            response.BirthDate = transaction.Patient?.Birthday?.Year.ToString();
            response.Gender = transaction.Patient?.Gender == Gender.Male ? "Nam" : "Nữ";
            response.TransactionDate = transaction.CreatedDate.Date;
            response.AdvancePaymentAmount = MathExtensions.Round((int)advancePaymentAmount, 1000);
            response.TotalFeeAmount = MathExtensions.Round((int)transaction.TotalFee, 1000);
            response.PatientPaymentAmount = MathExtensions.Round((int)transaction.Amount, 1000);
            response.InsurancePaymentAmount = MathExtensions.Round((int)transaction.InsuranceFee, 1000);
            response.TotalRefundAmount = MathExtensions.Round((int)totalRefundAmount, 1000);
            response.TotalLostAmount = MathExtensions.Round((int)lostPaymentAmount, 1000);
            response.AlreadyReturnPatientPaidAmount = alreadyReturnPatientPaidAmount;
            response.NotYetReturnPatientPaidAmount = notYetReturnPatientPaidAmount;
            response.SerialNo = transaction.SerialNo;
            response.RecvNo = transaction.RecvNo.Value;
            response.IsPaid = true;
            response.DepartmentName = "Khoa khám bệnh";
            response.ExtraFeeAmount = extraFeeAmount;
            response.Time = time;
            response.Type = TekmediCardCashFlowPrepareDataEnum.PaymentCancel;
            response.TypeName = "Hủy";
            response.TransactionInfoId = transaction.Id;
            response.CancelledTransactionInfoId = transaction.CancelledTransactionInfoId;

            return response;
        }

        /// <summary>
        /// Gets the list transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<List<TransactionInfoViewModel>> GetListTransaction(TransactionDetailRequest request)
        {
            var transactions = await _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .Where(t => t.RegisteredCode == request.RegisteredCode
                && t.PatientCode == request.PatientCode
                && t.Status != TransactionStatus.New)
                .OrderBy(o => o.UpdatedDate)
                .ToListAsync();
            return _mapper.Map<List<TransactionInfoViewModel>>(transactions);
        }

        /// <summary>
        /// Gets the detail by identifier.
        /// </summary>
        /// <param name="guidId">The unique identifier identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionDetailInfoResponse> GetTransactionDetail(Guid guidId)
        {
            var detailTransactions = new List<TransactionDetailViewModel>();

            var transaction = await _unitOfWork.GetRepository<TransactionInfo>().GetAsyncById(guidId);

            if (transaction == null)
                throw new Exception(ErrorMessages.NotFoundTransactionId);

            var valueType = await _unitOfWork.GetRepository<ListValueType>().FindAsync(x => x.Code == ValueTypeCode.ServiceCode);
            var valueExtends = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where(x => x.ListValueTypeId == valueType.Id).ToListAsync();

            var transactionClinics = _mapper.Map<List<TransactionDetailViewModel>>(transaction.TransactionClinics);

            foreach (var clinic in transactionClinics)
            {
                clinic.PatientCode = transaction.PatientCode;
                clinic.RegisteredCode = transaction.RegisteredCode;
                clinic.RegisteredDate = transaction.RegisteredDate;
                var service = valueExtends.FirstOrDefault(x => x.Code == clinic.ServiceId);
                if (service == null) clinic.ServiceName = clinic.ServiceId;
                clinic.ServiceName = service?.Description;
            }

            var transactionPrescriptions = _mapper.Map<List<TransactionDetailViewModel>>(transaction.TransactionPrescriptions);
            detailTransactions.AddRange(transactionClinics);
            detailTransactions.AddRange(transactionPrescriptions);

            return new TransactionDetailInfoResponse
            {
                TransactionInfoDetail = detailTransactions
            };
        }

        /// <summary>
        /// Unholds the transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TransactionInfo> UnholdTransaction(CancelTransactionRequest request)
        {
            var transaction = await _unitOfWork.GetRepository<TransactionInfo>().GetAsyncById(request.TransactionId);

            if (transaction == null)
                throw new Exception(ErrorMessages.NotFoundTransactionId);

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (string.IsNullOrEmpty(patient.TekmediCardNumber))
                throw new Exception(ErrorMessages.HaveNotProvidedCardNumber);

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == patient.TekmediCardNumber);
            if (tekmediCard == null)
                throw new Exception(ErrorMessages.NotFoundCardNumber);

            var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(u => u.Id == request.EmployeeId);
            if (employee == null)
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);

            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == request.PatientCode && r.RegisteredCode == transaction.RegisteredCode);
            if (reception == null)
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);

            if (reception.TransactionInfos.Any(x => x.Type == TransactionType.Paid && x.Status == TransactionStatus.Success))
                throw new Exception(ErrorMessages.ExsitedPaidTransaction);

            if (transaction.Status == TransactionStatus.Success)
            {
                var clinicList = transaction.TransactionClinics.ToList();

                var prescriptions = transaction.TransactionPrescriptions.ToList();

                var isInValidCondition = clinicList.Any(c => c.Type != TransactionType.Hold) || prescriptions.Any(c => c.Type != TransactionType.Hold);
                if (isInValidCondition)
                {
                    throw new Exception(ErrorMessages.NotStatisfyHoldConditionToCancel);
                }

                isInValidCondition = clinicList.Any(c => c.IsFinished == StatusServiceConstants.Finished);

                if (isInValidCondition)
                {
                    throw new Exception(ErrorMessages.NotStatisfyNoFinishConditionToCancel);
                }

                var refundClinicResponse = await _hospitalSystemService.RefundClinicList(new RefundRegistrationRawRequest { TransactionId = transaction.Id });

                if (refundClinicResponse.Success)
                {
                    foreach (var clinic in clinicList)
                    {
                        clinic.Type = TransactionType.Cancelled;
                        _unitOfWork.GetRepository<TransactionClinic>().Update(clinic);
                    }

                    foreach (var prescription in prescriptions)
                    {
                        prescription.Type = TransactionType.Cancelled;
                        _unitOfWork.GetRepository<TransactionPrescription>().Update(prescription);
                    }

                    transaction.Type = TransactionType.Cancelled;

                    var balance = tekmediCard.Balance;
                    var newBalance = balance + transaction.Amount;

                    await UpdateBalance(patient, tekmediCard, TypeEnum.Refund, newBalance, transaction.Amount, reception.RegisteredCode, employee);
                    var refundTransaction = CreateTrasaction(transaction.Amount,
                        patient,
                        TransactionType.Refund,
                        TransactionStatus.Success,
                        ErrorMessages.RefundTransactionSuccessMessage,
                        reception,
                        null,
                        null,
                        null,
                        employee, null);
                    await _unitOfWork.CommitAsync();
                    return refundTransaction;
                }
                else
                {
                    throw new Exception(refundClinicResponse.Message);
                }
            }
            else
            {
                throw new Exception(ErrorMessages.NotStatisfyConditionToCancel);
            }
        }
        #endregion

        /// <summary>
        /// Updates the balance.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="cardInfo">The card information.</param>
        /// <param name="cardType">Type of the card.</param>
        /// <param name="newBalance">The new balance.</param>
        /// <param name="amountTotal">The amount total.</param>
        /// <param name="employee">The employee.</param>
        private async Task UpdateBalance(Patient patientInfo, TekmediCard cardInfo, TypeEnum cardType, decimal newBalance, decimal amountTotal, string registeredCode, SysUser employee = null)
        {
            var history = new TekmediCardHistory
            {
                TekmediCardNumber = cardInfo.TekmediCardNumber,
                PatientId = patientInfo.Id,
                Amount = amountTotal,
                Time = DateTime.Now,
                Type = cardType,
                EmployeeId = employee != null ? employee.Id : Guid.Empty,
                Status = StatusEnum.Success,
                TekmediCardId = cardInfo.Id,
                BeforeValue = cardInfo.Balance,
                AfterValue = newBalance,
                RegisterCode = registeredCode
            };

            _unitOfWork.GetRepository<TekmediCardHistory>().Add(history);

            cardInfo.Balance = newBalance;
            _unitOfWork.GetRepository<TekmediCard>().Update(cardInfo);
        }

        /// <summary>
        /// Creates the trasaction.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="transactionStatus">The transaction status.</param>
        /// <param name="message">The message.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="clinics">The clinics.</param>
        /// <param name="prescriptionWithClinics">The prescription with clinics.</param>
        /// <param name="prescriptions">The prescriptions.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="store">The store.</param>
        /// <returns></returns>
        private TransactionInfo CreateTrasaction(
            decimal amount,
            Patient patientInfo,
            TransactionType transactionType,
            TransactionStatus transactionStatus,
            string message,
            Reception reception,
            ICollection<Clinic> clinics = null,
            ICollection<Prescription> prescriptionWithClinics = null,
            ICollection<Prescription> prescriptions = null,
            SysUser employee = null,
            ListValueExtend store = null)
        {
            var transactionId = Guid.NewGuid();
            var transaction = new TransactionInfo
            {
                Id = transactionId,
                Amount = amount,
                Message = message,
                PatientCode = patientInfo.Code,
                RegisteredCode = reception.RegisteredCode,
                RegisteredDate = reception.RegisteredDate,
                ExaminationType = reception.PatientType,
                Status = transactionStatus,
                Type = transactionType,
                PatientId = patientInfo.Id,
                StoreId = store?.Id,
                EmployeeId = employee?.Id,
                ReceptionId = reception?.Id,
                CreatedBy = Systems.CreatedBy,
                UpdatedBy = Systems.UpdatedBy,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            if (clinics != null && clinics.Count > 0)
            {
                foreach (var clinic in clinics)
                {
                    var transactionClinic = _mapper.Map<TransactionClinic>(clinic);
                    transactionClinic.Id = Guid.NewGuid();
                    transactionClinic.Type = transactionType;
                    transaction.TransactionClinics.Add(transactionClinic);
                }
            }

            if (prescriptionWithClinics != null && prescriptionWithClinics.Count > 0)
            {
                foreach (var prescription in prescriptionWithClinics)
                {
                    var transactionPrescription = _mapper.Map<TransactionPrescription>(prescription);
                    transactionPrescription.Id = Guid.NewGuid();
                    transactionPrescription.Type = transactionType;
                    transaction.TransactionPrescriptions.Add(transactionPrescription);
                }
            }

            if (prescriptions != null && prescriptions.Count > 0)
            {
                foreach (var prescription in prescriptions)
                {
                    var transactionPrescription = _mapper.Map<TransactionPrescription>(prescription);
                    transactionPrescription.Id = Guid.NewGuid();
                    transactionPrescription.Type = transactionType;
                    transaction.TransactionPrescriptions.Add(transactionPrescription);
                }
            }

            _unitOfWork.GetRepository<TransactionInfo>().Add(transaction);
            return transaction;
        }

        private IQueryable<TransactionReportViewModel> ApplyOrderBy(IQueryable<TransactionReportViewModel> query, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                property = property.Trim().ToUpper();
            }
            if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.PatientCode);
            else if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.PatientCode);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.FullName);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.FullName);
            else if (property == $"{SortCondition.TEKMEDICARD}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.TekmediCardNumber);
            else if (property == $"{SortCondition.TEKMEDICARD}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.TekmediCardNumber);
            else if (property == $"{SortCondition.CREATED_DATE}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.CreatedDate);
            else if (property == $"{SortCondition.CREATED_DATE}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.CreatedDate);
            else
                return query;
        }

        public async Task<List<TekTransactionJson>> PostAdvancePayment(string patientCode)
        {
            _logger.LogInformation($"PostAdvancePayment {DateTime.Now.ToString()}, PatientCode={patientCode}");
            var request = new GenerateAdvancePaymentRequest();
            request.PatientCode = patientCode;

            var stringContent = JsonConvert.SerializeObject(request);
            _logger.LogInformation($"PostAdvancePayment {DateTime.Now.ToString()}, PatientCode={patientCode}, request={stringContent}");

            var client = _clientFactory.CreateClient(NamedClientConstants.Internal);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.Internal.PaymentUrl,
                _externalSettings.Internal.AdvancePayment), body);
            var result = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"PostAdvancePayment {DateTime.Now.ToString()}, PatientCode={patientCode}, response={result}");

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<List<TekTransactionJson>>>(result);
                return data.Result;
            }
            else
            {
                return new List<TekTransactionJson>();
            }
        }
        public async Task<bool> PatchAdvancePayment(CS.VM.Requests.CreatePaymentRequest request)
        {
            _logger.LogInformation($"PatchAdvancePayment {DateTime.Now.ToString()}, TransactionId={request.TransactionId}");
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.Internal);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PatchAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.Internal.PaymentUrl,
                _externalSettings.Internal.AdvancePayment), body);
            var result = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"PatchAdvancePayment {DateTime.Now.ToString()}, TransactionId={request.TransactionId}, Result={result}");

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TransactionInfoViewModel> CancelPayment(CancelPaymentRequest request)
        {
            _logger.LogInformation($"SendCancelPaymentToHis Start {DateTime.Now.ToString()}, PatientCode={request.PatientCode}, RegisterCode={request.RegisteredCode}");

            if (string.IsNullOrEmpty(request.PatientCode)
                || string.IsNullOrEmpty(request.RegisteredCode))
            {
            }

            string registerCode = string.Empty;
            var patient = await _unitOfWork.GetRepository<Patient>()
                .GetAll()
                .FirstOrDefaultAsync(x => x.Code == request.PatientCode);

            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var employee = await _unitOfWork.GetRepository<SysUser>()
                .GetAll()
                .FirstOrDefaultAsync(x => x.Code == request.EmployeeCode);

            if (employee == null)
            {
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            var reception = await _unitOfWork.GetRepository<Reception>()
                .GetAll()
                .FirstOrDefaultAsync(x => x.RegisteredCode == request.RegisteredCode);

            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            if (!reception.IsFinished)
            {
                throw new Exception(ErrorMessages.NotFinishedReceptionNumber);
            }

            var transaction = await _unitOfWork.GetRepository<TransactionInfo>()
                .GetAll()
                .Where(x => x.RegisteredCode == request.RegisteredCode
                && x.State == StateConstants.Finished
                && x.Status == TransactionStatus.Success
                && x.InvoiceNo.HasValue).OrderByDescending(o => o.InvoiceNo)
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundFinishedTransaction);
            }

            var history = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                .Where(h => h.Type == TypeEnum.FinallyCharge
                && h.Status == StatusEnum.Success
                && h.RegisterCode == reception.RegisteredCode
                && h.PatientId == patient.Id
                && h.InvoiceNo == transaction.InvoiceNo)
                .OrderByDescending(s => s.Time)
                .FirstOrDefaultAsync();

            if (history == null)
            {
                throw new Exception(ErrorMessages.NotFoundHistory);
            }

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>()
                .GetAll()
                .FirstOrDefaultAsync(x => x.TekmediCardNumber == patient.TekmediCardNumber && x.IsActive == true);

            if (tekmediCard == null)
            {
                throw new Exception(ErrorMessages.NotFoundTekmediCard);
            }

            var cancelHistory = new TekmediCardCancelHistory
            {
                TekmediCardNumber = history.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = transaction.Amount,
                Time = transaction.CreatedDate,
                Type = TypeEnum.CancelPayment,
                EmployeeId = employee.Id,
                Status = StatusEnum.Success,
                TekmediCardId = history.TekmediCardId,
                TekmediCardHistoryId = history.Id,
                BeforeValue = tekmediCard.Balance,
                AfterValue = tekmediCard.Balance + transaction.Amount,
                RegisterCode = history.RegisterCode,
                TransactionInfoId = transaction.Id
            };
            _unitOfWork.GetRepository<TekmediCardCancelHistory>().Add(cancelHistory);

            //patient.Balance -= amount;
            tekmediCard.Balance = tekmediCard.Balance + transaction.Amount;

            if (!history.InvoiceNo.HasValue)
            {
                throw new Exception(ErrorMessages.NotFoundInvoiceNo);
            }

            // Hủy thu tiếp nếu có
            var extraFeeHistory = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                .Where(h => h.Type == TypeEnum.ExtraFee
                    && h.Status == StatusEnum.Success
                    && h.RegisterCode == reception.RegisteredCode
                    && h.PatientId == patient.Id)
                .OrderByDescending(s => s.Time)
                .FirstOrDefaultAsync();
            TekmediCardCancelHistory cancelExtraFeeHistory = null;
            if (extraFeeHistory != null)
            {
                // Kiểm tra xem thu tiếp này đã bị hủy chưa
                cancelExtraFeeHistory = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                .Where(h => h.Type == TypeEnum.CancelExtraFee
                    && h.Status == StatusEnum.Success
                    && h.RegisterCode == reception.RegisteredCode
                    && h.PatientId == patient.Id
                    && h.TekmediCardHistoryId == extraFeeHistory.Id)
                .OrderByDescending(s => s.Time)
                .FirstOrDefaultAsync();
                // Nếu chưa hủy
                if (cancelExtraFeeHistory == null)
                {
                    var cancel = new TekmediCardCancelHistory
                    {
                        TekmediCardNumber = history.TekmediCardNumber,
                        PatientId = patient.Id,
                        Amount = extraFeeHistory.Amount,
                        Time = DateTime.Now,
                        Type = TypeEnum.CancelExtraFee,
                        EmployeeId = employee.Id,
                        Status = StatusEnum.Success,
                        TekmediCardId = history.TekmediCardId,
                        TekmediCardHistoryId = extraFeeHistory.Id,
                        BeforeValue = tekmediCard.Balance,
                        AfterValue = tekmediCard.Balance - extraFeeHistory.Amount,
                        RegisterCode = history.RegisterCode,
                        TransactionInfoId = transaction.Id
                    };
                    _unitOfWork.GetRepository<TekmediCardCancelHistory>().Add(cancel);
                    tekmediCard.Balance = tekmediCard.Balance - extraFeeHistory.Amount.Value;
                }
            }

            var cancelPaymentReq = new CancelRawPaymentRequest
            {
                EmployeeCode = employee.Code,
                InvoiceNo = history.InvoiceNo.Value,
                PatientCode = patient.Code,
                RegisteredCode = reception.RegisteredCode
            };

            var result = await _hospitalSystemService.CancelPayment(cancelPaymentReq);
            if (result.StatusCode == "00"
                && result.Status == "success"
                && result.InvoiceNo > 0)
            {
                var tekmediCardHistory = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().FirstOrDefault(x => x.Id == history.Id);
                if (tekmediCardHistory != null)
                {
                    tekmediCardHistory.InvoiceNo = 0;
                    _unitOfWork.GetRepository<TekmediCardHistory>().Update(tekmediCardHistory);

                    var tekmediCardCancelHistory = _unitOfWork.GetRepository<TekmediCardCancelHistory>()
                        .GetAll()
                        .FirstOrDefault(x => x.TekmediCardHistoryId == history.Id);
                    if (tekmediCardCancelHistory != null)
                    {
                        tekmediCardCancelHistory.InvoiceNo = result.InvoiceNo;
                        _unitOfWork.GetRepository<TekmediCardCancelHistory>().Update(tekmediCardCancelHistory);
                    }
                }

                reception.IsFinished = false;
                reception.Type = ReceptionType.Cancelled;
                transaction.Type = TransactionType.Cancelled;

                await _unitOfWork.CommitAsync();
                return _mapper.Map<TransactionInfoViewModel>(transaction);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<GetEInvoiceDataResponse> GetEInvoiceData(GetEInvoiceDataRequest request)
        {
            var response = new GetEInvoiceDataResponse();
            var startDate = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
            var endDate = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
            var sql = "drop table if exists temp_data; ";
            var sqlGetData =
            "create temp table temp_data as " +
            "select ti.id as Id, " +
                "ti.e_invoice_no as EInvoiceNo, " +
                "ti.printed_bill_count as PrintedBillCount, " +
                "concat(ti.serial_no, '-', ti.recv_no) as BillNo, " +
                "ti.registered_code as RegisteredCode, " +
                "ti.patient_code as PatientCode, " +
                "concat(p.last_name, ' ', p.first_name) as PatientName, " +
                "'Khoa khám bệnh' as DepartmentName, " +
                "ti.created_date as CreatedDate, " +
                "ti.e_invoice_created_date as EInvoiceCreatedDate " +
            "from \"IHM\".transaction_info ti " +
            "join \"IHM\".patient p on p.id = ti.patient_id " +
            "join \"IHM\".reception r on r.id = ti.reception_id " +
            $"where ti.\"type\" = {(int)TransactionType.Paid} " +
                $"and ti.status = {(int)TransactionStatus.Success} " +
                "and r.is_finished = true " +
                $"and ti.created_date >= '{startDate}' " +
                $"and ti.created_date <= '{endDate}' ";

            if (request.AdminView == false)
            {
                sqlGetData += $"and ti.employee_id = '{request.EmployeeId}' ";
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                sqlGetData += $"and ti.registered_code like \'%{request.RegisteredCode}%\' ";
            }

            if (string.IsNullOrEmpty(request.PatientCode) == false)
            {
                sqlGetData += $"and ti.patient_code like \'%{request.PatientCode}%\' ";
            }

            if (string.IsNullOrEmpty(request.PatientName) == false)
            {
                sqlGetData += $"and concat(lower(p.last_name), ' ', lower(p.first_name)) like \'%{request.PatientName.ToLower().Trim()}%\' ";
            }

            if (string.IsNullOrEmpty(request.EInvoiceNo) == false)
            {
                sqlGetData += $"and ti.e_invoice_no like \'%{request.EInvoiceNo}%\' ";
            }

            sqlGetData += "; ";
            sql += sqlGetData;
            sql +=
            "select count(*) from temp_data; " +
            "select * from temp_data td " +
            "order by td.CreatedDate desc " +
            $"offset {request.Start} " +
            $"fetch next {request.Length} rows only; " +
            "drop table if exists temp_data; ";

            var data = new List<GetEInvoiceDataDto>();
            var totalRecord = 0;
            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var multi = await connection.QueryMultipleAsync(sql).ConfigureAwait(false))
                {
                    totalRecord = await multi.ReadSingleAsync<int>();
                    data = multi.Read<GetEInvoiceDataDto>().ToList();
                }
            }

            response.TotalRecord = totalRecord;
            response.Data = data;

            return response;
        }

        public async Task<UpdateEInvoiceNoResponse> UpdateEInvoiceNo(UpdateEInvoiceNoRequest request)
        {
            var response = new UpdateEInvoiceNoResponse();
            var employee = _unitOfWork.GetRepository<SysUser>().GetAll()
                .FirstOrDefault(x => x.Id == request.EmployeeId);
            if (employee == null)
            {
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            var transaction = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .FirstOrDefault(x => x.Id == request.Id);
            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionId);
            }

            var reception = _unitOfWork.GetRepository<Reception>().GetAll()
                .FirstOrDefault(x => x.Id == transaction.ReceptionId);
            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            if (transaction.Type != TransactionType.Paid
                || transaction.Status != TransactionStatus.Success
                || reception.IsFinished == false)
            {
                throw new Exception(ErrorMessages.NotFinishedReceptionNumber);
            }

            var dupEInvoice = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .FirstOrDefault(x => x.EInvoiceNo == request.EInvoiceNo
                    && x.Id != request.Id);
            if (dupEInvoice != null)
            {
                throw new Exception($"Số hoá đơn đã được sử dụng cho số biên lai: {dupEInvoice.SerialNo}-{dupEInvoice.RecvNo}");
            }

            transaction.EInvoiceNo = request.EInvoiceNo;
            transaction.EInvoiceCreatedDate = DateTime.Now;
            transaction.EInvoiceEmployeeId = employee.Id;
            transaction.UpdatedDate = DateTime.Now;
            _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            await _unitOfWork.CommitAsync();

            response.Id = transaction.Id;
            response.EInvoiceNo = transaction.EInvoiceNo;
            response.EInvoiceCreatedDate = transaction.EInvoiceCreatedDate;
            response.EInvoiceEmployeeId = transaction.EInvoiceEmployeeId;

            return response;
        }

        public Task<ICollection<TransactionInfo>> CreateAdvancePayment(Patient patientInfo)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionInfo> CreateAdvancePayment(Patient patientInfo, string registeredCode)
        {
            throw new NotImplementedException();
        }

        Task<TableResultJsonResponse<TransactionReportViewModel>> ITransactionService.GetTransactionReport(TransactionReportRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionInfo> CreatePayment(Patient patientInfo, string registeredCode)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionInfo> UpdateHoldStatus(TransactionInfo transaction, Reception reception)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionInfo> UpdatePaymentStatus(TransactionInfo transaction, Reception reception, TransactionNumberConfig numberConfig)
        {
            throw new NotImplementedException();
        }

        public Task<IncreasePrintedBillCountResponse> IncreasePrintedBillCount(IncreasePrintedBillCountRequest request)
        {
            throw new NotImplementedException();
        }
    }
}