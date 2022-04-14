// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.SingleEyeExpression"/>
    /// </summary>
    [ProtoContract]
    public class SingleEyeExpression_Surrogate {
        [ProtoMember(1)] public float EyeWide { get; set; }
        [ProtoMember(2)] public float EyeSqueeze { get; set; }
        [ProtoMember(3)] public float EyeFrown { get; set; }

        public SingleEyeExpression_Surrogate() { }

        public SingleEyeExpression_Surrogate(float eyeWide, float eyeSqueeze, float eyeFrown) {
            EyeWide = eyeWide;
            EyeSqueeze = eyeSqueeze;
            EyeFrown = eyeFrown;
        }

        public static implicit operator SingleEyeExpression_Surrogate(SingleEyeExpression value) {
            return new SingleEyeExpression_Surrogate(value.eye_wide, value.eye_squeeze, value.eye_frown);
        }

        public static implicit operator SingleEyeExpression(SingleEyeExpression_Surrogate value) {
            if (value == null) return default(SingleEyeExpression);
            return new SingleEyeExpression() {
                eye_wide = value.EyeWide,
                eye_squeeze = value.EyeSqueeze,
                eye_frown = value.EyeFrown
            };
        }
    }
}