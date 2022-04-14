// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using UnityEngine;

namespace Three.ViveSRIntegration {
    public class PointOfViewMapper : MonoBehaviour {
        [SerializeField] Transform userHead;
        [SerializeField] Camera screenCamera;

        /// <summary>
        /// Default distance used in computing 3D point of gaze for each eye.
        /// This is in meters and will be scaled with respect to the <see cref="userHead"/>.
        /// </summary>
        [SerializeField] float assumedEyeFocusDistance = 1;

        /// <summary>
        /// Whether to use the <see cref="VarjoPlugin.GazeData.focusDistance"/> of the combined eye gaze to estimate the focus distance of each individual eye.
        /// If this is true, the <see cref="VarjoPlugin.GazeData.focusDistance"/> will be used to infer individual eye focus distances when available; the <see cref="assumedEyeFocusDistance"/> will be used when only one eye is tracked.
        /// If this is false, the <see cref="assumedEyeFocusDistance"/> will always be used.
        /// </summary>
        [SerializeField] bool useMeasuredFocusDistance = true;

        /// <summary>
        /// Compute the camera-space coordinates of the given eye gaze, possibly using the <paramref name="focusDistance"/> and <paramref name="focusDirection"/> to infer the eye focus distance.
        /// </summary>
        /// <param name="eyePosition"></param>
        /// <param name="eyeDirection"></param>
        /// <param name="focusDistance"></param>
        /// <param name="focusDirection"></param>
        /// <returns></returns>
        public Vector3 GetViewportCoordinates(Vector3 eyePosition, Vector3 eyeDirection, float focusDistance, Vector3 focusDirection) {
            float eyeFocusDistance = useMeasuredFocusDistance ? InferEyeFocusDistance(eyePosition,eyeDirection,focusDistance,focusDirection) : assumedEyeFocusDistance;
            //Debug.Log(eyeFocusDistance);
            return GetViewportCoordinatesInner(eyePosition, eyeDirection, eyeFocusDistance);
        }

        /// <summary>
        /// Compute the camera-space coordinates of the given eye gaze based on our <see cref="assumedEyeFocusDistance"/>.
        /// </summary>
        /// <param name="eyePosition"></param>
        /// <param name="eyeDirection"></param>
        /// <returns></returns>
        public Vector3 GetViewportCoordinates(Vector3 eyePosition, Vector3 eyeDirection) {
            return GetViewportCoordinatesInner(eyePosition, eyeDirection, assumedEyeFocusDistance);
        }

        private Vector3 GetViewportCoordinatesInner(Vector3 eyePosition, Vector3 eyeDirection, float eyeFocusDistance) {
            return screenCamera.WorldToViewportPoint(userHead.TransformPoint(eyePosition + (eyeDirection * eyeFocusDistance)));
        }

        /// <summary>
        /// Project the eye gaze vector onto the plane normal to a focus direction at a given focus distance.
        /// </summary>
        /// <param name="eyePosition">Local position of the eye, relative to the focus vector origin at zero</param>
        /// <param name="eyeDirection">Normalized direction vector of the eye gaze, in local coordinates</param>
        /// <param name="focusDistance">Distance from the head to the focus point</param>
        /// <param name="focusDirection">Normalized direction vector from the head to the focus point, in local coordinates</param>
        /// <returns></returns>
        private static float InferEyeFocusDistance(Vector3 eyePosition, Vector3 eyeDirection, float focusDistance, Vector3 focusDirection) {
            return (focusDistance - Vector3.Dot(eyePosition, focusDirection)) / Vector3.Dot(eyeDirection, focusDirection);
        }
    }
}