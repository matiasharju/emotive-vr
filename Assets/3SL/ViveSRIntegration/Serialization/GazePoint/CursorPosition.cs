// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System.Globalization;
using System.Xml;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// GazePoint "Cursor position" fields.
    /// This class is included for completeness but not currently used in the iMotions / ViveSR integration.
    /// </summary>
    public readonly struct CursorPosition {
        public readonly float x;
        public readonly float y;
        public readonly int state;

        /// <summary>
        /// Write this object's data into an XmlWriter as attributes of a GazePoint record.
        /// </summary>
        /// <param name="writer"></param>
        public void ProvideXml(XmlWriter writer) {
            writer.WriteAttributeString("CX", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("CY", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("CS", state.ToString(CultureInfo.InvariantCulture));
        }
    }
}
