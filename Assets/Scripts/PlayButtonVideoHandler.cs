using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class PlayButtonVideoHandler : MonoBehaviour
{
    bool playbackTriggered = false;

    void Start()
    {
        Debug.Log("Appuyez sur ESPACE pour commencer. Press SPACE to start playback.");
        playbackTriggered = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !playbackTriggered)
        {
            DirectorSequencer.Instance.PlayNextSequence();
            Debug.Log("Play");
            playbackTriggered = true;
//            SceneManager.UnloadSceneAsync("04_a_PlayButton");
        }

    }
}
