using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service.Interfaces;
using Core.UoW;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.EntityFrameworkCore;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    public class SettingService : ISettingService
    {
        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUploadService _uploadService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public SettingService(IUnitOfWork unitOfWork,
            IUploadService uploadService,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
        }

        /// <summary>
        ///     Gets the setting device.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <returns></returns>
        public async Task<DeviceSettingResponse> GetSettingDevice(string ip)
        {
            var device = await _unitOfWork.GetRepository<SettingDepartment>().GetAll()
                .FirstOrDefaultAsync(x => x.Ip == ip);
            if (device == null)
            {
                return _mapper.Map(new SettingDepartment { Code = "" }, new DeviceSettingResponse());
            }

            var result = _mapper.Map(device, new DeviceSettingResponse());
            var valueType = await _unitOfWork.GetRepository<ListValueType>()
                .FindAsync(x => x.Code == ValueTypeCode.DepartmentCode);
            var department = await _unitOfWork.GetRepository<ListValueExtend>()
                .FindAsync(x => x.Code == device.Code && x.ListValueTypeId == valueType.Id);
            result.Name = department != null ? department.Description : device.Code;
            return result;
        }

        /// <summary>
        ///     Creates the or update setting device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<DeviceSettingResponse> CreateOrUpdateSettingDevice(
            CreateOrUpdateSettingDepartmentRequest request)
        {
            var setting = await _unitOfWork.GetRepository<SettingDepartment>().GetAll()
                .FirstOrDefaultAsync(x => x.Ip == request.Ip);
            if (setting == null)
            {
                var newSetting = _mapper.Map(request, new SettingDepartment());
                _unitOfWork.GetRepository<SettingDepartment>().Add(newSetting);
                await _unitOfWork.CommitAsync();
                return _mapper.Map(newSetting, new DeviceSettingResponse());
            }

            if (!string.IsNullOrEmpty(request.Ip)) setting.Ip = request.Ip;
            else setting.Ip = "";
            setting.Code = request.Code;
            setting.Type = request.Type;
            _unitOfWork.GetRepository<SettingDepartment>().Update(setting);
            await _unitOfWork.CommitAsync();
            return _mapper.Map(setting, new DeviceSettingResponse());
        }

        /// <summary>
        ///     Gets the setting by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<BaseSetting> GetSettingByKey(string key)
        {
            var setting = await _unitOfWork.GetRepository<Setting>().FindAsync(x => x.Key == key);

            if (setting == null)
            {
                key = DefautSetting.DefautKey;
                setting = await _unitOfWork.GetRepository<Setting>().FindAsync(x => x.Key == key);
            }

            return new BaseSetting
            {
                Key = setting.Key,
                Value = StringUtils.ConvertStringToObject<SettingModel>(setting.Value)
            };
        }

        /// <summary>
        ///     Creates the or update setting.
        /// </summary>
        /// <param name="request">The request.</param>
        public async Task CreateOrUpdateSetting(CreateOrUpdateSettingRequest request)
        {
            var exsitedSetting =
                await _unitOfWork.GetRepository<Setting>().FindAsync(setting => setting.Key == request.Key);

            if (exsitedSetting != null)
            {
                exsitedSetting.Value = ConvertSettingRequest(request);
                _unitOfWork.GetRepository<Setting>().Update(exsitedSetting);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                var addSetting =
                    _mapper.Map(new SettingViewModel { Key = request.Key, Value = ConvertSettingRequest(request) },
                        new Setting());
                _unitOfWork.GetRepository<Setting>().Add(addSetting);
                await _unitOfWork.CommitAsync();
            }
        }

        /// <summary>
        ///     Gets all setting.
        /// </summary>
        /// <returns></returns>
        public async Task<GetAllSettingResponse> GetAllSetting()
        {
            var settings = _unitOfWork.GetRepository<Setting>().GetAll();
            var listSetting = new List<BaseSetting>();

            await settings.ForEachAsync(setting =>
            {
                listSetting.Add(new BaseSetting
                {
                    Key = setting.Key,
                    Value = StringUtils.ConvertStringToObject<SettingModel>(setting.Value)
                });
            });

            return new GetAllSettingResponse
            {
                Settings = listSetting
            };
        }

        /// <summary>
        ///     Gets the general setting.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GeneralSettingResponse> GetGeneralSetting()
        {
            var generalSetting = await _unitOfWork.GetRepository<Setting>()
                .FindAsync(x => x.Key == DefautSetting.DefautGeneralKey);

            if (generalSetting == null) throw new Exception(ErrorMessages.NotFoundSetting);

            return StringUtils.ConvertStringToObject<GeneralSettingResponse>(generalSetting.Value);
        }

        /// <summary>
        ///     Updates the general setting.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<bool> AddOrUpdateGeneralSetting(GeneralSettingRequest request)
        {
            var generalSetting = await _unitOfWork.GetRepository<Setting>()
                .FindAsync(x => x.Key == DefautSetting.DefautGeneralKey);

            if (generalSetting == null)
            {
                var logoUrl = await _uploadService.SingleUpload(request.Logo);
                var bannerUrl = await _uploadService.SingleUpload(request.Banner);
                var backgroundUrl = await _uploadService.SingleUpload(request.Background);

                var addSetting = _mapper.Map(new SettingViewModel
                    {
                        Key = DefautSetting.DefautGeneralKey,
                        Value = StringUtils.ConvertObjectToString(new GeneralSettingViewModel
                        {
                            BackgroundUrl = backgroundUrl,
                            BannerUrl = bannerUrl,
                            LogoUrl = logoUrl,
                            HospitalCode = request.HospitalCode,
                            HospitalNameEnglish = request.HospitalNameEnglish,
                            HospitalNameVietnamese = request.HospitalNameVietnamese,
                            HospitalSlogan = request.HospitalSlogan
                        })
                    }
                    , new Setting());
                _unitOfWork.GetRepository<Setting>().Add(addSetting);
            }
            else
            {
                var logoUrl = await _uploadService.SingleUpload(request.Logo);
                var bannerUrl = await _uploadService.SingleUpload(request.Banner);
                var backgroundUrl = await _uploadService.SingleUpload(request.Background);

                var valueConvert = StringUtils.ConvertStringToObject<GeneralSettingResponse>(generalSetting.Value);

                generalSetting.Value = StringUtils.ConvertObjectToString(new GeneralSettingViewModel
                {
                    BackgroundUrl = string.IsNullOrEmpty(backgroundUrl) ? valueConvert.BackgroundUrl : backgroundUrl,
                    BannerUrl = string.IsNullOrEmpty(bannerUrl) ? valueConvert.BannerUrl : bannerUrl,
                    LogoUrl = string.IsNullOrEmpty(logoUrl) ? valueConvert.LogoUrl : logoUrl,
                    HospitalCode = request.HospitalCode,
                    HospitalNameEnglish = request.HospitalNameEnglish,
                    HospitalNameVietnamese = request.HospitalNameVietnamese,
                    HospitalSlogan = request.HospitalSlogan
                });
                _unitOfWork.GetRepository<Setting>().Update(generalSetting);
            }

            return await _unitOfWork.CommitAsync() >= 1;
        }

        /// <summary>
        ///     Converts the setting request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private string ConvertSettingRequest(CreateOrUpdateSettingRequest request)
        {
            var settingModels = new SettingModel
            {
                OptionHospital = new List<SettingValueModel> { request.OptionHospital },
                LogosUrl = new List<SettingValueModel> { request.LogosUrl },
                OptionBackground = new List<SettingValueModel> { request.OptionBackground },
                OptionColor = new List<SettingValueModel> { request.OptionColor },
                OptionColorByPriority = new List<SettingValueModel> { request.OptionColorByPriority },
                OptionsFont = new List<SettingValueModel> { request.OptionsFont },
                OptionsSizeFont = new List<SettingValueModel> { request.OptionsSizeFont },
                OptionsSL = new List<SettingValueModel> { request.OptionsSL },
                OptionsStartBanner = new List<SettingValueModel> { request.OptionsStartBanner },
                OptionsTimeBanner = new List<SettingValueModel> { request.OptionsTimeBanner },
                OptionsFooter = new List<SettingValueModel> { request.OptionsFooter }
            };

            return StringUtils.ConvertObjectToString(settingModels);
        }
    }
}