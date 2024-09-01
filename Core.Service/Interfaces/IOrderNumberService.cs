// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IQueueNumberService.cs" company="CS.Abstractions">
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
using CS.VM.PostModels;
using CS.VM.QueueNumberModels;
using CS.VM.QueueNumberModels.Requests;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    /// <summary>
    ///     Interface IQueueNumberService
    ///     Implements the <see cref="CS.Base.IService{QueueNumber, Base.IRepository{QueueNumber}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{QueueNumber, Base.IRepository{QueueNumber}}" />
    /// <seealso cref="QueueNumber" />
    public interface IOrderNumberService : IService<QueueNumber, IRepository<QueueNumber>>
    {
        /// <summary>
        ///     Generates the specified patient information.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<Guid> departments);

        /// <summary>
        ///     Adds the temporary patient asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<QueueNumber> AddTempPatientAsync(QueueNumber entity);

        /// <summary>
        ///     Gets the by departments.
        /// </summary>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        Task<ICollection<QueueNumber>> GetByDepartments(IEnumerable<string> departments, Guid patientId);

        /// <summary>
        ///     Gets the by patient code and department code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<IEnumerable<QueueNumber>> GetByPatientCodeAndDepartmentCode(GetByPatientCodeRequest request);

        /// <summary>
        ///     Adds the asynchronous.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        Task<QueueNumber> AddAsync(QueueNumberPostModel postModel);

        /// <summary>
        ///     Generates the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <returns></returns>
        Task<QueueNumber> Generate(Patient patient, string departmentCode);

        /// <summary>
        ///     Generates the specified patient information.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<CreateOrderNumberRequest> departments);

        /// <summary>
        ///     Gets the patients in room.
        /// </summary>
        /// <param name="roomRequest">The room request.</param>
        /// <returns></returns>
        Task<GetPatientsInRoomResponse> GetPatientsInRoom(GetPatientsInRoomRequest roomRequest);

        /// <summary>
        ///     Exports the patients in room.
        /// </summary>
        /// <param name="roomRequest">The room request.</param>
        /// <returns></returns>
        Task<List<PatientsInRoomViewModel>> ExportPatientsInRoom(GetPatientsInRoomRequest roomRequest);

        /// <summary>
        ///     Removes the patients in queue.
        /// </summary>
        /// <param name="removeRequest">The remove request.</param>
        /// <returns></returns>
        Task<bool> RemovePatientsInQueue(RemovePatientsInQueueRequest removeRequest);

        /// <summary>
        ///     Adds the queue number.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="patient">The patient.</param>
        /// <returns></returns>
        Task AddQueueNumber(string departmentCode, SysUser employee, Patient patient);

        /// <summary>
        ///     Gets the room by patient code.
        /// </summary>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        Task<GetRoomPatientResponse> GetRoomByPatientCode(string patientCode);

        /// <summary>
        ///     Patients the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<CheckInResponse> PatientCheckIn(CheckInRequest request);

        /// <summary>
        ///     Gets the by patient code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Task<IEnumerable<QueueNumber>> GetByPatientCode(string code);

        /// <summary>
        ///     Gets the result.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Patient>> GetResult();

        /// <summary>
        ///     Generates the clinic number.
        /// </summary>
        /// <param name="postModel">The post model.</param>
        /// <returns></returns>
        Task<List<QueueNumber>> GenerateClinicResult(QueueNumberPostModel postModel);

        /// <summary>
        ///     Registers the queue number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<RegisterQueueNumberResponse> RegisterQueueNumber(RegisterQueueNumberRequest request);

        /// <summary>
        ///     Generates the type of the by patient code with.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GenerateByPatientCodeResponse> GenerateByPatientCodeWithType(GenerateByPatientCodeWithTypeRequest request);

        /// <summary>
        ///     Generates the specified patient information.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<string> departments);

        /// <summary>
        ///     Generates the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <returns></returns>
        Task<QueueNumber> Generate(Patient patient, string departmentCode, Guid roomId, string registeredCode);

        /// <summary>
        ///     Gets the queue number temporary by table code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<QueueNumberTempViewModel>>
            GetQueueNumberTempByTableCode(GetQueueNumberTempByTableCodeRequest request);

        /// <summary>
        ///     Gets the selected queue number temporary by table code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ICollection<CombinePatientAndQueueTempViewModel>> GetSelectedQueueNumberTempByTableCode(
            GetQueueNumberTempByTableCodeRequest request);

        /// <summary>
        ///     Gets the latest number by department.
        /// </summary>
        /// <param name="deparmentCode">The deparment code.</param>
        /// <returns></returns>
        GetLatestNumberResponse GetLatestNumberByDepartment(string deparmentCode);

        /// <summary>
        ///     Adds the queue number temporary.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;QueueNumberTempViewModel&gt;.</returns>
        Task<QueueNumberTempViewModel> AddQueueNumberTemp(AddQueueNumberTempRequest request);

        /// <summary>
        ///     Verifies the queue temporary request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<QueueNumberTemp> VerifyQueueTempRequest(VerifyQueueTempRequest request);

        /// <summary>
        ///     Gets the type of the temporary from patient code and.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<List<CombinePatientAndQueueTempViewModel>> GetTempFromPatientCodeAndType(
            GetTempFromPatientsByDepartmentCodeRequest request);

        ///// <summary>
        ///// Gets the room by patient code.
        ///// </summary>
        ///// <param name="patientCode">The patient code.</param>
        ///// <returns></returns>
        //Task<UltrasoundResponse> GenerateNumber(List<CreateOrderNumberRequest> request, string patientCode);

        /// <summary>
        ///     Add new queue number history.
        /// </summary>
        /// <param name="postModel">The queue number history post model.</param>
        /// <returns></returns>
        Task<bool> RevertOrderNumber(RevertOrderNumberRequest request);

        Task<QueueNumber> AddNumberChangeRoom(QueueNumberAddModel postModel);

        /// <summary>
        ///     Registers the queue number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<RegisterQueueNumberResponse> RegisterEndoscopicQueueNumber(RegisterEndoscopicQueueNumberRequest request);

        /// <summary>
        ///     Registers the queue number.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<QueueNumber> EndoscopicBoardingRegisterQueueNumber(EndoscopicBoardingRegisterOrderNumberRequest request,
            Patient model);

        /// <summary>
        ///     Gets the patients in room.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ICollection<QueueNumber> GetPatientsInRoomEndoscopic(GetPatientsInEndoscopicRequest request,
            out int totalRecord, bool isExport);

        /// <summary>
        ///     Add new queue number history.
        /// </summary>
        /// <param name="postModel">The queue number history post model.</param>
        /// <returns></returns>
        Task<QueueNumberHistory> AddQueueNumberHistory(QueueNumberHistory entity);

        /// <summary>
        ///     Add new queue number history.
        /// </summary>
        /// <param name="postModel">The queue number history post model.</param>
        /// <returns></returns>
        Task<bool> RevertOrderNumberNormalDepartment(RevertOrderNumberNormalDepartmentRequest request);

        Task<RegisterQueueNumberResponse> RePrintQueueNumber(RePrintQueueNumberRequest request);
        Task<ResetQueueNumberResponse> ResetQueueNumber(ResetQueueNumberRequest request);
    }

    /// <summary>
    /// </summary>
    public class CreateOrderNumberRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        public string DepartmentCode { get; set; }

        public string RegisteredCode { get; set; }
    }
}