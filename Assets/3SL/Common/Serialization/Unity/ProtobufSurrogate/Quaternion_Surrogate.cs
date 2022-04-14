// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    [ProtoContract]
    public class Quaternion_Surrogate {
        [ProtoMember(1)] public float X { get; set; }
        [ProtoMember(2)] public float Y { get; set; }
        [ProtoMember(3)] public float Z { get; set; }
        [ProtoMember(3)] public float W { get; set; }

        public Quaternion_Surrogate() { }

        public Quaternion_Surrogate(float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator Quaternion_Surrogate(Quaternion value) {
            return new Quaternion_Surrogate(value.x, value.y, value.z, value.w);
        }
        public static implicit operator Quaternion(Quaternion_Surrogate value) {
            if (value == null) return default(Quaternion);
            return new Quaternion(value.X, value.Y, value.Z, value.W);
        }
    }
}
