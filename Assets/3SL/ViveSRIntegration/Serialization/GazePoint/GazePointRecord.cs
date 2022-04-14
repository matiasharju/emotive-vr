// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using System.Globalization;
using System.Xml;

namespace Three.ViveSRIntegration.GazePoint {
    /// <summary>
    /// A GazePoint data record per the Open Gaze API v2.0.
    /// </summary>
    public readonly struct GazePointRecord {
        public readonly int counter;
        public readonly float time;
        public readonly long? timeTick;
        public readonly FixationPointOfGaze? fixPOG;
        public readonly PointOfGaze? leftPOG;
        public readonly PointOfGaze? rightPOG;
        public readonly PointOfGaze? bestPOG;
        public readonly PupilOnCamera? leftPupil;
        public readonly PupilOnCamera? rightPupil;
        public readonly EyeLocation3D? leftEyeLocation;
        public readonly EyeLocation3D? rightEyeLocation;
        public readonly CursorPosition? cursor;
        public readonly string userData;

        public GazePointRecord(int counter, float time, long? timeTick = null, FixationPointOfGaze? fixPOG = null,
            PointOfGaze? leftPOG = null, PointOfGaze? rightPOG = null, PointOfGaze? bestPOG = null,
            PupilOnCamera? leftPupil = null, PupilOnCamera? rightPupil = null,
            EyeLocation3D? leftEyeLocation = null, EyeLocation3D? rightEyeLocation = null,
            CursorPosition? cursor = null, string userData = null
        ) {
            this.counter = counter;
            this.time = time;
            this.timeTick = timeTick;
            this.fixPOG = fixPOG;
            this.leftPOG = leftPOG;
            this.rightPOG = rightPOG;
            this.bestPOG = bestPOG;
            this.leftPupil = leftPupil;
            this.rightPupil = rightPupil;
            this.leftEyeLocation = leftEyeLocation;
            this.rightEyeLocation = rightEyeLocation;
            this.cursor = cursor;
            this.userData = userData;
        }

        /// <summary>
        /// Write this data record into an XmlWriter as an XML element compliant with the GazePoint specifications.
        /// </summary>
        /// <param name="writer"></param>
        public void ProvideXml(XmlWriter writer) {
            writer.WriteStartElement("REC");
            writer.WriteAttributeString("CNT", counter.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("TIME", time.ToString(CultureInfo.InvariantCulture));

            if (timeTick.HasValue) writer.WriteAttributeString("TIME_TICK", timeTick.Value.ToString(CultureInfo.InvariantCulture));

            fixPOG?.ProvideXml(writer);

            leftPOG?.ProvideXml(writer,"L");
            rightPOG?.ProvideXml(writer,"R");
            bestPOG?.ProvideXml(writer,"B");

            leftPupil?.ProvideXml(writer,"L");
            rightPupil?.ProvideXml(writer,"R");

            leftEyeLocation?.ProvideXml(writer, "L");
            rightEyeLocation?.ProvideXml(writer, "R");

            cursor?.ProvideXml(writer);

            if (!string.IsNullOrEmpty(userData)) writer.WriteAttributeString("USER", userData);

            writer.WriteEndElement();
        }
    }
}
