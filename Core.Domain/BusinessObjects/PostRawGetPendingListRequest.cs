using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class PostRawGetPendingListRequest
    {
        [JsonProperty("group_dept_code")] public string GroupDeptCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }
    }

    public class GetRawPendingListData
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("order_number")] public string OrderNumber { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("age")] public string Age { get; set; }

        [JsonProperty("gender")] public int Gender { get; set; }

        [JsonProperty("waiting_patient")] public List<GetRawPendingListPatientData> WaitingPatient { get; set; }

        [JsonProperty("missing_patient")] public List<GetRawPendingListPatientData> MissingPatient { get; set; }
    }

    public class GetRawPendingListPatientData
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("order_number")] public string OrderNumber { get; set; }

        [JsonProperty("full_name")] public string FullName { get; set; }

        [JsonProperty("age")] public string Age { get; set; }

        [JsonProperty("gender")] public int Gender { get; set; }
    }

    public class GetRawPendingListResponse : BaseRawResponse
    {
        public GetRawPendingListData Result { get; set; }
    }
}