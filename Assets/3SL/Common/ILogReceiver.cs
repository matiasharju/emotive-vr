// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System;

namespace Three.Common {
    public interface ILogReceiver {
        void Log(string s);
        void LogException(Exception e);
    }
}