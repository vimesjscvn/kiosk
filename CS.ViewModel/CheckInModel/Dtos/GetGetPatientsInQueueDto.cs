using System;
using System.Collections.Generic;
using CS.Common.Common;

namespace CS.VM.CheckInModel.Dtos
{
    public enum EStatus
    {
        Called = 1,
        Waiting = 0
    }

    public class GetPatientsInQueueDto
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
        public PatientType Type { get; set; }

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

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public Guid PatientId { get; set; }

        public string UrlAudio { get; set; } = "";
    }

    public class GetPatientsInAndLastQueueDto
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
    }
}