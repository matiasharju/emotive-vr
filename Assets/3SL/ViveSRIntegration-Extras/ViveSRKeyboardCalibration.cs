using UnityEngine;
using ViveSR.anipal.Eye;

namespace Three.ViveSRIntegration {
    /// <summary>
    /// Simple utility class to invoke eye tracking calibration from the keyboard.
    /// </summary>
    public class ViveSRKeyboardCalibration : MonoBehaviour {
        [SerializeField] KeyCode keyCode = KeyCode.Space;
        private void Update() {
//            if(Input.GetKeyDown(keyCode)) {
//                SRanipal_Eye.LaunchEyeCalibration();
//            }
        }
    }
}