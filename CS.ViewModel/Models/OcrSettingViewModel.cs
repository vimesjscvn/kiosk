using System;
using CS.Common.Common;

namespace CS.VM.Models
{
    /// <summary>
    ///     OcrSettingViewModel
    /// </summary>
    public class OcrSettingViewModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        public OcrType Type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public OcrSettingValue Value { get; set; }
    }

    /// <summary>
    ///     OcrSettingValue
    /// </summary>
    public class OcrSettingValue
    {
        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        public string TokenId { get; set; }

        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        public string TokenKey { get; set; }

        /// <summary>
        ///     Gets or sets the API key.
        /// </summary>
        /// <value>
        ///     The API key.
        /// </value>
        public string ApiKey { get; set; }
    }
}