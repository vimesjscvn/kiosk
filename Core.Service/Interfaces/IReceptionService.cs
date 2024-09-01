// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IReceptionService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IReceptionService
    ///     Implements the <see cref="CS.Base.IService{Reception, Base.IRepository{Reception}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{Reception, Base.IRepository{Reception}}" />
    public interface IReceptionService : IService<Reception, IRepository<Reception>>
    {
        /// <summary>
        ///     Gets the or add if not existed.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="clinic">The clinic.</param>
        /// <returns></returns>
        Task<Reception> GetOrAddIfNotExisted(GetOrAddIfNotExistedData data);

        /// <summary>
        ///     Gets the registered code list by patient.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Task<ICollection<Reception>> GetRegisteredCodeListByPatient(string code);

        /// <summary>
        ///     Gets all reception.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<ReceptionReportViewModel>> GetAllReception(ReceptionRequest request);

        /// <summary>
        ///     Exports the reception.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<ReceptionReportViewModel>> ExportReception(ReceptionRequest request);

        /// <summary>
        ///     Changes the finished.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> ChangeFinished(ChangeFinishedRequest request);

        /// <summary>
        ///     Gets all reason change.
        /// </summary>
        /// <param name="receptionId">The reception identifier.</param>
        /// <returns></returns>
        Task<ReceptionHistoryResponse> GetAllReasonChange(Guid receptionId);
    }
}