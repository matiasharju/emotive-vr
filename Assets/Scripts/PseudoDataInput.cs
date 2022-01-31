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

    public void IncreaseValence()
    {
        pseudoValence = pseudoValence + 0.05f;
    }

    public void DecreaseValence()
    {
        pseudoValence = pseudoValence - 0.05f;
    }

    public void IncreaseArousal()
    {
        pseudoArousal = pseudoArousal + 0.05f;
    }

    public void DecreaseArousal()
    {
        pseudoArousal = pseudoArousal - 0.05f;
    }

}
