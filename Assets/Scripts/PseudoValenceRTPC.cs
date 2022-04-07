using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoValenceRTPC : MonoBehaviour {

	public bool generateRandomValence;

	[Range(0.0f,1.0f)]
	public float pseudoValence = 0.5F; 		// 0 to 1
	float randomValence = 0.5f;
	public float sampleInterval = 7.0f;
	public float smoothTime = 5.0f;
	float velocity = 0.0f; 

	void Start()
	{
		if (generateRandomValence) StartCoroutine(RandomValence());
	}

	void Update () 
	{
		if (generateRandomValence) pseudoValence = Mathf.SmoothDamp(pseudoValence, randomValence, ref velocity, smoothTime);
		AkSoundEngine.SetRTPCValue(AkSoundEngine.GetIDFromString("ValenceLevel"), pseudoValence);
	}

	IEnumerator RandomValence()
	{
		while(true)
		{
			randomValence = Random.Range (0f, 1f);
			yield return new WaitForSeconds(sampleInterval);
		}
	}	
}