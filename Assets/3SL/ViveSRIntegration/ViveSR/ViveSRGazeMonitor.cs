// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration {
    /// <summary>
    /// Singleton class to provide gaze data to multiple receivers via an event.
    /// </summary>
    public class ViveSRGazeMonitor : MonoBehaviour {
        public enum PollingStrategy {
            SeparateThread,
            Unity_Update,
            Unity_FixedUpdate,
        }

        private static ViveSRGazeMonitor instance;
        public static ViveSRGazeMonitor Instance => instance ?? (instance = FindObjectOfType<ViveSRGazeMonitor>() ?? new GameObject("[ViveSR Gaze Monitor]").AddComponent<ViveSRGazeMonitor>());

        [Tooltip("Use a separate thread to poll gaze data, increasing the sampling rate from ~90Hz to ~120Hz.\n" +
            "WARNING: if this setting is enabled, calling SRanipal_Eye.GetEyeData from the main Unity thread will cause a crash.")]
        [SerializeField] PollingStrategy pollingStrategy = PollingStrategy.SeparateThread;

        /// <summary>
        /// The most recently polled data point.
        /// </summary>
        public EyeData_v2 LatestEyeData { get; private set; }

        /// <summary>
        /// Emits every distinct <see cref="EyeData_v2"/> struct received by the <see cref="ViveSRGazeMonitor"/>.
        /// </summary>
        public event Action<EyeData_v2> OnEyeData;

        private bool didInit;

        private IGazeDataSource alternateSource;
        private bool HasNoAlternateData => alternateSource == null || alternateSource.ReachedEndOfData;

        private AsyncGazeCollector asyncGazeCollector = new AsyncGazeCollector();

        private void Awake() {
            if (instance != null && instance != this) throw new Exception($"Multiple {nameof(ViveSRGazeMonitor)}s present");
            instance = this;

            // Prevent the gaze monitor from being destroyed on scene transition
            DontDestroyOnLoad(gameObject);

            var frameworkComponent = FindObjectOfType<SRanipal_Eye_Framework>() ?? gameObject.AddComponent<SRanipal_Eye_Framework>();
            frameworkComponent.StartFramework();

            try {
                var status = SRanipal_Eye_Framework.Status;
                didInit = status == SRanipal_Eye_Framework.FrameworkStatus.WORKING;

                if (!didInit) {
                    Debug.LogError($"SRWorks framework initialization failed with status {status}");
                }
            } catch (Exception e) {
                // Happens when the DLL is missing
                Debug.LogException(e);
            }

            if (didInit && pollingStrategy == PollingStrategy.SeparateThread) {
                SetPollingThreadActive(true);
            }
        }

        private void Update() {
            PollInternal(pollingStrategy == PollingStrategy.Unity_Update);
        }

        private void FixedUpdate() {
            if (pollingStrategy == PollingStrategy.Unity_FixedUpdate) {
                Poll();
            }
        }

        // Allow polling thread to be enabled or disabled during play
        private void OnValidate() {
            // If we're in edit mode, or this component is not active, do nothing
            if (!Application.isPlaying || !isActiveAndEnabled) return;
            RefreshPollingThreadState(true);
        }


        private void OnEnable() => RefreshPollingThreadState(true);
        private void OnDisable() => RefreshPollingThreadState(false);
        private void OnApplicationPause(bool pause) => RefreshPollingThreadState(!pause);

        private void OnApplicationQuit() => DisposePollingThread();
        private void OnDestroy() => DisposePollingThread();

        private void RefreshPollingThreadState(bool monitorActive) {
            SetPollingThreadActive(monitorActive && pollingStrategy == PollingStrategy.SeparateThread);
        }

        private void SetPollingThreadActive(bool value) {
            if (!didInit) return;
            if (asyncGazeCollector.IsDisposed) return;
            asyncGazeCollector.SetDataCollectionActive(value);
        }

        private void DisposePollingThread() {
            asyncGazeCollector.Dispose();
        }

        /// <summary>
        /// Provide an alternate source of gaze data, which will be used instead of the ViveSR plugin until the source is empty
        /// </summary>
        /// <param name="src"></param>
        public void InjectAlternateData(IGazeDataSource src) {
            this.alternateSource = src;
        }

        /// <summary>
        /// Retrieve the most recently acquired gaze data point.
        /// </summary>
        /// <returns></returns>
        public EyeData_v2 GetCurrentGaze() {
            Poll();
            return LatestEyeData;
        }

        /// <summary>
        /// Poll all available sources of eye tracking data.
        /// Any relevant new <see cref="EyeData_v2"/> objects will be emitted to listeners of the <see cref="OnEyeData"/> event.
        /// </summary>
        public void Poll() {
            PollInternal(true);
        }

        private void PollInternal(bool mayFetchPluginData) {
            // Check for injected data, e.g. a replay of recorded gaze information
            if (!HasNoAlternateData) {
                VisitAlternateSource(alternateSource);
                FlushAsyncDataQueue(false); // Clear any realtime data
            } else if (didInit) {
                if (asyncGazeCollector.IsAccessingAPI) {
                    FlushAsyncDataQueue(true);
                } else if(mayFetchPluginData) {
                    FetchPluginData();
                }
            }
        }

        // Retrieve and clear any data points accumulated by the polling thread
        private void FlushAsyncDataQueue(bool emitEvents) {
            EyeData_v2 value;
            if (emitEvents) {
                while (asyncGazeCollector.Queue.TryDequeue(out value)) {
                    LatestEyeData = value;
                    OnEyeData?.Invoke(LatestEyeData);
                }
            } else {
                while (asyncGazeCollector.Queue.TryDequeue(out value)) { }
            }
        }

        // Get the latest data point on the main thread
        private void FetchPluginData() {
            // Skip if the API method might be in use by another thread
            if (asyncGazeCollector.IsAccessingAPI) return;

            var data = default(EyeData_v2);
            var err = SRanipal_Eye_API.GetEyeData_v2(ref data);

            if (err == ViveSR.Error.WORK) {
                if (LatestEyeData.frame_sequence == data.frame_sequence) {
                    return; // Skip duplicate frames
                }

                LatestEyeData = data;
                OnEyeData?.Invoke(LatestEyeData);
            } else {
                Debug.LogError($"{nameof(ViveSR.Error)} {err} returned by {nameof(SRanipal_Eye_API.GetEyeData_v2)}");
            }
        }

        private class AsyncGazeCollector : IDisposable {
            const int POLLING_INTERVAL_MS = 1;
            const int QUEUE_MAX_COUNT = 100;
            private CancellationTokenSource tokenSource;

            public ConcurrentQueue<EyeData_v2> Queue { get; } = new ConcurrentQueue<EyeData_v2>();

            private object runningFlagLock = new object();
            private bool runningFlag = false;

            public bool IsDisposed { get; private set; } = false;

            // Flag to improve thread safety
            public bool IsAccessingAPI { get; private set; }

            public void SetDataCollectionActive(bool value) {
                if (IsDisposed) throw new ObjectDisposedException(nameof(AsyncGazeCollector));

                lock (runningFlagLock) {
                    if (runningFlag == value) return;
                    runningFlag = value;
                }

                if (value) {
                    StartDataCollection();
                } else {
                    StopDataCollection();
                }
            }

            private void StartDataCollection() {
                tokenSource?.Dispose();
                tokenSource = new CancellationTokenSource();

                var token = tokenSource.Token;

                var top = default(EyeData_v2);
                var err = SRanipal_Eye_API.GetEyeData_v2(ref top);

                if (err != ViveSR.Error.WORK) {
                    throw new Exception("Error starting async data collection: " + err);
                }

                IsAccessingAPI = true;

                Task.Run(async () => {
                    EyeData_v2 val = default(EyeData_v2);
                    while (!token.IsCancellationRequested) {
                        if (
                            Queue.Count < QUEUE_MAX_COUNT &&
                            SRanipal_Eye_API.GetEyeData_v2(ref val) == ViveSR.Error.WORK &&
                            top.frame_sequence != val.frame_sequence
                        ) {
                            top = val;
                            Queue.Enqueue(val);
                        }
                        await Task.Delay(POLLING_INTERVAL_MS);
                    }
                    IsAccessingAPI = false;
                }, tokenSource.Token);
            }

            private void StopDataCollection() {
                tokenSource.Cancel();
            }

            public void Dispose() {
                if (IsDisposed) return;
                IsDisposed = true;
                tokenSource?.Cancel();
                tokenSource?.Dispose();
            }
        }

        private void VisitAlternateSource(IGazeDataSource source) {
            var data = default(EyeData_v2);
            while (source.TryGetNextDataPoint(ref data)) {
                LatestEyeData = data;
                OnEyeData?.Invoke(LatestEyeData);
            }
        }
    }
}