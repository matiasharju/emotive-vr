using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSyncSlateToggle : MonoBehaviour
{
    public Text textOn;
    public Text textOff;
    Color darkGrey;
    public KeyboardControls keyboardControls;

    void Start()
    {
        darkGrey = new Color(0.1f, 0.1f, 0.1f, 1.0f);
    }

    void Update()
    {
        if ((keyboardControls != null) && (keyboardControls.useSyncSlate))
        {
            if (textOn != null) textOn.color = Color.white;
            if (textOff != null) textOff.color = darkGrey;
        }
        else if ((keyboardControls != null) && (!keyboardControls.useSyncSlate))
        {
            if (textOn != null) textOn.color = darkGrey;
            if (textOff != null) textOff.color = Color.white;
        }

    }
}
