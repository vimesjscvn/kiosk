using AutoMapper;
using CS.Common.Common;
using CS.Common.Enums;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Payment.Domain.Services
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
        /// Initializes a new instance of the <see cref="TekmediCardHistoryService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public TekmediCardHistoryService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
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

            IQueryable<BaseTekmediCardHistory> histories = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(
                t => t.EmployeeId == request.EmployeeId && t.Time >= request.StartDate && t.Time <= request.EndDate &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient);
            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(
                t => t.EmployeeId == request.EmployeeId && t.Time >= request.StartDate && t.Time <= request.EndDate &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient).ToListAsync();
            histories.Concat(cancelHistories);

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
            result.Data = statisticals.OrderBy(t => t.TekmediCardNumber).ThenBy(t => t.Time).ToList();

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
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;ICollection&lt;StatisticalViewModel&gt;&gt;.</returns>
        public async Task<TableResultJsonResponse<StatisticalViewModel>> GetHistory(HistoryCardRequest request)
        {
            var result = new TableResultJsonResponse<StatisticalViewModel>();
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();

            var predicateHistory = PredicateBuilder.Create<TekmediCardHistory>(t => t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw);
            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.ToLower().Contains(request.PatientCode.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(request.PatientName))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null && t.Patient.FirstName != null && t.Patient.FirstName.ToLower().Contains(request.PatientName.Trim().ToLower()));
            }

            var predicateCancelHistory = PredicateBuilder.Create<TekmediCardCancelHistory>(t => t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw);
            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.ToLower().Contains(request.PatientCode.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(request.PatientName))
            {
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null && t.Patient.FirstName != null && t.Patient.FirstName.ToLower().Contains(request.PatientName.Trim().ToLower()));
            }

            IQueryable<BaseTekmediCardHistory> histories = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(predicateHistory)
                .Include(h => h.Employee).Include(h => h.Patient);
            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(predicateCancelHistory)
                .Include(h => h.Employee).Include(h => h.Patient).ToListAsync();
            histories.Concat(cancelHistories);

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
            result.Data = statisticals.OrderBy(t => t.TekmediCardNumber).ThenBy(t => t.Time).ToList();

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

            IQueryable<BaseTekmediCardHistory> histories = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(t => t.Time >= request.StartDate && t.Time <= request.EndDate &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient);
            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(t => t.Time >= request.StartDate && t.Time <= request.EndDate &&
                (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient).ToListAsync();
            histories.Concat(cancelHistories);

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
            result.Data = statisticals.OrderBy(t => t.TekmediCardNumber).ThenBy(t => t.Time).ToList();

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

            var histories = new List<BaseTekmediCardHistory>();

            histories.AddRange(await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                //.FromSqlRaw(@"SELECT * FROM ""IHM"".tekmedi_card_history")
                .Where(t => t.EmployeeId == request.EmployeeId && t.Time >= request.StartDate && t.Time <= request.EndDate &&
                    (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                    t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient)
                .ToListAsync());
            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                //.FromSqlRaw(@"SELECT * FROM ""IHM"".tekmedi_card_cancel_history")
                .Where(t => t.EmployeeId == request.EmployeeId && t.Time >= request.StartDate && t.Time <= request.EndDate &&
                    (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                    t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient)
                .ToListAsync();
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

            var histories = new List<BaseTekmediCardHistory>();
            histories.AddRange(await _unitOfWork.GetRepository<TekmediCardHistory>().GetAll()
                //.FromSqlRaw(@"SELECT * FROM ""IHM"".tekmedi_card_history")
                .Where(t => t.Time >= request.StartDate && t.Time <= request.EndDate &&
                    (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                    t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient)
                .ToListAsync());

            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll()
                //.FromSqlRaw(@"SELECT * FROM ""IHM"".tekmedi_card_cancel_history")
                .Where(t => t.Time >= request.StartDate && t.Time <= request.EndDate &&
                    (t.Type == TypeEnum.Register || t.Type == TypeEnum.Recharged || t.Type == TypeEnum.Return ||
                    t.Type == TypeEnum.Lost || t.Type == TypeEnum.CardFee || t.Type == TypeEnum.Cancel || t.Type == TypeEnum.Withdraw))
                .Include(h => h.Employee).Include(h => h.Patient)
                .ToListAsync();

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
        /// Gets the type of the history with.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<StatisticalViewModel>> GetHistoryWithType(HistoryCardWithTypeRequest request)
        {
            var result = new TableResultJsonResponse<StatisticalViewModel>();
            var statisticals = new ConcurrentBag<StatisticalViewModel>();
            var provinces = await _unitOfWork.GetRepository<Province>().GetAll().ToListAsync();
            var districts = await _unitOfWork.GetRepository<District>().GetAll().ToListAsync();
            var wards = await _unitOfWork.GetRepository<Ward>().GetAll().ToListAsync();

            var predicateHistory = PredicateBuilder.Create<TekmediCardHistory>(t => request.Types.Contains(t.Type));
            var predicateCancelHistory = PredicateBuilder.Create<TekmediCardCancelHistory>(t => request.Types.Contains(t.Type));

            if (!string.IsNullOrEmpty(request.PatientCode))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.ToLower().Contains(request.PatientCode.Trim().ToLower()));
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null && t.Patient.Code != null && t.Patient.Code.ToLower().Contains(request.PatientCode.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(request.PatientName))
            {
                predicateHistory = predicateHistory.And(t => t.Patient != null && t.Patient.FirstName != null && t.Patient.FirstName.ToLower().Contains(request.PatientName.Trim().ToLower()));
                predicateCancelHistory = predicateCancelHistory.And(t => t.Patient != null && t.Patient.FirstName != null && t.Patient.FirstName.ToLower().Contains(request.PatientName.Trim().ToLower()));
            }

            IQueryable<BaseTekmediCardHistory> histories = _unitOfWork.GetRepository<TekmediCardHistory>().GetAll().Where(predicateHistory)
                .Include(h => h.Patient);

            var cancelHistories = await _unitOfWork.GetRepository<TekmediCardCancelHistory>().GetAll().Where(predicateCancelHistory)
              .Include(h => h.Patient)
              .ToListAsync();

            histories.Concat(cancelHistories);

            var totalRecord = histories.Count();

            var filteredHistories = histories
              .OrderByDescending(t => t.Time)
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
        #endregion

        #region Private Funcs
        private StatisticalViewModel ToViewModel(BaseTekmediCardHistory history,
           ICollection<TekmediCardCancelHistory> cancelHistories,
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
                PaymentTypeName = history.PaymentType?.Description
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

                // Get location
                statistical.Province = province?.Name;
                statistical.District = district?.Name;
                statistical.Ward = ward?.Name;
            }

            return statistical;
        }
        #endregion
    }
}
