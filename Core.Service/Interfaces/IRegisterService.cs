using System.Threading.Tasks;
using CS.EF.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface IRegisterService
    {
        /// <summary>
        ///     Updates the result list service out patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task UpdateResultListServiceOutPatient(UpdateResultListServiceRequest request);

        /// <summary>
        ///     Registers the out patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<RegisterResponse> RegisterOutPatient(RegisterRequest request, Patient patient);
    }
}