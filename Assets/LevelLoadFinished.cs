using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadFinished : MonoBehaviour
{
    public GameObject menuItems;
    public GameObject pressSpaceUI;
    public GameObject loadScreenUI;
    bool StartSceneLoaded = false;
    bool MainSceneLoaded = false;
    bool done = false;

    private void Start()
    {
        if (loadScreenUI != null) loadScreenUI.SetActive(true);
        if (menuItems!= null) menuItems.SetActive(false);
        if (pressSpaceUI!= null) pressSpaceUI.SetActive(false);
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level " + scene.name + " loaded");

        if (scene.name == "Main")
        {
            MainSceneLoaded = true;
            done = false;
        };


        if (scene.name == "00_StartPlayback")
        {
            StartSceneLoaded = true;
        };


    }

    private void Update()
    {
        if (!done && StartSceneLoaded && MainSceneLoaded)
        {
            if (loadScreenUI != null) loadScreenUI.SetActive(false);
            if (menuItems != null) menuItems.SetActive(true);
            if (pressSpaceUI != null) pressSpaceUI.SetActive(true);
            done = true;
        }

    }
}
