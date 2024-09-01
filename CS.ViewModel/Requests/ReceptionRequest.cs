using System;
using CS.Base.ViewModels.Requests;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class ReceptionRequest : DataTableParameters
    {
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RegisteredCode { get; set; }
        public ReceptionType? Type { get; set; }
        public string EmployeeName { get; set; }
    }

    public class ChangeFinishedRequest : BaseRequest
    {
        public bool? IsFinished { get; set; }

        [JsonRequired] public string Reason { get; set; }

        [JsonRequired] public Guid EmployeeId { get; set; }
    }
}