using System.Collections.Generic;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface IExportExcelService
    {
        /// <summary>
        ///     Exports the patient room.
        /// </summary>
        /// <param name="patientsInRoom">The patients in room.</param>
        /// <returns></returns>
        ExportResponse ExportPatientRoom(List<PatientsInRoomViewModel> patientsInRoom);

        /// <summary>
        ///     Exports the reception.
        /// </summary>
        /// <param name="receptionReports">The reception reports.</param>
        /// <returns></returns>
        ExportResponse ExportReception(List<ReceptionReportViewModel> receptionReports);

        /// <summary>
        ///     Exports the patient.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <returns></returns>
        ExportResponse ExportPatient(ICollection<PatientInfoViewModel> patients);

        /// <summary>
        ///     Exports the balance.
        /// </summary>
        /// <param name="patients">The patients.</param>
        /// <param name="exportRequest">The export request.</param>
        /// <returns></returns>
        ExportResponse ExportBalance(ICollection<PatientInfoViewModel> patients, ExportRequest exportRequest);

        /// <summary>
        ///     Exports the department service.
        /// </summary>
        /// <param name="departmentServices">The department services.</param>
        /// <returns></returns>
        ExportResponse ExportDepartmentService(List<DepartmentServiceViewModel> departmentServices);

        /// <summary>
        ///     Gets the file import error.
        /// </summary>
        /// <param name="datas">The datas.</param>
        /// <returns></returns>
        string GetFileImportError(List<ImportDepartmentServiceModel> datas);

        /// <summary>
        ///     Exports the ocr setting.
        /// </summary>
        /// <param name="ocrSettings">The ocr settings.</param>
        /// <returns></returns>
        ExportResponse ExportOcrSetting(List<OcrSettingViewModel> ocrSettings);
    }
}