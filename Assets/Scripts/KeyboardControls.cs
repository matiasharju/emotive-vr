using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{

    public void StartPlayback()
    {
        DirectorSequencer.Instance.PlayNextSequence();
        Debug.Log("Start Playback");
    }

}
