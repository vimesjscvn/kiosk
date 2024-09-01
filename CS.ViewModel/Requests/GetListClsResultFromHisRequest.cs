using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class GetListClsResultFromHisRequest
    {
        [JsonProperty("MaBenhVien")] public string HospitalCode { get; set; }

        [JsonProperty("MaQuanLy")] public string ManagedCode { get; set; }

        [JsonProperty("LoaiBenhNhan")] public string PatientType { get; set; }

        [JsonProperty("MaBenhNhan")] public string PatientCode { get; set; }

        [JsonProperty("SoTiepNhan")] public string RegisteredCode { get; set; }
    }
}