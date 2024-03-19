using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelemetryDisplay : MonoBehaviour
{
    public bool hideTimeDisplays;
    public bool hideArousalValues;

    public Text realTime;
    public Text dataTableTime;
    public Text GSRValue;
    public Text GSRCalibration;
    public Text arousalCumulativePeaks;

//    public GameObject realTimeDisplayObject;
//    public GameObject dataTimeDisplayObject;
    public GameObject GSRValueObject;
    public GameObject GSRCalibrationObject;
//    public GameObject arousalPeaksObject;

    void Start()
    {
        if (hideTimeDisplays)
        {
  //          if (realTimeDisplayObject != null) realTimeDisplayObject.SetActive(false);
  //          if (dataTimeDisplayObject != null) dataTimeDisplayObject.SetActive(false);
        }

        if (hideArousalValues)
        {
            if (GSRValueObject != null)
            {
  //              arousalPeaksObject.SetActive(false);
                GSRValueObject.SetActive(false);
            }
        }

        StartCoroutine(UpdateDisplays());
    }

    IEnumerator UpdateDisplays()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
//            if (!hideTimeDisplays && realTimeDisplayObject != null) realTime.text = ("Running time: " + (Mathf.Round(Time.fixedUnscaledTime) * 1f) + " s").ToString();
//            if (!hideTimeDisplays && dataTimeDisplayObject != null) dataTableTime.text = ("CSV data time: " + (DataReaderArousal._currentPlusStartTime / 10) + " s").ToString();
            if (!hideArousalValues && GSRValueObject != null) GSRValue.text = ("Arousal: " + (DirectorSequencer.Instance.arousal).ToString("F2"));
//            if (!hideArousalValues && GSRCalibrationObject != null) GSRCalibration.text = ("Cal: " + DirectorSequencer.Instance.GSRCalibrationMultiplier.ToString("F2"));
//            if (!hideArousalValues && arousalPeaksObject != null) arousalCumulativePeaks.text = ("Cumulative\narousal peaks:\n" + DirectorSequencer.Instance.arousal.ToString("F3"));

            yield return new WaitForSeconds(0.1f);
        }
    }


}
