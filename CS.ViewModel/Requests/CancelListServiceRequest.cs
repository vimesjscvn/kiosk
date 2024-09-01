using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class CancelListServiceRequest : BaseServiceRequest
    {
        /// <summary>
        ///     Gets or sets the clinics.
        /// </summary>
        /// <value>
        ///     The clinics.
        /// </value>
        [JsonRequired]
        [JsonProperty("clinics")]
        public List<ServiceDataModel> Clinics { get; set; }


        /// <summary>
        ///     Gets or sets the medicines.
        /// </summary>
        /// <value>
        ///     The medicines.
        /// </value>
        [JsonRequired]
        [JsonProperty("medicines")]
        public List<MedicineDataModel> Medicines { get; set; }
    }
}