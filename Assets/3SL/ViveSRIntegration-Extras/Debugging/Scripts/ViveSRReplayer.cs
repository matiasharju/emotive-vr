// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using Three.ViveSRIntegration.Serialization;
using ProtoBuf;
using System;
using System.IO;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Testing {
    /// <summary>
    /// Component class that can read a sequence of <see cref="RecordedEyeDataWrapper"/> messages from a binary file and inject them into the <see cref="ViveSRGazeMonitor"/>.
    /// </summary>
    public class ViveSRReplayer : MonoBehaviour {
        private class PlaybackInstance : IGazeDataSource, IDisposable {
            private readonly Stream stream;
            private readonly DateTime start;

            public bool ReachedEndOfData { get; private set; }

            public event Action OnPlayedToEnd;

            private RecordedEyeDataWrapper_v2 nextMsg;

            private long captureTimeOffset;

            private bool hadFirst = false;

            public long EarliestCaptureTime { get; private set; }
            public long LatestCaptureTime { get; private set; }

            public PlaybackInstance(Func<Stream> streamGenerator, long captureTimeOffset = 0) {
                ViveSRSerializationHelper.InitializeSurrogates();
                this.stream = streamGenerator();
                this.start = DateTime.UtcNow;
                this.captureTimeOffset = captureTimeOffset;
                Advance();
            }

            public bool TryGetNextDataPoint(ref EyeData_v2 data) {
                if (ReachedEndOfData || nextMsg.RecordTimeTicks > (DateTime.UtcNow - start).Ticks) {
                    data = default(EyeData_v2);
                    return false;
                } else {
                    data = nextMsg.Data;//.ToSourceFormat();
                    data.timestamp /= 1000;
                    Advance();
                    return true;
                }
            }

            private void Advance() {
                try {
                    if (stream.Position < stream.Length) {
                        var m = Serializer.DeserializeWithLengthPrefix<RecordedEyeDataWrapper_v2>(stream, PrefixStyle.Base128, 1);
                        //m.Data.CaptureTime += captureTimeOffset;
                        if (!hadFirst) {
                            hadFirst = true;
                            //EarliestCaptureTime = m.Data.CaptureTime;
                        }
                        //LatestCaptureTime = Math.Max(LatestCaptureTime, m.Data.CaptureTime);
                        nextMsg = m;
                    } else {
                        ReachedEndOfData = true;
                        OnPlayedToEnd?.Invoke();
                    }
                } catch (Exception e) {
                    Debug.LogException(e);
                    ReachedEndOfData = true;
                } finally {
                    if (ReachedEndOfData) {
                        stream.Close();
                    }
                }
            }

            public void Dispose() {
                ReachedEndOfData = true;
                stream.Dispose();
            }
        }


        // This should be a binary asset with file extension ".bytes"
        [SerializeField] TextAsset binaryData;

        [SerializeField] KeyCode toggleKey = KeyCode.P;
        [SerializeField] bool playOnStart;
        [SerializeField] bool loop;

        private bool playing;
        private Coroutine coroutine;
        private PlaybackInstance playbackInstance;

        private void Start() {
            if (playOnStart) StartPlayback();
        }

        private void Update() {
            if (Input.GetKeyDown(toggleKey)) {
                if (playing) {
                    StopPlayback();
                } else {
                    StartPlayback();
                }
            }
        }

        private void OnDestroy() {
            StopPlayback();
        }

        private void StartPlayback(long captureTimeOffset = 0) {
            playing = true;
            this.playbackInstance = new PlaybackInstance(()=>new MemoryStream(binaryData.bytes), captureTimeOffset);
            playbackInstance.OnPlayedToEnd += HandlePlayedToEnd;
            ViveSRGazeMonitor.Instance.InjectAlternateData(playbackInstance);
        }

        private void HandlePlayedToEnd() {
            playing = false;
            var offset = playbackInstance == null ? 0 : playbackInstance.LatestCaptureTime - playbackInstance.EarliestCaptureTime;
            if (this != null && loop) StartPlayback(offset);
        }

        private void StopPlayback() {
            playing = false;
            this.playbackInstance?.Dispose();
        }
    }
}