// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace Three.Common {
    public class LogQueue : ILogReceiver {
        public enum LogCategory {
            Standard,
            Error,
        }

        private class LogMessage {
            public LogCategory Category { get; }
            public string Message { get; }

            public LogMessage(LogCategory category, string message) {
                Category = category;
                Message = message;
            }
        }

        private ConcurrentQueue<LogMessage> messages = new ConcurrentQueue<LogMessage>();

        public void Log(string s) => messages.Enqueue(new LogMessage(LogCategory.Standard, s));
        public void LogException(Exception e) => messages.Enqueue(new LogMessage(LogCategory.Error, e.ToString()));


        /// <summary>
        /// Call this on the main Unity thread to write all enqueued messages to the console.
        /// This allows us to include frame timing information with messages that were generated off-thread.
        /// </summary>
        public void Visit() {
            LogMessage msg;
            while (messages.TryDequeue(out msg)) {
                switch (msg.Category) {
                    case LogCategory.Standard:
                        Debug.Log($"[{Time.frameCount}] {msg.Message}");
                        break;
                    case LogCategory.Error:
                        Debug.LogError($"[{Time.frameCount}] {msg.Message}");
                        break;
                }
            }
        }
    }
}