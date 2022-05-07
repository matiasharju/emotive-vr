using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleToggleDisplay : MonoBehaviour
{
    GameObject subtitleCanvas;
    public Text textOn;
    public Text textOff;
    Color darkGrey;

    void Start()
    {
        subtitleCanvas = GameObject.Find("/Canvas_Subtitles");
        darkGrey = new Color(0.1f, 0.1f, 0.1f, 1.0f);
    }

    void Update()
    {
        if ((subtitleCanvas != null) && (subtitleCanvas.activeSelf))
        {
            if (textOn != null) textOn.color = Color.white;
            if (textOff != null) textOff.color = darkGrey;
        }
        else if ((subtitleCanvas != null) && (!subtitleCanvas.activeSelf))
        {
            if (textOn != null) textOn.color = darkGrey;
            if (textOff != null) textOff.color = Color.white;
        }

    }
}
