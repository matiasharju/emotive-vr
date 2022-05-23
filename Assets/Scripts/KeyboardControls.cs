using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public GameObject telemetryElementsParentObject;
    public GameObject subtitlesParentObject;
    public GameObject emotionalTableParentObject;
    public GameObject operatorDataDisplay1;
    public GameObject operatorDataDisplay2;
    public GameObject operatorDataDisplay3;
    public GameObject pressSpace;
    public GameObject menuItems;

    bool keyPressedNeuLog = false;
    bool keyPressedSubtitles = false;
    bool keyPressedDataDisplay = false;
    bool keyPressedOperatorDataDisplay = false;
    bool keyPressedInteractiveMusic = false;
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
        if ((!keyPressedDataDisplay) && (emotionalTableParentObject != null))
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


    public void ToggleOperatorDataDisplay()
    {
        if ((!keyPressedOperatorDataDisplay) && (operatorDataDisplay1 != null))
        {
            keyPressedOperatorDataDisplay = true;

            if (operatorDataDisplay1.activeSelf)
            {
                operatorDataDisplay1.SetActive(false);
                operatorDataDisplay2.SetActive(false);
                operatorDataDisplay3.SetActive(false);
            }
            else if (!operatorDataDisplay1.activeSelf)
            {
                operatorDataDisplay1.SetActive(true);
                operatorDataDisplay2.SetActive(true);
                operatorDataDisplay3.SetActive(true);
            }

            StartCoroutine(releaseOperatorDataDisplayButton());
        }
    }
    IEnumerator releaseOperatorDataDisplayButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedOperatorDataDisplay = false;
    }

    public void ToggleInteractiveMusic()
    {
        if (!keyPressedInteractiveMusic)
        {
            keyPressedInteractiveMusic = true;

            if (DirectorSequencer.Instance.enableInteractiveMusic)
            {
                DirectorSequencer.Instance.enableInteractiveMusic = false;
            }
            else if (!DirectorSequencer.Instance.enableInteractiveMusic)
            {
                DirectorSequencer.Instance.enableInteractiveMusic = true;
            }

            StartCoroutine(releaseInteractiveMusicButton());
        }
    }
    IEnumerator releaseInteractiveMusicButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedInteractiveMusic = false;
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
