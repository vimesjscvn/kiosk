using System.Collections.Generic;
using CS.VM.CheckInModel.Dtos;

namespace Admin.Domain.Models.Responses
{
    public class GetMultiQueueByDepartmentResponse
    {
        /// <summary>
        ///     Gets or sets the normal patients.
        /// </summary>
        /// <value>
        ///     The normal patients.
        /// </value>
        public List<GetPatientsInQueueDto> NormalPatients { get; set; }

        /// <summary>
        ///     Gets or sets the priority patients.
        /// </summary>
        /// <value>
        ///     The priority patients.
        /// </value>
        public List<GetPatientsInQueueDto> PriorityPatients { get; set; }

        /// <summary>
        ///     Gets or sets the last patients.
        /// </summary>
        /// <value>
        ///     The last patients.
        /// </value>
        public List<GetPatientsInQueueDto> LastPatients { get; set; }

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

        public string DepartmentName { get; set; }
    }
}