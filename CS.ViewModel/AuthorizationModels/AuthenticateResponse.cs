using System;
using CS.EF.Models;
using Newtonsoft.Json;

namespace CS.VM.AuthorizationModels
{
    /// <summary>
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticateResponse" /> class.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="token">The token.</param>
        public AuthenticateResponse(SysUser user, string token)
        {
            Id = user.Id;
            FullName = user.FullName;
            Phone = user.Phone;
            Token = token;
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>
        ///     The phone.
        /// </value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     Gets or sets the token.
        /// </summary>
        /// <value>
        ///     The token.
        /// </value>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}