using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawUpdateObjectTypeResponse : BaseRawResponse
    {
        public string PatientCode { get; set; }

        public string PatientType { get; set; }

        public string PatientTypeCode { get; set; }

        public string RegisteredCode { get; set; }

        public string ManagementId { get; set; }
    }

    public class PostRawUpdateObjectTypeRequest : BaseRawRequest
    {
        public string HospitalCode { get; set; }

        public string PatientType { get; set; }

        public string PatientTypeCode { get; set; }

        public string RegisteredCode { get; set; }

        public string ManagementId { get; set; }

        public string Ip { get; set; }
    }
}
