// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System;
using System.Text;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration {
    /// <summary>
    /// Extension methods for ViveSR data structures, mostly for converting to Unity data structures
    /// </summary>
    public static class ViveSRExtensions {
        /// <summary>
        /// Convert a <see cref="SingleEyeData"/> struct, in the local coordinates of <paramref name="transform"/>, to a Unity ray
        /// </summary>
        /// <param name="data">Gaze data, interpreted as local position and direction</param>
        /// <param name="transform"></param>
        /// <returns>A <see cref="Ray"/> in world coordinates</returns>
        public static Ray ToUnityRay(this SingleEyeData data, Transform transform) => new Ray(transform.TransformPoint(data.GetPositionVector()), transform.TransformDirection(data.GetDirectionVector()));
        
        public static Vector3 GetDirectionVector(this CombinedEyeData data) => data.eye_data.GetDirectionVector();
        public static Vector3 GetDirectionVector(this SingleEyeData data) => data.gaze_direction_normalized.normalized.FlipX();

        public static Vector3 GetPositionVector(this CombinedEyeData data) => data.eye_data.GetPositionVector();
        public static Vector3 GetPositionVector(this SingleEyeData data) => (data.gaze_origin_mm * 0.001f).FlipX();

        public static bool IsValid(this CombinedEyeData data) => data.GetDirectionValid();
        public static bool IsValid(this SingleEyeData data) => data.GetDirectionValid();

        public static bool HasConvergence(this VerboseData data) => data.combined.convergence_distance_validity && data.left.IsValid() && data.right.IsValid();

        public static bool GetDirectionValid(this CombinedEyeData data) => data.eye_data.GetDirectionValid();
        public static bool GetDirectionValid(this SingleEyeData data) => data.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_GAZE_DIRECTION_VALIDITY);

        public static bool GetPupilPositionValid(this SingleEyeData data) => data.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_PUPIL_POSITION_IN_SENSOR_AREA_VALIDITY);
        public static bool GetPupilDiameterValid(this SingleEyeData data) => data.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_PUPIL_DIAMETER_VALIDITY);

        public static float GetConvergenceDistance(this CombinedEyeData data) => data.convergence_distance_mm * 0.001f;

        // Switch handedness of vector coordinates
        public static Vector3 FlipX(this Vector3 v) {
            v.x = -v.x;
            return v;
        }

        /// <summary>
        /// Construct a formatted string with most of the information in <paramref name="gazeData"/> for debugging purposes
        /// </summary>
        /// <param name="gazeData"></param>
        /// <param name="lineBreaks"></param>
        /// <returns></returns>
        public static string ToPrettyString(this EyeData gazeData, bool lineBreaks = true) {
            var sb = new StringBuilder();
            Action<string> append = lineBreaks ? new Action<string>(s => sb.AppendLine(s)) : new Action<string>(s => sb.Append(s));

            append("GazeData {");
            append($"\t[Frame]             {gazeData.frame_sequence}");
            append($"\t[CaptureTime]       {gazeData.timestamp}");

            VerboseData verbose = gazeData.verbose_data;

            append($"\t[CombinedStatus]    {verbose.combined.GetDirectionValid()}");
            append($"\t[CombinedDirection] {verbose.combined.GetDirectionVector()}");
            append($"\t[LeftStatus]        {verbose.left.GetDirectionValid()}");
            append($"\t[LeftPosition]      {verbose.left.GetPositionVector()}");
            append($"\t[LeftDirection]     {verbose.left.GetDirectionVector()}");
            append($"\t[RightStatus]       {verbose.right.GetDirectionValid()}");
            append($"\t[RightPosition]     {verbose.right.GetPositionVector()}");
            append($"\t[RightDirection]    {verbose.right.GetDirectionVector()}");
            append("}");

            return sb.ToString();
        }

        /// <summary>
        /// Construct a formatted string with most of the information in <paramref name="gazeData"/> for debugging purposes
        /// </summary>
        /// <param name="gazeData"></param>
        /// <param name="lineBreaks"></param>
        /// <returns></returns>
        public static string ToPrettyString(this EyeData_v2 gazeData, bool lineBreaks = true) {
            var sb = new StringBuilder();
            Action<string> append = lineBreaks ? new Action<string>(s => sb.AppendLine(s)) : new Action<string>(s => sb.Append(s));

            append("GazeData {");
            append($"\t[Frame]             {gazeData.frame_sequence}");
            append($"\t[CaptureTime]       {gazeData.timestamp}");

            VerboseData verbose = gazeData.verbose_data;

            append($"\t[CombinedStatus]    {verbose.combined.GetDirectionValid()}");
            append($"\t[CombinedDirection] {verbose.combined.GetDirectionVector()}");
            append($"\t[LeftStatus]        {verbose.left.GetDirectionValid()}");
            append($"\t[LeftPosition]      {verbose.left.GetPositionVector()}");
            append($"\t[LeftDirection]     {verbose.left.GetDirectionVector()}");
            append($"\t[RightStatus]       {verbose.right.GetDirectionValid()}");
            append($"\t[RightPosition]     {verbose.right.GetPositionVector()}");
            append($"\t[RightDirection]    {verbose.right.GetDirectionVector()}");
            append("}");

            return sb.ToString();
        }
    }
}