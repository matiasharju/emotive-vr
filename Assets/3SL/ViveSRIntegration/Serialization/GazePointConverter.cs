// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using Three.ViveSRIntegration.GazePoint;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration.Serialization {
    public class GazePointConverter {

        readonly PointOfViewMapper pointOfView;
        readonly int firstTimestamp;
        private int count;

        public GazePointConverter(PointOfViewMapper pointOfView, int firstTimestamp) {
            this.pointOfView = pointOfView;
            this.firstTimestamp = firstTimestamp;
        }

        public GazePointRecord ConvertToGazePointRecord(EyeData_v2 obj) {
            PointOfGaze leftPoG;
            PointOfGaze rightPoG;

            VerboseData v = obj.verbose_data;

            // Use focus distance in computing per-eye PoG if the focus distance is available
            if (v.HasConvergence()) {
                leftPoG = MakePoG(v.left, v.combined.GetConvergenceDistance(), v.combined.eye_data);
                rightPoG = MakePoG(v.right, v.combined.GetConvergenceDistance(), v.combined.eye_data);
            } else {
                leftPoG = MakePoG(v.left);
                rightPoG = MakePoG(v.right);
            }

            var record = new GazePointRecord(
                count++, NormalizeTimestamp(obj.timestamp),
                leftPOG: leftPoG,
                rightPOG: rightPoG,
                bestPOG: MakePoG(v.combined.eye_data),
                leftPupil: PupilOnCamera.DummyWithPositionAndValidity(
                    v.left.pupil_position_in_sensor_area,
                    v.left.GetPupilPositionValid()),
                rightPupil: PupilOnCamera.DummyWithPositionAndValidity(
                    v.right.pupil_position_in_sensor_area,
                    v.right.GetPupilPositionValid()),
                leftEyeLocation: EyeLocation3D.DummyWithPupilSizeAndValidity(
                    MillimetersToMeters(v.left.pupil_diameter_mm),
                    v.left.GetPupilDiameterValid()),
                rightEyeLocation: EyeLocation3D.DummyWithPupilSizeAndValidity(
                    MillimetersToMeters(v.right.pupil_diameter_mm),
                    v.right.GetPupilDiameterValid())
            );
            return record;
        }

        private int NormalizeTimestamp(int timestamp) => timestamp - firstTimestamp;
        private static float MillimetersToMeters(float mm) => 1e-3f * mm;

        private PointOfGaze MakePoG(SingleEyeData eye) {
            if (!eye.IsValid()) return PointOfGaze.Invalid;
            var screenVec = pointOfView.GetViewportCoordinates(eye.GetPositionVector(), eye.GetDirectionVector());
            return new PointOfGaze(screenVec.x, 1f - screenVec.y, true);
        }

        private PointOfGaze MakePoG(SingleEyeData eye, float focusDistance, SingleEyeData focus) {
            UnityEngine.Vector3 pos = eye.GetPositionVector();
            UnityEngine.Vector3 dir = eye.GetDirectionVector();
            var screenVec = pointOfView.GetViewportCoordinates(pos, dir, focusDistance, focus.GetDirectionVector());
            return new PointOfGaze(screenVec.x, 1f - screenVec.y, true);
        }
    }
}