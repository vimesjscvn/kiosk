using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Common.Models;
using Core.Config.Helpers;
using Core.Config.Settings;
using Core.Domain.BusinessObjects;
using Core.Service.Interfaces;
using CS.VM.Requests;
using Newtonsoft.Json;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    public class HospitalSystemService : IHospitalSystemService
    {
        /// <summary>
        ///     The HTTP client
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        ///     Gets the external settings.
        /// </summary>
        /// <value>The external settings.</value>
        private readonly ExternalSettings _externalSettings;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExternalSystemService" /> class.
        /// </summary>
        /// <param name="encryptingSettings">The encrypting settings.</param>
        /// <param name="externalSettings">The external settings.</param>
        /// <param name="clientFactory">The client factory.</param>
        public HospitalSystemService(ExternalSettings externalSettings,
            IHttpClientFactory clientFactory)
        {
            _externalSettings = AppConfig.LoadExternal(externalSettings);
            _clientFactory = clientFactory;
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawPatientByRegisteredCodeData> GetRawPatientByRegisteredCode(
            GetRawPatientByRegisteredCodeRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.FindPatientByRegisteredCodeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data =
                    JsonConvert.DeserializeObject<BaseInternalResponse<GetRawPatientByRegisteredCodeData>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawPatientByCodeData> GetRawPatientByCode(GetRawPatientByCodeRequest request)
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
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawPatientByCodeData>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        public async Task<GetRawPatientByCodeData> GetRawPatientByRegisterdCode(GetRawPatientByCodeRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.FindPatientByRegisteredCodeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawPatientByCodeData>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
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
                var data =
                    JsonConvert.DeserializeObject<BaseInternalResponse<List<GetRawAllCalendarResponseData>>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<GetRawCalendarResponseData>> GetRawAllCalendarByDate(GetRawCalendarRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetCalendarUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert
                    .DeserializeObject<BaseInternalResponse<List<GetRawCalendarResponseData>>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        public async Task<InternalResponse> PostCheckInInfo(PostRawCheckInInfoRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.PostCheckInInfoUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<InternalResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawListExaminationByCodeResponse> GetRawListExaminationByCode(
            GetRawListExaminationByCodeRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetListExaminationByCodeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<GetRawListExaminationByCodeResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawExaminationDetailByCodeResponse> GetRawExaminationDetailByCode(
            GetRawExaminationDetailByCodeRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetExaminationDetailByCodeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<GetRawExaminationDetailByCodeResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        public async Task<GetRawCategoryResponse> GetRawCategories(GetRawCategoryRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetCategoryUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<GetRawCategoryResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<GetRawReExaminationListByCodeAndDateResponseData>> GetRawListReExaminationByCodeAndDate(
            GetRawReExaminationListByCodeAndDateRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetReExaminationListByCodeAndDateUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert
                    .DeserializeObject<BaseInternalResponse<List<GetRawReExaminationListByCodeAndDateResponseData>>>(
                        result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawRegisterReExaminationResponse> PostRawRegisterReExamination(
            PostRawRegisterReExaminationRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.PostRegisterReExaminationUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<PostRawRegisterReExaminationResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawPatientData> GetRawPatient(GetRawPatientRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetPatientUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawPatientData>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawRegisterExaminationResponse> PostRawRegisterExamination(
            PostRawRegisterExaminationRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.PostRegisterExaminationUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<PostRawRegisterExaminationResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<GetRawListGroupDeptData>> GetRawListGroupDept(GetRawListGroupDeptRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetListGroupDeptUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<List<GetRawListGroupDeptData>>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawRegisterExamByGroupResponse> PostRawRegisterExamByGroup(
            PostRawRegisterExamByGroupRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.PostRegisterExamByGroupUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<PostRawRegisterExamByGroupResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        public async Task<GetRawListServiceByRegisteredCodeData> GetRawListServiceByRegisteredCode(
            GetRawListServiceByRegisteredCodeRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetListServiceByRegisteredCodeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data =
                    JsonConvert.DeserializeObject<BaseInternalResponse<GetRawListServiceByRegisteredCodeData>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw all calendar.
        /// </summary>
        /// <param name="request">The get raw all calendar request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawUpdateListServiceResponse> PostRawUpdateListService(
            PostRawUpdateListServiceRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.PostUpdateListServiceUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<PostRawUpdateListServiceResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
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
                var data = JsonConvert
                    .DeserializeObject<BaseInternalResponse<ServiceListFromHisRawData<GetListServiceFromHisRawData>>>(
                        result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
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

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            var responseError = new GetRawPendingListResponse();
            responseError.StatusCode = error.Code.ToString();
            responseError.Message = error.Message;
            responseError.Status = error.Success ? "success" : "failed";
            return responseError;
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawClinicListResponse> GetRawClinicList(GetRawClinicListRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetClinicListUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawClinicListResponse>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawFinallyClinicListResponse> GetRawFinallyClinicList(
            GetRawFinallyClinicListRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetFinallyClinicListUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawFinallyClinicListResponse>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetRawAllFeeResponse> GetRawAllFee(GetRawAllFeeRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.GetAllFeeUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<BaseInternalResponse<GetRawAllFeeResponse>>(result);
                return data.Result;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<InternalResponse> PostRawClinicList(ChargeRawClinicListRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.ChargeClinicUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<InternalResponse>(result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }

        /// <summary>
        ///     Posts the raw finally clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BaseInternalResponse<PostRawFinallyClinicRegistrationResponse>> PostRawFinallyClinicList(
            PayOffRawFinallyClinicListAtStoreRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.HIS);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(ExternalSettingHelper.GetEndPoint(_externalSettings.External.BaseUrl,
                _externalSettings.External.ChargeFinallyClinicListAtStoreUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data =
                    JsonConvert.DeserializeObject<BaseInternalResponse<PostRawFinallyClinicRegistrationResponse>>(
                        result);
                return data;
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
            throw new Exception(error.Message);
        }
    }
}