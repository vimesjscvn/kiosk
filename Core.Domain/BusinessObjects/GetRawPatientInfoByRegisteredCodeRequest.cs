using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class GetRawPatientInfoByRegisteredCodeRequest
    {
        [JsonProperty("hospital_code")] public string HospitalCode { get; set; }

        [JsonProperty("management_id")] public string ManagementId { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }
    }
}