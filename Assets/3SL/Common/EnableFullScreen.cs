using System.Linq;
using UnityEngine;

namespace Three.Common {
    public class EnableFullScreen : MonoBehaviour {
        void Start() {
            var maxResolution = Screen.resolutions.Last();
#if UNITY_2018_1_OR_NEWER
            Screen.SetResolution(maxResolution.width, maxResolution.height, FullScreenMode.ExclusiveFullScreen);
#else
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
#endif
        }
    }
}