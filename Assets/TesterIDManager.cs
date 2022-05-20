using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesterIDManager : MonoBehaviour
{
    public InputField inputField;
    public Text currentTesterID;

    void Start()
    {
        inputField.onEndEdit.AddListener(SetID);
    }

    private void SetID(string ID)
    {
        DataRecorder.testerID = ID;
        currentTesterID.text = ID;
    }

}
