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
        oscMessage = OSC.StringToOscMessage("/whatever/ " + text);
        osc.Send(oscMessage);
    }

    IEnumerator RunSequence()
    {
        calibrationStartText.SetActive(true);

        yield return new WaitForSeconds(5);

        calibrationStartText.SetActive(false);

        yield return new WaitForSeconds(1);

        while (calibrationItems.Count > 0)
        { 
            // Play noise
            AkSoundEngine.PostEvent(calibrationNoiseItem.wwiseEventName, gameObject);
            oscSend("noiseStarted");

            yield return new WaitForSeconds(5);

            // Stop the noise
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            oscSend("noiseStopped");

            yield return new WaitForSeconds(2);

            // Randomise first calibration sound item
            playIndex = Random.Range(0, calibrationItems.Count);
            AkSoundEngine.PostEvent(calibrationItems[playIndex].wwiseEventName, gameObject);
            oscSend("soundStarted with identifier " + calibrationItems[playIndex].identifier);
            calibrationItems.RemoveAt(playIndex);

            yield return new WaitForSeconds(5);

            // Stop sound
            AkSoundEngine.PostEvent("StopCalib", gameObject);
            oscSend("soundStopped");

            yield return new WaitForSeconds(1);
        }

        calibrationEndText.SetActive(true);

        yield return new WaitForSeconds(5);
        calibrationEndText.SetActive(false);

    }
}
