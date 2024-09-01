using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace Admin.API.Domain.Services
{
    public class OcrSettingService : IOcrSettingService
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
        /// Initializes a new instance of the <see cref="OcrSettingService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public OcrSettingService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the specified request.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> AddOrUpdate(Guid id, AddOrUpdateOcrSettingRequest request)
        {
            var ocrSetting = await _unitOfWork.GetRepository<OcrSetting>().FindAsync(x => x.Id == id);

            if (ocrSetting == null)
            {
                var addModel = _mapper.Map<OcrSetting>(request);
                addModel.Value = ConvertSettingRequest(request);
                _unitOfWork.GetRepository<OcrSetting>().Add(addModel);
            }
            else
            {
                ocrSetting.Description = request.Description;
                ocrSetting.Type = request.Type;
                ocrSetting.Value = ConvertSettingRequest(request);
                _unitOfWork.GetRepository<OcrSetting>().Update(ocrSetting);
            }
            return await _unitOfWork.CommitAsync() >= 1;

        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            var ocrSetting = await _unitOfWork.GetRepository<OcrSetting>().FindAsync(x => x.Id == id);
            if (ocrSetting == null) throw new Exception(ErrorMessages.NotFoundSetting);
            _unitOfWork.GetRepository<OcrSetting>().Delete(ocrSetting);
            return await _unitOfWork.CommitAsync() >= 1;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<OcrSettingViewModel> Get()
        {
            var ocrSetting = await _unitOfWork.GetRepository<OcrSetting>().FindAsync(x => x.IsActive);
            if (ocrSetting == null) throw new Exception(ErrorMessages.NotFoundSetting);
            var result = new OcrSettingViewModel
            {
                Id = ocrSetting.Id,
                Description = ocrSetting.Description,
                Type = ocrSetting.Type,
                IsDeleted = ocrSetting.IsDeleted,
                IsActive = ocrSetting.IsActive,
                Value = StringUtils.ConvertStringToObject<OcrSettingValue>(ocrSetting.Value),
                CreatedDate = ocrSetting.CreatedDate
            };
            return result;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<OcrSettingViewModel> GetById(Guid id)
        {
            var ocrSetting = await _unitOfWork.GetRepository<OcrSetting>().FindAsync(x => x.Id == id);
            if (ocrSetting == null) throw new Exception(ErrorMessages.NotFoundSetting);
            var result = new OcrSettingViewModel
            {
                Id = ocrSetting.Id,
                Description = ocrSetting.Description,
                Type = ocrSetting.Type,
                IsDeleted = ocrSetting.IsDeleted,
                IsActive = ocrSetting.IsActive,
                Value = StringUtils.ConvertStringToObject<OcrSettingValue>(ocrSetting.Value),
                CreatedDate = ocrSetting.CreatedDate
            };
            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<TableResultJsonResponse<OcrSettingViewModel>> GetAll(GetOcrSettingRequest request)
        {
            var result = new TableResultJsonResponse<OcrSettingViewModel>();
            List<OcrSettingViewModel> data = new List<OcrSettingViewModel>();

            var predicate = PredicateBuilder.True<OcrSetting>();

            if (!string.IsNullOrEmpty(request.Description))
                predicate = predicate.And(x => x.Description.ToLower().Contains(request.Description.ToLower()));

            if (request.Type.HasValue)
                predicate = predicate.And(x => x.Type == request.Type.Value);

            var ocrSettings = _unitOfWork.GetRepository<OcrSetting>().GetAll().Where(predicate).OrderByDescending(x => x.UpdatedDate);
            var total = await ocrSettings.CountAsync();

            var dataResult = await ocrSettings.Skip(request.Start).Take(request.Length).ToListAsync();

            foreach (var item in dataResult)
            {
                data.Add(new OcrSettingViewModel
                {
                    Id = item.Id,
                    Description = item.Description,
                    Type = item.Type,
                    IsDeleted = item.IsDeleted,
                    IsActive = item.IsActive,
                    Value = StringUtils.ConvertStringToObject<OcrSettingValue>(item.Value),
                    CreatedDate = item.CreatedDate
                });
            }

            result.Draw = request.Draw;
            result.RecordsTotal = total;
            result.RecordsFiltered = total;
            result.Data = data;

            return result;
        }

        public async Task<List<OcrSettingViewModel>> Export(ExportOcrSettingRequest request)
        {
            var predicate = PredicateBuilder.True<OcrSetting>();
            List<OcrSettingViewModel> data = new List<OcrSettingViewModel>();

            if (!string.IsNullOrEmpty(request.Description))
                predicate = predicate.And(x => x.Description.ToLower().Contains(request.Description.ToLower()));

            if (request.Type.HasValue)
                predicate = predicate.And(x => x.Type == request.Type.Value);

            var ocrSettings = await _unitOfWork.GetRepository<OcrSetting>().GetAll().Where(predicate).OrderByDescending(x => x.CreatedDate).ToListAsync();

            foreach (var item in ocrSettings)
            {
                data.Add(new OcrSettingViewModel
                {
                    Id = item.Id,
                    Description = item.Description,
                    Type = item.Type,
                    IsDeleted = item.IsDeleted,
                    IsActive = item.IsActive,
                    Value = StringUtils.ConvertStringToObject<OcrSettingValue>(item.Value),
                    CreatedDate = item.CreatedDate
                });
            }
            return data;
        }

        /// <summary>
        /// Changes the active.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangeActive(ChangeActiveRequest request)
        {
            var ocrSetting = await _unitOfWork.GetRepository<OcrSetting>().FindAsync(x => x.Id == request.Id);
            if (ocrSetting == null) throw new Exception(ErrorMessages.NotFoundSetting);
            ocrSetting.IsActive = !request.IsActive;
            ocrSetting.UpdatedDate = DateTime.Now;
            _unitOfWork.GetRepository<OcrSetting>().Update(ocrSetting);
            return await _unitOfWork.CommitAsync() >= 1;
        }

        /// <summary>
        /// Converts the setting request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private string ConvertSettingRequest(AddOrUpdateOcrSettingRequest request)
        {
            OcrSettingValue settingModels = new OcrSettingValue
            {
                AccessToken = request.AccessToken,
                ApiKey = request.ApiKey,
                TokenId = request.TokenId,
                TokenKey = request.TokenKey
            };

            return StringUtils.ConvertObjectToString(settingModels);
        }
    }
}
