using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{

    public GameObject subtitlesParentObject;
    bool keyPressed = false;
    public GameObject emotionalTableParentObject;
    bool keyPressed2 = false;


    public void StartPlayback()
    {
        DirectorSequencer.Instance.PlayNextSequenceFromStartScreen();
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
            }
            else if (!emotionalTableParentObject.activeSelf)
            {
                emotionalTableParentObject.SetActive(true);
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
