using CS.VM.ClinicModels;
using CS.VM.External.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CS.VM.External.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class PostRawClinicRegistrationRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseExternalResponse" />
    public class PostRawClinicRegistrationResponse : BaseExternalResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<ClinicPostModel> Data { get; set; }
    }
}
