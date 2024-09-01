using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class PostRawCancelListServiceRequest : BaseRawServiceRequest
    {
        /// <summary>
        ///     Gets or sets the clinics.
        /// </summary>
        /// <value>
        ///     The clinics.
        /// </value>
        [JsonRequired]
        [JsonProperty("clinics")]
        public List<ServiceRawDataModel> Clinics { get; set; }


        /// <summary>
        ///     Gets or sets the medicines.
        /// </summary>
        /// <value>
        ///     The medicines.
        /// </value>
        [JsonRequired]
        [JsonProperty("medicines")]
        public List<MedicineRawDataModel> Medicines { get; set; }
    }

    public class PostRawCancelListServiceResponse
    {
    }
}