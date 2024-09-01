using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UoW;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IPatientService : IService<Patient, IRepository<Patient>>
    {
        /// <summary>
        ///     Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;Patient&gt;.</returns>
        Task<Patient> GetByCode(string code, InputTypeCard type = InputTypeCard.None);

        Task<Patient> GetByCode(string type, string code);

        /// <summary>
        ///     Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;Patient&gt;.</returns>
        Task<Patient> GetByPatientCode(string code);

        Task<Patient> GetByHealthInsuranceNumber(string healthInsuranceNumber);
        Task<Patient> GetByRegisteredCode(string registeredCode);

        /// <summary>
        ///     Gets all calendar by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ICollection<ExaminationCalendar>> GetAllCalendar(GetCalendarByRegisteredCodeRequest request);

        /// <summary>
        ///     Gets the calendar by date.
        /// </summary>
        /// <param name="request">The get calendar by date request.</param>
        /// <returns></returns>
        Task<ICollection<ExaminationCalendar>> GetCalendarByDate(GetCalendarByDateRequest request);

        /// <summary>
        ///     Gets the patient by qr code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Task<TempPatient> GetPatientByQRCode(string code, List<Functions> functionsIds);

        /// <summary>
        ///     Gets the patient by qr code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Task<TempPatient> GetPatientByNationalIdQRCode(string code, List<Functions> functionsIds);

        /// <summary>
        ///     Gets all asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<PatientInfoViewModel>> GetAllAsync(DataTableParameters parameters);

        /// <summary>
        ///     Checks the code unique.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> CheckCodeUnique(CheckCodeUniqueRequest request);

        /// <summary>
        ///     Updates the patient.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PatientInfoViewModel> UpdatePatient(Guid patientId, PatientInfoViewModel request);

        /// <summary>
        ///     Gets the patient by identifier.
        /// </summary>
        /// <param name="patientId">The patient identifier.</param>
        /// <returns></returns>
        Task<PatientInfoViewModel> GetPatientById(Guid patientId);

        /// <summary>
        ///     Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ICollection<PatientInfoViewModel>> Export(ExportRequest request);

        /// <summary>
        ///     Updates the patient information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<UpdatePatientResponse> UpdatePatientInfo(UpdatePatientRequest request);

        /// <summary>
        ///     Gets the balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableResultJsonResponse<PatientInfoViewModel>> GetBalance(ExportRequest request);

        /// <summary>
        ///     Exports the balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ICollection<PatientInfoViewModel>> ExportBalance(ExportRequest request);

        /// <summary>
        ///     Gets the patient by health insurance number.
        /// </summary>
        /// <param name="healthInsuranceNumber">The health insurance number.</param>
        /// <returns></returns>
        Task<PatientInfoViewModel> GetPatientByHealthInsuranceNumber(string healthInsuranceNumber);


        /// <summary>
        ///     Gets the patient type by patient code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PatientInfoViewModel> GetPatientTypeByPatientCode(GetPatientRequest request);

        Task<TempPatient> GetPatientByQRCodeWithNoCheckSocialGateway(string code);

        Task<Patient> GetByRegisterCode(string registerCode);

        /// <summary>
        ///     Gets all patient.
        /// </summary>
        /// <returns></returns>
        Task<List<PatientViewModel>> GetAllPatient();

        /// <summary>
        ///     Gets the patient by qr code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientByQRCodeViewModel> GetPatientByQRCode(GetPatientByQRCodeRequest request);

        Task<PatientInfoViewModel> GetPatientTypeByRegisteredCode(GetPatientByRegisteredCodeRequest request);

        Task<PatientInfoViewModel> GetPatientTypeByCode(GetPatientTypeByCodeRequest request);
    }
}