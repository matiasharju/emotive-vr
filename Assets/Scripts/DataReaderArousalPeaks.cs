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
    private static string _pathGSR;
    private static string _filenameGSR;

    private static List<float> _arousalPeakPwrValues = new List<float>();
    private static int _startTime = 0;       // time in tenth of seconds
    public static int _currentTime = 0;    // time in tenth of seconds
    public static int _currentPlusStartTime;

    private static float arousalPeak;
    private static float arousalValley;

    private static float arousalPeakPwr;
    public static bool peakReached = false;
    public static bool valleyReached = false;
    public static float oldArousalValue;

    private static List<float> _GSRValues = new List<float>();
    private static float arousalPeakGSR;
    private static float arousalValleyGSR;

    private static float arousalPeakPwrGSR;
    public static bool peakReachedGSR = false;
    public static bool valleyReachedGSR = false;
    public static float oldArousalValueGSR = 0.0f;


    public static void Init(string filename)
    {
        _filename = filename;
        
        _path = Application.streamingAssetsPath + "/SensorData/" + _filename;
        _pathGSR = Application.streamingAssetsPath + "/SensorData/03_GSR_Only.csv";
//        Debug.Log(_path);
        ReadDataFromCSV();

    }

    public static void ReadDataFromCSV()
    {
        string fileData = File.ReadAllText(_path);
        string[] values = fileData.Split('\n');

        float[] floatValues = Array.ConvertAll(values, x => float.Parse(x));
 
        _arousalPeakPwrValues.AddRange(floatValues);

        string fileDataGSR = File.ReadAllText(_pathGSR);
        string[] valuesGSR = fileDataGSR.Split('\n');
        float[] floatValuesGSR = Array.ConvertAll(valuesGSR, x => float.Parse(x));

        _GSRValues.AddRange(floatValuesGSR);

    }

    public static float CalculateAndGetArousalPeaks()
    {
        _currentTime = (int)(Time.fixedUnscaledTime * 10f);

        float arousalRawValueGSR = _GSRValues[_currentTime];

        if ((arousalRawValueGSR > oldArousalValueGSR) && !valleyReachedGSR)
        {
            arousalValleyGSR = oldArousalValueGSR;
            valleyReachedGSR = true;
            peakReachedGSR = false;
        }

        if (peakReachedGSR)
        {
            arousalPeakGSR = 0.0f;
            arousalPeakPwrGSR = 0.0f;

        }
        else if ((arousalRawValueGSR < oldArousalValueGSR) && !peakReachedGSR)
        {
            arousalPeakGSR = oldArousalValueGSR;
            peakReachedGSR = true;
            valleyReachedGSR = false;

            arousalPeakPwrGSR = arousalPeakGSR - arousalValleyGSR;
        }

        oldArousalValueGSR = arousalRawValueGSR;

//        if (arousalPeakPwr != 0) Debug.Log("GSR PEAK PWR: " + arousalPeakPwrGSR);

        return arousalPeakPwrGSR;
    }

    public static float ReadDataFromStream(float arousalRawValue)
    {
        if ((arousalRawValue > oldArousalValue) && !valleyReached)
        {
            arousalValley = oldArousalValue;
            valleyReached = true;
            peakReached = false;
        }

        if (peakReached)
        {
            arousalPeak = 0.0f;
            arousalPeakPwr = 0.0f;

        }
        else if ((arousalRawValue < oldArousalValue) && !peakReached)
        {
            arousalPeak = oldArousalValue;
            peakReached = true;
            valleyReached = false;

            arousalPeakPwr = arousalPeak - arousalValley;
        }



        oldArousalValue = arousalRawValue;


//        if (arousalPeakPwr != 0) Debug.Log(arousalPeakPwr);

        return arousalPeakPwr;
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
