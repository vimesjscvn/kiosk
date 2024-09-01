using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEK.Core.Settings;
using TEK.Core.Models;
using TEK.Core.Service.Interfaces;
using static CS.Common.Common.Constants;
using CS.Common.Helpers;
using TEK.Core.Domain.BusinessObjects;

namespace TEK.Payment.Domain.Services
{
    public class InsuranceGatewayService : IInsuranceGatewayService
    {
        /// <summary>
        /// Gets the insurance settings.
        /// </summary>
        /// <value>The insurance settings.</value>
        private readonly InsuranceSettings _insuranceSettings;

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceSystemService" /> class.
        /// </summary>
        /// <param name="encryptingSettings">The encrypting settings.</param>
        /// <param name="insuranceSettings">The insurance settings.</param>
        /// <param name="clientFactory">The client factory.</param>
        public InsuranceGatewayService(InsuranceSettings insuranceSettings,
            IHttpClientFactory clientFactory)
        {
            _insuranceSettings = insuranceSettings;
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
        public async Task<PostRawLoginInsuranceGatewayResponse> PostRawLoginInsuranceGateway(PostRawLoginInsuranceGatewayRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.INSURANCE);

            var body = new StringContent(stringContent);
            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(InsuranceSettingHelper.GetEndPoint(_insuranceSettings.Insurance.BaseUrl,
                _insuranceSettings.Insurance.LoginUrl), body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<PostRawLoginInsuranceGatewayResponse>(result);
                return data;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// GetClinicListResponse.
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<PostRawVerifyInsuranceGatewayResponse> PostRawVerifyInsuranceGateway(PostRawVerifyInsuranceGatewayRequest request)
        {
            var stringContent = JsonConvert.SerializeObject(request);
            var client = _clientFactory.CreateClient(NamedClientConstants.INSURANCE);

            var body = new StringContent(stringContent);
            var baseUrl = InsuranceSettingHelper.GetEndPoint(_insuranceSettings.Insurance.BaseUrl,
                _insuranceSettings.Insurance.VerifyUrl);
            var token = request.token;
            var idToken = request.id_token;
            var username = _insuranceSettings.Insurance.Username;
            var password = EncryptingHelper.MD5Hash(_insuranceSettings.Insurance.Password);
            var url = baseUrl + $"?token={token}&id_token={idToken}&username={username}&password={password}";

            body.Headers.ContentType = new MediaTypeHeaderValue(HeaderConstants.CONTENT_TYPE);
            var response = await client.PostAsync(url, body);
            var result = await response.Content.ReadAsStringAsync();

            // Success
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                var data = JsonConvert.DeserializeObject<PostRawVerifyInsuranceGatewayResponse>(result);
                return data;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                throw new Exception(error.Message);
            }
        }
    }
}
