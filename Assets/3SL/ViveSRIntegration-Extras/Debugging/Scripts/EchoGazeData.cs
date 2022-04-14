// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration {
    /// <summary>
    /// Helper component for debugging.
    /// </summary>
    public class EchoGazeData : MonoBehaviour {
        private void OnEnable() => ViveSRGazeMonitor.Instance.OnEyeData += Echo;
        private void OnDisable() => ViveSRGazeMonitor.Instance.OnEyeData -= Echo;
        private void Echo(EyeData_v2 data) => Debug.Log(data.ToPrettyString());
    }
}