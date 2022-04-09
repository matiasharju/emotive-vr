using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

// Read the arousal values from CSV file
public static class DataReaderArousalPeaks
{
    private static string _path;
    private static string _filename;

    private static List<float> _arousalPeakPwrValues = new List<float>();
    private static int _startTime = 0;       // time in tenth of seconds
    public static int _currentTime = 0;    // time in tenth of seconds
    public static int _currentPlusStartTime;

    public static void Init(string filename)
    {
        _filename = filename;
        
        _path = Application.streamingAssetsPath + "/SensorData/" + _filename;
        Debug.Log(_path);
        ReadDataFromCSV();

    }

    public static void ReadDataFromCSV()
    {
        string fileData = File.ReadAllText(_path);
        string[] values = fileData.Split('\n');

        float[] floatValues = Array.ConvertAll(values, x => float.Parse(x));
 
        _arousalPeakPwrValues.AddRange(floatValues);
    }

    public static float GetArousalPeak(float startTime)
    {
        _currentTime = (int)(Time.fixedUnscaledTime * 10f);
        //        _currentTime = (int)(Mathf.Round((Time.fixedUnscaledTime * 10f) * 1f));

        _startTime = (int)(startTime * 10);
        _currentPlusStartTime = _currentTime + _startTime;
//        Debug.Log(_currentTime + _startTime);
//        return _arousalPeakPwrValues[_currentTime + _startTime];
        return _arousalPeakPwrValues[_currentPlusStartTime];
    }

    /*
    public static void UpTime()
    {
        _currentTime++;
        _currentTime = Mathf.Clamp(_currentTime, 0, (_arousalPeakPwrValues.Count * 10) - 1);
    }
    */
}
