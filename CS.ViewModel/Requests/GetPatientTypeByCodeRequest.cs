using System;

namespace CS.VM.Requests
{
    public class GetPatientTypeByCodeRequest
    {
        public string PatientCode { get; set; }
        public string RegisteredCode { get; set; }
        public DateTime? RequestedDate { get; set; }
    }
}