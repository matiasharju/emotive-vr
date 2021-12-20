using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class CallAudioMixerSnapshot : MonoBehaviour
{

    public AudioMixerSnapshot snapshot;
    public float fadeTime = 0.0f;
    public bool callOnAwake = true;

    void Awake()
    {
        if (callOnAwake)
        {
            snapshot.TransitionTo(fadeTime);
            Debug.Log(snapshot + " called with fade time " + fadeTime);
        }
    }

}
