using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetRawAllFeeRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    ///     Class GetAllClinicFeeResponse.
    /// </summary>
    public class GetRawAllFeeResponse : BaseRawResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetRawAllFeeResponse" /> class.
        /// </summary>
        public GetRawAllFeeResponse()
        {
            Clinics = new List<GetRawAllClinicFeeResponseData>();
            Medicines = new List<GetRawAllMedicineFeeResponseData>();
            InsuranceMedicines = new List<GetRawAllPrescriptionFeeResponseData>();
        }

        /// <summary>
        ///     Gets or sets the danh sach tat toan.
        /// </summary>
        /// <value>The danh sach tat toan.</value>
        [JsonProperty("clinics")]
        public List<GetRawAllClinicFeeResponseData> Clinics { get; set; }

        /// <summary>
        ///     Gets or sets the data thuoc.
        /// </summary>
        /// <value>The data thuoc.</value>
        [JsonProperty("medicines")]
        public List<GetRawAllMedicineFeeResponseData> Medicines { get; set; }

        /// <summary>
        ///     Gets or sets the data thuoc.
        /// </summary>
        /// <value>The data thuoc.</value>
        [JsonProperty("insurance_medicines")]
        public List<GetRawAllPrescriptionFeeResponseData> InsuranceMedicines { get; set; }

        /// <summary>
        ///     Gets or sets the is finished.
        /// </summary>
        /// <value>
        ///     The is finished.
        /// </value>
        [JsonProperty("is_finished")]
        public int IsFinished { get; set; }

        [JsonProperty("patient_code")] public string PatientCode { get; set; }

        [JsonProperty("registered_code")] public string RegisteredCode { get; set; }

        [JsonProperty("patient_type")] public string PatientType { get; set; }

        [JsonProperty("registered_date")] public DateTime RegisteredDate { get; set; }
    }

    /// <summary>
    ///     Class GetAllClinicFeeResponseData.
    /// </summary>
    public class GetRawAllClinicFeeResponseData : GetRawClinicListResponseData
    {
    }

    /// <summary>
    ///     Class GetAllMedicineFeeResponseData.
    /// </summary>
    public class GetRawAllMedicineFeeResponseData : GetRawListPrescriptionResponseData
    {
    }

    /// <summary>
    ///     Class GetAllMedicineFeeResponseData.
    /// </summary>
    public class GetRawAllPrescriptionFeeResponseData : GetRawListPrescriptionResponseData
    {
    }
}