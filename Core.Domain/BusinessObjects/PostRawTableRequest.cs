using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class PostRawTableResponse
    {
        /// <summary>
        ///     Gets or sets the device code.
        /// </summary>
        /// <value>The device code.</value>
        [JsonProperty("device")]
        public string DeviceCode { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public TablePriorityType Type { get; set; }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        [JsonProperty("device_type")]
        public int DeviceType { get; set; }

        /// <summary>
        ///     Gets or sets the computer ip.
        /// </summary>
        /// <value>The computer ip.</value>
        [JsonProperty("pc_ip")]
        public string ComputerIP { get; set; }

        /// <summary>
        ///     Gets or sets the area code.
        /// </summary>
        /// <value>
        ///     The area code.
        /// </value>
        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        ///     Gets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets the store.
        /// </summary>
        /// <value>
        ///     The store.
        /// </value>
        [JsonProperty("store")]
        public int Store { get; set; }
    }

    public class PostRawTableRequest
    {
        public string HospitalCode { get; set; }

        public string DepartmentCode { get; set; }
    }

    /// <summary>
    ///     Priority Type
    /// </summary>
    public enum TablePriorityType
    {
        /// <summary>
        ///     The Normal
        /// </summary>
        Normal,

        /// <summary>
        ///     The priority
        /// </summary>
        Priority
    }
}