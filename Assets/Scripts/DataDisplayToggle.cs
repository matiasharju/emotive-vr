using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDisplayToggle : MonoBehaviour
{
    GameObject emotionTable;
    public TextMesh textMeshOn;
    public TextMesh textMeshOff;
    Color darkGrey;

    void Start()
    {
        emotionTable = GameObject.Find("/EmotionTable");
        darkGrey = new Color(0.1f, 0.1f, 0.1f, 1.0f);
    }

    void Update()
    {
        if ((emotionTable != null) && (emotionTable.activeSelf))
        {
            if (textMeshOn != null) textMeshOn.color = Color.white;
            if (textMeshOff != null) textMeshOff.color = darkGrey;
        }
        else if ((emotionTable != null) && (!emotionTable.activeSelf))
        {
            if (textMeshOn != null) textMeshOn.color = darkGrey;
            if (textMeshOff != null) textMeshOff.color = Color.white;
        }

    }
}
