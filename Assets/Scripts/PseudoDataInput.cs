using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoDataInput : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float pseudoValence = 0.5F; 		// 0 to 1
    [Range(0.0f, 1.0f)]
    public float pseudoArousal = 0.5F;      // 0 to 1

    public float GetValence()
    {
        return pseudoValence;
    }

    public float GetArousal()
    {
        return pseudoArousal;
    }

    private void Update()
    {
        if (Input.GetKeyDown("L")) pseudoValence = pseudoValence + 0.05f;
    }
}
