using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NeuLogAPIRequest : MonoBehaviour
{
    public void RequestArousalFromNeuLog(string IP, string port, string request)
    {
        StartCoroutine(SendHTTPRequest("http://" + IP + ":" + port + request));
    }

    IEnumerator SendHTTPRequest(string request)
    {


        using (UnityWebRequest webRequest = UnityWebRequest.Get(request))
        {
            //Debug.Log(request);
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
