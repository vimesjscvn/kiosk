using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Common;
using CS.VM.CheckInModel.Requests;
using CS.VM.CheckInModel.Responses;
using CS.VM.Requests;
using CS.VM.Responses;

namespace Core.Service.Interfaces
{
    public interface ICheckInService
    {
        /// <summary>
        ///     Gets the patients in queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsInQueueResponse> GetPatientsInQueue(GetPatientsInQueueRequest request);

        /// <summary>
        ///     Calls the patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsInQueueResponse> CallPatient(CallPatientRequest request);

        /// <summary>
        ///     Calls the table patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<CallTablePatientResponse> CallTablePatient(CallTablePatientRequest request);

        /// <summary>
        ///     Changes the type of the table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ChangeTableTypeResponse> ChangeTableType(ChangeTableTypeRequest request);

        /// <summary>
        ///     Gets the table queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetTableQueueResponse> GetTableQueue(GetTableQueueRequest request);

        /// <summary>
        ///     Tables the check in.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TableCheckInResponse> TableCheckIn(TableCheckInRequest request);

        /// <summary>
        ///     Calls the paid table patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<CallTablePatientResponse> CallPaidTablePatient(CallTablePatientRequest request);

        /// <summary>
        ///     Gets the table paid queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetTableQueueResponse> GetTablePaidQueue(GetTableQueueRequest request);

        /// <summary>
        ///     Gets all table queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetAllTableQueueResponse> GetAllTableQueue(GetAllTableQueueRequest request);

        /// <summary>
        ///     Gets all table queue v02.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetAllTableQueueResponse> GetAllTableQueue_V02(GetAllTableQueueRequest_V02 request);

        /// <summary>
        ///     Gets the patient in and last queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsInAndLastQueueResponse> GetPatientInAndLastQueue(GetPatientsInQueueRequest request);

        /// <summary>
        ///     Gets the by token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<Guid> GetByToken(string token);

        /// <summary>
        ///     Gets the patient clinic result.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsLastQueueClinicResultResponse> GetPatientClinicResult(GetPatientsInQueueRequest request);

        /// <summary>
        ///     Calls the patient result clinic.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<bool> CallPatientClinicResult(CallPatientClinicResultRequest request);

        Task<GetPatientsLastQueueResponse> GetPatientInAndLastQueueV2(GetPatientsInQueueV2Request request,
            string webRoot = "");

        /// <summary>
        ///     Gets the patient in and last queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsLastQueueResponse> GetPatientInAndLastQueue(GetPatientsInQueueV2Request request,
            string webRoot = "");

        Task<List<QueueItem>> GetMultiQueueByDepartment(List<QueueItemRequest> request);

        /// <summary>
        ///     Gets the patient medicine result.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsLastQueueClinicResultResponse> GetPatientMedicineResult(GetPatientsInQueueRequest request);

        Task<RegisterQueueNumberResponse> ChangeRoomEndoscopic(ChangeRoomRequest request);

        Task<List<QueueItem>> GetMultiQueueByDepartmentEndoscopic(List<QueueItemRequest> request);

        /// <summary>
        ///     Calls the patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetPatientsInQueueResponse> CallPatientVirtual(CallPatientGroupRequest request, string urlAudio);

        /// <summary>
        ///     Gets all table queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetAllTableQueueResponse> GetCPS(GetAllTableQueueRequest request);
    }

    public class QueueItemRequest
    {
        public DateTime Date { get; set; }
        public Guid DepartmentCode { get; set; }
        public int Limit { get; set; }
    }

    public class QueueItem
    {
        /// <summary>
        ///     Gets or sets the normal patients.
        /// </summary>
        /// <value>
        ///     The normal patients.
        /// </value>
        public List<PatientQueueItem> NormalPatients { get; set; }

        /// <summary>
        ///     Gets or sets the priority patients.
        /// </summary>
        /// <value>
        ///     The priority patients.
        /// </value>
        public List<PatientQueueItem> PriorityPatients { get; set; }

        /// <summary>
        ///     Gets or sets the last patients.
        /// </summary>
        /// <value>
        ///     The last patients.
        /// </value>
        public List<PatientQueueItem> LastPatients { get; set; }

        /// <summary>
        ///     Gets or sets the normal number.
        /// </summary>
        /// <value>
        ///     The normal number.
        /// </value>
        public int NormalNumber { get; set; }

        /// <summary>
        ///     Gets or sets the priority number.
        /// </summary>
        /// <value>
        ///     The priority number.
        /// </value>
        public int PriorityNumber { get; set; }

        public string DeparmentCode { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string DepartmentNameChange { get; set; }

        public int NumberOfNormalPatient { get; set; }
        public int NumberOfPriorityPatient { get; set; }

        public string NormalAudioUrl { get; set; }
        public string PriorityAudioUrl { get; set; }

        /// <summary>
        ///     Hiện thị tên phòng
        /// </summary>
        public int? DisplayOrder { get; set; }
    }

    public class PatientQueueItem
    {
        /// <summary>
        ///     Gets or sets the queue number.
        /// </summary>
        /// <value>
        ///     The queue number.
        /// </value>
        public int QueueNumber { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the age.
        /// </summary>
        /// <value>
        ///     The age.
        /// </value>
        public string Age { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public PatientType TypeName { get; set; }

        /// <summary>
        ///     Gets or sets the type code.
        /// </summary>
        /// <value>
        ///     The type code.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public int Status { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public int Gender { get; set; }
    }
}