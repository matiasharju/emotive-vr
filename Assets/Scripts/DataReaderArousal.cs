using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class DataReaderArousal
{
    private static string _pathGSR;
    private static string _filenameGSR;
    private static string _path;
    private static string _filename;

    private static List<float> _GSRValues = new List<float>();
    private static List<float> _arousalPeakPwrValues = new List<float>();

    private static int _startTime = 0;       // time in tenth of seconds
    public static int _currentTime = 0;      // time in tenth of seconds
    public static int _currentPlusStartTime;

    static bool firstTime = true;

    private static float arousalPeak;
    private static float arousalValley;
    private static float arousalPeakPwr;
    public static bool peakReached = false;
    public static bool valleyReached = false;
    public static float oldArousalValue = 0.0f;


    public static float arousalRawValuePublic;

    static float startTimeOld;
    static int minusTime;

    public static void Init(string GSRfilename, string PeakCSVfilename)
    {
        _pathGSR = Application.streamingAssetsPath + "/SensorData/" + GSRfilename;
        _path = Application.streamingAssetsPath + "/SensorData/" + PeakCSVfilename;
        ReadDataFromCSV();
    }

    public static void ReadDataFromCSV()
    {
        // GSR raw data
        string fileDataGSR = File.ReadAllText(_pathGSR);
        string[] valuesGSR = fileDataGSR.Split('\n');
        float[] floatValuesGSR = Array.ConvertAll(valuesGSR, x => float.Parse(x));

        _GSRValues.AddRange(floatValuesGSR);


        // Pre-calculated arousal peaks
        string fileData = File.ReadAllText(_path);
        string[] values = fileData.Split('\n');

        float[] floatValues = Array.ConvertAll(values, x => float.Parse(x));
 
        _arousalPeakPwrValues.AddRange(floatValues);


    }

    public static float ReadArousalFromCSV(float startTime)
    {
        if (startTime != startTimeOld) minusTime = _currentTime;        // when a new startTime is passed, substract _currentTime from the _currentPlusStartTime
        startTimeOld = startTime;
        _currentTime = (int)(Time.fixedUnscaledTime * 10f);
        _startTime = (int)(startTime * 10);
        _currentPlusStartTime = _currentTime + _startTime - minusTime;

        float arousalRawValueCSV = _GSRValues[_currentPlusStartTime];
        arousalRawValuePublic = arousalRawValueCSV;

        return arousalRawValueCSV;

    }



    public static float ReadArousalFromNeuLog(string neuLogData)
    {
        var parsedNeuLogData = JObject.Parse(neuLogData);

        try
        {
            float arousalRawValueNeuLog = parsedNeuLogData["GetSensorValue"][0].Value<float>();
            arousalRawValuePublic = arousalRawValueNeuLog;
            return arousalRawValueNeuLog;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0f;
    }




    public static float CalculateArousalPeaks(float arousalRawValue)
    {
        if (firstTime)      // prevents creation of arousal peak, if the first incoming data is descending
        {
            oldArousalValue = arousalRawValue;
            peakReached = true;
        }

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

        firstTime = false;

        return arousalPeakPwr;
    }

    public static float GetArousalPeak(float startTime)
    {
        _currentTime = (int)(Time.fixedUnscaledTime * 10f);
        //        _currentTime = (int)(Mathf.Round((Time.fixedUnscaledTime * 10f) * 1f));

        _startTime = (int)(startTime * 10);
        _currentPlusStartTime = _currentTime + _startTime;
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
