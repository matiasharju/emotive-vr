// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using System;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Testing {
    /// <summary>
    /// Protobuf object to associate a <see cref="EyeData"/> object with a <see cref="TimeSpan"/> indicating when it was recorded relative to the start of a recording session.
    /// </summary>
    [ProtoContract]
    public class RecordedEyeDataWrapper {
        [ProtoMember(1)] public long RecordTimeTicks { get; set; }
        [ProtoMember(2)] public EyeData Data { get; set; }

        public RecordedEyeDataWrapper() { }

        public RecordedEyeDataWrapper(TimeSpan timeSinceStart, EyeData data) {
            RecordTimeTicks = timeSinceStart.Ticks;
            Data = data;
        }

        public TimeSpan GetRecordTime() => TimeSpan.FromTicks(RecordTimeTicks);
    }

    /// <summary>
    /// Protobuf object to associate a <see cref="EyeData_v2"/> object with a <see cref="TimeSpan"/> indicating when it was recorded relative to the start of a recording session.
    /// </summary>
    [ProtoContract]
    public class RecordedEyeDataWrapper_v2 {
        [ProtoMember(1)] public long RecordTimeTicks { get; set; }
        [ProtoMember(2)] public EyeData_v2 Data { get; set; }

        public RecordedEyeDataWrapper_v2() { }

        public RecordedEyeDataWrapper_v2(TimeSpan timeSinceStart, EyeData_v2 data) {
            RecordTimeTicks = timeSinceStart.Ticks;
            Data = data;
        }

        public TimeSpan GetRecordTime() => TimeSpan.FromTicks(RecordTimeTicks);
    }
}
