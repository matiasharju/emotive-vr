using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NeuLogAPIRequest : MonoBehaviour
{
    public string NeuLogIP = "127.0.0.1";
    public string NeuLogPort = "22004";
    public string NeuLogRequest = "NeuLogAPI?GetSensorValue:[GSR],[1]";

    public void RequestArousalFromNeuLog()
    {
        StartCoroutine(SendHTTPRequest("http://" + NeuLogIP + ":" + NeuLogPort + "/" + NeuLogRequest));
    }

    IEnumerator SendHTTPRequest(string request)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(request))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //                    Debug.Log(webRequest.downloadHandler.text);
                    DataReaderArousal.ReadArousalFromNeuLog(webRequest.downloadHandler.text);
                    break;
            }
        }

    }

}
