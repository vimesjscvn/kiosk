using CS.Base.ViewModels.Requests;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    /// <summary>
    ///     Class ChangeCheckedRequest.
    ///     Implements the <see cref="BaseRequest" />
    /// </summary>
    /// <seealso cref="BaseRequest" />
    public class ChangeCheckedRequest : BaseRequest
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is checked.
        /// </summary>
        /// <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        [JsonRequired]
        public bool IsChecked { get; set; }
    }
}