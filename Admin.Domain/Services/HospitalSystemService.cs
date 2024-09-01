using CS.VM.Requests;
using CS.VM.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEK.Core.Models;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Gateway.Domain.BusinessObjects;
using static CS.Common.Common.Constants;

namespace Admin.API.Domain.Services
{
    public class HospitalSystemService : IHospitalSystemService
    {
        /// <summary>
        /// Gets the external settings.
        /// </summary>
        /// <value>The external settings.</value>
        private readonly ExternalSettings _externalSettings;

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalSystemService" /> class.
        /// </summary>
        /// <param name="encryptingSettings">The encrypting settings.</param>
        /// <param name="externalSettings">The external settings.</param>
        /// <param name="clientFactory">The client factory.</param>
        public HospitalSystemService(ExternalSettings externalSettings,
            IHttpClientFactory clientFactory)
        {
            _externalSettings = externalSettings;
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawPatientData> GetRawPatient(GetRawPatientRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.FindPatientByCodeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawPatientData>>(result);
                return data.Result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<GetRawAllCalendarResponseData>> GetRawAllCalendar(GetRawAllCalendarRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetAllCalendarUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<List<GetRawAllCalendarResponseData>>>(result);
                return data.Result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Refunds the clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<InternalResponse> RefundClinicList(RefundRegistrationRawRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.RefundServiceUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<InternalResponse>(result);
                return data;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);
            }
        }

        public async Task<List<GetServiceResultRawResponse>> GetClinicResult(GetServiceListResultRawRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetServiceResultListUrl), body);
            var result = await response.Content.ReadAsStringAsync();
            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<List<GetServiceResultRawResponse>>>(result);
                return data.Result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);
            }
        }

        public async Task<ServiceListFromHisRawData<GetListServiceFromHisRawData>> SynchronizationListService()
        {
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);
            var response = await client.GetAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetServiceListFromHis));
            var result = await response.Content.ReadAsStringAsync();
            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<ServiceListFromHisRawData<GetListServiceFromHisRawData>>>(result);
                return data.Result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);                                                                                                          
            }
        }

        public async Task<UpdateRawRefundResponse> UpdateRefund(UpdateRawRefundRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.UpdateRefundUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<UpdateRawRefundResponse>>(result);
                return data.Result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                var responseError = new UpdateRawRefundResponse();
                responseError.StatusCode = error.Code.ToString();
                responseError.Message = error.Message;
                responseError.Status = error.Success ? "success" : "failed";
                return responseError;
            }
        }

        public async Task<GetRawPendingListResponse> GetPendingList(GetRawPendingListRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetPendingListUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<GetRawPendingListResponse>(result);
                return data;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                var responseError = new GetRawPendingListResponse();
                responseError.StatusCode = error.Code.ToString();
                responseError.Message = error.Message;
                responseError.Status = error.Success ? "success" : "failed";
                return responseError;
            }
        }

        public Task<GetRawPatientByCodeData> GetRawPatientByCode(GetRawPatientByCodeRequest request)
        {
            throw new NotImplementedException();
        }

        Task<GetRawPatientByRegisteredCodeData> IHospitalSystemService.GetRawPatientByRegisteredCode(GetRawPatientByRegisteredCodeRequest request)
        {
            throw new NotImplementedException();
        }

        Task<BaseInternalResponse<PostRawFinallyClinicRegistrationResponse>> IHospitalSystemService.PostRawFinallyClinicList(PayOffRawFinallyClinicListAtStoreRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetRawCalendarResponseData>> GetRawAllCalendarByDate(GetRawCalendarRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<InternalResponse> AdminApiAddPayment(AdminApiAddPaymentRequest request)
        {
            throw new NotImplementedException();
        }

        Task<BaseInternalResponse<Gateway.Domain.BusinessObjects.UpdateRawRefundResponse>> IHospitalSystemService.UpdateRefund(UpdateRawRefundRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<InternalResponse> PostCheckInInfo(PostRawCheckInInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRawPatientByCodeData> GetRawPatientByRegisterdCode(GetRawPatientByCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRawAllFeeResponse> GetRawAllFee(GetRawAllFeeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRawListExaminationByCodeResponse> GetRawListExaminationByCode(GetRawListExaminationByCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRawExaminationDetailByCodeResponse> GetRawExaminationDetailByCode(GetRawExaminationDetailByCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRawCategoryResponse> GetRawCategories(GetRawCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetRawReExaminationListByCodeAndDateResponseData>> GetRawListReExaminationByCodeAndDate(GetRawReExaminationListByCodeAndDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PostRawRegisterReExaminationResponse> PostRawRegisterReExamination(PostRawRegisterReExaminationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PostRawRegisterExaminationResponse> PostRawRegisterExamination(PostRawRegisterExaminationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetRawListGroupDeptData>> GetRawListGroupDept(GetRawListGroupDeptRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PostRawRegisterExamByGroupResponse> PostRawRegisterExamByGroup(PostRawRegisterExamByGroupRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRawListServiceByRegisteredCodeData> GetRawListServiceByRegisteredCode(GetRawListServiceByRegisteredCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PostRawUpdateListServiceResponse> PostRawUpdateListService(PostRawUpdateListServiceRequest request)
        {
            throw new NotImplementedException();
        }

        Task<Gateway.Domain.BusinessObjects.GetRawPendingListResponse> IHospitalSystemService.GetPendingList(GetRawPendingListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
