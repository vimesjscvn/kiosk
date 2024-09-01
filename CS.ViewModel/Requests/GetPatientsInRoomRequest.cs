using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class GetPatientsInRoomRequest : DataTableParameters
    {
        [JsonRequired] public string DepartmentCode { get; set; }

        public string PatientCode { get; set; }
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the patient.
        /// </summary>
        /// <value>
        ///     The name of the patient.
        /// </value>
        public string PatientName { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>
        ///     The start date.
        /// </value>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>
        ///     The end date.
        /// </value>
        public DateTime EndDate { get; set; }

        public string RegisteredCode { get; set; }
    }

    public class RemovePatientsInQueueRequest
    {
        [JsonRequired] public string DepartmentCode { get; set; }

        [JsonRequired] public Guid EmployeeId { get; set; }

        [JsonRequired] public string Reason { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class AddQueueNumberRequest
    {
        [JsonRequired] public string PatientCode { get; set; }

        [JsonRequired] public string Reason { get; set; }

        [JsonRequired] public string DepartmentCode { get; set; }

        [JsonRequired] public Guid EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class GetPatientsInEndoscopicRequest : PaginationFilter
    {
        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [FromQuery(Name = "department_code")]
        public string GroupCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [FromQuery(Name = "patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the patient.
        /// </summary>
        /// <value>
        ///     The name of the patient.
        /// </value>
        [FromQuery(Name = "patient_name")]
        public string PatientName { get; set; }

        /// <summary>
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>
        ///     The area code.
        /// </value>
        [FromQuery(Name = "area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        /// <value>
        ///     The start date.
        /// </value>
        [Required]
        [FromQuery(Name = "start_date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        /// <value>
        ///     The end date.
        /// </value>
        [Required]
        [FromQuery(Name = "end_date")]
        public DateTime EndDate { get; set; }

        [FromQuery(Name = "registered_code")] public string RegisteredCode { get; set; }
    }
}