using System;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class DeviceBaseRequest
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        [JsonRequired]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>
        ///     The ip.
        /// </value>
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the room identifier.
        /// </summary>
        /// <value>
        ///     The room identifier.
        /// </value>
        [JsonRequired]
        public Guid RoomId { get; set; }
    }

    public class AddDeviceRequest : DeviceBaseRequest
    {
    }

    public class UpdateDeviceRequest : DeviceBaseRequest
    {
    }

    public class GetAllDeviceRequest : DataTableParameters
    {
    }
}