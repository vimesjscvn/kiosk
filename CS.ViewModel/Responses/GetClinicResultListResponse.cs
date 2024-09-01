using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Responses
{
    public class GetListClsResultResponse
    {
        [JsonProperty("examination_rooms")]
        public List<ExaminationRoomResultViewModel> examinationRoomResults { get; set; } =
            new List<ExaminationRoomResultViewModel>();
    }

    public class ExaminationRoomResultViewModel
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("department_name")] public string DepartmentName { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("is_result")] public bool IsResult { get; set; }

        [JsonProperty("clinics")]
        public List<ExaminationRoomClinicResultViewModel> ClinicResults { get; set; } =
            new List<ExaminationRoomClinicResultViewModel>();
    }

    public class ExaminationRoomClinicResultViewModel
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("service_name")] public string ServiceName { get; set; }

        [JsonProperty("is_result")] public bool IsResult { get; set; }
    }
}