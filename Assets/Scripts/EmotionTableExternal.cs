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

    private void Awake()
    {
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

}
