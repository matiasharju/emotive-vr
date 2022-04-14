// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    [ProtoContract]
    public class Vector4_Surrogate {
        [ProtoMember(1)] public float X { get; set; }
        [ProtoMember(2)] public float Y { get; set; }
        [ProtoMember(3)] public float Z { get; set; }
        [ProtoMember(3)] public float W { get; set; }

        public Vector4_Surrogate() { }

        public Vector4_Surrogate(float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator Vector4_Surrogate(Vector4 value) {
            return new Vector4_Surrogate(value.x, value.y, value.z, value.w);
        }
        public static implicit operator Vector4(Vector4_Surrogate value) {
            if (value == null) return default(Vector4);
            return new Vector4(value.X, value.Y, value.Z, value.W);
        }
    }
}
