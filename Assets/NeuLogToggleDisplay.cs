using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuLogToggleDisplay : MonoBehaviour
{
    public TextMesh textMeshOn;
    public TextMesh textMeshOff;
    Color darkGrey;

    void Start()
    {
       darkGrey = new Color(0.1f, 0.1f, 0.1f, 1.0f);
    }


    void Update()
    {
        if (DirectorSequencer.useNeuLog)
        {
            if (textMeshOn != null) textMeshOn.color = Color.white;
            if (textMeshOff != null) textMeshOff.color = darkGrey;
        }
        else if (!DirectorSequencer.useNeuLog)
        {
            if (textMeshOn != null) textMeshOn.color = darkGrey;
            if (textMeshOff != null) textMeshOff.color = Color.white;
        }


    }
}
