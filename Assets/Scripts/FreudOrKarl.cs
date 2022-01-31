using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreudOrKarl : MonoBehaviour
{
    void Start()
    {
/*        if (DirectorSequencer.FreudPlayed)
        {
            StartCoroutine(StartNewViewpoint("Karl"));
        }

        else if (DirectorSequencer.KarlPlayed)
        {
            StartCoroutine(StartNewViewpoint("Freud"));
        }

        else
        {
            Debug.Log("Error, no Freud or Karl yet played!");
        }
*/

    }

    IEnumerator StartNewViewpoint(string nextSequence)
    {
        Debug.Log("Next sequence: " + nextSequence);
        yield return new WaitForSeconds(5);


    }
}
