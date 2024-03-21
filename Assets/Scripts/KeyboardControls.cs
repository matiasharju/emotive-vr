using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public GameObject calibrationManager;
    public GameObject telemetryElementsParentObject;
    public GameObject subtitlesParentObject;
    public GameObject emotionalTableParentObject;
    public GameObject operatorDataDisplay1;
    public GameObject operatorDataDisplay2;
    public GameObject operatorDataDisplay3;
    public GameObject pressSpace;
    public GameObject menuItems;
    public GameObject syncSlate;

    bool keyPressedNeuLog = false;
    bool keyPressedSubtitles = false;
    bool keyPressedDataDisplay = false;
    bool keyPressedOperatorDataDisplay = false;
    bool keyPressedInteractive = false;
    bool keyPressedStart = false;
    bool keyPressedMenu = false;
    bool keyPressedJump = false;
    bool keyPressedSync = false;



    public void StartPlayback()
    {
        if (!keyPressedStart)       // Allow only single press in the beginning of the experience, after that disable
        {
            keyPressedStart = true;
            DirectorSequencer.Instance.PlayNextSequenceFromStartScreen();

            pressSpace.SetActive(false);
            menuItems.SetActive(false);

            DirectorSequencer.Instance.arousal = 0.0f;

            if (DirectorSequencer.Instance.isInteractive) DataRecorder.StartRecording();    // Start DataRecorder only in interactive mode

            StartCoroutine(FlashSlate());
        }
    }

    IEnumerator FlashSlate()
    {
        syncSlate.SetActive(true);
        AkSoundEngine.PostEvent("PlayBeep", gameObject);

        yield return new WaitForSeconds(0.06f);

        syncSlate.SetActive(false);
    }

    public void StopPlayback()
    {
        DirectorSequencer.Instance.StopPlaybackReturnToSequence0();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }


    public void SyncAudioToVideo()
    {
        if (!keyPressedSync)
        {
            DirectorSequencer.Instance.SyncAudioToVideo();
            StartCoroutine(releaseSyncButton());
        }
    }

    IEnumerator releaseSyncButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedSync = false;
    }


    public void JumpToNextSequence()
    {
        if (!keyPressedJump)
        {
            DirectorSequencer.Instance.JumpToNextSequence();
            StartCoroutine(releaseJumpButton());
        }
    }

    IEnumerator releaseJumpButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedJump = false;
    }


    public void ToggleMenu()
    {
        if ((!keyPressedMenu) && (menuItems != null))
        {
            keyPressedMenu = true;
            Debug.Log("MENU");

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


    IEnumerator releaseNeuLogButton()
    {
        yield return new WaitForSeconds(0.3f);
        keyPressedNeuLog = false;
    }

    IEnumerator releaseMenuButton()
    {
        yield return new WaitForSeconds(0.3f);
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
        if (DirectorSequencer.Instance.isInteractive)
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
    }
    IEnumerator releaseDataDisplayButton()
    {
        yield return new WaitForSeconds(1);
        keyPressedDataDisplay = false;
    }


    public void ToggleOperatorDataDisplay()
    {
        if (DirectorSequencer.Instance.isInteractive)
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
    }
    IEnumerator releaseOperatorDataDisplayButton()
    {
        yield return new WaitForSeconds(0.3f);
        keyPressedOperatorDataDisplay = false;
    }

    public void ToggleInteractive()     // Toggle Intearctive Music
    {
        if (DirectorSequencer.Instance.isInteractive)
        {
            if (!keyPressedInteractive)
            {
                keyPressedInteractive = true;

                if (DirectorSequencer.Instance.enableInteractiveMusic)
                {
                    DirectorSequencer.Instance.enableInteractiveMusic = false;

                    if (emotionalTableParentObject != null)
                    {
                        emotionalTableParentObject.SetActive(false);
                        telemetryElementsParentObject.SetActive(false);
                    }
                }
                else if (!DirectorSequencer.Instance.enableInteractiveMusic)
                {
                    DirectorSequencer.Instance.enableInteractiveMusic = true;

                    if (emotionalTableParentObject != null)
                    {
                        emotionalTableParentObject.SetActive(true);
                        telemetryElementsParentObject.SetActive(true);
                    }

                }

                StartCoroutine(releaseInteractiveButton());
            }
        }
    }
    IEnumerator releaseInteractiveButton()
    {
        yield return new WaitForSeconds(0.3f);
        keyPressedInteractive = false;
    }


}
