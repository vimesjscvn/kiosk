// ***********************************************************************
// Assembly         : CS.SignalRClient
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="MessageHandler.cs" company="CS.SignalRClient">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.SignalRClient
{
    /// <summary>
    ///     Enum MessageAction
    /// </summary>
    public enum MessageAction
    {
        /// <summary>
        ///     The send
        /// </summary>
        SEND,

        /// <summary>
        ///     The delete
        /// </summary>
        DELETE,

        /// <summary>
        ///     The check connection
        /// </summary>
        CHECK_CONNECTION
    }

    /// <summary>
    ///     Class MessageHandler.
    /// </summary>
    public class MessageHandler
    {
        /// <summary>
        ///     Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public MessageAction Action { get; set; }

        /// <summary>
        ///     Gets or sets the signalr request.
        /// </summary>
        /// <value>The signalr request.</value>
        public SignalrRequest SignalrRequest { get; set; }
    }
}