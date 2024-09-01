using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Models;
using Core.Domain.BusinessObjects;
using CS.VM.Requests;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IHospitalSystemService
    {
        /// <summary>
        ///     Gets the raw patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetRawPatientByCodeData> GetRawPatientByCode(GetRawPatientByCodeRequest request);

        Task<GetRawPatientByRegisteredCodeData> GetRawPatientByRegisteredCode(
            GetRawPatientByRegisteredCodeRequest request);

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        Task<List<GetRawAllCalendarResponseData>> GetRawAllCalendar(GetRawAllCalendarRequest request);

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        Task<List<GetRawCalendarResponseData>> GetRawAllCalendarByDate(GetRawCalendarRequest request);

        /// <summary>
        ///     Gets the raw patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<InternalResponse> PostCheckInInfo(PostRawCheckInInfoRequest request);

        /// <summary>
        ///     Gets the raw patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetRawPatientByCodeData> GetRawPatientByRegisterdCode(GetRawPatientByCodeRequest request);

        Task<GetRawListExaminationByCodeResponse> GetRawListExaminationByCode(
            GetRawListExaminationByCodeRequest request);

        Task<GetRawExaminationDetailByCodeResponse> GetRawExaminationDetailByCode(
            GetRawExaminationDetailByCodeRequest request);

        Task<GetRawCategoryResponse> GetRawCategories(GetRawCategoryRequest request);

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        Task<List<GetRawReExaminationListByCodeAndDateResponseData>> GetRawListReExaminationByCodeAndDate(
            GetRawReExaminationListByCodeAndDateRequest request);

        Task<PostRawRegisterReExaminationResponse> PostRawRegisterReExamination(
            PostRawRegisterReExaminationRequest request);

        Task<GetRawPatientData> GetRawPatient(GetRawPatientRequest request);

        Task<PostRawRegisterExaminationResponse> PostRawRegisterExamination(PostRawRegisterExaminationRequest request);

        Task<List<GetRawListGroupDeptData>> GetRawListGroupDept(GetRawListGroupDeptRequest request);

        Task<PostRawRegisterExamByGroupResponse> PostRawRegisterExamByGroup(PostRawRegisterExamByGroupRequest request);

        Task<GetRawListServiceByRegisteredCodeData> GetRawListServiceByRegisteredCode(
            GetRawListServiceByRegisteredCodeRequest request);

        Task<PostRawUpdateListServiceResponse> PostRawUpdateListService(PostRawUpdateListServiceRequest request);

        /// <summary>
        ///     Synchronnization list service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceListFromHisRawData<GetListServiceFromHisRawData>> SynchronizationListService();

        Task<GetRawPendingListResponse> GetPendingList(GetRawPendingListRequest request);
    }
}