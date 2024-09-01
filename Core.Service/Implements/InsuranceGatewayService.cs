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
using Core.UoW;
using CS.Common.Helpers;
using CS.EF.Models;
using Newtonsoft.Json;
using static CS.Common.Common.Constants;

namespace Core.Service.Implements
{
    public class InsuranceGatewayService : IInsuranceGatewayService
    {
        /// <summary>
        ///     The HTTP client
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        ///     Gets the insurance settings.
        /// </summary>
        /// <value>The insurance settings.</value>
        private readonly InsuranceSettings _insuranceSettings;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InsuranceSystemService" /> class.
        /// </summary>
        /// <param name="encryptingSettings">The encrypting settings.</param>
        /// <param name="insuranceSettings">The insurance settings.</param>
        /// <param name="clientFactory">The client factory.</param>
        public InsuranceGatewayService(InsuranceSettings insuranceSettings,
            IHttpClientFactory clientFactory,
            IUnitOfWork unitOfWork)
        {
            _insuranceSettings = AppConfig.LoadInsurance(insuranceSettings);
            _clientFactory = clientFactory;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawLoginInsuranceGatewayResponse> PostRawLoginInsuranceGateway(
            PostRawLoginInsuranceGatewayRequest request)
        {
            if (!string.IsNullOrEmpty(_insuranceSettings.Insurance.Version) && _insuranceSettings.Insurance.Version == "1")
            {
                return await PostRawLoginInsuranceGatewayV1(request);
            }

            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.INSURANCE);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var url = InsuranceSettingHelper.GetEndPoint(
                _insuranceSettings.Insurance.BaseUrl,
                _insuranceSettings.Insurance.LoginUrl);

            try
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;

                var response = await client.PostAsync(url, body);
                var result = await response.Content.ReadAsStringAsync();

                // Success
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    var data = JsonConvert.DeserializeObject<PostRawLoginInsuranceGatewayResponse>(result);
                    partnerAudit.Response = JsonConvert.SerializeObject(data);
                    partnerAudit.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                    _unitOfWork.Commit();
                    return data;
                }

                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                partnerAudit.Response = JsonConvert.SerializeObject(error);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;
                var response = new PostRawLoginInsuranceGatewayResponse();
                response.maKetQua = HISErrorCode.CannotConnectToSocialInsuranceServer;
                //response.ghiChu = ex.Message;
                partnerAudit.Response = JsonConvert.SerializeObject(response);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                return response;
            }
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawVerifyInsuranceGatewayResponse> PostRawVerifyInsuranceGateway(
            PostRawVerifyInsuranceGatewayRequest request)
        {
            if (!string.IsNullOrEmpty(_insuranceSettings.Insurance.Version) && _insuranceSettings.Insurance.Version == "1")
            {
                return await PostRawVerifyInsuranceGatewayV1(request);
            }

            var client = _clientFactory.CreateClient(NamedClientConstants.INSURANCE);

            // Deserialize JSON string into a dictionary
            var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(request));

            // Convert the dictionary to form data
            var formData = new FormUrlEncodedContent(keyValuePairs);

            var baseUrl = InsuranceSettingHelper.GetEndPoint(_insuranceSettings.Insurance.BaseUrl,
                _insuranceSettings.Insurance.VerifyUrl);
            var token = request.token;
            var idToken = request.id_token;
            var username = _insuranceSettings.Insurance.Username;
            var password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password);
            var url = baseUrl + $"?token={token}&id_token={idToken}&username={username}&password={password}";

            try
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;

                var response = await client.PostAsync(url, formData);
                var result = await response.Content.ReadAsStringAsync();

                // Success
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    var data = JsonConvert.DeserializeObject<PostRawVerifyInsuranceGatewayResponse>(result);
                    partnerAudit.Response = JsonConvert.SerializeObject(data);
                    partnerAudit.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                    _unitOfWork.Commit();
                    return data;
                }

                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                partnerAudit.Response = JsonConvert.SerializeObject(error);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;
                var response = new PostRawVerifyInsuranceGatewayResponse();
                response.maKetQua = HISErrorCode.CannotConnectToSocialInsuranceServer;
                response.ghiChu = ex.Message;
                partnerAudit.Response = JsonConvert.SerializeObject(response);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                return response;
            }
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawLoginInsuranceGatewayResponse> PostRawLoginInsuranceGatewayV1(
            PostRawLoginInsuranceGatewayRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.INSURANCE);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var url = InsuranceSettingHelper.GetEndPoint(
                _insuranceSettings.Insurance.BaseUrl,
                _insuranceSettings.Insurance.LoginUrlV1);

            try
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;

                var response = await client.PostAsync(url, body);
                var result = await response.Content.ReadAsStringAsync();

                // Success
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    var data = JsonConvert.DeserializeObject<PostRawLoginInsuranceGatewayResponse>(result);
                    partnerAudit.Response = JsonConvert.SerializeObject(data);
                    partnerAudit.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                    _unitOfWork.Commit();
                    return data;
                }

                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                partnerAudit.Response = JsonConvert.SerializeObject(error);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;
                var response = new PostRawLoginInsuranceGatewayResponse();
                response.maKetQua = HISErrorCode.CannotConnectToSocialInsuranceServer;
                //response.ghiChu = ex.Message;
                partnerAudit.Response = JsonConvert.SerializeObject(response);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                return response;
            }
        }

        /// <summary>
        ///     Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawVerifyInsuranceGatewayResponse> PostRawVerifyInsuranceGatewayV1(
            PostRawVerifyInsuranceGatewayRequest request)
        {
            request.hoTenCb = _insuranceSettings.Insurance.EmployeeName;
            request.cccdCb = _insuranceSettings.Insurance.EmployeeIdentiyCard;
            var client = _clientFactory.CreateClient(NamedClientConstants.INSURANCE);

            // Deserialize JSON string into a dictionary
            var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(request));

            // Convert the dictionary to form data
            var formData = new FormUrlEncodedContent(keyValuePairs);

            var baseUrl = InsuranceSettingHelper.GetEndPoint(_insuranceSettings.Insurance.BaseUrl,
                _insuranceSettings.Insurance.VerifyUrlV1);
            var token = request.token;
            var idToken = request.id_token;
            var username = _insuranceSettings.Insurance.Username;
            var password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password);
            var url = baseUrl + $"?token={token}&id_token={idToken}&username={username}&password={password}";

            try
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;

                var response = await client.PostAsync(url, formData);
                var result = await response.Content.ReadAsStringAsync();

                // Success
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    var data = JsonConvert.DeserializeObject<PostRawVerifyInsuranceGatewayResponse>(result);
                    partnerAudit.Response = JsonConvert.SerializeObject(data);
                    partnerAudit.UpdatedDate = DateTime.Now;
                    _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                    _unitOfWork.Commit();
                    return data;
                }

                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                partnerAudit.Response = JsonConvert.SerializeObject(error);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                throw new Exception(error.Message);
            }
            catch (Exception ex)
            {
                var partnerAudit = new PartnerAudit();
                partnerAudit.Request = JsonConvert.SerializeObject(request);
                partnerAudit.URL = url;
                var response = new PostRawVerifyInsuranceGatewayResponse();
                response.maKetQua = HISErrorCode.CannotConnectToSocialInsuranceServer;
                response.ghiChu = ex.Message;
                partnerAudit.Response = JsonConvert.SerializeObject(response);
                partnerAudit.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<PartnerAudit>().Add(partnerAudit);
                _unitOfWork.Commit();
                return response;
            }
        }
    }
}