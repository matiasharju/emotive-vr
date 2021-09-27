using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageAudioRunning : MonoBehaviour
{
    public AudioSource audioSource;
    public string nameOfFunctionToBeCalled = "StartOldFreudSrt";
    bool isTriggered;
    GameObject directorSequencer;

    private void Awake()
    {
        isTriggered = false;
        directorSequencer = GameObject.FindWithTag("DirectorSequencer");
    }

    void Update()
    {
        if ((!isTriggered) && (directorSequencer != null) && (audioSource != null) && (audioSource.isPlaying) && (audioSource.time < 0.01))
        {
            directorSequencer.SendMessage(nameOfFunctionToBeCalled);
            isTriggered = true;
        }
            
    }
}
