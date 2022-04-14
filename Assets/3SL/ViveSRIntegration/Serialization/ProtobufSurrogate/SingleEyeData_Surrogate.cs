// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.SingleEyeData"/>
    /// </summary>
    [ProtoContract]
    public class SingleEyeData_Surrogate {
        [ProtoMember(1)] public System.UInt64 EyeDataValidataBitMask { get; set; }
        [ProtoMember(2)] public Vector3 GazeOriginMm { get; set; }
        [ProtoMember(3)] public Vector3 GazeDirectionNormalized { get; set; }
        [ProtoMember(4)] public float PupilDiameterMm { get; set; }
        [ProtoMember(5)] public float EyeOpenness { get; set; }
        [ProtoMember(6)] public Vector2 PupilPositionInSensorArea { get; set; }

        public SingleEyeData_Surrogate() {
        }

        public SingleEyeData_Surrogate(ulong eyeDataValidataBitMask, Vector3 gazeOriginMm, Vector3 gazeDirectionNormalized, float pupilDiameterMm, float eyeOpenness, Vector2 pupilPositionInSensorArea) {
            EyeDataValidataBitMask = eyeDataValidataBitMask;
            GazeOriginMm = gazeOriginMm;
            GazeDirectionNormalized = gazeDirectionNormalized;
            PupilDiameterMm = pupilDiameterMm;
            EyeOpenness = eyeOpenness;
            PupilPositionInSensorArea = pupilPositionInSensorArea;
        }

        public static implicit operator SingleEyeData_Surrogate(SingleEyeData value) {
            return new SingleEyeData_Surrogate(value.eye_data_validata_bit_mask, value.gaze_origin_mm, value.gaze_direction_normalized, value.pupil_diameter_mm, value.eye_openness, value.pupil_position_in_sensor_area);
        }
        public static implicit operator SingleEyeData(SingleEyeData_Surrogate value) {
            if (value == null) return default(SingleEyeData);
            return new SingleEyeData() {
                eye_data_validata_bit_mask = value.EyeDataValidataBitMask,
                gaze_origin_mm = value.GazeOriginMm,
                gaze_direction_normalized = value.GazeDirectionNormalized,
                pupil_diameter_mm = value.PupilDiameterMm,
                eye_openness = value.EyeOpenness,
                pupil_position_in_sensor_area = value.PupilPositionInSensorArea
            };
        }

    }
}