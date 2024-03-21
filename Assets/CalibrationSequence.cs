using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationSequence : MonoBehaviour
{
//    public CalibrationItem calibrationNoiseItem;
//    public List<CalibrationItem> calibrationItems;
    public AudioManager audioManager;
    //    private int playIndex;
    //    private List<int> playedItems = new List<int>();              // for keeping track of already played items (for not to play them multiple times)
    public OSC osc;
    private OscMessage oscMessage;
    public GameObject calibrationStartText;
    public GameObject calibrationEndText;
    [SerializeField] private float infoTextTime = 5.0f;
    [SerializeField] private float preStimulusTime = 5.5f;
    [SerializeField] private float soundStimulusTime = 6.0f;
    [SerializeField] private float postStimulusTime = 1.0f;
    [SerializeField] private float noiseTime = 13.5f;   // Wwise adds 0.5 sec fade-out, so this value should be 0.5 sec shorter
    [SerializeField] private int cycles = 5;
    [SerializeField] private float calibrationTime;

    public float timeRemaining;
    public Text timeText;

    private bool calibrationStarted = false;

    void Start()
    {
    }

    public void StartCalibration()
    {
        if (!calibrationStarted)
        {
            calibrationStarted = true;
            calibrationTime = infoTextTime + ((preStimulusTime + soundStimulusTime + postStimulusTime + noiseTime + 0.5f) * 4 * cycles);
            timeRemaining = calibrationTime;
            StartCoroutine(RunSequence());
        }
    }

    public void TerminateCalibration()
    {
        AkSoundEngine.PostEvent("StopCalib", gameObject);
        oscSend("end");
        if (timeText != null) timeText.text = "Calibration finished. Please run TRAIN and ESTIMATE.";
        calibrationStarted = false;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (timeText != null) timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void oscSend(string text)
    {
        oscMessage = OSC.StringToOscMessage("/ov/stimulation " + text);
        osc.Send(oscMessage);
    }



    // SEQUENCE WITH RANDOMISATION DONE IN WWISE
    IEnumerator RunSequence()
    {
        calibrationStartText.SetActive(true);   // Display calibration start message

        yield return new WaitForSeconds(infoTextTime);

        calibrationStartText.SetActive(false);  // Hide calibration start message

        while (cycles > 0)
        {
            // *********** LVLA *************

            // Pre-stimulus silence
            oscSend("nvna");
            yield return new WaitForSeconds(preStimulusTime);

            // Sound stimulus
            AkSoundEngine.PostEvent("PlayLVLA", gameObject);
            oscSend("lvla");
            yield return new WaitForSeconds(soundStimulusTime);

            // Stop sound; Post-stimulus silence
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            oscSend("nvna");
            yield return new WaitForSeconds(postStimulusTime);

            // Noise
            AkSoundEngine.PostEvent("PlayCalibNoise", gameObject);
            oscSend("nvna");
            yield return new WaitForSeconds(noiseTime);

            // Stop noise
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            yield return new WaitForSeconds(0.5f);  // wwise fade-out time

            // *********** LVHA *************

            // Pre-stimulus silence
            oscSend("nvna");
            yield return new WaitForSeconds(preStimulusTime);

            // Sound
            AkSoundEngine.PostEvent("PlayLVHA", gameObject);
            oscSend("lvha");

            yield return new WaitForSeconds(soundStimulusTime);

            // Stop sound; Post-stimulus silence
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            oscSend("nvna");

            yield return new WaitForSeconds(postStimulusTime);

            // Noise
            AkSoundEngine.PostEvent("PlayCalibNoise", gameObject);
            oscSend("nvna");

            yield return new WaitForSeconds(noiseTime);

            // Stop noise
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            yield return new WaitForSeconds(0.5f);  // wwise fade-out time

            // *********** HVLA *************

            // Pre-stimulus silence
            oscSend("nvna");
            yield return new WaitForSeconds(preStimulusTime);

            // Sound
            AkSoundEngine.PostEvent("PlayHVLA", gameObject);
            oscSend("hvla");

            yield return new WaitForSeconds(soundStimulusTime);

            // Stop sound; Post-stimulus silence
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            oscSend("nvna");

            yield return new WaitForSeconds(postStimulusTime);

            // Noise
            AkSoundEngine.PostEvent("PlayCalibNoise", gameObject);
            oscSend("nvna");

            yield return new WaitForSeconds(noiseTime);

            // Stop noise
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            yield return new WaitForSeconds(0.5f);  // wwise fade-out time

            // *********** HVHA *************

            // Pre-stimulus silence
            oscSend("nvna");
            yield return new WaitForSeconds(preStimulusTime);

            // Sound
            AkSoundEngine.PostEvent("PlayHVHA", gameObject);
            oscSend("hvha");

            yield return new WaitForSeconds(soundStimulusTime);

            // Stop sound; Post-stimulus silence
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            oscSend("nvna");

            yield return new WaitForSeconds(postStimulusTime);

            // Noise
            AkSoundEngine.PostEvent("PlayCalibNoise", gameObject);
            oscSend("nvna");

            yield return new WaitForSeconds(noiseTime);

            // Stop noise
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            yield return new WaitForSeconds(0.5f);  // wwise fade-out time


            cycles--;  // remove 1 from cyclesLeft
        }

        oscSend("end");

        if (timeText != null) timeText.text = "Calibration finished. Please run TRAIN and ESTIMATE.";

        calibrationEndText.SetActive(true);

        yield return new WaitForSeconds(5);
        calibrationEndText.SetActive(false);

        calibrationStarted = false;
    }

    /* OLD SEQUENCE USING RANDOMISATION IN UNITY
    IEnumerator RunSequence()
    {
        calibrationStartText.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        calibrationStartText.SetActive(false);

        yield return new WaitForSeconds(0.0f);

        while (calibrationItems.Count > 0)
        {
            // Pre-stimulus silence
            yield return new WaitForSeconds(5.0f);

            // Sound
            playIndex = Random.Range(0, calibrationItems.Count);
            AkSoundEngine.PostEvent(calibrationItems[playIndex].wwiseEventName, gameObject);
            oscSend(calibrationItems[playIndex].label);
            calibrationItems.RemoveAt(playIndex);

            yield return new WaitForSeconds(6.5f);

            // Stop sound; Post-stimulus silence
            AkSoundEngine.PostEvent("StopCalib", gameObject);
//            oscSend("soundStopped");

            yield return new WaitForSeconds(1.0f);

            // Noise
            AkSoundEngine.PostEvent(calibrationNoiseItem.wwiseEventName, gameObject);
//            oscSend("noiseStarted");

            yield return new WaitForSeconds(13.5f);

            // Stop noise
            AkSoundEngine.PostEvent("StopCalib", gameObject);
//            oscSend("noiseStopped");
        }

        oscSend("end");
        calibrationEndText.SetActive(true);

        yield return new WaitForSeconds(5);
        calibrationEndText.SetActive(false);

    }

    */

}
