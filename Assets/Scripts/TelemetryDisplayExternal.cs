using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelemetryDisplayExternal : MonoBehaviour
{
    public Text realTime;
    public Text dataTableTime;
    public Text arousalValue;

    public GameObject realTimeDisplayObject;
    public GameObject dataTimeDisplayObject;
    public GameObject arousalValueObject;


    void Start()
    {
        StartCoroutine(UpdateDisplays());
    }

    IEnumerator UpdateDisplays()
    {
        while(true)
        {
            realTime.text = ("Real time: " + (Mathf.Round(Time.fixedUnscaledTime) * 1f) + " s").ToString();
            dataTableTime.text = ("Data time: " + (DataReaderArousal._currentPlusStartTime / 10) + " s").ToString();
            arousalValue.text = ("Arousal cumulative:\n" + DirectorSequencer.Instance.cumulativeArousal);
        }

    }
}
