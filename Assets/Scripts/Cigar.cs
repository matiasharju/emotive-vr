using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Cigar : MonoBehaviour
{
    public List<float> timestampCigare;
    public float maxBurn;
    public float minBurn;

    private Material _burnMat;
    private float _time = 0;
    private int _indexTime = 0;

    public Color colorDark;
    public Color colorIdle;
    public Color colorInhale;

    void Start()
    {
        _burnMat = GetComponent<MeshRenderer>().material;
        _burnMat.color = colorDark;

    }


    void Update()
    {
        if(_indexTime < timestampCigare.Count)
        {
            _time += Time.deltaTime;

            if (_time >= timestampCigare[_indexTime])
            {
                _indexTime++;
                StartCoroutine(Inhale());
//                _burnMat.SetInt("_Bool_Burn", 0);
//                _burnMat.SetFloat("_Mask_Range", maxBurn);
//                StartCoroutine(CO_Wait());
                
            }
        }
    }

    IEnumerator Ignite()
    {
        float a = 0.0f;
        while (a < 1)
        {
            _burnMat.color = Color.Lerp(colorDark, colorInhale, a);
            Debug.Log(_burnMat.color);
            a = a + 0.1f;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.5f);

        while (a > 0.0f)
        {
            _burnMat.color = Color.Lerp(colorIdle, colorInhale, a);
            a = a - 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Inhale()
    {
        float a = 0.0f;
        while (a < 1)
        {
            _burnMat.color = Color.Lerp(colorIdle, colorInhale, a);
            Debug.Log(_burnMat.color);
            a = a + 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(1.5f);

        while (a > 0.0f)
        {
            _burnMat.color = Color.Lerp(colorIdle, colorInhale, a);
            a = a - 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator CO_Wait()
    {
        yield return new WaitForSeconds(3);
//        _burnMat.SetInt("_Bool_Burn", 1);
    }
}
