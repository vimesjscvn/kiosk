using CS.Common.Common;
using CS.Common.Enums;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.External.Requests;
using CS.VM.PaymentModels.Requests;
using CS.VM.PostModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Infrastructure;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using TEK.Gateway.Domain.BusinessObjects;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    public class TekmediCardService : ITekmediCardService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private readonly HospitalSettings _hospitalSettings;
        private readonly IHospitalSystemService _hospitalSystemService;
        private readonly ITransactionService _transactionService;
        private readonly ITransactionNumberUserService _transactionNumberService;
        private readonly ILogger<TekmediCardService> _logger;
        private readonly ITekmediCardHistoryService _tekmediCardHistoryService;

        public TekmediCardService(IUnitOfWork unitOfWork,
            HospitalSettings hospitalSettings,
            IHospitalSystemService hospitalSystemService,
            ITransactionService transactionService,
            ITransactionNumberUserService transactionNumberUserService,
            ILogger<TekmediCardService> logger,
            ITekmediCardHistoryService tekmediCardHistoryService)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
            _hospitalSystemService = hospitalSystemService;
            _transactionService = transactionService;
            _transactionNumberService = transactionNumberUserService;
            _logger = logger;
            _tekmediCardHistoryService = tekmediCardHistoryService;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public TekmediCard Add(TekmediCard entity)
        {
            _unitOfWork.GetRepository<TekmediCard>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TekmediCard> AddAsync(TekmediCard entity)
        {
            _unitOfWork.GetRepository<TekmediCard>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<TekmediCard>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<TekmediCard>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TekmediCard entity)
        {
            _unitOfWork.GetRepository<TekmediCard>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<TekmediCard>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(TekmediCard entity)
        {
            _unitOfWork.GetRepository<TekmediCard>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<TekmediCard>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public TekmediCard Find(Expression<Func<TekmediCard, bool>> match)
        {
            return _unitOfWork.GetRepository<TekmediCard>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TekmediCard> FindAll(Expression<Func<TekmediCard, bool>> match)
        {
            return _unitOfWork.GetRepository<TekmediCard>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TekmediCard>> FindAllAsync(Expression<Func<TekmediCard, bool>> match)
        {
            return await _unitOfWork.GetRepository<TekmediCard>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TekmediCard> FindAsync(Expression<Func<TekmediCard, bool>> match)
        {
            return await _unitOfWork.GetRepository<TekmediCard>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public TekmediCard Get(Guid id)
        {
            return _unitOfWork.GetRepository<TekmediCard>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TekmediCard> GetAll()
        {
            return _unitOfWork.GetRepository<TekmediCard>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TekmediCard>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TekmediCard>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TekmediCard> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<TekmediCard>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TekmediCard.</returns>
        public TekmediCard Update(TekmediCard entity, Guid id)
        {
            if (entity == null)
                return null;

            TekmediCard existing = _unitOfWork.GetRepository<TekmediCard>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TekmediCard>().Update(entity);
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
        /// TekmediCard.
        /// </returns>
        public async Task<TekmediCard> UpdateAsync(TekmediCard entity, Guid id)
        {
            if (entity == null)
                return null;

            TekmediCard existing = await _unitOfWork.GetRepository<TekmediCard>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TekmediCard>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion
        #region Public Funcs
        public async Task<TekmediCardHistory> SavePayment(TopUpRequest request)
        {
            if (string.IsNullOrEmpty(request.RegisterCode))
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            request.PatientCode = request.PatientCode.Trim();
            request.TekmediCardNumber = request.TekmediCardNumber.Trim();

            if (request.Price <= 0) throw new Exception(ErrorMessages.NagativePrice);

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (!(await ValidateCardNumber(request.TekmediCardNumber)))
                throw new Exception(ErrorMessages.InvalidCardNumber);

            if (patient.TekmediCardNumber != request.TekmediCardNumber)
                throw new Exception(ErrorMessages.NotMatchCardNumber);

            var tekmediCard = await _unitOfWork
                .GetRepository<TekmediCard>()
                .FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber && x.IsActive == true);
            if (tekmediCard == null)
                throw new Exception(ErrorMessages.NotFoundCardNumber);

            var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == request.RegisterCode);
            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            if (reception.IsFinished)
            {
                throw new Exception(ErrorMessages.FinishedReceptionNumber);
            }

            var employee = await _unitOfWork
                .GetRepository<SysUser>()
                .FindAsync(x => x.Id == request.EmployeeId);
            if (employee == null)
            {
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            var activeTransactionConfig = _transactionNumberService.GetAdvancePaymentNumberConfig(employee.Id);
            if (activeTransactionConfig == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionNumberConfig);
            }

            int recvNo = 0;
            bool isFillCanceledNumber = false;
            bool isSameNumber = false;

            // Nếu không truyền RecvNo, lấy mặc định ở cấu hình
            if (request.RecvNo <= 0)
            {
                recvNo = activeTransactionConfig.RecvNo;
            }

            // Nếu có truyền RecvNo, check xem có bị trùng không
            if (request.RecvNo > 0)
            {
                recvNo = request.RecvNo;

                // Lấy TekmediCardHistory với số biên lai mà user nhập vào
                var histories = _tekmediCardHistoryService.GetByTransactionNumberConfig(
                    activeTransactionConfig.SerialNo,
                    activeTransactionConfig.BookNo,
                    recvNo,
                    employee.Id);

                if (histories.Count > 0)
                {
                    var historyIds = histories.Select(x => x.Id).ToList();
                    var cancelHistories = _tekmediCardHistoryService.GetListCancelByHistoryIds(historyIds);
                    // Nếu history nhiều hơn cancel, số này bị trùng
                    if (histories.Count > cancelHistories.Count)
                    {
                        throw new Exception("Số biên lai này đã được sử dụng.");
                    }

                    // Nếu history bằng với cancel, là bù số bị hủy
                    if (histories.Count == cancelHistories.Count)
                    {
                        isFillCanceledNumber = true;
                    }
                }
            }

            if (recvNo == activeTransactionConfig.RecvNo)
            {
                isSameNumber = true;
            }

            var resultFromHis = await CallAdvancePaymentToHis(
                request.PatientCode,
                request.RegisterCode,
                request.Price,
                employee.Code,
                employee.Id,
                reception.PatientType,
                activeTransactionConfig.SerialNo,
                activeTransactionConfig.BookNo,
                recvNo);

            if (resultFromHis.IsSuccess == false)
            {
                throw new Exception($"Không thể tạo tạm ứng bên HIS. {resultFromHis.Message}");
            }

            // Tăng số hiện tại của cấu hình lên nếu không phải là bù số, số nhập vào bằng với số cấu hình
            if (isFillCanceledNumber == false && isSameNumber)
            {
                bool isDuplicatedNumber = true;
                while (isDuplicatedNumber)
                {
                    activeTransactionConfig = _transactionNumberService.GetNextNumberConfig(activeTransactionConfig);

                    // Check số vừa tăng lên có bị trùng hay không
                    var histories = _tekmediCardHistoryService.GetByTransactionNumberConfig(
                        activeTransactionConfig.SerialNo,
                        activeTransactionConfig.BookNo,
                        activeTransactionConfig.RecvNo,
                        employee.Id);

                    if (histories.Count == 0)
                    {
                        isDuplicatedNumber = false;
                    }
                }

                _unitOfWork.GetRepository<TransactionNumberConfig>().Update(activeTransactionConfig);
                _unitOfWork.Commit();
            }

            var result = await SavePayment(request, tekmediCard, patient, resultFromHis);
            await UpdateAdvancePaymentAfterTopup(request.PatientCode, request.TekmediCardNumber, request.EmployeeId);
            return result;
        }

        public async Task<CreateAdvancePaymentResult> CallAdvancePaymentToHis(
            string patientCode,
            string registerCode,
            decimal amount,
            string employeeCode,
            Guid employeeId,
            string patientType,
            string serialNo,
            string bookNo,
            int recvNo)
        {
            _logger.LogInformation($"CallAdvancePaymentToHis Start {DateTime.Now.ToString()}, PatientCode={patientCode}, RegisterCode={registerCode}");
            var request = new CreateAdvancePaymentRequest();
            request.ManageCode = registerCode;
            request.PatientCode = patientCode;
            request.PatientType = "NGOAI_TRU";
            request.EmployeeCode = employeeCode;
            request.Amount = amount;
            request.RegisterCode = registerCode;
            request.Date = DateTime.Now;
            request.BookNo = bookNo;
            request.RecvNo = recvNo;
            request.SerialNo = serialNo;

            _logger.LogInformation($"CallAdvancePaymentToHis Process {DateTime.Now.ToString()}, PatientCode={patientCode}, RegisterCode={registerCode}, Amount={amount}");
            var result = new CreateAdvancePaymentResult();

            try
            {
                var response = await _hospitalSystemService.CreateAdvancePayment(request);
                if (response.StatusCode == "00" && response.Status == "success" && response.Message == "Thành công" && response.InvoiceNo > 0)
                {
                    result.IsSuccess = true;
                    result.InvoiceNo = response.InvoiceNo;
                    result.RecvNo = response.RecvNo;
                    result.BookNo = response.BookNo;
                    result.SerialNo = response.SerialNo;

                    _logger.LogInformation($"CreateAdvancePaymentToHis Process {DateTime.Now.ToString()}, PatientCode={patientCode}," +
                        $" RegisterCode={registerCode}, Amount={amount}, IsSuccess={result.IsSuccess}, " +
                        $" InvoiceId={result.InvoiceNo}, RecvNo={result.RecvNo}, BookNo={result.BookNo}, SerialNo={result.SerialNo}");

                    return result;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = response.Message;
                    return result;
                }
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                return result;
            }
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task<bool> UpdateAdvancePaymentAfterTopup(string patientCode, string cardNumber, Guid employeeId)
        {
            //_logger.LogInformation($"UpdateAdvancePaymentAfterTopup Start {DateTime.Now.ToString()}, PatientCode={patientCode}, CardNumber={cardNumber}");

            //var listTransaction = await _transactionService.PostAdvancePayment(patientCode);

            //_logger.LogInformation($"UpdateAdvancePaymentAfterTopup {DateTime.Now.ToString()}, " +
            //    $"PatientCode={patientCode}, CardNumber={cardNumber}, ListTransaction Count={listTransaction.Count}");

            //var listTransactionStr = JsonConvert.SerializeObject(listTransaction);
            //_logger.LogInformation($"UpdateAdvancePaymentAfterTopup {DateTime.Now.ToString()}, " +
            //   $"PatientCode={patientCode}, CardNumber={cardNumber}, ListTransaction={listTransactionStr}");

            //if (listTransaction.Count > 0)
            //{
            //    foreach (var transaction in listTransaction)
            //    {
            //        var createPaymentRequest = new CreatePaymentRequest();
            //        createPaymentRequest.TransactionId = transaction.Id;
            //        createPaymentRequest.CardNumber = cardNumber;
            //        createPaymentRequest.PaymentProvider = ((int)transaction.PayProvider).ToString();
            //        createPaymentRequest.StoreCode = transaction.Store;
            //        createPaymentRequest.EmployeeId = employeeId;
            //        createPaymentRequest.DeviceId = Guid.Parse("2044fbf6-545e-4303-9009-67afe3f7b1aa");
            //        var success = await _transactionService.PatchAdvancePayment(createPaymentRequest);

            //        _logger.LogInformation($"UpdateAdvancePaymentAfterTopup {DateTime.Now.ToString()}, " +
            //           $"PatientCode={patientCode}, CardNumber={cardNumber}, Transaction={transaction.Id}, Success={success}");
            //    }
            //}

            return true;
        }

        /// <summary>
        /// Handles the lost card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        /// <exception cref="Exception">Can't found a patient with code " + request.PatientCode</exception>
        /// <exception cref="Exception">Can't found tekmediCard with card number " + request.CurrentTekmediCardNumber</exception>
        /// <exception cref="Exception">Thẻ " + request.NewTekmediCardNumber + " đã được đăng ký cho bệnh nhân khác</exception>
        public async Task<TekmediCardHistory> HandleLostCard(LostCardRequest request)
        {
            request.PatientCode = request.PatientCode.Trim();
            request.CurrentTekmediCardNumber = request.CurrentTekmediCardNumber.Trim();

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (patient.TekmediCardNumber != request.CurrentTekmediCardNumber)
                throw new Exception(ErrorMessages.NotMatchCardNumber);

            var currentTekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.CurrentTekmediCardNumber && x.IsActive == true);
            if (currentTekmediCard == null)
                throw new Exception(ErrorMessages.NotFoundCardNumber);

            if (currentTekmediCard != null && currentTekmediCard.Balance < 0)
                throw new Exception(ErrorMessages.InCorrectlyAccountBalance);

            if (string.IsNullOrEmpty(request.NewTekmediCardNumber))
                return await LostCardAndNotRenewPayment(request, currentTekmediCard, patient);

            request.NewTekmediCardNumber = request.NewTekmediCardNumber.Trim();

            if (!(await ValidateCardNumber(request.NewTekmediCardNumber)))
                throw new Exception(ErrorMessages.InvalidCardNumber);

            if (string.IsNullOrEmpty(request.RegisterCode) == false)
            {
                var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == request.RegisterCode);
                if (reception == null)
                {
                    throw new Exception(ErrorMessages.NotFoundReceptionNumber);
                }
            }

            var newTekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.NewTekmediCardNumber);
            if (newTekmediCard != null && newTekmediCard.IsActive)
                throw new Exception(ErrorMessages.RegisteredTekmediCard);

            return await LostCardAndRenewPayment(request, currentTekmediCard, newTekmediCard, patient);
        }


        /// <summary>
        /// Registers the card payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        /// <exception cref="Exception">Can't found a patient with code " + request.PatientCode</exception>
        /// <exception cref="Exception">Patient have been registered card number " + patient.TekmediCardNumber</exception>
        public async Task<int> RegisterCardPayment(RegisterCardRequest request)
        {
            request.PatientCode = request.PatientCode.Trim();
            request.TekmediCardNumber = request.TekmediCardNumber.Trim();

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (string.IsNullOrEmpty(request.RegisterCode) == false)
            {
                var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == request.RegisterCode);
                if (reception == null)
                {
                    throw new Exception(ErrorMessages.NotFoundReceptionNumber);
                }
            }

            if (!string.IsNullOrEmpty(patient.TekmediCardNumber))
                throw new Exception(ErrorMessages.PatientRegisteredTekmediCard);

            if (!(await ValidateCardNumber(request.TekmediCardNumber)))
                throw new Exception(ErrorMessages.InvalidCardNumber);

            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().GetAll().SingleOrDefaultAsync(s => s.TekmediCardNumber == request.TekmediCardNumber);
            if (cardInfo == null)
            {
                return await RegisterCardPaymentWithNewCard(request, patient);
            }
            else
            {
                if (cardInfo.IsActive)
                {
                    throw new Exception(ErrorMessages.RegisteredTekmediCard);
                }
                else
                {
                    return await RegisterCardPayment(request, patient, cardInfo);
                }
            }
        }

        /// <summary>
        /// Returns the card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        /// <exception cref="Exception">Can't found a patient with card number " + request.TekmediCardNumber</exception>
        /// <exception cref="Exception">Can't found tekmediCard with card number " + request.TekmediCardNumber</exception>
        public async Task<TekmediCardHistory> ReturnCard(ReturnCardRequest request)
        {
            request.TekmediCardNumber = request.TekmediCardNumber.Trim();

            if (!(await ValidateCardNumber(request.TekmediCardNumber)))
                throw new Exception(ErrorMessages.InvalidCardNumber);

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundCardNumberMappingWithPatient);

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber);
            if (tekmediCard == null)
                throw new Exception(ErrorMessages.NotFoundCardNumber);

            if (tekmediCard != null && tekmediCard.Balance < 0)
            {
                throw new Exception(ErrorMessages.InCorrectlyAccountBalance);
            }

            var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == request.EmployeeId);
            if (employee == null)
            {
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            if (string.IsNullOrEmpty(request.RegisterCode))
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            var reception = _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefault(x => x.RegisteredCode == request.RegisterCode);
            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            var transaction = _unitOfWork.GetRepository<TransactionInfo>().GetAll()
                .FirstOrDefault(x => x.RegisteredCode == request.RegisterCode
                    && x.State == StateConstants.Finished
                    && x.Status == TransactionStatus.Success
                    && x.Type == TransactionType.Paid);
            if (transaction == null)
            {
                throw new Exception("Giao dịch chưa tất toán.");
            }

            return await ReturnCard(request, tekmediCard, patient, employee, transaction, reception);
        }

        /// <summary>
        /// Getbies the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>Task&lt;TekmediCard&gt;.</returns>
        public async Task<TekmediCard> GetCardInfoByCardNumber(string cardNumber)
        {
            return await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == cardNumber);
        }

        /// <summary>
        /// Getbies the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>Task&lt;TekmediCard&gt;.</returns>
        /// <exception cref="Exception">Tekmedi card khong tim thay</exception>
        /// <exception cref="Exception">So du cua benh nhat la zero. Vui long nap tien truoc khi thanh toan</exception>
        public async Task<TekmediCard> GetAndValidateByCardNumber(string cardNumber)
        {
            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().GetAll().FirstOrDefaultAsync(c => c.TekmediCardNumber == cardNumber);
            if (cardInfo == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            if (cardInfo.Balance == 0)
            {
                throw new Exception(ErrorMessages.ZeroPrice);
            }

            return cardInfo;
        }

        /// <summary>
        /// Cancels the payment.
        /// </summary>
        /// <param name="historyId">The history identifier.</param>
        /// <returns>TekmediCardCancelHistory.</returns>
        /// <exception cref="Exception">Không tìm thấy lịch sử</exception>
        /// <exception cref="Exception">Giao dịch đã được hủy</exception>
        /// <exception cref="Exception">Không tìm thấy bệnh nhân với ID: " + history.PatientId</exception>
        /// <exception cref="Exception">Không tìm thấy thẻ tekmedi với ID: " + history.TekmediCardId</exception>
        public async Task<TekmediCardCancelHistory> CancelPayment(Guid historyId)
        {
            var history = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAsyncById(historyId);
            if (history == null)
            {
                throw new Exception(ErrorMessages.NotFoundHistory);
            }

            var cancelHistory = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().FindAsync(i => i.TekmediCardHistoryId == history.Id);
            if (cancelHistory != null)
            {
                throw new Exception(ErrorMessages.CancelledHistory);
            }

            var patient = await _unitOfWork.GetRepository<Patient>().GetAsyncById(history.PatientId);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>()
                .GetAll()
                .FirstOrDefaultAsync(c => c.TekmediCardNumber == patient.TekmediCardNumber && c.IsActive == true);
            if (tekmediCard == null)
            {
                throw new Exception(ErrorMessages.PatientHasBeenReturnedCard);
            }

            //if (patient.TekmediCard == null || patient.TekmediCardNumber != history.TekmediCardNumber)
            //{
            //    throw new Exception(ErrorMessages.PatientHasBeenReturnedCard);
            //}

            if (string.IsNullOrEmpty(history.RegisterCode) == false)
            {
                var reception = await _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefaultAsync(x => x.RegisteredCode == history.RegisterCode);
                if (reception == null)
                {
                    throw new Exception(ErrorMessages.NotFoundReceptionNumber);
                }

                if (reception.IsFinished)
                {
                    throw new Exception(ErrorMessages.FinishedReceptionNumber);
                }
            }

            var employee = await _unitOfWork
                .GetRepository<SysUser>()
                .FindAsync(x => x.Id == history.EmployeeId);
            if (employee == null)
            {
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);
            }

            return await CancelPayment(history, patient, tekmediCard, employee);
        }

        /// <summary>
        /// Withdraws the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<TekmediCardHistory> Withdraw(WithdrawRequest request)
        {
            request.PatientCode = request.PatientCode.Trim();
            request.TekmediCardNumber = request.TekmediCardNumber.Trim();

            if (request.Price <= 0) throw new Exception(ErrorMessages.NagativePrice);

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null) throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (!(await ValidateCardNumber(request.TekmediCardNumber)))
                throw new Exception(ErrorMessages.InvalidCardNumber);

            if (patient.TekmediCardNumber != request.TekmediCardNumber)
                throw new Exception(ErrorMessages.NotMatchCardNumber);

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber && x.IsActive == true);
            if (tekmediCard == null) throw new Exception(ErrorMessages.NotFoundCardNumber);

            if (request.Price > tekmediCard.Balance) throw new Exception(ErrorMessages.ConditionWithdraw);

            if (tekmediCard.Balance - request.Price < _hospitalSettings.Hospital.MinBalance)
                throw new Exception(string.Format(ErrorMessages.MinBalance, _hospitalSettings.Hospital.MinBalance));

            return await Withdraw(request, tekmediCard, patient);
        }

        /// <summary>
        /// Validates the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        public async Task<bool> ValidateCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) return false;
            return StringUtils.ValidateCardNumber(cardNumber);
        }

        /// <summary>
        /// Gets the by card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TekmediCard> GetByCardNumber(string cardNumber)
        {
            var cardInfo = await _unitOfWork.GetRepository<TekmediCard>().GetAll().FirstOrDefaultAsync(c => c.TekmediCardNumber == cardNumber);
            if (cardInfo == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            return cardInfo;
        }

        public async Task<TekmediCardHistory> AddExtraFee(AddExtraFeeRequest request)
        {
            var response = new TekmediCardHistory();
            if (request.Price <= 0)
            {
                throw new Exception(ErrorMessages.NagativePrice);
            }

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == request.PatientCode);
            if (patient == null)
            {
                throw new Exception(ErrorMessages.NotFoundPatientCode);
            }

            if (patient.TekmediCardNumber != request.TekmediCardNumber)
            {
                throw new Exception(ErrorMessages.NotMatchCardNumber);
            }

            var reception = _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefault(x => x.RegisteredCode == request.RegisterCode);
            if (reception == null)
            {
                throw new Exception(ErrorMessages.NotFoundReceptionNumber);
            }

            if (reception.IsFinished)
            {
                throw new Exception(ErrorMessages.FinishedReceptionNumber);
            }

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber && x.IsActive == true);
            if (tekmediCard == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            return await AddExtraFee(
                request,
                patient,
                reception,
                tekmediCard);
        }

        #endregion
        #region Private Funcs
        /// <summary>
        /// Saves the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="tekmediCard">The tekmedi card.</param>
        /// <param name="patient">The patient.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<TekmediCardHistory> SavePayment(TopUpRequest request, TekmediCard tekmediCard, Patient patient, CreateAdvancePaymentResult resultFromHis)
        {
            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = request.Price,
                Time = DateTime.Now,
                Type = TypeEnum.Recharged,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                BeforeValue = tekmediCard.Balance,
                AfterValue = tekmediCard.Balance + request.Price,
                PaymentTypeId = request.PaymentTypeId,
                RegisterCode = request.RegisterCode,
                InvoiceNo = resultFromHis.InvoiceNo,
                RecvNo = resultFromHis.RecvNo,
                SerialNo = resultFromHis.SerialNo,
                BookNo = resultFromHis.BookNo
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);

            //patient.Balance += request.Price;
            tekmediCard.Balance = tekmediCard.Balance + request.Price;

            await _unitOfWork.CommitAsync();
            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == tekmediCardHistory.Id);
        }

        public async Task<TekmediCardHistory> Withdraw(WithdrawRequest request, TekmediCard tekmediCard, Patient patient)
        {

            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = request.Price,
                Time = DateTime.Now,
                Type = TypeEnum.Withdraw,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                BeforeValue = tekmediCard.Balance,
                AfterValue = tekmediCard.Balance - request.Price
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);

            //patient.Balance -= request.Price;
            tekmediCard.Balance = tekmediCard.Balance - request.Price;

            await _unitOfWork.CommitAsync();

            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == tekmediCardHistory.Id);
        }

        /// <summary>
        /// Registers the card payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="patient">The patient.</param> 
        /// <param name="tekmediCard">The tekmedi card.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<int> RegisterCardPayment(RegisterCardRequest request, Patient patient, TekmediCard tekmediCard)
        {
            //var topUpTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
            //&& h.Type == TypeEnum.Recharged
            //&& h.Status == StatusEnum.Success).Sum(s => s.Amount);

            //decimal paidTotal = 0;
            //var receptions = _unitOfWork.GetRepository<Reception>().GetAll().Where(h => h.PatientCode == patient.Code).ToList();
            //if (receptions != null && receptions.Count > 0)
            //{
            //    foreach (var reception in receptions)
            //    {
            //        if (reception.IsFinished)
            //        {
            //            paidTotal += _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
            //            && t.RegisteredCode == reception.RegisteredCode
            //            && t.Type == TransactionType.Paid
            //            && t.Status == TransactionStatus.Success).Sum(s => s.Amount);
            //        }
            //        else
            //        {
            //            paidTotal += _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
            //            && t.RegisteredCode == reception.RegisteredCode
            //            && t.Type == TransactionType.Hold
            //            && t.Status == TransactionStatus.Success).Sum(s => s.Amount);

            //            paidTotal -= _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
            //            && t.RegisteredCode == reception.RegisteredCode
            //            && t.Type == TransactionType.Refund
            //            && t.Status == TransactionStatus.Success).Sum(s => s.Amount);
            //        }
            //    }
            //}

            //var payOffMedicineTotal = _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
            //&& t.Type == TransactionType.ServiceMedicine
            //&& t.Status == TransactionStatus.Success).Sum(s => s.Amount);

            //var withdrawTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
            //&& h.Type == TypeEnum.Withdraw
            //&& h.Status == StatusEnum.Success).Sum(s => s.Amount);

            //var cancelTotal = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(h => h.PatientId == patient.Id
            //&& h.Status == StatusEnum.Success).Sum(s => s.Amount);

            //var returnTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
            //&& h.Type == TypeEnum.Return
            //&& h.Status == StatusEnum.Success).Sum(s => s.Amount);

            //var balance = topUpTotal - paidTotal - payOffMedicineTotal - withdrawTotal - cancelTotal - returnTotal;

            tekmediCard.IsActive = true;
            tekmediCard.Balance = 0;
            _unitOfWork.GetRepository<TekmediCard>().Update(tekmediCard);

            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = 0,
                Time = DateTime.Now,
                Type = TypeEnum.Register,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                RegisterCode = request.RegisterCode
            };

            patient.TekmediCardNumber = request.TekmediCardNumber;
            patient.TekmediCardId = tekmediCard.Id;
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);
            var result = await _unitOfWork.CommitAsync();
            return result;
        }

        /// <summary>
        /// Registers the card payment with new card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="patient">The patient.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<int> RegisterCardPaymentWithNewCard(RegisterCardRequest request, Patient patient)
        {
            // var balance = GetBalance(patient);

            var tekmediCard = new TekmediCard
            {
                TekmediCardNumber = request.TekmediCardNumber,
                StartDate = DateTime.Now,
                Balance = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedBy = Systems.CreatedBy,
                UpdatedBy = Systems.UpdatedBy,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            _unitOfWork.GetRepository<TekmediCard>().Add(tekmediCard);
            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = 0,
                Time = DateTime.Now,
                Type = TypeEnum.Register,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                RegisterCode = request.RegisterCode
            };

            patient.TekmediCardNumber = request.TekmediCardNumber;
            patient.TekmediCardId = tekmediCard.Id;

            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);
            var result = await _unitOfWork.CommitAsync();
            return result;
        }

        /// <summary>
        /// Losts the card and renew payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="curentTekmediCard">The curent tekmedi card.</param>
        /// <param name="newTekmediCard">The new tekmedi card.</param>
        /// <param name="patient">The patient.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<TekmediCardHistory> LostCardAndRenewPayment(LostCardRequest request, TekmediCard curentTekmediCard, TekmediCard newTekmediCard, Patient patient)
        {
            Guid cardFeeId = Guid.Empty;
            curentTekmediCard.IsActive = false;
            //if (curentTekmediCard.Balance < _hospitalSettings.Hospital.CardFee)
            //{
            //    throw new Exception(ErrorMessages.NotEnoughLostPayment);
            //}

            if (newTekmediCard != null)
            {
                newTekmediCard.Balance = curentTekmediCard.Balance;
                newTekmediCard.IsActive = true;
                patient.TekmediCardId = newTekmediCard.Id;

                var lostCard = new TekmediCardHistory
                {
                    TekmediCardNumber = curentTekmediCard.TekmediCardNumber,
                    PatientId = patient.Id,
                    Amount = curentTekmediCard.Balance,
                    Time = DateTime.Now,
                    Type = TypeEnum.Lost,
                    EmployeeId = request.EmployeeId,
                    NewTekmediCardNumber = newTekmediCard.TekmediCardNumber,
                    Status = StatusEnum.Success,
                    TekmediCardId = curentTekmediCard.Id,
                    BeforeValue = curentTekmediCard.Balance,
                    AfterValue = 0,
                    RegisterCode = request.RegisterCode
                };

                _unitOfWork.GetRepository<TekmediCardHistory>().Add(lostCard);

                //newTekmediCard.Balance = newTekmediCard.Balance - _hospitalSettings.Hospital.CardFee;
                var cardFee = new TekmediCardHistory
                {
                    TekmediCardNumber = newTekmediCard.TekmediCardNumber,
                    PatientId = patient.Id,
                    Amount = _hospitalSettings.Hospital.CardFee,
                    Time = DateTime.Now,
                    Type = TypeEnum.CardFee,
                    EmployeeId = request.EmployeeId,
                    Status = StatusEnum.Success,
                    TekmediCardId = newTekmediCard.Id,
                    BeforeValue = 0,
                    AfterValue = newTekmediCard.Balance,
                    RegisterCode = request.RegisterCode
                };
                _unitOfWork.GetRepository<TekmediCardHistory>().Add(cardFee);

                patient.TekmediCardNumber = newTekmediCard.TekmediCardNumber;
                cardFeeId = cardFee.Id;
            }
            else
            {
                var tekmediCardId = Guid.NewGuid();
                var tekmediCard = new TekmediCard
                {
                    Id = tekmediCardId,
                    TekmediCardNumber = request.NewTekmediCardNumber,
                    StartDate = DateTime.Now,
                    Balance = curentTekmediCard.Balance,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = Systems.CreatedBy,
                    UpdatedBy = Systems.UpdatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                _unitOfWork.GetRepository<TekmediCard>().Add(tekmediCard);

                //tekmediCard.Balance = tekmediCard.Balance - _hospitalSettings.Hospital.CardFee;
                patient.TekmediCardId = tekmediCard.Id;
                var lostCard = new TekmediCardHistory
                {
                    TekmediCardNumber = request.CurrentTekmediCardNumber,
                    PatientId = patient.Id,
                    Amount = curentTekmediCard.Balance,
                    Time = DateTime.Now,
                    Type = TypeEnum.Lost,
                    EmployeeId = request.EmployeeId,
                    NewTekmediCardNumber = request.NewTekmediCardNumber,
                    Status = StatusEnum.Success,
                    TekmediCardId = tekmediCardId,
                    BeforeValue = curentTekmediCard.Balance,
                    AfterValue = 0,
                    RegisterCode = request.RegisterCode
                };

                _unitOfWork.GetRepository<TekmediCardHistory>().Add(lostCard);

                var cardFee = new TekmediCardHistory
                {
                    TekmediCardNumber = request.NewTekmediCardNumber,
                    PatientId = patient.Id,
                    Amount = _hospitalSettings.Hospital.CardFee,
                    Time = DateTime.Now,
                    Type = TypeEnum.CardFee,
                    EmployeeId = request.EmployeeId,
                    Status = StatusEnum.Success,
                    TekmediCardId = tekmediCardId,
                    BeforeValue = 0,
                    AfterValue = tekmediCard.Balance,
                    RegisterCode = request.RegisterCode
                };
                _unitOfWork.GetRepository<TekmediCardHistory>().Add(cardFee);
                patient.TekmediCardNumber = request.NewTekmediCardNumber;
                cardFeeId = cardFee.Id;
            }

            curentTekmediCard.Balance = 0;
            await _unitOfWork.CommitAsync();
            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == cardFeeId);
        }

        /// <summary>
        /// Losts the card and not renew payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="curentTekmediCard">The curent tekmedi card.</param>
        /// <param name="patient">The patient.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<TekmediCardHistory> LostCardAndNotRenewPayment(LostCardRequest request, TekmediCard curentTekmediCard, Patient patient)
        {
            //curentTekmediCard.IsActive = false;

            var lostCard = new TekmediCardHistory
            {
                TekmediCardNumber = request.CurrentTekmediCardNumber,
                PatientId = patient.Id,
                Amount = curentTekmediCard.Balance,
                Time = DateTime.Now,
                Type = TypeEnum.Lost,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = curentTekmediCard.Id,
                BeforeValue = curentTekmediCard.Balance,
                AfterValue = 0
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(lostCard);

            curentTekmediCard.Balance = 0;
            //patient.Balance = 0;
            //patient.TekmediCardNumber = string.Empty;
            //patient.TekmediCardId = null;

            await _unitOfWork.CommitAsync();
            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == lostCard.Id);
        }

        /// <summary>
        /// Returns the card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="tekmediCard">The tekmedi card.</param>
        /// <param name="patient">The patient.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<TekmediCardHistory> ReturnCard(ReturnCardRequest request, TekmediCard tekmediCard, Patient patient, SysUser employee, TransactionInfo transaction, Reception reception)
        {
            //var balance = GetBalance(patient);
            //if (balance < 0)
            //{
            //    throw new Exception(ErrorMessages.InCorrectlyAccountBalance);
            //}
            var balance = tekmediCard.Balance;

            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = balance,
                Time = DateTime.Now,
                Type = TypeEnum.Return,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Waiting,
                TekmediCardId = tekmediCard.Id,
                BeforeValue = balance,
                AfterValue = 0,
                RegisterCode = request.RegisterCode
            };

            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);
            await _unitOfWork.CommitAsync();

            var externalRequest = new UpdateRawReturnCardRequest();
            var listInvoice = new List<int>();
            listInvoice.Add(transaction.InvoiceNo.Value);
            externalRequest.HospitalCode = _hospitalSettings.Hospital.HospitalCode;
            externalRequest.PatientCode = patient.Code;
            externalRequest.PatientType = reception.ObjectType;
            externalRequest.ManagementCode = request.RegisterCode;
            externalRequest.RegisteredCode = request.RegisterCode;
            externalRequest.EmployeeCode = employee.Code;
            externalRequest.TransactionCode = tekmediCardHistory.Id.ToString();
            externalRequest.TransactionDate = tekmediCardHistory.Time;
            externalRequest.ReturnCardAmount = balance;
            externalRequest.Invoices = listInvoice;

            var externalResponse = await _hospitalSystemService.UpdateReturnCard(externalRequest);
            if (externalResponse.StatusCode != "00" && externalResponse.Status != "success")
            {
                tekmediCardHistory.Status = StatusEnum.Failed;
                _unitOfWork.GetRepository<TekmediCardHistory>().Update(tekmediCardHistory);
                await _unitOfWork.CommitAsync();
                var errStr = $"Cập nhật trả thẻ qua HIS không thành công: {externalResponse.Message}.";
                throw new Exception(errStr);
            }

            var refundExternalRequest = new UpdateRawRefundRequest();
            refundExternalRequest.HospitalCode = _hospitalSettings.Hospital.HospitalCode;
            refundExternalRequest.ManagementCode = request.RegisterCode;
            refundExternalRequest.PatientType = reception.ObjectType;
            refundExternalRequest.PatientCode = patient.Code;
            refundExternalRequest.RegisteredCode = request.RegisterCode;
            refundExternalRequest.EmployeeCode = employee.Code;
            refundExternalRequest.Amount = balance;
            refundExternalRequest.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            refundExternalRequest.BookNo = transaction.BookNo;
            refundExternalRequest.SerialNo = transaction.SerialNo;
            refundExternalRequest.RecvNo = transaction.RecvNo.Value;
            var refundExternalResponse = await _hospitalSystemService.UpdateRefund(refundExternalRequest);
            if (refundExternalResponse.StatusCode != "00" && refundExternalResponse.Status != "success")
            {
                tekmediCardHistory.Status = StatusEnum.Failed;
                _unitOfWork.GetRepository<TekmediCardHistory>().Update(tekmediCardHistory);
                await _unitOfWork.CommitAsync();
                var errStr = $"Cập nhật hoàn ứng qua HIS không thành công: {refundExternalResponse.Message}.";
                throw new Exception(errStr);
            }

            tekmediCard.Balance = 0;
            tekmediCard.IsActive = false;
            tekmediCardHistory.Status = StatusEnum.Success;
            tekmediCardHistory.InvoiceNo = refundExternalResponse.InvoiceNo;
            _unitOfWork.GetRepository<TekmediCardHistory>().Update(tekmediCardHistory);

            //patient.Balance = 0;
            patient.TekmediCardNumber = string.Empty;
            patient.TekmediCardId = null;
            await _unitOfWork.CommitAsync();

            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == tekmediCardHistory.Id);
        }

        /// <summary>
        /// Cancels the payment.
        /// </summary>
        /// <param name="history">The history.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="tekmediCard">The tekmedi card.</param>
        /// <returns>Task&lt;TekmediCardCancelHistory&gt;.</returns>
        /// <exception cref="Exception"></exception>
        private async Task<TekmediCardCancelHistory> CancelPayment(TekmediCardHistory history, Patient patient, TekmediCard tekmediCard, SysUser employee)
        {
            var amount = history.Amount.GetValueOrDefault();
            if (tekmediCard.Balance < amount)
            {
                throw new Exception(ErrorMessages.ConditionCancelPayment);
            }
            var cancelHistory = new TekmediCardCancelHistory
            {
                TekmediCardNumber = tekmediCard.TekmediCardNumber,
                PatientId = history.PatientId,
                Amount = history.Amount,
                Time = DateTime.Now,
                Type = TypeEnum.Cancel,
                EmployeeId = history.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                TekmediCardHistoryId = history.Id,
                BeforeValue = tekmediCard.Balance,
                AfterValue = tekmediCard.Balance - amount,
                RegisterCode = history.RegisterCode
            };
            _unitOfWork.GetRepository<TekmediCardCancelHistory>().Add(cancelHistory);

            //patient.Balance -= amount;
            tekmediCard.Balance = tekmediCard.Balance - amount;
            await _unitOfWork.CommitAsync();

            Hangfire.BackgroundJob.Schedule(() => SendCancelAdvancePaymentToHis(patient.Code, history.RegisterCode, history.Id, employee.Code), TimeSpan.FromSeconds(2));
            return cancelHistory;
        }


        [AutomaticRetry(Attempts = 0)]
        public async Task<bool> SendCancelAdvancePaymentToHis(string patientCode, string registeredCode, Guid tekmediCardHistoryId, string employeeCode)
        {
            _logger.LogInformation($"SendCancelAdvancePaymentToHis Start {DateTime.Now.ToString()}, PatientCode={patientCode}, RegisterCode={registeredCode}, TekmediCardHistoryId={tekmediCardHistoryId}");

            if (string.IsNullOrEmpty(patientCode) || string.IsNullOrEmpty(registeredCode) || tekmediCardHistoryId == Guid.Empty)
            {
                return true;
            }

            string registerCode = string.Empty;
            var reception = _unitOfWork.GetRepository<Reception>().GetAll().FirstOrDefault(x => x.RegisteredCode == registeredCode);
            if (reception != null)
            {
                registerCode = reception.RegisteredCode;
            }
            else
            {
                var receptionByPatientCode = _unitOfWork.GetRepository<Reception>().GetAll().Where(x => x.PatientCode == patientCode).OrderByDescending(x => x.RegisteredDate).FirstOrDefault();
                if (receptionByPatientCode != null)
                {
                    registerCode = receptionByPatientCode.RegisteredCode;
                }
            }

            if (string.IsNullOrEmpty(registerCode))
            {
                return true;
            }

            var historyCard = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().FirstOrDefault(x => x.Id == tekmediCardHistoryId);
            if (historyCard != null)
            {
                if (historyCard.InvoiceNo == 0)
                {
                    return true;
                }

                var request = new CancelAdvancePaymentRequest();
                request.RegisteredCode = registerCode;
                request.PatientCode = patientCode;
                request.InvoiceNo = historyCard.InvoiceNo ?? 0;
                request.EmployeeCode = employeeCode;
                _logger.LogInformation($"SendCancelAdvancePaymentToHis Process {DateTime.Now.ToString()}, PatientCode={patientCode}, RegisterCode={registeredCode}, " +
                    $"TekmediCardHistoryId={tekmediCardHistoryId}, InvoiceNo={historyCard.InvoiceNo}");

                var result = await _hospitalSystemService.CancelAdvancePayment(request);
                if (result.StatusCode == "00" && result.Status == "success" && result.InvoiceNo > 0)
                {
                    var tekmediCardHistory = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().FirstOrDefault(x => x.Id == tekmediCardHistoryId);
                    if (tekmediCardHistory != null)
                    {
                        tekmediCardHistory.InvoiceNo = 0;
                        _unitOfWork.GetRepository<TekmediCardHistory>().Update(tekmediCardHistory);
                        _unitOfWork.Commit();


                        var tekmediCardCancelHistory = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().FirstOrDefault(x => x.TekmediCardHistoryId == tekmediCardHistoryId);
                        if (tekmediCardCancelHistory != null)
                        {
                            tekmediCardCancelHistory.InvoiceNo = result.InvoiceNo;
                            _unitOfWork.GetRepository<TekmediCardCancelHistory>().Update(tekmediCardCancelHistory);
                            _unitOfWork.Commit();
                        }
                    }
                }

                _logger.LogInformation($"SendCancelAdvancePaymentToHis Process {DateTime.Now.ToString()}, PatientCode={patientCode}," +
                    $" RegisterCode={registeredCode}, Status={result.Status}, StatusCode={result.StatusCode}, Message={result.Message} InvoiceId={result.InvoiceNo}");
            }

            return true;
        }

        /// <summary>
        /// Registers the card payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="tekmediCard">The tekmedi card.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="Exception"></exception>
        private decimal GetBalance(Patient patient)
        {
            var topUpTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
                    && h.Type == TypeEnum.Recharged
                    && h.Status == StatusEnum.Success).Sum(s => s.Amount);

            decimal paidTotal = 0;
            var receptions = _unitOfWork.GetRepository<Reception>().GetAll().Where(h => h.PatientCode == patient.Code).ToList();
            if (receptions != null && receptions.Count > 0)
            {
                foreach (var reception in receptions)
                {
                    if (reception.Status == ReceptionStatus.Success && reception.Type == ReceptionType.Paid)
                    {
                        paidTotal += _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
                        && t.RegisteredCode == reception.RegisteredCode
                        && t.Type == TransactionType.Paid
                        && t.Status == TransactionStatus.Success).Sum(s => s.Amount);
                    }
                    else
                    {
                        paidTotal += _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
                        && t.RegisteredCode == reception.RegisteredCode
                        && t.Type == TransactionType.Hold
                        && t.Status == TransactionStatus.Success).Sum(s => s.Amount);

                        paidTotal -= _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
                        && t.RegisteredCode == reception.RegisteredCode
                        && t.Type == TransactionType.Refund
                        && t.Status == TransactionStatus.Success).Sum(s => s.Amount);
                    }
                }
            }

            var payOffMedicineTotal = _unitOfWork.GetRepository<TransactionInfo>().GetAll().Where(t => t.PatientCode == patient.Code
            && t.Type == TransactionType.ServiceMedicine
            && t.Status == TransactionStatus.Success).Sum(s => s.Amount);

            var withdrawTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
            && h.Type == TypeEnum.Withdraw
            && h.Status == StatusEnum.Success).Sum(s => s.Amount);

            var cancelTotal = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(h => h.PatientId == patient.Id
            && h.Status == StatusEnum.Success).Sum(s => s.Amount);

            var returnTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
            && h.Type == TypeEnum.Return
            && h.Status == StatusEnum.Success).Sum(s => s.Amount);

            var balance = topUpTotal - paidTotal - payOffMedicineTotal - withdrawTotal - cancelTotal - returnTotal;
            return balance ?? 0;
        }

        private async Task<TekmediCardHistory> AddExtraFee(
            AddExtraFeeRequest request,
            Patient patient,
            Reception reception,
            TekmediCard tekmediCard
        )
        {
            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = request.Price,
                Time = DateTime.Now,
                Type = TypeEnum.ExtraFee,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                BeforeValue = tekmediCard.Balance,
                AfterValue = tekmediCard.Balance + request.Price,
                RegisterCode = reception.RegisteredCode
            };

            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);

            tekmediCard.Balance += request.Price;
            tekmediCard.UpdatedDate = DateTime.Now;
            _unitOfWork.GetRepository<TekmediCard>().Update(tekmediCard);
            await _unitOfWork.CommitAsync();

            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == tekmediCardHistory.Id);
        }
        #endregion
    }
}

