using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoDataInput : MonoBehaviour
{
    public bool generateRandomValence;
    public bool sendPseudoArousalValues;

    [Range(0.0f, 1.0f)]
    public float pseudoValence = 0.5F; 		// 0 to 1
    [Range(0.0f, 1.0f)]
    public float pseudoArousal = 0.5F;      // 0 to 1

    float randomValence = 0.5f;
    public float sampleInterval = 7.0f;
    public float smoothTime = 5.0f;
    float velocity = 0.0f;

    public float sendArousalInterval = 0.1f;

    void Start()
    {
        if (generateRandomValence) StartCoroutine(RandomValence());
        if (sendPseudoArousalValues) StartCoroutine(SendPseudoArousalValues());
    }

    void Update()
    {
        if (generateRandomValence) pseudoValence = Mathf.SmoothDamp(pseudoValence, randomValence, ref velocity, smoothTime);
    }

    public float GetValence()
    {
        return pseudoValence;
    }

    public float GetArousal()
    {
        return pseudoArousal;
    }

    public void IncreaseValence()
    {
        pseudoValence = pseudoValence + 0.05f;
    }

    public void DecreaseValence()
    {
        pseudoValence = pseudoValence - 0.05f;
    }

    public void IncreaseArousal()
    {
        pseudoArousal = pseudoArousal + 0.05f;
    }

    public void DecreaseArousal()
    {
        pseudoArousal = pseudoArousal - 0.05f;
    }

    IEnumerator RandomValence()
    {
        while (true)
        {
            randomValence = Random.Range(0f, 1f);
            yield return new WaitForSeconds(sampleInterval);
        }
    }

    IEnumerator SendPseudoArousalValues()
    {
        while (true)
        {
            DataReaderArousalPeaks.ReadDataFromStream(pseudoArousal);   // send pseudo arousal value to DataReaderArousalPeaks.cs
            yield return new WaitForSeconds(sendArousalInterval);
        }
    }


}
