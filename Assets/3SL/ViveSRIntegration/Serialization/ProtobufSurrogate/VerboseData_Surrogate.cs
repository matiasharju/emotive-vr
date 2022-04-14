// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.VerboseData"/>
    /// </summary>
    [ProtoContract]
    public class VerboseData_Surrogate {
        /** A instance of the struct as @ref EyeData related to the left eye*/
        [ProtoMember(1)] public SingleEyeData_Surrogate Left { get; set; }
        /** A instance of the struct as @ref EyeData related to the right eye*/
        [ProtoMember(2)] public SingleEyeData_Surrogate Right { get; set; }
        /** A instance of the struct as @ref EyeData related to the combined eye*/
        [ProtoMember(3)] public CombinedEyeData_Surrogate Combined { get; set; }
        [ProtoMember(4)] public TrackingImprovements_Surrogate TrackingImprovements { get; set; }

        public VerboseData_Surrogate() {
        }

        public VerboseData_Surrogate(SingleEyeData_Surrogate left, SingleEyeData_Surrogate right, CombinedEyeData_Surrogate combined, TrackingImprovements_Surrogate trackingImprovements) {
            Left = left;
            Right = right;
            Combined = combined;
            TrackingImprovements = trackingImprovements;
        }
        
        public static implicit operator VerboseData_Surrogate(VerboseData value) {
            return new VerboseData_Surrogate(value.left, value.right, value.combined, value.tracking_improvements);
        }

        public static implicit operator VerboseData(VerboseData_Surrogate value) {
            if (value == null) return default(VerboseData);
            return new VerboseData() {
                left = value.Left,
                right = value.Right,
                combined = value.Combined,
                tracking_improvements = value.TrackingImprovements
            };
        }
    }
}