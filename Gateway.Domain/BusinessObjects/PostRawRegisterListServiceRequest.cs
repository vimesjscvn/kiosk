using Newtonsoft.Json;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    public class PostRawRegisterListServiceRequest : BaseRawServiceRequest
    {
        /// <summary>
        /// Gets or sets the clinics.
        /// </summary>
        /// <value>
        /// The clinics.
        /// </value>
        [JsonRequired]
        [JsonProperty("clinics")]
        public List<ServiceRawDataModel> Clinics { get; set; }


        /// <summary>
        /// Gets or sets the medicines.
        /// </summary>
        /// <value>
        /// The medicines.
        /// </value>
        [JsonRequired]
        [JsonProperty("medicines")]
        public List<MedicineRawDataModel> Medicines { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PostRawRegisterListServiceResponse
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the service code.
        /// </summary>
        /// <value>
        /// The service code.
        /// </value>
        [JsonProperty("service_id")]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Gets the room code.
        /// </summary>
        /// <value>
        /// The room code.
        /// </value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets the type of the costs.
        /// </summary>
        /// <value>
        /// The type of the costs.
        /// </value>
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        [JsonProperty("department_name")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        /// The type of the patient.
        /// </value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }
    }
}
