// ***********************************************************************
// Assembly         : CS.SignalRClient
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SignalrService.cs" company="CS.SignalRClient">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace CS.SignalRClient
{
    /// <summary>
    ///     Class SignalrService.
    /// </summary>
    public class SignalrService
    {
        /// <summary>
        ///     The instance
        /// </summary>
        private static SignalrService instance;

        public readonly string URL = "http://localhost:8090/sockethub";

        /// <summary>
        ///     The queue processor
        /// </summary>
        private ThreadQueueHelper<MessageHandler> _queueProcessor;

        private HubConnection hubConnection;

        /// <summary>
        ///     The is connected
        /// </summary>
        private bool isConnected;

        /// <summary>
        ///     The is stopped
        /// </summary>
        private bool isStopped;

        /// <summary>
        ///     The requests
        /// </summary>
        private readonly Dictionary<string, SignalrRequest> requests;

        /// <summary>
        ///     Prevents a default instance of the <see cref="SignalrService" /> class from being created.
        /// </summary>
        private SignalrService()
        {
            requests = new Dictionary<string, SignalrRequest>();
        }

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static SignalrService Instance
        {
            get
            {
                if (instance == null) instance = new SignalrService();
                return instance;
            }
        }

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            hubConnection = new HubConnectionBuilder().WithUrl(URL).Build();
            hubConnection.Closed += async error =>
            {
                isConnected = false;
                if (!isStopped)
                {
                    if (error != null) Console.WriteLine(error.StackTrace);
                    _queueProcessor.Pause();
                    while (!await StartSignalrService()) Console.WriteLine("SIGNALR: Reconnect Fail");
                    Console.WriteLine("SIGNALR: Reconnected");
                    _queueProcessor.Resume();
                }
                else
                {
                    Console.WriteLine("SIGNALR: Stop service");
                }
            };

            hubConnection.On<string>("CheckLostClientReceive", message =>
            {
                try
                {
                    _queueProcessor.Enqueue(new MessageHandler
                    {
                        Action = MessageAction.DELETE,
                        SignalrRequest = new SignalrRequest
                        {
                            ID = Guid.Parse(message)
                        }
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });

            hubConnection.On<string, string>("ClientReceiveFromBe", (from, data) =>
            {
                try
                {
                    var request = JsonConvert.DeserializeObject<SignalrRequest>(data);
                    Console.WriteLine("SIGNALR: RECEIVED " + request.ID);
                    if (request.Data.title == "CheckConnection")
                        // _queueProcessor.Enqueue(new MessageHandler()
                        // {
                        //     action = MessageAction.DELETE,
                        //     signalrRequest = new SignalrRequest()
                        //     {
                        //         ID = request.ID
                        //     }
                        // });
                        RemoveRequest(request.ID.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });


            _queueProcessor = new ThreadQueueHelper<MessageHandler>(HandleAction);
        }

        /// <summary>
        ///     Starts the signalr service.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public async Task<bool> StartSignalrService()
        {
            try
            {
                await hubConnection.StartAsync();
                // String _conId = hubConnection.getConnectionId();
                Console.WriteLine("SIGNALR: Connected: ");
                await hubConnection.InvokeAsync("InitDevice", "", "AdminBVK");
                isStopped = false;
                isConnected = true;
                return true;
            }

            catch (Exception error)
            {
                Console.WriteLine("SIGNALR: Connect fail" + error.StackTrace);
                return false;
            }
        }

        /// <summary>
        ///     Stops the signalr service.
        /// </summary>
        public async void StopSignalrService()
        {
            await hubConnection.StopAsync();
            isStopped = true;
        }

        /// <summary>
        ///     Sends the message.
        /// </summary>
        /// <param name="request">The request.</param>
        public void SendMessage(SignalrRequest request)
        {
            if (request != null)
                try
                {
                    _queueProcessor.Enqueue(new MessageHandler
                    {
                        Action = MessageAction.SEND,
                        SignalrRequest = request
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("SIGNALR: MsgSendFail");
                    Console.WriteLine(e.Message);
                }
        }

        /// <summary>
        ///     Sends the request.
        /// </summary>
        /// <param name="request">The request.</param>
        private async void SendRequest(SignalrRequest request)
        {
            async void onConnectionTimerElapsed(object source, ElapsedEventArgs e)
            {
                try
                {
                    Console.WriteLine("SIGNALR CONNECTION " + request.ID);
                    _queueProcessor.Pause();
                    _queueProcessor.Enqueue(new MessageHandler
                    {
                        Action = MessageAction.SEND,
                        SignalrRequest = request
                    });
                    if (isConnected)
                    {
                        isConnected = false;
                        Initialize();
                        while (!await StartSignalrService()) Console.WriteLine("SIGNALR: Reconnect Fail");
                        Console.WriteLine("SIGNALR: Reconnected");
                        _queueProcessor.Resume();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void onRetryTimerElapsed(object source, ElapsedEventArgs e)
            {
                try
                {
                    if (requests.ContainsKey(request.ID.ToString()))
                    {
                        var retryRequest = requests[request.ID.ToString()];
                        if (retryRequest.SentTime < 3)
                        {
                            Console.WriteLine("SIGNALR: Resend " + request.ID);
                            _queueProcessor.Enqueue(new MessageHandler
                            {
                                Action = MessageAction.SEND,
                                SignalrRequest = retryRequest
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                if (requests != null && isConnected)
                {
                    if (!requests.ContainsKey(request.ID.ToString())) requests.Add(request.ID.ToString(), request);

                    try
                    {
                        requests[request.ID.ToString()].SentTime++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (!isConnected)
                {
                    _queueProcessor.Enqueue(new MessageHandler
                    {
                        Action = MessageAction.SEND,
                        SignalrRequest = request
                    });
                    return;
                }

                var disconnectTimer = new Timer
                {
                    Interval = 5000,
                    AutoReset = false
                };
                disconnectTimer.Enabled = true;
                disconnectTimer.Elapsed += onConnectionTimerElapsed;
                disconnectTimer.Start();

                await hubConnection.InvokeAsync("PushDataBe", "AdminBVCR", request.Receiver,
                    JsonConvert.SerializeObject(request));
                Console.WriteLine("SIGNALR: MsgSent " + request.ID);
                disconnectTimer.Stop();


                var retryTimer = new Timer
                {
                    Interval = 2000,
                    AutoReset = false
                };
                retryTimer.Enabled = true;
                retryTimer.Elapsed += onRetryTimerElapsed;
                retryTimer.Start();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        /// <summary>
        ///     Removes the request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        private void RemoveRequest(string requestId)
        {
            if (requests.ContainsKey(requestId))
            {
                Console.WriteLine("SIGNALR: Remove " + requestId);
                requests.Remove(requestId);
            }
        }

        /// <summary>
        ///     Handles the action.
        /// </summary>
        /// <param name="message">The message.</param>
        public void HandleAction(MessageHandler message)
        {
            if (message.Action == MessageAction.SEND)
                SendRequest(message.SignalrRequest);
            else if (message.Action == MessageAction.DELETE) RemoveRequest(message.SignalrRequest.ID.ToString());
        }
    }
}