using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public static class DataRecorder
{
    static StreamWriter sw;
    public static string sessionID;
    public static bool enableRecording = true;
    public static bool enableWriting = false;

    static DateTime dateTimeOnStart;
    static float timeSecondsOnStart;

    public static void StartRecording()     // called from KeyboardControls.cs
    {
        if (enableRecording)
        {
            dateTimeOnStart = DateTime.Now;
            string date = dateTimeOnStart.ToString("yyyy-MM-dd");
            string timeHours = dateTimeOnStart.ToString("HH");
            string timeMinutes = dateTimeOnStart.ToString("mm");
            string fileName = "EmotiveVR_" + date + "_" + timeHours + "h" + timeMinutes + "_" + sessionID + ".csv";
            sw = new StreamWriter(fileName);
            sw.WriteLine("EMOTIVE VR DATA RECORDING");
            sw.WriteLine("Date (year-month-day): " + date);
            sw.WriteLine("Playback start time: " + timeHours + ":" + timeMinutes);
            sw.WriteLine("Session ID: " + sessionID);
            sw.WriteLine("\n");
            sw.WriteLine("Time from playback start (s),Sequence name,Video clip name,Video time (s),GSR,Arousal peak power");
            sw.Flush();

            timeSecondsOnStart = (float)(dateTimeOnStart.TimeOfDay.TotalSeconds);

            enableWriting = true;

        }
    }

    public static void WriteData(string sequenceName, string videoClipName, double timeInSeconds, float GSR, float arousalPeak)      // called from DirectorSequencer.cs
    {
        if (enableWriting)      // boolean set true by StartRecording() method
        {
            DateTime dateTimeUpdate = DateTime.Now;
            float timeSecondsUpdate = (float)(dateTimeUpdate.TimeOfDay.TotalSeconds) - timeSecondsOnStart;
            sw.WriteLine(timeSecondsUpdate.ToString("F2") + "," + sequenceName + "," + videoClipName + "," + timeInSeconds.ToString("F2") + "," + GSR + "," + arousalPeak);
            sw.Flush();
        }
    }
}
