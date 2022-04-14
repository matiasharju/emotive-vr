// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System.Globalization;
using System.Xml;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// GazePoint "Fixation POG" fields.
    /// This class is included for completeness but not currently used in the iMotions / ViveSR integration.
    /// </summary>
    public readonly struct FixationPointOfGaze {
        public readonly float x;
        public readonly float y;
        public readonly float duration; // seconds
        public readonly int id; // PoG ID number
        public readonly bool valid;

        public FixationPointOfGaze(float x, float y, float duration, int id, bool valid) {
            this.x = x;
            this.y = y;
            this.duration = duration;
            this.id = id;
            this.valid = valid;
        }

        /// <summary>
        /// Write this object's data into an XmlWriter as attributes of a GazePoint record.
        /// </summary>
        /// <param name="writer"></param>
        public void ProvideXml(XmlWriter writer) {
            writer.WriteAttributeString("FPOGX", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("FPOGY", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("FPOGD", duration.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("FPOGID", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("FPOGV", valid ? "1" : "0");
        }
    }
}
