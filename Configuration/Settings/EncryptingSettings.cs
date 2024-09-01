using Core.Config.Configs;

namespace Core.Config.Settings
{
    /// <summary>
    ///     Class EncryptingSettings. This class cannot be inherited.
    /// </summary>
    public sealed class EncryptingSettings
    {
        /// <summary>
        ///     Gets or sets the encrypting.
        /// </summary>
        /// <value>The encrypting.</value>
        public EncryptingConfig Encrypting { get; set; }
    }
}