// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="TekmediCardService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Common.Common;
using CS.EF.Models;
using System;
using System.Threading.Tasks;
using CS.Common.Enums;
using TEK.Core.UoW;
using TEK.Core.Service.Interfaces;
using TEK.Domain.VCB.BusinessObjects.BankAccount;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static CS.Common.Common.Constants;
using AutoMapper;
using TEK.Core.Helpers;
using Microsoft.EntityFrameworkCore.Internal;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// Class TekmediCardService.
    /// Implements the <see cref="CS.Abstractions.IServices.ITekmediCardService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.ITekmediCardService" />
    public class LocalCardService : ICardService
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
        /// Initializes a new instance of the <see cref="LocalCardService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public LocalCardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<TransactionInfo> Create(AdvancePaymentRequest request)
        {
            var transaction = request.Transaction;
            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionId);
            }

            transaction.Message = Messages.Waiting;
            transaction.Status = TransactionStatus.Waiting;
            transaction.PayProvider = PaymentProvider.Local;

            var device = await _unitOfWork.GetRepository<Device>().FindAsync(p => p.Id == request.DeviceId);
            if (device == null)
            {
                transaction.Message = ErrorMessages.NotFoundDevice;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundDevice);
            }

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(f => f.TekmediCardNumber == request.CardNumber);
            if (cardInfo != null)
            {
                var balance = cardInfo.Balance;
                if (balance >= transaction.Amount)
                {
                    var newBalance = cardInfo.Balance - transaction.Amount;
                    var history = new TekmediCardHistory
                    {
                        TekmediCardNumber = cardInfo.TekmediCardNumber,
                        PatientId = transaction.PatientId,
                        Amount = transaction.Amount,
                        Time = DateTime.Now,
                        Type = request.TypeEnum,
                        EmployeeId = request.EmployeeId,
                        Status = StatusEnum.Success,
                        TekmediCardId = cardInfo.Id,
                        BeforeValue = cardInfo.Balance,
                        AfterValue = newBalance
                    };

                    _unitOfWork.GetRepository<TekmediCardHistory>().Add(history);

                    cardInfo.Balance = newBalance;
                    _unitOfWork.GetRepository<TekmediCard>().Update(cardInfo);

                    transaction.Status = TransactionStatus.Approved;
                    transaction.PayProvider = PaymentProvider.Local;
                    transaction.State = StateConstants.Approved;
                    transaction.Message = Messages.Approved;
                    transaction.UpdatedDate = DateTime.Now;
                }
                else
                {
                    var reason = new BankTransactionReason();
                    reason.name = "INSUFFICIENT_FUNDS";
                    reason.message = ErrorMessages.NotEnoughBalanceMessage;
                    reason.amount = balance - transaction.Amount;
                    transaction.Status = TransactionStatus.Failed;
                    transaction.State = StateConstants.Failed;
                    transaction.Reason = JsonConvert.SerializeObject(reason);
                    transaction.Message = ErrorMessages.NotEnoughBalanceMessage;
                    transaction.UpdatedDate = DateTime.Now;
                }

                _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            }
            else
            {
                transaction.Message = ErrorMessages.NotFoundCardNumber;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            return transaction;
        }

        public async Task<TransactionInfo> CreateDraft(AdvancePaymentRequest request)
        {
            var transaction = request.Transaction;
            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionId);
            }

            transaction.Message = Messages.Waiting;
            transaction.Status = TransactionStatus.Waiting;
            transaction.PayProvider = PaymentProvider.Local;

            var device = await _unitOfWork.GetRepository<Device>().FindAsync(p => p.Id == request.DeviceId);
            if (device == null)
            {
                transaction.Message = ErrorMessages.NotFoundDevice;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundDevice);
            }

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(f => f.TekmediCardNumber == request.CardNumber);
            if (cardInfo != null)
            {
                var balance = cardInfo.Balance;
                if (balance >= transaction.Amount)
                {
                    //var newBalance = cardInfo.Balance - transaction.Amount;
                    //var history = new TekmediCardHistory
                    //{
                    //    TekmediCardNumber = cardInfo.TekmediCardNumber,
                    //    PatientId = transaction.PatientId,
                    //    Amount = transaction.Amount,
                    //    Time = DateTime.Now,
                    //    Type = request.TypeEnum,
                    //    EmployeeId = request.EmployeeId,
                    //    Status = StatusEnum.Success,
                    //    TekmediCardId = cardInfo.Id,
                    //    BeforeValue = cardInfo.Balance,
                    //    AfterValue = newBalance
                    //};

                    //_unitOfWork.GetRepository<TekmediCardHistory>().Add(history);

                    //cardInfo.Balance = newBalance;
                    //_unitOfWork.GetRepository<TekmediCard>().Update(cardInfo);

                    transaction.Status = TransactionStatus.Approved;
                    transaction.PayProvider = PaymentProvider.Local;
                    transaction.State = StateConstants.Approved;
                    transaction.Message = Messages.Approved;
                    transaction.UpdatedDate = DateTime.Now;
                }
                else
                {
                    var reason = new BankTransactionReason();
                    reason.name = "INSUFFICIENT_FUNDS";
                    reason.message = ErrorMessages.NotEnoughBalanceMessage;
                    reason.amount = balance - transaction.Amount;
                    transaction.Status = TransactionStatus.Failed;
                    transaction.State = StateConstants.Failed;
                    transaction.Reason = JsonConvert.SerializeObject(reason);
                    transaction.Message = ErrorMessages.NotEnoughBalanceMessage;
                    transaction.UpdatedDate = DateTime.Now;
                }

                _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            }
            else
            {
                transaction.Message = ErrorMessages.NotFoundCardNumber;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            return transaction;
        }

        /// <summary>
        /// Gets the by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<Patient> GetByNumber(string number, string hospitalCode)
        {
            var card = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(t => t.TekmediCardNumber == number);
            if (card == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(t => t.TekmediCardNumber == number);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumberMappingWithPatient);
            }

            patient.Balance = card.Balance;
            return patient;
        }

        /// <summary>
        /// Authenticates the payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TransactionInfo> AuthenticatePayment(string id, AuthenticateTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the finally.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<TransactionInfo> CreateFinally(FinallyPaymentRequest request)
        {
            var transaction = request.Transaction;
            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionId);
            }

            var device = await _unitOfWork.GetRepository<Device>()
                .GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.DeviceId);
            if (device == null)
            {
                transaction.Message = ErrorMessages.NotFoundDevice;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundDevice);
            }

            var employee = await _unitOfWork.GetRepository<SysUser>()
                .GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.EmployeeId);
            if (employee == null)
            {
                transaction.Message = ErrorMessages.NotFoundEmployeeCode;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            var store = await _unitOfWork.GetRepository<ListValueExtend>()
                .GetAll()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Code == request.StoreCode);
            if (store == null)
            {
                transaction.Message = ErrorMessages.NotFoundStoreCode;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundStoreCode);
            }

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(f => f.TekmediCardNumber == request.CardNumber);
            if (cardInfo == null)
            {
                transaction.Message = ErrorMessages.NotFoundCardNumber;
                transaction.Status = TransactionStatus.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                await _unitOfWork.CommitAsync();
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            var patient = transaction.Patient;

            transaction.Message = Messages.Waiting;
            transaction.Status = TransactionStatus.Waiting;
            transaction.EmployeeId = employee.Id;
            transaction.StoreId = store.Id;
            transaction.PayProvider = PaymentProvider.Local;
            var registeredCode = transaction.Reception?.RegisteredCode;

            var balance = cardInfo.Balance;

            var draftTransactions = await _unitOfWork.GetRepository<TransactionDraft>()
                .GetAll()
                .Where(t => t.TransactionInfoId == transaction.Id)
                .ToListAsync();

            var localRefundDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Refund
            && w.PayProvider == PaymentProvider.Local).ToList();

            var bankRefundDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Refund
            && w.PayProvider == PaymentProvider.Bank).ToList();

            var extraDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Extra).ToList();

            var localRefundTotal = localRefundDraftTransactions.Sum(t => t.Amount);
            var bankRefundTotal = bankRefundDraftTransactions.Sum(t => t.Amount);
            var extraTotal = extraDraftTransactions.Sum(t => t.Amount);

            var refundDraftTransactionTotals = new List<TransactionDraft>();
            refundDraftTransactionTotals.AddRange(localRefundDraftTransactions);
            refundDraftTransactionTotals.AddRange(bankRefundDraftTransactions);

            foreach (var item in refundDraftTransactionTotals)
            {
                RefundLocalPayment(request, patient, cardInfo, item.Amount, registeredCode);
                var updatedTransaction = CreateTrasaction(item);
                updatedTransaction.EmployeeId = employee.Id;
                updatedTransaction.StoreId = store.Id;
                updatedTransaction.PayProvider = PaymentProvider.Local;
                updatedTransaction.State = StateConstants.Finished;
                updatedTransaction.Message = Messages.Success;
                updatedTransaction.Status = TransactionStatus.Success;
                updatedTransaction.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<TransactionInfo>().Add(updatedTransaction);
            }

            if (cardInfo.Balance >= extraTotal)
            {
                foreach (var item in extraDraftTransactions)
                {
                    CreateLocalPayment(request, patient, cardInfo, item.Amount, registeredCode);
                    var updatedTransaction = CreateTrasaction(item);
                    updatedTransaction.EmployeeId = employee.Id;
                    updatedTransaction.StoreId = store.Id;
                    updatedTransaction.PayProvider = PaymentProvider.Local;
                    updatedTransaction.State = StateConstants.Finished;
                    updatedTransaction.Message = Messages.Success;
                    updatedTransaction.Status = TransactionStatus.Success;
                    updatedTransaction.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<TransactionInfo>().Add(updatedTransaction);
                }

                var chargeHistory = new TekmediCardHistory
                {
                    TekmediCardNumber = cardInfo.TekmediCardNumber,
                    PatientId = patient.Id,
                    Amount = transaction.Amount,
                    Time = DateTime.Now,
                    Type = TypeEnum.FinallyCharge,
                    EmployeeId = request.EmployeeId,
                    Status = StatusEnum.Success,
                    TekmediCardId = cardInfo.Id,
                    BeforeValue = balance,
                    AfterValue = cardInfo.Balance,
                    RegisterCode = registeredCode
                };
                _unitOfWork.GetRepository<TekmediCardHistory>().Add(chargeHistory);

                transaction.Status = TransactionStatus.Success;
                transaction.State = StateConstants.Approved;
                transaction.PayProvider = PaymentProvider.Local;
                transaction.Message = Messages.Approved;
                transaction.UpdatedDate = DateTime.Now;
            }
            else
            {
                var reason = new BankTransactionReason();
                reason.name = "INSUFFICIENT_FUNDS";
                reason.message = ErrorMessages.NotEnoughBalanceMessage;
                reason.amount = balance - extraTotal;
                transaction.Reason = JsonConvert.SerializeObject(reason);

                transaction.Status = TransactionStatus.Failed;
                transaction.State = StateConstants.Failed;
                transaction.PayProvider = PaymentProvider.Local;
                transaction.Message = ErrorMessages.NotEnoughBalanceMessage;
                transaction.UpdatedDate = DateTime.Now;
            }

            _unitOfWork.GetRepository<TekmediCard>().Update(cardInfo);
            _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            await _unitOfWork.CommitAsync();
            return transaction;
        }

        /// <summary>
        /// Creates the payment history.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="cardInfo">The card information.</param>
        /// <param name="amount">The amount.</param>
        private void CreateLocalPayment(FinallyPaymentRequest request,
            Patient patient,
            TekmediCard cardInfo,
            decimal amount,
            string registeredCode)
        {
            var balance = cardInfo.Balance;
            var newBalance = balance - amount;
            var chargeHistory = new TekmediCardHistory
            {
                TekmediCardNumber = cardInfo.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = amount,
                Time = DateTime.Now,
                Type = TypeEnum.Charge,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = cardInfo.Id,
                BeforeValue = balance,
                AfterValue = newBalance,
                RegisterCode = registeredCode
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(chargeHistory);

            cardInfo.Balance = newBalance;
        }

        /// <summary>
        /// Creates the history.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="cardInfo">The card information.</param>
        /// <param name="amount">The actually refund total.</param>
        private void RefundLocalPayment(FinallyPaymentRequest request,
            Patient patient,
            TekmediCard cardInfo,
            decimal amount,
            string registeredCode)
        {
            var balance = cardInfo.Balance;
            var newBalance = balance + amount;
            var refundHistory = new TekmediCardHistory
            {
                TekmediCardNumber = cardInfo.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = amount,
                Time = DateTime.Now,
                Type = TypeEnum.Refund,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = cardInfo.Id,
                BeforeValue = balance,
                AfterValue = newBalance,
                RegisterCode = registeredCode
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(refundHistory);

            cardInfo.Balance = newBalance;
        }

        /// <summary>
        /// Creates the trasaction.
        /// </summary>
        /// <param name="parentTransaction">The parent transaction.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private TransactionInfo CreateTrasaction(TransactionDraft item)
        {
            var transaction = _mapper.Map<TransactionInfo>(item);
            transaction.TransactionClinics = item.TransactionDraftClinics.Select(_mapper.Map<TransactionClinic>).ToList();
            transaction.TransactionPrescriptions = item.TransactionDraftPrescriptions.Select(_mapper.Map<TransactionPrescription>).ToList();

            return transaction;
        }

        /// <summary>
        /// Calculates the specified transactions.
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <param name="transactions">The transactions.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountBalanceStatus> Calculate(string cardnumber, IEnumerable<TransactionInfo> transactions)
        {
            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(f => f.TekmediCardNumber == cardnumber);
            if (cardInfo == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            var balance = cardInfo.Balance;

            var localRefundTotal = decimal.Zero;
            var bankRefundTotal = decimal.Zero;
            var extraTotal = decimal.Zero;

            foreach (var transaction in transactions)
            {
                var draftTransactions = await _unitOfWork.GetRepository<TransactionDraft>()
                    .GetAll()
                    .Where(t => t.TransactionInfoId == transaction.Id)
                    .ToListAsync();

                var localRefundDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Refund
                && w.PayProvider == PaymentProvider.Local).ToList();

                var bankRefundDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Refund
                && w.PayProvider == PaymentProvider.Bank).ToList();

                var extraDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Extra).ToList();

                localRefundTotal += localRefundDraftTransactions.Sum(t => t.Amount);
                bankRefundTotal += bankRefundDraftTransactions.Sum(t => t.Amount);
                extraTotal += extraDraftTransactions.Sum(t => t.Amount);
            }

            balance = balance + localRefundTotal + bankRefundTotal;

            var reason = new AccountBalanceStatus();
            var decimalPrice = balance - extraTotal;

            if (balance >= extraTotal)
            {
                reason.name = "SUFFICIENT_FUNDS";
                reason.message = ErrorMessages.EnoughBalanceMessage;
                reason.amount = decimalPrice;
            }
            else
            {
                reason.name = "INSUFFICIENT_FUNDS";
                reason.message = ErrorMessages.NotEnoughBalanceMessage;
                reason.amount = -NumberHelper.RoundToSignificantDigits(Math.Abs(decimalPrice));
            }

            return reason;
        }

        /// <summary>
        /// Cancels the specified transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionInfo> Cancel(TransactionInfo transaction)
        {
            var patientInfo = transaction.Patient;
            if (patientInfo == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(f => f.TekmediCardNumber == patientInfo.TekmediCardNumber);
            if (cardInfo == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            var balance = cardInfo.Balance;

            var localRefundTotal = decimal.Zero;
            var bankRefundTotal = decimal.Zero;
            var extraTotal = decimal.Zero;

            var draftTransactions = await _unitOfWork.GetRepository<TransactionDraft>()
                .GetAll()
                .Where(t => t.TransactionInfoId == transaction.Id)
                .ToListAsync();

            var localRefundDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Refund
            && w.PayProvider == PaymentProvider.Local).ToList();

            var bankRefundDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Refund
            && w.PayProvider == PaymentProvider.Bank).ToList();

            var extraDraftTransactions = draftTransactions.Where(w => w.Type == TransactionType.Extra).ToList();

            localRefundTotal += localRefundDraftTransactions.Sum(t => t.Amount);
            bankRefundTotal += bankRefundDraftTransactions.Sum(t => t.Amount);
            extraTotal += extraDraftTransactions.Sum(t => t.Amount);

            balance = balance - localRefundTotal - bankRefundTotal + extraTotal;

            transaction.Status = TransactionStatus.Failed;
            transaction.State = StateConstants.Failed;
            transaction.PayProvider = PaymentProvider.Local;
            transaction.Message = Messages.Failed;
            transaction.UpdatedDate = DateTime.Now;
            return transaction;
        }

        /// <summary>
        /// Gets the by patient code.
        /// </summary>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<CardInfo>> GetByPatientCode(string patientCode)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(p => p.Code == patientCode);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var cardHistories = await _unitOfWork.GetRepository<TekmediCardHistory>()
                .GetAll()
                .Where(t => t.PatientId == patient.Id)
                .Select(s => s.TekmediCardNumber)
                .Distinct().ToListAsync();

            var localCards = await _unitOfWork.GetRepository<TekmediCard>()
                .GetAll()
                .Where(t => cardHistories.Any(c => c == t.TekmediCardNumber))
                .ToListAsync();

            return localCards.Select(_mapper.Map<CardInfo>);
        }

        /// <summary>
        /// Gets the history by code and number.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<CardHistoryInfo>> GetHistoryByCodeAndNumber(string code, string cardNumber)
        {
            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(p => p.Code == code);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var cardHistories = await _unitOfWork.GetRepository<TekmediCardHistory>()
                .GetAll()
                .Where(t => t.PatientId == patient.Id
                && t.TekmediCardNumber == cardNumber).OrderByDescending(o => o.Time).ToListAsync();

            return cardHistories.Select(_mapper.Map<CardHistoryInfo>);
        }
    }
}
