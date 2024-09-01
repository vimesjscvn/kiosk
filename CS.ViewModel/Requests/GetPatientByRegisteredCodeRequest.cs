using System;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class GetPatientByRegisteredCodeRequest
    {
        [JsonRequired] public string RegisteredCode { get; set; }

        public DateTime? RequestedDate { get; set; }
    }
}