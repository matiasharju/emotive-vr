using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration {
    /// <summary>
    /// Watch the stream of gaze data emitted by the <see cref="ViveSRGazeMonitor"/> and log information about the sampling frequency.
    /// </summary>
    public class GazeSampleRateNotifier : MonoBehaviour {
        private Queue<Tuple<DateTime, int>> samplesWithinWindow = new Queue<Tuple<DateTime, int>>();
        private List<int> droppedFrameIndices = new List<int>();
        private int droppedFrameCount = 0;
        private bool droppedManyFrames = false;
        private DateTime startTime;
        private int lastReceivedIndex;

        void Start() {
            startTime = DateTime.Now;
            StartCoroutine(RunLoop(1));
        }

        private void OnEnable() {
            ViveSRGazeMonitor.Instance.OnEyeData += ReceiveDataPoint;
        }

        private void OnDisable() {
            ViveSRGazeMonitor.Instance.OnEyeData -= ReceiveDataPoint;
        }

        private IEnumerator RunLoop(float interval) {
            var sampleTime = DateTime.Now;
            while (true) {
                yield return new WaitForSecondsRealtime(interval);
                sampleTime = WriteInfoToConsole(sampleTime);
            }
        }

        private void ReceiveDataPoint(EyeData_v2 obj) {
            var now = DateTime.Now;
            if (samplesWithinWindow.Count > 0) {
                var framesSkipped = obj.frame_sequence - (lastReceivedIndex + 1);
                if (framesSkipped > 0) {
                    droppedFrameCount += framesSkipped;
                    if (framesSkipped + droppedFrameIndices.Count > 10) {
                        droppedManyFrames = true;
                    } else {
                        droppedFrameIndices.AddRange(Enumerable.Range(lastReceivedIndex + 1, framesSkipped));
                    }
                }
            }
            samplesWithinWindow.Enqueue(Tuple.Create(now, obj.frame_sequence));
            lastReceivedIndex = obj.frame_sequence;
        }

        DateTime WriteInfoToConsole(DateTime lastCheckTime) {
            var thisCheckTime = DateTime.Now;
            var window = (thisCheckTime - lastCheckTime).TotalSeconds;

            while (samplesWithinWindow.Count > 0 && (thisCheckTime - samplesWithinWindow.Peek().Item1).TotalSeconds > window) {
                samplesWithinWindow.Dequeue();
            }

            var hz = samplesWithinWindow.Count / window;
            var sb = new StringBuilder();
            sb.AppendLine($"[{thisCheckTime - startTime}] {hz:N2} Hz");
            if (droppedFrameCount > 0) {
                var sDrop = $"\tDropped {droppedFrameCount} frames in {window:N2}s (should've been {(samplesWithinWindow.Count + droppedFrameCount) / window:N2} Hz)";
                if(!droppedManyFrames) sDrop += ": " + string.Join(", ", droppedFrameIndices);
                sb.AppendLine(sDrop);
            }

            Debug.Log(sb.ToString());

            droppedFrameIndices.Clear();
            droppedFrameCount = 0;
            droppedManyFrames = false;

            return thisCheckTime;
        }
    }
}