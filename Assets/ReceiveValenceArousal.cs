using UnityEngine;
using System.Collections;

public class ReceiveValenceArousal : MonoBehaviour
{
    public OSC osc;
    public static float valence;
    public static float arousal;

    void Start()
    {
        osc.SetAddressHandler("/va", OnReceiveValence);
//        osc.SetAddressHandler("/ar", OnReceiveArousal);
    }

    void OnReceiveValence(OscMessage message)
    {
        Debug.Log(message);
        valence = message.GetFloat(0);
        arousal = message.GetFloat(1);
    }
    void OnReceiveArousal(OscMessage message)
    {
        arousal = message.GetFloat(0);
    }
}