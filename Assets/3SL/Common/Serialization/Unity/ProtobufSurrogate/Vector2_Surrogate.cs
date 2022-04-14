// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    [ProtoContract]
    public class Vector2_Surrogate {
        [ProtoMember(1)] public float X { get; set; }
        [ProtoMember(2)] public float Y { get; set; }

        public Vector2_Surrogate() { }
        public Vector2_Surrogate(float x, float y) {
            X = x;
            Y = y;
        }

        public static implicit operator Vector2_Surrogate(Vector2 value) {
            return new Vector2_Surrogate(value.x, value.y);
        }
        public static implicit operator Vector2(Vector2_Surrogate value) {
            if (value == null) return default(Vector2);
            return new Vector2(value.X, value.Y);
        }
    }
}
