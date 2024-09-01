using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface IClinicService
    {
        /// <summary>
        /// Gets the queue number clinic result.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ClinicResultResponse> GenerateClinicResultNumber(ClinicResultRequest request);
        Task<ClinicResultResponse> GenerateClinicResultNumberByExamination(ClinicResultByExaminationRequest request);

        /// <summary>
        /// Gets all clinic result.
        /// </summary>
        /// <returns></returns>
        Task<List<ClinicResultViewModel>> GetAllClinicResult(int? limit);

        /// <summary>
        /// Gets all list service by patient code or department code.
        /// </summary>
        /// <returns></returns>
        Task<GetListClsResultResponse> GetListClsResult(GetListClsResultRequest request);
    }
}
