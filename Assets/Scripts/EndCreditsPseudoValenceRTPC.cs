using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditsPseudoValenceRTPC : MonoBehaviour
{

    public float pseudoValence = 0.5f; 		// 0 to 1
    float targetValence;
    public float smoothTime = 7.0f;
    float velocity = 0.0f;

    void Start()
    {
        StartCoroutine(ValenceSequence());
    }

    void Update()
    {
        pseudoValence = Mathf.SmoothDamp(pseudoValence, targetValence, ref velocity, smoothTime);
        AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("ValenceLevel"), pseudoValence);
    }

    IEnumerator ValenceSequence()
    {
        targetValence = 0.5f;
        smoothTime = 0.1f;
        yield return new WaitForSeconds(20);
        targetValence = 0.7f;
        smoothTime = 1.0f;
        yield return new WaitForSeconds(27);
        targetValence = 1.0f;
        smoothTime = 1.0f;
        yield return new WaitForSeconds(70);
        targetValence = 0.5f;
        smoothTime = 0.1f;
    }
}
