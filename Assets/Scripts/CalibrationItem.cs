using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK;

[CreateAssetMenu(fileName = "CalibrationItem")]

public class CalibrationItem : ScriptableObject
{
    [Header("Wwise")]
    public string wwiseEventName;
    //    public AK.Wwise.Event wwiseEvent;
    [Header("Stimulation label sent to OpenVibe")]
    public string label;
}
