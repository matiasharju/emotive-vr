// Copyright (C) CoVR Solutions, LLC. All rights reserved.
// This file is subject to the terms and conditions defined in
// the 'LICENSE.txt' file included with this code package.

using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration {
    public interface IGazeDataSource {
        /// <summary>
        /// Try to retrieve a new data point at this time. Must return false if ReachedEndOfData is true or if the next data point is ahead of the current time.
        /// </summary>
        /// <param name="data">Output struct</param>
        /// <returns>True if another valid data point has been retrieved at this time, false otherwise.</returns>
        bool TryGetNextDataPoint(ref EyeData_v2 data);

        /// <summary>
        /// True iff we have exhausted all possible data points from this source.
        /// </summary>
        bool ReachedEndOfData { get; }
    }
}