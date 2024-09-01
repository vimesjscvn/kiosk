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
using CS.VM.Settings;
using System.Net.Http;
using System.Net.Http.Headers;
using static CS.Common.Common.Constants;
using Newtonsoft.Json;
using TEK.Core.UoW;
using TEK.Core.Service.Interfaces;
using TEK.Domain.VCB.BusinessObjects;
using System.Net;
using TEK.Payment.Domain.BusinessObjects;
using TEK.Core.Models;
using System.Linq;
using TEK.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using CS.Common.Enums;
using AutoMapper;
using System.Collections.Generic;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// Class TekmediCardService.
    /// Implements the <see cref="CS.Abstractions.IServices.ITekmediCardService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.ITekmediCardService" />
    public class BankCardService : ICardService
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
        /// The HTTP client
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// The internal bank settings
        /// </summary>
        private readonly InternalBankSettings _internalBankSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCardService"/> class.
        /// </summary>
        public BankCardService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpClientFactory clientFactory,
            InternalBankSettings internalBankSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clientFactory = clientFactory;
            _internalBankSettings = internalBankSettings;
        }

        /// <summary>
        /// Authenticates the payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<TransactionInfo> AuthenticatePayment(string id, AuthenticateTransactionRequest request)
        {
            var transaction = await _unitOfWork.GetRepository<TransactionInfo>().FindAsync(u => u.Id == request.TransactionId);
            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionId);
            }

            if (transaction.Status == TransactionStatus.Approved)
            {
                throw new Exception(ErrorMessages.TransactionIsPaid);
            }

            transaction.Message = Messages.Waiting;
            transaction.Status = TransactionStatus.Waiting;
            transaction.PayProvider = PaymentProvider.Bank;
            //await _unitOfWork.CommitAsync();

            var data = new AuthenticatePaymentRequest();
            data.transaction_id = request.TransactionId;
            data.authorization_input = new AuthenticatePaymentInput
            {
                otp = request.AuthorizationInput.OTP
            };

            var stringContent = JsonConvert.SerializeObject(data);
            var client = _clientFactory.CreateClient(NamedClientConstants.Bank);
            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var url = InternalBankSettingHelper.GetEndPoint(
                _internalBankSettings.InternalBank.BaseUrl,
                _internalBankSettings.InternalBank.AuthorizationPaymentUrl,
                id);

            var responseMessage = await client.PatchAsync(url, body);
            var responseText = await responseMessage.Content.ReadAsStringAsync();
            // Success
            if (responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.Created)
            {
                var resObj = JsonConvert.DeserializeObject<BaseInternalResponse<BankTransactionResponseJson>>(responseText);
                if (resObj != null && resObj.Result != null)
                {
                    var result = resObj.Result;
                    transaction.State = result.state;
                    transaction.PaymentRefId = result.id;
                    transaction.UpdatedDate = DateTime.Now;
                    switch (result.state)
                    {
                        case StateConstants.Approved:
                            transaction.Message = Messages.Approved;
                            transaction.Status = TransactionStatus.Approved;
                            break;
                        case StateConstants.Failed:
                            transaction.Message = resObj.Result.reason.message;
                            transaction.Reason = JsonConvert.SerializeObject(resObj.Result.reason);
                            transaction.Status = TransactionStatus.Failed;
                            break;
                        case StateConstants.AuthorizationRequired:
                            transaction.Message = ErrorMessages.AuthorizationBank;
                            transaction.Authorization = JsonConvert.SerializeObject(resObj.Result.authorization);
                            transaction.Status = TransactionStatus.AuthorizationRequired;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                var resObj = JsonConvert.DeserializeObject<ErrorResponse>(responseText);
                if (resObj != null)
                {
                    transaction.Message = resObj.Message;
                }

                transaction.Status = TransactionStatus.Failed;
                transaction.State = StateConstants.Failed;
                transaction.UpdatedDate = DateTime.Now;
            }
            await _unitOfWork.CommitAsync();
            return transaction;
        }

        /// <summary>
        /// Creates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TransactionInfo> Create(AdvancePaymentRequest request)
        {
            var transaction = request.Transaction;
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(p => p.Id == request.DeviceId);
            if (device == null)
            {
                throw new Exception(ErrorMessages.NotFoundDevice);
            }

            transaction.Message = Messages.Waiting;
            transaction.Status = TransactionStatus.Waiting;
            transaction.PayProvider = PaymentProvider.Bank;
            await _unitOfWork.CommitAsync();
            if (transaction.Amount > 0)
            {
                transaction = await CreateBankPayment(request, transaction);
            }
            else
            {
                transaction.State = StateConstants.Approved;
                transaction.Message = Messages.Approved;
                transaction.Status = TransactionStatus.Approved;
                transaction.UpdatedDate = DateTime.Now;
            }
            await _unitOfWork.CommitAsync();
            return transaction;
        }

        /// <summary>
        /// Creates the finally.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionInfo> CreateFinally(FinallyPaymentRequest request)
        {
            var transaction = request.Transaction;

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

            transaction.EmployeeId = employee.Id;
            transaction.StoreId = store.Id;
            transaction.Message = Messages.Waiting;
            transaction.Status = TransactionStatus.Waiting;
            transaction.PayProvider = PaymentProvider.Bank;
            //await _unitOfWork.CommitAsync();

            var patient = transaction.Patient;

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

            var refundTotal = localRefundTotal + bankRefundTotal;
            var registeredCode = transaction.Reception?.RegisteredCode;
            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(f => f.TekmediCardNumber == patient.TekmediCardNumber);
            if (cardInfo != null)
            {
                var balance = cardInfo.Balance;

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

                if (extraTotal > 0)
                {
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
                        _unitOfWork.GetRepository<TekmediCard>().Update(cardInfo);
                    }
                    else
                    {
                        foreach (var item in extraDraftTransactions)
                        {
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
                        transaction = await CreateBankPayment(request, transaction);
                    }
                }
                else
                {
                    transaction.Status = TransactionStatus.Success;
                    transaction.State = StateConstants.Approved;
                    transaction.PayProvider = PaymentProvider.Local;
                    transaction.Message = Messages.Approved;
                    transaction.UpdatedDate = DateTime.Now;
                }
            }
            else
            {
                if (extraTotal > 0)
                {
                    foreach (var item in extraDraftTransactions)
                    {
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
                    transaction = await CreateBankPayment(request, transaction);
                }
                else
                {
                    transaction.Status = TransactionStatus.Success;
                    transaction.State = StateConstants.Approved;
                    transaction.PayProvider = PaymentProvider.Local;
                    transaction.Message = Messages.Approved;
                    transaction.UpdatedDate = DateTime.Now;
                }
            }

            _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            await _unitOfWork.CommitAsync();
            return transaction;
        }

        /// <summary>
        /// Refunds to local card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="localRefundDraftTransactions">The local refund draft transactions.</param>
        /// <param name="localRefundTotal">The local refund total.</param>
        /// <param name="cardInfo">The card information.</param>
        private void RefundToLocalCard(FinallyPaymentRequest request,
            TransactionInfo transaction,
            IEnumerable<TransactionDraft> localRefundDraftTransactions,
            decimal localRefundTotal,
            TekmediCard cardInfo)
        {
            var balance = cardInfo.Balance;
            var newBalance = balance + localRefundTotal;
            var refundHistory = new TekmediCardHistory
            {
                TekmediCardNumber = cardInfo.TekmediCardNumber,
                PatientId = transaction.PatientId,
                Amount = localRefundTotal,
                Time = DateTime.Now,
                Type = TypeEnum.Refund,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = cardInfo.Id,
                BeforeValue = balance,
                AfterValue = newBalance
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(refundHistory);

            foreach (var item in localRefundDraftTransactions)
            {
                var refundTransaction = CreateTrasaction(item);
                refundTransaction.Status = TransactionStatus.Approved;
                refundTransaction.PayProvider = PaymentProvider.Local;
                refundTransaction.State = StateConstants.Approved;
                refundTransaction.Message = Messages.Approved;
                _unitOfWork.GetRepository<TransactionInfo>().Add(refundTransaction);
            }
        }

        /// <summary>
        /// Gets the by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="hospitalCode">The hospital code.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Patient> GetByNumber(string number, string hospitalCode)
        {
            var bankAccount = await _unitOfWork.GetRepository<BankAccount>().FindAsync(t => t.CardNumber == number);
            if (bankAccount == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            var bankInstrument = await _unitOfWork.GetRepository<BankInstrument>().FindAsync(t => t.BankAccountId == bankAccount.Id);
            if (bankInstrument == null || bankInstrument.State != "approved")
            {
                throw new Exception(ErrorMessages.NotActiveBankAccount);
            }

            var bankCard = bankAccount.BankCards.FirstOrDefault(c => c.HospitalCode == hospitalCode);
            if (bankCard == null)
            {
                throw new Exception(ErrorMessages.NotLinkedHospitalAndBank);
            }
            var code = HospitalHelper.BuildPatientCode(bankCard.PatientCode, hospitalCode);

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(t => t.Code == code);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumberMappingWithPatient);
            }

            return patient;
        }

        /// <summary>
        /// Creates the bank request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        private async Task<TransactionInfo> CreateBankPayment(AdvancePaymentRequest request, TransactionInfo transaction)
        {
            var data = new CreateBankPaymentRequest();
            data.CardNumber = request.CardNumber;
            data.DeviceId = request.DeviceId;
            data.TransactionInfoId = transaction.Id;
            var stringContent = JsonConvert.SerializeObject(data);
            var client = _clientFactory.CreateClient(NamedClientConstants.Bank);
            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var url = InternalBankSettingHelper.GetEndPoint(_internalBankSettings.InternalBank.BaseUrl, _internalBankSettings.InternalBank.CreatePaymentUrl);
            var responseMessage = await client.PostAsync(url, body);
            var responseText = await responseMessage.Content.ReadAsStringAsync();
            // Success
            if (responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.Created)
            {
                var resObj = JsonConvert.DeserializeObject<BaseInternalResponse<BankTransactionResponseJson>>(responseText);
                if (resObj != null && resObj.Result != null)
                {
                    var result = resObj.Result;
                    transaction.State = result.state;
                    transaction.PaymentRefId = result.id;
                    transaction.UpdatedDate = DateTime.Now;
                    if (result.state == StateConstants.Approved)
                    {
                        transaction.Message = Messages.Approved;
                        transaction.Status = TransactionStatus.Approved;
                    }

                    if (result.state == StateConstants.Failed)
                    {
                        transaction.Message = resObj.Result.reason.message;
                        transaction.Reason = JsonConvert.SerializeObject(resObj.Result.reason);
                        transaction.Status = TransactionStatus.Failed;
                    }

                    if (result.state == StateConstants.AuthorizationRequired)
                    {
                        transaction.Message = ErrorMessages.AuthorizationBank;
                        transaction.Authorization = JsonConvert.SerializeObject(resObj.Result.authorization);
                        transaction.Status = TransactionStatus.AuthorizationRequired;
                    }
                }
            }
            else
            {
                var resObj = JsonConvert.DeserializeObject<ErrorResponse>(responseText);
                if (resObj != null)
                {
                    transaction.Message = resObj.Message;
                }

                transaction.Status = TransactionStatus.Failed;
                transaction.State = StateConstants.Failed;
                transaction.UpdatedDate = DateTime.Now;
            }
            return transaction;
        }

        /// <summary>
        /// Creates the trasaction.
        /// </summary>
        /// <param name="draftTransaction">The draft transaction.</param>
        /// <returns></returns>
        private TransactionInfo CreateTrasaction(TransactionDraft draftTransaction)
        {
            var transaction = _mapper.Map<TransactionInfo>(draftTransaction);
            transaction.TransactionClinics = draftTransaction.TransactionDraftClinics.Select(_mapper.Map<TransactionClinic>).ToList();
            transaction.TransactionPrescriptions = draftTransaction.TransactionDraftPrescriptions.Select(_mapper.Map<TransactionPrescription>).ToList();
            return transaction;
        }

        /// <summary>
        /// Creates the trasaction.
        /// </summary>
        /// <param name="parentTransaction">The parent transaction.</param>
        /// <param name="draftTransactions">The draft transactions.</param>
        /// <returns></returns>
        private TransactionInfo CreateTrasaction(TransactionInfo parentTransaction, List<TransactionDraft> draftTransactions)
        {
            var transactionId = Guid.NewGuid();
            var transaction = new TransactionInfo
            {
                Id = transactionId,
                Message = Messages.New,
                PatientCode = parentTransaction.PatientCode,
                RegisteredCode = parentTransaction.RegisteredCode,
                RegisteredDate = parentTransaction.RegisteredDate,
                ExaminationType = parentTransaction.ExaminationType,
                Status = TransactionStatus.New,
                Type = TransactionType.Extra,
                PatientId = parentTransaction.PatientId,
                StoreId = parentTransaction.StoreId,
                EmployeeId = parentTransaction.EmployeeId,
                ReceptionId = parentTransaction.ReceptionId,
                CreatedBy = Systems.CreatedBy,
                UpdatedBy = Systems.UpdatedBy,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            transaction.TransactionClinics = draftTransactions
                .SelectMany(d => d.TransactionDraftClinics.Select(_mapper.Map<TransactionClinic>))
                .ToList();

            transaction.TransactionPrescriptions = draftTransactions
                .SelectMany(d => d.TransactionDraftPrescriptions.Select(_mapper.Map<TransactionPrescription>))
                .ToList();

            return transaction;
        }

        public Task<AccountBalanceStatus> Calculate(string cardnumber, IEnumerable<TransactionInfo> transactions)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionInfo> Cancel(TransactionInfo transaction)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CardInfo>> GetByPatientCode(string patientCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CardHistoryInfo>> GetHistoryByCodeAndNumber(string code, string cardNumber)
        {
            throw new NotImplementedException();
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

        public Task<TransactionInfo> CreateDraft(AdvancePaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
