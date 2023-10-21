using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

// Manage all audio and wwise events on the scene
public class AudioManager : MonoBehaviour
{
    // The source of the sound. A source is needed for Wwise to make sur spatialization work correctly
    public GameObject source;

    // The current loaded soundbank
    public string currentBankName;

    // The current Wwise audio event name
    public string eventName;

    // The volume of the audio effect (for Wwise only)
    [Range(-50, 12)] public float audioVolume;

    // The volume of the music (for Wwise only)
    [Range(-50, 12)] public float musicVolume;

    // The valence value
    [Range(0, 1)] public float valence;

    // The arousal value
    [Range(0, 1)] public float arousal;

    //public float arousalFadeDownSpeed = 0.005f;


    public void SeekAudio(int seekTimeMs)
    {
        AkSoundEngine.SeekOnEvent(AkSoundEngine.GetIDFromString(eventName), source, seekTimeMs);
        Debug.Log("Audio seeked to: " + seekTimeMs + " ms");
    }


    // To load a soundbank with the name
    public void LoadSoundBank(string soundBankName)
    {
        if (currentBankName != soundBankName)
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
        //        AkSoundEngine.PostEvent(evtName, source);

        object cookie = 0;
        AkCallbackType CallbackType = AkCallbackType.AK_EnableGetSourcePlayPosition;

        AkSoundEngine.PostEvent(evtName, source, (uint)CallbackType, EnableGetSourcePosition, cookie);

        Debug.Log(Time.realtimeSinceStartup + " : Posted Wwise event: " + evtName);
        eventName = evtName;
    }


    void EnableGetSourcePosition(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        Debug.Log("Enabled GetSourcePosition");
    }

    public void GetAudioPosition()
    {
        AkSoundEngine.GetSourcePlayPosition(AkSoundEngine.GetIDFromString(eventName), out int position);
        //Debug.Log(position);
    }


    // Change the valence value
    public void SetNewValenceValue(float newValence)
    {
        valence = newValence;
    }
    public void SetNewArousalValue(float newArousal)
    {
        arousal = newArousal;
    }

    //  Change the momentary arousal peak power value  
    /*    public void SetNewArousalPeakValue(float newArousalPeak)
        {
            arousalPeak = newArousalPeak;

            // Add peak value to the cumulative arousal value. Keep fading down slowly.
            cumulativeArousal = cumulativeArousal + arousalPeak;
            if (cumulativeArousal > 0) cumulativeArousal = cumulativeArousal - arousalFadeDownSpeed;
            if (cumulativeArousal < 0) cumulativeArousal = 0.0f;
        }
    */


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

        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("ArousalLevel"), arousal);
        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("ValenceLevel"), valence);

    }



}
