using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public GameObject telemetryElementsParentObject;
    public GameObject subtitlesParentObject;
    public GameObject emotionalTableParentObject;
    public GameObject pressSpace;
    public GameObject menuItems;

    bool keyPressedNeuLog = false;
    bool keyPressedSubtitles = false;
    bool keyPressedDataDisplay = false;
    bool keyPressedStart = false;
    bool keyPressedMenu = false;


    public void StartPlayback()
    {
        if (!keyPressedStart)       // Allow only single press in the beginning of the experience, after that disable
        {
            keyPressedStart = true;
            DirectorSequencer.Instance.PlayNextSequenceFromStartScreen();

            pressSpace.SetActive(false);
            menuItems.SetActive(false);

            DirectorSequencer.Instance.cumulativeArousal = 0.0f;

            DataRecorder.StartRecording();
        }
    }

    public void ToggleMenu()
    {
        if ((!keyPressedMenu) && (menuItems != null))
        {
            keyPressedMenu = true;

            if (menuItems.activeSelf)
            {
                menuItems.SetActive(false);
            }
            else if (!menuItems.activeSelf)
            {
                menuItems.SetActive(true);
            }

            StartCoroutine(releaseMenuButton());
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

    IEnumerator releaseMenuButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedMenu = false;
    }


    public void ToggleSubtitles()
    {
        if ((!keyPressedSubtitles) && (subtitlesParentObject != null))
        {
            keyPressedSubtitles = true;
 
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
        keyPressedSubtitles = false;
    }


    public void ToggleEmotionDataDisplay()
    {
        if ((!keyPressedSubtitles) && (emotionalTableParentObject != null))
        {
            keyPressedDataDisplay = true;

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
        keyPressedDataDisplay = false;
    }

    public void IncreaseGSRCalibrationValue()
    {
        DirectorSequencer.Instance.GSRCalibrationMultiplier = DirectorSequencer.Instance.GSRCalibrationMultiplier + 0.02f;
    }

    public void DecreaseGSRCalibrationValue()
    {
        DirectorSequencer.Instance.GSRCalibrationMultiplier = DirectorSequencer.Instance.GSRCalibrationMultiplier - 0.02f;
    }

}
