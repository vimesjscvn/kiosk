// ***********************************************************************
// Assembly         : CS.SignalRClient
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ThreadQueueHelper.cs" company="CS.SignalRClient">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Concurrent;
using System.Threading;

namespace CS.SignalRClient
{
    /// <summary>
    ///     Class ThreadQueueHelper.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadQueueHelper<T> where T : class
    {
        /// <summary>
        ///     The action
        /// </summary>
        private readonly Action<T> _action;

        /// <summary>
        ///     The wait handle
        /// </summary>
        private readonly EventWaitHandle _waitHandle = new AutoResetEvent(false);

        /// <summary>
        ///     The queue
        /// </summary>
        private ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

        /// <summary>
        ///     The is running
        /// </summary>
        private bool isRunning;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadQueueHelper{T}" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ThreadQueueHelper(Action<T> action)
        {
            _action = action;
            isRunning = true;
            var workerThread = new Thread(ProcessOutgoing)
            {
                IsBackground = true
            };

            workerThread.Start();
        }

        /// <summary>
        ///     Enqueues the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Enqueue(T obj)
        {
            _queue.Enqueue(obj);
            if (isRunning) _waitHandle.Set();
        }

        /// <summary>
        ///     Pauses this instance.
        /// </summary>
        public void Pause()
        {
            isRunning = false;
        }

        /// <summary>
        ///     Resumes this instance.
        /// </summary>
        public void Resume()
        {
            isRunning = true;
            _waitHandle.Set();
        }


        /// <summary>
        ///     Processes the outgoing.
        /// </summary>
        private void ProcessOutgoing()
        {
            while (true)
            {
                if (!isRunning) _waitHandle.WaitOne();
                if (!_queue.TryDequeue(out var obj))
                    //if data was not found (meaning list is empty) then wait till something is added to it
                    _waitHandle.WaitOne();

                if (obj != null)
                    try
                    {
                        _action(obj);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
            }
        }

        /// <summary>
        ///     Gets the length of the queue.
        /// </summary>
        /// <param name="firstItem">The first item.</param>
        /// <returns>System.Int32.</returns>
        public int GetQueueLength(out T firstItem)
        {
            return _queue.TryPeek(out firstItem) ? _queue.Count : 0;
        }

        /// <summary>
        ///     Clears the queue.
        /// </summary>
        public void ClearQueue()
        {
            _queue = new ConcurrentQueue<T>();
        }
    }
}