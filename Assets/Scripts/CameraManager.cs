using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Rendering.PostProcessing;

// Manage the camera
public class CameraManager : MonoBehaviour
{
    // POST-PROCESSING COMPONENTS
 //   public PostProcessLayer layer;
 //   public PostProcessVolume volume;

    // Lerp color speed (for post-process)
    public float speed;

    // Define if we can control the camera with mouse (to reproduce VR HEADSET movement) (TEST ONLY)
    public bool controlCameraWithMouse;
    
    // Control for the camera with mouse
    public float speedHorizontal;
    public float speedVertical;

    // Define the color for the valence value change in the Karl B scene
    public Color positiveValenceColor;
    public Color negativeValenceColor;
    public Color neutralColor;

    // The color grading component from post-process profil
 //   private ColorGrading _colorGradingLayer;

    // Lerp components
    private float _colorRatio;
    private Color _filterColorStart;
    private Color _filterColorEnd;

    // Camera rotation values
    private float yaw = 0;
    private float pitch = 0;

    private bool _lerpFilterColor;  

    private void Awake()
    {
 //       layer = GetComponent<PostProcessLayer>();
 //       volume = GetComponent<PostProcessVolume>();
    }

    /*
    // Enable post process on camera and load a profil
    public void SetPostProcess(bool active, PostProcessProfile profile)
    {
       layer.enabled = active;
        volume.enabled = active;
        volume.profile = profile;
   }

    // Disable post process
    public void DisablePostProcess()
    {
        volume.enabled = false;
    }

    // Change the color grading parameters
    public void UpdateFilterColor(float valence)
    {
        if(_colorGradingLayer == null)
        {
            volume.profile.TryGetSettings(out _colorGradingLayer);
            _colorGradingLayer.enabled.value = true;
        }
        _colorRatio = 0;
        _filterColorStart = _colorGradingLayer.colorFilter.value;
        _filterColorEnd = (valence < 0.5f) ? InterpolateColor(valence, negativeValenceColor, neutralColor) : InterpolateColor(valence, neutralColor, positiveValenceColor);
        _lerpFilterColor = true;

    }
    */

    // Calcul the color value from valence
    public Color InterpolateColor(float valence, Color minColor, Color maxColor)
    {
        float r = InterpolateValence(valence, minColor.r, maxColor.r);
        float g = InterpolateValence(valence, minColor.g, maxColor.g);
        float b = InterpolateValence(valence, minColor.b, maxColor.b);

        return new Color(r, g, b, 1);
    }

    // Calcul the new valence value in new range
    private float InterpolateValence(float valence, float newMinRange, float newMaxRange)
    {
        return (valence * (newMaxRange - newMinRange)) / 1 + newMinRange;
    }


    private void Update()
    {
        if(_lerpFilterColor)
        {
            _lerpFilterColor = _colorRatio < 1;
            _colorRatio += Time.deltaTime * speed;
 //           _colorGradingLayer.colorFilter.value = Color.Lerp(_filterColorStart, _filterColorEnd, _colorRatio);
        }

        if(controlCameraWithMouse)
        {
            pitch -= speedVertical * Input.GetAxis("Mouse Y");
            yaw += speedHorizontal * Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }
    }
}
