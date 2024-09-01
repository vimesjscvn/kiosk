using System.ComponentModel;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    /// <summary>
    ///     OcrSettingBase
    /// </summary>
    public class OcrSettingBase
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        [DefaultValue("")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        [DefaultValue("")]
        public string TokenId { get; set; }

        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        [DefaultValue("")]
        public string TokenKey { get; set; }

        /// <summary>
        ///     Gets or sets the API key.
        /// </summary>
        /// <value>
        ///     The API key.
        /// </value>
        [DefaultValue("")]
        public string ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        [JsonRequired]
        public OcrType Type { get; set; }
    }

    /// <summary>
    ///     GetOcrSettingRequest
    /// </summary>
    public class GetOcrSettingRequest : DataTableParameters
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public OcrType? Type { get; set; }
    }

    public class ExportOcrSettingRequest
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public OcrType? Type { get; set; }
    }

    /// <summary>
    ///     AddOcrSettingRequest
    /// </summary>
    /// <seealso cref="CS.VM.Requests.OcrSettingBase" />
    public class AddOrUpdateOcrSettingRequest : OcrSettingBase
    {
    }

    /// <summary>
    ///     UpdateOcrSettingRequest
    /// </summary>
    /// <seealso cref="CS.VM.Requests.OcrSettingBase" />
    public class UpdateOcrSettingRequest : OcrSettingBase
    {
    }
}