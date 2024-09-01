using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetRawFinallyClinicListRequest : BaseRawRequest
    {
        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>
        /// The registered code.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    /// Class GetFinallyClinicListResponse.
    /// </summary>
    public class GetRawFinallyClinicListResponse : BaseRawResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRawFinallyClinicListResponse"/> class.
        /// </summary>
        public GetRawFinallyClinicListResponse()
        {
            Clinics = new List<GetRawFinallyClinicListResponseData>();
            Medicines = new List<GetRawFinallyListPrescriptionResponseData>();
            InsuranceMedicines = new List<GetRawFinallyPrescriptionListResponseData>();
        }

        /// <summary>
        /// Gets or sets the danh sach tat toan.
        /// </summary>
        /// <value>The danh sach tat toan.</value>
        [JsonProperty("clinics")]
        public List<GetRawFinallyClinicListResponseData> Clinics { get; set; }

        /// <summary>
        /// Gets or sets the data thuoc.
        /// </summary>
        /// <value>The data thuoc.</value>
        [JsonProperty("medicines")]
        public List<GetRawFinallyListPrescriptionResponseData> Medicines { get; set; }

        /// <summary>
        /// Gets or sets the data thuoc.
        /// </summary>
        /// <value>The data thuoc.</value>
        [JsonProperty("insurance_medicines")]
        public List<GetRawFinallyPrescriptionListResponseData> InsuranceMedicines { get; set; }

        /// <summary>
        /// Gets or sets the is finished.
        /// </summary>
        /// <value>
        /// The is finished.
        /// </value>
        [JsonProperty("is_finished")]
        public int IsFinished { get; set; }
    }

    /// <summary>
    /// Class GetFinallyClinicListResponseData.
    /// </summary>
    public class GetRawFinallyClinicListResponseData : GetRawClinicListResponseData
    {
    }

    /// <summary>
    /// Class GetFinallyListPrescriptionResponseData.
    /// </summary>
    public class GetRawFinallyListPrescriptionResponseData : GetRawListPrescriptionResponseData
    {
    }
}
