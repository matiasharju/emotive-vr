using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NeuLogToggleDisplay : MonoBehaviour
{
    public Text textNeuLog;
    public Text textCSV;
    Color darkGrey;

    void Start()
    {
       darkGrey = new Color(0.1f, 0.1f, 0.1f, 1.0f);
    }


    void Update()
    {
        if (DirectorSequencer.useNeuLog)
        {
            if (textNeuLog != null) textNeuLog.color = Color.white;
            if (textCSV != null) textCSV.color = darkGrey;
        }
        else if (!DirectorSequencer.useNeuLog)
        {
            if (textNeuLog != null) textNeuLog.color = darkGrey;
            if (textCSV != null) textCSV.color = Color.white;
        }


    }
}
