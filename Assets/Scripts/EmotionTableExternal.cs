using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmotionTableExternal : MonoBehaviour
{
    public Transform pointerObject;
    Vector3 pointerPosition;
    float pointerPosHorizontal;
    float pointerPosVertical;

    public GameObject dataDiagramObject;
    private DD_DataDiagram m_DataDiagram;
    Color arousalColor;
    private GameObject line;

    private float m_Input = 0f;

    GameObject lineArousal;

    DD_Lines dD_Lines_Arousal;

    private void Start()
    {
        InitialiseDataDiagram();
        lineArousal = GameObject.Find("LineArousal");
        Invoke("ActivateLines", 1.0f);
    }

    private void ActivateLines()
    {
        if (lineArousal != null)
        {
            dD_Lines_Arousal = lineArousal.GetComponent<DD_Lines>();
            dD_Lines_Arousal.enabled = true;
        }
    }

    public void UpdateEmotionTable(float valenceValue, float arousalValue)
    {
        float normalX = Mathf.InverseLerp(0.0f, 1.0f, valenceValue);
        pointerPosition.x = Mathf.Lerp(-50f, 50f, normalX);

        float normalY = Mathf.InverseLerp(0.0f, 4.0f, arousalValue);
        pointerPosition.y = Mathf.Lerp(-50f, 50f, normalY);

        pointerPosition.z = 0.0f;

        pointerObject.localPosition = pointerPosition;

        float currentValence = valenceValue;
    }

    public void InitialiseDataDiagram()
    {
        arousalColor = Color.green;
        m_DataDiagram = dataDiagramObject.GetComponent<DD_DataDiagram>();
        line = m_DataDiagram.AddLine("Arousal", arousalColor);
    }

    public void DrawDataDiagram(float arousalRawValue)
    {
        //        int counter = 0;
//        Debug.Log(arousalRawValue);
        m_DataDiagram.InputPoint(line, new Vector2(0.01f, arousalRawValue));


//        m_DataDiagram.InputPoint(line, new Vector2(0.1f, (Mathf.Sin(counter + arousalRawValue) + 1f) * 2f));

//        counter++;
    }
}   
