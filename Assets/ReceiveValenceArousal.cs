using UnityEngine;
using System.Collections;

public class ReceiveValenceArousal : MonoBehaviour
{
    public OSC osc;
    public static int valence;
    public static int arousal;

    void Start()
    {
        osc.SetAddressHandler("/valence", OnReceiveValence);
        osc.SetAddressHandler("/arousal", OnReceiveArousal);
    }

    void OnReceiveValence(OscMessage message)
    {
        valence = message.GetInt(0);
    }
    void OnReceiveArousal(OscMessage message)
    {
        arousal = message.GetInt(0);
    }
}