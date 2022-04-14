// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    [ProtoContract]
    public class Color_Surrogate {
        [ProtoMember(1)] public float R { get; set; }
        [ProtoMember(2)] public float G { get; set; }
        [ProtoMember(3)] public float B { get; set; }
        [ProtoMember(3)] public float A { get; set; }

        public Color_Surrogate() { }

        public Color_Surrogate(float r, float g, float b, float a) {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static implicit operator Color_Surrogate(Color value) {
            return new Color_Surrogate(value.r, value.g, value.b, value.a);
        }
        public static implicit operator Color(Color_Surrogate value) {
            if (value == null) return default(Color);
            return new Color(value.R, value.G, value.B, value.A);
        }
    }
}
