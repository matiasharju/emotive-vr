using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manage the calibrage sequence
public class Calibrage : MonoBehaviour
{
    // List of all calibration pictures.
    public List<Sprite> calibrationImages;
    
    // The renreder to render the picture
    public Image imgRenderer;
    
    // Number of picture to show in screen
    public int nbImgToShow = 5;
    
    // Picture life time
    public float timeShowImg = 10;

    // Defini when change the picture
    private bool changeImg = true;
    
    private float _timer = 0;
    private int indexImg = 0;

    private void Start()
    {
        // Calcul the time to stay in scene
        DirectorSequencer.Instance.delay = (nbImgToShow * timeShowImg) + DirectorSequencer.Instance.fadeAnimator.GetCurrentAnimatorStateInfo(0).length;
        imgRenderer.transform.parent.GetComponent<Canvas>().worldCamera = DirectorSequencer.Instance.cam;
    }


    // Update is called once per frame
    void Update()
    {
        if(DirectorSequencer.Instance.play)
        {
            if (indexImg < calibrationImages.Count)
            {
                if (changeImg)
                {
                    imgRenderer.sprite = calibrationImages[indexImg];
                    ++indexImg;
                    changeImg = false;
                }
                _timer += Time.deltaTime;

                if (_timer >= timeShowImg)
                {
                    _timer = 0;
                    changeImg = true;
                }
            }
        }
        
    }
}
