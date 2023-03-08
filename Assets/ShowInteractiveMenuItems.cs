using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteractiveMenuItems : MonoBehaviour
{
    public GameObject SessionIDItem;
    public GameObject NeulogIPItem;
    public GameObject InteractiveMusicItem;
    public GameObject OperatorDataItem;

    void Start()
    {
        if (DirectorSequencer.Instance.useNeuLog)
        {
            if (SessionIDItem != null) SessionIDItem.SetActive(true);
            if (NeulogIPItem != null) NeulogIPItem.SetActive(true);
            if (InteractiveMusicItem != null) InteractiveMusicItem.SetActive(true);
            if (OperatorDataItem != null) OperatorDataItem.SetActive(true);
        }
        else if (!DirectorSequencer.Instance.useNeuLog)
        {
            if (SessionIDItem != null) SessionIDItem.SetActive(false);
            if (NeulogIPItem != null) NeulogIPItem.SetActive(false);
            if (InteractiveMusicItem != null) InteractiveMusicItem.SetActive(false);
            if (OperatorDataItem != null) OperatorDataItem.SetActive(false);
        }

    }


}
