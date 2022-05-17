using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
// using Valve.VR;


public class DirectorSequencer : MonoBehaviour
{
    public static DirectorSequencer Instance { private set; get; }

    
    [Header("Control Sequences")]
    public int indexSequence = 0;
    public List<Sequence> sequences;
    public Sequence currentSequence;

    [Header("Parameters")]
    public bool isInteractive = true;
    public float timeToChoice = 3;
    public float timerChoiceEpi = 0;
    public float timer = 0;
    public float delay;
    public float updateValenceTime = 0.1f;
    public float synchronizeTimer = 0;
    public float timeToFade = 2;

    public string loadedSceneName;

    public bool activeSubtitle = true;
    public bool vr = false;

    public float epilogueSrtDelay;

    [Header("References")]
    public List<Camera> allCameras;
    public SRTManager srtManager;
    public VideoPlayer player;
    public VideoPlayer cutPlayer;
    public GameObject emotionalBar;
    public GameObject emotionTable;
    public GameObject emotionTableExternal;
    public AudioManager audioManager;
    public Animator fadeAnimator;
    public RenderTexture cutRt;
    public Canvas canvasSubtitle;
	public Animator fadeCanvas;
    public PseudoDataInput pseudoDataInput;
    public EmotionTable emotionTableScript;
    public NeuLogAPIRequest neuLogAPIRequestScript;


    [HideInInspector] public Camera cam;

    [Header("States")]
    public bool play = false;
    public bool fadeDone = false;
    public bool waitEndScene = false;
    public bool activeRaycast = false;
    public bool showEpilogue = false;
    public bool updateBarPos = false;

    [Header("ChoiceSequenceAudio")]
    public string choiceSeqSoundstopEvent = "StopChoixSounds";
    public string choiceSeqOldFreudStopEvent = "StopOldFreud";

    private readonly float _timerChoice = 0;
	private float _timerManualSubtitle = 0;

    private Quaternion startRotation;
    private GameObject _hitObject;

    //    private SteamVR_LoadLevel vrSceneManager;

    [Header("Stats")]
    public bool FreudPlayed = false;
    public bool KarlPlayed = false;

    [Header("Arousal Data")]
    public static bool useNeuLog = true;

    public string GSRDataCSVFilename = "03_GSR_Only.csv";
    public string ArousalPeakCSVFilename = "03_peakPwrOnly.csv";
    public float arousalFadeDownSpeed = 0.005f;

    public float arousalRawValue;
    public float GSRCalibrationMultiplier = 1.0f;       // to calibrate the incoming GSR value with a multiplier constant

    // Cumulative arousal value. Grows by each arousal peak, but fades down if no peaks appear
    public float cumulativeArousal;


    private void Awake()
    {
        Instance = this;
     
        if(vr)
            {
                cam = allCameras[1];
                cam.transform.parent.gameObject.SetActive(true);
//                fadeAnimator.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                cam = allCameras[0];
                cam.gameObject.SetActive(true);

            }

           
        startRotation = cam.transform.rotation;
        canvasSubtitle.worldCamera = cam;
    }

    private void Start()
    {
        /*        vrSceneManager = GetComponent<SteamVR_LoadLevel>();
                vrSceneManager.fadeInTime = timeToFade;
                vrSceneManager.fadeOutTime = timeToFade;
        */

        if(activeSubtitle)
            srtManager.Init(sequences);

        // Add a callback when the video is finished
        player.loopPointReached += EndVideo;

        player.EnableAudioTrack(0, false);


        // START READING EMOTIONAL DATA 
        DataReaderArousal.Init(GSRDataCSVFilename, ArousalPeakCSVFilename);

        PrepareVideo();

        Invoke("StartEmotionalDataCoroutine", 1.0f);

    }

    private void StartEmotionalDataCoroutine()
    {
        StartCoroutine(CO_UpdateEmotionalData());
    }

    private void Update()
    {
        if(currentSequence != null)
        {
            // If we load an additional scene and we didn't wait an interaction
            if (waitEndScene && !currentSequence.waitInteraction)
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    waitEndScene = false;
                    timer = 0;

                    if(!vr)
                        StartCoroutine(Coroutine_FadeInBlack());
                    else
                        StartCoroutine(Coroutine_FadeInBlack_VR());
                }
            }

            if (currentSequence.cutSequence && fadeDone)
            {
                timer += Time.deltaTime;
                if (timer >= delay)
                {
                    timer = 0;
                    fadeDone = false;

                    if (!vr)
                        StartCoroutine(Coroutine_FadeInBlack());
                    else
                        StartCoroutine(Coroutine_FadeInBlack_VR());
                }
            }

