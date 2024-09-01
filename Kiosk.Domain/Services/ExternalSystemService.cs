// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ExternalSystemService.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Common.Common;
using CS.Common.Helpers;
using CS.VM.External.Requests;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.PaymentModels.Requests;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// Class ExternalSystemService.
    /// Implements the <see cref="CS.Abstractions.IServices.IExternalSystemService" />
    /// </summary>
    /// <seealso cref="CS.Abstractions.IServices.IExternalSystemService" />
    public class ExternalSystemService : IExternalSystemService
    {
        /// <summary>
        /// Gets the encrypting settings.
        /// </summary>
        /// <value>The encrypting settings.</value>
        public EncryptingSettings EncryptingSettings { get; private set; }

        /// <summary>
        /// Gets the external settings.
        /// </summary>
        /// <value>The external settings.</value>
        public ExternalSettings ExternalSettings { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalSystemService"/> class.
        /// </summary>
        /// <param name="encryptingSettings">The encrypting settings.</param>
        /// <param name="tekmediCardService">The tekmedi card service.</param>
        /// <param name="tekmediCardHistoryRepository">The tekmedi card history repository.</param>
        /// <param name="clinicRepository">The clinic repository.</param>
        /// <param name="patientRepository">The patient repository.</param>
        /// <param name="genericService">The generic service.</param>
        /// <param name="externalSettings">The external settings.</param>
        public ExternalSystemService(EncryptingSettings encryptingSettings,
            ExternalSettings externalSettings)
        {
            EncryptingSettings = encryptingSettings;
            ExternalSettings = externalSettings;
        }

        /// <summary>
        /// Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>GetClinicListResponse.</returns>
        public async Task<GetClinicListResponse> GetRawClinicList(GetRawClinicListRequest request)
        {
            var makeGetClinicListRequest = new MakeRequest<GetClinicListRequest, GetClinicListResponse>(EncryptingSettings, ExternalSettings);

            var getClinicListRequest = new GetClinicListRequest
            {
                PatientCode = request.PatientCode,
                RegisteredDate = DateUtils.ConvertToStringWithDefault(request.RegisteredDate, Constants.FormatDateTime)
            };

            var result = makeGetClinicListRequest.Invoke(getClinicListRequest, ExternalSettings.External.GetClinicUrl);
            return await Task.FromResult<GetClinicListResponse>(result);
        }

        /// <summary>
        /// Gets the raw finally clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>GetFinallyClinicListResponse.</returns>
        public async Task<GetFinallyClinicListResponse> GetRawFinallyClinicList(GetRawFinallyClinicListRequest request)
        {
            var makeGetFinallyClinicListRequest = new MakeRequest<GetFinallyClinicListRequest, GetFinallyClinicListResponse>(EncryptingSettings, ExternalSettings);

            var getFinallyClinicListRequest = new GetFinallyClinicListRequest
            {
                PatientCode = request.PatientCode,
                RegisteredCode = request.RegisteredCode
            };

            var result = makeGetFinallyClinicListRequest.Invoke(getFinallyClinicListRequest, ExternalSettings.External.GetFinallyClinicListUrl);
            return await Task.FromResult<GetFinallyClinicListResponse>(result);
        }

        /// <summary>
        /// Gets the raw finally clinic list by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;GetFinallyClinicListResponse&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetFinallyClinicListResponse> GetRawFinallyClinicListByRegisteredCode(GetRawFinallyClinicListByRegisteredCodeRequest request)
        {
            var makeGetFinallyClinicListRequest =
                new MakeRequest<GetFinallyClinicListRequest, GetFinallyClinicListResponse>(EncryptingSettings,
                    ExternalSettings);

            var getFinallyClinicListRequest = new GetFinallyClinicListRequest
            {
                PatientCode = request.PatientCode,
                RegisteredCode = request.RegisteredCode
            };

            var result = makeGetFinallyClinicListRequest.Invoke(getFinallyClinicListRequest,
                ExternalSettings.External.GetFinallyClinicListUrl);
            return await Task.FromResult<GetFinallyClinicListResponse>(result);
        }

        /// <summary>
        /// Gets the raw prescriptions by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;GetPrescriptionResponse&gt;.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetPrescriptionResponse> GetRawPrescriptionsByRegisteredCode(GetRawPrescriptionsByRegisteredCodeRequest request)
        {
            var makeRequest =
                new MakeRequest<GetPrescriptionRequest, GetPrescriptionResponse>(EncryptingSettings,
                    ExternalSettings);

            var getRequest = new GetPrescriptionRequest
            {
                PatientCode = request.PatientCode,
                RegisteredCode = request.RegisteredCode,
                RegisteredDate = DateUtils.ConvertToStringWithDefault(request.RequestedDate, Constants.FormatDateTime)
            };

            var result = makeRequest.Invoke(getRequest, ExternalSettings.External.GetPrescriptionUrl);
            return await Task.FromResult<GetPrescriptionResponse>(result);
        }

        /// <summary>
        /// Gets all waiting raw finally clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetAllFinallyClinicListResponse> GetAllWaitingRawFinallyClinicList(SyncPaidWaitingRequest request)
        {
            var makeGetFinallyClinicListRequest =
                new MakeRequest<GetAllFinallyClinicListRequest, GetAllFinallyClinicListResponse>(EncryptingSettings,
                    ExternalSettings);

            var getAllFinallyClinicListRequest = new GetAllFinallyClinicListRequest
            {
                FromDate = DateUtils.ConvertToStringWithDefault(request.FromDate, Constants.FormatDateTime),
                ToDate = DateUtils.ConvertToStringWithDefault(request.ToDate, Constants.FormatDateTime)
            };

            var result = makeGetFinallyClinicListRequest.Invoke(getAllFinallyClinicListRequest,
                ExternalSettings.External.GetAllFinallyClinicListUrl);
            return await Task.FromResult<GetAllFinallyClinicListResponse>(result);
        }

        /// <summary>
        /// Gets the raw finally clinic list by registered code.
        /// </summary>
        /// <param name="data">The request.</param>
        /// <returns>
        /// Task&lt;GetFinallyClinicListResponse&gt;.
        /// </returns>
        public async Task<GetRawCalendarResponse> GetRawCalendar(GetRawCalendarRequest data)
        {
            var makeRequest =
                new MakeRequest<GetCalendarRequest, GetRawCalendarResponse>(EncryptingSettings, ExternalSettings);

            var request = new GetCalendarRequest
            {
                PatientCode = data.PatientCode,
                RegisteredDate = DateUtils.ConvertToStringWithDefault(data.RegisteredDate, Constants.FormatDateTime)
            };

            var result = makeRequest.Invoke(request, ExternalSettings.External.GetCalendarUrl);
            return await Task.FromResult<GetRawCalendarResponse>(result);
        }

        /// <summary>
        /// Posts the raw clinic registration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<PostRawClinicRegistrationResponse> PostRawClinicRegistration(PostRawClinicRegistrationRequest data)
        {
            var makeRequest =
                new MakeRequest<PostRawClinicRegistrationRequest, PostRawClinicRegistrationResponse>(EncryptingSettings, ExternalSettings);

            var request = new PostRawClinicRegistrationRequest
            {
                PatientCode = data.PatientCode
            };

            var result = makeRequest.Invoke(request, ExternalSettings.External.RegisterClinicUrl);
            return await Task.FromResult<PostRawClinicRegistrationResponse>(result);
        }
    }
}
