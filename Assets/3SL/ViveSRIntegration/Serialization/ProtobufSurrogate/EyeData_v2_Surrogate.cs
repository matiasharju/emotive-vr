// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.EyeData_v2"/>
    /// </summary>
    [ProtoContract]
    public class EyeData_v2_Surrogate {
        [ProtoMember(1)] public bool NoUser { get; set; }
        [ProtoMember(2)] public int FrameSequence { get; set; }
        [ProtoMember(3)] public int Timestamp { get; set; }
        [ProtoMember(4)] public VerboseData VerboseData { get; set; }
        // Eye expression data--not required to allow us to deserialize EyeData_v2 from EyeData with all invalid eye expressions
        [ProtoMember(5, IsRequired = false)] public EyeExpression ExpressionData { get; set; }

        public EyeData_v2_Surrogate() { }

        public EyeData_v2_Surrogate(bool noUser, int frameSequence, int timestamp, VerboseData verboseData) {
            NoUser = noUser;
            FrameSequence = frameSequence;
            Timestamp = timestamp;
            VerboseData = verboseData;
        }

        public static implicit operator EyeData_v2_Surrogate(EyeData_v2 value) {
            return new EyeData_v2_Surrogate(value.no_user, value.frame_sequence, value.timestamp, value.verbose_data);
        }
        public static implicit operator EyeData_v2(EyeData_v2_Surrogate value) {
            if (value == null) return default(EyeData_v2);
            return new EyeData_v2() {
                no_user = value.NoUser,
                frame_sequence = value.FrameSequence,
                timestamp = value.Timestamp,
                verbose_data = value.VerboseData
            };
        }
    }
}