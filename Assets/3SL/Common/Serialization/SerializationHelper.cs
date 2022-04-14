// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ProtoBuf.Meta;
using System;


namespace Three.Common.Serialization {
    public static class SerializationHelper {

        public static void AddTypeWithSurrogate(Type target, Type surrogate) => RuntimeTypeModel.Default.Add(target, false).SetSurrogate(surrogate);
    }
}
