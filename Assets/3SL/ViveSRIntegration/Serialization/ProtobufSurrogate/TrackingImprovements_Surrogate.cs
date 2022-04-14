// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    /// <summary>
    /// Protobuf-net surrogate for <see cref="ViveSR.anipal.Eye.TrackingImprovements"/>
    /// </summary>
    [ProtoContract]
    public class TrackingImprovements_Surrogate {
        [ProtoMember(1)] public int Count { get; set; }
        [ProtoMember(2)] public TrackingImprovement[] Items { get; set; }

        public TrackingImprovements_Surrogate() {
        }

        public TrackingImprovements_Surrogate(int count, TrackingImprovement[] items) {
            Count = count;
            Items = items;
        }

        public static implicit operator TrackingImprovements_Surrogate(TrackingImprovements value) {
            return new TrackingImprovements_Surrogate(value.count,value.items);
        }

        public static implicit operator TrackingImprovements(TrackingImprovements_Surrogate value) {
            if (value == null) return default(TrackingImprovements);
            return new TrackingImprovements() {
                count = value.Count,
                items = value.Items
            };
        }
    }
}