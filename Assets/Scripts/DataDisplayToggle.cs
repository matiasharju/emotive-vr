using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayToggle : MonoBehaviour
{
    GameObject emotionTable;
    public Text textOn;
    public Text textOff;
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
            if (textOn != null) textOn.color = Color.white;
            if (textOff != null) textOff.color = darkGrey;
        }
        else if ((emotionTable != null) && (!emotionTable.activeSelf))
        {
            if (textOn != null) textOn.color = darkGrey;
            if (textOff != null) textOff.color = Color.white;
        }

    }
}
