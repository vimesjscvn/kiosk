using System.Threading.Tasks;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface ISettingDepartmentService
    {
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
    }
}