// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ITekmediCardService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Common.Common;
using CS.Common.Enums;
using CS.EF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        /// Gets the by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        Task<Patient> GetByNumber(string number, string hospitalCode);

        /// <summary>
        /// Creates the specified create payment request.
        /// </summary>
        /// <param name="request">The create payment request.</param>
        /// <returns></returns>
        Task<TransactionInfo> Create(AdvancePaymentRequest request);

        Task<TransactionInfo> CreateDraft(AdvancePaymentRequest request);

        /// <summary>
        /// Authenticates the payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TransactionInfo> AuthenticatePayment(string id, AuthenticateTransactionRequest request);

        /// <summary>
        /// Creates the finally.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TransactionInfo> CreateFinally(FinallyPaymentRequest request);

        /// <summary>
        /// Calculates the specified transactions.
        /// </summary>
        /// <param name="transactions">The transactions.</param>
        /// <returns></returns>
        Task<AccountBalanceStatus> Calculate(string cardnumber, IEnumerable<TransactionInfo> transactions);

        /// <summary>
        /// Cancels the specified transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        Task<TransactionInfo> Cancel(TransactionInfo transaction);

        /// <summary>
        /// Gets the by patient code.
        /// </summary>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        Task<IEnumerable<CardInfo>> GetByPatientCode(string patientCode);

        /// <summary>
        /// Gets the history by code and number.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        Task<IEnumerable<CardHistoryInfo>> GetHistoryByCodeAndNumber(string code, string cardNumber);
    }

    /// <summary>
    /// 
    /// </summary>
    public class AdvancePaymentRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the type enum.
        /// </summary>
        /// <value>
        /// The type enum.
        /// </value>
        public TypeEnum TypeEnum { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        public TransactionInfo Transaction { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public string StoreCode { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FinallyPaymentRequest : AdvancePaymentRequest
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateTransactionRequest
    {
        /// <summary>
        /// Gets or sets the authorization input.
        /// </summary>
        /// <value>
        /// The authorization input.
        /// </value>
        public AuthenticateTransactionInput AuthorizationInput { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("payment_provider")]
        public string PaymentProvider { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateTransactionInput
    {
        /// <summary>
        /// Gets or sets the otp.
        /// </summary>
        /// <value>
        /// The otp.
        /// </value>
        public string OTP { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AccountBalanceStatus
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string message { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string details { get; set; }
        /// <summary>
        /// Gets or sets the information link.
        /// </summary>
        /// <value>
        /// The information link.
        /// </value>
        public string information_link { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal amount { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CardInfo
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public PaymentProvider PaymentProvider { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive { get; set; }
    }


    /// <summary>
    /// Class BaseTekmediCardHistory.
    /// Implements the <see cref="BaseObject" />
    /// </summary>
    /// <seealso cref="BaseObject" />
    public class CardHistoryInfo
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Gets or sets the before value.
        /// </summary>
        /// <value>
        /// The before value.
        /// </value>
        public decimal? BeforeValue { get; set; }

        /// <summary>
        /// Gets or sets the after value.
        /// </summary>
        /// <value>
        /// The after value.
        /// </value>
        public decimal? AfterValue { get; set; }
    }
}
