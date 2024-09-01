using CS.Common.Common;
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
using Admin.API.Domain.InternalRepo;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    public class TransactionNumberConfigService : ITransactionNumberConfigService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionNumberConfigRepo _transactionNumberConfigRepo;
        private readonly ISysUserRepo _sysUserRepo;

        public TransactionNumberConfigService(
            IUnitOfWork unitOfWork,
            ITransactionNumberConfigRepo transactionNumberConfigRepo)
        {
            _transactionNumberConfigRepo = transactionNumberConfigRepo;
            _unitOfWork = unitOfWork;
        }

        public TransactionNumberConfigService(
             IUnitOfWork unitOfWork,
             ITransactionNumberConfigRepo transactionNumberConfigRepo,
             ISysUserRepo sysUserRepo)
        {
            _transactionNumberConfigRepo = transactionNumberConfigRepo;
            _unitOfWork = unitOfWork;
            _sysUserRepo = sysUserRepo;
        }

        public async Task<TransactionNumberConfig> AddTransactionNumberConfig(string serialNo, string type, string patientType, string bookNo, int recvNo, Guid userId)
        {
            var user = await _sysUserRepo.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User này không tồn tại để thêm vào cấu hình");
            }

            if (type == TransactionNumberConfig.BookTypeTamUng)
            {
                if (patientType != TransactionNumberConfig.PatientTypeTamUng)
                {
                    throw new Exception($"Khi thêm cấu hình là tạm ứng nên chọn Loại đối tượng là Tạm ứng");
                }

                var otherAdvancePaymentConfigByUserId = await _transactionNumberConfigRepo.GetOthersAdvancePaymentNumberConfigByUserId(Guid.Empty, userId);
                if (otherAdvancePaymentConfigByUserId != null)
                {
                    if (otherAdvancePaymentConfigByUserId.BookNo == bookNo && otherAdvancePaymentConfigByUserId.SerialNo == serialNo)
                    {
                        throw new Exception($"Đã tồn tại cấu hình cho tạm ứng với cùng Số sổ {otherAdvancePaymentConfigByUserId.BookNo} và Số serial {otherAdvancePaymentConfigByUserId.SerialNo}");
                    }
                }
            }

            if (type == TransactionNumberConfig.BookTypeTatToan)
            {
                if (TransactionNumberConfig.PatientTypesForTatToan.Contains(patientType) == false)
                {
                    throw new Exception($"Khi thêm cấu hình là tất toán nên chọn Loại đối tượng là Bảo hiểm hay Dịch vụ");
                }

                var otherPaymentConfigByUserId = await _transactionNumberConfigRepo.GetOtherPaymentNumberConfigByUserId(Guid.Empty, userId);
                if (otherPaymentConfigByUserId != null)
                {
                    if (otherPaymentConfigByUserId.PatientType == patientType && otherPaymentConfigByUserId.BookNo == bookNo && otherPaymentConfigByUserId.SerialNo == serialNo)
                    {
                        throw new Exception($"Đã tồn tại cấu hình cho tất toán với cùng Số sổ {otherPaymentConfigByUserId.BookNo} và Số serial {otherPaymentConfigByUserId.SerialNo} và loại đối tượng {otherPaymentConfigByUserId.PatientType}");
                    }
                }
            }

            if (type == TransactionNumberConfig.BookTypeHoanUng)
            {
                if (patientType != TransactionNumberConfig.PatientTypeHoanUng)
                {
                    throw new Exception($"Khi thêm cấu hình là hoàn ứng nên chọn Loại đối tượng là Hoàn ứng");
                }

                var otherRefundConfigByUserId = await _transactionNumberConfigRepo.GetOtherRefundNumberConfigByUserId(Guid.Empty, userId);
                if (otherRefundConfigByUserId != null)
                {
                    if (otherRefundConfigByUserId.BookNo == bookNo && otherRefundConfigByUserId.SerialNo == serialNo)
                    {
                        throw new Exception($"Đã tồn tại cấu hình cho hoàn ứng với cùng Số sổ {otherRefundConfigByUserId.BookNo} và Số serial {otherRefundConfigByUserId.SerialNo}");
                    }
                }
            }

            var newTransactionNumberConfig = TransactionNumberConfig.NewForAdd(serialNo, bookNo, type, patientType, recvNo, user.Id);
            _transactionNumberConfigRepo.Add(newTransactionNumberConfig);
            await _unitOfWork.CommitAsync();
            return newTransactionNumberConfig;
        }

        public async Task<TableResultJsonResponse<TransactionNumberConfigViewModel>> GetAllAsync(TransactionNumberConfigRequest parameters)
        {
            var data = new ConcurrentBag<TransactionNumberConfigViewModel>();
            var result = new TableResultJsonResponse<TransactionNumberConfigViewModel>();
            var searchValue = parameters.Search.Value.Trim().ToLower();
            var orderValue = "";
            if (parameters.Order != null && parameters.Order.Length > 0)
            {
                orderValue = parameters.Order[0].Dir.Trim().ToLower();
            }
            
            var user = await _sysUserRepo.GetUserById(parameters.UserId);
            if (user == null)
            {
                throw new Exception("Tài khoản không tồn tại");
            }

            var predicate = PredicateBuilder.Create<TransactionNumberConfig>(x => x.UserId == user.Id);
            if (!string.IsNullOrEmpty(searchValue))
            {
                predicate = predicate.And(x => x.SerialNo.ToLower().Contains(searchValue));
            }

            var transactionNumberConfigs = _unitOfWork.GetRepository<TransactionNumberConfig>().GetAll().Where(predicate)
                .OrderBy(x => x.SerialNo);
            var totals = transactionNumberConfigs.Count();
            var filteredNumberConfigs = await transactionNumberConfigs.Skip(parameters.Start).Take(parameters.Length).ToListAsync();

            foreach (var transactionNumberConfig in filteredNumberConfigs)
            {
                var transactionNumberConfigViewModel = new TransactionNumberConfigViewModel();
                transactionNumberConfigViewModel.SerialNo = transactionNumberConfig.SerialNo;
                transactionNumberConfigViewModel.BookNo = transactionNumberConfig.BookNo;
                transactionNumberConfigViewModel.RecvNo = transactionNumberConfig.RecvNo;
                transactionNumberConfigViewModel.Id = transactionNumberConfig.Id;
                transactionNumberConfigViewModel.Type = transactionNumberConfig.Type;
                transactionNumberConfigViewModel.PatientType = transactionNumberConfig.PatientType;
                transactionNumberConfigViewModel.IsActive = transactionNumberConfig.IsActive;
                data.Add(transactionNumberConfigViewModel);
            }

            result.Draw = parameters.Draw;
            result.RecordsTotal = totals;
            result.RecordsFiltered = totals;
            result.Data = data.ToList();
            return result;
        }

        public async Task<TransactionNumberConfig> RemoveTransactionNumberConfig(Guid id)
        {
            var existTransactionNumberConfig = await _transactionNumberConfigRepo.GetById(id);
            if (existTransactionNumberConfig == null)
            {
                throw new Exception("Không tìm thấy cấu hình biên lai.");
            }

            _transactionNumberConfigRepo.Delete(existTransactionNumberConfig);
            await _unitOfWork.CommitAsync();
            return existTransactionNumberConfig;
        }

        public async Task<TransactionNumberConfig> ActiveTransactionNumberConfig(Guid id)
        {
            var existTransactionNumberConfig = await _transactionNumberConfigRepo.GetById(id);
            if (existTransactionNumberConfig == null)
            {
                throw new Exception("Không tìm thấy cấu hình biên lai.");
            }

            if (existTransactionNumberConfig.Type == TransactionNumberConfig.BookTypeTamUng)
            {
                //var otherAdvancePaymentConfig = await _transactionNumberConfigRepo.GetOthersAdvancePaymentNumberConfigByUserId(existTransactionNumberConfig.Id, existTransactionNumberConfig.UserId);
                //if (otherAdvancePaymentConfig != null)
                //{
                //    if (otherAdvancePaymentConfig.IsActive)
                //    {
                //        throw new Exception($"Hiện tại đang có một cấu hình tạm ứng khác đang kích hoạt (Số serial: {otherAdvancePaymentConfig.SerialNo}, Số sổ: {otherAdvancePaymentConfig.BookNo}). " +
                //                                    $"Xin vui lòng bỏ kích hoạt tạm ứng trên trước khi kích hoạt tạm ứng này.");
                //    }
                //}

                var listOtherAdvancePaymentConfig = await _transactionNumberConfigRepo
                    .GetListOthersAdvancePaymentNumberConfigByUserId(existTransactionNumberConfig.Id, existTransactionNumberConfig.UserId);
                var otherAdvancePaymentConfig = listOtherAdvancePaymentConfig.FirstOrDefault(x => x.IsActive);
                if (otherAdvancePaymentConfig != null)
                {
                    throw new Exception($"Hiện tại đang có một cấu hình tạm ứng khác đang kích hoạt (Số serial: {otherAdvancePaymentConfig.SerialNo}, Số sổ: {otherAdvancePaymentConfig.BookNo}). " +
                                        $"Xin vui lòng bỏ kích hoạt tạm ứng trên trước khi kích hoạt tạm ứng này.");
                }
            }

            if (existTransactionNumberConfig.Type == TransactionNumberConfig.BookTypeTatToan)
            {
                //var otherPaymentConfig = await _transactionNumberConfigRepo.GetOtherPaymentNumberConfigByUserId(existTransactionNumberConfig.Id, existTransactionNumberConfig.UserId);
                //if (otherPaymentConfig != null)
                //{
                //    if (otherPaymentConfig.PatientType == existTransactionNumberConfig.PatientType && otherPaymentConfig.IsActive)
                //    {
                //        throw new Exception($"Hiện tại đang có một cấu hình tất toán khác đang kích hoạt (Số serial: {otherPaymentConfig.SerialNo}, " +
                //                            $"Số sổ: {otherPaymentConfig.BookNo}, Loại đối tượng: {otherPaymentConfig.PatientType}). " +
                //                             $"Xin vui lòng bỏ kích hoạt tất toán trên trước khi kích hoạt tất toán này.");
                //    }
                //}

                var listOtherPaymentConfig = await _transactionNumberConfigRepo
                    .GetListOtherPaymentNumberConfigByUserId(existTransactionNumberConfig.Id, existTransactionNumberConfig.UserId);
                var otherPaymentConfig = listOtherPaymentConfig.FirstOrDefault(x => x.PatientType == existTransactionNumberConfig.PatientType && x.IsActive);
                if (otherPaymentConfig != null)
                {
                    throw new Exception($"Hiện tại đang có một cấu hình tất toán khác đang kích hoạt (Số serial: {otherPaymentConfig.SerialNo}, " +
                                        $"Số sổ: {otherPaymentConfig.BookNo}, Loại đối tượng: {otherPaymentConfig.PatientType}). " +
                                        $"Xin vui lòng bỏ kích hoạt tất toán trên trước khi kích hoạt tất toán này.");
                }
            }

            if (existTransactionNumberConfig.Type == TransactionNumberConfig.BookTypeHoanUng)
            {
                var listOtherRefundConfig = await _transactionNumberConfigRepo
                    .GetListOtherRefundNumberConfigByUserId(existTransactionNumberConfig.Id, existTransactionNumberConfig.UserId);
                var otherRefundConfig = listOtherRefundConfig.FirstOrDefault(x => x.IsActive);
                if (otherRefundConfig != null)
                {
                    throw new Exception($"Hiện tại đang có một cấu hình hoàn ứng khác đang kích hoạt (Số serial: {otherRefundConfig.SerialNo}, Số sổ: {otherRefundConfig.BookNo}). " +
                                        $"Xin vui lòng bỏ kích hoạt hoàn ứng trên trước khi kích hoạt hoàn ứng này.");
                }
            }

            existTransactionNumberConfig.Activate();
            _transactionNumberConfigRepo.Update(existTransactionNumberConfig);
            _unitOfWork.Commit();
            return existTransactionNumberConfig;
        }

        public async Task<TransactionNumberConfig> DeactiveTransactionNumberConfig(Guid id)
        {
            var existTransactionNumberConfig = await _transactionNumberConfigRepo.GetById(id);
            if (existTransactionNumberConfig == null)
            {
                throw new Exception("Không tìm thấy cấu hình biên lai.");
            }

            existTransactionNumberConfig.Deactivate();
            _transactionNumberConfigRepo.Update(existTransactionNumberConfig);
            await _unitOfWork.CommitAsync();
            return existTransactionNumberConfig;

        }

        public async Task<TransactionNumberConfig> GetActiveAdvancePaymentConfig(GetActiveAdvancePaymentConfigRequest request)
        {
            var user = await _sysUserRepo.GetUserById(request.UserId);
            if (user == null)
            {
                throw new Exception("Tài khoản không tồn tại");
            }

            var allConfigs = await _transactionNumberConfigRepo.GetByUserId(user.Id);
            var activeAdvancePaymentConfig = allConfigs.FirstOrDefault(x => x.Type == TransactionNumberConfig.BookTypeTamUng && x.IsActive);
            if (activeAdvancePaymentConfig == null)
            {
                throw new Exception(ErrorMessages.NotFoundTransactionNumberConfig);
            }

            return activeAdvancePaymentConfig;
        }

        public ICollection<TransactionNumberConfig> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransactionNumberConfig>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TransactionNumberConfig Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionNumberConfig> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public TransactionNumberConfig Find(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionNumberConfig> FindAsync(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<TransactionNumberConfig> FindAll(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransactionNumberConfig>> FindAllAsync(Expression<Func<TransactionNumberConfig, bool>> match)
        {
            throw new NotImplementedException();
        }

        public TransactionNumberConfig Add(TransactionNumberConfig entity)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionNumberConfig> AddAsync(TransactionNumberConfig entity)
        {
            throw new NotImplementedException();
        }

        public TransactionNumberConfig Update(TransactionNumberConfig updated, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionNumberConfig> UpdateAsync(TransactionNumberConfig updated, Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TransactionNumberConfig entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TransactionNumberConfig entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
