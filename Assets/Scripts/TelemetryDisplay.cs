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
    public Text GSRValue;
    public Text arousalCumulativePeaks;

    public GameObject realTimeDisplayObject;
    public GameObject dataTimeDisplayObject;
    public GameObject GSRValueObject;
    public GameObject arousalPeaksObject;

    void Start()
    {
        if (hideTimeDisplays)
        {
            if (realTimeDisplayObject != null) realTimeDisplayObject.SetActive(false);
            if (dataTimeDisplayObject != null) dataTimeDisplayObject.SetActive(false);
        }

        if (hideArousalValue)
        {
            if (GSRValueObject != null)
            {
                arousalPeaksObject.SetActive(false);
                GSRValueObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (!hideTimeDisplays) realTime.text = ("Running time: " + (Mathf.Round(Time.fixedUnscaledTime) * 1f) + " s").ToString();
        if (!hideTimeDisplays) dataTableTime.text = ("CSV data time: " + (DataReaderArousalPeaks._currentPlusStartTime / 10) + " s").ToString();
        if (!hideArousalValue) GSRValue.text = ("GSR: " + DataReaderArousalPeaks.arousalRawValue);
        if (!hideArousalValue) arousalCumulativePeaks.text = ("Cumulative\narousal peaks" + DirectorSequencer.cumulativeArousal);
    }
}
