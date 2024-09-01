using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class CheckTableUniqueRequest
    {
        /// <summary>
        ///     Gets or sets the table code.
        /// </summary>
        /// <value>
        ///     The table code.
        /// </value>
        [JsonRequired]
        public string TableCode { get; set; }

        /// <summary>
        ///     Gets or sets the pc ip.
        /// </summary>
        /// <value>
        ///     The pc ip.
        /// </value>
        public string ComputerIP { get; set; }
    }
}