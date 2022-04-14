// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.EyeData"/>
    /// </summary>
    [ProtoContract]
    public class EyeData_Surrogate {
        [ProtoMember(1)] public bool NoUser { get; set; }
        [ProtoMember(2)] public int FrameSequence { get; set; }
        [ProtoMember(3)] public int Timestamp { get; set; }
        [ProtoMember(4)] public VerboseData VerboseData { get; set; }

        public EyeData_Surrogate() { }

        public EyeData_Surrogate(bool noUser, int frameSequence, int timestamp, VerboseData verboseData) {
            NoUser = noUser;
            FrameSequence = frameSequence;
            Timestamp = timestamp;
            VerboseData = verboseData;
        }

        public static implicit operator EyeData_Surrogate(EyeData value) {
            return new EyeData_Surrogate(value.no_user, value.frame_sequence, value.timestamp, value.verbose_data);
        }
        public static implicit operator EyeData(EyeData_Surrogate value) {
            if (value == null) return default(EyeData);
            return new EyeData() {
                no_user = value.NoUser,
                frame_sequence = value.FrameSequence,
                timestamp = value.Timestamp,
                verbose_data = value.VerboseData
            };
        }
    }
}