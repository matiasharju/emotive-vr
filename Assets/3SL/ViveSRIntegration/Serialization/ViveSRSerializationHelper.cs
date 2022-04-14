// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using Three.Common.Serialization;
using Three.Common.Serialization.Unity;
using System;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    public static class ViveSRSerializationHelper {
        private static bool didInitializeSurrogates = false;
        public static void InitializeSurrogates() {
            if (didInitializeSurrogates) return;
            didInitializeSurrogates = true;
            UnitySerializationHelper.InitializeSurrogates();

            AddTypeWithSurrogate(typeof(SingleEyeData), typeof(SingleEyeData_Surrogate));
            AddTypeWithSurrogate(typeof(CombinedEyeData), typeof(CombinedEyeData_Surrogate));
            AddTypeWithSurrogate(typeof(TrackingImprovements), typeof(TrackingImprovements_Surrogate));
            AddTypeWithSurrogate(typeof(VerboseData), typeof(VerboseData_Surrogate));
            AddTypeWithSurrogate(typeof(EyeData), typeof(EyeData_Surrogate));

            // v2 surrogates
            AddTypeWithSurrogate(typeof(EyeData_v2), typeof(EyeData_v2_Surrogate));
            AddTypeWithSurrogate(typeof(SingleEyeExpression), typeof(SingleEyeExpression_Surrogate));
            AddTypeWithSurrogate(typeof(EyeExpression), typeof(EyeExpression_Surrogate));
        }

        private static void AddTypeWithSurrogate(Type target, Type surrogate) => SerializationHelper.AddTypeWithSurrogate(target, surrogate);
    }
}