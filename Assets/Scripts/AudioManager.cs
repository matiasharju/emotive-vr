using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage all audio and wwise events on the scene
public class AudioManager : MonoBehaviour
{
    // The source of the sound. A source is needed for Wwise to make sur spatialization work correctly
    public GameObject source;

    // The current loaded soundbank
    public string currentBankName;

    // The volume of the audio effect (for Wwise only)
    [Range(-50, 12)] public float audioVolume;
    
    // The volume of the music (for Wwise only)
    [Range(-50, 12)] public float musicVolume;

    // The valence value. Actually she is defined by a external CSV file
    [Range(0, 1)] public float valence;

    // The arousal peak power value from the external CSV file
    [Range(0, 2)] public float arousalPeak;

    // Cumulative arousal value. Grows by each arousal peak, but fades down if no peaks appear
    [Range(0, 2)] public float cumulativeArousal;

    public float arousalFadeDownSpeed = 0.005f;

    // If we want to use a random smoothed valence
    public bool usePseudoValence;

    private void Start()
    {
        if (usePseudoValence == true)
        {
            GetComponent<PseudoValenceRTPC>().enabled = true;
        }

        else
        {
            GetComponent<PseudoValenceRTPC>().enabled = false;
        }

    }


    // To load a soundbank with the name
    public void LoadSoundBank(string soundBankName)
    {
        if(currentBankName != soundBankName)
        {
            // Before load, we need to unload the previous soundbank
            UnloadSoundBank(); 
            currentBankName = soundBankName;
            AkBankManager.LoadBank(soundBankName, false, false);
        }
       
    }

    // Unload the current soundBank
    public void UnloadSoundBank()
    {
        currentBankName = string.Empty;
        // To unload the soundbank, we need to stop all playing audio events
        AkSoundEngine.StopAll();
        AkBankManager.UnloadBank(currentBankName);
    }

    // Set an audio event
    public void SetEvent(string evtName, float delay = 0)
    {
        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("startDelay"), delay);
        AkSoundEngine.PostEvent(evtName, source);  
    }

    // Change the valence value
    public void SetNewValenceValue(float newValence)
    {
        valence = newValence;
    }

    //  Change the momentary arousal peak power value  
    public void SetNewArousalPeakValue(float newArousalPeak)
    {
        arousalPeak = newArousalPeak;

        // Add peak value to the cumulative arousal value. Keep fading down slowly.
        cumulativeArousal = cumulativeArousal + arousalPeak;
        if (cumulativeArousal > 0) cumulativeArousal = cumulativeArousal - arousalFadeDownSpeed;
        if (cumulativeArousal < 0) cumulativeArousal = 0.0f;
    }


    // Change the volume of music and audio (not used now)
    public void ChangeVolumeParameters(float newAudioVol, float newMusicVol)
    {
        audioVolume = newAudioVol;
        musicVolume = newMusicVol;
    }

    // Pause an event
    public void Pause()
    {
        AkSoundEngine.PostEvent("PauseAll", source);
    }

    // Play an event
    public void Resume()
    {
        AkSoundEngine.PostEvent("ResumeAll", source);
    }

    private void Update()
    {
        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("AudioVolume"), audioVolume);
        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("MusicVolume"), musicVolume);

        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("ArousalLevel"), cumulativeArousal);

        if (usePseudoValence == false)
        {
            AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("ValenceLevel"), valence);
        }

    }


}
