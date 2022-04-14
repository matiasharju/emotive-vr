// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System.Globalization;
using System.Xml;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// GazePoint "Eye POG" fields for a single eye.
    /// </summary>
    public readonly struct PointOfGaze {
        public static PointOfGaze Invalid { get; } = new PointOfGaze(0, 0, false);

        public readonly float x; // screen coordinate
        public readonly float y; // screen coordinate
        public readonly bool valid;

        public PointOfGaze(float x, float y, bool valid) {
            this.x = x;
            this.y = y;
            this.valid = valid;
        }
        
        /// <summary>
        /// Write this object's data into an XmlWriter as attributes of a GazePoint record.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="prefix">"B", "L" or "R"</param>
        public void ProvideXml(XmlWriter writer, string prefix) {
            writer.WriteAttributeString(prefix + "POGX", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "POGY", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "POGV", valid ? "1" : "0");
        }
    }
}
