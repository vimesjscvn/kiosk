using CS.Common.Common;
using CS.Common.Enums;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Settings;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Domain.Services
{
    public class TekmediCardService : ITekmediCardService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private readonly HospitalSettings _hospitalSettings;
        public TekmediCardService(IUnitOfWork unitOfWork,
            HospitalSettings hospitalSettings)
        {
            _unitOfWork = unitOfWork;
            _hospitalSettings = hospitalSettings;
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

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber && x.IsActive == true);
            if (tekmediCard == null)
                throw new Exception(ErrorMessages.NotFoundCardNumber);

            return await SavePayment(request, tekmediCard, patient);
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
            {
                throw new Exception(ErrorMessages.InCorrectlyAccountBalance);
            }

            if (string.IsNullOrEmpty(request.NewTekmediCardNumber))
            {
                return await LostCardAndNotRenewPayment(request, currentTekmediCard, patient);
            }

            request.NewTekmediCardNumber = request.NewTekmediCardNumber.Trim();

            if (!(await ValidateCardNumber(request.NewTekmediCardNumber)))
                throw new Exception(ErrorMessages.InvalidCardNumber);

            var newTekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.NewTekmediCardNumber);
            if (newTekmediCard != null && newTekmediCard.IsActive)
            {
                throw new Exception(ErrorMessages.RegisteredTekmediCard);
            }

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
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().FindAsync(x => x.TekmediCardNumber == request.TekmediCardNumber);
            if (tekmediCard == null)
                throw new Exception(ErrorMessages.NotFoundCardNumber);

            if (tekmediCard != null && tekmediCard.Balance < 0)
            {
                throw new Exception(ErrorMessages.InCorrectlyAccountBalance);
            }

            return await ReturnCard(request, tekmediCard, patient);
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

            var tekmediCard = await _unitOfWork.GetRepository<TekmediCard>().GetAsyncById(history.TekmediCardId);
            if (tekmediCard == null)
            {
                throw new Exception(ErrorMessages.NotFoundCardNumber);
            }

            return await CancelPayment(history, patient, tekmediCard);
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
        private async Task<TekmediCardHistory> SavePayment(TopUpRequest request, TekmediCard tekmediCard, Patient patient)
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
                PaymentTypeId = request.PaymentType
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
            var topUpTotal = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(h => h.PatientId == patient.Id
            && h.Type == TypeEnum.Recharged
            && h.Status == StatusEnum.Success).Sum(s => s.Amount);

            decimal paidTotal = 0;
            var receptions = _unitOfWork.GetRepository<Reception>().GetAll().Where(h => h.PatientCode == patient.Code).ToList();
            if (receptions != null && receptions.Count > 0)
            {
                foreach (var reception in receptions)
                {
                    if (reception.IsFinished)
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

            tekmediCard.IsActive = true;
            tekmediCard.Balance = balance.GetValueOrDefault();
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
                TekmediCardId = tekmediCard.Id
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

            var balance = GetBalance(patient);

            var tekmediCard = new TekmediCard
            {
                TekmediCardNumber = request.TekmediCardNumber,
                StartDate = DateTime.Now,
                Balance = balance,
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
                TekmediCardId = tekmediCard.Id
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
            var tekmediCardId = Guid.NewGuid();
            decimal? beforeValue;
            decimal? afterValue;

            curentTekmediCard.IsActive = false;
            if (newTekmediCard != null)
            {
                beforeValue = newTekmediCard.Balance;
                afterValue = curentTekmediCard.Balance;

                newTekmediCard.Balance = curentTekmediCard.Balance;
                newTekmediCard.IsActive = true;

                patient.TekmediCardId = newTekmediCard.Id;
            }
            else
            {
                beforeValue = 0;
                afterValue = curentTekmediCard.Balance;

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
                    UpdatedDate = DateTime.Now
                };

                _unitOfWork.GetRepository<TekmediCard>().Add(tekmediCard);

                patient.TekmediCardId = tekmediCard.Id;
            }

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
                BeforeValue = beforeValue,
                AfterValue = afterValue
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
                BeforeValue = curentTekmediCard.Balance,
                AfterValue = curentTekmediCard.Balance
            };
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(cardFee);

            curentTekmediCard.Balance = 0;
            patient.TekmediCardNumber = request.NewTekmediCardNumber;

            await _unitOfWork.CommitAsync();

            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(i => i.Employee).FirstOrDefault(i => i.Id == cardFee.Id);
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
            curentTekmediCard.IsActive = false;

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
            patient.TekmediCardNumber = string.Empty;
            patient.TekmediCardId = null;

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
        private async Task<TekmediCardHistory> ReturnCard(ReturnCardRequest request, TekmediCard tekmediCard, Patient patient)
        {
            var balance = GetBalance(patient);
            if (balance < 0)
            {
                throw new Exception(ErrorMessages.InCorrectlyAccountBalance);
            }

            var tekmediCardHistory = new TekmediCardHistory
            {
                TekmediCardNumber = request.TekmediCardNumber,
                PatientId = patient.Id,
                Amount = balance,
                Time = DateTime.Now,
                Type = TypeEnum.Return,
                EmployeeId = request.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = tekmediCard.Id,
                BeforeValue = balance,
                AfterValue = 0
            };

            _unitOfWork.GetRepository<TekmediCardHistory>().Add(tekmediCardHistory);

            tekmediCard.Balance = 0;
            tekmediCard.IsActive = false;

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
        private async Task<TekmediCardCancelHistory> CancelPayment(TekmediCardHistory history, Patient patient, TekmediCard tekmediCard)
        {
            var amount = history.Amount.GetValueOrDefault();

            var cancelHistory = new TekmediCardCancelHistory
            {
                TekmediCardNumber = history.TekmediCardNumber,
                PatientId = history.PatientId,
                Amount = history.Amount,
                Time = DateTime.Now,
                Type = TypeEnum.Cancel,
                EmployeeId = history.EmployeeId,
                Status = StatusEnum.Success,
                TekmediCardId = history.TekmediCardId,
                TekmediCardHistoryId = history.Id,
                BeforeValue = tekmediCard.Balance,
                AfterValue = tekmediCard.Balance - amount
            };
            _unitOfWork.GetRepository<TekmediCardCancelHistory>().Add(cancelHistory);

            //patient.Balance -= amount;
            tekmediCard.Balance = tekmediCard.Balance - amount;

            await _unitOfWork.GetRepository<TekmediCardCancelHistory>().SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return cancelHistory;
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
                    if (reception.IsFinished)
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
            return balance.HasValue ? balance.Value : 0;
        }
        #endregion
    }
}

