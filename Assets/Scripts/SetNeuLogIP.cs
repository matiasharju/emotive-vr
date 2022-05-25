using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;



public class SetNeuLogIP : MonoBehaviour
{
    private StreamWriter streamWriter;
    private StreamReader streamReader;

    public InputField inputField;
    public NeuLogAPIRequest neuLogAPIRequest;
    public Text currentIP;

    void Start()
    {
        if (File.Exists("NeuLogIP.conf"))
        {
            streamReader = new StreamReader("NeuLogIP.conf");
            neuLogAPIRequest.NeuLogIP = streamReader.ReadToEnd();
            streamReader.Close();
        }

        currentIP.text = neuLogAPIRequest.NeuLogIP;
        inputField.onEndEdit.AddListener(SetIP);

    }

    private void SetIP(string IP)
    {
        neuLogAPIRequest.NeuLogIP = IP;
        currentIP.text = neuLogAPIRequest.NeuLogIP;

        streamWriter = new StreamWriter("NeuLogIP.conf");
        streamWriter.WriteLine(IP);
        streamWriter.Close();
    }
}
