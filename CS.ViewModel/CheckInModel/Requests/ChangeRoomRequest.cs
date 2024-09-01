using System;
using Newtonsoft.Json;

namespace CS.VM.CheckInModel.Requests
{
    public class ChangeRoomRequest
    {
        /// <summary>
        ///     Gets or sets the room.
        /// </summary>
        /// <value>
        ///     The room.
        /// </value>
        [JsonRequired]
        public Guid PatientId { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonRequired]
        public string NewDepartment { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonRequired]
        public string OldDepartment { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; }


        /// <summary>
        ///     Gets or sets the new date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        [JsonRequired]
        public DateTime NewDate { get; set; }

        /// <summary>
        ///     Gets or sets the reason.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public string Reason { get; set; }

        /// <summary>
        ///     Gets or sets the employee id.
        /// </summary>
        /// <value>
        ///     The employee id.
        /// </value>
        public Guid EmployeeId { get; set; }
    }
}