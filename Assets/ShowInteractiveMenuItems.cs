using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteractiveMenuItems : MonoBehaviour
{
    public GameObject SessionIDItem;
    public GameObject NeulogIPItem;
    public GameObject InteractiveMusicItem;
    public GameObject OperatorDataItem;
    public GameObject InteractiveItem;
    public GameObject NonInteractiveItem;

    void Update()
    {
        if (DirectorSequencer.Instance.isInteractive)
        {
            {
                if (InteractiveItem != null) InteractiveItem.SetActive(true);
                if (NonInteractiveItem != null) NonInteractiveItem.SetActive(false);
            }

            if (SessionIDItem != null) SessionIDItem.SetActive(true);
            if (NeulogIPItem != null) NeulogIPItem.SetActive(true);
            if (InteractiveMusicItem != null) InteractiveMusicItem.SetActive(true);
            if (OperatorDataItem != null) OperatorDataItem.SetActive(true);
        }
        else if (!DirectorSequencer.Instance.isInteractive)
        {
            {
                if (InteractiveItem != null) InteractiveItem.SetActive(false);
                if (NonInteractiveItem != null) NonInteractiveItem.SetActive(true);
            }

            if (SessionIDItem != null) SessionIDItem.SetActive(false);
            if (NeulogIPItem != null) NeulogIPItem.SetActive(false);
            if (InteractiveMusicItem != null) InteractiveMusicItem.SetActive(false);
            if (OperatorDataItem != null) OperatorDataItem.SetActive(false);
        }

    }


}
