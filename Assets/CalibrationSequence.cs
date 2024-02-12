using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationSequence : MonoBehaviour
{
    public CalibrationItem calibrationNoiseItem;
    public List<CalibrationItem> calibrationItems;
    public AudioManager audioManager;
    private int playIndex;
    private List<int> playedItems = new List<int>();              // for keeping track of already played items (for not to play them multiple times)
    public OSC osc;
    private OscMessage oscMessage;
    public GameObject calibrationStartText;
    public GameObject calibrationEndText;

    void Start()
    {
        StartCoroutine(RunSequence());
    }

    void Update()
    {
        
    }

    public void oscSend(string text)
    {
        oscMessage = OSC.StringToOscMessage("/ov/stimulation " + text);
        osc.Send(oscMessage);
    }

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
}
