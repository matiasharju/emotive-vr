using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{

    public GameObject subtitlesParentObject;
    bool keyPressed = false;

    public GameObject emotionalTableParentObject;
    public GameObject telemetryElementsParentObject;
    bool keyPressed2 = false;

    bool keyPressedStart = false;

    bool keyPressedNeuLog = false;


    public void StartPlayback()
    {
        if (!keyPressedStart)       // Allow only single press in the beginning of the experience, after that disable
        {
            keyPressedStart = true;
            DirectorSequencer.Instance.PlayNextSequenceFromStartScreen();
        }
    }

    public void ToggleNeuLog()
    {
        if ((!keyPressedNeuLog) && (subtitlesParentObject != null))
        {
            keyPressedNeuLog = true;

            if (DirectorSequencer.useNeuLog)
            {
                DirectorSequencer.useNeuLog = false;
            }
            else if (!DirectorSequencer.useNeuLog)
            {
                DirectorSequencer.useNeuLog = true;
            }

            StartCoroutine(releaseNeuLogButton());
        }
    }


    IEnumerator releaseNeuLogButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedNeuLog = false;
    }


    public void ToggleSubtitles()
    {
        if ((!keyPressed) && (subtitlesParentObject != null))
        {
            keyPressed = true;
 
            if (subtitlesParentObject.activeSelf)
            {
                subtitlesParentObject.SetActive(false);
            }
            else if (!subtitlesParentObject.activeSelf)
            {
                subtitlesParentObject.SetActive(true);
            }

            StartCoroutine(releaseSubtitleButton());
        }
    }

    IEnumerator releaseSubtitleButton()
    {
        yield return new WaitForSeconds(1);
        keyPressed = false;
    }


    public void ToggleEmotionDataDisplay()
    {
        if ((!keyPressed) && (emotionalTableParentObject != null))
        {
            keyPressed2 = true;

            if (emotionalTableParentObject.activeSelf)
            {
                emotionalTableParentObject.SetActive(false);
                telemetryElementsParentObject.SetActive(false);
            }
            else if (!emotionalTableParentObject.activeSelf)
            {
                emotionalTableParentObject.SetActive(true);
                telemetryElementsParentObject.SetActive(true);
            }

            StartCoroutine(releaseDataDisplayButton());
        }
    }

    IEnumerator releaseDataDisplayButton()
    {
        yield return new WaitForSeconds(1);
        keyPressed2 = false;
    }

}
