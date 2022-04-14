// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Three.Common {
    /// <summary>
    /// An asynchronous TCP server that can broadcast 
    /// Can accept multiple client connections.
    /// </summary>
    public class SimpleTcpBroadcastServer : IDisposable {

        /// <summary>
        /// Wraps a single client connection and an associated output message queue.
        /// </summary>
        private class Sender : IDisposable {
            private const int LOOP_INTERVAL = 10; // milliseconds to wait between queue polling attempts

            private readonly ConcurrentQueue<byte[]> messages = new ConcurrentQueue<byte[]>();
            private readonly TcpClient client;
            private readonly SimpleTcpBroadcastServer parentServer;
            private readonly CancellationTokenSource disposalTokenSource;
            
            public Sender(SimpleTcpBroadcastServer parentServer, TcpClient client) {
                this.parentServer = parentServer;
                this.client = client;
                this.disposalTokenSource = new CancellationTokenSource();
                parentServer.OnMessage += messages.Enqueue;
            }

            public async Task LoopAsync(CancellationToken token) {
                var stream = client.GetStream();
                byte[] next;
                using (var loopTokenSource = CancellationTokenSource.CreateLinkedTokenSource(this.disposalTokenSource.Token, token)) { 
                    while (client.Connected && !loopTokenSource.Token.IsCancellationRequested) {
                        while (messages.TryDequeue(out next)) {
                            try {
                                await stream.WriteAsync(next, 0, next.Length, loopTokenSource.Token);
                            } catch (Exception e) {
                                parentServer?.logReceiver?.LogException(e);
                            }
                        }
                        await Task.Delay(LOOP_INTERVAL, loopTokenSource.Token);
                    }
                }
            }

            public void Dispose() {
                disposalTokenSource.Cancel();
                disposalTokenSource.Dispose();
                parentServer.OnMessage -= messages.Enqueue;
                client.Close();
            }
        }

        private readonly TcpListener listener;

        /// <summary>
        /// Internal event used to provide serialized messages to other threads.
        /// </summary>
        private event Action<byte[]> OnMessage;

        /// <summary>
        /// Optional destination for log info.
        /// </summary>
        private ILogReceiver logReceiver;
        
        private bool isRunning;
        private bool disposed;

        private readonly CancellationTokenSource disposalTokenSource;
        private CancellationTokenSource stopTokenSource;

        /// <summary>
        /// Create a new server on the specified port.
        /// </summary>
        /// <param name="port"></param>
        public SimpleTcpBroadcastServer(IPAddress address, int port) {
            this.listener = new TcpListener(address, port);
            this.disposalTokenSource = new CancellationTokenSource();
        }

        public void SetLogger(ILogReceiver logReceiver) {
            if (disposed) throw new ObjectDisposedException(typeof(SimpleTcpBroadcastServer).Name);
            this.logReceiver = logReceiver;
        }

        /// <summary>
        /// Send the provided message to all current listeners.
        /// Uses ASCII encoding.
        /// </summary>
        /// <param name="message"></param>
        public void Broadcast(string message) {
            if (disposed) return;
            OnMessage?.Invoke(Encoding.ASCII.GetBytes(message));
        }

        /// <summary>
        /// Send the provided message to all current listeners.
        /// The <paramref name="message"/> byte array will be used by reference, so you should avoid editing it after calling this method.
        /// </summary>
        /// <param name="message"></param>
        public void Broadcast(byte[] message) {
            if (disposed) return;
            OnMessage?.Invoke(message);
        }

        /// <summary>
        /// Start listening for new clients.
        /// </summary>
        public void Open() {
            if (disposed) throw new ObjectDisposedException(typeof(SimpleTcpBroadcastServer).Name);
            if (isRunning) throw new InvalidOperationException("Server is already running");
            isRunning = true;
            stopTokenSource = CancellationTokenSource.CreateLinkedTokenSource(disposalTokenSource.Token);
            Task.Run(()=>Receive(stopTokenSource.Token));
        }

        /// <summary>
        /// Stop listening for new clients and close all existing client connections.
        /// </summary>
        public void Close() {
            if (disposed) return;
            stopTokenSource?.Cancel();
            stopTokenSource?.Dispose();
            stopTokenSource = null;
        }

        public void Dispose() {
            if (disposed) return;
            Close();
            disposed = true;
            disposalTokenSource.Cancel();
            disposalTokenSource.Dispose();
        }

        private async Task Receive(CancellationToken token) {
            logReceiver?.Log($"TCP broadcast server listening for clients on {listener.LocalEndpoint}");
            try {
                listener.Start();
                while (!token.IsCancellationRequested) {
                    var client = await listener.AcceptTcpClientAsync();
                    logReceiver?.Log($"Received client connection from {client.Client.RemoteEndPoint}");
                    var sender = new Sender(this, client);

                    // Start sender loop on new fire-and-forget task with same token
                    var _ = Task.Run(async () => {
                        await sender.LoopAsync(token);
                        sender.Dispose();
                    });
                }
            } catch (Exception e) {
                logReceiver?.LogException(e);
            } finally {
                logReceiver?.Log($"Stopping TCP server");
                listener.Stop();
                isRunning = false;
            }
        }

    }
}