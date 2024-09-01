// ***********************************************************************
// Assembly         : CS.SignalRClient
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SignalrRequest.cs" company="CS.SignalRClient">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace CS.SignalRClient
{
    /// <summary>
    ///     Class SignalrRequest.
    /// </summary>
    public class SignalrRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SignalrRequest" /> class.
        /// </summary>
        public SignalrRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignalrRequest" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="receiver">The receiver.</param>
        public SignalrRequest(Data data, string receiver)
        {
            ID = Guid.NewGuid();
            Data = data;
            SentTime = 0;
            Receiver = receiver;
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid ID { get; set; }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public Data Data { get; set; }

        /// <summary>
        ///     Gets or sets the sent time.
        /// </summary>
        /// <value>The sent time.</value>
        public int SentTime { get; set; }

        /// <summary>
        ///     Gets or sets the receiver.
        /// </summary>
        /// <value>The receiver.</value>
        public string Receiver { get; set; }
    }

    /// <summary>
    ///     Class Data.
    /// </summary>
    public class Data
    {
        /// <summary>
        ///     Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public object body { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string title { get; set; }
    }
}