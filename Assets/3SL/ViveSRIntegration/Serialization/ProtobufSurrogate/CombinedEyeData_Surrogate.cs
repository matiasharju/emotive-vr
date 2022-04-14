// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.CombinedEyeData"/>
    /// </summary>
    [ProtoContract]
    public class CombinedEyeData_Surrogate {
        [ProtoMember(1)] public SingleEyeData EyeData { get; set; }
        [ProtoMember(2)] public bool ConvergenceDistanceValidity { get; set; }
        [ProtoMember(3)] public float ConvergenceDistanceMm { get; set; }

        public CombinedEyeData_Surrogate() {
        }

        public CombinedEyeData_Surrogate(SingleEyeData eyeData, bool convergenceDistanceValidity, float convergenceDistanceMm) {
            EyeData = eyeData;
            ConvergenceDistanceValidity = convergenceDistanceValidity;
            ConvergenceDistanceMm = convergenceDistanceMm;
        }

        public static implicit operator CombinedEyeData_Surrogate(CombinedEyeData value) {
            return new CombinedEyeData_Surrogate(value.eye_data, value.convergence_distance_validity, value.convergence_distance_mm);
        }
        public static implicit operator CombinedEyeData(CombinedEyeData_Surrogate value) {
            if (value == null) return default(CombinedEyeData);
            return new CombinedEyeData() {
                eye_data = value.EyeData,
                convergence_distance_validity = value.ConvergenceDistanceValidity,
                convergence_distance_mm = value.ConvergenceDistanceMm
            };
        }
    }
}