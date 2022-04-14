// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System;
using UnityEngine;
namespace Three.Common.Serialization.Unity {
    public static class UnitySerializationHelper {
        private static bool didInitializeSurrogates = false;
        public static void InitializeSurrogates() {
            if (didInitializeSurrogates) return;
            didInitializeSurrogates = true;
            AddTypeWithSurrogate(typeof(Vector2), typeof(Vector2_Surrogate));
            AddTypeWithSurrogate(typeof(Vector3), typeof(Vector3_Surrogate));
            AddTypeWithSurrogate(typeof(Vector4), typeof(Vector4_Surrogate));
            AddTypeWithSurrogate(typeof(Quaternion), typeof(Quaternion_Surrogate));
            AddTypeWithSurrogate(typeof(Pose), typeof(Pose_Surrogate));
            AddTypeWithSurrogate(typeof(Color), typeof(Color_Surrogate));
        }

        private static void AddTypeWithSurrogate(Type target, Type surrogate) => SerializationHelper.AddTypeWithSurrogate(target, surrogate);
    }
}