            if (activeRaycast)
            {
                RaycastHit hit;
                // We fire a raycast from the camera position to the camera forward
                Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
                {
                    if (hit.collider != null)
                    {
                        if (_hitObject != null && _hitObject != hit.collider.gameObject)
                        {
                            _hitObject.GetComponent<ChoiceSequence>().OnRaycastExit();
                        }

                        _hitObject = hit.collider.gameObject;
                        _hitObject.GetComponent<ChoiceSequence>().OnRaycastEnter();
                    }
                   
                }
                else
                {
                    if(_hitObject != null)
                        _hitObject.GetComponent<ChoiceSequence>().OnRaycastExit();

                    _hitObject = null;
                }
            }
        }

        if(updateBarPos)
        {
            
            emotionalBar.GetComponent<EmotionBar>().UpdateBar(player.frame);
        }
       
    }

    public void PlayFreud(FreudOrKarl choice)
    {
        AddSequences(choice.GetFreudSequences());
        srtManager.AddSubtitles(choice.GetFreudSequences());

        if (!vr)
            StartCoroutine(Coroutine_FadeInBlack());
        else
            StartCoroutine(Coroutine_FadeInBlack_VR());
    }

    public void PlayKarl(FreudOrKarl choice)
    {
        AddSequences(choice.GetKarlSequences());
        srtManager.AddSubtitles(choice.GetKarlSequences());

        if (!vr)
            StartCoroutine(Coroutine_FadeInBlack());
        else
            StartCoroutine(Coroutine_FadeInBlack_VR());
    }

    public void ValidateChoice(ChoiceSequence choice)
    {
        if (!choice.nextSequence)       // If false, adds sequences from the list of sequences in the choice script; If true, continues to the next sequence in the main list
        {
            AddSequences(choice.GetSequence());
            srtManager.AddSubtitles(choice.GetSequence());
        }

		activeRaycast = false;
        showEpilogue = true;

        if (!vr)
            StartCoroutine(Coroutine_FadeInBlack());
        else
            StartCoroutine(Coroutine_FadeInBlack_VR());

        // fade out choice sequence sounds
        //        choiceSeqMuteSnapshot.TransitionTo(choiceSeqMuteFadeTime);
        audioManager.SetEvent(choiceSeqSoundstopEvent, 0);
        audioManager.SetEvent(choiceSeqOldFreudStopEvent, 0);
    }

    // Called by the "Press space to start playback" scene
    public void PlayNextSequenceFromStartScreen()
    {
        indexSequence = 1;
        StartCoroutine(Coroutine_FadeInBlack_VR());
    }

    private void PrepareVideo()
    {
        play = false;
        if (indexSequence < sequences.Count)
        {
            currentSequence = sequences[indexSequence];
            if (currentSequence.clip != null)
            {
                SetupSequence(currentSequence);
                player.Prepare();
                player.prepareCompleted += SetNextVideo;
                player.isLooping = currentSequence.videoLoop;
            }
            else
            {
                SetNextVideo(player);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            indexSequence = 0;
        }
    }

    private void SetNextVideo(VideoPlayer vp)
    {
        
        player.prepareCompleted -= SetNextVideo;

//        emotionalBar.SetActive(currentSequence.showEmotionalBar);

        if ((currentSequence.showEmotionalBar) && (emotionTable != null)) emotionTableScript.FadeIn();
        if ((!currentSequence.showEmotionalBar) && (emotionTable != null)) emotionTableScript.FadeOut();


        // SETUP ADDITIONAL SCENE
        if (currentSequence.addScene)
        {
            AddScene(currentSequence);

            if(currentSequence.waitInteraction)
            {
                activeRaycast = true;
            }
        }

        if(currentSequence.delayBeforeNextSequence != 0)
        {
            delay = currentSequence.delayBeforeNextSequence;
        }

        if(currentSequence.clearVideo)
        {
            player.Stop();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = Color.black;
            audioManager.UnloadSoundBank();
        }
        else
        {
            cam.clearFlags = CameraClearFlags.Skybox;
        }

        // OBSOLETE: EMOTIONAL BAR INIT
        //        if(currentSequence.showEmotionalBar)
        //        {


        if (currentSequence.barInfo.Count > 0)
            {
                emotionalBar.GetComponent<EmotionBar>().MapBarInfo(currentSequence.barInfo);
                updateBarPos = true;
            }

			emotionalBar.GetComponent<EmotionBar>().ShowOrHideBackground(currentSequence.showBackground);
            emotionalBar.GetComponent<EmotionBar>().ShowOrHideText(currentSequence.hideText);
//        }

        // SETUP AUDIO
        if (!string.IsNullOrEmpty(currentSequence.soundBankName))
        {
            audioManager.LoadSoundBank(currentSequence.soundBankName);
        }

        if(currentSequence.audioEvtNames.Count > 0)
        {
            StartCoroutine(CO_WaitVideoToLaunchAudio());
        }
       

        if(currentSequence.usePostProcess)
        {
            cam.GetComponent<CameraManager>().SetPostProcess(true, currentSequence.profile);
        }
        else
        {
            cam.GetComponent<CameraManager>().SetPostProcess(false, null);
        }

        if(activeSubtitle)
        {
            srtManager.SetSubtitles(currentSequence.name);
        }

        if(vr)
        {
            StartCoroutine(Coroutine_FadeOutBlack_VR());
        }
        else
        {
            StartCoroutine(Coroutine_FadeOutBlack());
        }

		play = true;
		player.Play();

        if (currentSequence.thisIsFreud) FreudPlayed = true;
        if (currentSequence.thisIsKarl) KarlPlayed = true;

        if(currentSequence.epilogue)
        {
            // does nothing; StartOldFreudSrt() waits a message from the prologue / epilogue scene
        }
        else
        {
            StartCoroutine(srtManager.Begin());
//            Debug.Log("Start subtitles");
        }
		    
        ++indexSequence;
    }

// Start Epilogue subtitles
    public void StartOldFreudSrt()       // Gets called from the prologue / epilogue scene when audio sources are running
    {
        StartCoroutine(srtManager.Begin());
 //       Debug.Log("Audio started. Start srtManager");
    }

// Callback when the video is finish
private void EndVideo(VideoPlayer vp)
    {
        if (!player.isLooping)
        {
            player.Stop();
            // Check if we can go to the next video
            if (!currentSequence.waitInteraction && currentSequence.delayBeforeNextSequence == 0)
            {
                if (!vr)
                    StartCoroutine(Coroutine_FadeInBlack());
                else
                    StartCoroutine(Coroutine_FadeInBlack_VR());
            }
        }
    }

    #region Sequences
    // Set the sequence to the scene. Update video and render texture and set to the skybox material. Active the bar if it's necessary
    private void SetupSequence(Sequence sequence)
    {
        player.clip = sequence.clip;
        player.targetTexture = sequence.rt;
        player.audioOutputMode = sequence.useAudioFromVideo?VideoAudioOutputMode.Direct:VideoAudioOutputMode.None;
        player.EnableAudioTrack(0,sequence.useAudioFromVideo);
        RenderSettings.skybox.mainTexture = sequence.rt;

    }

    // Add a range of new sequences in the list (for the choice scene)
    private void AddSequences(List<Sequence> newSequences)
    {
        sequences.InsertRange(indexSequence, newSequences);
    }


    // Check if the sequence list contains a sequence
    public bool ContainSequence(Sequence sequence)
    {
        return sequences.Contains(sequence);
    }

    #endregion


    #region Fade Event

    public void EndFadeInBlack()
    {
//        Debug.Log("EndFadeInBlack");
		if(currentSequence.addScene)
		{
			RemoveScene();
		}
        PrepareVideo();
    }

    public void EndFadeOutBlack()
    {
//        Debug.Log("EndFadeOutBlack");
    }
    #endregion

    #region Scene Management
    // Load an additional scene in Additive Mode
    private void AddScene(Sequence sequence)
    {
        SceneManager.LoadSceneAsync(sequence.sceneNameToLoad, LoadSceneMode.Additive);
        waitEndScene = true;
        loadedSceneName = sequence.sceneNameToLoad;
        
    }

    // Unload an scene
    private void RemoveScene()
    {
		waitEndScene = false;
		SceneManager.UnloadSceneAsync(loadedSceneName);
    }
    #endregion

    #region Coroutines
    IEnumerator CO_UpdateEmotionalData()
    {
        while(true)
//        while(currentSequence.readSensorData && isInteractive)
        {
            //DataReader.UpTime();          
            //float valence = DataReaderValence.GetValence();     // Read valence from CSV
            //DataReaderArousal.UpTime();                // update arousal data reader's clock, add start time offset
            //float arousalPeak = DataReaderArousalPeaks.GetArousalPeak(currentSequence.sensorDataStartTime);    // Read arousal data from CSV and let the sequence adjust the start time

            if (useNeuLog)
            {
                neuLogAPIRequestScript.RequestArousalFromNeuLog();                      // Send HTTP request to NeuLog for arousal data
                arousalRawValue = DataReaderArousal.arousalRawValuePublic * GSRCalibrationMultiplier;              // Read arousal raw value from NeuLog sensor
            }
            else if (!useNeuLog)
            {
                arousalRawValue = DataReaderArousal.ReadArousalFromCSV(currentSequence.sensorDataStartTime);        // Read arousal raw value from csv from the timepoint defined from the sequence
            }

            float arousalPeak = DataReaderArousal.CalculateArousalPeaks(arousalRawValue);           // Calculate arousal peaks

            // Add peak value to the cumulative arousal value. Keep fading down slowly.
            cumulativeArousal = cumulativeArousal + arousalPeak;                                // cumulative arousal will be reset to 0 when pressing spacebar to start playback
            if (cumulativeArousal > 0) cumulativeArousal = cumulativeArousal - arousalFadeDownSpeed;
            if (cumulativeArousal < 0) cumulativeArousal = 0.0f;

            float valence = pseudoDataInput.GetValence();   // Read from debug valence slider
            // float arousal = pseudoDataInput.GetArousal();

            audioManager.SetNewValenceValue(valence);
            audioManager.SetNewArousalValue(cumulativeArousal);

            if (currentSequence.updateColorFromValence)
            {
                cam.GetComponent<CameraManager>().UpdateFilterColor(valence);
            }

            if (emotionTable.activeSelf)
            {
                emotionalBar.GetComponent<EmotionBar>().UpdateEmotionBar(valence);
                emotionTable.GetComponent<EmotionTable>().UpdateEmotionTable(valence, cumulativeArousal);
            }

            if (emotionTableExternal.activeSelf)
            {
                emotionTableExternal.GetComponent<EmotionTableExternal>().UpdateEmotionTable(valence, cumulativeArousal);
                emotionTableExternal.GetComponent<EmotionTableExternal>().DrawDataDiagram(arousalRawValue);
            }


            yield return new WaitForSeconds(updateValenceTime);
        }

        //        cam.GetComponent<CameraManager>().DisablePostProcess();

        yield return null;

    }

    IEnumerator CO_WaitVideoToLaunchAudio()
    {
        while(!player.isPlaying)
        {
            yield return null;
        }

        if(currentSequence.forceSynchronize)
        {
            while(synchronizeTimer < currentSequence.timeValue)
            {
                synchronizeTimer += Time.deltaTime;
                yield return null;
            }
        }
        synchronizeTimer = 0;
        foreach (string evtName in currentSequence.audioEvtNames)
        {
            if (!string.IsNullOrEmpty(evtName))
            {
				audioManager.SetEvent(evtName, currentSequence.delay);
            }
        }
    }

    IEnumerator Coroutine_FadeInBlack()
    {
//        Debug.Log("Coroutine_FadeInBlack");

        fadeDone = false;
        fadeAnimator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorStateInfo(0).length);

        EndFadeInBlack();
        yield return null;
    }

    IEnumerator Coroutine_FadeOutBlack()
    {
   //    Debug.Log("Coroutine_FadeOutBlack");

        fadeAnimator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorStateInfo(0).length);

        fadeDone = true;
        EndFadeOutBlack();
        yield return null;
    }

    IEnumerator Coroutine_FadeInBlack_VR()
    {
//        Debug.Log("Coroutine_FadeInBlack_VR");

        fadeCanvas.SetBool("FadeIn", true);


        yield return new WaitForSeconds(fadeCanvas.GetCurrentAnimatorStateInfo(0).length + 1);

        EndFadeInBlack();
        yield return null;
    }

    IEnumerator Coroutine_FadeOutBlack_VR()
    {
   //     Debug.Log("Coroutine_FadeOutBlack_VR");

        yield return new WaitForSeconds(1);

		fadeCanvas.SetBool("FadeIn", false);
        fadeCanvas.SetBool("FadeOut", true);
        yield return new WaitForSeconds(fadeCanvas.GetCurrentAnimatorStateInfo(0).length);
		fadeCanvas.SetBool("FadeOut", false);
        fadeDone = true;
        EndFadeOutBlack();
        yield return null;
    }


    IEnumerator CO_ForceSynchroEpilogue(float delay)
    {
   //     Debug.Log("Force delay epilogue subtitles for " + delay + " seconds");
        yield return new WaitForSeconds(delay);

        StartCoroutine(srtManager.Begin());
  //      Debug.Log("Start srtManager");
    }
    #endregion
}
