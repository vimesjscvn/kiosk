using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.BusinessObjects;

namespace Gateway.Domain.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IGatewayService
    {
        /// <summary>
        ///     Gets the patient by code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        GetRawPatientByCodeResponse GetPatientByCode(GetRawPatientByCodeRequest request);

        GetRawPatientByRegisteredCodeResponse GetPatientByRegisterdCode(GetRawPatientByRegisteredCodeRequest request);

        /// <summary>
        ///     Gets the calendar by code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        GetRawCalendarResponse GetCalendar(GetRawCalendarRequest request);

        /// <summary>
        ///     Gets all calendar.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        GetRawAllCalendarResponse GetAllCalendar(GetRawAllCalendarRequest request);

        /// <summary>
        ///     Registers the calendar.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        RegisterRawCalendarResponse RegisterCalendar(RegisterRawCalendarRequest request);

        /// <summary>
        ///     Patients the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawCheckInResponse> PatientCheckIn(PostRawCheckInRequest request);

        /// <summary>
        ///     Patients the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawUpdatePatientInfoResponse> UpdatePatientInfo(PostRawUpdatePatientInfoRequest request);

        /// <summary>
        ///     Registers the list service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<PostRawRegisterListServiceResponse>> RegisterListService(PostRawRegisterListServiceRequest request);

        /// <summary>
        ///     Registers the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawRegisterResponse> Register(PostRawRegisterRequest request);

        /// <summary>
        ///     Registers the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawChangeResponse> Change(PostRawChangeRequest request);

        /// <summary>
        ///     Updates the result list service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawUpdateResultListServiceResponse> UpdateResultListService(
            PostRawUpdateResultListServiceRequest request);

        /// <summary>
        ///     Cancels the list service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawCancelListServiceResponse> CancelListService(PostRawCancelListServiceRequest request);

        // <summary>
        /// Get service list.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        GetRawServiceListResponse GetServiceList();

        // <summary>
        /// Get drug list
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        GetRawDrugListResponse GetDrugList();

        GetRawPatientByCodeResponse GetPatientByRegisteredCode(GetRawPatientInfoByRegisteredCodeRequest request);

        Task<PostRawUpdateObjectTypeResponse> UpdateObjectType(PostRawUpdateObjectTypeRequest request);
        GetRawInfoCheckInResponse GetInfoCheckIn(GetRawInfoCheckInRequest request);

        /// <summary>
        ///     Gets all table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<PostRawTableResponse>> PostTableList(PostRawTableRequest request);

        Task<PostRawCallOrderNumberResponse> PostCallOrderNumber(PostRawCallOrderNumberRequest request);

        PostRawCheckInInfoResponse PostCheckInInfo(PostRawCheckInInfoRequest request);
        GetRawCategoryResponse GetCategories(GetRawCategoryRequest request);

        GetRawPatientResponse GetPatient(GetRawPatientRequest request);

        Task<PostRawCallNumberResponse> PostCallNumber(PostRawCallNumberRequest request, string webRoot);

        Task<PostRawRecallOrderNumberResponse> PostRecallOrderNumber(PostRawRecallOrderNumberRequest request);

        GetRawPendingListResponse GetPendingList(PostRawGetPendingListRequest request);
    }
}