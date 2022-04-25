using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleToggleDisplay : MonoBehaviour
{
    GameObject subtitleCanvas;
    public TextMesh textMeshOn;
    public TextMesh textMeshOff;
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
            if (textMeshOn != null) textMeshOn.color = Color.white;
            if (textMeshOff != null) textMeshOff.color = darkGrey;
        }
        else if ((subtitleCanvas != null) && (!subtitleCanvas.activeSelf))
        {
            if (textMeshOn != null) textMeshOn.color = darkGrey;
            if (textMeshOff != null) textMeshOff.color = Color.white;
        }

    }
}
