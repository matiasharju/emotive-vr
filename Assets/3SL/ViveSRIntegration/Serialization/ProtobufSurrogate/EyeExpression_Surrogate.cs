// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.EyeExpression"/>
    /// </summary>
    [ProtoContract]
    public class EyeExpression_Surrogate {
        [ProtoMember(1)] public SingleEyeExpression_Surrogate Left { get; set; }
        [ProtoMember(2)] public SingleEyeExpression_Surrogate Right { get; set; }

        public EyeExpression_Surrogate() { }

        public EyeExpression_Surrogate(SingleEyeExpression_Surrogate left, SingleEyeExpression_Surrogate right) {
            Left = left;
            Right = right;
        }

        public static implicit operator EyeExpression_Surrogate(EyeExpression value) {
            return new EyeExpression_Surrogate(value.left, value.right);
        }

        public static implicit operator EyeExpression(EyeExpression_Surrogate value) {
            if (value == null) return default(EyeExpression);
            return new EyeExpression() {
                left = value.Left,
                right = value.Right,
            };
        }
    }
}