using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNeuLogIP : MonoBehaviour
{
    public InputField inputField;
    public NeuLogAPIRequest neuLogAPIRequest;
    public Text currentIP;

    void Start()
    {
        currentIP.text = neuLogAPIRequest.NeuLogIP;
        inputField.onEndEdit.AddListener(SetIP);
    }

    private void SetIP(string IP)
    {
        neuLogAPIRequest.NeuLogIP = IP;
        currentIP.text = neuLogAPIRequest.NeuLogIP;
    }
}
