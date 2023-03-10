using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreudOrKarl : MonoBehaviour
{
    public GameObject NextViewpointObject;
    public GameObject FreudTextObject;
    public GameObject KarlTextObject;

    public float waitBeforeNextSequence = 5.0f;

    // Sequences to add 
    public List<Sequence> FreudSequencesInteractive;
    public List<Sequence> KarlSequencesInteractive;
    public List<Sequence> FreudSequencesNonInteractive;
    public List<Sequence> KarlSequencesNonInteractive;

    private void Awake()
    {
        KarlTextObject.SetActive(false);
        FreudTextObject.SetActive(false);

        if (DirectorSequencer.Instance.isInteractive) NextViewpointObject.SetActive(true);  // Show "Next Viewpoint" text only in interactive experience
        else NextViewpointObject.SetActive(false);

        if (DirectorSequencer.Instance.isInteractive) waitBeforeNextSequence = 5.0f;
        else waitBeforeNextSequence = 2.0f;                                             // Shorter delay before next viewpoint in non-interactive version without text

    }
    void Start()
    {
        if (DirectorSequencer.Instance.FreudPlayed)
        {
            if (DirectorSequencer.Instance.isInteractive) KarlTextObject.SetActive(true);
            StartCoroutine(StartNewViewpoint("Karl"));
        }

        else if (DirectorSequencer.Instance.KarlPlayed)
        {
            if (!DirectorSequencer.Instance.isInteractive) FreudTextObject.SetActive(true);
            StartCoroutine(StartNewViewpoint("Freud"));
        }

        else
        {
            Debug.Log("Error, no Freud or Karl yet played!");
        }


    }

    public List<Sequence> GetFreudSequences()
    {
        if (DirectorSequencer.Instance.isInteractive) return FreudSequencesInteractive;
        else return FreudSequencesNonInteractive;
    }
    public List<Sequence> GetKarlSequences()
    {
        if (DirectorSequencer.Instance.isInteractive) return KarlSequencesInteractive;
        else return KarlSequencesNonInteractive;
    }

    IEnumerator StartNewViewpoint(string nextSequence)
    {
        Debug.Log("Next sequence: " + nextSequence);
        yield return new WaitForSeconds(waitBeforeNextSequence);
        if (nextSequence == "Freud") DirectorSequencer.Instance.PlayFreud(this);
        if (nextSequence == "Karl") DirectorSequencer.Instance.PlayKarl(this);

    }
}
