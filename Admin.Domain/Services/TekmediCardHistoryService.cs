using AutoMapper;
using CS.Common.Common;
using CS.Common.Enums;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    public class TekmediCardHistoryService : ITekmediCardHistoryService
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
        /// The configuration
        /// </summary>
        private IConfiguration _configuration;
        public TekmediCardHistoryService(
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public TekmediCardHistory Add(TekmediCardHistory entity)
        {
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TekmediCardHistory> AddAsync(TekmediCardHistory entity)
        {
            _unitOfWork.GetRepository<TekmediCardHistory>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<TekmediCardHistory>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<TekmediCardHistory>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TekmediCardHistory entity)
        {
            _unitOfWork.GetRepository<TekmediCardHistory>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<TekmediCardHistory>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(TekmediCardHistory entity)
        {
            _unitOfWork.GetRepository<TekmediCardHistory>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<TekmediCardHistory>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        public TekmediCardHistory Find(Expression<Func<TekmediCardHistory, bool>> match)
        {
            return _unitOfWork.GetRepository<TekmediCardHistory>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TekmediCardHistory> FindAll(Expression<Func<TekmediCardHistory, bool>> match)
        {
            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TekmediCardHistory>> FindAllAsync(Expression<Func<TekmediCardHistory, bool>> match)
        {
            return await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TekmediCardHistory> FindAsync(Expression<Func<TekmediCardHistory, bool>> match)
        {
            return await _unitOfWork.GetRepository<TekmediCardHistory>().FindAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public TekmediCardHistory Get(Guid id)
        {
            return _unitOfWork.GetRepository<TekmediCardHistory>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        public ICollection<TekmediCardHistory> GetAll()
        {
            return _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        public async Task<ICollection<TekmediCardHistory>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<TekmediCardHistory> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<TekmediCardHistory>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>TekmediCardHistory.</returns>
        public TekmediCardHistory Update(TekmediCardHistory entity, Guid id)
        {
            if (entity == null)
                return null;

            TekmediCardHistory existing = _unitOfWork.GetRepository<TekmediCardHistory>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TekmediCardHistory>().Update(entity);
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
        /// TekmediCardHistory.
        /// </returns>
        public async Task<TekmediCardHistory> UpdateAsync(TekmediCardHistory entity, Guid id)
        {
            if (entity == null)
                return null;

            TekmediCardHistory existing = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<TekmediCardHistory>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        #region Public Funcs
        /// <summary>
        /// Gets the statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<StatisticalViewModel>> GetStatistical(ExportRequest request)
        {
            var result = new TableResultJsonResponse<StatisticalViewModel>();
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var histories = new List<BaseTekmediCardHistory>();
            var orderValue = "";
            if (request.Order != null && request.Order.Length > 0)
            {
                orderValue = request.Order[0].Dir.Trim().ToLower();
            }
            var paymentType = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where
                (x => x.Id == request.PaymentTypeId).FirstOrDefaultAsync();

            histories.AddRange(_unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(
                t => t.EmployeeId == request.EmployeeId && t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient).Include(h => h.PaymentType));

            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(
                t => t.EmployeeId == request.EmployeeId && t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient).Include(h => h.PaymentType).ToListAsync();

            if (paymentType != null && paymentType.Code != "All")
            {
                histories = histories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
                cancelHistories = cancelHistories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
            }

            histories.AddRange(cancelHistories);

            var totalRecord = histories.Count();
            var filteredHistories = histories.OrderBy(t => t.TekmediCardNumber)
                .ThenBy(t => t.Time).Skip(request.Start).Take(request.Length).ToList();

            foreach (var history in filteredHistories)
            {
                var province = provinces.FirstOrDefault(p => p.Code == history.Patient?.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == history.Patient?.DistrictCode && d.ProvinceCode == history.Patient?.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == history.Patient?.WardCode && w.DistrictCode == history.Patient?.DistrictCode);
                statisticals.Add(ToViewModel(history, cancelHistories, province, district, ward));
            }

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = ApplyOrderBy(statisticals.AsQueryable(), orderValue).ToList();

            return result;
        }
        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<StatisticalViewModel> GetHistory(Guid id)
        {
            StatisticalViewModel historyViewModel = null;
            var history = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(h => h.Employee)
                .Include(h => h.Patient).FirstOrDefaultAsync(h => h.Id == id);
            if (history != null)
            {
                var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                    .Where(t => t.TekmediCardHistoryId == id).Include(h => h.Employee).Include(h => h.Patient).ToListAsync();
                var province = await _unitOfWork.GetRepository<Province>().GetAll().FirstOrDefaultAsync(p => p.Code == history.Patient.ProvinceCode);
                var district = await _unitOfWork.GetRepository<District>().GetAll().FirstOrDefaultAsync(d => d.Code == history.Patient.DistrictCode && d.ProvinceCode == history.Patient.ProvinceCode);
                var ward = await _unitOfWork.GetRepository<Ward>().GetAll().FirstOrDefaultAsync(w => w.Code == history.Patient.WardCode && w.DistrictCode == history.Patient.DistrictCode);
                historyViewModel = ToViewModel(history, cancelHistories, province, district, ward);
            }

            return historyViewModel;
        }

        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<StatisticalIncludeUserName> GetHistoryToBilling(Guid id)
        {
            StatisticalIncludeUserName historyViewModel = null;
            var history = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Include(h => h.Employee)
                .Include(h => h.Patient).FirstOrDefaultAsync(h => h.Id == id);
            if (history != null)
            {
                var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                    .Where(t => t.TekmediCardHistoryId == id).Include(h => h.Employee).Include(h => h.Patient).ToListAsync();
                var province = await _unitOfWork.GetRepository<Province>().GetAll().FirstOrDefaultAsync(p => p.Code == history.Patient.ProvinceCode);
                var district = await _unitOfWork.GetRepository<District>().GetAll().FirstOrDefaultAsync(d => d.Code == history.Patient.DistrictCode && d.ProvinceCode == history.Patient.ProvinceCode);
                var ward = await _unitOfWork.GetRepository<Ward>().GetAll().FirstOrDefaultAsync(w => w.Code == history.Patient.WardCode && w.DistrictCode == history.Patient.DistrictCode);
                historyViewModel = ToViewModelBilling(history, cancelHistories, province, district, ward);
            }

            return historyViewModel;
        }

        /// <summary>
        /// Gets the history.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;ICollection&lt;StatisticalViewModel&gt;&gt;.</returns>
        public async Task<TableResultJsonResponse<StatisticalViewModel>> GetHistory(HistoryCardRequest request)
        {
            var patientCode = request.PatientCode.Trim().ToLower();
            var patientName = request.PatientName.Trim().ToLower();
            var result = new TableResultJsonResponse<StatisticalViewModel>();
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var orderValue = "";
            if (request.Order != null && request.Order.Length > 0)
            {
                orderValue = request.Order[0].Dir.Trim().ToLower();
            }
            var predicateHistory = PredicateBuilder.Create<TekmediCardHistory>(t => t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw);
            if (!string.IsNullOrEmpty(patientCode))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.Trim().ToLower().Contains(patientCode));
            }

            if (!string.IsNullOrEmpty(patientName))
            {
                predicateHistory = predicateHistory.And(p => (p.Patient.LastName.Trim().ToLower() + " " + p.Patient.FirstName.Trim().ToLower()).Trim().Contains(patientName));
            }

            var predicateCancelHistory = PredicateBuilder.Create<TekmediCardCancelHistory>(t => t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw);
            if (!string.IsNullOrEmpty(patientCode))
            {
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.Trim().ToLower().Contains(patientCode));
            }

            if (!string.IsNullOrEmpty(patientName))
            {
                predicateCancelHistory = predicateCancelHistory.And(p => (p.Patient.LastName.Trim().ToLower() + " " + p.Patient.FirstName.Trim().ToLower()).Trim().Contains(patientName));
            }

            IEnumerable<BaseTekmediCardHistory> histories = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(predicateHistory)
                .Include(h => h.Employee).Include(h => h.Patient);
            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(predicateCancelHistory)
                .Include(h => h.Employee).Include(h => h.Patient).ToListAsync();
            histories.Concat(cancelHistories);

            var totalRecord = histories.Count();
            var filteredHistories = histories.OrderBy(t => t.Time).Skip(request.Start).Take(request.Length).ToList();

            foreach (var history in filteredHistories)
            {
                var province = provinces.FirstOrDefault(p => p.Code == history.Patient?.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == history.Patient?.DistrictCode && d.ProvinceCode == history.Patient?.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == history.Patient?.WardCode && w.DistrictCode == history.Patient?.DistrictCode);
                statisticals.Add(ToViewModel(history, cancelHistories, province, district, ward));
            }

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = ApplyOrderBy(statisticals.AsQueryable(), orderValue).ToList();

            return result;
        }

        /// <summary>
        /// Gets the admin statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ICollection&lt;StatisticalViewModel&gt;.</returns>
        public async Task<TableResultJsonResponse<StatisticalViewModel>> GetAdminStatistical(ExportRequest request)
        {
            var result = new TableResultJsonResponse<StatisticalViewModel>();
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var orderValue = "";
            if (request.Order != null && request.Order.Length > 0)
            {
                orderValue = request.Order[0].Dir.Trim().ToLower();
            }
            var paymentType = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where
               (x => x.Id == request.PaymentTypeId).FirstOrDefaultAsync();
            var histories = new List<BaseTekmediCardHistory>();

            histories.AddRange(_unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(t => t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient).Include(t => t.PaymentType));

            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(t => t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient).Include(t => t.PaymentType).ToListAsync();

            if (paymentType != null && paymentType.Code != "All")
            {
                histories = histories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
                cancelHistories = cancelHistories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
            }

            histories.AddRange(cancelHistories);

            var totalRecord = histories.Count();
            var filteredHistories = histories.OrderBy(t => t.TekmediCardNumber)
                .ThenBy(t => t.Time).Skip(request.Start).Take(request.Length).ToList();

            foreach (var history in filteredHistories)
            {
                var province = provinces.FirstOrDefault(p => p.Code == history.Patient?.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == history.Patient?.DistrictCode && d.ProvinceCode == history.Patient?.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == history.Patient?.WardCode && w.DistrictCode == history.Patient?.DistrictCode);
                statisticals.Add(ToViewModel(history, cancelHistories, province, district, ward));
            }

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = ApplyOrderBy(statisticals.AsQueryable(), orderValue).ToList();

            return result;
        }

        /// <summary>
        /// Exports the statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<StatisticalViewModel>> ExportStatistical(ExportRequest request)
        {
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var paymentType = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where
               (x => x.Id == request.PaymentTypeId).FirstOrDefaultAsync();

            var histories = new List<BaseTekmediCardHistory>();

            histories.AddRange(await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                //.FromSqlRaw(@"SELECT * FROM ""IHM"".tekmedi_card_history")
                .Where(t => t.EmployeeId == request.EmployeeId && t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date &&
                    (t.Type == TypeEnum.Register
                    || t.Type == TypeEnum.Recharged
                    || t.Type == TypeEnum.Return
                    || t.Type == TypeEnum.CardFee))
                .Include(h => h.Employee).Include(h => h.Patient).Include(h => h.PaymentType)
                .ToListAsync());
            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                //.FromSqlRaw(@"SELECT * FROM ""IHM"".tekmedi_card_cancel_history")
                .Where(t => t.EmployeeId == request.EmployeeId && t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date &&
                    (t.Type == TypeEnum.Register
                    || t.Type == TypeEnum.Recharged
                    || t.Type == TypeEnum.Return
                    || t.Type == TypeEnum.CardFee))
                .Include(h => h.Employee).Include(h => h.Patient).Include(h => h.PaymentType)
                .ToListAsync();

            if (paymentType != null && paymentType.Code != "All")
            {
                histories = histories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
                cancelHistories = cancelHistories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
            }

            histories.AddRange(cancelHistories);

            foreach (var history in histories)
            {
                var province = provinces.FirstOrDefault(p => p.Code == history.Patient?.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == history.Patient?.DistrictCode && d.ProvinceCode == history.Patient?.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == history.Patient?.WardCode && w.DistrictCode == history.Patient?.DistrictCode);
                statisticals.Add(ToViewModel(history, cancelHistories, province, district, ward));
            }

            return statisticals.OrderBy(t => t.TekmediCardNumber).ThenBy(t => t.Time).ToList();
        }

        /// <summary>
        /// Exports the admin statistical.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ICollection<StatisticalViewModel>> ExportAdminStatistical(ExportRequest request)
        {
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();
            var paymentType = await _unitOfWork.GetRepository<ListValueExtend>().GetAll().Where
               (x => x.Id == request.PaymentTypeId).FirstOrDefaultAsync();

            var histories = new List<BaseTekmediCardHistory>();
            histories.AddRange(await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                .Where(t => t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date
                && t.Status == StatusEnum.Success
                && (t.Type == TypeEnum.Register
                || t.Type == TypeEnum.Recharged
                || t.Type == TypeEnum.Return
                || t.Type == TypeEnum.CardFee))
                .Include(h => h.Employee).Include(h => h.Patient).Include(h => h.PaymentType)
                .ToListAsync());

            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                .Where(t => t.Time.Date >= request.StartDate.Date && t.Time.Date <= request.EndDate.Date
                    && t.Status == StatusEnum.Success
                    && (t.Type == TypeEnum.Register
                    || t.Type == TypeEnum.Recharged
                    || t.Type == TypeEnum.Return
                    || t.Type == TypeEnum.CardFee
                    || t.Type == TypeEnum.Cancel))
                .Include(h => h.Employee).Include(h => h.Patient).Include(h => h.PaymentType)
                .ToListAsync();

            if (paymentType != null && paymentType.Code != "All")
            {
                histories = histories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
                cancelHistories = cancelHistories.Where(t => t.PaymentTypeId == paymentType.Id).ToList();
            }

            histories.AddRange(cancelHistories);

            foreach (var history in histories)
            {
                var province = provinces.FirstOrDefault(p => p.Code == history.Patient?.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == history.Patient?.DistrictCode && d.ProvinceCode == history.Patient?.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == history.Patient?.WardCode && w.DistrictCode == history.Patient?.DistrictCode);
                statisticals.Add(ToViewModel(history, cancelHistories, province, district, ward));
            }

            return statisticals.OrderBy(t => t.TekmediCardNumber).ThenBy(t => t.Time).ToList();
        }

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

        public async Task<TekmediCardCashflowExportSheetData> ExportAdminCashFlowReport(ExportOverviewCashflowRequest request, SysUser employee)
        {
            var cashFlowResult = new List<TekmediCardCashFlowPrepareData>();
            var paymentResultList = new List<TransactionInfo>();
            var cancelledPaymentResultList = new List<TransactionInfo>();
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

            if (request.PatientType == ExportOverviewCashflowPatientType.BHYT)
            {
                paymentResultList = paymentResultList
                    .Where(x => x.Reception?.IsFinished == true
                        && x.Reception?.PatientType == "Bảo hiểm")
                    .ToList();

                cancelledPaymentResultList = cancelledPaymentResultList
                    .Where(x => x.Reception?.PatientType == "Bảo hiểm")
                    .ToList();
            }
            else if (request.PatientType == ExportOverviewCashflowPatientType.DV)
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
                        CreatedDate = advancePaymentResult.Time
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
                        i.PatientName, 
                        i.Gender, 
                        i.BirthDate 
                    },
                  (key, g) => new
                  { 
                      RegisteredCode = key.RegisteredCode, 
                      PatientName = key.PatientName,
                      Gender = key.Gender, 
                      BirthDate = key.BirthDate, 
                      TransactionDate = g.Where(x => x.RegisteredCode == key.RegisteredCode)
                        .OrderByDescending(x => x.TransactionDate).FirstOrDefault()?.TransactionDate , Historys = g.ToList() 
                  });

            var listResult = new List<TekmediCardCashflowExportViewModel>();
            int indexRow = 1;
            foreach (var groupItem in groups)
            {
                string rowNumber = "";
                decimal diffAmount = 0;
                string time = "";
                string note = "";
                var rowNumberItem = groupItem.Historys.FirstOrDefault(x => x.Type == TekmediCardCashFlowPrepareDataEnum.Payment && x.RegisteredCode == groupItem.RegisteredCode);
                // Khi hủy tất toán mà chưa tất toán lại thì dư record -0-0
                if (rowNumberItem == null)
                {
                    continue;
                }

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
                    PatientName = groupItem.PatientName,
                    BirthDate = groupItem.BirthDate,
                    Gender = groupItem.Gender,
                    TransactionDate = groupItem.TransactionDate,
                    AdvancePaymentAmount = groupItem.Historys.Select(h => h.AdvancePaymentAmount).Sum() - groupItem.Historys.Select(h => h.CancelAdvancePaymentAmount).Sum(),
                    TotalFeeAmount = groupItem.Historys.Select(x => x.TotalFee).Sum(),
                    PatientPaymentAmount = groupItem.Historys.Select(x => x.PatientPaymentAmount).Sum(),
                    InsurancePaymentAmount = groupItem.Historys.Select(x => x.InsurancePaymentAmount).Sum(),
                    TotalRefundAmount = groupItem.Historys.Select(x => x.RefundPaymentAmount).Sum(),
                    TotalLostAmount = groupItem.Historys.Select(x => x.LostPaymentAmount).Sum(),
                    IsReturnedCard = cashFlowResult.Any(x => x.RegisteredCode == groupItem.RegisteredCode && x.Type == TekmediCardCashFlowPrepareDataEnum.Refund),
                    SerialNo = rowNumberItem == null ? string.Empty : rowNumberItem.SerialNo,
                    RecvNo = rowNumberItem == null ? 0 : rowNumberItem.RecvNo,
                    DepartmentName = "Khoa khám bệnh",
                    ExtraFeeAmount = groupItem.Historys.Select(x => x.ExtraFeeAmount).Sum(),
                    Type = TekmediCardCashFlowPrepareDataEnum.Payment,
                    DiffAmount = diffAmount,
                    Time = time,
                    Note = note
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

                decimal extraFee = 0;
                var extraFeeRec = cancelExtraFeeResultList.Where(x => x.TransactionInfoId == groupItem.TransactionInfoId).FirstOrDefault();
                if (extraFeeRec != null)
                {
                    extraFee = extraFeeRec.Amount.Value;
                }

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

                listResult.Add(new TekmediCardCashflowExportViewModel
                {
                    RowNum = groupItem.RowNumber,
                    RegisteredCode = groupItem.RegisteredCode,
                    PatientName = groupItem.PatientName,
                    BirthDate = groupItem.BirthDate,
                    Gender = groupItem.Gender,
                    TransactionDate = groupItem.TransactionDate,
                    AdvancePaymentAmount = advancePaymentAmountHistories.Select(h => h.AdvancePaymentAmount).Sum() - cancelAdvancePaymentAmountHistories.Select(h => h.CancelAdvancePaymentAmount).Sum(),
                    TotalFeeAmount = groupItem.TotalFee,
                    PatientPaymentAmount = groupItem.PatientPaymentAmount,
                    InsurancePaymentAmount = groupItem.InsurancePaymentAmount,
                    TotalRefundAmount = histories.Select(x => x.RefundPaymentAmount).Sum(),
                    TotalLostAmount = histories.Select(x => x.LostPaymentAmount).Sum(),
                    IsReturnedCard = histories.Any(x => x.RegisteredCode == groupItem.RegisteredCode && x.Type == TekmediCardCashFlowPrepareDataEnum.Refund),
                    SerialNo = groupItem.SerialNo,
                    RecvNo = groupItem.RecvNo,
                    DepartmentName = "Khoa khám bệnh",
                    ExtraFeeAmount = extraFee,
                    Time = time,
                    Type = TekmediCardCashFlowPrepareDataEnum.PaymentCancel
                });
            }

            var cashFlowResultForEmployee = cashFlowResult.Where(x => x.Type == TekmediCardCashFlowPrepareDataEnum.Payment).ToList();
            var patientAndCard = cashFlowResult.Select(x => new
            {
                RegisteredCode = x.RegisteredCode,
                TekmediCardNumber = x.TekmediCardNumber
            }).Distinct().ToList();

            var groupsByEmployee = cashFlowResultForEmployee.GroupBy(i => new { i.TekmediCardNumber, i.RegisteredCode, i.PatientName, i.Gender, i.BirthDate, i.EmployeeUserName },
                  (key, g) => new
                  {
                      TekmediCardNumber = key.TekmediCardNumber,
                      RegisteredCode = key.RegisteredCode,
                      PatientName = key.PatientName,
                      Gender = key.Gender,
                      BirthDate = key.BirthDate,
                      EmployeeUserName = key.EmployeeUserName,
                      Historys = g.ToList()
                  });

            var listResultByEmployee = new List<TekmediCardCashflowExportViewModel>();
            int indexRowByEmployee = 1;
            foreach (var groupItem in groupsByEmployee)
            {
                string rowNumber = "";
                var rowNumberItem = groupItem.Historys.FirstOrDefault(x => x.Type == TekmediCardCashFlowPrepareDataEnum.Payment && x.RegisteredCode == groupItem.RegisteredCode);
                if (rowNumberItem != null)
                {
                    if (rowNumberItem.RowNumber != "--")
                    {
                        rowNumber = rowNumberItem.RowNumber;
                    }
                }

                if (rowNumber == "")
                {
                    rowNumber = "-0-0";
                }

                listResultByEmployee.Add(new TekmediCardCashflowExportViewModel
                {
                    RowNum = rowNumber,
                    RegisteredCode = groupItem.RegisteredCode,
                    PatientName = groupItem.PatientName,
                    BirthDate = groupItem.BirthDate,
                    Gender = groupItem.Gender,
                    TotalFeeAmount = groupItem.Historys.Select(x => x.TotalFee).Sum(),
                    TekmediCardNumber = patientAndCard.FirstOrDefault(x => x.RegisteredCode == groupItem.RegisteredCode)?.TekmediCardNumber,
                    InsurancePaymentAmount = groupItem.Historys.Select(x => x.InsurancePaymentAmount).Sum(),
                    PatientPaymentAmount = groupItem.Historys.Select(x => x.PatientPaymentAmount).Sum(),
                    SerialNo = rowNumberItem == null ? string.Empty : rowNumberItem.SerialNo,
                    RecvNo = rowNumberItem == null ? 0 : rowNumberItem.RecvNo,
                    EmployeeName = rowNumberItem == null ? "" : rowNumberItem.EmployeeName,
                    DepartmentName = "Khoa khám bệnh"
                });

                indexRowByEmployee++;
            }

            var listData = new TekmediCardCashflowExportSheetData();
            listData.ListDetail = listResult;
            listData.ListDetailByEmployee = listResultByEmployee;

            return listData;
        }

        /// <summary>
        /// Gets the type of the history with.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<StatisticalViewModel>> GetHistoryWithType(HistoryCardWithTypeRequest request)
        {
            var patientCode = request.PatientCode.Trim().ToLower();
            var patientName = request.PatientName.Trim().ToLower();
            var result = new TableResultJsonResponse<StatisticalViewModel>();
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();

            var predicateHistory = PredicateBuilder.Create<TekmediCardHistory>(
                t => request.Types.Contains(t.Type) 
                && t.Status == StatusEnum.Success);
            var predicateCancelHistory = PredicateBuilder.Create<TekmediCardCancelHistory>(
                t => request.Types.Contains(t.Type)
                && t.Status == StatusEnum.Success);

            if (!string.IsNullOrEmpty(patientCode))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.ToLower().Contains(patientCode));
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.ToLower().Contains(patientCode));
            }

            if (!string.IsNullOrEmpty(patientName))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null
                                    && t.Patient.FirstName != null
                                    && t.Patient.LastName != null
                                    && (t.Patient.LastName.ToLower() + " " + t.Patient.FirstName.ToLower())
                                        .Contains(patientName));
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null
                                    && t.Patient.FirstName != null
                                    && t.Patient.LastName != null
                                    && (t.Patient.LastName.ToLower() + " " + t.Patient.FirstName.ToLower())
                                        .Contains(patientName));
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                predicateHistory = predicateHistory.And(t => t.RegisterCode == request.RegisteredCode);
                predicateCancelHistory = predicateCancelHistory.And(t => t.RegisterCode == request.RegisteredCode);
            }

            var histories = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(predicateHistory)
                .Include(h => h.Patient).Select(x => _mapper.Map<BaseTekmediCardHistory>(x)).ToListAsync();

            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(predicateCancelHistory)
              .Include(h => h.Patient).ToListAsync();

            histories = histories.Concat(cancelHistories).ToList();

            var totalRecord = histories.Count();

            var filteredHistories = histories
              .OrderByDescending(t => t.Time)
              .Skip(request.Start).Take(request.Length)
              .ToList();

            foreach (var history in filteredHistories)
            {
                var province = provinces.FirstOrDefault(p => p.Code == history.Patient?.ProvinceCode);
                var district = districts.FirstOrDefault(d => d.Code == history.Patient?.DistrictCode && d.ProvinceCode == history.Patient?.ProvinceCode);
                var ward = wards.FirstOrDefault(w => w.Code == history.Patient?.WardCode && w.DistrictCode == history.Patient?.DistrictCode);
                statisticals.Add(ToViewModel(history, cancelHistories, province, district, ward));
            }

            result.Draw = request.Draw;
            result.RecordsTotal = totalRecord;
            result.RecordsFiltered = totalRecord;
            result.Data = statisticals
                .OrderByDescending(t => t.Time)
                .ToList();

            return result;
        }

        /// <summary>
        /// Counts the history.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<int> CountHistory(NumberBillRequest request)
        {
            var histories = await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                        .Where(x => x.EmployeeId == request.EmployeeId &&
                        x.Status == StatusEnum.Success &&
                        x.Type == request.Type && x.Status == StatusEnum.Success &&
                        DateTime.Compare(x.Time.Date, request.Date.Date) == 0).OrderBy(x => x.Time).ToListAsync();

            int count = 0;

            if (request.HistoryId != Guid.Empty)
            {
                var history = histories.FirstOrDefault(x => x.Id == request.HistoryId);
                if (history != null)
                    count = histories.IndexOf(history) + 1;
            }
            else
                count = histories.Count();

            return count;
        }
         
        public async Task<List<TekmediCardHistoryCardExportViewModel>> GetCancelledAdvancePaymentForExport(ExportHistoryCardRequest request, bool isAdmin)
        {
            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
            var data = new List<TekmediCardHistoryCardExportViewModel>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var startDate = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
                var endDate = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
                var sqlForGetData = $"select concat(tch.serial_no, '-', tch.recv_no) as RowNum, " +
                       "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                       "CARD.employee_id AS EmployeeId, " +
                       "CARD.price AS CancelAdvancePaymentAmount, " +
                       "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                       "P.code AS PatientCode, " +
                       "CARD.\"time\" AS TIME, " +
                       "CARD.\"type\" AS TYPE," +
                       "LVE.description AS PaymentTypeName, " +
                       "LVE.code AS PaymentTypeCode, " +
                       "s.full_name AS EmployeeName, " +
                       "coalesce(tch.register_code, '0') AS RegisteredCode, " +
                       "'Khoa khám bệnh' AS DepartmentName, " +
                       "tch.recv_no AS RecvNo, " +
                       "tch.serial_no AS SerialNo " +
                    "FROM \"IHM\".tekmedi_card_cancel_history AS CARD " +
                    "JOIN \"IHM\".tekmedi_card_history AS tch on tch.id = CARD.tekmedi_card_history_id " +
                    "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON tch.payment_type_id = LVE.ID " +
                    "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                    "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                    "LEFT JOIN \"IHM\".reception AS r ON r.registered_code = CARD.register_code " +
                    $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                       $"AND CARD.\"type\" = '12' " +
                       $"AND CARD.\"time\" >= '{startDate}' " +
                       $"AND CARD.\"time\" <= '{endDate}' ";

                if (!isAdmin)
                {
                    sqlForGetData += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                }

                if (request.PatientType == ExportHistoryCardPatientType.BHYT)
                {
                    sqlForGetData += "and r.patient_type = 'Bảo hiểm' ";
                }
                else if (request.PatientType == ExportHistoryCardPatientType.DV)
                {
                    sqlForGetData += "and r.patient_type = 'Dịch vụ' ";
                }

                using (var multi = await connection.QueryMultipleAsync(sqlForGetData).ConfigureAwait(false))
                {
                    data = multi.Read<TekmediCardHistoryCardExportViewModel>().ToList();
                }
            }

            return data;
        }

        public async Task<List<TekmediCardHistoryCardExportViewModel>> GetExportHistoryCardAdvancePaymentSheet(ExportHistoryCardRequest request, bool isAdmin)
        {
            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
            var data = new List<TekmediCardHistoryCardExportViewModel>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var startDate = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
                var endDate = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
                var sqlForGetData = $"select concat(CARD.serial_no, '-', CARD.recv_no) as RowNum, " +
                         "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                         "CARD.new_tekmedi_card_number AS NewTekmediCardNumber, " +
                         "CARD.employee_id AS EmployeeId, " +
                         "CARD.price AS Amount, " +
                         "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                         "P.code AS PatientCode, " +
                         "CARD.\"time\" AS TIME, " +
                         "CARD.\"type\" AS TYPE," +
                         "LVE.description AS PaymentTypeName, " +
                         "LVE.code AS PaymentTypeCode, " +
                         "s.full_name AS EmployeeName, " +
                         "coalesce(CARD.register_code, '0') AS RegisteredCode, " +
                         "'Khoa khám bệnh' AS DepartmentName, " +
                         "CARD.recv_no AS RecvNo, " +
                         "CARD.serial_no AS SerialNo " +
                      "FROM \"IHM\".tekmedi_card_history AS CARD " +
                      "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                      "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                      "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                      "LEFT JOIN \"IHM\".reception AS r ON r.registered_code = CARD.register_code " +
                      $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                         $"AND CARD.\"time\" >= '{startDate}' " +
                         $"AND CARD.\"time\" <= '{endDate}' " +
                         $"AND CARD.\"type\" = '{(int)TypeEnum.Recharged}' ";

                if (!isAdmin)
                {
                    sqlForGetData += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                }

                if (request.PatientType == ExportHistoryCardPatientType.BHYT)
                {
                    sqlForGetData += "and r.patient_type = 'Bảo hiểm' ";
                }
                else if (request.PatientType == ExportHistoryCardPatientType.DV)
                {
                    sqlForGetData += "and r.patient_type = 'Dịch vụ' ";
                }

                using (var multi = await connection.QueryMultipleAsync(sqlForGetData).ConfigureAwait(false))
                {
                    data = multi.Read<TekmediCardHistoryCardExportViewModel>().ToList();
                }
            }

            return data;
               
        }

        public async Task<List<TekmediCardHistoryCardExportViewModel>> GetExportHistoryCardRefundSheet(ExportHistoryCardRequest request, bool isAdmin)
        {
            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
            var data = new List<TekmediCardHistoryCardExportViewModel>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var startDate = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
                var endDate = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
                var sqlForGetData = $"select concat(CARD.serial_no, '-', CARD.recv_no) as RowNum, " +
                         "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                         "CARD.new_tekmedi_card_number AS NewTekmediCardNumber, " +
                         "CARD.employee_id AS EmployeeId, " +
                         "CARD.price AS Amount, " +
                         "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                         "P.code AS PatientCode, " +
                         "CARD.\"time\" AS TIME, " +
                         "CARD.\"type\" AS TYPE," +
                         "LVE.description AS PaymentTypeName, " +
                         "LVE.code AS PaymentTypeCode, " +
                         "s.full_name AS EmployeeName, " +
                         "coalesce(CARD.register_code, '0') AS RegisteredCode, " +
                         "'Khoa khám bệnh' AS DepartmentName, " +
                         "CARD.recv_no AS RecvNo, " +
                         "CARD.serial_no AS SerialNo " +
                      "FROM \"IHM\".tekmedi_card_history AS CARD " +
                      "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                      "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                      "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                      "LEFT JOIN \"IHM\".reception AS r ON r.registered_code = CARD.register_code " +
                      $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                         $"AND CARD.\"time\" >= '{startDate}' " +
                         $"AND CARD.\"time\" <= '{endDate}' " +
                         $"AND CARD.\"type\" = '{(int)TypeEnum.Refund}' ";

                if (!isAdmin)
                {
                    sqlForGetData += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                }

                if (request.PatientType == ExportHistoryCardPatientType.BHYT)
                {
                    sqlForGetData += "and r.patient_type = 'Bảo hiểm' ";
                }
                else if (request.PatientType == ExportHistoryCardPatientType.DV)
                {
                    sqlForGetData += "and r.patient_type = 'Dịch vụ' ";
                }

                using (var multi = await connection.QueryMultipleAsync(sqlForGetData).ConfigureAwait(false))
                {
                    data = multi.Read<TekmediCardHistoryCardExportViewModel>().ToList();
                }
            }

            return data;

        }

        /// <summary>
        /// The Get Export History Card
        /// </summary>
        /// <param name="exportRequest"></param>
        /// <returns></returns>
        public async Task<PagedResponse<List<TekmediCardHistoryCardExportViewModel>>> GetExportHistoryCard(ExportHistoryCardRequest request, bool isAdmin, bool isExport)
        {
            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));

            using (var connection = new NpgsqlConnection(connectionString))
            {
                var startDate = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
                var endDate = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";

                var sqlCount =
                      $"SELECT count(*) " +
                     "FROM \"IHM\".tekmedi_card_history AS CARD " +
                     "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                     "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                     "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                     "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                     $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}'" +
                        $"AND CARD.\"time\" >= '{startDate}' " +
                        $"AND CARD.\"time\" <= '{endDate}' " +
                        "and chis.id is null ";

                var sqlForGetData = $"select  concat(s.user_name, '-', substring(cast(DATE_PART('year', card.time::date) as text), 3, 2), '-' ," +
                                    "CAST(row_number() over(partition by card.employee_id, card.type order by card.time) as text))   as RowNum, " +
                       "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                       "CARD.employee_id AS EmployeeId, " +
                       "CARD.price AS Amount, " +
                       "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                       "P.code AS PatientCode, " +
                       "CARD.\"time\" AS TIME, " +
                       "CARD.\"type\" AS TYPE," +
                       "LVE.description AS PaymentTypeName, " +
                       "LVE.code AS PaymentTypeCode, " +
                       "s.full_name AS EmployeeName, " +
                       "coalesce(CARD.register_code, '0') AS RegisteredCode, " +
                       "'Khoa khám bệnh' AS DepartmentName, " +
                       "CAST(row_number() over(partition by card.employee_id, card.type order by card.time) as text) AS RecvNo " +
                    "FROM \"IHM\".tekmedi_card_history AS CARD " +
                    "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                    "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                     "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                    "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                    $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                       $"AND CARD.\"time\" >= '{startDate}' " +
                       $"AND CARD.\"time\" <= '{endDate}' " +
                    "and chis.id is null ";

                if (isExport == false)
                {
                    sqlForGetData += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";
                    sqlCount += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";
                    if (request.TypeCard != (int)TypeEnum.Overview)
                    {
                        if (request.TypeCard == (int)TypeEnum.Recharged)
                        {
                            sqlCount +=
                                   $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                                    $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}') ";
                            sqlForGetData +=
                                   $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                                    $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}') ";
                        }
                        else
                        {
                            sqlCount += $"AND CARD.\"type\" = {request.TypeCard} ";
                            sqlForGetData += $"AND CARD.\"type\" = {request.TypeCard} ";
                        }
                    }
                    else
                    {
                        sqlCount +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";

                        sqlForGetData +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";
                    }

                    if (string.IsNullOrEmpty(request.RegisteredCode) == false)
                    {
                        sqlCount += $"AND CARD.register_code = '{request.RegisteredCode}' ";
                        sqlForGetData += $"AND CARD.register_code = '{request.RegisteredCode}' ";
                    }
                }
                else // type = export
                {
                    sqlCount =
                          $"SELECT count(*) " +
                         "FROM \"IHM\".tekmedi_card_history AS CARD " +
                         "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                         "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                         "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                         "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                         $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}'" +
                            $"AND CARD.\"time\" >= '{startDate}' " +
                            $"AND CARD.\"time\" <= '{endDate}' " +
                    "and chis.id is null ";

                    sqlForGetData = $"select  concat(s.user_name, '-', substring(cast(DATE_PART('year', card.time::date) as text), 3, 2), '-' ," +
                                    "CAST(row_number() over(partition by card.employee_id, card.type order by card.time) as text))   as RowNum, " +
                           "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                           "CARD.new_tekmedi_card_number AS NewTekmediCardNumber, " +
                           "CARD.employee_id AS EmployeeId, " +
                           "CARD.price AS Amount, " +
                           "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                           "P.code AS PatientCode, " +
                           "CARD.\"time\" AS TIME, " +
                           "CARD.\"type\" AS TYPE," +
                           "LVE.description AS PaymentTypeName, " +
                           "LVE.code AS PaymentTypeCode, " +
                           "s.full_name AS EmployeeName, " +
                           "coalesce(CARD.register_code, '0') AS RegisteredCode, " +
                           "'Khoa khám bệnh' AS DepartmentName, " +
                           "CAST(row_number() over(partition by card.employee_id, card.type order by card.time) as text) AS RecvNo " +
                        "FROM \"IHM\".tekmedi_card_history AS CARD " +
                        "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                        "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                        "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                        "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                        $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                           $"AND CARD.\"time\" >= '{startDate}' " +
                           $"AND CARD.\"time\" <= '{endDate}' " +
                    "and chis.id is null ";

                    sqlForGetData += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";
                    sqlCount += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";

                    if (request.TypeCard != (int)TypeEnum.Overview)
                    {
                        sqlCount += $"AND CARD.\"type\" = {request.TypeCard} ";
                        sqlForGetData += $"AND CARD.\"type\" = {request.TypeCard} ";
                    }
                    else
                    {
                        sqlCount +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Lost}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";

                        sqlForGetData +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Lost}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";
                    }
                }


                if (!isAdmin)
                {
                    sqlForGetData += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                    sqlCount += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                }
                sqlCount += "; ";

                sqlForGetData += "ORDER BY CARD.\"time\", RowNum ";
                if (!isExport)
                {
                    sqlForGetData += $" OFFSET (({request.PageNumber} - 1) * {request.PageSize}) ROWS " +
                        $"FETCH NEXT {request.PageSize} ROWS ONLY; ";
                }

                var sqlExcute = sqlCount + sqlForGetData;
                var data = new List<TekmediCardHistoryCardExportViewModel>();
                var totalRecord = 0;
                using (var multi = await connection.QueryMultipleAsync(sqlExcute).ConfigureAwait(false))
                {
                    totalRecord = await multi.ReadSingleAsync<int>();
                    data = multi.Read<TekmediCardHistoryCardExportViewModel>().ToList();
                }

                var response = new PagedResponse<List<TekmediCardHistoryCardExportViewModel>>(data, request.PageNumber, request.PageSize);
                response.TotalRecords = totalRecord;
                response.TotalPages = Convert.ToInt32(Math.Ceiling(totalRecord / (double)request.PageSize));
                return response;
            }
        }

        public async Task<PagedResponse<List<TekmediCardHistoryCardExportViewModel>>> GetCardStatisticsForRechargeOrigin(ExportHistoryCardRequest request, bool isAdmin)
        {
            var dataRecharge = await GetExportHistoryCardAdvancePaymentSheet(request, isAdmin);
            var dataCancel = await GetCancelledAdvancePaymentForExport(request, isAdmin);
            dataRecharge = FilterRechargeOriginDataByCancel(dataRecharge, dataCancel);
            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                dataRecharge = dataRecharge.Where(x => x.RegisteredCode == request.RegisteredCode).ToList();
            }

            var totalRecord = dataRecharge.Count;
            dataRecharge = dataRecharge
                .OrderBy(x => x.EmployeeId)
                .ThenBy(x => x.SerialNo)
                .ThenBy(x => x.RecvNo)
                .ToList();
            dataRecharge.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            var response = new PagedResponse<List<TekmediCardHistoryCardExportViewModel>>(dataRecharge, request.PageNumber, request.PageSize);
            response.TotalRecords = totalRecord;
            response.TotalPages = Convert.ToInt32(Math.Ceiling(totalRecord / (double)request.PageSize));
            return response;
        }

        public async Task<PagedResponse<List<TekmediCardHistoryCardExportViewModel>>> GetCardStatisticsForRefund(ExportHistoryCardRequest request, bool isAdmin)
        {
            var dataRefund = await GetExportHistoryCardRefundSheet(request, isAdmin);
            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                dataRefund = dataRefund.Where(x => x.RegisteredCode == request.RegisteredCode).ToList();
            }

            var totalRecord = dataRefund.Count;
            dataRefund = dataRefund
                .OrderBy(x => x.EmployeeId)
                .ThenBy(x => x.SerialNo)
                .ThenBy(x => x.RecvNo)
                .ToList();
            dataRefund.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            var response = new PagedResponse<List<TekmediCardHistoryCardExportViewModel>>(dataRefund, request.PageNumber, request.PageSize);
            response.TotalRecords = totalRecord;
            response.TotalPages = Convert.ToInt32(Math.Ceiling(totalRecord / (double)request.PageSize));
            return response;
        }

        public async Task<PagedResponse<List<TekmediCardHistoryCardExportViewModel>>> GetCardStatistics(ExportHistoryCardRequest request, bool isAdmin, bool isExport)
        {
            // Nạp tiền gốc
            if (request.TypeCard == 1000)
            {
                return await GetCardStatisticsForRechargeOrigin(request, isAdmin);
            }    

            // Hoàn ứng tái khám
            if (request.TypeCard == 1001)
            {
                return await GetCardStatisticsForRefund(request, isAdmin);
            }

            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));

            using (var connection = new NpgsqlConnection(connectionString))
            {
                var startDate = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
                var endDate = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";

                var sqlCount =
                      $"SELECT count(*) " +
                     "FROM \"IHM\".tekmedi_card_history AS CARD " +
                     "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                     "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                     "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                     "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                     $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}'" +
                        $"AND CARD.\"time\" >= '{startDate}' " +
                        $"AND CARD.\"time\" <= '{endDate}' " +
                        "and chis.id is null ";

                var sqlForGetData = 
                    $"select " +
                        "case when CARD.\"type\" != 2 then " +
                            "concat(s.user_name, '-', substring(cast(DATE_PART('year', card.time::date) as text), 3, 2), '-' ," +
                            "CAST(row_number() over(partition by card.employee_id, card.type order by card.time) as text)) " +
                        "else concat(CARD.serial_no, '-', CARD.recv_no) " +
                        "end as RowNum, " +
                       "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                       "CARD.employee_id AS EmployeeId, " +
                       "CARD.price AS Amount, " +
                       "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                       "P.code AS PatientCode, " +
                       "CARD.\"time\" AS TIME, " +
                       "CARD.\"type\" AS TYPE," +
                       "LVE.description AS PaymentTypeName, " +
                       "LVE.code AS PaymentTypeCode, " +
                       "s.full_name AS EmployeeName, " +
                       "coalesce(CARD.register_code, '0') AS RegisteredCode, " +
                       "'Khoa khám bệnh' AS DepartmentName " +
                    "FROM \"IHM\".tekmedi_card_history AS CARD " +
                    "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                    "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                     "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                    "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                    $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                       $"AND CARD.\"time\" >= '{startDate}' " +
                       $"AND CARD.\"time\" <= '{endDate}' " +
                    "and chis.id is null ";

                if (isExport == false)
                {
                    sqlForGetData += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";
                    sqlCount += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";
                    if (request.TypeCard != (int)TypeEnum.Overview)
                    {
                        if (request.TypeCard == (int)TypeEnum.Recharged)
                        {
                            sqlCount +=
                                   $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                                    $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}') ";
                            sqlForGetData +=
                                   $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                                    $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}') ";
                        }
                        else
                        {
                            sqlCount += $"AND CARD.\"type\" = {request.TypeCard} ";
                            sqlForGetData += $"AND CARD.\"type\" = {request.TypeCard} ";
                        }
                    }
                    else
                    {
                        sqlCount +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";

                        sqlForGetData +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Cancel}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";
                    }

                    if (string.IsNullOrEmpty(request.RegisteredCode) == false)
                    {
                        sqlCount += $"AND CARD.register_code = '{request.RegisteredCode}' ";
                        sqlForGetData += $"AND CARD.register_code = '{request.RegisteredCode}' ";
                    }
                }
                else // type = export
                {
                    sqlCount =
                          $"SELECT count(*) " +
                         "FROM \"IHM\".tekmedi_card_history AS CARD " +
                         "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                         "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                         "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                         "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                         $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}'" +
                            $"AND CARD.\"time\" >= '{startDate}' " +
                            $"AND CARD.\"time\" <= '{endDate}' " +
                    "and chis.id is null ";

                    sqlForGetData =
                           $"select " +
                            "case when CARD.\"type\" != 2 then " +
                                "concat(s.user_name, '-', substring(cast(DATE_PART('year', card.time::date) as text), 3, 2), '-' ," +
                                "CAST(row_number() over(partition by card.employee_id, card.type order by card.time) as text)) " +
                            "else concat(CARD.serial_no, '-', CARD.recv_no) " +
                            "end as RowNum, " +
                           "CARD.tekmedi_card_number AS TekmediCardNumber, " +
                           "CARD.new_tekmedi_card_number AS NewTekmediCardNumber, " +
                           "CARD.employee_id AS EmployeeId, " +
                           "CARD.price AS Amount, " +
                           "CONCAT(P.last_name, ' ', P.first_name) AS PatientName, " +
                           "P.code AS PatientCode, " +
                           "CARD.\"time\" AS TIME, " +
                           "CARD.\"type\" AS TYPE," +
                           "LVE.description AS PaymentTypeName, " +
                           "LVE.code AS PaymentTypeCode, " +
                           "s.full_name AS EmployeeName, " +
                           "coalesce(CARD.register_code, '0') AS RegisteredCode, " +
                           "'Khoa khám bệnh' AS DepartmentName " +
                        "FROM \"IHM\".tekmedi_card_history AS CARD " +
                        "LEFT JOIN \"ListMgmt\".list_value_extend AS LVE ON CARD.payment_type_id = LVE.ID " +
                        "LEFT JOIN \"IHM\".patient AS P ON P.ID = CARD.patient_id " +
                        "left JOIN \"IHM\".tekmedi_card_cancel_history chis on chis.tekmedi_card_history_id = CARD.id " +
                        "LEFT JOIN \"IHM\".sys_user AS s ON s.ID = CARD.employee_id " +
                        $"WHERE CARD.\"status\" = '{(int)StatusEnum.Success}' " +
                           $"AND CARD.\"time\" >= '{startDate}' " +
                           $"AND CARD.\"time\" <= '{endDate}' " +
                    "and chis.id is null ";

                    sqlForGetData += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";
                    sqlCount += " And CARD.id not in (select tcch.tekmedi_card_history_id from \"IHM\".tekmedi_card_cancel_history tcch) ";

                    if (request.TypeCard != (int)TypeEnum.Overview)
                    {
                        sqlCount += $"AND CARD.\"type\" = {request.TypeCard} ";
                        sqlForGetData += $"AND CARD.\"type\" = {request.TypeCard} ";
                    }
                    else
                    {
                        sqlCount +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Lost}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";

                        sqlForGetData +=
                            $"AND (CARD.\"type\" = '{(int)TypeEnum.Recharged}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Register}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.CardFee}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Lost}' " +
                            $"OR CARD.\"type\" = '{(int)TypeEnum.Return}') ";
                    }
                }

                if (!isAdmin)
                {
                    sqlForGetData += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                    sqlCount += $"AND CARD.\"employee_id\" = '{request.EmployeeId}' ";
                }
                sqlCount += "; ";

                sqlForGetData += "ORDER BY CARD.\"time\", RowNum ";
                if (!isExport)
                {
                    sqlForGetData += $" OFFSET (({request.PageNumber} - 1) * {request.PageSize}) ROWS " +
                        $"FETCH NEXT {request.PageSize} ROWS ONLY; ";
                }

                var sqlExcute = sqlCount + sqlForGetData;
                var data = new List<TekmediCardHistoryCardExportViewModel>();
                var totalRecord = 0;
                using (var multi = await connection.QueryMultipleAsync(sqlExcute).ConfigureAwait(false))
                {
                    totalRecord = await multi.ReadSingleAsync<int>();
                    data = multi.Read<TekmediCardHistoryCardExportViewModel>().ToList();
                }

                var response = new PagedResponse<List<TekmediCardHistoryCardExportViewModel>>(data, request.PageNumber, request.PageSize);
                response.TotalRecords = totalRecord;
                response.TotalPages = Convert.ToInt32(Math.Ceiling(totalRecord / (double)request.PageSize));
                return response;
            }
        }

        public async Task<TableResultJsonResponse<StatisticalMonthByPatientViewModel>> StatisticalMonthByPatient(ExportRequest exportRequest)
        {
            var response = new TableResultJsonResponse<StatisticalMonthByPatientViewModel>();
            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
            var pageIndex = exportRequest.Start <= 0 ? 1 : exportRequest.Start;
            var pageSize = exportRequest.Length <= 0 ? 15 : exportRequest.Length;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var startDate = exportRequest.StartDate.ToString("yyyy-MM-dd");
                var endDate = new DateTime(exportRequest.EndDate.Year, exportRequest.EndDate.Month, exportRequest.EndDate.Day, 23, 59, 59).ToString("yyyy-MM-dd HH:mm:ss");

                var sqlForInsertTableTemp =

                "DROP TABLE IF EXISTS temp_initial_increase; " +
                "CREATE TEMP TABLE temp_initial_increase(patient_id uuid, amount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_initial_decrease_return; " +
                "CREATE TEMP TABLE temp_initial_decrease_return(patient_id uuid, amount DECIMAL); " +
                "DROP TABLE IF EXISTS temp_initial_decrease_charged; " +
                "CREATE TEMP TABLE temp_initial_decrease_charged(patient_id uuid, amount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_initial_balance; " +
                "CREATE TEMP TABLE temp_initial_balance(patient_id uuid, amount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_in_month_increase; " +
                "CREATE TEMP TABLE temp_in_month_increase(patient_id uuid, amount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_in_month_decrease_payment; " +
                "CREATE TEMP TABLE temp_in_month_decrease_payment(patient_id uuid, amount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_in_month_decrease_return_card; " +
                "CREATE TEMP TABLE temp_in_month_decrease_return_card(patient_id uuid, amount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_in_month_final_balance; " +
                "CREATE TEMP TABLE temp_in_month_final_balance(patient_id uuid, initial DECIMAL, increase DECIMAL, payment DECIMAL, returnCardAmount DECIMAL, lastAmount DECIMAL); " +

                "DROP TABLE IF EXISTS temp_in_month_final_info; " +
                "CREATE TEMP TABLE temp_in_month_final_info(patient_id uuid, patient_code VARCHAR(50), last_name VARCHAR(250), first_name VARCHAR(250), initial DECIMAL, " +
                "increase DECIMAL, payment DECIMAL, returnCardAmount DECIMAL, lastAmount DECIMAL); " +


                "INSERT INTO temp_initial_increase " +
                "SELECT h.patient_id, sum(h.price) as amount " +
                "FROM \"IHM\".tekmedi_card_history h " +
                $"WHERE status = 1 AND time::date < '{startDate}' AND type = '2' AND h.id NOT IN (SELECT hc.tekmedi_card_history_id FROM \"IHM\".tekmedi_card_cancel_history as hc where status = 1 and type = '12' ) " +
                 "GROUP BY 1; " +

                "INSERT INTO temp_initial_decrease_return " +
                "SELECT h.patient_id, sum(h.price) as amount " +
                "FROM  \"IHM\".tekmedi_card_history h " +
                $"WHERE status = 1 AND time::date < '{startDate}' AND(type = '3') " +
                " AND h.id NOT IN(SELECT hc.tekmedi_card_history_id FROM \"IHM\".tekmedi_card_cancel_history as hc where status = 1 and type = '12') GROUP BY 1; " +

                "INSERT INTO temp_initial_decrease_charged " +
               "SELECT ti.patient_id, sum(ti.amount) as amount " +
               "FROM \"IHM\".transaction_info ti " +
               $"where ti.type = 1 and status = 0 and(state is null or state = 'finished') and ti.created_date::date < '{startDate}' " +
               "GROUP BY 1; " +


                "INSERT INTO temp_initial_balance " +
                "SELECT dp.id, COALESCE(i.amount, 0) - COALESCE(d.amount, 0) - COALESCE(c.amount, 0) as amount " +
                "FROM \"IHM\".patient dp " +
                "LEFT JOIN temp_initial_increase i ON dp.id = i.patient_id " +
                "LEFT JOIN temp_initial_decrease_return d ON dp.id = d.patient_id " +
                "left join temp_initial_decrease_charged c on dp.id = c.patient_id; " +

                "UPDATE temp_initial_balance " +
                "SET amount = 0 " +
                "WHERE amount< 0; " +

                "INSERT INTO temp_initial_balance " +
                 "SELECT DISTINCT ON(h.patient_id) patient_id, 0 as amount " +
                 "FROM \"IHM\".tekmedi_card_history h " +
                 $"WHERE status = 1 AND time::date >= '{startDate}' AND time::date <= '{endDate}' AND (type = '2' or type = '3') AND h.id NOT IN (SELECT hc.tekmedi_card_history_id FROM \"IHM\".tekmedi_card_cancel_history as hc where status = 1 and type = '12' )" +
                 "AND NOT EXISTS(SELECT 1 FROM temp_initial_balance) " +
                 "GROUP BY 1; " +

                "INSERT INTO temp_in_month_increase " +
                "SELECT h.patient_id, sum(h.price) as amount " +
                "FROM \"IHM\".tekmedi_card_history h " +
                $"WHERE status = 1 AND time::date >= '{startDate}' AND time::date <= '{endDate}' AND type = '2' AND h.id NOT IN (SELECT hc.tekmedi_card_history_id FROM \"IHM\".tekmedi_card_cancel_history as hc where status = 1 and type = '12' )" +
                "GROUP BY 1; " +


                "INSERT INTO temp_in_month_decrease_payment " +
                "SELECT ti.patient_id, sum(ti.amount) as amount " +
                "FROM \"IHM\".transaction_info ti " +
                $"where ti.type = 1 and status = 0 and(state is null or state = 'finished') AND ti.created_date::date >= '{startDate}' AND ti.created_date::date <= '{endDate}' " +
                "GROUP BY 1; " +

                "INSERT INTO temp_in_month_decrease_return_card " +
                "SELECT h.patient_id, sum(h.price) as amount " +
                 "FROM \"IHM\".tekmedi_card_history h " +
                 $"WHERE status = 1 AND time::date >= '{startDate}' AND time::date <= '{endDate}' AND type = '3' AND h.id NOT IN (SELECT hc.tekmedi_card_history_id FROM \"IHM\".tekmedi_card_cancel_history as hc where status = 1 and type = '12' )" +
                 "GROUP BY 1; " +

                "INSERT INTO temp_in_month_final_balance " +
                "SELECT ib.patient_id, " +
                "COALESCE(ib.amount, 0) AS initial, " +
                "COALESCE(imi.amount, 0) AS increase, " +
                "COALESCE(idp.amount, 0) AS payment, " +
                "COALESCE(idrc.amount, 0) AS returnCardAmount, " +
                "COALESCE(ib.amount, 0) + COALESCE(imi.amount, 0) - COALESCE(idp.amount, 0) - COALESCE(idrc.amount, 0) AS lastAmount " +
                 "FROM temp_initial_balance ib " +
                 "LEFT JOIN temp_in_month_increase imi ON ib.patient_id = imi.patient_id " +
                 "LEFT JOIN temp_in_month_decrease_payment idp ON ib.patient_id = idp.patient_id " +
                 "LEFT JOIN temp_in_month_decrease_return_card idrc ON ib.patient_id = idrc.patient_id; " +

                 "DELETE FROM temp_in_month_final_balance WHERE initial = 0 AND increase = 0 AND payment = 0 AND returnCardAmount = 0 AND lastAmount = 0; " +

                "INSERT INTO temp_in_month_final_info " +
                "SELECT b.patient_id, p.code, p.last_name, p.first_name, b.initial, b.increase, b.payment, b.returnCardAmount, b.lastAmount " +
                "FROM temp_in_month_final_balance b " +
                "LEFT JOIN \"IHM\".patient p ON b.patient_id = p.\"id\"; " +

                "UPDATE temp_in_month_final_info " +
                "SET lastAmount = 0, payment = payment + lastAmount " +
                "WHERE lastAmount< 0; ";

                var sqlForCountData = "SELECT COUNT(*) FROM temp_in_month_final_info; ";
                var sqlForGetData =
               "SELECT " +
               "b.patient_id as PatientId," +
               "b.patient_code as PatientCode, " +
               "CONCAT(b.last_name, ' ', b.first_name)  as FullName, " +
               "b.initial as Initial, " +
               "b.increase as Increase, " +
               "b.payment as Payment, " +
               "b.returnCardAmount as ReturnCardAmount, " +
               "b.lastAmount as LastAmount " +
               "FROM temp_in_month_final_info as b; ";


                var sqlDropTableTemp =
                "DROP TABLE IF EXISTS temp_initial_increase; " +
                "DROP TABLE IF EXISTS temp_initial_decrease_return; " +
                "DROP TABLE IF EXISTS temp_initial_decrease_charged; " +
                "DROP TABLE IF EXISTS temp_initial_balance; " +
                "DROP TABLE IF EXISTS temp_in_month_increase; " +
                "DROP TABLE IF EXISTS temp_in_month_decrease_payment; " +
                "DROP TABLE IF EXISTS temp_in_month_decrease_return_card; " +
                "DROP TABLE IF EXISTS temp_in_month_final_balance; " +
                "DROP TABLE IF EXISTS temp_in_month_final_info; ";


                if (exportRequest.Search != null && !string.IsNullOrEmpty(exportRequest.Search.Value))
                {
                    sqlForCountData = sqlForCountData.Replace(
                       ";",
                       $" WHERE 1=1 AND patient_code = '{exportRequest.Search.Value}' OR CONCAT(last_name, ' ',first_name) like '%{exportRequest.Search.Value}%'; ");
                    sqlForGetData = sqlForGetData.Replace(
                       ";",
                       $" WHERE 1=1 AND patient_code = '{exportRequest.Search.Value}' OR CONCAT(last_name, ' ',first_name) like '%{exportRequest.Search.Value}%'; ");
                }

                if (!exportRequest.IsExport)
                {
                    sqlForGetData = sqlForGetData.Replace(
                        ";",
                        $" OFFSET (({pageIndex} - 1) * {pageSize}) ROWS " +
                        $"FETCH NEXT {pageSize} ROWS ONLY; ");
                }


                var sql = sqlForInsertTableTemp + sqlForCountData + sqlForGetData + sqlDropTableTemp;

                var data = new List<StatisticalMonthByPatientViewModel>();
                var totalRecords = 0;

                using (var multi = await connection.QueryMultipleAsync(sql).ConfigureAwait(false))
                {
                    totalRecords = await multi.ReadSingleAsync<int>();
                    data = multi.Read<StatisticalMonthByPatientViewModel>().ToList();
                }
                response.Data = data.ToList();
                response.RecordsTotal = totalRecords;

                return response;
            }
        }

        private StatisticalViewModel ToViewModel(BaseTekmediCardHistory history,
           List<TekmediCardCancelHistory> cancelHistories)
        {
            var statistical = new StatisticalViewModel
            {
                Id = history.Id,
                TekmediCardNumber = history.TekmediCardNumber,
                Time = history.Time,
                Type = history.Type != TypeEnum.Cancel && cancelHistories.Any(i => i.TekmediCardHistoryId == history.Id) ?
                       TypeEnum.Cancel : history.Type,
                NewTekmediCardNumber = history.NewTekmediCardNumber,
                BeforeValue = history.BeforeValue.GetValueOrDefault(),
                AfterValue = history.AfterValue.GetValueOrDefault(),
                PaymentType = history.PaymentType != null ? history.PaymentType.Description : ""
            };

            switch (history.Type)
            {
                case TypeEnum.Register:
                    statistical.Manipulation = ManipulationContent.Register;
                    break;
                case TypeEnum.Recharged:
                    statistical.Manipulation = ManipulationContent.Recharged;

                    if (statistical.Type == TypeEnum.Cancel)
                    {
                        statistical.Manipulation += " (đã hủy)";
                    }
                    break;
                case TypeEnum.Return:
                    statistical.Manipulation = ManipulationContent.Return;
                    break;
                case TypeEnum.Lost:
                    statistical.Manipulation = string.IsNullOrWhiteSpace(history.NewTekmediCardNumber)
                        ? ManipulationContent.Lost
                        : ManipulationContent.LostRenew;
                    break;
                case TypeEnum.Charge:
                    statistical.Manipulation = ManipulationContent.Charge;
                    break;
                case TypeEnum.Refund:
                    statistical.Manipulation = ManipulationContent.Refund;
                    break;
                case TypeEnum.ChargeList:
                    statistical.Manipulation = ManipulationContent.ChargeList;
                    break;
                case TypeEnum.FinallyCharge:
                    statistical.Manipulation = ManipulationContent.FinallyCharge;
                    break;
                case TypeEnum.CardFee:
                    statistical.Manipulation = ManipulationContent.CardFee;
                    break;
                case TypeEnum.Cancel:
                    statistical.Manipulation = ManipulationContent.Cancel;
                    break;
                case TypeEnum.Withdraw:
                    statistical.Manipulation = ManipulationContent.Withdraw;
                    break;
                case TypeEnum.CancelPayment:
                    statistical.Manipulation = ManipulationContent.CancelPayment;
                    break;
                case TypeEnum.ExtraFee:
                    statistical.Manipulation = ManipulationContent.ExtraFee;
                    break;
                default:
                    break;
            }

            statistical.Price = history.Amount.GetValueOrDefault();

            // Get employee info
            var employee = history.Employee;
            if (employee != null)
            {
                statistical.EmployeeId = employee.Id;
                statistical.EmployeeName = employee.FullName;
            }

            // Get info from patient
            var patient = history.Patient;
            if (patient != null)
            {
                statistical.TekmediId = patient.TekmediId;
                statistical.Code = patient.Code;
                statistical.Name = patient.LastName + " " + patient.FirstName;
                statistical.Gender = patient.Gender == Gender.Male ? "Nam" : "Nữ";
                statistical.Birthday = patient.Birthday;
                statistical.IdentityCardNumber = patient.IdentityCardNumber;
                statistical.Phone = patient.Phone;
                statistical.IsActivedCard = patient.TekmediCardNumber == history.TekmediCardNumber;
                statistical.BirthdayYearOnly = patient.BirthdayYearOnly;
            }

            return statistical;
        }

        public List<TekmediCardHistory> GetByTransactionNumberConfig(
            string serialNo, 
            string bookNo, 
            int recvNo,
            Guid employeeId)
        {
            var histories = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                .Where(x => x.SerialNo == serialNo
                    && x.BookNo == bookNo
                    && x.RecvNo == recvNo
                    && x.Type == TypeEnum.Recharged
                    && x.Status == StatusEnum.Success
                    && x.EmployeeId == employeeId)
                .ToList();
            return histories;
        }

        public List<TekmediCardCancelHistory> GetListCancelByHistoryIds(List<Guid> historyIds)
        {
            var histories = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                .Where(x => historyIds.Contains(x.TekmediCardHistoryId))
                .ToList();
            return histories;
        }

        public List<TekmediCardHistoryCardExportViewModel> FilterRechargeOriginDataByCancel(
            List<TekmediCardHistoryCardExportViewModel> dataRecharge,
            List<TekmediCardHistoryCardExportViewModel> dataCancel)
        {
            var listCancelAfterCheck = new List<TekmediCardHistoryCardExportViewModel>();
            foreach (var data in dataCancel)
            {
                // 1 số biên lai có thể hủy nhiều lần, nếu đã check rồi thì bỏ qua
                var isChecked = listCancelAfterCheck
                    .Any(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId);
                if (isChecked)
                {
                    continue;
                }

                var cancels = dataCancel
                    .Where(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId)
                    .ToList();

                var recharges = dataRecharge
                    .Where(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId)
                    .OrderByDescending(x => x.Time)
                    .ToList();

                // Xóa hết record nạp tiền mà có hủy
                dataRecharge.RemoveAll(x => x.SerialNo == data.SerialNo
                    && x.RecvNo == data.RecvNo
                    && x.EmployeeId == data.EmployeeId);

                // Đã bù số biên lai, thêm lại record mới nhất vào list nạp
                if (recharges.Count > cancels.Count)
                {
                    var latestRecharge = recharges.FirstOrDefault();
                    if (latestRecharge != null)
                    {
                        dataRecharge.Add(latestRecharge);
                    }
                }
                // Chưa bù số biên lai, thêm lại record mới nhất vào list nạp, gán lại tiền về 0
                else
                {
                    var latestRecharge = recharges.FirstOrDefault();
                    latestRecharge.Amount = 0;
                    if (latestRecharge != null)
                    {
                        dataRecharge.Add(latestRecharge);
                    }
                }

                listCancelAfterCheck.Add(data);
            }

            return dataRecharge;
        }

        public List<TekmediCardHistoryCardExportViewModel> FilterRechargeDataByCancel(
            List<TekmediCardHistoryCardExportViewModel> dataRecharge,
            List<TekmediCardHistoryCardExportViewModel> dataCancel)
        {
            var listCancelAfterCheck = new List<TekmediCardHistoryCardExportViewModel>();
            foreach (var data in dataCancel)
            {
                // 1 số biên lai có thể hủy nhiều lần, nếu đã check rồi thì bỏ qua
                var isChecked = listCancelAfterCheck
                    .Any(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId);
                if (isChecked)
                {
                    continue;
                }

                var cancels = dataCancel
                    .Where(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId)
                    .ToList();

                var recharges = dataRecharge
                    .Where(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId)
                    .OrderByDescending(x => x.Time)
                    .ToList();

                // Xóa hết record nạp tiền mà có hủy
                dataRecharge.RemoveAll(x => x.SerialNo == data.SerialNo
                    && x.RecvNo == data.RecvNo
                    && x.EmployeeId == data.EmployeeId);

                // Đã bù số biên lai, thêm lại record mới nhất vào list nạp
                if (recharges.Count > cancels.Count)
                {
                    var latestRecharge = recharges.FirstOrDefault();
                    if (latestRecharge != null)
                    {
                        dataRecharge.Add(latestRecharge);
                    }
                }

                listCancelAfterCheck.Add(data);
            }

            return dataRecharge;
        }

        public List<TekmediCardHistoryCardExportViewModel> FilterCancelData(
            List<TekmediCardHistoryCardExportViewModel> dataRecharge,
            List<TekmediCardHistoryCardExportViewModel> dataCancel)
        {
            var listCancelAfterCheck = new List<TekmediCardHistoryCardExportViewModel>();
            var result = new List<TekmediCardHistoryCardExportViewModel>();
            foreach (var data in dataCancel)
            {
                // 1 số biên lai có thể hủy nhiều lần, nếu đã check rồi thì bỏ qua
                var isChecked = listCancelAfterCheck
                    .Any(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId);
                if (isChecked)
                {
                    continue;
                }

                var cancels = dataCancel
                    .Where(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId)
                    .OrderByDescending(x => x.Time)
                    .ToList();

                // List nạp đã đc lọc ở bước trước đó, nếu số biên lai này xuất hiện trong list nạp tức là đã bù
                var isFillCancelNumber = dataRecharge.Any(x => x.SerialNo == data.SerialNo
                        && x.RecvNo == data.RecvNo
                        && x.EmployeeId == data.EmployeeId);

                // Chưa bù số
                if (isFillCancelNumber == false)
                {
                    var latestCancel = cancels.FirstOrDefault();
                    if (latestCancel != null)
                    {
                        result.Add(latestCancel);
                    }
                }

                listCancelAfterCheck.Add(data);
            }

            return result;
        }

        public ExportBalanceExcelSheetData GetExportBalanceExcelSheetData(ExportBalanceExcelRequest request)
        {
            var response = new ExportBalanceExcelSheetData();
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var startDateStr = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
            var endDateStr = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
            DateTime.TryParseExact(startDateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            DateTime.TryParseExact(endDateStr, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            var receptions = new List<Reception>();
            // Sau tất toán
            if (request.Status == ExportBalanceExcelStatus.Payment)
            {
                receptions = _unitOfWork.GetRepository<Reception>().GetAll()
                    .Include(x => x.Patient)
                    .ThenInclude(x => x.TekmediCard)
                    .AsNoTracking()
                    .Where(x => x.Status == ReceptionStatus.Success
                        && x.Type == ReceptionType.Paid
                        && x.IsFinished == true
                        && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                    .ToList();
            }
            // Chưa tất toán
            else if (request.Status == ExportBalanceExcelStatus.NotPayment)
            {
                receptions = _unitOfWork.GetRepository<Reception>().GetAll()
                    .Include(x => x.Patient)
                    .ThenInclude(x => x.TekmediCard)
                    .AsNoTracking()
                    .Where(x => x.Status == ReceptionStatus.Success
                        && (x.Type == ReceptionType.Hold || x.Type == ReceptionType.New)
                        && x.IsFinished == false
                        && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                    .ToList();
            }
            // Tất cả
            else
            {
                receptions = _unitOfWork.GetRepository<Reception>().GetAll()
                    .Include(x => x.Patient)
                    .ThenInclude(x => x.TekmediCard)
                    .AsNoTracking()
                    .Where(x => x.Status == ReceptionStatus.Success
                        && x.Type != ReceptionType.Cancelled
                        && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                    .ToList();
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                receptions = receptions.Where(x => x.RegisteredCode == request.RegisteredCode).ToList();
            }

            if (string.IsNullOrEmpty(request.PatientCode) == false)
            {
                receptions = receptions.Where(x => x.PatientCode == request.PatientCode).ToList();
            }

            if (string.IsNullOrEmpty(request.PatientName) == false)
            {
                var nameList = new List<string>();
                nameList.Add(request.PatientName.ToLower().Trim());
                receptions = receptions
                    .Where(x => nameList.Contains($"{x.Patient.LastName.ToLower()} {x.Patient.FirstName.ToLower()}"))
                    .ToList();
            }

            var listRegisteredCode = receptions.Select(x => x.RegisteredCode).ToList();
            var listHistory = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Where(x => listRegisteredCode.Contains(x.RegisterCode)
                    && x.Status == StatusEnum.Success)
                .ToList();

            var listCancel = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Where(x => listRegisteredCode.Contains(x.RegisterCode)
                    && x.Status == StatusEnum.Success)
                .ToList();

            var cancelIds = listCancel.Select(x => x.TekmediCardHistoryId).ToList();
            listHistory = listHistory.Where(x => cancelIds.Contains(x.Id) == false).ToList();

            foreach (var reception in receptions)
            {
                // Trả thẻ rồi thì không hiện trong báo cáo
                var returnHistory = listHistory
                    .Where(x => x.Type == TypeEnum.Return
                        && x.RegisterCode == reception.RegisteredCode)
                    .FirstOrDefault();
                if (returnHistory != null)
                {
                    continue;
                }

                var tekmediCard = reception.Patient.TekmediCard;
                if (tekmediCard == null)
                {
                    continue;
                }

                var res = new ExportBalanceExcelDataDto();
                res.BillNumber = "";
                res.RegisteredCode = reception.RegisteredCode;
                res.PatientName = $"{reception.Patient.LastName} {reception.Patient.FirstName}";
                res.DepartmentName = "Khoa khám bệnh";
                res.Gender = reception.Patient.Gender == Gender.Male ? "Nam" : "Nữ";
                res.Birthday = reception.Patient.Birthday;
                res.AmountBeforePayment = 0;
                res.AmountAfterPayment = 0;
                res.CreatedDate = reception.CreatedDate;
                res.TekmediCardNumber = tekmediCard.TekmediCardNumber;
                res.PatientCode = reception.Patient.Code;

                TekmediCardHistory history = null;
                if (reception.Status == ReceptionStatus.Success
                    && reception.Type == ReceptionType.Paid
                    && reception.IsFinished == true)
                {
                    history = listHistory
                        .Where(x => x.Type == TypeEnum.FinallyCharge
                            && x.RegisterCode == reception.RegisteredCode)
                        .OrderByDescending(x => x.Time)
                        .FirstOrDefault();

                    res.AmountAfterPayment = tekmediCard.Balance;
                }
                else
                {
                    var rechargedHistory = listHistory
                        .Where(x => x.Type == TypeEnum.Recharged
                            && x.RegisterCode == reception.RegisteredCode)
                        .OrderByDescending(x => x.Time)
                        .ToList();

                    history = rechargedHistory.FirstOrDefault();
                    res.AmountBeforePayment = rechargedHistory.Sum(x => x.Amount).Value;
                }

                if (history != null)
                {
                    res.BillNumber = $"{history.SerialNo}-{history.RecvNo}";
                    res.SerialNo = history.SerialNo;
                    res.RecvNo = history.RecvNo.Value;
                }

                response.Data.Add(res);
            }

            return response;
        }

        public ExportBalanceWebResponse GetExportBalanceWebData(ExportBalanceWebRequest request)
        {
            var response = new ExportBalanceWebResponse();
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var startDateStr = $"{request.StartDate.ToString("yyyy-MM-dd")} {request.StartTime}:00";
            var endDateStr = $"{request.EndDate.ToString("yyyy-MM-dd")} {request.EndTime}:59.999";
            DateTime.TryParseExact(startDateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            DateTime.TryParseExact(endDateStr, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            var receptions = new List<Reception>();
            // Sau tất toán
            if (request.Status == ExportBalanceExcelStatus.Payment)
            {
                receptions = _unitOfWork.GetRepository<Reception>().GetAll()
                    .Include(x => x.Patient)
                    .ThenInclude(x => x.TekmediCard)
                    .AsNoTracking()
                    .Where(x => x.Status == ReceptionStatus.Success
                        && x.Type == ReceptionType.Paid
                        && x.IsFinished == true
                        && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                    .ToList();
            }
            // Chưa tất toán
            else if (request.Status == ExportBalanceExcelStatus.NotPayment)
            {
                receptions = _unitOfWork.GetRepository<Reception>().GetAll()
                    .Include(x => x.Patient)
                    .ThenInclude(x => x.TekmediCard)
                    .AsNoTracking()
                    .Where(x => x.Status == ReceptionStatus.Success
                        && (x.Type == ReceptionType.Hold || x.Type == ReceptionType.New)
                        && x.IsFinished == false
                        && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                    .ToList();
            }
            // Tất cả
            else
            {
                receptions = _unitOfWork.GetRepository<Reception>().GetAll()
                    .Include(x => x.Patient)
                    .ThenInclude(x => x.TekmediCard)
                    .AsNoTracking()
                    .Where(x => x.Status == ReceptionStatus.Success
                        && x.Type != ReceptionType.Cancelled
                        && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                    .ToList();
            }

            if (string.IsNullOrEmpty(request.RegisteredCode) == false)
            {
                receptions = receptions.Where(x => x.RegisteredCode == request.RegisteredCode).ToList();
            }

            if (string.IsNullOrEmpty(request.PatientCode) == false)
            {
                receptions = receptions.Where(x => x.PatientCode == request.PatientCode).ToList();
            }

            if (string.IsNullOrEmpty(request.PatientName) == false)
            {
                var nameList = new List<string>();
                nameList.Add(request.PatientName.ToLower().Trim());
                receptions = receptions
                    .Where(x => nameList.Contains($"{x.Patient.LastName.ToLower()} {x.Patient.FirstName.ToLower()}"))
                    .ToList();
            }

            var listRegisteredCode = receptions.Select(x => x.RegisteredCode).ToList();
            var listHistory = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().AsNoTracking()
                .Where(x => listRegisteredCode.Contains(x.RegisterCode)
                    && x.Status == StatusEnum.Success)
                .ToList();

            var listCancel = _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().AsNoTracking()
                .Where(x => listRegisteredCode.Contains(x.RegisterCode)
                    && x.Status == StatusEnum.Success)
                .ToList();

            var cancelIds = listCancel.Select(x => x.TekmediCardHistoryId).ToList();
            listHistory = listHistory.Where(x => cancelIds.Contains(x.Id) == false).ToList();

            foreach (var reception in receptions)
            {
                // Trả thẻ rồi thì không hiện trong báo cáo
                var returnHistory = listHistory
                    .Where(x => x.Type == TypeEnum.Return
                        && x.RegisterCode == reception.RegisteredCode)
                    .FirstOrDefault();
                if (returnHistory != null)
                {
                    continue;
                }

                var tekmediCard = reception.Patient.TekmediCard;
                if (tekmediCard == null)
                {
                    continue;
                }

                var res = new ExportBalanceExcelDataDto();
                res.BillNumber = "";
                res.RegisteredCode = reception.RegisteredCode;
                res.PatientName = $"{reception.Patient.LastName} {reception.Patient.FirstName}";
                res.DepartmentName = "Khoa khám bệnh";
                res.Gender = reception.Patient.Gender == Gender.Male ? "Nam" : "Nữ";
                res.Birthday = reception.Patient.Birthday;
                res.AmountBeforePayment = 0;
                res.AmountAfterPayment = 0;
                res.CreatedDate = reception.CreatedDate;
                res.TekmediCardNumber = tekmediCard.TekmediCardNumber;
                res.PatientCode = reception.Patient.Code;

                TekmediCardHistory history = null;
                if (reception.Status == ReceptionStatus.Success
                    && reception.Type == ReceptionType.Paid
                    && reception.IsFinished == true)
                {
                    history = listHistory
                        .Where(x => x.Type == TypeEnum.FinallyCharge
                            && x.RegisterCode == reception.RegisteredCode)
                        .OrderByDescending(x => x.Time)
                        .FirstOrDefault();

                    res.AmountAfterPayment = tekmediCard.Balance;
                }
                else
                {
                    var rechargedHistory = listHistory
                        .Where(x => x.Type == TypeEnum.Recharged
                            && x.RegisterCode == reception.RegisteredCode)
                        .OrderByDescending(x => x.Time)
                        .ToList();

                    history = rechargedHistory.FirstOrDefault();
                    res.AmountBeforePayment = rechargedHistory.Sum(x => x.Amount).Value;
                }

                if (history != null)
                {
                    res.BillNumber = $"{history.SerialNo}-{history.RecvNo}";
                    res.SerialNo = history.SerialNo;
                    res.RecvNo = history.RecvNo.Value;
                }

                response.Data.Add(res);
            }

            response.TotalRecord = response.Data.Count;
            response.Data = response.Data
                .OrderBy(x => x.CreatedDate.Date)
                .ThenBy(x => x.SerialNo)
                .ThenBy(x => x.RecvNo)
                .Skip(request.Start).Take(request.Length)
                .ToList();

            return response;
        }

        #endregion

        #region Private Funcs
        private StatisticalViewModel ToViewModel(BaseTekmediCardHistory history,
           List<TekmediCardCancelHistory> cancelHistories,
           Province province, District district, Ward ward)
        {
            var statistical = new StatisticalViewModel
            {
                Id = history.Id,
                TekmediCardNumber = history.TekmediCardNumber,
                Time = history.Time,
                Type = history.Type != TypeEnum.Cancel && cancelHistories.Any(i => i.TekmediCardHistoryId == history.Id) ?
                        TypeEnum.Cancel : history.Type,
                NewTekmediCardNumber = history.NewTekmediCardNumber,
                BeforeValue = history.BeforeValue.GetValueOrDefault(),
                AfterValue = history.AfterValue.GetValueOrDefault(),
                PaymentType = history.PaymentType != null ? history.PaymentType.Description : "",
                RegisteredCode = history.RegisterCode != null ? history.RegisterCode : ""
            };

            switch (history.Type)
            {
                case TypeEnum.Register:
                    statistical.Manipulation = ManipulationContent.Register;
                    break;
                case TypeEnum.Recharged:
                    statistical.Manipulation = ManipulationContent.Recharged;

                    if (statistical.Type == TypeEnum.Cancel)
                    {
                        statistical.Manipulation += " (đã hủy)";
                    }
                    break;
                case TypeEnum.Return:
                    statistical.Manipulation = ManipulationContent.Return;
                    break;
                case TypeEnum.Lost:
                    statistical.Manipulation = string.IsNullOrWhiteSpace(history.NewTekmediCardNumber)
                        ? ManipulationContent.Lost
                        : ManipulationContent.LostRenew;
                    break;
                case TypeEnum.Charge:
                    statistical.Manipulation = ManipulationContent.Charge;
                    break;
                case TypeEnum.Refund:
                    statistical.Manipulation = ManipulationContent.Refund;
                    break;
                case TypeEnum.ChargeList:
                    statistical.Manipulation = ManipulationContent.ChargeList;
                    break;
                case TypeEnum.FinallyCharge:
                    statistical.Manipulation = ManipulationContent.FinallyCharge;
                    break;
                case TypeEnum.CardFee:
                    statistical.Manipulation = ManipulationContent.CardFee;
                    break;
                case TypeEnum.Cancel:
                    statistical.Manipulation = ManipulationContent.Cancel;
                    break;
                case TypeEnum.Withdraw:
                    statistical.Manipulation = ManipulationContent.Withdraw;
                    break;
                case TypeEnum.CancelPayment:
                    statistical.Manipulation = ManipulationContent.CancelPayment;
                    break;
                case TypeEnum.ExtraFee:
                    statistical.Manipulation = ManipulationContent.ExtraFee;
                    break;
                default:
                    break;
            }

            statistical.Price = history.Amount.GetValueOrDefault();

            // Get employee info
            var employee = history.Employee;
            if (employee != null)
            {
                statistical.EmployeeId = employee.Id;
                statistical.EmployeeName = employee.FullName;
            }

            // Get info from patient
            var patient = history.Patient;
            if (patient != null)
            {
                statistical.TekmediId = patient.TekmediId;
                statistical.Code = patient.Code;
                statistical.Name = patient.LastName + " " + patient.FirstName;
                statistical.Gender = patient.Gender == Gender.Male ? "Nam" : "Nữ";
                statistical.Birthday = patient.Birthday;
                statistical.IdentityCardNumber = patient.IdentityCardNumber;
                statistical.Phone = patient.Phone;
                statistical.IsActivedCard = patient.TekmediCardNumber == history.TekmediCardNumber;
                statistical.BirthdayYearOnly = patient.BirthdayYearOnly;
                // Get location
                statistical.Province = province?.Name;
                statistical.District = district?.Name;
                statistical.Ward = ward?.Name;
            }

            return statistical;
        }

        private StatisticalIncludeUserName ToViewModelBilling(BaseTekmediCardHistory history,
          List<TekmediCardCancelHistory> cancelHistories,
          Province province, District district, Ward ward)
        {
            var statistical = new StatisticalIncludeUserName
            {
                Id = history.Id,
                TekmediCardNumber = history.TekmediCardNumber,
                Time = history.Time,
                Type = history.Type != TypeEnum.Cancel && cancelHistories.Any(i => i.TekmediCardHistoryId == history.Id) ?
                        TypeEnum.Cancel : history.Type,
                NewTekmediCardNumber = history.NewTekmediCardNumber,
                BeforeValue = history.BeforeValue.GetValueOrDefault(),
                AfterValue = history.AfterValue.GetValueOrDefault(),
                PaymentType = history.PaymentType != null ? history.PaymentType.Description : "",
                RegisteredCode = history.RegisterCode,
                SerialNo = history.SerialNo,
                RecvNo = history.RecvNo
            };

            switch (history.Type)
            {
                case TypeEnum.Register:
                    statistical.Manipulation = ManipulationContent.Register;
                    break;
                case TypeEnum.Recharged:
                    statistical.Manipulation = ManipulationContent.Recharged;

                    if (statistical.Type == TypeEnum.Cancel)
                    {
                        statistical.Manipulation += " (đã hủy)";
                    }
                    break;
                case TypeEnum.Return:
                    statistical.Manipulation = ManipulationContent.Return;
                    break;
                case TypeEnum.Lost:
                    statistical.Manipulation = string.IsNullOrWhiteSpace(history.NewTekmediCardNumber)
                        ? ManipulationContent.Lost
                        : ManipulationContent.LostRenew;
                    break;
                case TypeEnum.Charge:
                    statistical.Manipulation = ManipulationContent.Charge;
                    break;
                case TypeEnum.Refund:
                    statistical.Manipulation = ManipulationContent.Refund;
                    break;
                case TypeEnum.ChargeList:
                    statistical.Manipulation = ManipulationContent.ChargeList;
                    break;
                case TypeEnum.FinallyCharge:
                    statistical.Manipulation = ManipulationContent.FinallyCharge;
                    break;
                case TypeEnum.CardFee:
                    statistical.Manipulation = ManipulationContent.CardFee;
                    break;
                case TypeEnum.Cancel:
                    statistical.Manipulation = ManipulationContent.Cancel;
                    break;
                case TypeEnum.Withdraw:
                    statistical.Manipulation = ManipulationContent.Withdraw;
                    break;
                case TypeEnum.ExtraFee:
                    statistical.Manipulation = ManipulationContent.ExtraFee;
                    break;
                default:
                    break;
            }

            statistical.Price = history.Amount.GetValueOrDefault();

            // Get employee info
            var employee = history.Employee;
            if (employee != null)
            {
                statistical.EmployeeId = employee.Id;
                statistical.EmployeeName = employee.FullName;
                statistical.UserName = employee.UserName;
            }

            // Get info from patient
            var patient = history.Patient;
            if (patient != null)
            {
                statistical.TekmediId = patient.TekmediId;
                statistical.Code = patient.Code;
                statistical.Name = patient.LastName + " " + patient.FirstName;
                statistical.Gender = patient.Gender == Gender.Male ? "Nam" : "Nữ";
                statistical.Birthday = patient.Birthday;
                statistical.IdentityCardNumber = patient.IdentityCardNumber;
                statistical.Phone = patient.Phone;
                statistical.IsActivedCard = patient.TekmediCardNumber == history.TekmediCardNumber;
                statistical.BirthdayYearOnly = patient.BirthdayYearOnly;
                // Get location
                statistical.Province = province?.Name;
                statistical.District = district?.Name;
                statistical.Ward = ward?.Name;
            }

            return statistical;
        }


        private IQueryable<StatisticalViewModel> ApplyOrderBy(IQueryable<StatisticalViewModel> query, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                property = property.Trim().ToUpper();
            }

            if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.Code).ThenBy(x => x.Time);
            else if (property == $"{SortCondition.PATIENT_CODE}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.Code).ThenBy(x => x.Time);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.Name).ThenBy(x => x.Time);
            else if (property == $"{SortCondition.NAME}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.Name).ThenBy(x => x.Time);
            else if (property == $"{SortCondition.TEKMEDICARD}{SortCondition.ORDER_BY_ESC}")
                return query.OrderBy(p => p.TekmediCardNumber).ThenBy(x => x.Time);
            else if (property == $"{SortCondition.TEKMEDICARD}{SortCondition.ORDER_BY_DESC}")
                return query.OrderByDescending(p => p.TekmediCardNumber).ThenBy(x => x.Time);
            else
                return query.OrderBy(p => p.TekmediCardNumber).ThenBy(x => x.Time);
        }

        #endregion
    }
}
