using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenInfoToggle : MonoBehaviour
{
    public GameObject infoTextObject;
    bool done = false;

    void Update()
    {
        if (DirectorSequencer.Instance.enableInteractiveMusic && infoTextObject != null ) infoTextObject.SetActive(true);
        else if (!DirectorSequencer.Instance.enableInteractiveMusic && infoTextObject != null) infoTextObject.SetActive(false);

        if (DirectorSequencer.Instance.currentSequence != null)
        {
            if (!DirectorSequencer.Instance.currentSequence.thisIsStartScene & !done)
                {
                    gameObject.SetActive(false);
                    done = true;
                }
        }
    }
}
