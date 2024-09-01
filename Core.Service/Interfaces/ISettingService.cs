using System.Threading.Tasks;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface ISettingService
    {
        /// <summary>
        ///     Gets all setting.
        /// </summary>
        /// <returns></returns>
        Task<GetAllSettingResponse> GetAllSetting();

        /// <summary>
        ///     Gets the setting by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<BaseSetting> GetSettingByKey(string key);

        /// <summary>
        ///     Creates the or update setting.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task CreateOrUpdateSetting(CreateOrUpdateSettingRequest request);

        /// <summary>
        ///     Gets the setting device.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <returns></returns>
        Task<DeviceSettingResponse> GetSettingDevice(string ip);

        /// <summary>
        ///     Creates the or update setting device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<DeviceSettingResponse> CreateOrUpdateSettingDevice(CreateOrUpdateSettingDepartmentRequest request);

        /// <summary>
        ///     Gets the general setting.
        /// </summary>
        /// <returns></returns>
        Task<GeneralSettingResponse> GetGeneralSetting();

        /// <summary>
        ///     Adds the or update general setting.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> AddOrUpdateGeneralSetting(GeneralSettingRequest request);
    }
}