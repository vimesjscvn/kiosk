using System;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class ExportOverviewCashflowRequest
    {
        /// <summary>
        ///     Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        [JsonRequired]
        public Guid EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [JsonRequired]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [JsonRequired]
        public DateTime EndDate { get; set; }

        public bool AdminView { get; set; } = true;

        public string StartTime { get; set; } = "00:00";
        public string EndTime { get; set; } = "23:59";

        public ExportOverviewCashflowStatus Status { get; set; } = ExportOverviewCashflowStatus.All;
        public ExportOverviewCashflowPatientType PatientType { get; set; } = ExportOverviewCashflowPatientType.All;
    }

    public enum ExportOverviewCashflowStatus
    {
        All = 0,
        Waiting = 1,
        Paid = 2
    }

    public enum ExportOverviewCashflowPatientType
    {
        All = 0,
        BHYT = 1,
        DV = 2
    }
}