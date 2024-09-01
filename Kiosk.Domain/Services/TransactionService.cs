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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.VM.PaymentModels.Requests;
using Microsoft.EntityFrameworkCore;
using CS.EF.Models;
using System.Linq;
using CS.Common.Common;
using CS.VM.PostModels;
using static CS.Common.Common.Constants;
using CS.VM.ClinicModels;
using TEK.Gateway.Domain.BusinessObjects;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using System.Linq.Expressions;
using AutoMapper;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using TEK.Payment.Domain.Models.Responses;
using CS.VM.Responses;
using CS.VM.Models;
using CS.VM.Requests;
using TEK.Core.Helpers;
using CS.VM.PaymentModels.Models;
using CS.Common.Enums;
using CS.Common.Extensions;
using TEK.Core.Settings;

namespace TEK.Payment.Domain.Services
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

        private readonly ITransactionNumberUserService _transactionNumberUserService;
        private readonly HospitalSettings _hospitalSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService" /> class.
        /// </summary>
        /// <param name="externalSystemService">The external system service.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public TransactionService(
            IHospitalSystemService externalSystemService,
            ITransactionNumberUserService transactionNumberUserService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            HospitalSettings hospitalSettings)
        {
            _hospitalSystemService = externalSystemService;
            _transactionNumberUserService = transactionNumberUserService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hospitalSettings = hospitalSettings;
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

        /// <summary>
        /// Creates the hold payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<ICollection<TransactionInfo>> CreateAdvancePayment(Patient patientInfo)
        {
            var transactionType = TransactionType.Hold;

            var result = await _hospitalSystemService.GetRawClinicList(new GetRawClinicListRequest
            {
                PatientCode = patientInfo.Code,
                RegisteredDate = DateTime.Now
            });

            if (result.Clinics != null
                && result.Clinics.Count == 0
                && result.Medicines != null
                && result.Medicines.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundClinicData);
            }

            // Get total amount
            decimal amountPrescriptionTotal = result.Medicines != null
                && result.Medicines.Count > 0
                ? (decimal)result.Medicines.Sum(item => item.Amount) : 0;

            decimal amountClinicTotal = result.Clinics != null
                && result.Clinics.Count > 0 ?
                (decimal)result.Clinics.Sum(item => item.Amount) : 0;

            var amountTotal = amountPrescriptionTotal + amountClinicTotal;

            //
            var clinicData = new GetClinicListWithClinicData();
            var clinicList = result.Clinics.GroupBy(g => g.ReceptionId);
            var medicineList = result.Medicines.GroupBy(g => g.ReceptionId);

            var receptionIds = new List<Guid>();
            var registeredCodeClinics = result.Clinics.Select(s => s.ReceptionId);
            var registeredCodeMedicines = result.Medicines.Select(s => s.ReceptionId);
            if (registeredCodeClinics != null && registeredCodeClinics.Count() > 0)
            {
                receptionIds.AddRange(registeredCodeClinics);
            }

            if (registeredCodeMedicines != null && registeredCodeMedicines.Count() > 0)
            {
                receptionIds.AddRange(registeredCodeMedicines);
            }

            receptionIds = receptionIds.Distinct().ToList();
            var transactions = new List<TransactionInfo>();

            foreach (var receptionId in receptionIds)
            {
                // Get reception info by patient code and registered code
                var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == patientInfo.Code
                                        && r.Id == receptionId);
                if (reception == null)
                {
                    throw new Exception(ErrorMessages.NotFoundReceptionNumber);
                    //reception = new Reception
                    //{
                    //    Id = Guid.NewGuid(),
                    //    PatientCode = patientInfo.Code,
                    //    PatientId = patientInfo.Id,
                    //    PatientType = string.Empty,
                    //    RegisteredCode = receptionId,
                    //    RegisteredDate = DateTime.Now,
                    //    Status = ReceptionStatus.Success,
                    //    Type = ReceptionType.New,
                    //    CreatedBy = Systems.CreatedBy,
                    //    CreatedDate = DateTime.Now,
                    //    UpdatedBy = Systems.UpdatedBy,
                    //    UpdatedDate = DateTime.Now
                    //};
                    //_unitOfWork.GetRepository<Reception>().Add(reception);
                    //await _unitOfWork.CommitAsync();
                }

                if (clinicList != null && clinicList.Count() > 0)
                {
                    var clinicItems = clinicList.SingleOrDefault(f => f.Key == receptionId)?.ToList();
                    if (clinicItems != null && clinicItems.Count > 0)
                    {
                        clinicData.Clinics = clinicItems;
                    }
                }

                var prescriptionData = new GetClinicListWithPrescriptionData();
                if (medicineList != null && medicineList.Count() > 0)
                {
                    var medicineItems = medicineList.SingleOrDefault(f => f.Key == receptionId)?.ToList();
                    if (medicineItems != null && medicineItems.Count > 0)
                    {
                        prescriptionData.Medicines = medicineItems;
                    }
                }

                var transaction = await CreateAdvancePayment(patientInfo, transactionType, clinicData, reception, prescriptionData);
                transactions.Add(transaction);
            }
            await _unitOfWork.CommitAsync();

            return transactions;
        }

        /// <summary>
        /// Creates the advance payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="registeredCode">The registered code.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionInfo> CreateAdvancePayment(Patient patientInfo, string registeredCode)
        {
            var transactionType = TransactionType.Hold;

            var result = await _hospitalSystemService.GetRawClinicList(new GetRawClinicListRequest
            {
                PatientCode = patientInfo.Code,
                RegisteredDate = DateTime.Now
            });

            if (result.Clinics != null
                && result.Clinics.Count == 0
                && result.Medicines != null
                && result.Medicines.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundClinicData);
            }

            // Get reception info by patient code and registered code
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == patientInfo.Code
                                    && r.RegisteredCode == registeredCode);
            if (reception == null)
            {
                reception = new Reception
                {
                    PatientCode = patientInfo.Code,
                    PatientId = patientInfo.Id,
                    PatientType = string.Empty,
                    RegisteredCode = registeredCode,
                    RegisteredDate = DateTime.Now,
                    Status = ReceptionStatus.Success,
                    Type = ReceptionType.New,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now
                };

                _unitOfWork.GetRepository<Reception>().Add(reception);
                await _unitOfWork.CommitAsync();
            }

            // Get total amount
            decimal amountPrescriptionTotal = result.Medicines != null
                && result.Medicines.Count > 0
                ? (decimal)result.Medicines.Sum(item => item.Amount) : 0;

            decimal amountClinicTotal = result.Clinics != null
                && result.Clinics.Count > 0 ?
                (decimal)result.Clinics.Sum(item => item.Amount) : 0;

            var amountTotal = amountPrescriptionTotal + amountClinicTotal;

            //
            var clinicData = new GetClinicListWithClinicData();
            var clinicList = result.Clinics.GroupBy(g => g.ReceptionId);
            var medicineList = result.Medicines.GroupBy(g => g.ReceptionId);

            var receptionIds = new List<Guid>();
            var registeredCodeClinics = result.Clinics.Select(s => s.ReceptionId);
            var registeredCodeMedicines = result.Medicines.Select(s => s.ReceptionId);
            if (registeredCodeClinics != null && registeredCodeClinics.Count() > 0)
            {
                receptionIds.AddRange(registeredCodeClinics);
            }

            if (registeredCodeMedicines != null && registeredCodeMedicines.Count() > 0)
            {
                receptionIds.AddRange(registeredCodeMedicines);
            }

            receptionIds = receptionIds.Distinct().ToList();
            var registeredCodeItem = receptionIds.FirstOrDefault(c => c == reception.Id);

            if (clinicList != null && clinicList.Count() > 0)
            {
                var clinicItems = clinicList.SingleOrDefault(f => f.Key == registeredCodeItem)?.ToList();
                if (clinicItems != null && clinicItems.Count > 0)
                {
                    clinicData.Clinics = clinicItems;
                }
            }

            var prescriptionData = new GetClinicListWithPrescriptionData();
            if (medicineList != null && medicineList.Count() > 0)
            {
                var medicineItems = medicineList.SingleOrDefault(f => f.Key == registeredCodeItem)?.ToList();
                if (medicineItems != null && medicineItems.Count > 0)
                {
                    prescriptionData.Medicines = medicineItems;
                }
            }

            var transaction = await CreateAdvancePayment(patientInfo, transactionType, clinicData, reception, prescriptionData);

            var extraTransaction = CreateDraftTrasaction(patientInfo,
                                        TransactionType.Extra,
                                        TransactionStatus.New,
                                        Messages.New,
                                        reception,
                                        transaction.TransactionClinics,
                                        transaction.TransactionPrescriptions);
            extraTransaction.TransactionInfoId = transaction.Id;

            await _unitOfWork.CommitAsync();

            return transaction;
        }

        /// <summary>
        /// Creates the payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="registeredCode">The registered code.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<TransactionInfo> CreatePayment(Patient patientInfo, string registeredCode)
        {
            var transactionType = TransactionType.Paid;
            var result = await _hospitalSystemService.GetRawFinallyClinicList(new GetRawFinallyClinicListRequest
            {
                PatientCode = patientInfo.Code,
                RegisteredCode = registeredCode
            });

            if (result.Clinics != null
                && result.Clinics.Count == 0
                && result.Medicines != null
                && result.Medicines.Count == 0
                && result.InsuranceMedicines != null
                && result.InsuranceMedicines.Count == 0)
            {
                throw new Exception(ErrorMessages.NotFoundClinicData);
            }

            // Get reception info by patient code and registered code
            var reception = await _unitOfWork.GetRepository<Reception>().FindAsync(r => r.PatientCode == patientInfo.Code
                                    && r.RegisteredCode == registeredCode);
            if (reception == null)
            {
                reception = new Reception
                {
                    PatientCode = patientInfo.Code,
                    PatientId = patientInfo.Id,
                    PatientType = string.Empty,
                    RegisteredCode = registeredCode,
                    RegisteredDate = DateTime.Now,
                    Status = ReceptionStatus.Success,
                    Type = ReceptionType.New,
                    CreatedBy = Systems.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = Systems.UpdatedBy,
                    UpdatedDate = DateTime.Now
                };
                _unitOfWork.GetRepository<Reception>().Add(reception);
                await _unitOfWork.CommitAsync();
            }

            if (reception.Type == ReceptionType.Paid && reception.Status == ReceptionStatus.Success)
            {
                throw new Exception(ErrorMessages.RegisteredCodeIsPaid);
            }

            var transaction = await CreatePayment(patientInfo, transactionType, result.Clinics, reception, result.Medicines, result.InsuranceMedicines);
            var lastTransaction = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .Where(t => t.InvoiceNo.HasValue
                && t.RegisteredCode == transaction.RegisteredCode
                && t.Status == TransactionStatus.Success)
                .OrderBy(o => o.CreatedDate).FirstOrDefault();
            if (lastTransaction != null)
            {
                transaction.CreatedDate = lastTransaction.CreatedDate;
                transaction.UpdatedDate = lastTransaction.UpdatedDate;
            }

            var createdDate = transaction.CreatedDate;
            var updatedDate = transaction.UpdatedDate;

            var notYetFinishedClinics = result.Clinics.Where(c => c.IsFinished != StatusServiceConstants.Finished).Select(c => c.IdSpecified);
            var finishedClinics = result.Clinics.Where(c => c.IsFinished == StatusServiceConstants.Finished).Select(c => c.IdSpecified);

            var transactions = await _unitOfWork.GetRepository<TransactionInfo>()
                .GetAll().Where(t => t.PatientCode == patientInfo.Code
             && t.RegisteredCode == reception.RegisteredCode
             && (t.Type == TransactionType.Hold || t.Type == TransactionType.Refund)
             && t.Status == TransactionStatus.Success).ToListAsync();

            var holdTransactions = transactions.Where(t => t.Type == TransactionType.Hold).ToList();

            var refundClinics = transactions.Where(t => t.Type == TransactionType.Refund)
                .SelectMany(s => s.TransactionClinics)
                .Select(c => c.IdSpecified).ToList();

            var refundPrescriptions = transactions.Where(t => t.Type == TransactionType.Refund)
                .SelectMany(s => s.TransactionPrescriptions)
                .ToList();

            var draftTransactions = new List<TransactionDraft>();
            var refundIds = new List<string>();

            foreach (var transactionItem in holdTransactions)
            {
                // Refund clinic
                var transactionClinics = transactionItem.TransactionClinics.ToList();
                var clinics = transactionClinics.Where(c => notYetFinishedClinics.Any(id => id == c.IdSpecified)
                && !refundClinics.Any(id => id == c.IdSpecified)).ToList();
                refundIds.AddRange(clinics.Select(s => s.IdSpecified));

                var removedClinics = transactionClinics.Where(c => !finishedClinics.Any(id => id == c.IdSpecified)
                && !refundClinics.Any(id => id == c.IdSpecified)
                && !refundIds.Any(id => id == c.IdSpecified));
                refundIds.AddRange(removedClinics.Select(s => s.IdSpecified));

                clinics.AddRange(removedClinics);

                // Refund prescription
                var transactionPrescriptions = transactionItem.TransactionPrescriptions.ToList();
                var prescriptions = transactionPrescriptions.Where(p => !result.Medicines.Any(m => m.PrescriptionId == p.PrescriptionDataId
                && m.PrescriptionDetailId == p.PrescriptionDetailId
                && m.MedicineCode == p.MedicineCode)
                && !refundPrescriptions.Any(m => m.PrescriptionDataId == p.PrescriptionDataId
                && m.PrescriptionDetailId == p.PrescriptionDetailId
                && m.MedicineCode == p.MedicineCode));

                if (clinics.Count() > 0 || prescriptions.Count() > 0)
                {
                    var refundTransaction = CreateDraftTrasaction(patientInfo,
                                                TransactionType.Refund,
                                                TransactionStatus.New,
                                                Messages.New,
                                                reception,
                                                clinics,
                                                prescriptions);

                    refundTransaction.TransactionInfoId = transaction.Id;
                    refundTransaction.PaymentRefId = transactionItem.PaymentRefId;
                    refundTransaction.PayProvider = transactionItem.PayProvider;
                    refundTransaction.CreatedDate = createdDate;
                    refundTransaction.UpdatedDate = updatedDate;
                    draftTransactions.Add(refundTransaction);
                    continue;
                }
            }


            var existingClinics = transactions.SelectMany(s => s.TransactionClinics)
                .Select(c => c.IdSpecified);

            var existingPrescriptions = transactions
                .SelectMany(s => s.TransactionPrescriptions);

            // Lấy danh sách clinic đã hoàn thành (vì nếu phát sinh phí BHYT sẽ được update)
            var clinicList = await _unitOfWork.GetRepository<Clinic>()
                .GetAll()
                .Where(x => finishedClinics.Any(f => f == x.IdSpecified)
                && x.ReceptionId == reception.Id).ToListAsync();
            // Lấy danh sách clinic đã hold ban đầu
            var holdClinic = holdTransactions.SelectMany(s => s.TransactionClinics).ToList();
            // Danh sách dịch vụ có chi phí chênh lệch khi hold và tất toán (phí BHYT)
            var hasInsuranceFeeClinics = clinicList.Where(x => holdClinic.Any(h => h.IdSpecified == x.IdSpecified && h.Amount < x.Amount)).Select(x => x.IdSpecified).ToList();
            // New clinic
            IEnumerable<TransactionClinic> newClinicsOrHasInsuranceFee = null;
            if (hasInsuranceFeeClinics.Count > 0)
            {
                newClinicsOrHasInsuranceFee = transaction.TransactionClinics
                .Where(c => (!existingClinics.Any(id => id == c.IdSpecified)
                || hasInsuranceFeeClinics.Any(id => id == c.IdSpecified))
                && c.IsFinished == StatusServiceConstants.Finished);
            }
            else
            {
                newClinicsOrHasInsuranceFee = transaction.TransactionClinics
                .Where(c => !existingClinics.Any(id => id == c.IdSpecified)
                && c.IsFinished == StatusServiceConstants.Finished);
            }

            // New prescription
            var newPrescription = transaction.TransactionPrescriptions.Where(p => !existingPrescriptions.Any(m => m.PrescriptionDataId == p.PrescriptionDataId
            && m.PrescriptionDetailId == p.PrescriptionDetailId
            && m.MedicineCode == p.MedicineCode));

            if (newClinicsOrHasInsuranceFee.Count() > 0 || newPrescription.Count() > 0)
            {
                var extraTransaction = CreateDraftTrasaction(patientInfo,
                                            TransactionType.Extra,
                                            TransactionStatus.New,
                                            Messages.New,
                                            reception,
                                            newClinicsOrHasInsuranceFee,
                                            newPrescription);
                extraTransaction.TransactionInfoId = transaction.Id;
                extraTransaction.CreatedDate = createdDate;
                extraTransaction.UpdatedDate = updatedDate;
            }

            await _unitOfWork.CommitAsync();
            return transaction;
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="reception">The reception.</param>
        /// <returns></returns>
        public async Task<TransactionInfo> UpdateHoldStatus(TransactionInfo transaction, Reception reception)
        {
            if (transaction.State == StateConstants.Approved)
            {
                var updateResponse = await _hospitalSystemService.PostRawClinicList(new ChargeRawClinicListRequest
                {
                    TransactionId = transaction.Id
                });

                if (updateResponse.Success)
                {
                    transaction.Status = TransactionStatus.Success;
                    transaction.Message = Messages.Success;
                    transaction.State = StateConstants.Finished;

                    reception.Status = ReceptionStatus.Success;
                }
                else
                {
                    transaction.Message = updateResponse.Message;
                    var reason = new PaymentReason
                    {
                        name = nameof(ErrorMessages.UpdateFailedHIS),
                        message = updateResponse.Message
                    };
                    transaction.Reason = JsonConvert.SerializeObject(reason);

                    reception.Status = ReceptionStatus.Failed;
                }

                reception.UpdatedDate = DateTime.Now;
            }

            if (transaction.State == StateConstants.Failed
                && !string.IsNullOrEmpty(transaction.Reason))
            {
                reception.Status = ReceptionStatus.Failed;
                reception.UpdatedDate = DateTime.Now;
            }

            _unitOfWork.GetRepository<Reception>().Update(reception);
            _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            await _unitOfWork.CommitAsync();
            return transaction;
        }

        public string GetNote(TransactionInfo transaction, TransactionInfo cancelledTransaction)
        {
            var note = "";
            var diffStr = "";
            var diffAmount = transaction.Amount - cancelledTransaction.Amount;
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

        public async Task TransferMoneyFromOldToNewRegisteredCode(TransactionInfo transaction, Reception reception)
        {
            var patient = _unitOfWork.GetRepository<Patient>().GetAll()
                .Where(x => x.Code == reception.PatientCode)
                .FirstOrDefault();
            if (patient == null)
            {
                return;
            }

            var tekmediCard = _unitOfWork.GetRepository<TekmediCard>().GetAll().Where(card => card.TekmediCardNumber == patient.TekmediCardNumber).FirstOrDefault();
            if (tekmediCard == null)
            {
                return;
            }

            if (tekmediCard.Balance <= 0)
            {
                return;
            }

            // Tìm mã điều trị có ngày tạo lớn hơn và gần nhất
            var newestReception = _unitOfWork.GetRepository<Reception>().GetAll()
                .OrderBy(x => x.CreatedDate)
                .FirstOrDefault(x => x.PatientCode == patient.Code
                    && x.RegisteredCode != reception.RegisteredCode
                    && x.CreatedDate > reception.CreatedDate);
            if (newestReception == null)
            {
                return;
            }

            if (newestReception.IsFinished)
            {
                return;
            }

            // Tạm ứng tái khám sẽ dùng user TCKTTAIKHAM
            var employee = _unitOfWork.GetRepository<SysUser>().GetAll().FirstOrDefault(x => x.UserName == "TCKTTAIKHAM");
            if (employee == null)
            {
                return;
            }

            var amountToTransfer = tekmediCard.Balance;

            // Hoàn tiền mã điều trị cũ
            var refundHistory = new TekmediCardHistory
            {
                TekmediCardNumber = tekmediCard.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = amountToTransfer,
                Time = DateTime.Now.AddSeconds(-1),
                Type = TypeEnum.Refund,
                EmployeeId = employee.Id,
                Status = StatusEnum.Waiting,
                TekmediCardId = tekmediCard.Id,
                BeforeValue = amountToTransfer,
                AfterValue = 0,
                RegisterCode = reception.RegisteredCode,
                // Tiền mặt 2ad096a6-c9b7-42bd-85d2-9bb2b6b4aac4
                PaymentTypeId = Guid.Parse("2ad096a6-c9b7-42bd-85d2-9bb2b6b4aac4")
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(refundHistory);
            tekmediCard.Balance = 0;
            _unitOfWork.GetRepository<TekmediCard>().Update(tekmediCard);
            await _unitOfWork.CommitAsync();

            // Tạm ứng mã điều trị mới
            var addPaymentRequest = new AdminApiAddPaymentRequest
            {
                TekmediCardNumber = tekmediCard.TekmediCardNumber,
                Price = amountToTransfer,
                EmployeeId = employee.Id,
                PatientCode = patient.Code,
                PaymentTypeId = Guid.Parse("2ad096a6-c9b7-42bd-85d2-9bb2b6b4aac4"),
                RegisterCode = newestReception.RegisteredCode,
                RecvNo = 0,
            };

            // Hoàn ứng mã điều trị cũ
            var updateRefundRequest = new UpdateRawRefundRequest
            {
                HospitalCode = _hospitalSettings.Hospital.HospitalCode,
                ManagementCode = reception.RegisteredCode,
                PatientType = reception.ObjectType,
                PatientCode = patient.Code,
                RegisteredCode = reception.RegisteredCode,
                EmployeeCode = employee.Code,
                Amount = amountToTransfer,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                BookNo = transaction.BookNo,
                SerialNo = transaction.SerialNo,
                RecvNo = transaction.RecvNo.Value
            };

            try
            {
                // Gọi nạp thẻ của admin api, thất bại thì trả lại tiền vào thẻ
                var addPaymentResponse = await _hospitalSystemService.AdminApiAddPayment(addPaymentRequest);
                if (addPaymentResponse.Success == false)
                {
                    refundHistory.Status = StatusEnum.Failed;
                    _unitOfWork.GetRepository<TekmediCardHistory>().Update(refundHistory);
                    tekmediCard.Balance = amountToTransfer;
                    _unitOfWork.GetRepository<TekmediCard>().Update(tekmediCard);
                    await _unitOfWork.CommitAsync();
                    return;
                }

                var updateRefundResponse = await _hospitalSystemService.UpdateRefund(updateRefundRequest);
                // Gọi hoàn ứng của HIS, thất bại thì trả lại tiền vào thẻ
                if (updateRefundResponse.Result.StatusCode != "00" && updateRefundResponse.Result.Status != "success")
                {
                    refundHistory.Status = StatusEnum.Failed;
                    _unitOfWork.GetRepository<TekmediCardHistory>().Update(refundHistory);
                    tekmediCard.Balance = amountToTransfer;
                    _unitOfWork.GetRepository<TekmediCard>().Update(tekmediCard);
                    await _unitOfWork.CommitAsync();
                    return;
                }

                // Gọi nạp thẻ của admin api, hoàn ứng của HIS thành công
                var numberConfig = _transactionNumberUserService.GetRefundConfig(employee.Id);
                if (numberConfig != null)
                {
                    refundHistory.SerialNo = numberConfig.SerialNo;
                    refundHistory.BookNo = numberConfig.BookNo;
                    refundHistory.RecvNo = numberConfig.RecvNo;
                    numberConfig = _transactionNumberUserService.GetNextNumberConfig(numberConfig);
                    _unitOfWork.GetRepository<TransactionNumberConfig>().Update(numberConfig);
                }

                refundHistory.Status = StatusEnum.Success;
                _unitOfWork.GetRepository<TekmediCardHistory>().Update(refundHistory);
                await _unitOfWork.CommitAsync();
            }
            // Gọi nạp thẻ của admin api, hoàn ứng của HIS thất bại thì trả lại tiền vào thẻ
            catch (Exception ex)
            {
                refundHistory.Status = StatusEnum.Failed;
                _unitOfWork.GetRepository<TekmediCardHistory>().Update(refundHistory);
                tekmediCard.Balance = amountToTransfer;
                _unitOfWork.GetRepository<TekmediCard>().Update(tekmediCard);
                await _unitOfWork.CommitAsync();
            }
        }

        /// <summary>
        /// Updates the payment status.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="reception">The reception.</param>
        /// <returns></returns>
        public async Task<TransactionInfo> UpdatePaymentStatus(TransactionInfo transaction, Reception reception, TransactionNumberConfig numberconfig)
        {
            if (transaction.State == StateConstants.Approved)
            {
                var bookNo = numberconfig.BookNo;
                var recvNo = numberconfig.RecvNo;
                var serialNo = numberconfig.SerialNo;
                var bookNoCancel = "";
                var serialNoCancel = "";
                var recvNoCancel = 0;
                var transactionIdCancel = "";
                var cancelledTransaction = await _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(
                    x => x.RegisteredCode == transaction.RegisteredCode && x.Type == TransactionType.Cancelled && x.Status == TransactionStatus.Success)
                    .OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();
                var note = "";
                if (cancelledTransaction != null)
                {
                    note = GetNote(transaction, cancelledTransaction);
                    bookNoCancel = cancelledTransaction.BookNo;
                    serialNoCancel = cancelledTransaction.SerialNo;
                    recvNoCancel = cancelledTransaction.RecvNo.Value;
                    transactionIdCancel = cancelledTransaction.Id.ToString();
                }

                decimal extraFeeAmount = 0;
                // Lấy thu tiếp mới nhất
                var extraFeeHistory = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                    .OrderByDescending(x => x.Time)
                    .FirstOrDefault(x => x.RegisterCode == transaction.RegisteredCode
                        && x.Type == TypeEnum.ExtraFee
                        && x.Status == StatusEnum.Success);
                TekmediCardCancelHistory cancelExtraFeeHistory = null;
                if (extraFeeHistory != null)
                {
                    cancelExtraFeeHistory = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                        .FirstOrDefault(x => x.TekmediCardHistoryId == extraFeeHistory.Id);
                    // Nếu chưa hủy thu tiếp
                    if (cancelExtraFeeHistory == null)
                    {
                        extraFeeAmount = extraFeeHistory.Amount.Value;
                    }
                }

                var updateResponse = await _hospitalSystemService.PostRawFinallyClinicList(new PayOffRawFinallyClinicListAtStoreRequest
                {
                    TransactionId = transaction.Id,
                    BookNo = bookNo,
                    RecvNo = recvNo,
                    SerialNo = serialNo,
                    Note = note,
                    ExtraFeeAmount = extraFeeAmount,
                    SerialNoCancel = serialNoCancel,
                    BookNoCancel = bookNoCancel,
                    RecvNoCancel = recvNoCancel,
                    TransactionIdCancel = transactionIdCancel
                });

                if (updateResponse.Success)
                {
                    if (numberconfig != null)
                    {
                        numberconfig = _transactionNumberUserService.GetNextNumberConfig(numberconfig);
                        _unitOfWork.GetRepository<TransactionNumberConfig>().Update(numberconfig);
                        _unitOfWork.Commit();
                    }

                    transaction.Status = TransactionStatus.Success;
                    transaction.Message = Messages.Success;
                    transaction.State = StateConstants.Finished;
                    transaction.InvoiceNo = updateResponse.Result.InvoiceNo;
                    transaction.SerialNo = updateResponse.Result.SerialNo;
                    transaction.RecvNo = updateResponse.Result.RecvNo;
                    transaction.BookNo = updateResponse.Result.BookNo;
                    if (cancelledTransaction != null)
                    {
                        transaction.CancelledTransactionInfoId = cancelledTransaction.Id;
                    }

                    reception.Status = ReceptionStatus.Success;
                    reception.IsFinished = true;

                    var history = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                        .Where(h => h.Type == TypeEnum.FinallyCharge
                        && h.Status == StatusEnum.Success
                        && h.RegisterCode == reception.RegisteredCode)
                        .OrderByDescending(s => s.Time)
                        .FirstOrDefaultAsync();

                    if (history != null)
                    {
                        history.InvoiceNo = transaction.InvoiceNo;
                        history.SerialNo = transaction.SerialNo;
                        history.RecvNo = transaction.RecvNo;
                        history.BookNo = transaction.BookNo;
                    }

                    if (extraFeeHistory != null && cancelExtraFeeHistory == null)
                    {
                        extraFeeHistory.InvoiceNo = transaction.InvoiceNo;
                        extraFeeHistory.SerialNo = transaction.SerialNo;
                        extraFeeHistory.RecvNo = transaction.RecvNo;
                        extraFeeHistory.BookNo = transaction.BookNo;
                    }

                    // Chuyển tiền từ mã điều trị cũ sang mã điều trị mới
                    await TransferMoneyFromOldToNewRegisteredCode(transaction, reception);
                }
                else
                {
                    if (updateResponse.Code == HISErrorCode.NotFoundFinallyInformationData)
                    {
                        transaction.Status = TransactionStatus.Success;
                        transaction.Message = Messages.Success;
                        transaction.State = StateConstants.Finished;

                        reception.Status = ReceptionStatus.Success;
                        reception.IsFinished = true;
                    }
                    else
                    {
                        transaction.State = StateConstants.Failed;
                        transaction.Message = updateResponse.Message;
                        var reason = new PaymentReason
                        {
                            name = nameof(ErrorMessages.UpdateFailedHIS),
                            message = updateResponse.Message
                        };
                        transaction.Reason = JsonConvert.SerializeObject(reason);
                        reception.Status = ReceptionStatus.Failed;
                    }
                }

                reception.UpdatedDate = DateTime.Now;
            }

            _unitOfWork.GetRepository<Reception>().Update(reception);
            _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            await _unitOfWork.CommitAsync();
            return transaction;
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
                    throw new Exception(ErrorMessages.NotStatisfyHoldConditionToCancel);

                isInValidCondition = clinicList.Any(c => c.IsFinished == StatusServiceConstants.Finished);

                if (isInValidCondition)
                    throw new Exception(ErrorMessages.NotStatisfyNoFinishConditionToCancel);

                var refundClinicResponse = await _hospitalSystemService.RefundClinicList(new RefundRegistrationRawRequest { TransactionId = transaction.Id });

                if (refundClinicResponse.Success)
                {
                    //var jsonPayment = await _unitOfWork.GetRepository<HsoftPaymentHistory>().FindAsync(x => x.TransactionId == transaction.Id);
                    //var clinicResult = await CreateOrUpdateClinic(JsonConvert.DeserializeObject<List<GetRawClinicListResponseData>>(jsonPayment.Json), patient, reception, ClinicStatus.Cancelled);
                    foreach (var clinic in clinicList)
                    {
                        clinic.Type = TransactionType.Refund;
                        _unitOfWork.GetRepository<TransactionClinic>().Update(clinic);
                    }
                    await _unitOfWork.CommitAsync();

                    foreach (var prescription in prescriptions)
                    {
                        prescription.Type = TransactionType.Refund;
                        _unitOfWork.GetRepository<TransactionPrescription>().Update(prescription);
                    }
                    await _unitOfWork.CommitAsync();

                    var balance = tekmediCard.Balance;
                    var newBalance = balance + transaction.Amount;

                    await UpdateBalance(patient, tekmediCard, TypeEnum.Refund, newBalance, transaction.Amount, employee);
                    var refundTransaction = CreateTrasaction(transaction.Amount,
                        transaction.TotalFee,
                        transaction.InsuranceFee,
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
                    throw new Exception(refundClinicResponse.Message);
            }
            else
                throw new Exception(ErrorMessages.NotStatisfyConditionToCancel);
        }

        public async Task<IncreasePrintedBillCountResponse> IncreasePrintedBillCount(IncreasePrintedBillCountRequest request)
        {
            var response = new IncreasePrintedBillCountResponse();
            var transaction = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .FirstOrDefault(x => x.Id == request.Id);
            if (transaction == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionId);
            }

            transaction.PrintedBillCount++;
            transaction.UpdatedDate = DateTime.Now;
            _unitOfWork.GetRepository<TransactionInfo>().Update(transaction);
            await _unitOfWork.CommitAsync();

            response.Id = transaction.Id;
            response.PrintedBillCount = transaction.PrintedBillCount;
            return response;
        }

        /// <summary>
        /// Updates the balance.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="cardInfo">The card information.</param>
        /// <param name="cardType">Type of the card.</param>
        /// <param name="newBalance">The new balance.</param>
        /// <param name="amountTotal">The amount total.</param>
        /// <param name="employee">The employee.</param>
        private async Task UpdateBalance(Patient patientInfo, TekmediCard cardInfo, TypeEnum cardType, decimal newBalance, decimal amountTotal, SysUser employee = null)
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
                AfterValue = newBalance
            };

            _unitOfWork.GetRepository<TekmediCardHistory>().Add(history);
            await _unitOfWork.CommitAsync();

            cardInfo.Balance = newBalance;
            _unitOfWork.GetRepository<TekmediCard>().Update(cardInfo);
            await _unitOfWork.CommitAsync();
        }

        #region -- Private Method --
        #region -- Advance Payment --
        /// <summary>
        /// Creates the advance payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="clinicData">The clinic data.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="prescriptionData">The prescription data.</param>
        /// <returns></returns>
        private async Task<TransactionInfo> CreateAdvancePayment(Patient patientInfo,
            TransactionType transactionType,
            GetClinicListWithClinicData clinicData,
            Reception reception,
            GetClinicListWithPrescriptionData prescriptionData)
        {
            var clinicResults = await CreateOrUpdateClinic(
                                    clinicData.Clinics,
                                    patientInfo,
                                    reception,
                                    ClinicStatus.Hold);

            var prescriptionResults = CreateOrUpdatePrescription(
                prescriptionData.Medicines,
                patientInfo,
                PrescriptionStatus.Hold,
                PrescriptionType.UseWithService);

            // Get total amount
            decimal amountPrescriptionItemTotal = prescriptionData.Medicines != null
                && prescriptionData.Medicines.Count > 0
                ? (decimal)prescriptionData.Medicines.Sum(item => item.Amount) : 0;

            decimal amountPrescriptionItemTotalFee = prescriptionData.Medicines != null
                && prescriptionData.Medicines.Count > 0
                ? (decimal)prescriptionData.Medicines.Sum(item => item.TotalFee) : 0;

            decimal amountPrescriptionItemInsuranceFee = prescriptionData.Medicines != null
                && prescriptionData.Medicines.Count > 0
                ? (decimal)prescriptionData.Medicines.Sum(item => item.InsuranceFee) : 0;

            decimal amountClinicItemTotal = clinicData.Clinics != null
                && clinicData.Clinics.Count > 0 ?
                (decimal)clinicData.Clinics.Sum(item => item.Amount) : 0;

            decimal amountClinicItemTotalFee = clinicData.Clinics != null
                && clinicData.Clinics.Count > 0 ?
                (decimal)clinicData.Clinics.Sum(item => item.TotalFee) : 0;

            decimal amountClinicItemInsuranceFee = clinicData.Clinics != null
                && clinicData.Clinics.Count > 0 ?
                (decimal)clinicData.Clinics.Sum(item => item.InsuranceFee) : 0;

            decimal amountItemTotal = amountPrescriptionItemTotal + amountClinicItemTotal;
            decimal amountItemTotalFee = amountPrescriptionItemTotalFee + amountClinicItemTotalFee;
            decimal amountItemInsuranceFee = amountPrescriptionItemInsuranceFee + amountClinicItemInsuranceFee;

            var transaction = CreateTrasaction((decimal)amountItemTotal,
                                        amountItemTotalFee,
                                        amountItemInsuranceFee,
                                        patientInfo,
                                        transactionType,
                                        TransactionStatus.New,
                                        Messages.New,
                                        reception,
                                        clinicResults,
                                        prescriptionResults);
            return transaction;
        }

        /// <summary>
        /// Creates the or update clinic with charge list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="clinicInfo">The clinic information.</param>
        /// <returns>ICollection&lt;Clinic&gt;.</returns>
        private async Task<ICollection<Clinic>> CreateOrUpdateClinic(List<GetRawClinicListResponseData> data,
            Patient patientInfo,
            Reception reception,
            ClinicStatus? status)
        {
            ConcurrentBag<Clinic> clinicBag = new ConcurrentBag<Clinic>();
            if (data != null && data.Count > 0)
            {
                var departmentIds = data.Select(s => s.DepartmentCode);
                var examinationIds = data.Select(s => s.ExaminationCode);
                var serviceIds = data.Select(s => s.ServiceId);
                //var kxnDepartments = data.Where(d => d.DepartmentCode == Departments.KXN);
                //var kxnDepartmentIds = new List<string>();
                //if (kxnDepartments.Count() > 0)
                //{
                //    foreach (var item in kxnDepartments)
                //    {
                //        kxnDepartmentIds.Add(item.DepartmentCode + "_" + item.ExaminationCode);
                //    }

                //    kxnDepartmentIds = kxnDepartmentIds.Distinct().ToList();
                //    var kxnDepartment = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking().Where(v => kxnDepartmentIds.Any(id => id == v.Code)).ToListAsync();
                //    var kxnDepartmentDescription = kxnDepartment.Select(d => d.Description).Distinct();
                //    var kxnDepartmentDescriptionIds = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking().Where(v => kxnDepartmentDescription.Any(id => id == v.Description)).ToListAsync();
                //    kxnDepartmentIds.AddRange(kxnDepartmentDescriptionIds.Select(d => d.Code));
                //    kxnDepartmentIds.AddRange(kxnDepartmentDescription);
                //    kxnDepartmentIds.Add(Departments.CLSXN12);
                //}

                var serviceCodes = new List<string>(departmentIds.Count() + examinationIds.Count() + serviceIds.Count());
                serviceCodes.AddRange(departmentIds);
                serviceCodes.AddRange(examinationIds);
                serviceCodes.AddRange(serviceIds);
                //if (kxnDepartmentIds.Count > 0)
                //{
                //    serviceCodes.AddRange(kxnDepartmentIds);
                //}
                serviceCodes = serviceCodes.Distinct().ToList();
                var services = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking().Where(v => serviceCodes.Any(id => id == v.Code)).ToListAsync();
                var departmentTypeIds = services.Select(s => s.ListValueId);
                var departmentTypes = await _unitOfWork.GetRepository<ListValue>().GetAll().AsNoTracking().Where(v => departmentTypeIds.Any(id => id == v.Id)).ToListAsync();

                Parallel.ForEach(
                            data,
                            new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                            item =>
                            {
                                Clinic clinicModel = NewClinicModelBuilder(patientInfo, reception, status, item, services, departmentTypes);
                                clinicBag.Add(clinicModel);
                            });
            }

            return clinicBag.ToList();
        }

        /// <summary>
        /// Creates new clinicmodelbuilder.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="status">The status.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private Clinic NewClinicModelBuilder(Patient patientInfo,
            Reception reception,
            ClinicStatus? status,
            GetRawClinicListResponseData item,
            List<ListValueExtend> services,
            List<ListValue> departmentTypes)
        {
            var clinicPostModel = new ClinicPostModel
            {
                PatientCode = patientInfo.Code,
                IdSpecified = item.IdSpecified,
                //RegisteredDate = item.RegisteredDate,
                //RegisteredCode = item.RegisteredCode,
                PatientType = reception.PatientType,
                ServiceId = item.ServiceId,
                Money = (decimal)item.Amount,
                TotalFee = (decimal)item.TotalFee,
                InsuranceFee = (decimal)item.InsuranceFee,
                DepartmentCode = item.DepartmentCode,
                Note = item.Note,
                ExaminationCode = item.ExaminationCode,
                ClinicType = (ClinicType)item.ClinicType,
                IsFinished = item.IsFinished,
                ServiceType = item.ServiceType,
                //ManagementId = item.ManagementId,
                //ObjectType = item.ObjectType,
                Status = status.HasValue ? status.Value : ClinicStatus.New,
            };
            var clinic = _mapper.Map<Clinic>(clinicPostModel);
            clinic.PatientId = patientInfo.Id;
            clinic.ReceptionId = reception.Id;

            clinic = GetDepartment(clinic, services, departmentTypes);
            return clinic;
        }

        /// <summary>
        /// Creates the or update prescription with charge list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="prescriptionStatus">The prescription status.</param>
        /// <param name="prescriptionType">Type of the prescription.</param>
        /// <returns>ICollection&lt;Prescription&gt;.</returns>
        private ICollection<Prescription> CreateOrUpdatePrescription(
            List<GetRawListPrescriptionResponseData> data,
            Patient patientInfo,
            PrescriptionStatus? prescriptionStatus,
            PrescriptionType prescriptionType)
        {
            ConcurrentBag<Prescription> prescriptionBag = new ConcurrentBag<Prescription>();
            if (data != null && data.Count > 0)
            {
                Parallel.ForEach(
                    data,
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    item =>
                    {
                        var prescriptionPostModel = new PrescriptionPostModel
                        {
                            PatientCode = item.PatientCode,
                            RegisteredDate = DateTime.Now,
                            RegisteredCode = item.RegisteredCode,
                            PrescriptionDataId = item.PrescriptionId,
                            PrescriptionDetailId = item.PrescriptionDetailId,
                            MedicineCode = item.MedicineCode,
                            MedicineName = item.MedicineName,
                            Quantity = (int)item.Quantity,
                            Price = (decimal)item.UnitPrice,
                            Amount = (decimal)item.Amount,
                            TotalFee = (decimal)item.TotalFee,
                            InsuranceFee = (decimal)item.InsuranceFee,
                            Status = prescriptionStatus.HasValue ? prescriptionStatus.Value : PrescriptionStatus.New,
                            Type = prescriptionType
                        };
                        var prescriptionModel = _mapper.Map<Prescription>(prescriptionPostModel);
                        prescriptionModel.PatientId = patientInfo.Id;
                        prescriptionBag.Add(prescriptionModel);
                    });
            }
            return prescriptionBag.ToList();
        }

        /// <summary>
        /// Prescriptions the model builder.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="prescriptionStatus">The prescription status.</param>
        /// <param name="prescriptionType">Type of the prescription.</param>
        /// <param name="item">The item.</param>
        /// <param name="existingPrescription">The existing prescription.</param>
        private static void PrescriptionModelBuilder(Patient patientInfo,
            PrescriptionStatus? prescriptionStatus,
            PrescriptionType prescriptionType,
            GetRawListPrescriptionResponseData item,
            Prescription existingPrescription)
        {
            existingPrescription.PatientCode = item.PatientCode;
            existingPrescription.RegisteredDate = DateTime.Now;
            existingPrescription.RegisteredCode = item.RegisteredCode;
            existingPrescription.PrescriptionId = item.PrescriptionId;
            existingPrescription.PrescriptionDetailId = item.PrescriptionDetailId;
            existingPrescription.MedicineCode = item.MedicineCode;
            existingPrescription.MedicineName = item.MedicineName;
            existingPrescription.Quantity = (int)item.Quantity;
            existingPrescription.Price = (decimal)item.UnitPrice;
            existingPrescription.Amount = (decimal)item.Amount;
            existingPrescription.TotalFee = (decimal)item.TotalFee;
            existingPrescription.InsuranceFee = (decimal)item.InsuranceFee;
            if (prescriptionStatus.HasValue)
            {
                existingPrescription.Status = prescriptionStatus.Value;
            }
            existingPrescription.Type = prescriptionType;
            existingPrescription.PatientId = patientInfo.Id;
        }
        #endregion

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="clinic">The clinic.</param>
        /// <param name="services">The services.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="departmentTypes">The department types.</param>
        /// <returns>
        /// Clinic.
        /// </returns>
        private Clinic GetDepartment(Clinic clinic, List<ListValueExtend> services, List<ListValue> departmentTypes)
        {
            var service = services.FirstOrDefault(l => l.Code == clinic.ServiceId);
            clinic.ServiceExtendId = service?.Id;

            if (!string.IsNullOrEmpty(clinic.ExaminationCode))
            {
                var examination = services.FirstOrDefault(l => l.Code == clinic.ExaminationCode);
                clinic.ExaminationId = examination?.Id;
                clinic.ExaminationExtendId = examination?.Id;
            }

            var departmentType = services.FirstOrDefault(l => l.Code == clinic.DepartmentCode);
            if (departmentType != null)
            {
                var departmentTypeValue = departmentTypes.FirstOrDefault(d => d.Id == departmentType.ListValueId);
                if (departmentTypeValue != null && departmentTypeValue.Code == "KB")
                {
                    clinic.ClinicType = ClinicType.Examination;
                }
                else
                {
                    clinic.ClinicType = ClinicType.Clinic;
                }
            }
            else
            {
                clinic.ClinicType = ClinicType.Clinic;
            }

            if (clinic.DepartmentCode == Departments.KXN && !string.IsNullOrEmpty(clinic.ExaminationCode))
            {
                var departmentCode = clinic.DepartmentCode + "_" + clinic.ExaminationCode;
                var department = services.FirstOrDefault(l => l.Code == departmentCode);
                if (department != null)
                {
                    var departmentName = services.FirstOrDefault(l => l.Code == department.Description);
                    clinic.DepartmentExtendId = departmentName.Id;
                    clinic.DepartmentCode = departmentName.Code;
                }
                else
                {
                    department = services.FirstOrDefault(l => l.Code == Departments.CLSXN12);
                    clinic.DepartmentExtendId = department.Id;
                }
            }
            else
            {
                var department = services.FirstOrDefault(l => l.Code == clinic.DepartmentCode);
                clinic.DepartmentExtendId = department.Id;
            }

            return clinic;
        }

        /// <summary>
        /// Saves the trasaction.
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
            decimal totalFee,
            decimal insuranceFee,
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
                TotalFee = totalFee,
                InsuranceFee = insuranceFee,
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

        /// <summary>
        /// Saves the trasaction.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="transactionStatus">The transaction status.</param>
        /// <param name="message">The message.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="clinics">The clinics.</param>
        /// <param name="prescriptions">The prescription with clinics.</param>
        /// <param name="insurancePrescriptions">The prescriptions.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="store">The store.</param>
        /// <returns></returns>
        private TransactionDraft CreateDraftTrasaction(
            Patient patientInfo,
            TransactionType transactionType,
            TransactionStatus transactionStatus,
            string message,
            Reception reception,
            IEnumerable<TransactionClinic> clinics = null,
            IEnumerable<TransactionPrescription> prescriptions = null,
            SysUser employee = null,
            ListValueExtend store = null)
        {
            var clinicAmount = clinics != null ? clinics.Sum(s => s.Amount) : decimal.Zero;
            var clinicTotalFee = clinics != null ? clinics.Sum(s => s.TotalFee) : decimal.Zero;
            var clinicInsuranceFee = clinics != null ? clinics.Sum(s => s.InsuranceFee) : decimal.Zero;
            var prescriptionAmount = prescriptions != null ? prescriptions.Sum(s => s.Amount) : decimal.Zero;
            var prescriptionTotalFee = prescriptions != null ? prescriptions.Sum(s => s.TotalFee) : decimal.Zero;
            var prescriptionInsuranceFee = prescriptions != null ? prescriptions.Sum(s => s.InsuranceFee) : decimal.Zero;
            var total = clinicAmount + prescriptionAmount;
            var totalFee = clinicTotalFee + prescriptionTotalFee;
            var insuranceFee = clinicTotalFee + prescriptionTotalFee;

            var transactionId = Guid.NewGuid();
            var transaction = new TransactionDraft
            {
                Id = transactionId,
                Amount = total,
                TotalFee = totalFee,
                InsuranceFee = insuranceFee,
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

            if (clinics != null && clinics.Count() > 0)
            {
                foreach (var clinic in clinics)
                {
                    var transactionClinic = (TransactionClinic)clinic.Clone();
                    transactionClinic.Id = Guid.NewGuid();
                    transactionClinic.Type = transactionType;
                    var trasactionDraftClinic = _mapper.Map<TransactionDraftClinic>(transactionClinic);
                    transaction.TransactionDraftClinics.Add(trasactionDraftClinic);
                }
            }

            if (prescriptions != null && prescriptions.Count() > 0)
            {
                foreach (var prescription in prescriptions)
                {
                    var transactionPrescription = _mapper.Map<TransactionDraftPrescription>(prescription);
                    transactionPrescription.Id = Guid.NewGuid();
                    transactionPrescription.Type = transactionType;
                    transaction.TransactionDraftPrescriptions.Add(transactionPrescription);
                }
            }

            _unitOfWork.GetRepository<TransactionDraft>().Add(transaction);
            return transaction;
        }

        /// <summary>
        /// Creates the payment.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <param name="clinics">The clinics.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="medicines">The medicines.</param>
        /// <returns></returns>
        private async Task<TransactionInfo> CreatePayment(Patient patientInfo,
            TransactionType transactionType,
            List<GetRawFinallyClinicListResponseData> clinics,
            Reception reception,
            List<GetRawFinallyListPrescriptionResponseData> medicines,
            List<GetRawFinallyPrescriptionListResponseData> insuranceMedicines)
        {
            var clinicResults = await CreateOrUpdateFinallyClinic(
                                    clinics,
                                    patientInfo,
                                    reception,
                                    ClinicStatus.Paid);

            var prescriptionResults = CreateOrUpdateFinallyPrescription(
                medicines,
                patientInfo,
                PrescriptionStatus.Paid,
                PrescriptionType.UseWithService);

            var insurancePrescriptionResults = CreateOrUpdateFinallyInsurancePrescription(
                insuranceMedicines,
                patientInfo,
                PrescriptionStatus.Paid,
                PrescriptionType.UseByDoctor);

            // Get total amount
            decimal amountClinicItemTotal = clinics != null
                && clinics.Count > 0
                ? (decimal)clinics.Where(c => c.IsFinished == StatusServiceConstants.Finished).Sum(item => item.Amount) : 0;

            decimal amountClinicItemTotalFee = clinics != null
                 && clinics.Count > 0
                 ? (decimal)clinics.Sum(item => item.TotalFee) : 0;

            decimal amountClinicItemInsuranceFee = clinics != null
                 && clinics.Count > 0
                 ? (decimal)clinics.Sum(item => item.InsuranceFee) : 0;

            decimal amountPrescriptionItemTotal = medicines != null
                && medicines.Count > 0
                ? (decimal)medicines.Sum(item => item.Amount) : 0;

            decimal amountPrescriptionItemTotalFee = medicines != null
                && medicines.Count > 0
                ? (decimal)medicines.Sum(item => item.TotalFee) : 0;

            decimal amountPrescriptionItemInsuranceFee = medicines != null
                && medicines.Count > 0
                ? (decimal)medicines.Sum(item => item.InsuranceFee) : 0;

            decimal amountInsurancePrescriptionItemTotal = insuranceMedicines != null
                && insuranceMedicines.Count > 0
                ? (decimal)insuranceMedicines.Sum(item => item.Amount) : 0;

            decimal amountInsurancePrescriptionItemTotalFee = insuranceMedicines != null
                && insuranceMedicines.Count > 0
                ? (decimal)insuranceMedicines.Sum(item => item.TotalFee) : 0;

            decimal amountInsurancePrescriptionItemInsuranceFee = insuranceMedicines != null
                && insuranceMedicines.Count > 0
                ? (decimal)insuranceMedicines.Sum(item => item.InsuranceFee) : 0;

            decimal amountItemTotal = amountPrescriptionItemTotal + amountClinicItemTotal + amountInsurancePrescriptionItemTotal;
            decimal amountItemTotalFee = amountPrescriptionItemTotalFee + amountClinicItemTotalFee + amountInsurancePrescriptionItemTotalFee;
            decimal amountItemInsuranceFee = amountPrescriptionItemInsuranceFee + amountClinicItemInsuranceFee + amountInsurancePrescriptionItemInsuranceFee;

            var transaction = CreateTrasaction((decimal)amountItemTotal,
                                        amountItemTotalFee,
                                        amountItemInsuranceFee,
                                        patientInfo,
                                        transactionType,
                                        TransactionStatus.New,
                                        Messages.New,
                                        reception,
                                        clinicResults,
                                        prescriptionResults,
                                        insurancePrescriptionResults);
            _unitOfWork.GetRepository<TransactionInfo>().Add(transaction);
            return transaction;
        }

        /// <summary>
        /// Creates the or update finally clinic.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        private async Task<ICollection<Clinic>> CreateOrUpdateFinallyClinic(List<GetRawFinallyClinicListResponseData> data,
            Patient patientInfo,
            Reception reception,
            ClinicStatus status)
        {
            ConcurrentBag<Clinic> clinicBag = new ConcurrentBag<Clinic>();
            if (data != null && data.Count > 0)
            {
                var departmentIds = data.Select(s => s.DepartmentCode);
                var examinationIds = data.Select(s => s.ExaminationCode);
                var serviceIds = data.Select(s => s.ServiceId);
                var kxnDepartments = data.Where(d => d.DepartmentCode == Departments.KXN);
                var kxnDepartmentIds = new List<string>();
                if (kxnDepartments.Count() > 0)
                {
                    foreach (var item in kxnDepartments)
                    {
                        kxnDepartmentIds.Add(item.DepartmentCode + "_" + item.ExaminationCode);
                    }

                    kxnDepartmentIds = kxnDepartmentIds.Distinct().ToList();
                    var kxnDepartment = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking().Where(v => kxnDepartmentIds.Any(id => id == v.Code)).ToListAsync();
                    var kxnDepartmentDescription = kxnDepartment.Select(d => d.Description).Distinct();
                    var kxnDepartmentDescriptionIds = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking().Where(v => kxnDepartmentDescription.Any(id => id == v.Description)).ToListAsync();
                    kxnDepartmentIds.AddRange(kxnDepartmentDescriptionIds.Select(d => d.Code));
                    kxnDepartmentIds.AddRange(kxnDepartmentDescription);
                    kxnDepartmentIds.Add(Departments.CLSXN12);
                }

                var serviceCodes = new List<string>(departmentIds.Count() + examinationIds.Count() + serviceIds.Count() + kxnDepartmentIds.Count());
                serviceCodes.AddRange(departmentIds);
                serviceCodes.AddRange(examinationIds);
                serviceCodes.AddRange(serviceIds);
                if (kxnDepartmentIds.Count > 0)
                {
                    serviceCodes.AddRange(kxnDepartmentIds);
                }
                serviceCodes = serviceCodes.Distinct().ToList();
                var services = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().AsNoTracking().Where(v => serviceCodes.Any(id => id == v.Code)).ToListAsync();
                var departmentTypeIds = services.Select(s => s.ListValueId);
                var departmentTypes = await _unitOfWork.GetRepository<ListValue>().GetAll().AsNoTracking().Where(v => departmentTypeIds.Any(id => id == v.Id)).ToListAsync();

                Parallel.ForEach(
                            data,
                            new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                            item =>
                            {
                                Clinic clinicModel = NewFinallyClinicModelBuilder(patientInfo, reception, status, item, services, departmentTypes);
                                clinicBag.Add(clinicModel);
                            });
            }

            return clinicBag.ToList();
        }

        /// <summary>
        /// Creates new clinicmodelbuilder.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="reception">The reception.</param>
        /// <param name="status">The status.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private Clinic NewFinallyClinicModelBuilder(Patient patientInfo,
            Reception reception,
            ClinicStatus? status,
            GetRawClinicListResponseData item,
            List<ListValueExtend> services,
            List<ListValue> departmentTypes)
        {
            var clinicPostModel = new ClinicPostModel
            {
                PatientCode = patientInfo.Code,
                IdSpecified = item.IdSpecified,
                //RegisteredDate = item.RegisteredDate,
                //RegisteredCode = item.RegisteredCode,
                PatientType = reception.PatientType,
                ServiceId = item.ServiceId,
                Money = (decimal)item.Amount,
                TotalFee = (decimal)item.TotalFee,
                InsuranceFee = (decimal)item.InsuranceFee,
                DepartmentCode = item.DepartmentCode,
                Note = item.Note,
                ExaminationCode = item.ExaminationCode,
                ClinicType = (ClinicType)item.ClinicType,
                IsFinished = item.IsFinished,
                ServiceType = item.ServiceType,
                //ManagementId = item.ManagementId,
                //ObjectType = item.ObjectType,
                Status = status.HasValue ? status.Value : ClinicStatus.New,
            };
            var clinic = _mapper.Map<Clinic>(clinicPostModel);
            clinic.PatientId = patientInfo.Id;
            clinic.ReceptionId = reception.Id;

            clinic = GetDepartment(clinic, services, departmentTypes);
            return clinic;
        }

        /// <summary>
        /// Creates the or update finally prescription.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="prescriptionStatus">The prescription status.</param>
        /// <param name="prescriptionType">Type of the prescription.</param>
        /// <returns></returns>
        private ICollection<Prescription> CreateOrUpdateFinallyPrescription(
            List<GetRawFinallyListPrescriptionResponseData> data,
            Patient patientInfo,
            PrescriptionStatus? prescriptionStatus,
            PrescriptionType prescriptionType)
        {
            ConcurrentBag<Prescription> prescriptionBag = new ConcurrentBag<Prescription>();
            if (data != null && data.Count > 0)
            {
                Parallel.ForEach(
                    data,
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    item =>
                    {
                        var prescriptionPostModel = new PrescriptionPostModel
                        {
                            PatientCode = item.PatientCode,
                            RegisteredDate = DateTime.Now,
                            RegisteredCode = item.RegisteredCode,
                            PrescriptionDataId = item.PrescriptionId,
                            PrescriptionDetailId = item.PrescriptionDetailId,
                            MedicineCode = item.MedicineCode,
                            MedicineName = item.MedicineName,
                            Quantity = (int)item.Quantity,
                            Price = (decimal)item.UnitPrice,
                            Amount = (decimal)item.Amount,
                            TotalFee = (decimal)item.TotalFee,
                            InsuranceFee = (decimal)item.InsuranceFee,
                            Status = prescriptionStatus.HasValue ? prescriptionStatus.Value : PrescriptionStatus.New,
                            Type = prescriptionType
                        };
                        var prescriptionModel = _mapper.Map<Prescription>(prescriptionPostModel);
                        prescriptionModel.PatientId = patientInfo.Id;
                        prescriptionBag.Add(prescriptionModel);
                    });
            }
            return prescriptionBag.ToList();
        }

        /// <summary>
        /// Creates the or update finally insurance prescription.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="prescriptionStatus">The prescription status.</param>
        /// <param name="prescriptionType">Type of the prescription.</param>
        /// <returns></returns>
        private ICollection<Prescription> CreateOrUpdateFinallyInsurancePrescription(
            List<GetRawFinallyPrescriptionListResponseData> data,
            Patient patientInfo,
            PrescriptionStatus? prescriptionStatus,
            PrescriptionType prescriptionType)
        {
            var list = new List<Prescription>();
            ConcurrentBag<Prescription> prescriptionBag = new ConcurrentBag<Prescription>();
            if (data != null && data.Count > 0)
            {
                Parallel.ForEach(
                    data,
                    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                    item =>
                    {
                        var prescriptionPostModel = new PrescriptionPostModel
                        {
                            PatientCode = item.PatientCode,
                            RegisteredDate = DateTime.Now,
                            RegisteredCode = item.RegisteredCode,
                            PrescriptionDataId = item.PrescriptionId,
                            PrescriptionDetailId = item.PrescriptionDetailId,
                            MedicineCode = item.MedicineCode,
                            MedicineName = item.MedicineName,
                            Quantity = (int)item.Quantity,
                            Price = (decimal)item.UnitPrice,
                            Amount = (decimal)item.Amount,
                            TotalFee = (decimal)item.TotalFee,
                            InsuranceFee = (decimal)item.InsuranceFee,
                            Status = prescriptionStatus.HasValue ? prescriptionStatus.Value : PrescriptionStatus.New,
                            Type = prescriptionType
                        };
                        var prescriptionModel = _mapper.Map<Prescription>(prescriptionPostModel);
                        prescriptionModel.PatientId = patientInfo.Id;
                        prescriptionBag.Add(prescriptionModel);
                    });
            }
            return prescriptionBag.ToList();
        }
        #endregion


        #region -- Service Admin --
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
        public async Task<TableResultJsonResponse<TransactionReportViewModel>> GetTransactionReport(TransactionReportRequest request)
        {
            var result = new TableResultJsonResponse<TransactionReportViewModel>();

            var predicate = PredicateBuilder.Create<TransactionInfo>(t => t.CreatedDate >= request.StartDate && t.CreatedDate <= request.EndDate);

            // Filter with conditions
            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                predicate = predicate.And(t => t.PatientCode != null && t.PatientCode.ToLower().Contains(request.PatientCode.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.PatientName))
            {
                predicate = predicate.And(t => t.Patient.FirstName != null && t.Patient.FirstName.ToLower().Contains(request.PatientName.ToLower()));
            }

            var filteredTransactions = _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(predicate);
            var transactions = filteredTransactions
                .OrderBy(t => t.CreatedDate)
                .GroupBy(t => new { t.PatientCode, t.RegisteredCode, t.Patient.TekmediId, t.Patient.TekmediCardNumber, t.Patient.FirstName, t.Patient.LastName, t.Patient.Gender, t.Patient.Birthday })
                .Select(g => new TransactionReportViewModel
                {
                    PatientCode = g.Key.PatientCode,
                    RegisteredDate = g.Min(t => t.RegisteredDate),
                    RegisteredNumber = g.Key.RegisteredCode,
                    Status = filteredTransactions.Where(t => t.PatientCode == g.Key.PatientCode && t.RegisteredCode == g.Key.RegisteredCode)
                        .Any(t => t.Type == TransactionType.Paid) ? TransactionReportStatus.Paid : TransactionReportStatus.Doing,
                    TekmediUID = g.Key.TekmediId,
                    TekmediCardNumber = g.Key.TekmediCardNumber,
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    Gender = g.Key.Gender,
                    Birthday = g.Key.Birthday,
                    CreatedDate = g.Max(t => t.CreatedDate)
                });

            // Filter status
            if (request.Status != 0)
            {
                transactions = transactions.Where(x => x.Status == (TransactionReportStatus)request.Status);
            }

            var totalRecord = transactions.Count();
            var data = transactions.Skip(request.Start).Take(request.Length).ToList();

            foreach (var item in data)
            {
                var sumTransactions = filteredTransactions.Where(t => t.PatientCode == item.PatientCode &&
                    t.RegisteredCode == item.RegisteredNumber).ToList();

                item.TotalMoneyRequired = sumTransactions.Sum(t => t.TransactionClinics
                                       .Where(c => c.Status == TransactionStatus.Success && c.Type == TransactionType.Hold).Sum(c => c.Amount));
                item.TotalMoneyRequired += sumTransactions.Sum(t => t.TransactionPrescriptions
                                       .Where(p => p.Status == TransactionStatus.Success && p.Type == TransactionType.Hold).Sum(p => p.Amount));

                item.TotalMoneyHold = sumTransactions.Sum(t => t.TransactionClinics
                    .Where(c => c.Status == TransactionStatus.Success && c.Type == TransactionType.Hold).Sum(c => c.Amount));
                item.TotalMoneyHold += sumTransactions.Sum(t => t.TransactionPrescriptions
                    .Where(p => p.Status == TransactionStatus.Success && p.Type == TransactionType.Hold).Sum(p => p.Amount));
                item.TotalMoneyHold -= sumTransactions.Sum(t => t.TransactionClinics
                    .Where(c => c.Status == TransactionStatus.Success && c.Type == TransactionType.Cancelled).Sum(c => c.Amount));
                item.TotalMoneyHold -= sumTransactions.Sum(t => t.TransactionPrescriptions
                    .Where(p => p.Status == TransactionStatus.Success && p.Type == TransactionType.Cancelled).Sum(p => p.Amount));

                item.TotalPayment = sumTransactions.Sum(t => t.TransactionClinics
                    .Where(c => c.Status == TransactionStatus.Success && c.Type == TransactionType.Paid).Sum(c => c.Amount));
                item.TotalPayment += sumTransactions.Sum(t => t.TransactionPrescriptions
                    .Where(p => p.Status == TransactionStatus.Success && p.Type == TransactionType.Paid).Sum(p => p.Amount));
            }

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = data;

            return result;
        }

        /// <summary>
        /// Gets the list transaction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<List<TransactionInfoViewModel>> GetListTransaction(TransactionDetailRequest request)
        {
            var transactions = await _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .Where(t => t.RegisteredCode == request.RegisteredCode && t.PatientCode == request.PatientCode)
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

            var transactionClinics = _mapper.Map<List<TransactionDetailViewModel>>(transaction.TransactionClinics);
            var transactionPrescriptions = _mapper.Map<List<TransactionDetailViewModel>>(transaction.TransactionPrescriptions);
            detailTransactions.AddRange(transactionClinics);
            detailTransactions.AddRange(transactionPrescriptions);

            return new TransactionDetailInfoResponse
            {
                TransactionInfoDetail = detailTransactions
            };
        }
        #endregion
    }
}