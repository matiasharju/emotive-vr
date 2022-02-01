using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreudOrKarl : MonoBehaviour
{

    public GameObject FreudTextObject;
    public GameObject KarlTextObject;

    // Sequences to add 
    public List<Sequence> FreudSequences;
    public List<Sequence> KarlSequences;

    private void Awake()
    {
        KarlTextObject.SetActive(false);
        FreudTextObject.SetActive(false);
    }
    void Start()
    {
        if (DirectorSequencer.Instance.FreudPlayed)
        {
            KarlTextObject.SetActive(true);
            StartCoroutine(StartNewViewpoint("Karl"));
        }

        else if (DirectorSequencer.Instance.KarlPlayed)
        {
            FreudTextObject.SetActive(true);
            StartCoroutine(StartNewViewpoint("Freud"));
        }

        else
        {
            Debug.Log("Error, no Freud or Karl yet played!");
        }


    }

    public List<Sequence> GetFreudSequences()
    {
        return FreudSequences;
    }
    public List<Sequence> GetKarlSequences()
    {
        return KarlSequences;
    }

    IEnumerator StartNewViewpoint(string nextSequence)
    {
        Debug.Log("Next sequence: " + nextSequence);
        yield return new WaitForSeconds(5);
        if (nextSequence == "Freud") DirectorSequencer.Instance.PlayFreud(this);
        if (nextSequence == "Karl") DirectorSequencer.Instance.PlayKarl(this);

    }
}
