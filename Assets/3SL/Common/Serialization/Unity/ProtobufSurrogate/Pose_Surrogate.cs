// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    [ProtoContract]
    public class Pose_Surrogate {
        [ProtoMember(1)] public Vector3 Position { get; set; }
        [ProtoMember(2)] public Quaternion Rotation { get; set; }

        public Pose_Surrogate() { }

        public Pose_Surrogate(Vector3 position, Quaternion rotation) {
            Position = position;
            Rotation = rotation;
        }

        public static implicit operator Pose_Surrogate(Pose value) {
            return new Pose_Surrogate(value.position, value.rotation);
        }

        public static implicit operator Pose(Pose_Surrogate value) {
            if (value == null) return default(Pose);
            return new Pose(value.Position, value.Rotation);
        }
    }
}
