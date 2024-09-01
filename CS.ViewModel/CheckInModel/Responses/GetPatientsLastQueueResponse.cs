using CS.VM.CheckInModel.Dtos;
using System.Collections.Generic;

namespace CS.VM.CheckInModel.Responses
{
    public class GetPatientsLastQueueResponse
    {
        /// <summary>
        /// Gets or sets the normal patients.
        /// </summary>
        /// <value>
        /// The normal patients.
        /// </value>
        public List<GetPatientsInQueueDto> NormalPatients { get; set; }
        /// <summary>
        /// Gets or sets the priority patients.
        /// </summary>
        /// <value>
        /// The priority patients.
        /// </value>
        public List<GetPatientsInQueueDto> PriorityPatients { get; set; }
        /// <summary>
        /// Gets or sets the last patients.
        /// </summary>
        /// <value>
        /// The last patients.
        /// </value>
        public List<GetPatientsInQueueDto> LastPatients { get; set; }
        /// <summary>
        /// Gets or sets the normal number.
        /// </summary>
        /// <value>
        /// The normal number.
        /// </value>
        public int NormalNumber { get; set; }
        public string NormalName { get; set; }
        public string NormalAge { get; set; }
        public int NormalGender { get; set; }
        public string NormalAudioUrl { get; set; }

        /// <summary>
        /// Gets or sets the priority number.
        /// </summary>
        /// <value>
        /// The priority number.
        /// </value>
        public int PriorityNumber { get; set; }
        /// <summary>
        /// Gets or sets the normal patients.
        /// </summary>
        /// <value>
        /// The normal patients.
        /// </value>
        public List<GetPatientsInQueueDto> NormalPatients { get; set; }
        /// <summary>
        /// Gets or sets the priority patients.
        /// </summary>
        /// <value>
        /// The priority patients.
        /// </value>
        public List<GetPatientsInQueueDto> PriorityPatients { get; set; }
        /// <summary>
        /// Gets or sets the last patients.
        /// </summary>
        /// <value>
        /// The last patients.
        /// </value>
        public List<GetPatientsInQueueDto> LastPatients { get; set; }
        /// <summary>
        /// Gets or sets the normal number.
        /// </summary>
        /// <value>
        /// The normal number.
        /// </value>
        public int NormalNumber { get; set; }
        /// <summary>
        /// Gets or sets the priority number.
        /// </summary>
        /// <value>
        /// The priority number.
        /// </value>
        public int PriorityNumber { get; set; }
    }

    public class GetPatientsLastQueueClinicResultResponse
    {
        /// <summary>
        /// Gets or sets the last queue patients.
        /// </summary>
        /// <value>
        /// The last queue patients.
        /// </value>
        public List<GetPatientsInQueueDto> LastQueuePatients { get; set; }
        /// <summary>
        /// Gets or sets the in queue patients.
        /// </summary>
        /// <value>
        /// The in queue patients.
        /// </value>
        public List<GetPatientsInQueueDto> InQueuePatients { get; set; }
        /// <summary>
        /// Gets or sets the current number.
        /// </summary>
        /// <value>
        /// The current number.
        /// </value>
        public int CurrentNumber { get; set; }
        public string CurrentName { get; set; }
        public string CurrentAge { get; set; }
        public int CurrentGender { get; set; }
        /// <summary>
        /// Gets or sets the last queue patients.
        /// </summary>
        /// <value>
        /// The last queue patients.
        /// </value>
        public List<GetPatientsInQueueDto> LastQueuePatients { get; set; }
        /// <summary>
        /// Gets or sets the in queue patients.
        /// </summary>
        /// <value>
        /// The in queue patients.
        /// </value>
        public List<GetPatientsInQueueDto> InQueuePatients { get; set; }
        /// <summary>
        /// Gets or sets the current number.
        /// </summary>
        /// <value>
        /// The current number.
        /// </value>
        public int CurrentNumber { get; set; }
    }
}
