// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IPaymentService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.PaymentModels.Models;
using CS.VM.PaymentModels.Requests;
using CS.VM.Requests;
using CS.VM.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// Interface IPaymentService
    /// </summary>
    public interface ITransactionService : IService<TransactionInfo, IRepository<TransactionInfo>>
    {
        /// <summary>
        /// Creates the hold payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <returns></returns>
        Task<ICollection<TransactionInfo>> CreateAdvancePayment(Patient patientInfo);

        /// <summary>
        /// Creates the advance payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="registeredCode">The registered code.</param>
        /// <returns></returns>
        Task<TransactionInfo> CreateAdvancePayment(Patient patientInfo, string registeredCode);

        /// <summary>
        /// Gets the transaction report.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<TransactionReportViewModel>> GetTransactionReport(TransactionReportRequest request);

        /// <summary>
        /// Creates the payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="registeredCode">The registered code.</param>
        /// <returns></returns>
        Task<TransactionInfo> CreatePayment(Patient patientInfo, string registeredCode);

        /// <summary>
        /// Gets the list transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<TransactionInfoViewModel>> GetListTransaction(TransactionDetailRequest request);

        /// <summary>
        /// Gets the detail by identifier.
        /// </summary>
        /// <param name="guidId">The unique identifier identifier.</param>
        /// <returns></returns>
        Task<TransactionDetailInfoResponse> GetTransactionDetail(Guid guidId);

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="reception">The reception.</param>
        /// <returns></returns>
        Task<TransactionInfo> UpdateHoldStatus(TransactionInfo transaction, Reception reception);

        /// <summary>
        /// Updates the payment status.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="reception">The reception.</param>
        /// <returns></returns>
        Task<TransactionInfo> UpdatePaymentStatus(TransactionInfo transaction, Reception reception, TransactionNumberConfig numberConfig);

        /// <summary>
        /// Unholds the transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TransactionInfo> UnholdTransaction(CancelTransactionRequest request);

        Task<IncreasePrintedBillCountResponse> IncreasePrintedBillCount(IncreasePrintedBillCountRequest request);
    }
}
