// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System.Globalization;
using System.Xml;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// GazePoint "Eye 3D Data" fields for a single eye.
    /// </summary>
    public readonly struct EyeLocation3D {
        public readonly float x; // meters relative to camera focal point
        public readonly float y; // meters relative to camera focal point
        public readonly float z; // meters relative to camera focal point
        public readonly float pupilDiameter; // meters
        public readonly bool valid;

        public EyeLocation3D(float x, float y, float z, float pupilDiameter, bool valid) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.pupilDiameter = pupilDiameter;
            this.valid = valid;
        }

        /// <summary>
        /// Write this object's data into an XmlWriter as attributes of a GazePoint record.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="prefix">"L" or "R"</param>
        public void ProvideXml(XmlWriter writer, string prefix) {
            writer.WriteAttributeString(prefix + "EYEX", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "EYEY", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "EYEZ", z.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "PUPILD", pupilDiameter.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "PUPILV", valid ? "1" : "0");
        }
        
        /// <summary>
        /// Dummy data used in iMotions Tobii integration.
        /// </summary>
        public static EyeLocation3D Dummy { get; } = new EyeLocation3D(
            -0.027770f,
            -0.004590f,
            0.63645f,
            0.00294f,
            true
        );

        public static EyeLocation3D DummyWithPupilSizeAndValidity(float size, bool validity) => new EyeLocation3D(
            -0.027770f,
            -0.004590f,
            0.63645f,
            size,
            validity
        );

    }
}
