using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class CreateOrUpdateSettingDepartmentRequest
    {
        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>
        ///     The ip.
        /// </value>
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [JsonRequired]
        public DepartmentType Type { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        [JsonRequired]
        public string Code { get; set; }
    }
}