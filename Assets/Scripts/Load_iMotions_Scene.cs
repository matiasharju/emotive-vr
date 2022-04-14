using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_iMotions_Scene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync("Example-iMotions-ViveSR-SteamVR2", LoadSceneMode.Additive);
    }
}
