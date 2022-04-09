using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelemetryDisplay : MonoBehaviour
{
    public bool hideTimeDisplays;
    public bool hideArousalValue;

    public Text realTime;
    public Text dataTableTime;
    public Text arousalValue;

    public GameObject realTimeDisplayObject;
    public GameObject dataTimeDisplayObject;
    public GameObject arousalValueObject;

    void Start()
    {
        if (hideTimeDisplays)
        {
            if (realTimeDisplayObject != null) realTimeDisplayObject.SetActive(false);
            if (dataTimeDisplayObject != null) dataTimeDisplayObject.SetActive(false);
        }

        if (hideArousalValue)
        {
            if (arousalValueObject != null) arousalValueObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!hideTimeDisplays) realTime.text = ("Real time: " + (Mathf.Round(Time.fixedUnscaledTime) * 1f) + " s").ToString();
        if (!hideTimeDisplays) dataTableTime.text = ("Data time: " + (DataReaderArousalPeaks._currentPlusStartTime / 10) + " s").ToString();
        if (!hideArousalValue) arousalValue.text = ("Arousal cumulative:\n" + DirectorSequencer.cumulativeArousal);
    }
}
