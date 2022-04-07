using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSmokeColour : MonoBehaviour
{
    public ParticleSystem smokeParticleSystem;
    public Light negativeValenceLight;
    public Light positiveValenceLight;

    public float maxIntensity = 2.0f;

    PseudoDataInput pseudoDataInput;
    float valenceTarget;
    float valence;
    float velocity = 0.0f;
    public float smoothTime = 0.5f;


    Light light;

    void Start()
    {

        light = GetComponent<Light>();
        pseudoDataInput = GameObject.FindGameObjectWithTag("PseudoDataInput").GetComponent<PseudoDataInput>();

        positiveValenceLight.intensity = 0.0f;
        negativeValenceLight.intensity = 0.0f;

        StartCoroutine(CO_UpdateValenceTime());
    }

    IEnumerator CO_UpdateValenceTime()
    {
        var lights = smokeParticleSystem.lights;
        valenceTarget = pseudoDataInput.GetValence();  // Read from debug valence slider


        if (valence >= 0.5f)
        {
            lights.light = positiveValenceLight;
        }

        if (valence < 0.5f)
        {
            lights.light = negativeValenceLight;
        }

        yield return new WaitForSeconds(0.5f);

        UpdateAgain();
    }

    void UpdateAgain()
    {
        StartCoroutine(CO_UpdateValenceTime());
    }

    void Update()
    {
        valence = Mathf.SmoothDamp(valence, valenceTarget, ref velocity, smoothTime);
//        Debug.Log(valenceTarget + " - " + valence);

        // DataReader.UpTime();
        // float valence = DataReader.GetValence();     // Read from CSV

        if (valence >= 0.5f)
        {
            float normal = Mathf.InverseLerp(0.5f, 1.0f, valence);
            positiveValenceLight.intensity = Mathf.Lerp(0.0f, maxIntensity, normal);
        }

        if (valence < 0.5f)
        {
            float normal = Mathf.InverseLerp(0.5f, 0.0f, valence);
            negativeValenceLight.intensity = Mathf.Lerp(0.0f, maxIntensity, normal);
        }
    }
}
