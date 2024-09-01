using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class RegisterListServiceRequest : BaseServiceRequest
    {
        [JsonRequired]
        [JsonProperty("clinics")]
        public List<ServiceDataModel> Data { get; set; }

        [JsonRequired]
        [JsonProperty("medicines")]
        public List<MedicineDataModel> DataThuoc { get; set; }
    }
}