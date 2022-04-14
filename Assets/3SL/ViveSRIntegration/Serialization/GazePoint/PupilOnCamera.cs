// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System.Globalization;
using System.Xml;
using UnityEngine;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// GazePoint "Eye Pupil" fields for a single eye.
    /// </summary>
    public readonly struct PupilOnCamera {
        private const float DUMMY_PUPIL_SCALE_FACTOR = 1f;
        private const float DUMMY_PUPIL_DIAMETER_PIXELS = 10.45f;

        public readonly float x; // fraction of camera image
        public readonly float y; // fraction of camera image
        public readonly float diameter; // pixels
        public readonly float scaleFactor; // relative to 1 at calibration depth
        public readonly bool valid;

        public PupilOnCamera(float x, float y, float diameter, float scaleFactor, bool valid) {
            this.x = x;
            this.y = y;
            this.diameter = diameter;
            this.scaleFactor = scaleFactor;
            this.valid = valid;
        }

        /// <summary>
        /// Write this object's data into an XmlWriter as attributes of a GazePoint record.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="prefix">"L" or "R"</param>
        public void ProvideXml(XmlWriter writer, string prefix) {
            writer.WriteAttributeString(prefix + "PCX", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "PCY", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "PD", diameter.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "PS", scaleFactor.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString(prefix + "PV", valid ? "1" : "0");
        }

        public static PupilOnCamera DummyWithPositionAndValidity(Vector2 pupilPosition, bool isValid) {
            return new PupilOnCamera(
                pupilPosition.x, pupilPosition.y,
                DUMMY_PUPIL_DIAMETER_PIXELS, DUMMY_PUPIL_SCALE_FACTOR,
                isValid);
        }

        public static PupilOnCamera Dummy { get; } = new PupilOnCamera(
            0.046200f,
            0.927400f,
            DUMMY_PUPIL_DIAMETER_PIXELS,
            DUMMY_PUPIL_SCALE_FACTOR,
            true
        );
    }
}
