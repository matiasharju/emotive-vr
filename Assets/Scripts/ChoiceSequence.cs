using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage the choice sequence
public class ChoiceSequence : MonoBehaviour
{
    // The smoke effect
    public GameObject effect;
    
    // Sequences to add 
    public List<Sequence> sequences;
    
    
    public bool nextSequence = false;
    
    // Disable the choice
    public bool blockHide = false;
    
    // This choice is epilogue
    public bool epilogue = false;
    
    // Make the effect appears or diseappears
    public bool invert = false;

    // The audio of the other choice
    public AudioSource audioToFade;

    private float _fadePercent = 1;
    private bool _raycastEnter;
    private float _timer = 0;

    private void Start()
    {
        _fadePercent = (invert) ? 0 : 1;
        if(epilogue)
        {
            if(!DirectorSequencer.Instance.showEpilogue)
            {

                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
        else if(DirectorSequencer.Instance.ContainSequence(sequences[0]) && !blockHide)
        {
            gameObject.SetActive(false);
        }
    }

    // Get sequences to add
    public List<Sequence> GetSequence()
    {
        return sequences;
    }

    // Fade out the audio of the other choice
    IEnumerator CO_FadeOutChoiceSequence(float speed)
    {
        while (_fadePercent > 0)
        {
            _fadePercent -= Time.deltaTime * (1 / DirectorSequencer.Instance.timeToChoice) * speed;
            if(epilogue)
            {
                audioToFade.volume = _fadePercent * 5;
            }
            else
            {
                audioToFade.volume = 0;
            }
            
            yield return null;
        }
        _fadePercent = 0;
        audioToFade.volume = 0;
    }

    // Fade in the audio of the other choice
    IEnumerator CO_FadeInChoiceSequence(float speed)
    {
        while (_fadePercent < 1)
        {
            _fadePercent += Time.deltaTime * (1 / DirectorSequencer.Instance.timeToChoice) * speed;
            if (epilogue)
            {
                audioToFade.volume = _fadePercent * 5;
            }
            else
            {
                audioToFade.volume = 1;
            }
            yield return null;
        }

        _fadePercent = 1;
        audioToFade.volume = 1;

    }

    // Active the smoke effect
    public void ActiveEffect(bool active)
    {
		if(gameObject.activeSelf)
        	effect.SetActive(active);
    }

    // If the user watch this choice
    public void OnRaycastEnter()
    {
        if(!_raycastEnter)
        {
            StopAllCoroutines();
            if (!invert)
            {
                StartCoroutine(CO_FadeOutChoiceSequence(1));
            }
            else
            {
                StartCoroutine(CO_FadeInChoiceSequence(1));
            }

            ActiveEffect(true);
            GetComponent<AudioSource>().Play();
            _raycastEnter = true;
        }

        _timer += Time.deltaTime;

        if(_timer >= (epilogue ? DirectorSequencer.Instance.timerChoiceEpi : DirectorSequencer.Instance.timeToChoice))
        {
            DirectorSequencer.Instance.ValidateChoice(this);
            // fade out sounds (but if using master fader, then reset in the beginning of the next sequence)
        }
       
    }

    // If the user doesn't watch this choice
    public void OnRaycastExit()
    {
        if(_raycastEnter)
        {
            StopAllCoroutines();
            if (!invert)
            {
                StartCoroutine(CO_FadeInChoiceSequence(4));
            }
            else
            {
                StartCoroutine(CO_FadeOutChoiceSequence(4));
            }

            ActiveEffect(false);
            _raycastEnter = false;
        }
        _timer = 0;
      
    }
}
