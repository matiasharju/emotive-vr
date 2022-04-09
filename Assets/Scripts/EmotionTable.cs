using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmotionTable : MonoBehaviour
{
    public Transform pointerObject;
    Vector3 pointerPosition;
    float pointerPosHorizontal;
    float pointerPosVertical;
    public Image backgroundImage;
    public Image pointerImage;
    public float fadeTime = 3.0f;

    private void Awake()
    {
        backgroundImage.CrossFadeAlpha(0.0f, 0.0f, false);
        pointerImage.CrossFadeAlpha(0.0f, 0.0f, false);

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

    public void FadeIn()
    {
        backgroundImage.CrossFadeAlpha(1.0f, fadeTime, false);
        pointerImage.CrossFadeAlpha(1.0f, fadeTime, false);
    }

    public void FadeOut()
    {
        backgroundImage.CrossFadeAlpha(0.0f, fadeTime, false);
        pointerImage.CrossFadeAlpha(0.0f, fadeTime, false);
    }

}
