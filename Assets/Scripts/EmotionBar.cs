using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmotionBar : MonoBehaviour
{
    // A black background for the generic
	public GameObject background;

	// The image of positive values 
    public Image barPos;
    
    // The image of negative values
    public Image barNeg;

    // All texts set in the bar 
    public TextMeshProUGUI title;
    public TextMeshProUGUI subtitle;
    public TextMeshProUGUI plus;
    public TextMeshProUGUI minus;

    // The origin value for lerp
    private float _startAmountValue;
    
    // The target amount for lerp
    private float _endAmountValue;
    
    // Define the percent of lerp for positive values
    private float _fillRatioYellow;
    
    // Define the percent of lerp for negative values
    private float _fillRatioBlue;
    
    // Active lerp for negative values
    private bool _lerpBlue;
    
    // Active lerp for positive values
    private bool _lerpYellow;
    
    // If we need to switch from positive to negative value
    private bool _yellowToBlue;
    
    // Same but from negative to positive values
    private bool _blueToYellow;

    // All positions informations for bar (for Freud and Karl sequence)
    private List<Sequence.BarPositionInfo> _infos = new List<Sequence.BarPositionInfo>();
    
    // Current index of position
    private int _infoIndex;
    
    // Time to change position
    private float _timer;
    private float _waitNextPlanTime;
    private bool _waitTimer;

    // The start position of the bar. If the bar change position, we can easily reset it position with this.
    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    // Calcul new bar state 
    public void UpdateEmotionBar(float valenceValue)
    {
        // Reset variable value
        _yellowToBlue = false;
        _blueToYellow = false;
        _lerpBlue = false;
        _lerpYellow = false;

        _fillRatioBlue = 0;
        _fillRatioYellow = 0;

        _startAmountValue = (barPos.fillAmount > 0) ? barPos.fillAmount : barNeg.fillAmount;

        // Valence value is between 0 and 1. But we need to cut the value in two range [0;0.5] for negative values and [0.5;1] for positive value
        // So we check the valence value and we calculate it new value in the specific range
        if(valenceValue >= 0.5f)
        {
            _endAmountValue = (((valenceValue - 0.5f) * 1) / 0.5f) + 0;
        }
        else
        {
//            _endAmountValue = (((valenceValue - 0) * 1) / 0.5f) + 0;      // original impelementation where negative bar goes opposite direction

            float normal = Mathf.InverseLerp(0.0f, 0.5f, valenceValue);     // new implementation where negative bar goes logically
            _endAmountValue = Mathf.Lerp(1.0f, 0.0f, normal);
        }

        // Defining which lerp apply
        if (valenceValue >= 0.5f && barNeg.fillAmount == _startAmountValue)
        {
            _blueToYellow = true;
            _lerpBlue = true;
            _lerpYellow = true;
        }
        else if(valenceValue < 0.5f && barPos.fillAmount == _startAmountValue)
        {
            _yellowToBlue = true;
            _lerpBlue = true;
            _lerpYellow = true;
        }
        else if(valenceValue >= 0.5f && barPos.fillAmount == _startAmountValue)
        {
            _lerpYellow = true;
        }
        else
        {
            _lerpBlue = true;
        }
    }

    // Get all bar positions informations
    public void MapBarInfo(List<Sequence.BarPositionInfo> barInfos)
    {
        _infoIndex = 0;
        _infos = barInfos;
    }

    // Lerp the positive bar
    private void LerpYellow(float timeToLerp, float startValue, float endValue)
    {
        _fillRatioYellow += Time.deltaTime / timeToLerp;
        _lerpYellow = _fillRatioYellow < 1;
        barPos.fillAmount = Mathf.Lerp(startValue, endValue, _fillRatioYellow);
    }

    // Lerp the negative bar
    private void LerpBlue(float timeToLerp, float startValue, float endValue)
    {
        _fillRatioBlue += Time.deltaTime / timeToLerp;
        _lerpBlue = _fillRatioBlue < 1;
        barNeg.fillAmount = Mathf.Lerp(startValue, endValue, _fillRatioBlue);
    }

    // Show or hide all texts
    public void ShowOrHideText(bool hide)
    {
		title.gameObject.SetActive(!hide);
		subtitle.gameObject.SetActive(!hide);
		plus.gameObject.SetActive(!hide);
		minus.gameObject.SetActive(!hide);
    }

    // Show or hide backgroung
	public void ShowOrHideBackground(bool show)
	{
		background.SetActive(show);
	}

    public void ResetPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = _startPosition;
    }

    // Update the bar position and rotation
    public void UpdateBar(long frame)
    {
        if (_infoIndex < _infos.Count)
        {
            if (frame >= _infos[_infoIndex].keyFrame)
            {
                if (_infos[_infoIndex].hide)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    transform.position = _infos[_infoIndex].position;
                    transform.rotation = Quaternion.Euler(_infos[_infoIndex].rotation);
                }

                ++_infoIndex;
            }
        }
    }

    private void Update()
    {
        // Apply lerp
        if(_yellowToBlue)
        {
            if(_lerpYellow)
            {
                LerpYellow(DirectorSequencer.Instance.updateValenceTime / 2, _startAmountValue, 0);
            }
            else if(_lerpBlue)
            {
                LerpBlue(DirectorSequencer.Instance.updateValenceTime / 2, 0, _endAmountValue);
            }
        }
        else if(_blueToYellow)
        {
            if (_lerpBlue)
            {
                LerpBlue(DirectorSequencer.Instance.updateValenceTime / 2, _startAmountValue, 0);
            }
            else if (_lerpYellow)
            {
                LerpYellow(DirectorSequencer.Instance.updateValenceTime / 2, 0, _endAmountValue);
            }
        }
        else
        {
            if (_lerpYellow)
            {
                LerpYellow(DirectorSequencer.Instance.updateValenceTime,_startAmountValue, _endAmountValue);
            }
            else if(_lerpBlue)
            {
                LerpBlue(DirectorSequencer.Instance.updateValenceTime, _startAmountValue, _endAmountValue);
            }
        }
    }

}
