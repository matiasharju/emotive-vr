// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    [ProtoContract]
    public class Vector3_Surrogate {
        [ProtoMember(1)] public float X { get; set; }
        [ProtoMember(2)] public float Y { get; set; }
        [ProtoMember(3)] public float Z { get; set; }

        public Vector3_Surrogate() { }
        public Vector3_Surrogate(float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3_Surrogate(Vector3 value) {
            return new Vector3_Surrogate(value.x, value.y, value.z);
        }
        public static implicit operator Vector3(Vector3_Surrogate value) {
            if (value == null) return default(Vector3);
            return new Vector3(value.X, value.Y, value.Z);
        }
    }
}
